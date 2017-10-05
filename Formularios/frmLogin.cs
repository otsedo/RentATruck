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

namespace RentATruck.Formularios
{
    public partial class frmLogin : Form
    {
        public Boolean logueado = false;
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        
        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string resultado = Utilitarios.IniciarSesion(this.txtUsuario.Text,this.txtPassword.Text);
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

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
