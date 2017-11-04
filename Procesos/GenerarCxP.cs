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
    public partial class GenerarCxP : Form
    {
        int CodigoCxP, CodigoSuplidor;
        datos objDatos = new datos();
        private static GenerarCxP cxpInstancia = null;

        private void GenerarCxP_Load(object sender, EventArgs e)
        {
            proximoCodigoCxP();
            txtFecha.Text = DateTime.Now.Date.Date.ToString("MM-dd-yyyy");
            objDatos.Conectar();
            this.cmbTipoPago.DataSource = objDatos.ConsultaTabla("tipo_pagos", " descri_tpa");
            this.cmbTipoPago.DisplayMember = "descri_tpa";
            this.cmbTipoPago.ValueMember = "codigo_tpa";

            txtFecha.Text = DateTime.Now.Date.Date.ToString("MM-dd-yyyy");

            objDatos.Desconectar();
        }

        public static GenerarCxP InstanciaCxP()
        {
            if ((cxpInstancia == null) || (cxpInstancia.IsDisposed == true))
            {
                cxpInstancia = new GenerarCxP();
            }
            cxpInstancia.BringToFront();
            return cxpInstancia;
        }

        private void cmdBuscarCodCli_Click(object sender, EventArgs e)
        {
            Busquedas.busquedaSuplidores f2 = new Busquedas.busquedaSuplidores();
            DialogResult res = f2.ShowDialog();

            if (res == DialogResult.OK)
            {
                CodigoSuplidor = Convert.ToInt16(f2.ReturnValue1);
                this.txtNombreSuplidor.Text = f2.ReturnValue2;
                this.txtCodigoSuplidor.Text = CodigoSuplidor.ToString();
            }
        }

        private void cmdProcesar_Click(object sender, EventArgs e)
        {
            if (txtCodigoSuplidor.Text != "")
            {
                if (this.txtMontoFactura.Text != "" && txtNumeroFactura.Text != "" && this.txtNCF.Text != "")
                {
                    objDatos.Conectar();
                    objDatos.Consulta_llenar_datos("insert into cuentas_por_pagar values ('" + txtFecha.Text + "','" + txtNumeroFactura.Text + "'," + txtMontoFactura.Text + "," + txtMontoFactura.Text + ",0," + this.txtMontoFactura.Text + "," + cmbTipoPago.SelectedValue.ToString() + "," + txtUsuario.Text + "," + txtCodigoSuplidor.Text + ",'" + txtNCF.Text + "','" + txtConceptp.Text + "','False')");
                    MessageBox.Show("Cuenta por Pagar Generada");
                    objDatos.Desconectar();
                    proximoCodigoCxP();
                    this.txtCodigoSuplidor.Text = "";
                    this.txtNombreSuplidor.Text = "";
                    this.txtConceptp.Text = "";
                    this.txtNCF.Text = "";
                    this.txtMontoFactura.Text = "";
                    this.txtNumeroFactura.Text = "";
                    this.txtUsuario.Text = "";
                }
                else
                {
                    MessageBox.Show("Existen campos obligatorios necesarios", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }
            else
            {
                MessageBox.Show("Seleccione un suplidor", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void proximoCodigoCxP()
        {
            objDatos.Conectar();
            objDatos.consultar("SELECT codigo_cpp from ", "numero_cpp");
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                CodigoCxP = Convert.ToInt32(objDatos.ds.Tables["numero_cpp"].Rows[0][0].ToString()) + 1;
                this.txtCodigoCxP.Text = CodigoCxP.ToString();
            }
            else { CodigoCxP = 1; this.txtCodigoCxP.Text = CodigoCxP.ToString(); }
            objDatos.Desconectar();
        }

        public GenerarCxP()
        {
            InitializeComponent();
        }
    }
}
