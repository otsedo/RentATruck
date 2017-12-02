using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Mantenimientos
{
    public partial class mantCamiones : Form
    {
        datos objDatos = new datos();
        datos objDatosImg = new datos();
        string activo = "";
        DataView miFiltro;
        public static int codigo_marca;
        public static string marcaEncontrada;
        private static mantCamiones camionesInstancia = null;

        public mantCamiones()
        {
            InitializeComponent();
        }

        public static mantCamiones InstanciaMarcas()
        {
            if ((camionesInstancia == null) || (camionesInstancia.IsDisposed == true))
            {
                camionesInstancia = new mantCamiones();
            }
            camionesInstancia.BringToFront();
            return camionesInstancia;
        }

        private void mantCamiones_Load(object sender, EventArgs e)
        {
            this.cmdEliminar.Enabled = false;
            this.AcceptButton = this.cmdGuardar;
            this.CancelButton = cmdCancelar;
            //try
            //{
            cargarMarcas();
            //}
            //catch (System.Data.SqlClient.SqlException ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        public virtual void cargarMarcas()
        {
            estado.Checked = true;
            this.txtID.Text = "Nuevo";
            this.txtAño.Text = "";
            this.txtKm.Text = "";
            this.txtDescripcion.Text = "";
            this.txtPlaca.Text = "";
            this.txtChasis.Text = "";
            this.txtDescripcion.Focus();
            this.txtID.Enabled = false;
            this.pictureBox1.Image = RentATruck.Properties.Resources.place_holder1;
            objDatos.Conectar();

            string sring = ("exec obtenerVehiculos");
            objDatos.Consulta_llenar_datos(sring);

            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;
            objDatos.Desconectar();

            this.dataGridView1.Columns[0].Width = 50;
            this.dataGridView1.Columns[0].HeaderText = "ID";
            this.dataGridView1.Columns[1].Width = 125;
            this.dataGridView1.Columns[1].HeaderText = "Marca";
            this.dataGridView1.Columns[2].Width = 125;
            this.dataGridView1.Columns[2].HeaderText = "Modelo";
            this.dataGridView1.Columns[3].Width = 80;
            this.dataGridView1.Columns[3].HeaderText = "Año";
            this.dataGridView1.Columns[4].Width = 170;
            this.dataGridView1.Columns[4].HeaderText = "Descripcion";
            this.dataGridView1.Columns[5].Width = 100;
            this.dataGridView1.Columns[5].HeaderText = "Placa";
            this.dataGridView1.Columns[6].Width = 125;
            this.dataGridView1.Columns[6].HeaderText = "Chasis";
            this.dataGridView1.Columns[7].Width = 75;
            this.dataGridView1.Columns[7].HeaderText = "Estado";
            this.dataGridView1.Columns[8].Width = 63;
            this.dataGridView1.Columns[8].HeaderText = "Color";
            this.dataGridView1.Columns[9].Visible = false;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.cmdEliminar.Enabled = false;
            this.dataGridView1.ClearSelection();

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            objDatos.Conectar();
            this.cbmMarca.DataSource = objDatos.ConsultaTabla("marca_articulos", " order by descripcion asc");
            this.cbmMarca.DisplayMember = "descripcion";
            this.cbmMarca.ValueMember = "codigo_marca";

            this.cbmTipo.DataSource = objDatos.ConsultaTabla("tipo_vehiculos", " order by descripcion asc");
            this.cbmTipo.DisplayMember = "descripcion";
            this.cbmTipo.ValueMember = "codigo_tipo_vehiculo";

            this.cbmColor.DataSource = objDatos.ConsultaTabla("colores", " order by descripcion asc");
            this.cbmColor.DisplayMember = "descripcion";
            this.cbmColor.ValueMember = "codigo_color";

            this.cbmModelo.DataSource = objDatos.ConsultaTabla("modelos_vehiculos", " order by descripcion asc");
            this.cbmModelo.DisplayMember = "descripcion";
            this.cbmModelo.ValueMember = "codigo_modelos";

            buscarImagen();
            objDatos.Desconectar();
        }

        public bool validadCampo()
        {
            return (txtDescripcion.Text.Length > 2);
        }

        public static mantCamiones InstanciaCamiones()
        {
            if ((camionesInstancia == null) || (camionesInstancia.IsDisposed == true))
            {
                camionesInstancia = new mantCamiones();
            }
            camionesInstancia.BringToFront();
            return camionesInstancia;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer click que llene los textbox
            if (dataGridView1.DataSource == null)
            {
                return;
            }
            else
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbmMarca.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbmModelo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtAño.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtPlaca.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtChasis.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                cbmColor.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                this.txtKm.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                this.cbmTipo.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();


                if (Convert.ToBoolean(objDatos.ds.Tables[0].Rows[0][7]) == true)
                {
                    this.estado.Checked = true;
                    activo = "True";
                }
                if (Convert.ToBoolean(objDatos.ds.Tables[0].Rows[0][7]) == false)
                {
                    this.estado.Checked = false;
                    activo = "False";
                }
                buscarImagen();
                this.cmdEliminar.Enabled = true;
                return;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistros();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
        }

        public virtual void guardarRegistros()
        {
            if (String.IsNullOrEmpty(this.txtAño.Text) || (String.IsNullOrEmpty(this.txtPlaca.Text) || (String.IsNullOrEmpty(this.txtKm.Text)) || (String.IsNullOrEmpty(this.txtChasis.Text))))
            {
                MessageBox.Show("No puede haber campos en blanco", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAño.Focus();
            }

            if (validadCampo() == false)
            {
                MessageBox.Show("La descripcion no puede ser menor a 2 caracteres.", "Favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                objDatos.Conectar();

                if (this.txtID.Text == "Nuevo")
                {
                    byte[] data = System.IO.File.ReadAllBytes(this.txtRutaImagen.Text);
                    string qry = "insert into vehiculo (codigo_marca, codigo_tipo_vehiculo,codigo_modelos, codigo_color, anoveh_veh, descri_veh, numpla_veh, kilome_veh, numcha_veh, estado, fotove_veh) values (@codigo_marca, @codigo_tipo_vehiculo,@codigo_modelos, @codigo_color, @anoveh_veh, @descri_veh, @numpla_veh, @kilome_veh, @numcha_veh, @estado, @fotove_veh)";

                    try
                    {
                        // Inicializa el objeto SqlCommand
                        SqlCommand SqlCom = new SqlCommand(qry, objDatos.Cn);

                        // Se agrega la información como parámetros
                        SqlCom.Parameters.Add(new SqlParameter("@codigo_marca", this.cbmMarca.SelectedValue));
                        SqlCom.Parameters.Add(new SqlParameter("@codigo_tipo_vehiculo", this.cbmTipo.SelectedValue));
                        SqlCom.Parameters.Add(new SqlParameter("@codigo_modelos", this.cbmModelo.SelectedValue));
                        SqlCom.Parameters.Add(new SqlParameter("@codigo_color", this.cbmColor.SelectedValue));
                        SqlCom.Parameters.Add(new SqlParameter("@anoveh_veh", this.txtAño.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@descri_veh", this.txtDescripcion.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@numpla_veh", this.txtPlaca.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@kilome_veh", this.txtKm.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@numcha_veh", txtChasis.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@estado", activo));
                        SqlCom.Parameters.Add(new SqlParameter("@fotove_veh", data));

                        // Abrir la conexión y ejecutar el query
                        objDatos.Conectar();
                        SqlCom.ExecuteNonQuery();

                        // Mostrar un mensaje de confirmación
                        MessageBox.Show("Registro guardado correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Ahora, vaya al menu de Administracion y configure la fecha de vencimiento del seguro del camion", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    byte[] data = System.IO.File.ReadAllBytes(this.txtRutaImagen.Text);
                    string qry = "update vehiculo set codigo_marca = @codigo_marca, codigo_tipo_vehiculo = @codigo_tipo_vehiculo,codigo_modelos = @codigo_modelos, codigo_color=@codigo_color, anoveh_veh=@anoveh_veh, descri_veh = @descri_veh, numpla_veh=@numpla_veh, kilome_veh = @kilome_veh, numcha_veh = @numcha_veh, estado = @estado, fotove_veh  = @fotove_veh where codveh_veh = " + this.txtID.Text;

                    try
                    {
                        // Inicializa el objeto SqlCommand
                        SqlCommand SqlCom = new SqlCommand(qry, objDatos.Cn);

                        // Se agrega la información como parámetros
                        SqlCom.Parameters.Add(new SqlParameter("@codigo_marca", this.cbmMarca.SelectedValue));
                        SqlCom.Parameters.Add(new SqlParameter("@codigo_tipo_vehiculo", this.cbmTipo.SelectedValue));
                        SqlCom.Parameters.Add(new SqlParameter("@codigo_modelos", this.cbmModelo.SelectedValue));
                        SqlCom.Parameters.Add(new SqlParameter("@codigo_color", this.cbmColor.SelectedValue));
                        SqlCom.Parameters.Add(new SqlParameter("@anoveh_veh", this.txtAño.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@descri_veh", this.txtDescripcion.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@numpla_veh", this.txtPlaca.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@kilome_veh", this.txtKm.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@numcha_veh", txtChasis.Text));
                        SqlCom.Parameters.Add(new SqlParameter("@estado", activo));
                        SqlCom.Parameters.Add(new SqlParameter("@fotove_veh", data));

                        // Abrir la conexión y ejecutar el query
                        objDatos.Conectar();
                        SqlCom.ExecuteNonQuery();

                        // Mostrar un mensaje de confirmación
                        MessageBox.Show("Nota Actualizada correctamente", "Guardar Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cargarMarcas();
        }


        public virtual void eliminarRegistro()
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("Desea elmininar el registro seleccionado?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (respuesta == DialogResult.OK)
            {

                if (this.txtID.Text == "" || this.txtID.Text == "Nuevo")
                {
                    MessageBox.Show("Favor de seleccionar un elemento para borrar");
                }
                else
                {
                    try
                    {
                        objDatos.Conectar();
                        string sql = "exec elimina_vehiculos " + this.txtID.Text;
                        if (objDatos.Insertar(sql))
                        {
                            MessageBox.Show("Registro Eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.None);
                            cargarMarcas();
                        }
                        else
                        {
                            MessageBox.Show("Registro no pudo eliminar el registro");
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

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            cargarMarcas();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivos de Imagenes (*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*";
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Buscar Imagen del articulo";
            BuscarImagen.FileName = this.txtRutaImagen.Text;
            //DialogResult result = BuscarImagen.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                this.txtRutaImagen.Text = BuscarImagen.FileName;
                String Direccion = BuscarImagen.FileName;
                this.pictureBox1.ImageLocation = Direccion;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        void buscarImagen()
        {
            string ID = "";
            if (this.txtID.Text != "Nuevo") { ID = this.txtID.Text; } else { ID = "0"; };
            string qry = "select fotove_veh from vehiculo where codveh_veh = " + ID;
            try
            {
                objDatos.Conectar();
                // Inicializa el objeto SqlCommand
                SqlCommand SqlCom = new SqlCommand(qry, objDatos.Cn);

                // Se agrega la información de búsqueda con parámetros
                SqlCom.Parameters.Add(new SqlParameter("@codveh_veh", this.txtID.Text));

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




        private void estado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.estado.Checked == true)
            {
                activo = "True";
            }
            if (this.estado.Checked == false)
            {
                activo = "False";
            }
        }
    }
}


