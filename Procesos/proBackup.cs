using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentATruck.Procesos
{
    public partial class proBackup : Form
    {
        private static proBackup backupInstancia = null;
        public proBackup()
        {
            InitializeComponent();
        }

        public static proBackup InstanciaBackup()
        {
            if ((backupInstancia == null) || (backupInstancia.IsDisposed == true))
            {
                backupInstancia = new proBackup();
            }
            backupInstancia.BringToFront();
            return backupInstancia;
        }

        // Call the function of tick event of the timer:_...
        // Set the timer Intervel at 60:_
        // Set the timer enabled "True" by the timer properties:_


        //Create the function for progress bar:_
        public void fn_prbar_()
        {
            progressBar1.Increment(1);
            label1.Text = "Haciendo Backup  " + progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();

                string info = @"C:\RentATruck\backup.bat";
                Process test = new Process();
                test.StartInfo.FileName = info;
                test.StartInfo.UseShellExecute = false;
                test.StartInfo.RedirectStandardOutput = true;
                test.StartInfo.RedirectStandardError = true;
                test.Start();

                string Copiar = @"C:\RentATruck\Copiar.bat";
                Process test2 = new Process();
                test2.StartInfo.FileName = Copiar;
                test2.StartInfo.UseShellExecute = false;
                test2.StartInfo.RedirectStandardOutput = true;
                test2.StartInfo.RedirectStandardError = true;
                test2.Start();


                string result = test.StandardOutput.ReadToEnd();
                string error = test.StandardError.ReadToEnd();

                test.WaitForExit();
                if (error != "")
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show("Backup Listo");
                    //copiar();
                    //MessageBox.Show(result);
                }
                progressBar1.Value = 0;
                label1.Text = "";
                timer1.Stop();
            }
        }

        public void copiar()
        {
            //progressBar1.Increment(1);
            //label1.Text = "Copiando Archivos de Backup  " + progressBar1.Value.ToString() + "%";
            //if (progressBar1.Value == progressBar1.Maximum)
            //{
            //    timer1.Stop();
            //    string Copiar = @"C:\RentATruck\Copiar.bat";
            //    Process test2 = new Process();
            //    test2.StartInfo.FileName = Copiar;
            //    test2.StartInfo.UseShellExecute = false;
            //    test2.StartInfo.RedirectStandardOutput = true;
            //    test2.StartInfo.RedirectStandardError = true;
            //    test2.Start();


            //    string result = test2.StandardOutput.ReadToEnd();
            //    string error = test2.StandardError.ReadToEnd();

            //    test2.WaitForExit();
            //    if (error != "")
            //    {
            //        MessageBox.Show(error);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Proceso terminado");
            //        //MessageBox.Show(result);
            //    }
            //    progressBar1.Value = 0;
            //    label1.Text = "";
            //    timer1.Stop();
            //}
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            fn_prbar_();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void proBackup_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Abre folder en el explorer
            //Process.Start(@"C:\RentATruck\Backup");
            // Abre folder en el explorer
            Process.Start("explorer.exe", @"C:\RentATruck\Backup");
            //// lanza un error
            //Process.Start(@"c:\");
            //// opens explorer, showing some other folder)
            //Process.Start("explorer.exe", @"c:\");
        }
    }
}
