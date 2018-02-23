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
    public partial class proEntradaCamiones : Form
    {
        datos objDatos = new datos();
        private static proEntradaCamiones entradaCamionesInstancia = null;
        Int32 NuevoKilometraje, KilometrajeInsertar, codigoSalidaCamion;
        DateTime fecha_entrada;
        DateTime salida, HoraFechaSalida, HoraFechaEntrada;

        private void cmdProcesar_Click(object sender, EventArgs e)
        {
            if (this.txtPersonaEntrega.Text == "")
            {
                MessageBox.Show("Especifique quien entrega el vehiculo");
                this.txtPersonaEntrega.Focus();
            }
            if (this.txtPersonaEntrega.Text == "")
            {
                this.txtCedula.Text = "N/A";
            }
            if (this.txtKilometraje.Text == "")
            {
                MessageBox.Show("Especifique el kilometraje al recibir el camion");
                this.txtPersonaEntrega.Focus();
            }


            if (this.txtKilometraje.Text == "")
            {
                this.txtCombustibleEntrada.Text = "N/A";
            }

            if (this.txtReferencia.Text == "")
            {
                txtCombustibleEntrada.Text = "N/A";
            }

            if (this.txtCodigoCamion.Text != "Nuevo")
            {
                try
                {
                    //Calcular la cantidad de dias
                    txtFechaEntrada.Format = DateTimePickerFormat.Custom;
                    txtFechaEntrada.CustomFormat = "dd/MM/yyyy";
                    salida = DateTime.ParseExact(this.txtFechaSalida.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string date = txtFechaEntrada.Text;
                    DateTime entrada = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    TimeSpan difference = entrada - salida;

                    //Calcular la cantidad de horas
                    txtFechaEntrada.Format = DateTimePickerFormat.Custom;
                    txtFechaEntrada.CustomFormat = "MM/dd/yyyy HH:mm:ss";

                    var src = HoraFechaSalida;
                    var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);

                    DateTime src2 = txtFechaEntrada.Value;
                    var hm2 = new DateTime(src2.Year, src2.Month, src2.Day, src2.Hour, src2.Minute, 0);

                    int dias = hm2.Day - hm.Day;
                    int horas = hm2.Hour - hm.Hour;
                    int minutos;


                    if (hm2.Hour > hm.Hour)
                    { minutos = hm2.Minute - hm.Minute; }
                    else
                    { minutos = hm.Minute - hm2.Minute; }



                    objDatos.Conectar();
                    string sql = "exec inserta_entrada_camiones " + this.txtCodigoCamion.Text + ",'" + entrada + "','" + this.txtPersonaEntrega.Text + "','" + this.txtCedula.Text + "','" + this.horaEntrada.Text.Substring(0, 8) + "','" + this.txtKilometraje.Text + "','" + this.txtReferencia.Text + "','" + this.txtCombustible.Text + "'," + difference.TotalDays + "," + horas;
                    if (objDatos.Insertar(sql))
                    {
                        string ActualizarAlquiler = "update vehiculo set alquilado = 'False', kilome_veh= " + txtKilometraje.Text + " where codveh_veh = " + this.txtCodigoCamion.Text;
                        if (objDatos.Insertar(ActualizarAlquiler))
                        {
                            MessageBox.Show("Registro Insertado");
                        }

                        NuevoKilometraje = Convert.ToInt32(txtKilometraje.Text) - Convert.ToInt32(txtKmSalida.Text);
                        KilometrajeInsertar = NuevoKilometraje + kilometrajeActualCambioAceite();
                        //MessageBox.Show("El nuevo kilometraje es:" + NuevoKilometraje);
                        objDatos.Desconectar();
                        objDatos.Conectar();
                        string sql3 = "exec actualizar_kilometraje_aceite " + this.txtCodigoCamion.Text + "," + KilometrajeInsertar;
                        if (objDatos.Insertar(sql3))
                        {
                            objDatos.Desconectar();
                            //MessageBox.Show("Se actualizó la cantidad de KM para el cambio de aceite");
                        }

                        objDatos.Conectar();
                        string sql5 = "exec desactiva_salida_camion " + codigoSalidaCamion + "," + "'False'";
                        if (objDatos.Insertar(sql5))
                        {
                            objDatos.Desconectar();
                            //MessageBox.Show("se deactivo la salida de camion");
                        }
                        objDatos.Desconectar();
                        limpiarPantalla();
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

        public static proEntradaCamiones InstanciaEntradaCamiones()
        {
            if ((entradaCamionesInstancia == null) || (entradaCamionesInstancia.IsDisposed == true))
            {
                entradaCamionesInstancia = new proEntradaCamiones();
            }
            entradaCamionesInstancia.BringToFront();
            return entradaCamionesInstancia;
        }

        private void limpiarPantalla()
        {
            this.txtCamion.Text = "Nuevo";

            txtFechaEntrada.Format = DateTimePickerFormat.Custom;
            txtFechaEntrada.CustomFormat = "dd/MM/yyyy";
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime entrada = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            fecha_entrada = entrada;
            this.txtFechaEntrada.Text = fecha_entrada.ToString();

















            this.txtPersonaEntrega.Text = "";
            this.txtCedula.Text = "";
            this.horaEntrada.Text = DateTime.Now.ToShortTimeString().ToString();
            this.txtKilometraje.Text = "";
            this.txtCombustible.Text = "";
            this.txtReferencia.Text = "";
            this.txtCodigoCliente.Text = "";
            this.txtCliente.Text = "";
            this.txtCamion.Text = "";
            txtFechaSalida.Text = "";
            txtKmSalida.Text = "";
            txtCombustibleEntrada.Text = "";

            txtFechaEntrada.Format = DateTimePickerFormat.Custom;
            txtFechaEntrada.CustomFormat = "dd/MM/yyyy";
            date = DateTime.Now.ToString("dd/MM/yyyy");
            entrada = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            fecha_entrada = entrada;
        }

        private void cmdBuscarCodCli_Click(object sender, EventArgs e)
        {
            Busquedas.busquedaCamionesAlquilados BC = new Busquedas.busquedaCamionesAlquilados();
            DialogResult res = BC.ShowDialog();

            if (res == DialogResult.OK)
            {
                this.txtCodigoCamion.Text = BC.ReturnValue1;
            }
        }

        private Int32 kilometrajeActualCambioAceite()
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select * from control_cambio_aceite where control_cambio_aceite.codveh_veh = " + txtCodigoCamion.Text);
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(this.txtCamion.Text = objDatos.ds.Tables[0].Rows[0][2].ToString());
            }
            else
            {
                return 0;
            }
        }

        public proEntradaCamiones()
        {
            InitializeComponent();
        }

        private void txtKilometraje_KeyUp(object sender, KeyEventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigoCamion.Text != "Nuevo")
            {
                //Calcular la cantidad de dias
                txtFechaEntrada.Format = DateTimePickerFormat.Custom;
                txtFechaEntrada.CustomFormat = "dd/MM/yyyy";
                salida = DateTime.ParseExact(this.txtFechaSalida.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string date = txtFechaEntrada.Text;
                DateTime entrada = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan difference = entrada - salida;
                //MessageBox.Show("Dias: " + difference.TotalDays.ToString());

                //Calcular la cantidad de horas
                txtFechaEntrada.Format = DateTimePickerFormat.Custom;
                txtFechaEntrada.CustomFormat = "MM/dd/yyyy HH:mm:ss";

                var src = HoraFechaSalida;
                var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);

                DateTime src2 = txtFechaEntrada.Value;
                var hm2 = new DateTime(src2.Year, src2.Month, src2.Day, src2.Hour, src2.Minute, 0);

                int dias = hm2.Day - hm.Day;
                int horas = hm2.Hour - hm.Hour;
                int minutos;


                if (hm2.Hour > hm.Hour)
                { minutos = hm2.Minute - hm.Minute; }
                else
                { minutos = hm.Minute - hm2.Minute; }

                MessageBox.Show("Dias:       " + difference.TotalDays.ToString() + "\n" + "Horas:    " + horas);
            }
            else
            {
                MessageBox.Show("Seleccione un camion");
            }
        }

        private void txtCamion_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCodigoCamion.Text != "Nuevo")
            {
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select cl.nombre as 'cliente',cl.codigo_cliente ,sc.cantidad_combustible, CONVERT(char(10), sc.fecha_salida,103) as 'fecha_salida', sc.concepto,sc.codigo_cliente,sc.kilometraje_salida,m.descripcion + ' '  + mv.descripcion + ' año ' + convert(varchar(4),v.anoveh_veh) + ', Placa ' + convert(varchar(12),v.numpla_veh) + ' Chasis ' +  convert(varchar(17),v.numcha_veh) as vehiculo, sc.codigo_salida_camiones, sc.hola_salida, Combined = fecha_salida + hola_salida from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c, salida_camiones sc, clientes cl where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and cl.codigo_cliente = sc.codigo_cliente and sc.codveh_veh = v.codveh_veh and sc.codigo_cliente = cl.codigo_cliente and c.codigo_color = v.codigo_color and sc.estado = 'True' and sc.codveh_veh = " + txtCodigoCamion.Text);
                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    this.txtCamion.Text = objDatos.ds.Tables[0].Rows[0][7].ToString();
                    this.txtCodigoCliente.Text = objDatos.ds.Tables[0].Rows[0][1].ToString();
                    this.txtCliente.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
                    this.txtFechaSalida.Text = objDatos.ds.Tables[0].Rows[0][3].ToString();
                    this.txtKmSalida.Text = objDatos.ds.Tables[0].Rows[0][6].ToString();
                    this.txtCombustibleEntrada.Text = objDatos.ds.Tables[0].Rows[0][2].ToString();
                    codigoSalidaCamion = Convert.ToInt32(objDatos.ds.Tables[0].Rows[0][8].ToString());
                    this.txtHoraEntrada.Text = objDatos.ds.Tables[0].Rows[0][9].ToString();
                    HoraFechaSalida = Convert.ToDateTime(objDatos.ds.Tables[0].Rows[0][10].ToString());
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void proEntradaCamiones_Load(object sender, EventArgs e)
        {
            horaEntrada.Text = DateTime.Now.ToString("HH:mm");
            String HoraEntradaFinal = horaEntrada.Text;

            txtFechaEntrada.Format = DateTimePickerFormat.Custom;
            txtFechaEntrada.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime entrada = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            fecha_entrada = entrada;
            txtCodigoCamion.Text = "Nuevo";
        }
    }
}
