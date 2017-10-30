using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Procesos
{
    public partial class imprimirFacturas : Form
    {
        Int64 codFactura = 0;
        public imprimirFacturas(Int64 n)
        {
            InitializeComponent();
            codFactura = n;
        }

        private void imprimirFacturas_Load(object sender, EventArgs e)
        {
            datos objDatos = new datos();
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("consultar_factura_por_codigo " + codFactura + "");

            Reportes.Facturas rp = new Reportes.Facturas();
            rp.SetDataSource(objDatos.ds.Tables[0]);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
            objDatos.Desconectar();
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
