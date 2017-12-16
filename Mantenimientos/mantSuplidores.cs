using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RentATruck.Mantenimientos
{
    public partial class mantSuplidores : RentATruck.Mantenimientos.mantVendedores
    {
        datos objDatos = new datos();
        Boolean activo = false;
        public static int codigo_marca;
        public static string marcaEncontrada;
        private static mantSuplidores suplidoresInstancia = null;

        public mantSuplidores()
        {
            InitializeComponent();
        }

        public static mantSuplidores InstanciaSuplidores()
        {
            if ((suplidoresInstancia == null) || (suplidoresInstancia.IsDisposed == true))
            {
                suplidoresInstancia = new mantSuplidores();
            }
            suplidoresInstancia.BringToFront();
            return suplidoresInstancia;
        }
        public bool validadCampo()
        {
            return (this.txtnombre.Text.Length > 2);
        }

        //Funcion para asignar teclas de funciones
        private void KeyEvent(object sender, KeyEventArgs e) //Keyup Event 
        {
            if (e.KeyCode == Keys.F4)
            {
                this.cmdBuscar.PerformClick();
            }
        }

        private void mantSuplidores_Load(object sender, EventArgs e)
        {
            //Tool tip en los botones
            toolTip1.SetToolTip(cmdGuardar, "Guarda los cambios");
            toolTip1.SetToolTip(cmdCancelar, "Cierra la ventana sin guardar los cambios");
            toolTip1.SetToolTip(cmdBuscar, "Muestra un listado de los suplidores");
            toolTip1.SetToolTip(cmdEliminar, "Elimina el registro seleccionado");

            //Corre la funcion para asignar teclas de funciones
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);
            this.cmdEliminar.Enabled = false;
            this.AcceptButton = this.cmdGuardar;
            this.CancelButton = cmdCancelar;
            try
            {
                cargarMarcas();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public virtual void cargarMarcas()
        {
            estado.Checked = true;
            this.txtID.Text = "Nuevo";
            this.txtDireccion.Text = "";
            this.txtnombre.Text = "";
            this.txtTelefono1.Text = "";
            this.txtTelefono2.Text = "";
            this.txtIDentificacion.Text = "";
            this.txtnombre.Focus();
            this.txtID.Enabled = false;
            this.pictureBox1.Image = RentATruck.Properties.Resources.user;
            objDatos.Conectar();


            this.cmdEliminar.Enabled = false;
        }

        public override void eliminarRegistro()
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("Desea elmininar el suplidor?: " + this.txtnombre.Text, "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (respuesta == DialogResult.OK)
            {

                if (this.txtID.Text == "" || this.txtID.Text == "Nuevo")
                {
                    MessageBox.Show("Favor de seleccionar un vendedor para borrar");
                }
                else
                {
                    try
                    {
                        objDatos.Conectar();
                        string sql = "exec elimina_suplidores " + this.txtID.Text;
                        if (objDatos.Insertar(sql))
                        {
                            MessageBox.Show("Suplidor Eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.None);
                            cargarMarcas();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro");
                        }
                        objDatos.Cn.Close();
                        cargarMarcas();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    cargarMarcas();
                }
            }
            else
            {
                cargarMarcas();
            }
        }

        public override void guardarRegistros()
        {
            if (estado.Checked == true)
            {
                activo = true;
            }
            else
            {
                activo = false;
            }

            if (String.IsNullOrEmpty(this.txtnombre.Text))
            {
                MessageBox.Show("El nombre del suplidor no puede estar en blanco", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtnombre.Focus();
            }

            if (validadCampo() == false)
            {
                MessageBox.Show("El nombre no puede ser menor a 2 caracteres.", "Favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                objDatos.Conectar();

                if (this.txtID.Text == "Nuevo")
                {
                    byte[] data = System.IO.File.ReadAllBytes(this.txtRutaImagen.Text);
                    string qry = "insert into suplidores (nombre, identificacion,estado, fecha_ingreso, telefono1, telefono2, direccion,fotove_cliente) values (@nombre, @identificacion,@estado, @fecha_ingreso, @telefono1, @telefono2, @direccion,@fotove_cliente)";

                    try
                    {
                        // Inicializa el objeto SqlCommand
                        SqlCommand SqlCom = new SqlCommand(qry, objDatos.Cn);

                        // Se agrega la información como parámetros
                        SqlCom.Parameters.Add(new SqlParameter("@nombre", this.txtnombre.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@identificacion", this.txtIDentificacion.Text.Trim()));
                        SqlCom.Parameters.Add(new SqlParameter("@estado", activo));
                        SqlCom.Parameters.Add(new SqlParameter("@fecha_ingreso", dateTimePicker1.Value));
                        SqlCom.Parameters.Add(new SqlParameter("@telefono1", this.txtTelefono1.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@telefono2", this.txtTelefono2.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@direccion", this.txtDireccion.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@fotove_cliente", data));
                        // Abrir la conexión y ejecutar el query
                        objDatos.Conectar();
                        SqlCom.ExecuteNonQuery();

                        // Mostrar un mensaje de confirmación
                        MessageBox.Show("Registro guardado correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarMarcas();
                        data.Initialize();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        // Cerrar la conexión si esta se encuentra abierta
                        if (objDatos.Cn.State == ConnectionState.Open)
                            objDatos.Desconectar();
                    }
                }
                else
                {
                    byte[] data = System.IO.File.ReadAllBytes(this.txtRutaImagen.Text);
                    string qry = "update suplidores set nombre = @nombre, identificacion = @identificacion,estado = @estado, fecha_ingreso=@fecha_ingreso, telefono1 = @telefono1, telefono2=@telefono2, direccion = @direccion, fotove_cliente = @fotove_cliente where codigo_suplidor = " + this.txtID.Text;

                    try
                    {
                        // Inicializa el objeto SqlCommand
                        SqlCommand SqlCom = new SqlCommand(qry, objDatos.Cn);

                        // Se agrega la información como parámetros
                        SqlCom.Parameters.Add(new SqlParameter("@nombre", this.txtnombre.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@identificacion", this.txtIDentificacion.Text.Trim()));
                        SqlCom.Parameters.Add(new SqlParameter("@estado", activo));
                        SqlCom.Parameters.Add(new SqlParameter("@fecha_ingreso", this.dateTimePicker1.Value));
                        SqlCom.Parameters.Add(new SqlParameter("@telefono1", this.txtTelefono1.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@telefono2", this.txtTelefono2.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@direccion", this.txtDireccion.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@fotove_cliente", data));

                        // Abrir la conexión y ejecutar el query
                        objDatos.Conectar();
                        SqlCom.ExecuteNonQuery();

                        // Mostrar un mensaje de confirmación
                        MessageBox.Show("Suplidor Actualizado correctamente", "Guardar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarMarcas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        // Cerrar la conexión si esta se encuentra abierta
                        if (objDatos.Cn.State == ConnectionState.Open)
                            objDatos.Desconectar();
                    }
                }
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Busquedas.busquedaSuplidores f3 = new Busquedas.busquedaSuplidores();
            DialogResult res = f3.ShowDialog();

            if (res == DialogResult.OK)
            {
                this.txtID.Text = f3.ReturnValue1;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (this.txtID.Text != "Nuevo")
            {
                objDatos.Conectar();
                string sql = ("select * from suplidores c where c.codigo_suplidor = " + this.txtID.Text + "");
                objDatos.Consulta_llenar_datos(sql);

                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    this.txtnombre.Text = objDatos.ds.Tables[0].Rows[0][1].ToString();
                    this.txtIDentificacion.Text = objDatos.ds.Tables[0].Rows[0][2].ToString();
                    this.dateTimePicker1.Text = objDatos.ds.Tables[0].Rows[0][4].ToString();
                    this.txtTelefono1.Text = objDatos.ds.Tables[0].Rows[0][5].ToString();
                    this.txtDireccion.Text = objDatos.ds.Tables[0].Rows[0][7].ToString();
                    this.txtTelefono2.Text = objDatos.ds.Tables[0].Rows[0][6].ToString();


                    if (Convert.ToBoolean(objDatos.ds.Tables[0].Rows[0][3]) == true)
                    {
                        this.estado.Checked = true;
                    }
                    if (Convert.ToBoolean(objDatos.ds.Tables[0].Rows[0][3]) == false)
                    {
                        this.estado.Checked = false;
                    }
                    buscarImagen();
                    this.cmdEliminar.Enabled = true;
                    objDatos.Cn.Close();
                }
            }
        }

        void buscarImagen()
        {
            string ID = "";
            if (this.txtID.Text != "Nuevo")
            { ID = this.txtID.Text; }
            else
            { ID = "0"; };
            string qry = "select fotove_cliente from suplidores where codigo_suplidor = " + ID;
            try
            {
                objDatos.Conectar();
                // Inicializa el objeto SqlCommand
                SqlCommand SqlCom = new SqlCommand(qry, objDatos.Cn);

                // Se agrega la información de búsqueda con parámetros
                SqlCom.Parameters.Add(new SqlParameter("@codigo_vendedor", this.txtID.Text));

                // Abre la conexión y ejecutar el query
                objDatos.Conectar();
                SqlDataReader rdr = SqlCom.ExecuteReader();

                Image newImage = null;

                if (rdr.Read())
                {
                    // Obtiene los resultados de la búsqueda
                    //txtDescripcion.Text = rdr.GetString(0);
                    byte[] imgData = (byte[])rdr.GetValue(0);

                    // Trata la información de la imagen para poder trasladarla al picturebox
                    using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
                    {
                        ms.Write(imgData, 0, imgData.Length);
                        newImage = Image.FromStream(ms, true);
                    }

                    pictureBox1.Image = newImage;
                    newImage = null;
                }
                else
                {
                    //MessageBox.Show("No existe registro con ese Id", "Búsqueda Nota", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Cierra la conexión si esta se encuentra abierta
                if (objDatos.Cn.State == ConnectionState.Open)
                    objDatos.Cn.Close();
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
