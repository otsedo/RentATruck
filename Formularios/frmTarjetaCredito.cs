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
    public partial class frmTarjetaCredito : Form
    {
        double numfac_fac;

        int codigoPago;
        public frmTarjetaCredito(double a, string b)
        {
            numfac_fac = Convert.ToDouble(b);
            InitializeComponent();
            txtCantidadPagar.Text = a.ToString();
        }

        private void frmTarjetaCredito_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoPago = 0;
                datos objDatos = new datos();
                objDatos.Consulta_llenar_datos("insert into resgistro_pago_tarjetas values (" + this.txt4Digitos.Text + "," + this.txtAprobacion.Text + "," + this.txtCantidadPagar.Text + "," + numfac_fac.ToString() + ")");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
