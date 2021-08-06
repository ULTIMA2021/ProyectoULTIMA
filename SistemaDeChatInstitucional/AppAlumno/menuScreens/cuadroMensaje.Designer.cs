namespace AppAlumno.menuScreens
{
    partial class cuadroMensaje
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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.txtMensajeAlumno = new System.Windows.Forms.TextBox();
            this.lblNombrePersona = new System.Windows.Forms.Label();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelContenedor.Controls.Add(this.txtMensajeAlumno);
            this.panelContenedor.Controls.Add(this.lblNombrePersona);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(656, 150);
            this.panelContenedor.TabIndex = 0;
            // 
            // txtMensajeAlumno
            // 
            this.txtMensajeAlumno.BackColor = System.Drawing.Color.PowderBlue;
            this.txtMensajeAlumno.Enabled = false;
            this.txtMensajeAlumno.Location = new System.Drawing.Point(66, 46);
            this.txtMensajeAlumno.Multiline = true;
            this.txtMensajeAlumno.Name = "txtMensajeAlumno";
            this.txtMensajeAlumno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeAlumno.Size = new System.Drawing.Size(546, 92);
            this.txtMensajeAlumno.TabIndex = 9;
            // 
            // lblNombrePersona
            // 
            this.lblNombrePersona.AutoSize = true;
            this.lblNombrePersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePersona.Location = new System.Drawing.Point(12, 18);
            this.lblNombrePersona.Name = "lblNombrePersona";
            this.lblNombrePersona.Size = new System.Drawing.Size(112, 15);
            this.lblNombrePersona.TabIndex = 8;
            this.lblNombrePersona.Text = "nombre persona";
            // 
            // cuadroMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 150);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cuadroMensaje";
            this.Text = "cuadroMensaje";
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        public System.Windows.Forms.TextBox txtMensajeAlumno;
        public System.Windows.Forms.Label lblNombrePersona;
    }
}