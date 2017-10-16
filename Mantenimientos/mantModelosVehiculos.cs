using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RentATruck.Mantenimientos
{
    public partial class mantModelosVehiculos : RentATruck.Mantenimientos.mantMarcas
    {
        datos objDatos = new datos();
        DataView miFiltro;
        public static int codigo_marca;
        public static string marcaEncontrada;
        private static mantMarcas marcaInstancia = null;
        public mantModelosVehiculos()
        {
            InitializeComponent();
        }

        private void mantModelosVehiculos_Load(object sender, EventArgs e)
        {

        }

        override public void cargarMarcas()
        {
            this.txtID.Text = "Nuevo";
            this.txtMarca.Text = "";
            this.txtMarca.Focus();
            this.txtID.Enabled = false;
            objDatos.Conectar();

            string sring = ("exec obtenerModelos");
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

        public override void guardarRegistros()
        {
            if (this.txtMarca.Text != "")
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
                            string sql = "exec inserta_actualiza_modelos " + codigo_marca + ",'" + this.txtMarca.Text + "'";
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

        public override void eliminarRegistro()
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
                        string sql = "exec elimina_modelos " + this.txtID.Text;
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

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistros();
        }


    }
}
