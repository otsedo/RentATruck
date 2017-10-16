﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentATruck.Clases;


namespace RentATruck.Formularios
{
    public partial class frmPrincipal : Form
    {
        public Boolean UsuarioLogueado = false;
        frmAbout frmAbout = null;
        //Mantenimientos.mantMarcas mantMarcas = null;


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {



            this.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();
            int codigo_perfil = Utilitarios.codigo_perfil;
            if (login.logueado == true)
            {
                this.Show();
                UsuarioLogueado = true;
                lblEstado.Text = "Usuario: " + login.resultado.Substring(20);

                if (codigo_perfil == 1)
                {
                    mnuMantenimientos.Enabled = false;
                }


            }
            else
            {
                this.Close();
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UsuarioLogueado == true)
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("Desea Salir del sistema?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAbout == null)
            {
                frmAbout = new frmAbout();
                frmAbout.MdiParent = this;
                frmAbout.Show();
            }
        }

        private void marcasDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantMarcas F_mantMarcas = new Mantenimientos.mantMarcas();
            F_mantMarcas = Mantenimientos.mantMarcas.InstanciaMarcas();
            F_mantMarcas.MdiParent = this;
            F_mantMarcas.Show();

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantColores F_mantColores = new Mantenimientos.mantColores();
            F_mantColores = Mantenimientos.mantColores.InstanciaColores();
            F_mantColores.MdiParent = this;
            F_mantColores.Show();
        }

        private void medidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantModelosVehiculos F_mantModelos = new Mantenimientos.mantModelosVehiculos();
            F_mantModelos = Mantenimientos.mantModelosVehiculos.InstanciaModelos();
            F_mantModelos.MdiParent = this;
            F_mantModelos.Show();
        }

        private void tipoProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantTipoVehiculos F_mantTipoProductos = new Mantenimientos.mantTipoVehiculos();
            F_mantTipoProductos = Mantenimientos.mantTipoVehiculos.InstanciaTipoVehiculos();
            F_mantTipoProductos.MdiParent = this;
            F_mantTipoProductos.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantUsuarios F_mantUsuarios = new Mantenimientos.mantUsuarios();
            F_mantUsuarios = Mantenimientos.mantUsuarios.InstanciaUsuarios();
            F_mantUsuarios.MdiParent = this;
            F_mantUsuarios.Show();
        }
    }
}
