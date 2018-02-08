using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Consultas
{
    public partial class conFacturas : Form
    {
        datos objDatos = new datos();
        DataSet Resultados = new DataSet();
        DataView miFiltro;
        public string ReturnValue1 { get; set; }

        public conFacturas()
        {
            InitializeComponent();
        }

        private void conFacturas_Load(object sender, EventArgs e)
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select f.numfac_fac, c.nombre, f.fecfac_fac, f.monfac_fac from facturas f, detalle_facturas dt, clientes c where dt.numfac_fac = f.numfac_fac and c.codigo_cliente = f.codcli_cli order by f.numfac_fac desc");
            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

            this.dataGridView1.Columns[0].Width = 65;
            this.dataGridView1.Columns[0].HeaderText = "Factura";
            this.dataGridView1.Columns[1].Width = 295;
            this.dataGridView1.Columns[1].HeaderText = "Cliente";
            this.dataGridView1.Columns[2].Width = 150;
            this.dataGridView1.Columns[2].HeaderText = "Fecha Factura";
            this.dataGridView1.Columns[3].Width = 150;
            this.dataGridView1.Columns[3].HeaderText = "Monto Factura";
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

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            //string salida_datos = "";
            //string[] palabras_busqueda = this.textBox1.Text.Split(' ');
            //foreach (string palabra in palabras_busqueda)
            //{
            //    if (salida_datos.Length == 0)
            //    {
            //        salida_datos = "(nombre LIKE '%" + palabra + "%')";
            //    }
            //    else
            //    {
            //        salida_datos += "AND (nombre LIKE '%" + palabra + "'%)";
            //    }
            //}
            //this.miFiltro.RowFilter = salida_datos;
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
                MessageBox.Show("Debe seleccionar una factura del listado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                this.ReturnValue1 = row.Cells["numfac_fac"].Value.ToString();
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
