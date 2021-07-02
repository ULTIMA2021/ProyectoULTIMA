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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(alumnoMainScreen));
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.btnMensajes = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.subMenuDocentes = new System.Windows.Forms.Panel();
            this.btnInstitucion = new System.Windows.Forms.Button();
            this.btnMisDocentes = new System.Windows.Forms.Button();
            this.btnDocentes = new System.Windows.Forms.Button();
            this.subMenuMiPerfil = new System.Windows.Forms.Panel();
            this.btnAsignaturas = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnMiPerfil = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.fotoAlumno = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ttInformacion = new System.Windows.Forms.ToolTip(this.components);
            this.panelOpciones.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.subMenuDocentes.SuspendLayout();
            this.subMenuMiPerfil.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoAlumno)).BeginInit();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOpciones
            // 
            this.panelOpciones.BackColor = System.Drawing.Color.Blue;
            this.panelOpciones.Controls.Add(this.btnMinimizar);
            this.panelOpciones.Controls.Add(this.btnMaximizar);
            this.panelOpciones.Controls.Add(this.btnExit);
            this.panelOpciones.Controls.Add(this.btnNormal);
            resources.ApplyResources(this.panelOpciones, "panelOpciones");
            this.panelOpciones.Name = "panelOpciones";
            // 
            // btnMinimizar
            // 
            resources.ApplyResources(this.btnMinimizar, "btnMinimizar");
            this.btnMinimizar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMinimizar.Name = "btnMinimizar";
            this.ttInformacion.SetToolTip(this.btnMinimizar, resources.GetString("btnMinimizar.ToolTip"));
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            resources.ApplyResources(this.btnMaximizar, "btnMaximizar");
            this.btnMaximizar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMaximizar.Name = "btnMaximizar";
            this.ttInformacion.SetToolTip(this.btnMaximizar, resources.GetString("btnMaximizar.ToolTip"));
            this.btnMaximizar.UseVisualStyleBackColor = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnExit.Name = "btnExit";
            this.ttInformacion.SetToolTip(this.btnExit, resources.GetString("btnExit.ToolTip"));
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNormal
            // 
            resources.ApplyResources(this.btnNormal, "btnNormal");
            this.btnNormal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // panelInfo
            // 
            resources.ApplyResources(this.panelInfo, "panelInfo");
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panelInfo.Controls.Add(this.btnMensajes);
            this.panelInfo.Controls.Add(this.btnAgenda);
            this.panelInfo.Controls.Add(this.subMenuDocentes);
            this.panelInfo.Controls.Add(this.btnDocentes);
            this.panelInfo.Controls.Add(this.subMenuMiPerfil);
            this.panelInfo.Controls.Add(this.btnMiPerfil);
            this.panelInfo.Controls.Add(this.panel2);
            this.panelInfo.Name = "panelInfo";
            // 
            // btnMensajes
            // 
            this.btnMensajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.btnMensajes, "btnMensajes");
            this.btnMensajes.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMensajes.FlatAppearance.BorderSize = 0;
            this.btnMensajes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnMensajes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMensajes.Name = "btnMensajes";
            this.btnMensajes.UseVisualStyleBackColor = false;
            this.btnMensajes.Click += new System.EventHandler(this.btnMensajes_Click);
            // 
            // btnAgenda
            // 
            this.btnAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.btnAgenda, "btnAgenda");
            this.btnAgenda.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAgenda.FlatAppearance.BorderSize = 0;
            this.btnAgenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnAgenda.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.UseVisualStyleBackColor = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // subMenuDocentes
            // 
            this.subMenuDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.subMenuDocentes.Controls.Add(this.btnInstitucion);
            this.subMenuDocentes.Controls.Add(this.btnMisDocentes);
            resources.ApplyResources(this.subMenuDocentes, "subMenuDocentes");
            this.subMenuDocentes.Name = "subMenuDocentes";
            // 
            // btnInstitucion
            // 
            this.btnInstitucion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.btnInstitucion.FlatAppearance.BorderSize = 0;
            this.btnInstitucion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(80)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this.btnInstitucion, "btnInstitucion");
            this.btnInstitucion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInstitucion.Name = "btnInstitucion";
            this.btnInstitucion.UseVisualStyleBackColor = false;
            // 
            // btnMisDocentes
            // 
            this.btnMisDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.btnMisDocentes.FlatAppearance.BorderSize = 0;
            this.btnMisDocentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(80)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this.btnMisDocentes, "btnMisDocentes");
            this.btnMisDocentes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMisDocentes.Name = "btnMisDocentes";
            this.btnMisDocentes.UseVisualStyleBackColor = false;
            this.btnMisDocentes.Click += new System.EventHandler(this.btnMisDocentes_Click);
            // 
            // btnDocentes
            // 
            this.btnDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.btnDocentes, "btnDocentes");
            this.btnDocentes.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDocentes.FlatAppearance.BorderSize = 0;
            this.btnDocentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnDocentes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDocentes.Name = "btnDocentes";
            this.btnDocentes.UseVisualStyleBackColor = false;
            this.btnDocentes.Click += new System.EventHandler(this.btnDocentes_Click);
            // 
            // subMenuMiPerfil
            // 
            this.subMenuMiPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.subMenuMiPerfil.Controls.Add(this.btnAsignaturas);
            this.subMenuMiPerfil.Controls.Add(this.btnConfiguracion);
            resources.ApplyResources(this.subMenuMiPerfil, "subMenuMiPerfil");
            this.subMenuMiPerfil.Name = "subMenuMiPerfil";
            // 
            // btnAsignaturas
            // 
            this.btnAsignaturas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.btnAsignaturas.FlatAppearance.BorderSize = 0;
            this.btnAsignaturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(80)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this.btnAsignaturas, "btnAsignaturas");
            this.btnAsignaturas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAsignaturas.Name = "btnAsignaturas";
            this.btnAsignaturas.UseVisualStyleBackColor = false;
            this.btnAsignaturas.Click += new System.EventHandler(this.btnAsignaturas_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(100)))));
            this.btnConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnConfiguracion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(80)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this.btnConfiguracion, "btnConfiguracion");
            this.btnConfiguracion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnMiPerfil
            // 
            this.btnMiPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.btnMiPerfil, "btnMiPerfil");
            this.btnMiPerfil.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMiPerfil.FlatAppearance.BorderSize = 0;
            this.btnMiPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnMiPerfil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMiPerfil.Name = "btnMiPerfil";
            this.btnMiPerfil.UseVisualStyleBackColor = false;
            this.btnMiPerfil.Click += new System.EventHandler(this.btnMiPerfil_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNombre);
            this.panel2.Controls.Add(this.fotoAlumno);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lblNombre
            // 
            resources.ApplyResources(this.lblNombre, "lblNombre");
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNombre.Name = "lblNombre";
            // 
            // fotoAlumno
            // 
            resources.ApplyResources(this.fotoAlumno, "fotoAlumno");
            this.fotoAlumno.Name = "fotoAlumno";
            this.fotoAlumno.TabStop = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            this.panelContenedor.Controls.Add(this.label2);
            this.panelContenedor.Controls.Add(this.label1);
            resources.ApplyResources(this.panelContenedor, "panelContenedor");
            this.panelContenedor.Name = "panelContenedor";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Name = "label1";
            // 
            // alumnoMainScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "alumnoMainScreen";
            this.panelOpciones.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.subMenuDocentes.ResumeLayout(false);
            this.subMenuMiPerfil.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoAlumno)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel subMenuMiPerfil;
        private System.Windows.Forms.Button btnAsignaturas;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnMiPerfil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox fotoAlumno;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel subMenuDocentes;
        private System.Windows.Forms.Button btnInstitucion;
        private System.Windows.Forms.Button btnMisDocentes;
        private System.Windows.Forms.Button btnDocentes;
        private System.Windows.Forms.Button btnMensajes;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.ToolTip ttInformacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}