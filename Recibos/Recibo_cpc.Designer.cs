namespace RentATruck.Recibos
{
    partial class Recibo_cpc
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtCodigoFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGenerar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(859, 456);
            this.crystalReportViewer1.TabIndex = 12;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // txtCodigoFactura
            // 
            this.txtCodigoFactura.Location = new System.Drawing.Point(112, 13);
            this.txtCodigoFactura.Name = "txtCodigoFactura";
            this.txtCodigoFactura.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoFactura.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Codigo Factura:";
            // 
            // cmdGenerar
            // 
            this.cmdGenerar.Location = new System.Drawing.Point(237, 11);
            this.cmdGenerar.Name = "cmdGenerar";
            this.cmdGenerar.Size = new System.Drawing.Size(75, 23);
            this.cmdGenerar.TabIndex = 9;
            this.cmdGenerar.Text = "Generar Reporte";
            this.cmdGenerar.UseVisualStyleBackColor = true;
            // 
            // Recibo_cpc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 456);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.txtCodigoFactura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGenerar);
            this.Name = "Recibo_cpc";
            this.Text = "Recibo_cpc";
            this.Load += new System.EventHandler(this.Recibo_cpc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox txtCodigoFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdGenerar;
    }
}