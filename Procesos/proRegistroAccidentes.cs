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
    public partial class txtNombreChofer : Form
    {
        Boolean casaConductor = false, Muertos = false, Heridos = false;
        datos objDatos = new datos();
        private static txtNombreChofer accidnetesInstancia = null;
        public txtNombreChofer()
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

        private void txtCamion_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCamion.Text != "Nuevo")
            {
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select m.descripcion + ' '  + mv.descripcion + ' año ' + convert(varchar(4),v.anoveh_veh) + ', Placa ' + convert(varchar(12),v.numpla_veh) + ' Chasis ' +  convert(varchar(17),v.numcha_veh) as vehiculo from vehiculo v, marca_articulos m, tipo_vehiculos tv, modelos_vehiculos mv, colores c where v.codigo_marca = m.codigo_marca and v.codigo_tipo_vehiculo = tv.codigo_tipo_vehiculo and v.codigo_modelos =mv.codigo_modelos and c.codigo_color = v.codigo_color and v.codveh_veh = " + txtCamion.Text);
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

        public static txtNombreChofer InstanciaAccidentes()
        {
            if ((accidnetesInstancia == null) || (accidnetesInstancia.IsDisposed == true))
            {
                accidnetesInstancia = new txtNombreChofer();
            }
            accidnetesInstancia.BringToFront();
            return accidnetesInstancia;
        }

        private void proRegistroAccidentes_Load(object sender, EventArgs e)
        {
            this.txtCamion.Text = "Nuevo";

            objDatos.Conectar();
            this.cmbTipoAccidente.DataSource = objDatos.ConsultaTabla("tipo_accidentes", " order by descripcion asc");
            this.cmbTipoAccidente.DisplayMember = "descripcion";
            this.cmbTipoAccidente.ValueMember = "codigo_tac";
            objDatos.Desconectar();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Busquedas.busquedaClientes f3 = new Busquedas.busquedaClientes();
            DialogResult res = f3.ShowDialog();

            if (res == DialogResult.OK)
            {
                txtCodigoCliente.Text = f3.ReturnValue1;
            }
        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCodigoCliente.Text != "Nuevo")
            {
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select c.nombre from clientes c, tipo_cliente tc where c.codtip_tip = tc.codtip_tip and c.codigo_cliente = " + txtCodigoCliente.Text);
                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    this.lblDatosCliente.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                objDatos.Desconectar();
            }
        }

        private void cmdProcesar_Click(object sender, EventArgs e)
        {
            if (this.txtCamion.Text != "Nuevo" || this.txtCamion.Text != "")
            {
                if (this.radioButton1.Checked == true)
                {
                    Heridos = true;
                }

                if (this.radioButton6.Checked == true)
                {
                    Muertos = true;
                }

                if (this.radioButton4.Checked == true)
                {
                    casaConductor = true;
                }

                try
                {
                    objDatos.Conectar();
                    string sql = "exec inserta_registro_accidentes " + this.txtCamion.Text + "," + this.cmbTipoAccidente.SelectedValue + ",'" + this.txtNombre.Text + "','" + this.txtLicencia.Text + "','" + this.txtSeguro.Text + "','" + this.txtDetalles.Text + "','" + casaConductor + "','" + Muertos + "','" + Heridos + "'," + this.txtCodigoCliente.Text + ",'" + this.txtTelefonoChofer.Text + "'";
                    if (objDatos.Insertar(sql))
                    {
                        objDatos.Desconectar();
                        MessageBox.Show("Registro Insertado");
                    }
                    else
                    {
                        MessageBox.Show("Registro no pudo ser insertado");
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show("Confirme que no haya campos vacios");
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            limpiarPantalla();
        }

        private void limpiarPantalla()
        {
            txtCamion.Text = "Nuevo";
            txtDetalles.Text = "";
            txtLicencia.Text = "";
            txtNombre.Text = "";
            txtSeguro.Text = "";
            lblDatosCamion.Text = "";
            lblDatosCliente.Text = "";
            txtTelefonoChofer.Text = "";
        }
    }
}

