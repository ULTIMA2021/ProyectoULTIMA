namespace AppAlumno.menuScreens
{
    partial class replyScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensajeDocente = new System.Windows.Forms.TextBox();
            this.txtMensajeAlumno = new System.Windows.Forms.TextBox();
            this.lblNombreDocente = new System.Windows.Forms.Label();
            this.lblNombreAlumno = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnEnviar);
            this.panel1.Controls.Add(this.txtRespuesta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 140);
            this.panel1.TabIndex = 0;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            this.btnEnviar.Enabled = false;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEnviar.Location = new System.Drawing.Point(519, 20);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(125, 102);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Enabled = false;
            this.txtRespuesta.Location = new System.Drawing.Point(26, 20);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRespuesta.Size = new System.Drawing.Size(480, 108);
            this.txtRespuesta.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.txtMensajeDocente);
            this.panel2.Controls.Add(this.txtMensajeAlumno);
            this.panel2.Controls.Add(this.lblNombreDocente);
            this.panel2.Controls.Add(this.lblNombreAlumno);
            this.panel2.Controls.Add(this.shapeContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(656, 329);
            this.panel2.TabIndex = 1;
            // 
            // txtMensajeDocente
            // 
            this.txtMensajeDocente.BackColor = System.Drawing.Color.PowderBlue;
            this.txtMensajeDocente.Enabled = false;
            this.txtMensajeDocente.Location = new System.Drawing.Point(36, 202);
            this.txtMensajeDocente.Multiline = true;
            this.txtMensajeDocente.Name = "txtMensajeDocente";
            this.txtMensajeDocente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeDocente.Size = new System.Drawing.Size(587, 105);
            this.txtMensajeDocente.TabIndex = 6;
            this.txtMensajeDocente.Visible = false;
            // 
            // txtMensajeAlumno
            // 
            this.txtMensajeAlumno.BackColor = System.Drawing.Color.PowderBlue;
            this.txtMensajeAlumno.Enabled = false;
            this.txtMensajeAlumno.Location = new System.Drawing.Point(36, 35);
            this.txtMensajeAlumno.Multiline = true;
            this.txtMensajeAlumno.Name = "txtMensajeAlumno";
            this.txtMensajeAlumno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeAlumno.Size = new System.Drawing.Size(587, 105);
            this.txtMensajeAlumno.TabIndex = 5;
            // 
            // lblNombreDocente
            // 
            this.lblNombreDocente.AutoSize = true;
            this.lblNombreDocente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDocente.Location = new System.Drawing.Point(35, 184);
            this.lblNombreDocente.Name = "lblNombreDocente";
            this.lblNombreDocente.Size = new System.Drawing.Size(111, 15);
            this.lblNombreDocente.TabIndex = 3;
            this.lblNombreDocente.Text = "nombre docente";
            this.lblNombreDocente.Visible = false;
            // 
            // lblNombreAlumno
            // 
            this.lblNombreAlumno.AutoSize = true;
            this.lblNombreAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAlumno.Location = new System.Drawing.Point(33, 17);
            this.lblNombreAlumno.Name = "lblNombreAlumno";
            this.lblNombreAlumno.Size = new System.Drawing.Size(108, 15);
            this.lblNombreAlumno.TabIndex = 1;
            this.lblNombreAlumno.Text = "nombre alumno";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(656, 329);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = -1;
            this.lineShape2.X2 = 654;
            this.lineShape2.Y1 = 324;
            this.lineShape2.Y2 = 324;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 22;
            this.lineShape1.X2 = 636;
            this.lineShape1.Y1 = 166;
            this.lineShape1.Y2 = 166;
            // 
            // replyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(656, 469);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "replyScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mensajes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblNombreDocente;
        public System.Windows.Forms.Label lblNombreAlumno;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        public System.Windows.Forms.TextBox txtMensajeDocente;
        public System.Windows.Forms.TextBox txtMensajeAlumno;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
    }
}