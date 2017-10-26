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
    public partial class mantServicios : Form
    {
        datos objDatos = new datos();
        DataView miFiltro;
        public static int codigo_marca;
        public static string marcaEncontrada;
        string activo = "";
        private static mantServicios serviciosInstancia = null;

        public mantServicios()
        {
            InitializeComponent();
        }

        public static mantServicios InstanciaServicios()
        {
            if ((serviciosInstancia == null) || (serviciosInstancia.IsDisposed == true))
            {
                serviciosInstancia = new mantServicios();
            }
            serviciosInstancia.BringToFront();
            return serviciosInstancia;
        }

        private void mantServicios_Load(object sender, EventArgs e)
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

        public bool validadCampo()
        {
            return (txtMarca.Text.Length > 2);
        }

        void cargarMarcas()
        {
            this.txtID.Text = "Nuevo";
            this.txtMarca.Text = "";
            this.txtPrecio.Text = "";
            this.txtMarca.Focus();
            this.txtID.Enabled = false;
            objDatos.Conectar();

            string sring = ("exec obtenerServicios");
            objDatos.Consulta_llenar_datos(sring);

            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

            this.dataGridView1.Columns[0].Width = 60;
            this.dataGridView1.Columns[0].HeaderText = "ID";
            this.dataGridView1.Columns[1].Width = 270;
            this.dataGridView1.Columns[1].HeaderText = "Descripcion";
            this.dataGridView1.Columns[2].Width = 120;
            this.dataGridView1.Columns[2].HeaderText = "Precio Unitario";
            this.dataGridView1.Columns[3].Width = 91;
            this.dataGridView1.Columns[3].HeaderText = "Estado";
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

        void guardarRegistros()
        {
            if (this.chkEstado.Checked == true)
            {
                activo = "True";
            }
            if (this.chkEstado.Checked == false)
            {
                activo = "False";
            }

            if (this.txtMarca.Text != "")
            {
                if (validadCampo() == false)
                {
                    MessageBox.Show("El color debe ser mayor a 2 caracteres.", "Favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        respuesta = MessageBox.Show("El color encontrado, " + marcaEncontrada + ", existe. ¿Desea actualizar?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.OK)
                        {
                            objDatos.Conectar();
                            string sql = "exec inserta_actualiza_servicios " + codigo_marca + ",'" + this.txtMarca.Text + "'," + this.txtPrecio.Text + ",'" + activo + "'";
                            if (objDatos.Insertar(sql))
                            {
                                MessageBox.Show("Registro Actualizado");
                                //cargarMarcas();
                            }
                            else
                            {
                                MessageBox.Show("Registro no pudo ser insertado");
                            }
                            objDatos.Cn.Close();
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
                            string sql = "exec inserta_actualiza_servicios " + codigo_marca + ",'" + this.txtMarca.Text + "'," + this.txtPrecio.Text + ",'" + activo + "'";
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
                }
            }
        }

        void eliminarRegistro()
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
                        string sql = "exec elimina_servicios " + this.txtID.Text;
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
            if (dataGridView1.DataSource == null)
            {
                return;
            }
            else
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                if (Convert.ToBoolean(objDatos.ds.Tables[0].Rows[0][3]) == true)
                {
                    this.chkEstado.Checked = true;
                    activo = "True";
                }
                if (Convert.ToBoolean(objDatos.ds.Tables[0].Rows[0][3]) == false)
                {
                    this.chkEstado.Checked = false;
                    activo = "False";
                }
                this.cmdEliminar.Enabled = true;
            }
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            cargarMarcas();
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

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
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

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEstado.Checked == true)
            {
                activo = "True";
            }
            if (this.chkEstado.Checked == false)
            {
                activo = "False";
            }
        }
    }
}
