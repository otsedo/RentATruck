﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Procesos
{
    public partial class proCuentasXCobrar : Form
    {
        int CodigoCxC, CodigoCliente;
        datos objDatos = new datos();
        DataView miFiltro;
        double apagar, saldo;

        private void cmdBuscarCodCli_Click(object sender, EventArgs e)
        {
            Busquedas.busquedaClientes f2 = new Busquedas.busquedaClientes();
            DialogResult res = f2.ShowDialog();

            if (res == DialogResult.OK)
            {
                CodigoCliente = Convert.ToInt16(f2.ReturnValue1);
                this.txtNombreCliente.Text = f2.ReturnValue2;
                this.txtCodigoCliente.Text = CodigoCliente.ToString();
            }
        }

        private void actualizarDatosFactura()
        {

            objDatos.Consulta_llenar_datos("select f.numfac_fac as 'No. Fac.',f.fecfac_fac as 'Fecha Factura',f.monfac_fac as 'Monto',u.nombre as 'Usuario',f.ncf_ncf as 'NCF',tf.descri_fac as 'Tipo Factura',cpc.saldo_final as 'Balance',f.codcli_cli as 'Codigo Cliente' from facturas f,tipo_factura tf,usuarios u,cuentas_por_cobrar cpc where f.codtip_fac = 2 and f.codtip_fac = tf.codtip_fac and f.codusuario = u.codigo_usuario and f.numfac_fac = cpc.numfac_fac and cpc.saldo_final > 0 and f.codcli_cli = " + CodigoCliente.ToString() + "");
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
                this.dataGridView1.DataSource = miFiltro;
                this.dataGridView1.Columns[0].Width = 70;
                this.dataGridView1.Columns[1].Width = 110;
                this.dataGridView1.Columns[2].Width = 70;
                this.dataGridView1.Columns[3].Width = 95;
                this.dataGridView1.Columns[4].Width = 139;
                this.dataGridView1.Columns[5].Width = 99;
                this.dataGridView1.Columns[6].Width = 65;
                this.dataGridView1.Columns[7].Width = 88;


                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView1.Columns.Add(chk);
                chk.HeaderText = "Saldar";
                chk.Name = "chk";
                dataGridView1.Rows[0].Cells[8].Value = false;
                this.dataGridView1.Columns[8].Width = 50;


                for (int a = 0; a < this.dataGridView1.Rows.Count; a++)
                {
                    //subTotal = (Convert.ToDouble(subTotal)) + Convert.ToDouble(this.dataGridView1.Rows[a].Cells["importe"].Value.ToString());
                }
            }
            else
            {
                MessageBox.Show("El cliente " + this.txtNombreCliente.Text + ", no tiene cuentas por cobrar pendientes");
            }
        }

        private void cmdCalcular_Click(object sender, EventArgs e)
        {
            if (this.txtCodigoCliente.Text != "")
            {
                objDatos.Conectar();
                this.objDatos.Consulta_llenar_datos("select SUM(saldo_final) as 'saldo' from facturas f,cuentas_por_cobrar cxc where cxc.numfac_fac = f.numfac_fac and f.codcli_cli = " + CodigoCliente.ToString());
                saldo = Convert.ToDouble(objDatos.ds.Tables[0].Rows[0][0].ToString());
                this.txtSaldo.Text = saldo.ToString("C");
                actualizarDatosFactura();
                objDatos.Desconectar();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[8].Index)
            {
                dataGridView1.EndEdit();  //Stop editing of cell.                             
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = dataGridView1.RowCount;
            for (int i = 0; i < rows; i++)
            {
                string sql = "select cpc.codigo_cpc from cuentas_por_cobrar cpc where cpc.numfac_fac = " + dataGridView1.Rows[i].Cells[0].Value + "";
                Int32 codigoCpC = 0;
                objDatos.Consulta_llenar_datos(sql);
                codigoCpC = Convert.ToInt32(objDatos.ds.Tables[0].Rows[0][0].ToString());
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("insert into cuenta_por_cobrar_temporal values (" + dataGridView1.Rows[i].Cells[0].Value + ",'" + dataGridView1.Rows[i].Cells[1].Value + "'," + dataGridView1.Rows[i].Cells[2].Value + ",'" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "'," + dataGridView1.Rows[i].Cells[6].Value + "," + dataGridView1.Rows[i].Cells[7].Value + ",'" + dataGridView1.Rows[i].Cells[8].Value + "'," + codigoCpC.ToString() + ")");
            }

            //Buscar cantidad de facturas marcadas
            objDatos.Consulta_llenar_datos("select count(numfac_fac) from cuenta_por_cobrar_temporal where saldar = 1");
            int cantFacturas = 0;
            cantFacturas = Convert.ToInt32(objDatos.ds.Tables[0].Rows[0][0].ToString());

            objDatos.Consulta_llenar_datos("insert into registro_abonos_cpc values (" + this.txtCodigoCxC.Text + "," + this.txtCodigoCliente.Text + ",'" + this.txtFecha.Text + "')");

            datos objDatos2 = new datos();

            for (int n = 0; n < cantFacturas; n++)
            {
                objDatos2.Conectar();
                objDatos2.Consulta_llenar_datos("select * from cuenta_por_cobrar_temporal where saldar = 1");
                Int32 codigoCXC = Convert.ToInt32(objDatos2.ds.Tables[0].Rows[n][9].ToString());
                DateTime fecha = Convert.ToDateTime(objDatos2.ds.Tables[0].Rows[n][1].ToString());
                Int32 numfac_fac = Convert.ToInt32(objDatos2.ds.Tables[0].Rows[n][0].ToString());
                double credito = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                double monto = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                double debito = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                double saldo_final = 0.0;

                string sql = "actualiza_cuentas_por_cobrar " + codigoCXC.ToString() + ",'" + fecha.ToShortDateString() + "'," + numfac_fac.ToString() + "," + credito.ToString() + "," + monto.ToString() + "," + debito.ToString() + "," + saldo_final.ToString() + "";
                objDatos2.Consulta_llenar_datos(sql);

                string sql2 = "insert into registro_detalles_abonos_cpc values (" + this.txtCodigoCxC.Text + "," + numfac_fac.ToString() + "," + monto.ToString() + ")";
                objDatos2.Consulta_llenar_datos(sql2);
                objDatos2.Desconectar();
            }
            objDatos.Consulta_llenar_datos("truncate table cuenta_por_cobrar_temporal");
            MessageBox.Show("Proceso concluido");
            DialogResult dialogResult = MessageBox.Show("Desea Imprimir el recibo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Form frmImprimirRecibo = new Recibos.Recibo_cpc(CodigoCxC);
                    frmImprimirRecibo.Show();
                    actualizarDatosFactura();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show("No se encuentra la factura actual");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
            objDatos.Desconectar();
        }

        private void proCuentasXCobrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("truncate table cuenta_por_cobrar_temporal");
            objDatos.Desconectar();
        }

        private void proCuentasXCobrar_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.Date.Date.ToString("MM-dd-yyyy");
            objDatos.Conectar();
            objDatos.consultar("SELECT codigo_cpc from ", "numero_cpc");
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                CodigoCxC = Convert.ToInt32(objDatos.ds.Tables["numero_cpc"].Rows[0][0].ToString()) + 1;
                this.txtCodigoCxC.Text = CodigoCxC.ToString();
            }
            else { CodigoCxC = 1; this.txtCodigoCxC.Text = CodigoCxC.ToString(); }

            this.cmbTipoPago.DataSource = objDatos.ConsultaTabla("tipo_pagos", " descri_tpa");
            this.cmbTipoPago.DisplayMember = "descri_tpa";
            this.cmbTipoPago.ValueMember = "codigo_tpa";
            objDatos.Desconectar();
        }

        public proCuentasXCobrar()
        {
            InitializeComponent();
        }
    }
}
