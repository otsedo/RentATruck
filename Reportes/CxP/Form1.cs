using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Reportes.CxP
{
    public partial class Form1 : Form
    {
        private static Form1 reporteCxP = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datos objDatos = new datos();
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select * from reporteCxP");

            Reportes.CxP.CrystalReport1 rp = new Reportes.CxP.CrystalReport1();
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

        public static Form1 InstanciaReporteCxP()
        {
            if ((reporteCxP == null) || (reporteCxP.IsDisposed == true))
            {
                reporteCxP = new Form1();
            }
            reporteCxP.BringToFront();
            return reporteCxP;
        }
    }
}
