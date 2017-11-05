using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Reportes.ReimpresionFacturas
{
    public partial class Form1 : Form
    {
        private static Form1 reimpresionFacturasInstancia = null;

        public Form1()
        {
            InitializeComponent();
        }

        public static Form1 InstanciaReimpresionFActuras()
        {
            if ((reimpresionFacturasInstancia == null) || (reimpresionFacturasInstancia.IsDisposed == true))
            {
                reimpresionFacturasInstancia = new Form1();
            }
            reimpresionFacturasInstancia.BringToFront();
            return reimpresionFacturasInstancia;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            datos objDatos = new datos();
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("consultar_factura_por_codigo " + this.txtID.Text + "");

            Reportes.Facturas rp = new Reportes.Facturas();
            rp.SetDataSource(objDatos.ds.Tables[0]);
            crystalReportViewer1.ReportSource = rp;

            crystalReportViewer1.ShowCloseButton = false;
            crystalReportViewer1.ShowCopyButton = false;
            crystalReportViewer1.ShowGotoPageButton = false;
            crystalReportViewer1.ShowLogo = false;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.DisplayStatusBar = false;

            crystalReportViewer1.RefreshReport();

            objDatos.Desconectar();
        }
    }
}
