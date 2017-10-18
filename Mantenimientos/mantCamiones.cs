using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Mantenimientos
{
    public partial class mantCamiones : Form
    {
        datos objDatos = new datos();
        DataView miFiltro;
        public static int codigo_marca;
        public static string marcaEncontrada;
        private static mantCamiones camionesInstancia = null;

        public mantCamiones()
        {
            InitializeComponent();
        }

        private void mantCamiones_Load(object sender, EventArgs e)
        {
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
            this.txtID.Text = "Nuevo";
            this.txtModelo.Text = "";
            this.txtAño.Text = "";
            this.txtKm.Text = "";
            this.txtDescripcion.Text = "";
            this.txtPlaca.Text = "";
            this.txtChasis.Text = "";
            this.txtDescripcion.Focus();
            this.txtID.Enabled = false;
            objDatos.Conectar();

            string sring = ("exec obtenerVehiculos");
            objDatos.Consulta_llenar_datos(sring);

            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

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

            this.cbmMarca.DataSource = objDatos.ConsultaTabla("marca_articulos", " descripcion");
            this.cbmMarca.DisplayMember = "descripcion";
            this.cbmMarca.ValueMember = "codigo_marca";

            this.cbmTipo.DataSource = objDatos.ConsultaTabla("tipo_vehiculos", " descripcion");
            this.cbmTipo.DisplayMember = "descripcion";
            this.cbmTipo.ValueMember = "codigo_tipo_vehiculo";

            this.cbmColor.DataSource = objDatos.ConsultaTabla("colores", " descripcion");
            this.cbmColor.DisplayMember = "descripcion";
            this.cbmColor.ValueMember = "codigo_color";

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
                txtModelo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtAño.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtPlaca.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtChasis.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                cbmColor.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                this.txtKm.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();


                if (Convert.ToBoolean(objDatos.ds.Tables[0].Rows[0][7]) == true)
                {
                    this.estado.Checked = true;
                }
                if (Convert.ToBoolean(objDatos.ds.Tables[0].Rows[0][7]) == false)
                {
                    this.estado.Checked = false;
                }

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
            if (validadCampo() == false)
            {
                MessageBox.Show("La Marca debe ser mayor a 2 caracteres.", "Favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Verificar si ya la marca insertada estaba insertada
                marcaEncontrada = "";
                if (txtID.Text == "Nuevo")
                {
                    codigo_marca = 0;
                }
                else
                {
                    codigo_marca = int.Parse(this.txtID.Text);
                }

                //Busco en el gridview
                foreach (DataGridViewRow Row in dataGridView1.Rows)
                {
                    int fila = Row.Index;
                    String valor = Row.Cells[1].Value.ToString();

                    //compara lo que se escribe con lo que esta en el grid
                    if (this.txtDescripcion.Text == valor)
                    {
                        marcaEncontrada = valor;
                        dataGridView1.Rows[fila].Selected = true;
                    }
                }
                //validamos la variable valor
                if (marcaEncontrada != "")
                {
                    DialogResult respuesta;
                    respuesta = MessageBox.Show("La marca encontrada, " + marcaEncontrada + ", existe. ¿Desea actualizar?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.OK)
                    {
                        MessageBox.Show("Procedemos a guardar");
                        cargarMarcas();
                    }
                    else
                    {
                        cargarMarcas();
                    }
                }
                else
                {
                    try
                    {
                        objDatos.Conectar();
                        string sql = "exec inserta_actualiza_marcas " + codigo_marca + ",'" + this.txtDescripcion.Text + "'";
                        if (objDatos.Insertar(sql))
                        {
                            MessageBox.Show("Registro Insertado");
                            cargarMarcas();
                        }
                        else
                        {
                            MessageBox.Show("Registro no pudo ser insertado");
                        }
                        objDatos.Cn.Close();
                        cargarMarcas();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        public virtual void eliminarRegistro()
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("Desea elmininar el registro " + this.txtDescripcion.Text + "?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                        string sql = "exec elimina_marcas " + this.txtID.Text;
                        if (objDatos.Insertar(sql))
                        {
                            MessageBox.Show("Registro Eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult result = BuscarImagen.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(BuscarImagen.FileName);
            }
        }
    }
}
