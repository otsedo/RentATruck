using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Reportes.ReporteSalida
{
    public partial class Form1 : Form
    {
        Int32 ultimaSalida;
        datos objDatos = new datos();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select max(codigo_salida_camiones) as 'ultimo' from salida_camiones");
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                ultimaSalida = Convert.ToInt32(objDatos.ds.Tables[0].Rows[0][0].ToString());
            }

            objDatos.Consulta_llenar_datos("consultar_ultima_salida_camion " + ultimaSalida);


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
