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
    public partial class mantContactosTelefomicos : Form
    {
        datos objDatos = new datos();
        DataView miFiltro;
        public static int codigo_marca;
        public static string marcaEncontrada;
        private static mantContactosTelefomicos contactosInstancia = null;

        public mantContactosTelefomicos()
        {
            InitializeComponent();
        }

        public static mantContactosTelefomicos InstanciaContactos()
        {
            if ((contactosInstancia == null) || (contactosInstancia.IsDisposed == true))
            {
                contactosInstancia = new mantContactosTelefomicos();
            }
            contactosInstancia.BringToFront();
            return contactosInstancia;
        }

        public bool validadCampo()
        {
            return (txtNombre.Text.Length > 2);
        }



        void guardarRegistros()
        {

            if (this.txtNombre.Text != "")
            {
                if (validadCampo() == false)
                {
                    MessageBox.Show("El nombre debe ser mayor a 2 caracteres.", "Favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        if (this.txtNombre.Text == valor)
                        {
                            marcaEncontrada = valor;
                            dataGridView1.Rows[fila].Selected = true;
                        }
                    }
                    //validamos la variable valor
                    if (marcaEncontrada != "")
                    {
                        DialogResult respuesta;
                        respuesta = MessageBox.Show("El contacto encontrado, " + marcaEncontrada + ", existe. ¿Desea actualizar?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.OK)
                        {
                            objDatos.Conectar();
                            string sql = "exec inserta_actualiza_agenda " + codigo_marca + "," + this.cbmTipoCliente.SelectedValue + ",'" + this.txtNombre.Text + "','" + this.txtTelefono1.Text + "','" + txtTelefono2.Text + "'";
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
                            string sql = "exec inserta_actualiza_agenda " + codigo_marca + "," + this.cbmTipoCliente.SelectedValue + ",'" + this.txtNombre.Text + "','" + this.txtTelefono1.Text + "','" + txtTelefono2.Text + "'";
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

        void cargarMarcas()
        {
            this.txtID.Text = "Nuevo";
            this.txtNombre.Text = "";
            this.txtTelefono1.Text = "";
            this.txtTelefono2.Text = "";
            this.txtNombre.Focus();
            this.txtID.Enabled = false;
            objDatos.Conectar();

            string sring = ("exec obtenerContactos");
            objDatos.Consulta_llenar_datos(sring);

            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 185;
            dataGridView1.Columns[3].Width = 88;
            dataGridView1.Columns[4].Width = 88;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.MultiSelect = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            cmdEliminar.Enabled = false;
            dataGridView1.ClearSelection();
            objDatos.Desconectar();
        }


        void eliminarRegistro()
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("Desea elmininar el registro " + this.txtNombre.Text + "?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                        string sql = "exec elimina_contacto " + this.txtID.Text;
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


        private void mantContactosTelefomicos_Load(object sender, EventArgs e)
        {
            this.cmdEliminar.Enabled = false;
            this.AcceptButton = this.cmdGuardar;
            this.CancelButton = cmdCancelar;

            objDatos.Conectar();
            this.cbmTipoCliente.DataSource = objDatos.ConsultaTabla("tipo_contacto", " tipo_contacto");
            this.cbmTipoCliente.DisplayMember = "tipo_contacto";
            this.cbmTipoCliente.ValueMember = "codigo_tipo_contacto";
            objDatos.Desconectar();

            try
            {
                cargarMarcas();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
                cbmTipoCliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTelefono1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtTelefono2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
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
    }
}
