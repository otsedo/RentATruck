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
    public partial class frmDevuelta : Form
    {
        string pagar_monto;
        double total;

        public frmDevuelta(string x, double y)
        {
            InitializeComponent();
            pagar_monto = x.ToString();
            total = y;
        }

        private void frmDevuelta_Load(object sender, EventArgs e)
        {
            this.txtCantidadPagar.Text = pagar_monto;
            this.txtFT.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            long efectivo;
            efectivo = Convert.ToInt64(this.txtFT.Text);


            if (efectivo < total)
            {
                MessageBox.Show("Fondos Insuficientes", "Error");
            }
            else
            {
                double devuelta = efectivo - total;
                this.txtCambio.Text = devuelta.ToString("C");
            }
        }
    }
}
