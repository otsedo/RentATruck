using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Reportes.NCF
{
    public partial class Form1 : Form
    {
        private static Form1 ncfActivos = null;

        public Form1()
        {
            InitializeComponent();
        }


        public static Form1 InstanciaReporteNCFActivos()
        {
            if ((ncfActivos == null) || (ncfActivos.IsDisposed == true))
            {
                ncfActivos = new Form1();
            }
            ncfActivos.BringToFront();
            return ncfActivos;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datos objDatos = new datos();
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select * from NCFActivos");

            Reportes.NCF.NCFActivos rp = new Reportes.NCF.NCFActivos();
            rp.SetDataSource(objDatos.ds.Tables[0]);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
            objDatos.Desconectar();

            crystalReportViewer1.ShowCloseButton = false;
            crystalReportViewer1.ShowCopyButton = false;
            crystalReportViewer1.ShowGotoPageButton = false;
            crystalReportViewer1.ShowLogo = false;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
