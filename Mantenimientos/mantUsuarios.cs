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
    public partial class mantUsuarios : Form
    {
        datos objDatos = new datos();
        DataView miFiltro;
        public static int codigo_marca;
        public static string marcaEncontrada;
        private static mantUsuarios usuariosInstancia = null;

        public mantUsuarios()
        {
            InitializeComponent();
        }

        private void mantusuarios_Load(object sender, EventArgs e)
        {
            cargarMarcas();
        }

        public static mantUsuarios InstanciaUsuarios()
        {
            if ((usuariosInstancia == null) || (usuariosInstancia.IsDisposed == true))
            {
                usuariosInstancia = new mantUsuarios();
            }
            usuariosInstancia.BringToFront();
            return usuariosInstancia;
        }



        public bool validadCampo()
        {
            return (txtMarca.Text.Length > 2);
        }

        public void cargarMarcas()
        {
            this.txtID.Text = "Nuevo";
            this.txtMarca.Text = "";
            this.txtUsuario.Text = "";
            this.txtContrasena1.Text = "";
            this.txtContrasena2.Text = "";
            this.txtFecha.Text = System.DateTime.Now.Date.ToShortDateString();
            this.txtHora.Text = DateTime.Now.ToString("h:mm:ss tt");
            this.txtMarca.Focus();
            this.txtID.Enabled = false;
            objDatos.Conectar();

            string sring = ("exec obtenerUsuarios");
            objDatos.Consulta_llenar_datos(sring);

            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

            this.dataGridView1.Columns[0].Width = 30;
            this.dataGridView1.Columns[0].HeaderText = "ID";
            this.dataGridView1.Columns[1].Width = 100;
            this.dataGridView1.Columns[1].HeaderText = "Nombre Usuario";
            this.dataGridView1.Columns[2].Width = 80;
            this.dataGridView1.Columns[2].HeaderText = "Usuario";
            this.dataGridView1.Columns[3].Width = 100;
            this.dataGridView1.Columns[3].HeaderText = "Contraseña";
            this.dataGridView1.Columns[4].Width = 60;
            this.dataGridView1.Columns[4].HeaderText = "Fecha Creacion";
            this.dataGridView1.Columns[5].Width = 60;
            this.dataGridView1.Columns[5].HeaderText = "Hora Creacion";
            this.dataGridView1.Columns[6].Width = 60;
            this.dataGridView1.Columns[6].HeaderText = "Codigo Perfil";
            this.dataGridView1.Columns[7].Width = 83;
            this.dataGridView1.Columns[7].HeaderText = "Perfil Asignado";

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

            this.cmbPerfiles.DataSource = objDatos.ConsultaTabla("perfiles_usuarios", " descripcion");
            this.cmbPerfiles.DisplayMember = "descripcion";
            this.cmbPerfiles.ValueMember = "nivel";

            objDatos.Desconectar();
        }

        public void guardarRegistros()
        {
            if (this.txtMarca.Text != "")
            {
                if (validadCampo() == false)
                {
                    MessageBox.Show("El nombre del usuario debe ser mayor a 2 caracteres.", "Favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        respuesta = MessageBox.Show("El usuario encontrado, " + marcaEncontrada + ", existe. ¿Desea actualizar?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                        if (this.txtContrasena1.Text == this.txtContrasena2.Text)
                        {
                            try
                            {
                                objDatos.Conectar();
                                string sql = "exec inserta_actualiza_usuarios " + codigo_marca + ",'" + this.txtMarca.Text + "','" + this.txtUsuario.Text + "','" + this.txtContrasena1.Text + "','" + this.txtFecha.Text + "','" + this.txtHora.Text + "'," + this.cmbPerfiles.SelectedValue;
                                if (objDatos.Insertar(sql))
                                {
                                    MessageBox.Show("Registro Insertado");
                                    //cargarMarcas();
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
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden");
                        }
                    }
                }
            }
        }

        public void eliminarRegistro()
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
                        string sql = "exec elimina_usuarios " + this.txtID.Text;
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
                this.txtUsuario.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.txtFecha.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                this.txtHora.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                this.txtContrasena1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.txtContrasena2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.cmbPerfiles.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                this.cmdEliminar.Enabled = true;
                this.cmdEliminar.Enabled = true;
                return;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistros();
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            cargarMarcas();
        }
    }
}
