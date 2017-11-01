using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Recibos
{
    public partial class Recibo_cpc : Form
    {
        Int64 codFactura = 0;
        public Recibo_cpc(Int64 n)
        {
            InitializeComponent();
            codFactura = n;
        }

        private void Recibo_cpc_Load(object sender, EventArgs e)
        {
            datos objDatos = new datos();
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("consultar_recibo_cpc " + codFactura.ToString() + "");

            Recibos.cpc rp = new Recibos.cpc();
            rp.SetDataSource(objDatos.ds.Tables[0]);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
        }
    }
}
