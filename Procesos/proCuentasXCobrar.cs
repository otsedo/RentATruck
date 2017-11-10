using System;
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
    public partial class proCuentasxCobrar : Form
    {
        int CodigoCxC, CodigoCliente;
        datos objDatos = new datos();
        datos objDatos3 = new datos();
        datos objDatos2 = new datos();
        DataView miFiltro;
        double acobrar, saldo;

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

        private void proCuentasxCobrar_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            acobrar = 0;
            int x = dataGridView1.RowCount - 1;
            for (int i = 0; i <= x; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[9].Value == true)
                {
                    acobrar = acobrar + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                }
            }
            this.txtAPagar.Text = acobrar.ToString("C");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[8].Index)
            {
                dataGridView1.EndEdit();
            }
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
                    string sql = "select cpc.codigo_cpc from cuentas_por_cobrar cpc where cpc.numfac_fac = " + dataGridView1.Rows[i].Cells[0].Value + "";
                    Int32 codigoCpC = 0;
                    objDatos.Consulta_llenar_datos(sql);
                    codigoCpC = Convert.ToInt32(objDatos.ds.Tables[0].Rows[0][0].ToString());

                    objDatos.Consulta_llenar_datos("insert into cuenta_por_cobrar_temporal values (" + dataGridView1.Rows[i].Cells[0].Value + ",'" + dataGridView1.Rows[i].Cells[2].Value + "'," + dataGridView1.Rows[i].Cells[3].Value + ",'" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "'," + dataGridView1.Rows[i].Cells[7].Value + "," + dataGridView1.Rows[i].Cells[8].Value + ",'" + dataGridView1.Rows[i].Cells[9].Value + "'," + codigoCpC.ToString() + ")");
                }
                objDatos.Desconectar();
                objDatos3.Desconectar();
                objDatos.Consulta_llenar_datos("select count(codigo_cpc) from cuenta_por_cobrar_temporal where saldar = 1");
                int cantFacturas = 0;
                cantFacturas = Convert.ToInt32(objDatos.ds.Tables[0].Rows[0][0].ToString());

                for (int n = 0; n < cantFacturas; n++)
                {
                    objDatos2.Conectar();
                    objDatos2.Consulta_llenar_datos("select * from cuenta_por_cobrar_temporal where saldar = 1");
                    Int32 codigoCXP = Convert.ToInt32(objDatos2.ds.Tables[0].Rows[n][9].ToString());
                    DateTime fecha = Convert.ToDateTime(objDatos2.ds.Tables[0].Rows[n][1].ToString());
                    string numfac_fac = objDatos2.ds.Tables[0].Rows[n][0].ToString();
                    double credito = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                    double monto = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                    double debito = Convert.ToDouble(objDatos2.ds.Tables[0].Rows[n][2].ToString());
                    double saldo_final = 0.0;
                    int codigocliente = Convert.ToInt16(objDatos2.ds.Tables[0].Rows[n][7].ToString());
                    string ncf = objDatos2.ds.Tables[0].Rows[n][4].ToString();

                    string sql = "actualiza_cuentas_por_cobrar " + codigoCXP.ToString() + ",'" + fecha.ToShortDateString() + "'," + numfac_fac.ToString() + "," + credito.ToString() + "," + monto.ToString() + "," + debito.ToString() + "," + saldo_final.ToString() + "";
                    objDatos2.Consulta_llenar_datos(sql);

                    string sql2 = "insert into registro_detalles_abonos_cpc values (" + codigoCXP + ",'" + numfac_fac.ToString() + "'," + monto.ToString() + ")";
                    objDatos2.Consulta_llenar_datos(sql2);
                    objDatos2.Desconectar();
                    objDatos.Consulta_llenar_datos("insert into registro_abonos_cpc values (" + codigoCXP + "," + this.txtCodigoCliente.Text + ",'" + this.txtFecha.Text.ToString() + "')");
                }

                MessageBox.Show("Proceso concluido");
                objDatos.Consulta_llenar_datos("truncate table cuenta_por_cobrar_temporal");
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

        private void proCuentasxCobrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("truncate table cuenta_por_cobrar_temporal");
            objDatos.Desconectar();
        }

        private void cmdConsultarCuentas_Click(object sender, EventArgs e)
        {
            objDatos.Conectar();
            this.objDatos.Consulta_llenar_datos("select SUM(saldo_final) as 'saldo' from cuentas_por_cobrar cpc, facturas f where cpc.numfac_fac = f.numfac_fac and f.codtip_fac = 2 and f.codcli_cli = " + CodigoCliente.ToString());

            if (objDatos.ds.Tables[0].Rows[0][0].ToString() != "")
            {
                saldo = Convert.ToDouble(objDatos.ds.Tables[0].Rows[0][0].ToString());
            }

            this.txtSaldo.Text = saldo.ToString("C");
            actualizarDatosFactura();
            objDatos.Desconectar();
        }

        private void actualizarDatosFactura()
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select f.numfac_fac as 'No. Fac.',cpc.codigo_cpc as 'CxP',f.fecfac_fac as 'Fecha Factura',f.monfac_fac as 'Monto',c.nombre as 'Cliente',f.ncf_ncf as 'NCF',tf.descri_fac as 'Tipo Factura',cpc.saldo_final as 'Balance',f.codcli_cli as 'Codigo Cliente',cpc.Saldar as 'Saldar' from facturas f,tipo_factura tf,cuentas_por_cobrar cpc, clientes c  where f.codtip_fac = 2 and f.codtip_fac = tf.codtip_fac and f.codcli_cli = c.codigo_cliente and f.numfac_fac = cpc.numfac_fac and cpc.saldo_final > 0 and f.codcli_cli = " + CodigoCliente.ToString() + "");
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                int nSaldar = ((int)objDatos.ds.Tables[0].Rows.Count) - 1;
                this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
                this.dataGridView1.DataSource = miFiltro;
                this.dataGridView1.Columns[0].Width = 60;
                this.dataGridView1.Columns[1].Width = 60;
                this.dataGridView1.Columns[2].Width = 80;
                this.dataGridView1.Columns[3].Width = 70;
                this.dataGridView1.Columns[4].Width = 113;
                this.dataGridView1.Columns[5].Width = 139;
                this.dataGridView1.Columns[6].Width = 99;
                this.dataGridView1.Columns[7].Width = 65;
                this.dataGridView1.Columns[8].Width = 68;
                this.dataGridView1.Columns[9].Width = 50;
                dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[2].DefaultCellStyle.Format = "dd-MM-yyyy";
            }
            else
            {
                MessageBox.Show("El cliente " + this.txtNombreCliente.Text.TrimEnd() + ", no tiene cuentas por cobrar pendientes");
            }
        }

        public proCuentasxCobrar()
        {
            InitializeComponent();
        }
    }
}
