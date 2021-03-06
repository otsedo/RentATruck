﻿using System;
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
    public partial class busquedaClientes : Form
    {
        datos objDatos = new datos();
        DataSet Resultados = new DataSet();
        DataView miFiltro;

        public string ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }
        public string ReturnValue3 { get; set; }

        public busquedaClientes()
        {
            InitializeComponent();
        }

        private void busquedaClientes_Load(object sender, EventArgs e)
        {

            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select c.codigo_cliente, c.nombre, c.direccion,c.telefono1, c.telefono2, c.representante from clientes c, tipo_cliente tc where c.codtip_tip = tc.codtip_tip");
            this.miFiltro = (objDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;

            this.dataGridView1.Columns[0].Width = 48;
            this.dataGridView1.Columns[0].HeaderText = "ID";
            this.dataGridView1.Columns[1].Width = 200;
            this.dataGridView1.Columns[1].HeaderText = "Nombre del cliente";
            this.dataGridView1.Columns[2].Width = 300;
            this.dataGridView1.Columns[2].HeaderText = "Direccion del cliente";
            this.dataGridView1.Columns[3].Width = 100;
            this.dataGridView1.Columns[3].HeaderText = "Telefono 1";
            this.dataGridView1.Columns[4].Width = 100;
            this.dataGridView1.Columns[4].HeaderText = "Telefono 2";
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
            textBox1.Focus(); ;
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
                MessageBox.Show("Debe seleccionar un cliente del listado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    salida_datos = "(Nombre del cliente LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += "AND (Nombre del cliente LIKE '%" + palabra + "'%)";
                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                this.ReturnValue1 = row.Cells["codigo_cliente"].Value.ToString();
                this.ReturnValue2 = row.Cells["nombre"].Value.ToString();
                this.ReturnValue3 = row.Cells["representante"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.cmdSeleccionar.PerformClick();
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
                    salida_datos += "AND (nombre LIKE '%" + palabra + "'%)";
                }
            }
            this.miFiltro.RowFilter = salida_datos;
        }
    }
}
