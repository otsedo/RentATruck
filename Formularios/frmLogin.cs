using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentATruck.Clases;
using System.IO;

namespace RentATruck.Formularios
{
    public partial class frmLogin : Form
    {
        public Boolean logueado = false;
        public string resultado;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        public void IniciarSesion()
        {

            resultado = Utilitarios.IniciarSesion(this.txtUsuario.Text, this.txtPassword.Text);

            if (resultado != "")
            {
                MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK);
                logueado = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Acceso Denegado ", "Mensaje", MessageBoxButtons.OK);
                this.txtUsuario.Text = "";
                this.txtPassword.Text = "";
                this.txtUsuario.Focus();
            }
        }


        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                IniciarSesion();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText(@"C:\RentATruck\setting.txt", Encoding.UTF8);
            MessageBox.Show(text);
        }
    }
}
