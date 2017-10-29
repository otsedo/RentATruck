namespace RentATruck.Formularios
{
    partial class frmTarjetaCredito
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
            this.txt4Digitos = new System.Windows.Forms.TextBox();
            this.txtAprobacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.Label();
            this.txtCantidadPagar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt4Digitos
            // 
            this.txt4Digitos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4Digitos.Location = new System.Drawing.Point(50, 111);
            this.txt4Digitos.Name = "txt4Digitos";
            this.txt4Digitos.Size = new System.Drawing.Size(175, 26);
            this.txt4Digitos.TabIndex = 21;
            this.txt4Digitos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAprobacion
            // 
            this.txtAprobacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAprobacion.Location = new System.Drawing.Point(50, 179);
            this.txtAprobacion.Name = "txtAprobacion";
            this.txtAprobacion.Size = new System.Drawing.Size(175, 26);
            this.txtAprobacion.TabIndex = 19;
            this.txtAprobacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "Aprobacion";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.AutoSize = true;
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(7, 81);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(271, 22);
            this.txtEfectivo.TabIndex = 17;
            this.txtEfectivo.Text = "Ultimos 4 digitos de la tarjeta";
            // 
            // txtCantidadPagar
            // 
            this.txtCantidadPagar.Enabled = false;
            this.txtCantidadPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadPagar.Location = new System.Drawing.Point(50, 38);
            this.txtCantidadPagar.Name = "txtCantidadPagar";
            this.txtCantidadPagar.Size = new System.Drawing.Size(175, 26);
            this.txtCantidadPagar.TabIndex = 16;
            this.txtCantidadPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cantidad a Pagar";
            // 
            // button1
            // 
            this.button1.Image = global::RentATruck.Properties.Resources.yes;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(83, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 35);
            this.button1.TabIndex = 20;
            this.button1.Text = "&Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTarjetaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txt4Digitos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAprobacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.txtCantidadPagar);
            this.Controls.Add(this.label1);
            this.Name = "frmTarjetaCredito";
            this.Text = "frmTarjetaCredito";
            this.Load += new System.EventHandler(this.frmTarjetaCredito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt4Digitos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAprobacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtEfectivo;
        private System.Windows.Forms.TextBox txtCantidadPagar;
        private System.Windows.Forms.Label label1;
    }
}