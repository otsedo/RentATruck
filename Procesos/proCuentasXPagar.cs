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
    public partial class proCuentasXPagar : Form
    {
        Int32 codigoCpC = 0, CodigoCliente;
        private datos objDatos3 = new datos();
        private datos objDatos = new datos();
        private datos objDatos2 = new datos();
        private static proCuentasXPagar abonocxpInstancia = null;
        DataView miFiltro;
        double apagar, saldo, deuda;
        public string codigoEmpleado;

        private void cmdBuscarCodCli_Click(object sender, EventArgs e)
        {
            Busquedas.busquedaSuplidores f2 = new Busquedas.busquedaSuplidores();
            DialogResult res = f2.ShowDialog();

            if (res == DialogResult.OK)
            {
                CodigoCliente = Convert.ToInt16(f2.ReturnValue1);
                this.txtNombreCliente.Text = f2.ReturnValue2;
                this.txtCodigoCliente.Text = CodigoCliente.ToString();
            }
        }

        public static proCuentasXPagar InstanciaAbonarCxP()
        {
            if ((abonocxpInstancia == null) || (abonocxpInstancia.IsDisposed == true))
            {
                abonocxpInstancia = new proCuentasXPagar();
            }
            abonocxpInstancia.BringToFront();
            return abonocxpInstancia;
        }

        private void actualizarDatosFactura()
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select cpp.numfac_fac as 'No. Fac.',cpp.codigo_cpp as 'CxP',cpp.fecha as 'Fecha Factura',cpp.monto as 'Monto',u.nombre_usuario as 'Usuario',cpp.ncf_ncf as 'NCF',tf.descri_fac as 'Tipo Factura',cpp.saldo_final as 'Balance',cpp.codigo_suplidor as 'Codigo Suplidor', cpp.Saldar as 'Saldar' from tipo_factura tf,usuarios u,cuentas_por_pagar cpp where cpp.codtip_fac = tf.codtip_fac and cpp.codigo_usuario = u.codigo_usuario and cpp.saldo_final > 0 and cpp.codigo_suplidor = " + CodigoCliente.ToString() + "");
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                int nSaldar = ((int)objDatos.ds.Tables[0].Rows.Count) - 1;
                this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
                this.dataGridView1.DataSource = miFiltro;
                this.dataGridView1.Columns[0].Width = 60;
                this.dataGridView1.Columns[1].Width = 60;
                this.dataGridView1.Columns[2].Width = 80;
                this.dataGridView1.Columns[3].Width = 70;
                this.dataGridView1.Columns[4].Width = 95;
                this.dataGridView1.Columns[5].Width = 139;
                this.dataGridView1.Columns[6].Width = 99;
                this.dataGridView1.Columns[7].Width = 65;
                this.dataGridView1.Columns[8].Width = 88;
                this.dataGridView1.Columns[9].Width = 50;
            }
            else
            {
                MessageBox.Show("El suplidor " + this.txtNombreCliente.Text.TrimEnd() + ", no tiene cuentas por pagar pendientes");
            }
        }

        private void cmdConsultarCuentas_Click(object sender, EventArgs e)
        {
            if (this.txtCodigoCliente.Text != "")
            {
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select SUM(saldo_final) as 'saldo' from cuentas_por_pagar cpp where cpp.codigo_suplidor = " + CodigoCliente.ToString());
                if (objDatos.ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    saldo = Convert.ToDouble(objDatos.ds.Tables[0].Rows[0][0].ToString());
                }
                this.txtSaldo.Text = saldo.ToString("C");
                objDatos.Desconectar();

                if (objDatos.ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    deuda = Convert.ToDouble(objDatos.ds.Tables[0].Rows[0][0].ToString());
                }
                if (deuda > 0)
                {
                    string sring = ("exec consultarCxP " + CodigoCliente.ToString());
                    objDatos.Consulta_llenar_datos(sring);

                    this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
                    this.dataGridView1.DataSource = miFiltro;
                    objDatos.Desconectar();

                    this.dataGridView1.Columns[0].Width = 50;
                    this.dataGridView1.Columns[1].Width = 125;
                    this.dataGridView1.Columns[2].Width = 125;
                    this.dataGridView1.Columns[3].Width = 80;
                    this.dataGridView1.Columns[4].Width = 170;

                    actualizarDatosFactura();
                    objDatos.Desconectar();
                }
                else
                {
                    MessageBox.Show("El suplidor seleccionado no tiene Cuentas por Pagar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[8].Index)
            {
                dataGridView1.EndEdit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            apagar = 0;
            int x = dataGridView1.RowCount - 1;
            for (int i = 0; i <= x; i++)
            {
                if ((Boolean)dataGridView1.Rows[i].Cells[9].Value == false)
                {

                }
                else
                {
                    apagar = apagar + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                }
            }
            this.txtAPagar.Text = apagar.ToString("C");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtAPagar.Text != "")
            {
                int rows = dataGridView1.RowCount;
                for (int i = 0; i < rows; i++)
                {
                    objDatos.Conectar();
                    objDatos3.Conectar();
                    string sql = "select cpp.codigo_cpp from cuentas_por_pagar cpp where cpp.numfac_fac = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    string referecnia = "select referecnia from cuentas_por_pagar cpp where cpp.numfac_fac = '" + dataGridView1.Rows[i].Cells[0].Value + "'";

                    objDatos.Consulta_llenar_datos(sql);
                    objDatos3.Consulta_llenar_datos(referecnia);
                    codigoCpC = Convert.ToInt32(objDatos.ds.Tables[0].Rows[0][0].ToString());

                    objDatos.Consulta_llenar_datos("insert into cuenta_por_pagar_temporal values ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "'," + dataGridView1.Rows[i].Cells[3].Value + ",'" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "'," + dataGridView1.Rows[i].Cells[7].Value + "," + dataGridView1.Rows[i].Cells[8].Value + ",'" + dataGridView1.Rows[i].Cells[9].Value + "'," + codigoCpC.ToString() + ",'" + objDatos3.ds.Tables[0].Rows[0][0].ToString() + "')");
                    objDatos.Desconectar();
                    objDatos3.Desconectar();
                }

                //Buscar cantidad de facturas marcadas
                objDatos.Consulta_llenar_datos("select count(codigo_cpp) from cuenta_por_pagar_temporal where saldar = 1");
                int cantFacturas = 0;
                cantFacturas = Convert.ToInt32(objDatos.ds.Tables[0].Rows[0][0].ToString());

                for (int n = 0; n < cantFacturas; n++)
                {
                    objDatos2.Conectar();
                    objDatos2.Consulta_llenar_datos("select * from cuenta_por_pagar_temporal where saldar = 1");
                    Int32 codigoCXP = Convert.ToInt32(objDatos2.ds.Tables[0].Rows[n][9].ToString());
                    DateTime fecha = Convert.ToDateTime(objDatos2.ds.Tables[0].Rows[n][1].ToString());
                    string numfac_fac = objDatos2.ds.Tables[0].Rows[n][0].ToString();
                    double credito = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                    double monto = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                    double debito = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                    double saldo_final = 0.0;
                    int codigocliente = Convert.ToInt16(objDatos2.ds.Tables[0].Rows[n][7].ToString());
                    string ncf = objDatos2.ds.Tables[0].Rows[n][4].ToString();
                    string referencia = objDatos2.ds.Tables[0].Rows[n][10].ToString();

                    string sql = "actualiza_cuentas_por_pagar " + codigoCXP.ToString() + ",'" + fecha.ToShortDateString() + "','" + numfac_fac.ToString() + "'," + credito.ToString() + "," + monto.ToString() + "," + debito.ToString() + "," + saldo_final.ToString() + "," + this.cmbTipoPago.SelectedValue.ToString() + "," + codigoEmpleado + "," + codigocliente.ToString() + ",'" + ncf.ToString() + "','" + referencia.ToString() + "'";
                    objDatos2.Consulta_llenar_datos(sql);

                    string sql2 = "insert into registro_detalles_abonos_cpp values (" + codigoCXP + ",'" + numfac_fac.ToString() + "'," + monto.ToString() + ")";
                    objDatos2.Consulta_llenar_datos(sql2);
                    objDatos2.Desconectar();
                    objDatos.Consulta_llenar_datos("insert into registro_abonos_cpp values (" + codigoCXP + "," + this.txtCodigoCliente.Text + ",'" + this.txtFecha.Text.ToString() + "')");
                }

                MessageBox.Show("Proceso concluido");
                objDatos.Consulta_llenar_datos("truncate table cuenta_por_pagar_temporal");
                limpiarPantall();
            }
            else
            {
                MessageBox.Show("Expecifique el monto que desea abonar a la CxP");
            }
        }

        private void limpiarPantall()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            this.txtNombreCliente.Text = "";
            this.txtCodigoCliente.Text = "";
            this.txtAPagar.Text = "";
            this.txtSaldo.Text = "";
        }

        private void proCuentasXPagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("truncate table cuenta_por_pagar_temporal");
            objDatos.Desconectar();
        }

        private void proCuentasXPagar_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.Date.Date.ToString("yyyy-MM-dd");
            objDatos.Conectar();
            this.cmbTipoPago.DataSource = objDatos.ConsultaTabla("tipo_pagos", " descri_tpa");
            this.cmbTipoPago.DisplayMember = "descri_tpa";
            this.cmbTipoPago.ValueMember = "codigo_tpa";
            objDatos.Desconectar();
        }

        public proCuentasXPagar()
        {
            InitializeComponent();
        }
    }
}