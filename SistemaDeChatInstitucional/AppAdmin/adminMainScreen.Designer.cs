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
            this.btnExit = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnAdministradores = new System.Windows.Forms.Button();
            this.btnDocentes = new System.Windows.Forms.Button();
            this.btnAlumno = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.subMenuAdmin = new System.Windows.Forms.Panel();
            this.btnRequerimientoAdmin = new System.Windows.Forms.Button();
            this.btnListarAdmin = new System.Windows.Forms.Button();
            this.btnEliminarAdmin = new System.Windows.Forms.Button();
            this.btnModificarAdmin = new System.Windows.Forms.Button();
            this.btnIngresarAdmin = new System.Windows.Forms.Button();
            this.subMenuDocentes = new System.Windows.Forms.Panel();
            this.btnRequerimientoDocentes = new System.Windows.Forms.Button();
            this.btnListarDocentes = new System.Windows.Forms.Button();
            this.btnEliminarDocente = new System.Windows.Forms.Button();
            this.btnModificarDocente = new System.Windows.Forms.Button();
            this.btnIngresarDocente = new System.Windows.Forms.Button();
            this.subMenuAlumnos = new System.Windows.Forms.Panel();
            this.btnRequerimientoAlumnos = new System.Windows.Forms.Button();
            this.btnListarAlumnos = new System.Windows.Forms.Button();
            this.btnEliminarAlumnos = new System.Windows.Forms.Button();
            this.btnModificarAlumnos = new System.Windows.Forms.Button();
            this.btnIngresarAlumno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitulo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.subMenuAdmin.SuspendLayout();
            this.subMenuDocentes.SuspendLayout();
            this.subMenuAlumnos.SuspendLayout();
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
            this.panelTitulo.Size = new System.Drawing.Size(855, 31);
            this.panelTitulo.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(821, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(34, 27);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnAdministradores);
            this.panelMenu.Controls.Add(this.btnDocentes);
            this.panelMenu.Controls.Add(this.btnAlumno);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 31);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(855, 35);
            this.panelMenu.TabIndex = 1;
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
            this.btnAdministradores.Location = new System.Drawing.Point(576, 0);
            this.btnAdministradores.Name = "btnAdministradores";
            this.btnAdministradores.Size = new System.Drawing.Size(279, 35);
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
            this.btnDocentes.Location = new System.Drawing.Point(289, 0);
            this.btnDocentes.Name = "btnDocentes";
            this.btnDocentes.Size = new System.Drawing.Size(287, 35);
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
            this.btnAlumno.Size = new System.Drawing.Size(289, 35);
            this.btnAlumno.TabIndex = 0;
            this.btnAlumno.Text = "ALUMNOS";
            this.btnAlumno.UseVisualStyleBackColor = false;
            this.btnAlumno.Click += new System.EventHandler(this.btnAlumno_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelContenedor.Controls.Add(this.subMenuAdmin);
            this.panelContenedor.Controls.Add(this.subMenuDocentes);
            this.panelContenedor.Controls.Add(this.subMenuAlumnos);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 66);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(855, 384);
            this.panelContenedor.TabIndex = 5;
            // 
            // subMenuAdmin
            // 
            this.subMenuAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.subMenuAdmin.Controls.Add(this.btnRequerimientoAdmin);
            this.subMenuAdmin.Controls.Add(this.btnListarAdmin);
            this.subMenuAdmin.Controls.Add(this.btnEliminarAdmin);
            this.subMenuAdmin.Controls.Add(this.btnModificarAdmin);
            this.subMenuAdmin.Controls.Add(this.btnIngresarAdmin);
            this.subMenuAdmin.Location = new System.Drawing.Point(576, 0);
            this.subMenuAdmin.Name = "subMenuAdmin";
            this.subMenuAdmin.Size = new System.Drawing.Size(279, 178);
            this.subMenuAdmin.TabIndex = 7;
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
            this.btnRequerimientoAdmin.Location = new System.Drawing.Point(0, 140);
            this.btnRequerimientoAdmin.Name = "btnRequerimientoAdmin";
            this.btnRequerimientoAdmin.Size = new System.Drawing.Size(279, 35);
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
            this.btnListarAdmin.Location = new System.Drawing.Point(0, 105);
            this.btnListarAdmin.Name = "btnListarAdmin";
            this.btnListarAdmin.Size = new System.Drawing.Size(279, 35);
            this.btnListarAdmin.TabIndex = 8;
            this.btnListarAdmin.Text = "Listar todos";
            this.btnListarAdmin.UseVisualStyleBackColor = true;
            // 
            // btnEliminarAdmin
            // 
            this.btnEliminarAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminarAdmin.FlatAppearance.BorderSize = 0;
            this.btnEliminarAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnEliminarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarAdmin.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarAdmin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnEliminarAdmin.Location = new System.Drawing.Point(0, 70);
            this.btnEliminarAdmin.Name = "btnEliminarAdmin";
            this.btnEliminarAdmin.Size = new System.Drawing.Size(279, 35);
            this.btnEliminarAdmin.TabIndex = 7;
            this.btnEliminarAdmin.Text = "Eliminar";
            this.btnEliminarAdmin.UseVisualStyleBackColor = true;
            // 
            // btnModificarAdmin
            // 
            this.btnModificarAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnModificarAdmin.FlatAppearance.BorderSize = 0;
            this.btnModificarAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnModificarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarAdmin.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarAdmin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnModificarAdmin.Location = new System.Drawing.Point(0, 35);
            this.btnModificarAdmin.Name = "btnModificarAdmin";
            this.btnModificarAdmin.Size = new System.Drawing.Size(279, 35);
            this.btnModificarAdmin.TabIndex = 6;
            this.btnModificarAdmin.Text = "Modificar";
            this.btnModificarAdmin.UseVisualStyleBackColor = true;
            // 
            // btnIngresarAdmin
            // 
            this.btnIngresarAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresarAdmin.FlatAppearance.BorderSize = 0;
            this.btnIngresarAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnIngresarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarAdmin.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarAdmin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnIngresarAdmin.Location = new System.Drawing.Point(0, 0);
            this.btnIngresarAdmin.Name = "btnIngresarAdmin";
            this.btnIngresarAdmin.Size = new System.Drawing.Size(279, 35);
            this.btnIngresarAdmin.TabIndex = 5;
            this.btnIngresarAdmin.Text = "Ingresar";
            this.btnIngresarAdmin.UseVisualStyleBackColor = true;
            // 
            // subMenuDocentes
            // 
            this.subMenuDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.subMenuDocentes.Controls.Add(this.btnRequerimientoDocentes);
            this.subMenuDocentes.Controls.Add(this.btnListarDocentes);
            this.subMenuDocentes.Controls.Add(this.btnEliminarDocente);
            this.subMenuDocentes.Controls.Add(this.btnModificarDocente);
            this.subMenuDocentes.Controls.Add(this.btnIngresarDocente);
            this.subMenuDocentes.Location = new System.Drawing.Point(289, 0);
            this.subMenuDocentes.Name = "subMenuDocentes";
            this.subMenuDocentes.Size = new System.Drawing.Size(287, 178);
            this.subMenuDocentes.TabIndex = 6;
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
            this.btnRequerimientoDocentes.Location = new System.Drawing.Point(0, 140);
            this.btnRequerimientoDocentes.Name = "btnRequerimientoDocentes";
            this.btnRequerimientoDocentes.Size = new System.Drawing.Size(287, 35);
            this.btnRequerimientoDocentes.TabIndex = 9;
            this.btnRequerimientoDocentes.Text = "Requerimientos de registro";
            this.btnRequerimientoDocentes.UseVisualStyleBackColor = true;
            // 
            // btnListarDocentes
            // 
            this.btnListarDocentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListarDocentes.FlatAppearance.BorderSize = 0;
            this.btnListarDocentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnListarDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarDocentes.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarDocentes.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnListarDocentes.Location = new System.Drawing.Point(0, 105);
            this.btnListarDocentes.Name = "btnListarDocentes";
            this.btnListarDocentes.Size = new System.Drawing.Size(287, 35);
            this.btnListarDocentes.TabIndex = 8;
            this.btnListarDocentes.Text = "Listar todos";
            this.btnListarDocentes.UseVisualStyleBackColor = true;
            this.btnListarDocentes.Click += new System.EventHandler(this.btnListarDocentes_Click);
            // 
            // btnEliminarDocente
            // 
            this.btnEliminarDocente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminarDocente.FlatAppearance.BorderSize = 0;
            this.btnEliminarDocente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnEliminarDocente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDocente.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDocente.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnEliminarDocente.Location = new System.Drawing.Point(0, 70);
            this.btnEliminarDocente.Name = "btnEliminarDocente";
            this.btnEliminarDocente.Size = new System.Drawing.Size(287, 35);
            this.btnEliminarDocente.TabIndex = 7;
            this.btnEliminarDocente.Text = "Eliminar";
            this.btnEliminarDocente.UseVisualStyleBackColor = true;
            // 
            // btnModificarDocente
            // 
            this.btnModificarDocente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnModificarDocente.FlatAppearance.BorderSize = 0;
            this.btnModificarDocente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnModificarDocente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarDocente.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarDocente.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnModificarDocente.Location = new System.Drawing.Point(0, 35);
            this.btnModificarDocente.Name = "btnModificarDocente";
            this.btnModificarDocente.Size = new System.Drawing.Size(287, 35);
            this.btnModificarDocente.TabIndex = 6;
            this.btnModificarDocente.Text = "Modificar";
            this.btnModificarDocente.UseVisualStyleBackColor = true;
            // 
            // btnIngresarDocente
            // 
            this.btnIngresarDocente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresarDocente.FlatAppearance.BorderSize = 0;
            this.btnIngresarDocente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnIngresarDocente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarDocente.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarDocente.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnIngresarDocente.Location = new System.Drawing.Point(0, 0);
            this.btnIngresarDocente.Name = "btnIngresarDocente";
            this.btnIngresarDocente.Size = new System.Drawing.Size(287, 35);
            this.btnIngresarDocente.TabIndex = 5;
            this.btnIngresarDocente.Text = "Ingresar";
            this.btnIngresarDocente.UseVisualStyleBackColor = true;
            // 
            // subMenuAlumnos
            // 
            this.subMenuAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.subMenuAlumnos.Controls.Add(this.btnRequerimientoAlumnos);
            this.subMenuAlumnos.Controls.Add(this.btnListarAlumnos);
            this.subMenuAlumnos.Controls.Add(this.btnEliminarAlumnos);
            this.subMenuAlumnos.Controls.Add(this.btnModificarAlumnos);
            this.subMenuAlumnos.Controls.Add(this.btnIngresarAlumno);
            this.subMenuAlumnos.Location = new System.Drawing.Point(0, 0);
            this.subMenuAlumnos.Name = "subMenuAlumnos";
            this.subMenuAlumnos.Size = new System.Drawing.Size(289, 178);
            this.subMenuAlumnos.TabIndex = 5;
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
            this.btnRequerimientoAlumnos.Location = new System.Drawing.Point(0, 140);
            this.btnRequerimientoAlumnos.Name = "btnRequerimientoAlumnos";
            this.btnRequerimientoAlumnos.Size = new System.Drawing.Size(289, 35);
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
            this.btnListarAlumnos.Location = new System.Drawing.Point(0, 105);
            this.btnListarAlumnos.Name = "btnListarAlumnos";
            this.btnListarAlumnos.Size = new System.Drawing.Size(289, 35);
            this.btnListarAlumnos.TabIndex = 3;
            this.btnListarAlumnos.Text = "Listar todos";
            this.btnListarAlumnos.UseVisualStyleBackColor = true;
            this.btnListarAlumnos.Click += new System.EventHandler(this.btnListarAlumnos_Click);
            // 
            // btnEliminarAlumnos
            // 
            this.btnEliminarAlumnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminarAlumnos.FlatAppearance.BorderSize = 0;
            this.btnEliminarAlumnos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnEliminarAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarAlumnos.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarAlumnos.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnEliminarAlumnos.Location = new System.Drawing.Point(0, 70);
            this.btnEliminarAlumnos.Name = "btnEliminarAlumnos";
            this.btnEliminarAlumnos.Size = new System.Drawing.Size(289, 35);
            this.btnEliminarAlumnos.TabIndex = 2;
            this.btnEliminarAlumnos.Text = "Eliminar";
            this.btnEliminarAlumnos.UseVisualStyleBackColor = true;
            // 
            // btnModificarAlumnos
            // 
            this.btnModificarAlumnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnModificarAlumnos.FlatAppearance.BorderSize = 0;
            this.btnModificarAlumnos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnModificarAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarAlumnos.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarAlumnos.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnModificarAlumnos.Location = new System.Drawing.Point(0, 35);
            this.btnModificarAlumnos.Name = "btnModificarAlumnos";
            this.btnModificarAlumnos.Size = new System.Drawing.Size(289, 35);
            this.btnModificarAlumnos.TabIndex = 1;
            this.btnModificarAlumnos.Text = "Modificar";
            this.btnModificarAlumnos.UseVisualStyleBackColor = true;
            // 
            // btnIngresarAlumno
            // 
            this.btnIngresarAlumno.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresarAlumno.FlatAppearance.BorderSize = 0;
            this.btnIngresarAlumno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(3)))), ((int)(((byte)(28)))));
            this.btnIngresarAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarAlumno.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarAlumno.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnIngresarAlumno.Location = new System.Drawing.Point(0, 0);
            this.btnIngresarAlumno.Name = "btnIngresarAlumno";
            this.btnIngresarAlumno.Size = new System.Drawing.Size(289, 35);
            this.btnIngresarAlumno.TabIndex = 0;
            this.btnIngresarAlumno.Text = "Ingresar";
            this.btnIngresarAlumno.UseVisualStyleBackColor = true;
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
            // adminMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 450);
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
            this.subMenuAdmin.ResumeLayout(false);
            this.subMenuDocentes.ResumeLayout(false);
            this.subMenuAlumnos.ResumeLayout(false);
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
        private System.Windows.Forms.Panel subMenuAdmin;
        private System.Windows.Forms.Button btnRequerimientoAdmin;
        private System.Windows.Forms.Button btnListarAdmin;
        private System.Windows.Forms.Button btnEliminarAdmin;
        private System.Windows.Forms.Button btnModificarAdmin;
        private System.Windows.Forms.Button btnIngresarAdmin;
        private System.Windows.Forms.Panel subMenuDocentes;
        private System.Windows.Forms.Button btnRequerimientoDocentes;
        private System.Windows.Forms.Button btnListarDocentes;
        private System.Windows.Forms.Button btnEliminarDocente;
        private System.Windows.Forms.Button btnModificarDocente;
        private System.Windows.Forms.Button btnIngresarDocente;
        private System.Windows.Forms.Panel subMenuAlumnos;
        private System.Windows.Forms.Button btnRequerimientoAlumnos;
        private System.Windows.Forms.Button btnListarAlumnos;
        private System.Windows.Forms.Button btnEliminarAlumnos;
        private System.Windows.Forms.Button btnModificarAlumnos;
        private System.Windows.Forms.Button btnIngresarAlumno;
        private System.Windows.Forms.Label label1;
    }
}