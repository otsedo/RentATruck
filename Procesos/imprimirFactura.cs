using System;
using System.Windows.Forms;

namespace RentATruck.Procesos
{
    public partial class imprimirFactura : Form
    {
        Int64 codFactura = 0;
        public imprimirFactura(Int64 n)
        {
            InitializeComponent();
            codFactura = n;
        }

        private void imprimirFactura_Load(object sender, EventArgs e)
        {
            //datos objDatos = new datos();
            //objDatos.Consulta_llenar_datos("consultar_factura_por_codigo " + codFactura + "");

            //Factura rp = new Factura();
            //rp.SetDataSource(objDatos.ds.Tables[0]);
            //crystalReportViewer1.ReportSource = rp;
            //crystalReportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
