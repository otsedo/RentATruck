using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.PopUps
{
    public partial class popEditarArticulos1 : Form
    {
        public string var_cantidadUpdated;

        public popEditarArticulos1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var_cantidadUpdated = this.txtCantidad.Text;
            this.Close();
        }

        private void popEditarArticulos1_Load(object sender, EventArgs e)
        {
            this.txtCantidad.Focus();
        }

        private void popEditarArticulos1_Activated(object sender, EventArgs e)
        {
            this.txtCantidad.Focus();
        }
    }
}
