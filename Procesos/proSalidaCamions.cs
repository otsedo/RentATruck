using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Procesos
{
    public partial class proSalidaCamions : Form
    {
        string personaRecibe, Cedula, Referencia, Km, Concepto, Combustible, Sucursal, TelefonoChofer;
        datos objDatos = new datos();
        private static proSalidaCamions salidaCamionesInstancia = null;
        public string NombreEmpleado, codigoEmpleado;
        Boolean miscelaneo_1 = false;
        string[] miscelaneos = new string[] { "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False" };



        public proSalidaCamions()
        {
            InitializeComponent();
        }

        public static proSalidaCamions InstanciaSalidaCamiones()
        {
            if ((salidaCamionesInstancia == null) || (salidaCamionesInstancia.IsDisposed == true))
            {
                salidaCamionesInstancia = new proSalidaCamions();
            }
            salidaCamionesInstancia.BringToFront();
            return salidaCamionesInstancia;
        }

        private void cmdBuscarCodCli_Click(object sender, EventArgs e)
        {
            Busquedas.BusquedaCamiones BC = new Busquedas.BusquedaCamiones();
            DialogResult res = BC.ShowDialog();

            if (res == DialogResult.OK)
            {
                this.txtCamion.Text = BC.ReturnValue1;

                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select * from mantenimiento_vehiculos where mantenimiento_vehiculos.codveh_veh = " + txtCamion.Text);
                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    this.cmdProcesar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Antes de Darle salida al vehiculo, debe configurar la fecha de vencimiento del seguro, en el menu Administrar y luego en Configuracion de Mantenimientos a Camiones", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cmdProcesar.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            //for (int i = 0; i < +chBoxListTables.Items.Count; i++)
            //{
            //    MessageBox.Show("Posicion: " + i.ToString() + ", Valor: " + miscelaneos[i].ToString());
            //}


        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void proSalidaCamions_Load(object sender, EventArgs e)
        {
            horaSalida.Value = DateTime.Now;
            this.fechaSalida.Text = DateTime.Now.Date.Date.ToString("dd-MM-yyyy");
            this.txtFechaEntrada.Text = DateTime.Now.Date.Date.ToString("dd-MM-yyyy");
            this.txtCamion.Text = "Nuevo";
            this.txtCodigoCliente.Text = "Nuevo";

            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select nombre_usuario from usuarios where codigo_usuario = " + codigoEmpleado);
            this.txtUsuario.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
            objDatos.Desconectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Busquedas.busquedaClientes f3 = new Busquedas.busquedaClientes();
            DialogResult res = f3.ShowDialog();

            if (res == DialogResult.OK)
            {
                txtCodigoCliente.Text = f3.ReturnValue1;
            }
        }

        private void txtCamion_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCamion.Text != "Nuevo")
            {
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select m.descripcion + ' '  + mv.descripcion + ' año ' + convert(varchar(4),v.anoveh_veh) + ', Placa ' + convert(varchar(12),v.numpla_veh) + ' Chasis ' +  convert(varchar(17),v.numcha_veh) as vehiculo from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and c.codigo_color = v.codigo_color and v.codveh_veh = " + txtCamion.Text);
                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    this.lblDatosCamion.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("Camion no encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCodigoCliente.Text != "Nuevo")
            {
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select c.nombre from clientes c, tipo_cliente tc where c.codtip_tip = tc.codtip_tip and c.codigo_cliente = " + txtCodigoCliente.Text);
                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    this.lblDatosCliente.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                objDatos.Desconectar();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKilometraje_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Solo acepta numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmdProcesar_Click(object sender, EventArgs e)
        {
            if (this.txtCamion.Text == "")
            {
                errorProvider1.SetError(txtCamion, "Seleccione un camion");
            }
            else { errorProvider1.Clear(); }

            if (this.txtCodigoCliente.Text == "")
            {
                errorProvider1.SetError(txtCodigoCliente, "Seleccione un camion");
            }
            //if (this.txtFechaEntrada.Text == this.fechaSalida.Text)
            //{
            //    MessageBox.Show("La fecha de Salida no puede ser la misma fecha de Entrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            else
            {
                if (this.txtCamion.Text != "" && this.txtCamion.Text != "")
                {
                    if (this.txtCamion.Text != "Nuevo")
                    {

                        try
                        {
                            if (txtPersonaRecibe.Text == "") { personaRecibe = "NULL"; } else { personaRecibe = txtPersonaRecibe.Text; }
                            if (this.txtCedula.Text == "") { Cedula = "NULL"; } else { Cedula = txtCedula.Text; }
                            if (this.txtReferencia.Text == "") { Referencia = "NULL"; } else { Referencia = txtReferencia.Text; }
                            if (this.txtKilometraje.Text == "") { Km = "NULL"; } else { Km = txtKilometraje.Text; }
                            if (this.txtConcepto.Text == "") { Concepto = "NULL"; } else { Concepto = txtConcepto.Text; }
                            if (this.txtCombustible.Text == "") { Combustible = "NULL"; } else { Combustible = txtCombustible.Text; }
                            if (this.txtSucursal.Text == "") { Sucursal = "NULL"; } else { Sucursal = txtSucursal.Text; }
                            if (this.txtTelefonoChofer.Text == "") { TelefonoChofer = "NULL"; } else { TelefonoChofer = txtTelefonoChofer.Text; }

                            for (int i = 0; i < +chBoxListTables.Items.Count; i++)
                            {
                                if (chBoxListTables.GetItemChecked(i))
                                {
                                    miscelaneos[i] = "True";
                                }
                            }

                            objDatos.Conectar();
                            string sql = "exec inserta_salida_camiones " + this.txtCamion.Text + "," + this.txtCodigoCliente.Text + ",'" + personaRecibe + "','" + Cedula + "','" + this.fechaSalida.Text + "','" + this.horaSalida.Value.ToString("HH:mm:ss") + "','" + this.txtFechaEntrada.Text + "','" + this.horaSalida.Value.ToString("HH:mm:ss") + "'," + Km + ",'" + Referencia + "','" + Concepto + "','" + Sucursal + "','" + Combustible + "','" + TelefonoChofer + "'," + codigoEmpleado + ",'" + miscelaneos[0] + "','" + miscelaneos[1] + "','" + miscelaneos[2] + "','" + miscelaneos[3] + "','" + miscelaneos[4] + "','" + miscelaneos[5] + "','" + miscelaneos[6] + "','" + miscelaneos[7] + "','" + miscelaneos[8] + "','" + miscelaneos[9] + "','" + miscelaneos[10] + "','" + miscelaneos[11] + "','" + miscelaneos[12] + "','" + miscelaneos[13] + "','" + miscelaneos[14] + "','" + miscelaneos[15] + "','" + miscelaneos[16] + "','" + miscelaneos[17] + "','" + miscelaneos[18] + "','" + miscelaneos[19] + "','" + miscelaneos[20] + "','" + miscelaneos[21] + "','" + miscelaneos[22] + "','" + miscelaneos[23] + "','" + miscelaneos[24] + "','" + miscelaneos[25] + "','" + miscelaneos[26] + "','" + miscelaneos[27] + "','" + miscelaneos[28] + "'";
                            if (objDatos.Insertar(sql))
                            {
                                objDatos.Desconectar();
                                objDatos.Conectar();
                                objDatos.Consulta_llenar_datos("exec setAlquilarVehiculo1 " + this.txtCamion.Text);
                                objDatos.Desconectar();
                                MessageBox.Show("Registro Insertado");

                                Reportes.ReporteSalida.Form1 Reporte_Salida = new Reportes.ReporteSalida.Form1();
                                Reporte_Salida.ShowDialog();
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

                    }



                }
                limpiarPantalla();
            }

        }

        private void limpiarPantalla()
        {
            this.txtCamion.Text = "Nuevo";
            this.txtCedula.Text = "";
            this.txtCodigoCliente.Text = "Nuevo";
            this.txtCombustible.Text = "";
            this.txtConcepto.Text = "";
            this.txtKilometraje.Text = "";
            this.txtReferencia.Text = "";
            this.txtSucursal.Text = "";
            this.txtPersonaRecibe.Text = "";
            this.lblDatosCamion.Text = "";
            this.lblDatosCliente.Text = "";
            this.txtTelefonoChofer.Text = "";
        }
    }
}






