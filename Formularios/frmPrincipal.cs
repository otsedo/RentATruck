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
    public partial class frmPrincipal : Form
    {
        public Boolean UsuarioLogueado = false;
        

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
            

            this.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();

            if (login.logueado == true)
            {
                this.Show();
                UsuarioLogueado = true;

                             
            }
            else
            {
                this.Close();
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(UsuarioLogueado == true)
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("Desea Salir del sistema?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }                
            }
        }
    }
}
