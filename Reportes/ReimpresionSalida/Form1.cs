using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Reportes.ReimpresionSalida
{
    public partial class Form1 : Form
    {
        private static Form1 reimpresionSalidas = null;

        public Form1()
        {
            InitializeComponent();
        }

        public static Form1 InstanciaReimpresionSalidas()
        {
            if ((reimpresionSalidas == null) || (reimpresionSalidas.IsDisposed == true))
            {
                reimpresionSalidas = new Form1();
            }
            reimpresionSalidas.BringToFront();
            return reimpresionSalidas;
        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            if (this.txtID.Text == "")
            {
                MessageBox.Show("Debe de especificar el numero de salida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                datos objDatos = new datos();
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("consultar_ultima_salida_camion " + this.txtID.Text);

                Reportes.ReporteSalida.rptUltimaSalida rp = new Reportes.ReporteSalida.rptUltimaSalida();
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
}
