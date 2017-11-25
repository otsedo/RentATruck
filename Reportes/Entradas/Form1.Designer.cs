namespace RentATruck.Reportes.Entradas
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtCamion = new System.Windows.Forms.TextBox();
            this.lblDatosCamion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmdNuevo = new System.Windows.Forms.Button();
            this.cmdBuscarCodCli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCamion
            // 
            this.txtCamion.Enabled = false;
            this.txtCamion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamion.Location = new System.Drawing.Point(424, 293);
            this.txtCamion.MaxLength = 40;
            this.txtCamion.Name = "txtCamion";
            this.txtCamion.Size = new System.Drawing.Size(143, 26);
            this.txtCamion.TabIndex = 167;
            this.txtCamion.Visible = false;
            this.txtCamion.TextChanged += new System.EventHandler(this.txtCamion_TextChanged);
            // 
            // lblDatosCamion
            // 
            this.lblDatosCamion.AutoSize = true;
            this.lblDatosCamion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosCamion.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDatosCamion.Location = new System.Drawing.Point(159, 62);
            this.lblDatosCamion.Name = "lblDatosCamion";
            this.lblDatosCamion.Size = new System.Drawing.Size(0, 20);
            this.lblDatosCamion.TabIndex = 166;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 164;
            this.label2.Text = "Camion:";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 90);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(966, 513);
            this.crystalReportViewer1.TabIndex = 163;
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
            this.textBox1.Size = new System.Drawing.Size(990, 38);
            this.textBox1.TabIndex = 162;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Entrada de Camiones";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdNuevo
            // 
            this.cmdNuevo.BackColor = System.Drawing.Color.SteelBlue;
            this.cmdNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNuevo.ForeColor = System.Drawing.Color.White;
            this.cmdNuevo.Location = new System.Drawing.Point(776, 54);
            this.cmdNuevo.Name = "cmdNuevo";
            this.cmdNuevo.Size = new System.Drawing.Size(95, 35);
            this.cmdNuevo.TabIndex = 161;
            this.cmdNuevo.Text = "Generar";
            this.cmdNuevo.UseVisualStyleBackColor = false;
            this.cmdNuevo.Click += new System.EventHandler(this.cmdNuevo_Click);
            // 
            // cmdBuscarCodCli
            // 
            this.cmdBuscarCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuscarCodCli.ForeColor = System.Drawing.Color.SteelBlue;
            this.cmdBuscarCodCli.Image = global::RentATruck.Properties.Resources.if_InterfaceExpendet_13_592605__3_;
            this.cmdBuscarCodCli.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBuscarCodCli.Location = new System.Drawing.Point(105, 47);
            this.cmdBuscarCodCli.Name = "cmdBuscarCodCli";
            this.cmdBuscarCodCli.Size = new System.Drawing.Size(48, 35);
            this.cmdBuscarCodCli.TabIndex = 165;
            this.cmdBuscarCodCli.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBuscarCodCli.UseVisualStyleBackColor = true;
            this.cmdBuscarCodCli.Click += new System.EventHandler(this.cmdBuscarCodCli_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 606);
            this.Controls.Add(this.txtCamion);
            this.Controls.Add(this.lblDatosCamion);
            this.Controls.Add(this.cmdBuscarCodCli);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmdNuevo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCamion;
        public System.Windows.Forms.Label lblDatosCamion;
        private System.Windows.Forms.Button cmdBuscarCodCli;
        public System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button cmdNuevo;
    }
}