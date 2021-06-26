namespace AppAlumno
{
    partial class alumnoMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(alumnoMainScreen));
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.btnMensajes = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.subMenuDocentes = new System.Windows.Forms.Panel();
            this.btnInstitucion = new System.Windows.Forms.Button();
            this.btnMisDocentes = new System.Windows.Forms.Button();
            this.btnDocentes = new System.Windows.Forms.Button();
            this.subMenuMiPerfil = new System.Windows.Forms.Panel();
            this.btnAsignaturas = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnMiPerfil = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.fotoAlumno = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelContenedor.SuspendLayout();
            this.subMenuDocentes.SuspendLayout();
            this.subMenuMiPerfil.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOpciones
            // 
            this.panelOpciones.BackColor = System.Drawing.Color.Blue;
            this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOpciones.Location = new System.Drawing.Point(0, 0);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(855, 27);
            this.panelOpciones.TabIndex = 0;
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panelContenedor.Controls.Add(this.btnMensajes);
            this.panelContenedor.Controls.Add(this.btnAgenda);
            this.panelContenedor.Controls.Add(this.subMenuDocentes);
            this.panelContenedor.Controls.Add(this.btnDocentes);
            this.panelContenedor.Controls.Add(this.subMenuMiPerfil);
            this.panelContenedor.Controls.Add(this.btnMiPerfil);
            this.panelContenedor.Controls.Add(this.panel2);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelContenedor.Location = new System.Drawing.Point(0, 27);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(191, 525);
            this.panelContenedor.TabIndex = 1;
            // 
            // btnMensajes
            // 
            this.btnMensajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnMensajes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMensajes.FlatAppearance.BorderSize = 0;
            this.btnMensajes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnMensajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMensajes.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMensajes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMensajes.Image = ((System.Drawing.Image)(resources.GetObject("btnMensajes.Image")));
            this.btnMensajes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMensajes.Location = new System.Drawing.Point(0, 464);
            this.btnMensajes.Name = "btnMensajes";
            this.btnMensajes.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnMensajes.Size = new System.Drawing.Size(191, 36);
            this.btnMensajes.TabIndex = 8;
            this.btnMensajes.Text = "            Mensajes";
            this.btnMensajes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMensajes.UseVisualStyleBackColor = false;
            this.btnMensajes.Click += new System.EventHandler(this.btnMensajes_Click);
            // 
            // btnAgenda
            // 
            this.btnAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnAgenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgenda.FlatAppearance.BorderSize = 0;
            this.btnAgenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgenda.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgenda.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgenda.Image = ((System.Drawing.Image)(resources.GetObject("btnAgenda.Image")));
            this.btnAgenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgenda.Location = new System.Drawing.Point(0, 428);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnAgenda.Size = new System.Drawing.Size(191, 36);
            this.btnAgenda.TabIndex = 7;
            this.btnAgenda.Text = "            Agenda";
            this.btnAgenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgenda.UseVisualStyleBackColor = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // subMenuDocentes
            // 
            this.subMenuDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.subMenuDocentes.Controls.Add(this.btnInstitucion);
            this.subMenuDocentes.Controls.Add(this.btnMisDocentes);
            this.subMenuDocentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.subMenuDocentes.Location = new System.Drawing.Point(0, 337);
            this.subMenuDocentes.Name = "subMenuDocentes";
            this.subMenuDocentes.Size = new System.Drawing.Size(191, 91);
            this.subMenuDocentes.TabIndex = 6;
            this.subMenuDocentes.Visible = false;
            // 
            // btnInstitucion
            // 
            this.btnInstitucion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.btnInstitucion.FlatAppearance.BorderSize = 0;
            this.btnInstitucion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(80)))), ((int)(((byte)(250)))));
            this.btnInstitucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstitucion.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstitucion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInstitucion.Location = new System.Drawing.Point(0, 48);
            this.btnInstitucion.Name = "btnInstitucion";
            this.btnInstitucion.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnInstitucion.Size = new System.Drawing.Size(191, 36);
            this.btnInstitucion.TabIndex = 7;
            this.btnInstitucion.Text = "Institucion";
            this.btnInstitucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstitucion.UseVisualStyleBackColor = false;
            // 
            // btnMisDocentes
            // 
            this.btnMisDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.btnMisDocentes.FlatAppearance.BorderSize = 0;
            this.btnMisDocentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(80)))), ((int)(((byte)(250)))));
            this.btnMisDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMisDocentes.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisDocentes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMisDocentes.Location = new System.Drawing.Point(0, 6);
            this.btnMisDocentes.Name = "btnMisDocentes";
            this.btnMisDocentes.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnMisDocentes.Size = new System.Drawing.Size(191, 36);
            this.btnMisDocentes.TabIndex = 6;
            this.btnMisDocentes.Text = "Mis docentes";
            this.btnMisDocentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMisDocentes.UseVisualStyleBackColor = false;
            // 
            // btnDocentes
            // 
            this.btnDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnDocentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDocentes.FlatAppearance.BorderSize = 0;
            this.btnDocentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocentes.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocentes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDocentes.Image = ((System.Drawing.Image)(resources.GetObject("btnDocentes.Image")));
            this.btnDocentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocentes.Location = new System.Drawing.Point(0, 301);
            this.btnDocentes.Name = "btnDocentes";
            this.btnDocentes.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnDocentes.Size = new System.Drawing.Size(191, 36);
            this.btnDocentes.TabIndex = 5;
            this.btnDocentes.Text = "            Docentes";
            this.btnDocentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocentes.UseVisualStyleBackColor = false;
            this.btnDocentes.Click += new System.EventHandler(this.btnDocentes_Click);
            // 
            // subMenuMiPerfil
            // 
            this.subMenuMiPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.subMenuMiPerfil.Controls.Add(this.btnAsignaturas);
            this.subMenuMiPerfil.Controls.Add(this.btnEditar);
            this.subMenuMiPerfil.Dock = System.Windows.Forms.DockStyle.Top;
            this.subMenuMiPerfil.Location = new System.Drawing.Point(0, 211);
            this.subMenuMiPerfil.Name = "subMenuMiPerfil";
            this.subMenuMiPerfil.Size = new System.Drawing.Size(191, 90);
            this.subMenuMiPerfil.TabIndex = 4;
            this.subMenuMiPerfil.Visible = false;
            // 
            // btnAsignaturas
            // 
            this.btnAsignaturas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.btnAsignaturas.FlatAppearance.BorderSize = 0;
            this.btnAsignaturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(80)))), ((int)(((byte)(250)))));
            this.btnAsignaturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignaturas.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignaturas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAsignaturas.Location = new System.Drawing.Point(0, 48);
            this.btnAsignaturas.Name = "btnAsignaturas";
            this.btnAsignaturas.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnAsignaturas.Size = new System.Drawing.Size(191, 36);
            this.btnAsignaturas.TabIndex = 6;
            this.btnAsignaturas.Text = "Mis asignaturas";
            this.btnAsignaturas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignaturas.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(80)))), ((int)(((byte)(250)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditar.Location = new System.Drawing.Point(0, 6);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnEditar.Size = new System.Drawing.Size(191, 36);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "Configuracion";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnMiPerfil
            // 
            this.btnMiPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnMiPerfil.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMiPerfil.FlatAppearance.BorderSize = 0;
            this.btnMiPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnMiPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiPerfil.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiPerfil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMiPerfil.Image = ((System.Drawing.Image)(resources.GetObject("btnMiPerfil.Image")));
            this.btnMiPerfil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMiPerfil.Location = new System.Drawing.Point(0, 175);
            this.btnMiPerfil.Name = "btnMiPerfil";
            this.btnMiPerfil.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnMiPerfil.Size = new System.Drawing.Size(191, 36);
            this.btnMiPerfil.TabIndex = 2;
            this.btnMiPerfil.Text = "            Mi perfil";
            this.btnMiPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMiPerfil.UseVisualStyleBackColor = false;
            this.btnMiPerfil.Click += new System.EventHandler(this.btnMiPerfil_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNombre);
            this.panel2.Controls.Add(this.fotoAlumno);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 175);
            this.panel2.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNombre.Location = new System.Drawing.Point(38, 127);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(94, 14);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Apellido";
            // 
            // fotoAlumno
            // 
            this.fotoAlumno.Image = ((System.Drawing.Image)(resources.GetObject("fotoAlumno.Image")));
            this.fotoAlumno.Location = new System.Drawing.Point(41, 6);
            this.fotoAlumno.Name = "fotoAlumno";
            this.fotoAlumno.Size = new System.Drawing.Size(117, 107);
            this.fotoAlumno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.fotoAlumno.TabIndex = 0;
            this.fotoAlumno.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(191, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 525);
            this.panel1.TabIndex = 2;
            // 
            // alumnoMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 552);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelOpciones);
            this.Name = "alumnoMainScreen";
            this.Text = "alumnoMainScreen";
            this.panelContenedor.ResumeLayout(false);
            this.subMenuDocentes.ResumeLayout(false);
            this.subMenuMiPerfil.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoAlumno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel subMenuMiPerfil;
        private System.Windows.Forms.Button btnAsignaturas;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnMiPerfil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox fotoAlumno;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel subMenuDocentes;
        private System.Windows.Forms.Button btnInstitucion;
        private System.Windows.Forms.Button btnMisDocentes;
        private System.Windows.Forms.Button btnDocentes;
        private System.Windows.Forms.Button btnMensajes;
        private System.Windows.Forms.Button btnAgenda;
    }
}