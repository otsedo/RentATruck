using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RentATruck.Mantenimientos
{
    public partial class mantMarcas : Form
    {
        datos objDatos = new datos();
        DataView miFiltro;
        public static int codigo_marca;
        public static string marcaEncontrada;
        private static mantMarcas marcaInstancia = null;

        public mantMarcas()
        {
            InitializeComponent();
        }

        private void mantMarcas_Load(object sender, EventArgs e)
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
            this.txtMarca.Text = "";
            this.txtMarca.Focus();
            this.txtID.Enabled = false;
            objDatos.Conectar();

            string sring = ("exec obtenerMarcas");
            objDatos.Consulta_llenar_datos(sring);

            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

            this.dataGridView1.Columns[0].Width = 120;
            this.dataGridView1.Columns[0].HeaderText = "ID";
            this.dataGridView1.Columns[1].Width = 421;
            this.dataGridView1.Columns[1].HeaderText = "Marca";
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

            objDatos.Desconectar();
        }

        public bool validadCampo()
        {
            return (txtMarca.Text.Length > 2);
        }

        public static mantMarcas InstanciaMarcas()
        {
            if ((marcaInstancia == null) || (marcaInstancia.IsDisposed == true))
            {
                marcaInstancia = new mantMarcas();
            }
            marcaInstancia.BringToFront();
            return marcaInstancia;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validando que no pueda ingresar espacios, numeros y simbolos
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
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
                txtMarca.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
                    if (this.txtMarca.Text == valor)
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
                        string sql = "exec inserta_actualiza_marcas " + codigo_marca + ",'" + this.txtMarca.Text + "'";
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
            respuesta = MessageBox.Show("Desea elmininar el registro " + this.txtMarca.Text + "?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                return;
            }
            else
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.cmdEliminar.Enabled = true;
            }
        }

        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer click que llene los textbox
            if (dataGridView1.DataSource == null)
            {
                return;
            }
            else
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.cmdEliminar.Enabled = true;
                return;
            }
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            cargarMarcas();
        }
    }
}