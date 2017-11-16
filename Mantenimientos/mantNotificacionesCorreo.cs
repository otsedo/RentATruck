using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Mantenimientos
{
    public partial class mantNotificacionesCorreo : Form
    {
        datos objDatos = new datos();
        public mantNotificacionesCorreo()
        {
            InitializeComponent();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(this.txtID.Text) == true)
            {
                try
                {
                    objDatos.Conectar();
                    string sql = "exec inserta_actualiza_notificacion_correos " + this.textBox2.Text + ",'" + this.txtID.Text + "'";
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
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            else
            {
                MessageBox.Show("Correo invalido");
            }
        }

        private void mantNotificacionesCorreo_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            objDatos.Conectar();
            objDatos.Consulta_llenar_datos("select descripcion from notificacion_correos where codigo_notificacion_correos = " + this.textBox2.Text);
            if (objDatos.ds.Tables[0].Rows.Count > 0)
            {
                this.txtID.Text = objDatos.ds.Tables[0].Rows[0][0].ToString();
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
