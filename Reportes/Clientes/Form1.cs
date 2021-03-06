﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Reportes.Clientes
{
    public partial class Form1 : Form
    {
        private static Form1 reporteClientesInstancia = null;

        public Form1()
        {
            InitializeComponent();
        }

        public static Form1 InstanciaReporteClientes()
        {
            if ((reporteClientesInstancia == null) || (reporteClientesInstancia.IsDisposed == true))
            {
                reporteClientesInstancia = new Form1();
            }
            reporteClientesInstancia.BringToFront();
            return reporteClientesInstancia;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datos objDatos = new datos();
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select * from reporteClientes");

            Reportes.Clientes.rptClientes rp = new Reportes.Clientes.rptClientes();
            rp.SetDataSource(objDatos.ds.Tables[0]);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
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
