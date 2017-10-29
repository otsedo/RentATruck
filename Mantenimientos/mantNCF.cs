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
    public partial class mantNCF : Form
    {
        datos obDatos = new datos();
        string total = "";
        private static mantNCF ncfInstancia = null;

        public mantNCF()
        {
            InitializeComponent();
        }

        private void mantNCF_Load(object sender, EventArgs e)
        {
            obDatos.Conectar();
            this.cmbTCF.DataSource = obDatos.ConsultaTabla("tipo_NCF", " descri_tncf");
            this.cmbTCF.DisplayMember = "descri_tncf";
            this.cmbTCF.ValueMember = "codigo_tncf";
            obDatos.Desconectar();
        }

        public static mantNCF InstanciaNCF()
        {
            if ((ncfInstancia == null) || (ncfInstancia.IsDisposed == true))
            {
                ncfInstancia = new mantNCF();
            }
            ncfInstancia.BringToFront();
            return ncfInstancia;
        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(this.txtSecuenciaDesde.Text) < Int32.Parse(this.txtSecuenciaHasta.Text))
            {
                total = total + this.cmbSerie.Text.ToString() + txtDN.Text + txtPE.Text + txtAI.Text + this.cmbTCF.SelectedValue.ToString();
                string total1, total2, total3, total4, total5, total6, total7, total8 = "";

                int desde = Convert.ToInt32(this.txtSecuenciaDesde.Text);
                int hasta = Convert.ToInt32(this.txtSecuenciaHasta.Text);

                for (int a = desde; a <= hasta; a++)
                {
                    if (a < 10)
                    {
                        total1 = "0000000" + a.ToString();
                        this.listBox1.Items.Add(total + total1.ToString());
                    }
                    else if (a >= 10 && a < 100)
                    {
                        total2 = "000000" + a.ToString();
                        this.listBox1.Items.Add(total + total2.ToString());
                    }
                    else if (a >= 100 && a < 1000)
                    {
                        total3 = "00000" + a.ToString();
                        this.listBox1.Items.Add(total + total3.ToString());
                    }
                    else if (a >= 1000 && a < 10000)
                    {
                        total4 = "0000" + a.ToString();
                        this.listBox1.Items.Add(total + total4.ToString());
                    }
                    else if (a >= 10000 && a < 100000)
                    {
                        total5 = "000" + a.ToString();
                        this.listBox1.Items.Add(total + total5.ToString());
                    }
                    else if (a >= 100000 && a < 1000000)
                    {
                        total6 = "00" + a.ToString();
                        this.listBox1.Items.Add(total + total6.ToString());
                    }
                    else if (a >= 1000000 && a < 10000000)
                    {
                        total7 = "0" + a.ToString();
                        this.listBox1.Items.Add(total + total7.ToString());
                    }
                    else if (a >= 10000000 && a < 100000000)
                    {
                        total8 = "" + a.ToString();
                        this.listBox1.Items.Add(total + total8.ToString());
                    }
                }
                this.cmdGenerar.Enabled = false;
            }
            else
            {
                MessageBox.Show("El numero DESDE no puede ser mejor que HASTA");
            }
            this.button2.Enabled = true;
        }

        private void cmbSerie_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtDN.Enabled = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                obDatos.Conectar();
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    //MessageBox.Show(listBox1.Items[i].ToString());
                    string sql = "insert into NCF (ncf_ncf,codigo_tncf,estado) values ('" + listBox1.Items[i].ToString() + "'," + this.cmbTCF.SelectedValue.ToString() + ",'TRUE')";

                    if (obDatos.Insertar(sql))
                    {
                        //MessageBox.Show("Registro Insertado");
                    }
                    else
                    {
                        //MessageBox.Show("Registro Insertado");
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            MessageBox.Show("NCF Insertados");
            obDatos.Desconectar();
        }

        private void txtDN_TextChanged(object sender, EventArgs e)
        {
            this.txtPE.Enabled = true;
        }

        private void txtAI_TextChanged(object sender, EventArgs e)
        {
            this.cmbTCF.Enabled = true;
        }

        private void cmbTCF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtSecuenciaDesde.Enabled = true;
        }

        private void txtPE_TextChanged(object sender, EventArgs e)
        {
            this.txtAI.Enabled = true;
        }

        private void txtSecuenciaDesde_TextChanged(object sender, EventArgs e)
        {
            this.txtSecuenciaHasta.Enabled = true;
        }

        private void txtSecuenciaHasta_TextChanged(object sender, EventArgs e)
        {
            this.cmdGenerar.Enabled = true;
        }

        private void txtSecuenciaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validando que no pueda ingresar espacios, letras y simbolos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSecuenciaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validando que no pueda ingresar espacios, letras y simbolos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
