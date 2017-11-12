using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Busquedas
{
    public partial class BusquedaCamiones : Form
    {
        datos objDatos = new datos();
        DataSet Resultados = new DataSet();
        DataView miFiltro;
        public string ReturnValue1 { get; set; }

        public BusquedaCamiones()
        {
            InitializeComponent();
        }

        private void BusquedaCamiones_Load(object sender, EventArgs e)
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select v.codveh_veh, m.descripcion, mv.descripcion, v.anoveh_veh, c.descripcion, v.descri_veh, v.numpla_veh, v.numcha_veh,v.kilome_veh from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and c.codigo_color = v.codigo_color and v.alquilado = 0");
            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

            this.dataGridView1.Columns[0].Width = 30;
            this.dataGridView1.Columns[0].HeaderText = "ID";
            this.dataGridView1.Columns[1].Width = 90;
            this.dataGridView1.Columns[1].HeaderText = "Marca";
            this.dataGridView1.Columns[2].Width = 80;
            this.dataGridView1.Columns[2].HeaderText = "Modelo";
            this.dataGridView1.Columns[3].Width = 70;
            this.dataGridView1.Columns[3].HeaderText = "Año";
            this.dataGridView1.Columns[4].Width = 70;
            this.dataGridView1.Columns[4].HeaderText = "Color";
            this.dataGridView1.Columns[5].Width = 120;
            this.dataGridView1.Columns[5].HeaderText = "Descripcion";
            this.dataGridView1.Columns[6].Width = 100;
            this.dataGridView1.Columns[6].HeaderText = "Placa";
            this.dataGridView1.Columns[7].Width = 120;
            this.dataGridView1.Columns[7].HeaderText = "Chasis";
            this.dataGridView1.Columns[8].Width = 68;
            this.dataGridView1.Columns[8].HeaderText = "Kilometraje";
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
            this.dataGridView1.ClearSelection();
            objDatos.Desconectar();
            textBox1.Focus();
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.ReturnValue1 != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un vehiculo del listado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabras_busqueda = this.textBox1.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(numpla_veh LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += "AND (codveh_veh LIKE '%" + palabra + "'%)";
                }
            }
            this.miFiltro.RowFilter = salida_datos;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                this.ReturnValue1 = row.Cells["codveh_veh"].Value.ToString();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.cmdSeleccionar.PerformClick();
        }
    }
}
