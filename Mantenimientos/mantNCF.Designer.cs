namespace RentATruck.Mantenimientos
{
    partial class mantNCF
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmdGenerar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSecuenciaHasta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSecuenciaDesde = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTCF = new System.Windows.Forms.ComboBox();
            this.txtAI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSerie = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.textBox1.Size = new System.Drawing.Size(718, 38);
            this.textBox1.TabIndex = 87;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Mantenimiento de NCF";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(209, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 38);
            this.button2.TabIndex = 104;
            this.button2.Text = "Guardar NCF";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(397, 76);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(235, 328);
            this.listBox1.TabIndex = 103;
            // 
            // cmdGenerar
            // 
            this.cmdGenerar.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdGenerar.Enabled = false;
            this.cmdGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerar.ForeColor = System.Drawing.Color.White;
            this.cmdGenerar.Location = new System.Drawing.Point(209, 328);
            this.cmdGenerar.Name = "cmdGenerar";
            this.cmdGenerar.Size = new System.Drawing.Size(182, 38);
            this.cmdGenerar.TabIndex = 102;
            this.cmdGenerar.Text = "Generar Secuencia";
            this.cmdGenerar.UseVisualStyleBackColor = false;
            this.cmdGenerar.Click += new System.EventHandler(this.cmdGenerar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(38, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 20);
            this.label7.TabIndex = 101;
            this.label7.Text = "Secuencia Hasta:";
            // 
            // txtSecuenciaHasta
            // 
            this.txtSecuenciaHasta.Enabled = false;
            this.txtSecuenciaHasta.Location = new System.Drawing.Point(195, 302);
            this.txtSecuenciaHasta.MaxLength = 8;
            this.txtSecuenciaHasta.Name = "txtSecuenciaHasta";
            this.txtSecuenciaHasta.Size = new System.Drawing.Size(196, 20);
            this.txtSecuenciaHasta.TabIndex = 100;
            this.txtSecuenciaHasta.TextChanged += new System.EventHandler(this.txtSecuenciaHasta_TextChanged);
            this.txtSecuenciaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecuenciaHasta_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(34, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 20);
            this.label6.TabIndex = 99;
            this.label6.Text = "Secuencia Desde:";
            // 
            // txtSecuenciaDesde
            // 
            this.txtSecuenciaDesde.Enabled = false;
            this.txtSecuenciaDesde.Location = new System.Drawing.Point(195, 265);
            this.txtSecuenciaDesde.MaxLength = 8;
            this.txtSecuenciaDesde.Name = "txtSecuenciaDesde";
            this.txtSecuenciaDesde.Size = new System.Drawing.Size(196, 20);
            this.txtSecuenciaDesde.TabIndex = 98;
            this.txtSecuenciaDesde.TextChanged += new System.EventHandler(this.txtSecuenciaDesde_TextChanged);
            this.txtSecuenciaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecuenciaDesde_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(101, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 97;
            this.label5.Text = "Tipo NCF:";
            // 
            // cmbTCF
            // 
            this.cmbTCF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTCF.Enabled = false;
            this.cmbTCF.FormattingEnabled = true;
            this.cmbTCF.Location = new System.Drawing.Point(195, 227);
            this.cmbTCF.Name = "cmbTCF";
            this.cmbTCF.Size = new System.Drawing.Size(196, 21);
            this.cmbTCF.TabIndex = 96;
            this.cmbTCF.SelectionChangeCommitted += new System.EventHandler(this.cmbTCF_SelectionChangeCommitted);
            // 
            // txtAI
            // 
            this.txtAI.Enabled = false;
            this.txtAI.Location = new System.Drawing.Point(195, 190);
            this.txtAI.MaxLength = 3;
            this.txtAI.Name = "txtAI";
            this.txtAI.Size = new System.Drawing.Size(196, 20);
            this.txtAI.TabIndex = 95;
            this.txtAI.TextChanged += new System.EventHandler(this.txtAI_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(28, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 94;
            this.label4.Text = "Area de Impresion:";
            // 
            // txtPE
            // 
            this.txtPE.Enabled = false;
            this.txtPE.Location = new System.Drawing.Point(195, 153);
            this.txtPE.MaxLength = 3;
            this.txtPE.Name = "txtPE";
            this.txtPE.Size = new System.Drawing.Size(196, 20);
            this.txtPE.TabIndex = 93;
            this.txtPE.TextChanged += new System.EventHandler(this.txtPE_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(35, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 92;
            this.label3.Text = "Punto de Emision:";
            // 
            // txtDN
            // 
            this.txtDN.Enabled = false;
            this.txtDN.Location = new System.Drawing.Point(195, 116);
            this.txtDN.MaxLength = 2;
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(196, 20);
            this.txtDN.TabIndex = 91;
            this.txtDN.TextChanged += new System.EventHandler(this.txtDN_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(18, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 90;
            this.label2.Text = "Division de Negocio:";
            // 
            // cmbSerie
            // 
            this.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerie.FormattingEnabled = true;
            this.cmbSerie.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U"});
            this.cmbSerie.Location = new System.Drawing.Point(195, 78);
            this.cmbSerie.Name = "cmbSerie";
            this.cmbSerie.Size = new System.Drawing.Size(196, 21);
            this.cmbSerie.TabIndex = 89;
            this.cmbSerie.SelectionChangeCommitted += new System.EventHandler(this.cmbSerie_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(133, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "Serie:";
            // 
            // mantNCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 446);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cmdGenerar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSecuenciaHasta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSecuenciaDesde);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTCF);
            this.Controls.Add(this.txtAI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSerie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mantNCF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.mantNCF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button cmdGenerar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSecuenciaHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSecuenciaDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTCF;
        private System.Windows.Forms.TextBox txtAI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSerie;
        private System.Windows.Forms.Label label1;
    }
}