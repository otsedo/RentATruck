using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Formularios
{
    public partial class frmAgenda : Form
    {
        datos objDatos = new datos();
        DataSet Resultados = new DataSet();
        DataView miFiltro;
        private static frmAgenda AgendaInstancia = null;


        public frmAgenda()
        {
            InitializeComponent();
        }

        public static frmAgenda InstanciaAgenda()
        {
            if ((AgendaInstancia == null) || (AgendaInstancia.IsDisposed == true))
            {
                AgendaInstancia = new frmAgenda();
            }
            AgendaInstancia.BringToFront();
            return AgendaInstancia;
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            cargarContactos();
        }

        private void cargarContactos()
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select a.nombre, a.telefono1, a.telefono2, b.tipo_contacto from agenda a, tipo_contacto b where b.codigo_tipo_contacto = a.codigo_tipo_contacto order by nombre asc");
            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

            this.dataGridView1.Columns[0].Width = 350;
            this.dataGridView1.Columns[0].HeaderText = "Contacto";
            this.dataGridView1.Columns[1].Width = 100;
            this.dataGridView1.Columns[1].HeaderText = "Telefono 1";
            this.dataGridView1.Columns[2].Width = 100;
            this.dataGridView1.Columns[2].HeaderText = "Telefono 2";
            this.dataGridView1.Columns[3].Width = 197;
            this.dataGridView1.Columns[3].HeaderText = "Servicio";

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
            this.ActiveControl = textBox1;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabras_busqueda = this.textBox1.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(nombre LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += "and (nombre LIKE '%" + palabra + "'%)";
                }
            }
            this.miFiltro.RowFilter = salida_datos;
        }

        private void cmdAgregarArticuloaFactura_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantContactosTelefomicos contactos = new Mantenimientos.mantContactosTelefomicos();
            contactos = Mantenimientos.mantContactosTelefomicos.InstanciaContactos();
            //contactos.MdiParent = this;
            contactos.Show();
        }

        private void frmAgenda_Activated(object sender, EventArgs e)
        {
            cargarContactos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

