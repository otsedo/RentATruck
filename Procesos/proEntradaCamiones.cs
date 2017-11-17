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
    public partial class proEntradaCamiones : Form
    {
        string personaRecibe, Cedula, Referencia, Km, Concepto, Combustible, Sucursal;
        datos objDatos = new datos();
        private static proSalidaCamions salidaCamionesInstancia = null;

        public proEntradaCamiones()
        {
            InitializeComponent();
        }

        private void txtCamion_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCodigoCamion.Text != "Nuevo")
            {
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select cl.nombre as 'cliente',sc.cantidad_combustible, sc.fecha_salida, sc.concepto,sc.codigo_cliente,sc.kilometraje_salida,m.descripcion + ' '  + mv.descripcion + ' año ' + convert(varchar(4),v.anoveh_veh) + ', Placa ' + convert(varchar(12),v.numpla_veh) + ' Chasis ' +  convert(varchar(17),v.numcha_veh) as vehiculo from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c, salida_camiones sc, clientes cl where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and c.codigo_color = v.codigo_color and sc.codveh_veh = v.codveh_veh and cl.codigo_cliente = sc.codigo_cliente and sc.codveh_veh =  " + txtCodigoCamion.Text);
                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    this.lblDatosCamion.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void proEntradaCamiones_Load(object sender, EventArgs e)
        {
            //horaEntrada.Text = DateTime.Now.ToShortTimeString().ToString();
            //horaSalida.Text = DateTime.Now.ToShortTimeString().ToString();
            //this.txtCamion.Text = "Nuevo";
            //this.txtCodigoCliente.Text = "Nuevo";
        }
    }
}
