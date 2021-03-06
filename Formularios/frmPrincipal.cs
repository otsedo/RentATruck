﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentATruck.Clases;
using System.Threading;

namespace RentATruck.Formularios
{
    public partial class frmPrincipal : Form
    {
        public String Usuario, codigo_usuario;
        public Boolean UsuarioLogueado = false;
        public string varf2_codigo;
        frmAbout frmAbout = null;
        Thread p1, p2;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();
            int codigo_perfil = Utilitarios.codigo_perfil;
            if (login.logueado == true)
            {
                this.Show();
                UsuarioLogueado = true;
                lblEstado.Text = "Usuario: " + login.resultado.Substring(20);
                Usuario = login.resultado.Substring(20);
                codigo_usuario = Convert.ToString(Utilitarios.codigo_usuario);

                if (codigo_perfil == 2)
                {
                    administrarToolStripMenuItem.Enabled = false;
                }

                //Hilo para enviar correo
                p1 = new Thread(new ThreadStart(HiloEnviarCorreo));
                p2 = new Thread(new ThreadStart(HiloEnviarCorreoAceite));
                p1.Start();
                p2.Start();
            }
            else
            {
                this.Close();
            }
        }

        public void HiloEnviarCorreo()
        {
            enviarCorreo();
        }

        public void HiloEnviarCorreoAceite()
        {
            enviarCorreoCambioAceite();
        }

        private void enviarCorreo()
        {
            try
            {
                datos objDatos = new datos();
                string correo = "";
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select descripcion from notificacion_correos");

                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    correo = objDatos.ds.Tables[0].Rows[0][0].ToString();
                }

                EnviarCorreo mandaCorreo = new EnviarCorreo();
                mandaCorreo.enviarCorreo15(correo);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void enviarCorreoCambioAceite()
        {
            try
            {
                datos objDatos = new datos();
                string correo = "";
                objDatos.Conectar();
                objDatos.Consulta_llenar_datos("select descripcion from notificacion_correos");

                if (objDatos.ds.Tables[0].Rows.Count > 0)
                {
                    correo = objDatos.ds.Tables[0].Rows[0][0].ToString();
                }

                EnviarCorreo mandaCorreoAceite = new EnviarCorreo();
                mandaCorreoAceite.enviarCorreoAceite(correo);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UsuarioLogueado == true)
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("Desea Salir del sistema?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAbout == null)
            {
                frmAbout = new frmAbout();
                frmAbout.MdiParent = this;
                frmAbout.Show();
            }
        }

        private void marcasDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantMarcas F_mantMarcas = new Mantenimientos.mantMarcas();
            F_mantMarcas = Mantenimientos.mantMarcas.InstanciaMarcas();
            F_mantMarcas.MdiParent = this;
            F_mantMarcas.Show();

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantColores F_mantColores = new Mantenimientos.mantColores();
            F_mantColores = Mantenimientos.mantColores.InstanciaColores();
            F_mantColores.MdiParent = this;
            F_mantColores.Show();
        }

        private void medidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantModelosVehiculos F_mantModelos = new Mantenimientos.mantModelosVehiculos();
            F_mantModelos = Mantenimientos.mantModelosVehiculos.InstanciaModelos();
            F_mantModelos.MdiParent = this;
            F_mantModelos.Show();
        }

        private void tipoProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantTipoVehiculos F_mantTipoProductos = new Mantenimientos.mantTipoVehiculos();
            F_mantTipoProductos = Mantenimientos.mantTipoVehiculos.InstanciaTipoVehiculos();
            F_mantTipoProductos.MdiParent = this;
            F_mantTipoProductos.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantUsuarios F_mantUsuarios = new Mantenimientos.mantUsuarios();
            F_mantUsuarios = Mantenimientos.mantUsuarios.InstanciaUsuarios();
            F_mantUsuarios.MdiParent = this;
            F_mantUsuarios.Show();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantCamiones F_mantCamiones = new Mantenimientos.mantCamiones();
            F_mantCamiones = Mantenimientos.mantCamiones.InstanciaCamiones();
            F_mantCamiones.MdiParent = this;
            F_mantCamiones.Show();
        }

        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantServicios F_mantServicios = new Mantenimientos.mantServicios();
            F_mantServicios = Mantenimientos.mantServicios.InstanciaServicios();
            F_mantServicios.MdiParent = this;
            F_mantServicios.Show();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantClientes F_mantClientes = new Mantenimientos.mantClientes();
            F_mantClientes = Mantenimientos.mantClientes.InstanciaClientes();
            F_mantClientes.MdiParent = this;
            F_mantClientes.Show();
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.proFacturacion proFacturacion = new Procesos.proFacturacion();
            proFacturacion = Procesos.proFacturacion.InstanciaFacturacion();
            proFacturacion.MdiParent = this;
            proFacturacion.codigoEmpleado = codigo_usuario;
            proFacturacion.Show();
        }

        private void generarNCFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantNCF F_mantClientes = new Mantenimientos.mantNCF();
            F_mantClientes = Mantenimientos.mantNCF.InstanciaNCF();
            F_mantClientes.MdiParent = this;
            F_mantClientes.Show();
        }

        private void suplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantSuplidores F_mantSuplidores = new Mantenimientos.mantSuplidores();
            F_mantSuplidores = Mantenimientos.mantSuplidores.InstanciaSuplidores();
            F_mantSuplidores.MdiParent = this;
            F_mantSuplidores.Show();
        }

        private void crearCuentasPorPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.GenerarCxP F_CxP = new Procesos.GenerarCxP();
            F_CxP = Procesos.GenerarCxP.InstanciaCxP();
            F_CxP.MdiParent = this;
            F_CxP.codigoEmpleado = codigo_usuario;
            F_CxP.Show();
        }

        private void cuentasPorPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.proCuentasXPagar F_AbonoCxP = new Procesos.proCuentasXPagar();
            F_AbonoCxP = Procesos.proCuentasXPagar.InstanciaAbonarCxP();
            F_AbonoCxP.MdiParent = this;
            F_AbonoCxP.codigoEmpleado = codigo_usuario;
            F_AbonoCxP.Show();

        }

        private void cuadreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.proCuadreCaja F_cuadre = new Procesos.proCuadreCaja();
            F_cuadre = Procesos.proCuadreCaja.InstanciaCuadre();
            F_cuadre.MdiParent = this;
            F_cuadre.Show();
        }

        private void clientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Reportes.Clientes.Form1 F_reporteClientes = new Reportes.Clientes.Form1();
            F_reporteClientes = Reportes.Clientes.Form1.InstanciaReporteClientes();
            F_reporteClientes.MdiParent = this;
            F_reporteClientes.Show();
        }

        private void imprimirFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.ReimpresionFacturas.Form1 F_ReimpresionFacturas = new Reportes.ReimpresionFacturas.Form1();
            F_ReimpresionFacturas = Reportes.ReimpresionFacturas.Form1.InstanciaReimpresionFActuras();
            F_ReimpresionFacturas.MdiParent = this;
            F_ReimpresionFacturas.Show();
        }

        private void nCFDisponiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.NCF.Form1 F_NCFActivos = new Reportes.NCF.Form1();
            F_NCFActivos = Reportes.NCF.Form1.InstanciaReporteNCFActivos();
            F_NCFActivos.MdiParent = this;
            F_NCFActivos.Show();
        }

        private void suplidoresToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Reportes.Suplodore.Form1 F_RptSuplidores = new Reportes.Suplodore.Form1();
            F_RptSuplidores = Reportes.Suplodore.Form1.InstanciaSuplidores();
            F_RptSuplidores.MdiParent = this;
            F_RptSuplidores.Show();
        }

        private void backupDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.proBackup F_backup = new Procesos.proBackup();
            F_backup = Procesos.proBackup.InstanciaBackup();
            F_backup.MdiParent = this;
            F_backup.Show();
        }

        private void cuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.CxC.Form1 F_RCxC = new Reportes.CxC.Form1();
            F_RCxC = Reportes.CxC.Form1.InstanciaReporteCxCs();
            F_RCxC.MdiParent = this;
            F_RCxC.Show();
        }

        private void cuentasPorCobrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Procesos.proCuentasxCobrar F_RCxC = new Procesos.proCuentasxCobrar();
            F_RCxC = Procesos.proCuentasxCobrar.InstanciaCxc();
            F_RCxC.MdiParent = this;
            F_RCxC.Show();
        }

        private void salidasDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.proSalidaCamions F_SalidaCamiones = new Procesos.proSalidaCamions();
            F_SalidaCamiones = Procesos.proSalidaCamions.InstanciaSalidaCamiones();
            F_SalidaCamiones.MdiParent = this;
            F_SalidaCamiones.codigoEmpleado = codigo_usuario;
            F_SalidaCamiones.Show();
        }

        private void correoRecibeAlertasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantNotificacionesCorreo notificaciones = new Mantenimientos.mantNotificacionesCorreo();
            notificaciones = Mantenimientos.mantNotificacionesCorreo.InstanciaNotificaciones();
            notificaciones.MdiParent = this;
            notificaciones.Show();
        }

        private void configuracionDeMantenimientosACamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.frm mantMant = new Mantenimientos.frm();
            mantMant = Mantenimientos.frm.InstanciaMantMant();
            mantMant.MdiParent = this;
            mantMant.Show();
        }

        private void registroDeAccidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.txtNombreChofer proAccidentes = new Procesos.txtNombreChofer();
            proAccidentes = Procesos.txtNombreChofer.InstanciaAccidentes();
            proAccidentes.MdiParent = this;
            proAccidentes.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void salidaDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.Salida.Form1 F_RCxP = new Reportes.Salida.Form1();
            F_RCxP = Reportes.Salida.Form1.InstanciaReporteSalidas();
            F_RCxP.MdiParent = this;
            F_RCxP.Show();
        }

        private void entradaDeCamionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reportes.Entradas.Form1 F_RCxP = new Reportes.Entradas.Form1();
            F_RCxP = Reportes.Entradas.Form1.InstanciaReporteEntradas();
            F_RCxP.MdiParent = this;
            F_RCxP.Show();
        }

        private void agendaTelefonicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.frmAgenda frm_Agenda = new Formularios.frmAgenda();
            frm_Agenda = Formularios.frmAgenda.InstanciaAgenda();
            frm_Agenda.MdiParent = this;
            frm_Agenda.Show();
        }

        private void contactosTelefonicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantContactosTelefomicos contactos = new Mantenimientos.mantContactosTelefomicos();
            contactos = Mantenimientos.mantContactosTelefomicos.InstanciaContactos();
            contactos.MdiParent = this;
            contactos.Show();
        }

        private void tipoDeContactoTelefonicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.mantTipoContacto contactos = new Mantenimientos.mantTipoContacto();
            contactos = Mantenimientos.mantTipoContacto.InstanciaTipoContactos();
            contactos.MdiParent = this;
            contactos.Show();
        }

        private void accidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.Accidentes.Form1 Accidentes = new Reportes.Accidentes.Form1();
            Accidentes = Reportes.Accidentes.Form1.InstanciaReporteAccidentes();
            Accidentes.MdiParent = this;
            Accidentes.Show();
        }

        private void reImprimirSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.ReimpresionSalida.Form1 salidasre = new Reportes.ReimpresionSalida.Form1();
            salidasre = Reportes.ReimpresionSalida.Form1.InstanciaReimpresionSalidas();
            salidasre.MdiParent = this;
            salidasre.Show();
        }

        private void entradaDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.proEntradaCamiones proEntradaCamiones = new Procesos.proEntradaCamiones();
            proEntradaCamiones = Procesos.proEntradaCamiones.InstanciaEntradaCamiones();
            proEntradaCamiones.MdiParent = this;
            proEntradaCamiones.Show();
        }

        private void cuentasPorPagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reportes.CxP.Form1 F_RCxP = new Reportes.CxP.Form1();
            F_RCxP = Reportes.CxP.Form1.InstanciaReporteCxP();
            F_RCxP.MdiParent = this;
            F_RCxP.Show();
        }
    }
}
