using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using RentATruck.Clases;

namespace RentATruck.Mantenimientos
{
    public partial class frm : Form
    {
        string aceite, correa_tiempo, frenos, camion;
        datos objDatos = new datos();
        private static frm mantMantNotificacionInstancia = null;
        int codigoMantenimiento;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.dateTimePicker1.Enabled = true;
            }
            else
            {
                this.dateTimePicker1.Enabled = false;
            }
        }

        public static frm InstanciaMantMant()
        {
            if ((mantMantNotificacionInstancia == null) || (mantMantNotificacionInstancia.IsDisposed == true))
            {
                mantMantNotificacionInstancia = new frm();
            }
            mantMantNotificacionInstancia.BringToFront();
            return mantMantNotificacionInstancia;
        }

        private void txtCamion_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCamion.Text != "Nuevo")
            {
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select m.descripcion + ' '  + mv.descripcion + ' año ' + convert(varchar(4),v.anoveh_veh) + ', Placa ' + convert(varchar(12),v.numpla_veh) + ' Chasis ' +  convert(varchar(17),v.numcha_veh) as vehiculo,mav.aceite,mav.seguro,mav.correa_tiempo,mav.frenos,mav.codigo_mantenimiento_vehiculos from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c, mantenimiento_vehiculos mav where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and c.codigo_color = v.codigo_color and mav.codveh_veh = v.codveh_veh and v.codveh_veh = " + txtCamion.Text);
                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    this.lblDatosCamion.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
                    this.txtAceite.Text = objDatos.ds.Tables[0].Rows[0][1].ToString();
                    dateTimePicker1.Text = objDatos.ds.Tables[0].Rows[0][2].ToString();
                    this.txtCorreaTiempo.Text = objDatos.ds.Tables[0].Rows[0][3].ToString();
                    this.txtFrenos.Text = objDatos.ds.Tables[0].Rows[0][4].ToString();
                    this.txtID.Text = objDatos.ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    if (txtCamion.Text == "0")
                    {

                    }
                    else
                    {
                        MessageBox.Show("Todavia No se ha guardado ninguna configuracion para este camion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cmdBuscarCodCli_Click(object sender, EventArgs e)
        {
            Busquedas.BusquedaCamion BC = new Busquedas.BusquedaCamion();
            DialogResult res = BC.ShowDialog();

            if (res == DialogResult.OK)
            {
                this.txtCamion.Text = BC.ReturnValue1;
            }
        }

        public frm()
        {
            InitializeComponent();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void mantMantenimiento_Load(object sender, EventArgs e)
        {
            this.txtID.Text = "Nuevo";
            dateTimePicker1.Value = DateTime.Now.Date.Date;
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            //if (txtID.Text == "Nuevo")
            //{
            //    MessageBox.Show("Seleccione un camion");
            //}
            //else
            //{
            string selectDateAsString = dateTimePicker1.Value.ToString("yyyyMMdd");
            if (this.txtAceite.Text == "") { aceite = "NULL"; } else { aceite = txtAceite.Text; }
            if (this.checkBox1.Checked == false) { selectDateAsString = "19900101"; }
            if (this.txtCorreaTiempo.Text == "") { correa_tiempo = "NULL"; } else { correa_tiempo = this.txtCorreaTiempo.Text; }
            if (this.txtFrenos.Text == "") { frenos = "NULL"; } else { frenos = this.txtFrenos.Text; }
            if (this.txtID.Text == "Nuevo") { codigoMantenimiento = 0; } else { codigoMantenimiento = Convert.ToInt32(txtID.Text); }


            try
            {
                objDatos.Conectar();
                string sql = "exec inserta_actualiza_mantenimiento_vehiculos " + codigoMantenimiento + "," + this.txtCamion.Text + "," + aceite + ",'" + selectDateAsString + "'," + correa_tiempo + "," + frenos + "";
                if (objDatos.Insertar(sql))
                {
                    objDatos.Desconectar();
                    MessageBox.Show("Registro Insertado");
                }
                else
                {
                    MessageBox.Show("Registro no pudo ser insertado");
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            limpiarPantalla();
            //}
        }

        private void limpiarPantalla()
        {
            this.txtAceite.Text = "";
            this.txtCorreaTiempo.Text = "";
            this.txtFrenos.Text = "";
            this.dateTimePicker1.Value = DateTime.Now.Date;
            this.checkBox1.Checked = false;
            this.lblDatosCamion.Text = "";
            this.txtID.Text = "Nuevo";
            this.txtCamion.Text = "0";
        }
    }
}
