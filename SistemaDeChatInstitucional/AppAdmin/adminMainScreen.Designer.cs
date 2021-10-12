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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.subMenuCursos = new System.Windows.Forms.Panel();
            this.btnOrientaciones = new System.Windows.Forms.Button();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.btnGrupos = new System.Windows.Forms.Button();
            this.subMenuAlumnos = new System.Windows.Forms.Panel();
            this.btnRegi = new System.Windows.Forms.Button();
            this.btnListarAlumnos = new System.Windows.Forms.Button();
            this.pbImagenInicio = new System.Windows.Forms.PictureBox();
            this.btnNuevosAlumnos = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCursos = new System.Windows.Forms.Button();
            this.panelTitulo.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.subMenuCursos.SuspendLayout();
            this.subMenuAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenInicio)).BeginInit();
            this.panelMenu.SuspendLayout();
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
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelContenedor.Controls.Add(this.subMenuCursos);
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
            this.subMenuCursos.Location = new System.Drawing.Point(460, 0);
            this.subMenuCursos.Name = "subMenuCursos";
            this.subMenuCursos.Size = new System.Drawing.Size(460, 113);
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
            this.btnOrientaciones.Size = new System.Drawing.Size(460, 35);
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
            this.btnMaterias.Size = new System.Drawing.Size(460, 35);
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
            this.btnGrupos.Size = new System.Drawing.Size(460, 35);
            this.btnGrupos.TabIndex = 6;
            this.btnGrupos.Text = "Grupos";
            this.btnGrupos.UseVisualStyleBackColor = true;
            this.btnGrupos.Click += new System.EventHandler(this.btnGrupos_Click);
            // 
            // subMenuAlumnos
            // 
            this.subMenuAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.subMenuAlumnos.Controls.Add(this.btnNuevosAlumnos);
            this.subMenuAlumnos.Controls.Add(this.btnRegi);
            this.subMenuAlumnos.Controls.Add(this.btnListarAlumnos);
            this.subMenuAlumnos.Location = new System.Drawing.Point(0, 0);
            this.subMenuAlumnos.Name = "subMenuAlumnos";
            this.subMenuAlumnos.Size = new System.Drawing.Size(460, 113);
            this.subMenuAlumnos.TabIndex = 9;
            this.subMenuAlumnos.Visible = false;
            // 
            // btnRegi
            // 
            this.btnRegi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegi.FlatAppearance.BorderSize = 0;
            this.btnRegi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnRegi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegi.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegi.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRegi.Location = new System.Drawing.Point(0, 35);
            this.btnRegi.Name = "btnRegi";
            this.btnRegi.Size = new System.Drawing.Size(460, 35);
            this.btnRegi.TabIndex = 4;
            this.btnRegi.Text = "Registrar nuevos usuarios";
            this.btnRegi.UseVisualStyleBackColor = true;
            this.btnRegi.Click += new System.EventHandler(this.btnRequerimientoAlumnos_Click);
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
            this.btnListarAlumnos.Size = new System.Drawing.Size(460, 35);
            this.btnListarAlumnos.TabIndex = 3;
            this.btnListarAlumnos.Text = "Consultar informacion de usuarios";
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
            // btnNuevosAlumnos
            // 
            this.btnNuevosAlumnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevosAlumnos.FlatAppearance.BorderSize = 0;
            this.btnNuevosAlumnos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnNuevosAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevosAlumnos.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevosAlumnos.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnNuevosAlumnos.Location = new System.Drawing.Point(0, 70);
            this.btnNuevosAlumnos.Name = "btnNuevosAlumnos";
            this.btnNuevosAlumnos.Size = new System.Drawing.Size(460, 35);
            this.btnNuevosAlumnos.TabIndex = 5;
            this.btnNuevosAlumnos.Text = "Verificar ticket de alumno";
            this.btnNuevosAlumnos.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(15)))), ((int)(((byte)(54)))));
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUsuarios.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.Gray;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 0);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(460, 35);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnCursos);
            this.panelMenu.Controls.Add(this.btnUsuarios);
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
            this.btnCursos.Location = new System.Drawing.Point(460, 0);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(460, 35);
            this.btnCursos.TabIndex = 3;
            this.btnCursos.Text = "CURSOS";
            this.btnCursos.UseVisualStyleBackColor = false;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
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
            this.panelContenedor.ResumeLayout(false);
            this.subMenuCursos.ResumeLayout(false);
            this.subMenuAlumnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenInicio)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel subMenuAlumnos;
        private System.Windows.Forms.Button btnRegi;
        private System.Windows.Forms.Button btnListarAlumnos;
        private System.Windows.Forms.PictureBox pbImagenInicio;
        private System.Windows.Forms.Panel subMenuCursos;
        private System.Windows.Forms.Button btnOrientaciones;
        private System.Windows.Forms.Button btnMaterias;
        private System.Windows.Forms.Button btnGrupos;
        private System.Windows.Forms.Button btnNuevosAlumnos;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCursos;
    }
}