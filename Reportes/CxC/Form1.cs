using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Reportes.CxC
{
    public partial class Form1 : Form
    {
        private static Form1 reporteCxC = null;

        public Form1()
        {
            InitializeComponent();
        }

        public static Form1 InstanciaReporteCxCs()
        {
            if ((reporteCxC == null) || (reporteCxC.IsDisposed == true))
            {
                reporteCxC = new Form1();
            }
            reporteCxC.BringToFront();
            return reporteCxC;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            datos objDatos = new datos();
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select * from consultarCxC");

            Reportes.CxC.CrystalReport1 rp = new Reportes.CxC.CrystalReport1();
            rp.SetDataSource(objDatos.ds.Tables[0]);
            crystalReportViewer1.ReportSource = rp;
            objDatos.Desconectar();
            this.crystalReportViewer1.RefreshReport();

            crystalReportViewer1.ShowCloseButton = false;
            crystalReportViewer1.ShowCopyButton = false;
            crystalReportViewer1.ShowGotoPageButton = false;
            crystalReportViewer1.ShowLogo = false;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.DisplayStatusBar = false;
        }
    }
}
