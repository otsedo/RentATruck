using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Reportes.Entradas
{
    public partial class Form1 : Form
    {
        datos objDatos = new datos();
        private static Form1 rpEntradaCamiones = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void cmdBuscarCodCli_Click(object sender, EventArgs e)
        {
            Busquedas.BusquedaCamion BC = new Busquedas.BusquedaCamion();
            DialogResult res = BC.ShowDialog();

            if (res == DialogResult.OK)
            {
                this.txtCamion.Text = BC.ReturnValue1;
            }
        }

        public static Form1 InstanciaReporteEntradas()
        {
            if ((rpEntradaCamiones == null) || (rpEntradaCamiones.IsDisposed == true))
            {
                rpEntradaCamiones = new Form1();
            }
            rpEntradaCamiones.BringToFront();
            return rpEntradaCamiones;
        }


        private void cmdNuevo_Click(object sender, EventArgs e)
        {

            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("consultar_entrada_camion " + this.txtCamion.Text + "");

            Reportes.Entradas.rptEntrada rp = new Reportes.Entradas.rptEntrada();
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

        private void txtCamion_TextChanged(object sender, EventArgs e)
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select m.descripcion + ' '  + mv.descripcion + ' año ' + convert(varchar(4),v.anoveh_veh) + ', Placa ' + convert(varchar(12),v.numpla_veh) + ' Chasis ' +  convert(varchar(17),v.numcha_veh) as vehiculo,mav.aceite,mav.seguro,mav.correa_tiempo,mav.frenos,mav.codigo_mantenimiento_vehiculos from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c, mantenimiento_vehiculos mav where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and c.codigo_color = v.codigo_color and mav.codveh_veh = v.codveh_veh and v.codveh_veh = " + txtCamion.Text);
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                this.lblDatosCamion.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("Cliente no encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
