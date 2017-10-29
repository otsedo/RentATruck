﻿using System;
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
    public partial class proFacturacion : Form
    {
        datos obDatos = new datos();
        DataView miFiltro;
        int linea = 1;
        string descripcion, unidad, codigobarra, codigoArticulo, subTotal2, subTotal3, cantidadUpdated;

        private void proFacturacion_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.Date.Date.ToString("MM-dd-yyyy");
            txtHora.Text = DateTime.Now.ToShortTimeString().ToString();

            obDatos.Conectar();
            obDatos.consultar("SELECT COUNT(numfac_fac) from ", "facturas");
            numeroFactura = Convert.ToInt32(obDatos.ds.Tables["facturas"].Rows[0][0].ToString()) + 1;
            this.txtNumeroFactura.Text = (Convert.ToString(numeroFactura));
            actualizarDatosFactura();

            this.cmbTipoPago.DataSource = obDatos.ConsultaTabla("tipo_factura", " descri_fac");
            this.cmbTipoPago.DisplayMember = "descri_fac";
            this.cmbTipoPago.ValueMember = "codtip_fac";

            this.cmbTipoNCF.DataSource = obDatos.ConsultaTabla("tipo_NCF", " descri_tncf");
            this.cmbTipoNCF.DisplayMember = "descri_tncf";
            this.cmbTipoNCF.ValueMember = "codigo_tncf";
            obDatos.Desconectar();
        }

        private void cmdBuscarCodCli_Click(object sender, EventArgs e)
        {
            Busquedas.busquedaClientes f3 = new Busquedas.busquedaClientes();
            DialogResult res = f3.ShowDialog();

            if (res == DialogResult.OK)
            {
                txtCodigoCliente.Text = f3.ReturnValue1;
                lblNombreCliente.Text = f3.ReturnValue2;
            }
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (this.txtCodigoArticulo.Text != "")
                {
                    string sql = ("select a.codigo_art,a.codbrr_art as 'Codigo Barra', a.descriart_art as 'Descripcion',tu.descri_uni as 'Unidad',a.precio_art as 'Precio' from articulos a,tipo_unidad tu where a.codigo_uni = tu.codigo_uni and a.codigo_art = '" + this.txtCodigoArticulo.Text.ToString() + "'");
                    obDatos.Consulta_llenar_datos(sql);
                    this.txtCantidad.Focus();


                    if (obDatos.ds.Tables[0].Rows.Count > 0)
                    {
                        codigoArticulo = obDatos.ds.Tables[0].Rows[0][0].ToString();
                        codigobarra = obDatos.ds.Tables[0].Rows[0][1].ToString();
                        descripcion = obDatos.ds.Tables[0].Rows[0][2].ToString();
                        unidad = obDatos.ds.Tables[0].Rows[0][3].ToString();
                        precioUnidad = Convert.ToDouble(obDatos.ds.Tables[0].Rows[0][4].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Debe digitar el codigo del articulo");
                    this.txtCodigoArticulo.Focus();
                }
            }
        }

        private void cmdBuscarArticulo_Click(object sender, EventArgs e)
        {
            //Consultas.busquedaArticulos Ba = new Consultas.busquedaArticulos();
            //DialogResult res = Ba.ShowDialog();

            //if (res == DialogResult.OK)
            //{
            //    this.txtCodigoArticulo.Text = Ba.var_codigo_de_articulo;
            //    this.txtCantidad.Focus();
            //}
        }

        private void cmdAgregarArticuloaFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCodigoArticulo.Text != "")
                {
                    string buscarCantidad = ("select cantidad from facturatemporal where codigo_art = '" + this.txtCodigoArticulo.Text.ToString() + "'");
                    obDatos.Consulta_llenar_datos(buscarCantidad);

                    //int cantidad = Convert.ToInt16(obDatos.ds.Tables[0].Rows[0][0].ToString());
                    //string buscarCantidad = ("select cantidad from facturatemporal where codigo_art = '" + this.txtCodigoArticulo.Text.ToString() + "'");
                    //obDatos.Consulta_llenar_datos(buscarCantidad);

                    if (obDatos.ds.Tables[0].Rows.Count > 0)
                    {
                        cantidad = Convert.ToInt32(obDatos.ds.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        cantidad = 0;
                    }

                    cantidad = Convert.ToInt32(cantidad) + Convert.ToInt32(this.txtCantidad.Value);

                    string sql = "exec inserta_actualiza_detalle_factura_temporal " + this.codigoArticulo.ToString() + "," + linea + ",'" + descripcion + "'," + cantidad + ",'" + unidad + "'," + this.porcientoDescuento.Value + "," + importe + "," + precioUnidad.ToString() + "";
                    if (obDatos.Insertar(sql))
                    {
                        cantidad = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar registro");
                    }
                    actualizarDatosFactura();
                }
                else
                {
                    MessageBox.Show("Debe especificar el codigo de barra del articulo");
                    this.txtCodigoArticulo.Focus();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int a = 0; a < this.dataGridView1.Rows.Count; a++)
            {
                subTotal = (Convert.ToDouble(subTotal)) + Convert.ToDouble(this.dataGridView1.Rows[a].Cells["importe"].Value.ToString());
            }
            subTotal2 = subTotal.ToString();
            subTotal3 = subTotal.ToString("C");
            lblSubTotal.Text = subTotal3;
            totalITBIS = (Convert.ToDouble(subTotal2)) * ITBIS;
            lblItbis.Text = totalITBIS.ToString("C");
            total = totalITBIS + subTotal;
            lblTotal.Text = total.ToString("C");
            subTotal = 0;
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            this.txtCantidad.Select(0, this.txtCantidad.ToString().Length);
            if (this.txtCodigoArticulo.Text != "")
            {
                string sql = ("select a.codigo_art,a.codbrr_art as 'Codigo Barra', a.descriart_art as 'Descripcion',tu.descri_uni as 'Unidad',a.precio_art as 'Precio' from articulos a,tipo_unidad tu where a.codigo_uni = tu.codigo_uni and a.codigo_art = '" + this.txtCodigoArticulo.Text.ToString() + "'");
                obDatos.Consulta_llenar_datos(sql);
                this.txtCantidad.Focus();

                if (obDatos.ds.Tables[0].Rows.Count > 0)
                {
                    codigoArticulo = obDatos.ds.Tables[0].Rows[0][0].ToString();
                    codigobarra = obDatos.ds.Tables[0].Rows[0][1].ToString();
                    descripcion = obDatos.ds.Tables[0].Rows[0][2].ToString();
                    unidad = obDatos.ds.Tables[0].Rows[0][3].ToString();
                    precioUnidad = Convert.ToDouble(obDatos.ds.Tables[0].Rows[0][4].ToString());
                }
            }
        }

        private void txtCantidad_ValueChanged(object sender, EventArgs e)
        {
            this.cmdAgregarArticuloaFactura.PerformClick();
            this.txtCodigoArticulo.Focus();
            this.txtCodigoArticulo.Clear();
        }

        private void chkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            this.porcientoDescuento.Enabled = true;
        }

        private void proFacturacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            string truncarTablaTemporal = ("truncate table facturatemporal");
            obDatos.Consulta_llenar_datos(truncarTablaTemporal);
        }

        private void cmdAgregarNCF_Click(object sender, EventArgs e)
        {
            //PopUps.popSeleccionarNCF f2 = new PopUps.popSeleccionarNCF();
            //DialogResult NCF = f2.ShowDialog();

            //if (NCF == DialogResult.OK)
            //{
            //    txtNCF.Text = f2.numero_comprobante_fiscal;
            //}

            datos objDato = new datos();
            objDato.Conectar();
            string sql = "";
            sql = ("select n.ncf_ncf from NCF n where n.codigo_tncf = " + this.cmbTipoNCF.SelectedValue.ToString() + " and estado = 1");
            objDato.Consulta_llenar_datos(sql);
            this.txtCantidad.Focus();

            if (objDato.ds.Tables[0].Rows.Count > 0)
            {
                string NCF;
                NCF = objDato.ds.Tables[0].Rows[0][0].ToString();
                this.txtNCF.Text = NCF.ToString();
            }
            else
            {
                MessageBox.Show("No hay NCF disponibles");
            }
            objDato.Desconectar();
        }

        private void cmdBorrarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = this.dataGridView1.CurrentRow.Index;
                obDatos.Eliminar("facturatemporal", "codigo_art = " + this.dataGridView1.Rows[fila].Cells["Cod. Art."].Value);
                actualizarDatosFactura();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdEditarArticulo_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    PopUps.popEditarArticulo Art = new PopUps.popEditarArticulo();
            //    DialogResult res = Art.ShowDialog();

            //    if (res == DialogResult.OK)
            //    {
            //        cantidadUpdated = Art.var_cantidadUpdated;
            //    }
            //    int fila = this.dataGridView1.CurrentRow.Index;
            //    string sql = ("update facturatemporal set cantidad = " + Art.var_cantidadUpdated + " where codigo_art = " + this.dataGridView1.Rows[fila].Cells["Cod. Art."].Value + "");
            //    obDatos.Consulta_llenar_datos(sql);
            //    actualizarDatosFactura();
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void cmdFacturar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtNCF.Text) || (String.IsNullOrEmpty(this.txtCodigoCliente.Text)))
            {
                MessageBox.Show("Codigo de cliente o NCF no pueden estar en blanco", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int tipoPago = Convert.ToInt32(cmbTipoPago.SelectedValue);

                if (tipoPago == 1)
                {
                    descontarInventario();
                    guardarFactura();
                    guardarDetalleFactura();

                    desabilitarNCF();
                    Formularios.frmDevuelta fr = new Formularios.frmDevuelta(lblTotal.Text, total);
                    fr.Show();
                    MessageBox.Show("Proceso concluido");
                }
                if (tipoPago == 2)
                {
                    descontarInventario();
                    guardarFactura();
                    guardarDetalleFactura();

                    desabilitarNCF();
                    obDatos.Consulta_llenar_datos("insert into cuentas_por_cobrar values ('" + txtFecha.Text + "'," + numeroFactura.ToString() + "," + total.ToString() + "," + total.ToString() + ",0," + total.ToString() + ")");
                    MessageBox.Show("Cuenta por cobrar generada");
                }
                if (tipoPago == 3)
                {
                    descontarInventario();
                    guardarFactura();
                    guardarDetalleFactura();

                    desabilitarNCF();
                    Formularios.frmTarjetaCredito tc = new Formularios.frmTarjetaCredito(total, this.numeroFactura.ToString());
                    tc.ShowDialog();
                    MessageBox.Show("Proceso concluido");
                }

            }
        }

        private void cmdImprimirFactura_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Form frmImprimir = new Procesos.imprimirFactura(this.numeroFactura);
            //    frmImprimir.Show();
            //}
            //catch (SystemException ex)
            //{
            //    MessageBox.Show("No se encuentra la factura actual");
            //}
        }

        int numeroFactura, cantidad, codigoDetalleFactura;
        double importe, precioUnidad, subTotal, ITBIS = 0.18, totalITBIS, descuento;

        private void Button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form facturacion = new Procesos.proFacturacion();
            facturacion.Show();
        }

        public double total;
        //CrystalReport1 objRpt;

        public proFacturacion()
        {
            InitializeComponent();
        }

        private void actualizarDatosFactura()
        {
            obDatos.Conectar();
            obDatos.Consulta_llenar_datos("select f.codigo_art as 'Cod. Art.',f.descripcion as 'Descripcion',f.cantidad as 'Cantidad',f.unidad as 'Unidad',f.descuento as 'Descuento',f.precio as 'Precio',f.cantidad*f.precio as 'Importe' from  facturatemporal f");
            this.miFiltro = (obDatos.ds.Tables[0].DefaultView);
            this.dataGridView1.DataSource = miFiltro;
            this.dataGridView1.Columns[0].Width = 80;
            this.dataGridView1.Columns[1].Width = 400;
            this.dataGridView1.Columns[2].Width = 60;
            this.dataGridView1.Columns[3].Width = 55;


            for (int a = 0; a < this.dataGridView1.Rows.Count; a++)
            {
                subTotal = (Convert.ToDouble(subTotal)) + Convert.ToDouble(this.dataGridView1.Rows[a].Cells["importe"].Value.ToString());
            }
            subTotal2 = subTotal.ToString();
            subTotal3 = subTotal.ToString("C");
            lblSubTotal.Text = subTotal3;
            totalITBIS = (Convert.ToDouble(subTotal2)) * ITBIS;
            lblItbis.Text = totalITBIS.ToString("C");
            total = totalITBIS + subTotal;
            lblTotal.Text = total.ToString("C");
            subTotal = 0;
            obDatos.Desconectar();
        }

        private void descontarInventario()
        {
            try
            {
                datos objDatos1 = new datos();
                //Buscar cantidad de articulos = 3
                obDatos.consultar("select count(distinct codigo_art) from ", "facturatemporal");
                int cantArticulos = Convert.ToInt32(obDatos.ds.Tables["facturatemporal"].Rows[0][0].ToString());


                //Buscar los codigos de los articulos entrados           
                string sql3 = "select distinct codigo_art,cantidad from facturatemporal";
                objDatos1.Consulta_llenar_datos(sql3);

                for (int n = 0; n < cantArticulos; n++)
                {
                    string sql2 = "";
                    int existencia = 0, existencia_actual = 0, cantidad = Convert.ToInt32(objDatos1.ds.Tables[0].Rows[n][1].ToString()), codArt = Convert.ToInt32(objDatos1.ds.Tables[0].Rows[n][0].ToString());
                    sql2 = "select SUM(existencia) from inventario where codigo_art = " + objDatos1.ds.Tables[0].Rows[n][0].ToString();
                    obDatos.Consulta_llenar_datos(sql2);
                    existencia_actual = Convert.ToInt32(obDatos.ds.Tables[0].Rows[0][0].ToString());
                    existencia = existencia_actual - cantidad;

                    obDatos.Consulta_llenar_datos("exec inserta_actualiza_inventario 1," + codArt.ToString() + "," + existencia.ToString() + ",1");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("No existe suficiente cantidad del articulo");
            }
        }

        private void guardarFactura()
        {
            obDatos.Consulta_llenar_datos("exec inserta_facturas " + cmbTipoPago.SelectedValue.ToString() + "," + this.txtNumeroFactura.Text + "," + this.txtCodigoEmpleado.Text + ",'" + this.txtFecha.Text + "'," + total + "," + this.txtCodigoCliente.Text + "," + this.porcientoDescuento.Value.ToString() + "," + this.cmbTipoPago.SelectedValue.ToString() + ",1,0,'" + this.txtNCF.Text + "'," + totalITBIS.ToString() + "," + subTotal2.ToString() + "");
        }

        private void desabilitarNCF()
        {
            obDatos.Consulta_llenar_datos("update NCF set estado = 0 where ncf_ncf =  '" + this.txtNCF.Text + "'");
        }

        private void guardarDetalleFactura()
        {
            datos objDatos = new datos();
            string sql = "select precio,cantidad,codigo_art,descuento,cantidad*precio as 'importe',codigo_uni from facturatemporal,tipo_unidad where descri_uni = unidad";
            objDatos.Consulta_llenar_datos(sql);

            //Buscar cantidad de articulos
            obDatos.consultar("select count(distinct codigo_art) from ", "facturatemporal");
            int cantArticulos = Convert.ToInt32(obDatos.ds.Tables["facturatemporal"].Rows[0][0].ToString());

            for (int n = 0; n < cantArticulos; n++)
            {
                double precio = Convert.ToDouble(objDatos.ds.Tables[0].Rows[n][0].ToString());
                int cantidad = Convert.ToInt32(objDatos.ds.Tables[0].Rows[n][1].ToString());
                int codArticulo = Convert.ToInt32(objDatos.ds.Tables[0].Rows[n][2].ToString());
                int descuento = Convert.ToInt32(objDatos.ds.Tables[0].Rows[n][3].ToString());
                double importe = Convert.ToDouble(objDatos.ds.Tables[0].Rows[n][4].ToString());
                int codigoUnidad = Convert.ToInt32(objDatos.ds.Tables[0].Rows[n][5].ToString());
                obDatos.consultar("SELECT COUNT(id_detall) from ", "detalle_facturas");
                int idDetall = Convert.ToInt32(obDatos.ds.Tables["detalle_facturas"].Rows[0][0].ToString()) + 1;

                obDatos.Consulta_llenar_datos("exec inserta_detalles_facturas " + idDetall + "," + this.txtNumeroFactura.Text + "," + precio + "," + cantidad + "," + codArticulo + "," + descuento + "," + importe + "," + codigoUnidad + "");
            }

        }

        private void cmdPrueba_Enter(object sender, EventArgs e)
        {

        }
    }
}
