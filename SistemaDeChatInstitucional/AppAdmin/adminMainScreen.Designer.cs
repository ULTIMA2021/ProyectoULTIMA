namespace AppAdmin
{
    partial class adminMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminMainScreen));
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCursos = new System.Windows.Forms.Button();
            this.btnAdministradores = new System.Windows.Forms.Button();
            this.btnDocentes = new System.Windows.Forms.Button();
            this.btnAlumno = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.subMenuCursos = new System.Windows.Forms.Panel();
            this.btnOrientaciones = new System.Windows.Forms.Button();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.btnGrupos = new System.Windows.Forms.Button();
            this.subMenuAdmin = new System.Windows.Forms.Panel();
            this.btnRequerimientoAdmin = new System.Windows.Forms.Button();
            this.btnListarAdmin = new System.Windows.Forms.Button();
            this.subMenuDocentes = new System.Windows.Forms.Panel();
            this.btnRequerimientoDocentes = new System.Windows.Forms.Button();
            this.btnListarDocentes = new System.Windows.Forms.Button();
            this.subMenuAlumnos = new System.Windows.Forms.Panel();
            this.btnRequerimientoAlumnos = new System.Windows.Forms.Button();
            this.btnListarAlumnos = new System.Windows.Forms.Button();
            this.pbImagenInicio = new System.Windows.Forms.PictureBox();
            this.panelTitulo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.subMenuCursos.SuspendLayout();
            this.subMenuAdmin.SuspendLayout();
            this.subMenuDocentes.SuspendLayout();
            this.subMenuAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.panelTitulo.Controls.Add(this.label1);
            this.panelTitulo.Controls.Add(this.btnExit);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(920, 31);
            this.panelTitulo.TabIndex = 0;
            this.panelTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitulo_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "App Administrador";
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(886, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(34, 27);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnCursos);
            this.panelMenu.Controls.Add(this.btnAdministradores);
            this.panelMenu.Controls.Add(this.btnDocentes);
            this.panelMenu.Controls.Add(this.btnAlumno);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 31);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(920, 35);
            this.panelMenu.TabIndex = 1;
            // 
            // btnCursos
            // 
            this.btnCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(15)))), ((int)(((byte)(54)))));
            this.btnCursos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCursos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCursos.FlatAppearance.BorderSize = 0;
            this.btnCursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCursos.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCursos.ForeColor = System.Drawing.Color.Gray;
            this.btnCursos.Location = new System.Drawing.Point(690, 0);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(230, 35);
            this.btnCursos.TabIndex = 3;
            this.btnCursos.Text = "CURSOS";
            this.btnCursos.UseVisualStyleBackColor = false;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // btnAdministradores
            // 
            this.btnAdministradores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(15)))), ((int)(((byte)(54)))));
            this.btnAdministradores.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdministradores.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAdministradores.FlatAppearance.BorderSize = 0;
            this.btnAdministradores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministradores.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministradores.ForeColor = System.Drawing.Color.Gray;
            this.btnAdministradores.Location = new System.Drawing.Point(460, 0);
            this.btnAdministradores.Name = "btnAdministradores";
            this.btnAdministradores.Size = new System.Drawing.Size(230, 35);
            this.btnAdministradores.TabIndex = 2;
            this.btnAdministradores.Text = "ADMINISTRADORES";
            this.btnAdministradores.UseVisualStyleBackColor = false;
            this.btnAdministradores.Click += new System.EventHandler(this.btnAdministradores_Click);
            // 
            // btnDocentes
            // 
            this.btnDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(15)))), ((int)(((byte)(54)))));
            this.btnDocentes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDocentes.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDocentes.FlatAppearance.BorderSize = 0;
            this.btnDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocentes.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocentes.ForeColor = System.Drawing.Color.Gray;
            this.btnDocentes.Location = new System.Drawing.Point(230, 0);
            this.btnDocentes.Name = "btnDocentes";
            this.btnDocentes.Size = new System.Drawing.Size(230, 35);
            this.btnDocentes.TabIndex = 1;
            this.btnDocentes.Text = "DOCENTES";
            this.btnDocentes.UseVisualStyleBackColor = false;
            this.btnDocentes.Click += new System.EventHandler(this.btnDocente_Click);
            // 
            // btnAlumno
            // 
            this.btnAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(15)))), ((int)(((byte)(54)))));
            this.btnAlumno.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAlumno.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAlumno.FlatAppearance.BorderSize = 0;
            this.btnAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlumno.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumno.ForeColor = System.Drawing.Color.Gray;
            this.btnAlumno.Location = new System.Drawing.Point(0, 0);
            this.btnAlumno.Name = "btnAlumno";
            this.btnAlumno.Size = new System.Drawing.Size(230, 35);
            this.btnAlumno.TabIndex = 0;
            this.btnAlumno.Text = "ALUMNOS";
            this.btnAlumno.UseVisualStyleBackColor = false;
            this.btnAlumno.Click += new System.EventHandler(this.btnAlumno_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelContenedor.Controls.Add(this.subMenuCursos);
            this.panelContenedor.Controls.Add(this.subMenuAdmin);
            this.panelContenedor.Controls.Add(this.subMenuDocentes);
            this.panelContenedor.Controls.Add(this.subMenuAlumnos);
            this.panelContenedor.Controls.Add(this.pbImagenInicio);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 66);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(920, 384);
            this.panelContenedor.TabIndex = 5;
            // 
            // subMenuCursos
            // 
            this.subMenuCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.subMenuCursos.Controls.Add(this.btnOrientaciones);
            this.subMenuCursos.Controls.Add(this.btnMaterias);
            this.subMenuCursos.Controls.Add(this.btnGrupos);
            this.subMenuCursos.Location = new System.Drawing.Point(690, 0);
            this.subMenuCursos.Name = "subMenuCursos";
            this.subMenuCursos.Size = new System.Drawing.Size(230, 113);
            this.subMenuCursos.TabIndex = 12;
            this.subMenuCursos.Visible = false;
            // 
            // btnOrientaciones
            // 
            this.btnOrientaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrientaciones.FlatAppearance.BorderSize = 0;
            this.btnOrientaciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnOrientaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrientaciones.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrientaciones.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnOrientaciones.Location = new System.Drawing.Point(0, 70);
            this.btnOrientaciones.Name = "btnOrientaciones";
            this.btnOrientaciones.Size = new System.Drawing.Size(230, 35);
            this.btnOrientaciones.TabIndex = 8;
            this.btnOrientaciones.Text = "Orientaciones";
            this.btnOrientaciones.UseVisualStyleBackColor = true;
            this.btnOrientaciones.Click += new System.EventHandler(this.btnOrientaciones_Click);
            // 
            // btnMaterias
            // 
            this.btnMaterias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMaterias.FlatAppearance.BorderSize = 0;
            this.btnMaterias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterias.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterias.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnMaterias.Location = new System.Drawing.Point(0, 35);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(230, 35);
            this.btnMaterias.TabIndex = 7;
            this.btnMaterias.Text = "Materias";
            this.btnMaterias.UseVisualStyleBackColor = true;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            // 
            // btnGrupos
            // 
            this.btnGrupos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrupos.FlatAppearance.BorderSize = 0;
            this.btnGrupos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrupos.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrupos.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnGrupos.Location = new System.Drawing.Point(0, 0);
            this.btnGrupos.Name = "btnGrupos";
            this.btnGrupos.Size = new System.Drawing.Size(230, 35);
            this.btnGrupos.TabIndex = 6;
            this.btnGrupos.Text = "Grupos";
            this.btnGrupos.UseVisualStyleBackColor = true;
            this.btnGrupos.Click += new System.EventHandler(this.btnGrupos_Click);
            // 
            // subMenuAdmin
            // 
            this.subMenuAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.subMenuAdmin.Controls.Add(this.btnRequerimientoAdmin);
            this.subMenuAdmin.Controls.Add(this.btnListarAdmin);
            this.subMenuAdmin.Location = new System.Drawing.Point(460, 0);
            this.subMenuAdmin.Name = "subMenuAdmin";
            this.subMenuAdmin.Size = new System.Drawing.Size(230, 80);
            this.subMenuAdmin.TabIndex = 11;
            this.subMenuAdmin.Visible = false;
            // 
            // btnRequerimientoAdmin
            // 
            this.btnRequerimientoAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRequerimientoAdmin.FlatAppearance.BorderSize = 0;
            this.btnRequerimientoAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnRequerimientoAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequerimientoAdmin.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequerimientoAdmin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRequerimientoAdmin.Location = new System.Drawing.Point(0, 35);
            this.btnRequerimientoAdmin.Name = "btnRequerimientoAdmin";
            this.btnRequerimientoAdmin.Size = new System.Drawing.Size(230, 35);
            this.btnRequerimientoAdmin.TabIndex = 9;
            this.btnRequerimientoAdmin.Text = "Requerimientos de registro";
            this.btnRequerimientoAdmin.UseVisualStyleBackColor = true;
            // 
            // btnListarAdmin
            // 
            this.btnListarAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListarAdmin.FlatAppearance.BorderSize = 0;
            this.btnListarAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnListarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarAdmin.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarAdmin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnListarAdmin.Location = new System.Drawing.Point(0, 0);
            this.btnListarAdmin.Name = "btnListarAdmin";
            this.btnListarAdmin.Size = new System.Drawing.Size(230, 35);
            this.btnListarAdmin.TabIndex = 8;
            this.btnListarAdmin.Text = "Listar todos";
            this.btnListarAdmin.UseVisualStyleBackColor = true;
            // 
            // subMenuDocentes
            // 
            this.subMenuDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.subMenuDocentes.Controls.Add(this.btnRequerimientoDocentes);
            this.subMenuDocentes.Controls.Add(this.btnListarDocentes);
            this.subMenuDocentes.Location = new System.Drawing.Point(230, 0);
            this.subMenuDocentes.Name = "subMenuDocentes";
            this.subMenuDocentes.Size = new System.Drawing.Size(230, 80);
            this.subMenuDocentes.TabIndex = 10;
            this.subMenuDocentes.Visible = false;
            // 
            // btnRequerimientoDocentes
            // 
            this.btnRequerimientoDocentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRequerimientoDocentes.FlatAppearance.BorderSize = 0;
            this.btnRequerimientoDocentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnRequerimientoDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequerimientoDocentes.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequerimientoDocentes.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRequerimientoDocentes.Location = new System.Drawing.Point(0, 35);
            this.btnRequerimientoDocentes.Name = "btnRequerimientoDocentes";
            this.btnRequerimientoDocentes.Size = new System.Drawing.Size(230, 35);
            this.btnRequerimientoDocentes.TabIndex = 9;
            this.btnRequerimientoDocentes.Text = "Listar registro de sesiones";
            this.btnRequerimientoDocentes.UseVisualStyleBackColor = true;
            this.btnRequerimientoDocentes.Click += new System.EventHandler(this.btnRequerimientoDocentes_Click);
            // 
            // btnListarDocentes
            // 
            this.btnListarDocentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListarDocentes.FlatAppearance.BorderSize = 0;
            this.btnListarDocentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnListarDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarDocentes.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarDocentes.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnListarDocentes.Location = new System.Drawing.Point(0, 0);
            this.btnListarDocentes.Name = "btnListarDocentes";
            this.btnListarDocentes.Size = new System.Drawing.Size(230, 35);
            this.btnListarDocentes.TabIndex = 8;
            this.btnListarDocentes.Text = "Listar todos";
            this.btnListarDocentes.UseVisualStyleBackColor = true;
            this.btnListarDocentes.Click += new System.EventHandler(this.btnListarDocentes_Click);
            // 
            // subMenuAlumnos
            // 
            this.subMenuAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.subMenuAlumnos.Controls.Add(this.btnRequerimientoAlumnos);
            this.subMenuAlumnos.Controls.Add(this.btnListarAlumnos);
            this.subMenuAlumnos.Location = new System.Drawing.Point(0, 0);
            this.subMenuAlumnos.Name = "subMenuAlumnos";
            this.subMenuAlumnos.Size = new System.Drawing.Size(230, 80);
            this.subMenuAlumnos.TabIndex = 9;
            this.subMenuAlumnos.Visible = false;
            // 
            // btnRequerimientoAlumnos
            // 
            this.btnRequerimientoAlumnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRequerimientoAlumnos.FlatAppearance.BorderSize = 0;
            this.btnRequerimientoAlumnos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnRequerimientoAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequerimientoAlumnos.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequerimientoAlumnos.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRequerimientoAlumnos.Location = new System.Drawing.Point(0, 35);
            this.btnRequerimientoAlumnos.Name = "btnRequerimientoAlumnos";
            this.btnRequerimientoAlumnos.Size = new System.Drawing.Size(230, 35);
            this.btnRequerimientoAlumnos.TabIndex = 4;
            this.btnRequerimientoAlumnos.Text = "Requerimientos de registro";
            this.btnRequerimientoAlumnos.UseVisualStyleBackColor = true;
            this.btnRequerimientoAlumnos.Click += new System.EventHandler(this.btnRequerimientoAlumnos_Click);
            // 
            // btnListarAlumnos
            // 
            this.btnListarAlumnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListarAlumnos.FlatAppearance.BorderSize = 0;
            this.btnListarAlumnos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnListarAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarAlumnos.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarAlumnos.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnListarAlumnos.Location = new System.Drawing.Point(0, 0);
            this.btnListarAlumnos.Name = "btnListarAlumnos";
            this.btnListarAlumnos.Size = new System.Drawing.Size(230, 35);
            this.btnListarAlumnos.TabIndex = 3;
            this.btnListarAlumnos.Text = "Listar todos";
            this.btnListarAlumnos.UseVisualStyleBackColor = true;
            this.btnListarAlumnos.Click += new System.EventHandler(this.btnListarAlumnos_Click_1);
            // 
            // pbImagenInicio
            // 
            this.pbImagenInicio.Image = ((System.Drawing.Image)(resources.GetObject("pbImagenInicio.Image")));
            this.pbImagenInicio.Location = new System.Drawing.Point(326, 70);
            this.pbImagenInicio.Name = "pbImagenInicio";
            this.pbImagenInicio.Size = new System.Drawing.Size(267, 274);
            this.pbImagenInicio.TabIndex = 8;
            this.pbImagenInicio.TabStop = false;
            // 
            // adminMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 450);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "adminMainScreen";
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelContenedor.ResumeLayout(false);
            this.subMenuCursos.ResumeLayout(false);
            this.subMenuAdmin.ResumeLayout(false);
            this.subMenuDocentes.ResumeLayout(false);
            this.subMenuAlumnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnAlumno;
        private System.Windows.Forms.Button btnAdministradores;
        private System.Windows.Forms.Button btnDocentes;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel subMenuAdmin;
        private System.Windows.Forms.Button btnRequerimientoAdmin;
        private System.Windows.Forms.Button btnListarAdmin;
        private System.Windows.Forms.Panel subMenuDocentes;
        private System.Windows.Forms.Button btnRequerimientoDocentes;
        private System.Windows.Forms.Button btnListarDocentes;
        private System.Windows.Forms.Panel subMenuAlumnos;
        private System.Windows.Forms.Button btnRequerimientoAlumnos;
        private System.Windows.Forms.Button btnListarAlumnos;
        private System.Windows.Forms.PictureBox pbImagenInicio;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Panel subMenuCursos;
        private System.Windows.Forms.Button btnOrientaciones;
        private System.Windows.Forms.Button btnMaterias;
        private System.Windows.Forms.Button btnGrupos;
    }
}