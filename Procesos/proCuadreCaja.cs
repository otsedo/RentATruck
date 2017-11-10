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
    public partial class proCuadreCaja : Form
    {
        int peso, cinco, diez, veinte, veintey5, cincuenta, cien, doscientos, quinientos, mil, dosmil, total;
        double vendidoEfectivo, vendidoCredito, totalCajero, diferencia;
        private static proCuadreCaja cuadreInstancia = null;

        private void txtQuinientos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                quinientos = Convert.ToInt32(this.txtQuinientos.Text) * 500;
                this.txtTotal500.Text = quinientos.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        public static proCuadreCaja InstanciaCuadre()
        {
            if ((cuadreInstancia == null) || (cuadreInstancia.IsDisposed == true))
            {
                cuadreInstancia = new proCuadreCaja();
            }
            cuadreInstancia.BringToFront();
            return cuadreInstancia;
        }

        private void txtMil_TextChanged(object sender, EventArgs e)
        {
            try
            {
                mil = Convert.ToInt32(this.txtMil.Text) * 1000;
                this.txtTotal1000.Text = mil.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void txtDosMil_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dosmil = Convert.ToInt32(this.txtDosMil.Text) * 2000;
                this.txtTotal2000.Text = dosmil.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void cmdCalcular_Click(object sender, EventArgs e)
        {


        }

        private void cmdNuevo_Click(object sender, EventArgs e)
        {
            totalCajero = Convert.ToDouble(peso + cinco + diez + veinte + veintey5 + cincuenta + cien + doscientos + quinientos + mil + dosmil);
            this.lblCajero.Text = totalCajero.ToString("C");
            diferencia = totalCajero - vendidoEfectivo;

            if (diferencia == 0)
            {
                lblCajero.ForeColor = Color.DarkGreen;
                lblDiferencia.Text = diferencia.ToString("C");
            }
            else
            {
                lblCajero.ForeColor = Color.DarkRed;
                lblDiferencia.Text = diferencia.ToString("C");
            }
        }

        private void txtDoscientos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                doscientos = Convert.ToInt32(this.txtDoscientos.Text) * 200;
                this.txtTotal200.Text = doscientos.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void txtCien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cien = Convert.ToInt32(this.txtCien.Text) * 100;
                this.txtTotalCien.Text = cien.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void txtCincuenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cincuenta = Convert.ToInt32(this.txtCincuenta.Text) * 50;
                this.txtTotalCiencuenta.Text = cincuenta.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void txtVeinticinco_TextChanged(object sender, EventArgs e)
        {
            try
            {
                veintey5 = Convert.ToInt32(this.txtVeinte.Text) * 25;
                this.txtTotalVeinteyCinco.Text = veintey5.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void txtVeinte_TextChanged(object sender, EventArgs e)
        {
            try
            {
                veinte = Convert.ToInt32(this.txtVeinte.Text) * 20;
                this.txtTotalVeinte.Text = veinte.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void txtDiez_TextChanged(object sender, EventArgs e)
        {
            try
            {
                diez = Convert.ToInt32(this.txtDiez.Text) * 10;
                this.txtTotalDiez.Text = diez.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void txtCinco_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cinco = Convert.ToInt32(this.txtCinco.Text) * 5;
                this.txtTotalCinco.Text = cinco.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                peso = Convert.ToInt32(this.txtPeso.Text) * 1;
                this.txtTotalPeso.Text = peso.ToString("C");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Este valor no debe estar en blanco. Puede ser 0");
            }
        }

        public proCuadreCaja()
        {
            InitializeComponent();
        }

        private void proCuadreCaja_Load(object sender, EventArgs e)
        {
            try
            {
                datos objDatos = new datos();
                string fecha = DateTime.Now.Date.Date.ToString("yyyy-MM-dd");
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select SUM(f.monfac_fac)as 'monto' from facturas f where f.fecfac_fac = " + "'" + fecha.ToString() + "' and f.codtip_fac = 1");
                if (Convert.ToString(objDatos.ds.Tables[0].Rows[0][0].ToString()) == "")
                {
                    this.txtTotalEfectivoSistema.Text = "$0.00";
                }
                else
                {
                    vendidoEfectivo = Convert.ToDouble(objDatos.ds.Tables[0].Rows[0][0].ToString());
                    this.txtTotalEfectivoSistema.Text = vendidoEfectivo.ToString("C");
                }
                objDatos.Desconectar();
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select SUM(f.monfac_fac)as 'monto' from facturas f where f.codtip_fac = 2 and f.fecfac_fac = " + "'" + fecha.ToString() + "'");
                if (Convert.ToString(objDatos.ds.Tables[0].Rows[0][0].ToString()) == "")
                {
                    this.txtVentasEfectivo.Text = "$0.00";
                }
                else
                {
                    {
                        vendidoCredito = Convert.ToDouble(objDatos.ds.Tables[0].Rows[0][0].ToString());
                        this.txtVentasEfectivo.Text = vendidoCredito.ToString("C");
                    }

                }
                //-------------------VENTAS EN TARJETA DE CREDITO---------------------
                //    objDatos.Consulta_llenar_datos("select SUM(f.monfac_fac)as 'monto' from facturas f where f.codtip_fac = 3 and f.fecfac_fac = " + "'" + fecha.ToString() + "'");
                //    if (objDatos.ds.Tables[0].Rows.Count < 1)
                //    {
                //        this.txtTotalVentasTarjeta.Text = "$0.00";
                //    }
                //    else
                //    {
                //        vendidotarjeta = Convert.ToDouble(objDatos.ds.Tables[0].Rows[0][0].ToString());
                //        this.txtTotalVentasTarjeta.Text = vendidotarjeta.ToString("C");
                //    }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("No se encontraron facturas el dia de hoy");
            }
            this.lblSistema.Text = (vendidoCredito + vendidoEfectivo).ToString("C");
            this.lblSistema2.Text = (vendidoEfectivo).ToString("C");
        }
    }
}
