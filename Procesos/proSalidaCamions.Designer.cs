namespace RentATruck.Procesos
{
    partial class proSalidaCamions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(proSalidaCamions));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmdProcesar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCamion = new System.Windows.Forms.TextBox();
            this.cmdBuscarCodCli = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersonaRecibe = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaSalida = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHoraSalida = new System.Windows.Forms.TextBox();
            this.txtHoraEntrada = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaEntrada = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKilometraje = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCombustible = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDatosCamion = new System.Windows.Forms.Label();
            this.lblDatosCliente = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(833, 38);
            this.textBox1.TabIndex = 92;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Salida de Camiones";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdProcesar
            // 
            this.cmdProcesar.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcesar.ForeColor = System.Drawing.Color.White;
            this.cmdProcesar.Location = new System.Drawing.Point(622, 314);
            this.cmdProcesar.Name = "cmdProcesar";
            this.cmdProcesar.Size = new System.Drawing.Size(178, 35);
            this.cmdProcesar.TabIndex = 93;
            this.cmdProcesar.Text = "Procesar Salida";
            this.cmdProcesar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 95;
            this.label2.Text = "Camion:";
            // 
            // txtCamion
            // 
            this.txtCamion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamion.Location = new System.Drawing.Point(99, 62);
            this.txtCamion.MaxLength = 40;
            this.txtCamion.Name = "txtCamion";
            this.txtCamion.Size = new System.Drawing.Size(61, 26);
            this.txtCamion.TabIndex = 94;
            // 
            // cmdBuscarCodCli
            // 
            this.cmdBuscarCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuscarCodCli.ForeColor = System.Drawing.Color.SteelBlue;
            this.cmdBuscarCodCli.Image = global::RentATruck.Properties.Resources.if_InterfaceExpendet_13_592605__3_;
            this.cmdBuscarCodCli.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBuscarCodCli.Location = new System.Drawing.Point(166, 59);
            this.cmdBuscarCodCli.Name = "cmdBuscarCodCli";
            this.cmdBuscarCodCli.Size = new System.Drawing.Size(48, 35);
            this.cmdBuscarCodCli.TabIndex = 97;
            this.cmdBuscarCodCli.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBuscarCodCli.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Image = global::RentATruck.Properties.Resources.if_InterfaceExpendet_13_592605__3_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(166, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 35);
            this.button1.TabIndex = 101;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(23, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "Cliente:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoCliente.Location = new System.Drawing.Point(99, 103);
            this.txtCodigoCliente.MaxLength = 40;
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(61, 26);
            this.txtCodigoCliente.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(18, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 102;
            this.label3.Text = "Perona Recibe:";
            // 
            // txtPersonaRecibe
            // 
            this.txtPersonaRecibe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonaRecibe.Location = new System.Drawing.Point(153, 139);
            this.txtPersonaRecibe.MaxLength = 40;
            this.txtPersonaRecibe.Name = "txtPersonaRecibe";
            this.txtPersonaRecibe.Size = new System.Drawing.Size(363, 26);
            this.txtPersonaRecibe.TabIndex = 103;
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(598, 139);
            this.txtCedula.MaxLength = 40;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(202, 26);
            this.txtCedula.TabIndex = 105;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(594, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 104;
            this.label4.Text = "Cédula:";
            // 
            // fechaSalida
            // 
            this.fechaSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaSalida.Location = new System.Drawing.Point(153, 174);
            this.fechaSalida.MinDate = new System.DateTime(2017, 11, 11, 0, 0, 0, 0);
            this.fechaSalida.Name = "fechaSalida";
            this.fechaSalida.Size = new System.Drawing.Size(158, 26);
            this.fechaSalida.TabIndex = 109;
            this.fechaSalida.Value = new System.DateTime(2017, 11, 11, 0, 0, 0, 0);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.SteelBlue;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(31, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 20);
            this.label16.TabIndex = 110;
            this.label16.Text = "Fecha Salida:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(327, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 111;
            this.label5.Text = "Hora Salida:";
            // 
            // txtHoraSalida
            // 
            this.txtHoraSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraSalida.Location = new System.Drawing.Point(441, 176);
            this.txtHoraSalida.MaxLength = 40;
            this.txtHoraSalida.Name = "txtHoraSalida";
            this.txtHoraSalida.Size = new System.Drawing.Size(85, 26);
            this.txtHoraSalida.TabIndex = 112;
            // 
            // txtHoraEntrada
            // 
            this.txtHoraEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraEntrada.Location = new System.Drawing.Point(441, 208);
            this.txtHoraEntrada.MaxLength = 40;
            this.txtHoraEntrada.Name = "txtHoraEntrada";
            this.txtHoraEntrada.Size = new System.Drawing.Size(85, 26);
            this.txtHoraEntrada.TabIndex = 116;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(313, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 115;
            this.label6.Text = "Hora Entrada:";
            // 
            // txtFechaEntrada
            // 
            this.txtFechaEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFechaEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaEntrada.Location = new System.Drawing.Point(153, 209);
            this.txtFechaEntrada.MinDate = new System.DateTime(2017, 11, 11, 0, 0, 0, 0);
            this.txtFechaEntrada.Name = "txtFechaEntrada";
            this.txtFechaEntrada.Size = new System.Drawing.Size(158, 26);
            this.txtFechaEntrada.TabIndex = 113;
            this.txtFechaEntrada.Value = new System.DateTime(2017, 11, 11, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(17, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 114;
            this.label7.Text = "Fecha Entrada:";
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKilometraje.Location = new System.Drawing.Point(153, 244);
            this.txtKilometraje.MaxLength = 40;
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Size = new System.Drawing.Size(158, 26);
            this.txtKilometraje.TabIndex = 118;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(47, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 117;
            this.label8.Text = "Kilometraje:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(594, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 20);
            this.label9.TabIndex = 119;
            this.label9.Text = "Referencia:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(598, 197);
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(202, 37);
            this.txtReferencia.TabIndex = 120;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcepto.Location = new System.Drawing.Point(441, 247);
            this.txtConcepto.MaxLength = 40;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(359, 26);
            this.txtConcepto.TabIndex = 122;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(344, 250);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 20);
            this.label10.TabIndex = 121;
            this.label10.Text = "Concepto:";
            // 
            // txtCombustible
            // 
            this.txtCombustible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCombustible.Location = new System.Drawing.Point(153, 279);
            this.txtCombustible.MaxLength = 40;
            this.txtCombustible.Name = "txtCombustible";
            this.txtCombustible.Size = new System.Drawing.Size(158, 26);
            this.txtCombustible.TabIndex = 124;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.SteelBlue;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(37, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 20);
            this.label11.TabIndex = 123;
            this.label11.Text = "Combustible:";
            // 
            // txtSucursal
            // 
            this.txtSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSucursal.Location = new System.Drawing.Point(441, 282);
            this.txtSucursal.MaxLength = 40;
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(359, 26);
            this.txtSucursal.TabIndex = 126;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(344, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 125;
            this.label12.Text = "Sucursal";
            // 
            // lblDatosCamion
            // 
            this.lblDatosCamion.AutoSize = true;
            this.lblDatosCamion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosCamion.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDatosCamion.Location = new System.Drawing.Point(237, 65);
            this.lblDatosCamion.Name = "lblDatosCamion";
            this.lblDatosCamion.Size = new System.Drawing.Size(333, 20);
            this.lblDatosCamion.TabIndex = 127;
            this.lblDatosCamion.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // lblDatosCliente
            // 
            this.lblDatosCliente.AutoSize = true;
            this.lblDatosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosCliente.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDatosCliente.Location = new System.Drawing.Point(237, 106);
            this.lblDatosCliente.Name = "lblDatosCliente";
            this.lblDatosCliente.Size = new System.Drawing.Size(333, 20);
            this.lblDatosCliente.TabIndex = 128;
            this.lblDatosCliente.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.IndianRed;
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cmdCancelar.ForeColor = System.Drawing.Color.White;
            this.cmdCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdCancelar.Location = new System.Drawing.Point(441, 314);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(178, 35);
            this.cmdCancelar.TabIndex = 138;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = false;
            // 
            // proSalidaCamions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 385);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.lblDatosCliente);
            this.Controls.Add(this.lblDatosCamion);
            this.Controls.Add(this.txtSucursal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCombustible);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtKilometraje);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtHoraEntrada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFechaEntrada);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHoraSalida);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fechaSalida);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPersonaRecibe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.cmdBuscarCodCli);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCamion);
            this.Controls.Add(this.cmdProcesar);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "proSalidaCamions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button cmdProcesar;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCamion;
        private System.Windows.Forms.Button cmdBuscarCodCli;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPersonaRecibe;
        public System.Windows.Forms.TextBox txtCedula;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaSalida;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtHoraSalida;
        public System.Windows.Forms.TextBox txtHoraEntrada;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker txtFechaEntrada;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtKilometraje;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReferencia;
        public System.Windows.Forms.TextBox txtConcepto;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtCombustible;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtSucursal;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lblDatosCamion;
        public System.Windows.Forms.Label lblDatosCliente;
        public System.Windows.Forms.Button cmdCancelar;
    }
}