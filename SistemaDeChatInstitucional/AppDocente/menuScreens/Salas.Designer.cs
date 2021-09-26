namespace AppDocente.menuScreens
{
    partial class Salas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Salas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSalas = new System.Windows.Forms.DataGridView();
            this.lblSalas = new System.Windows.Forms.Label();
            this.lblCrear = new System.Windows.Forms.Label();
            this.btnUnirse = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvGrupoMaterias = new System.Windows.Forms.DataGridView();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtAsuntoSala = new System.Windows.Forms.TextBox();
            this.btnHistorial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalas
            // 
            this.dgvSalas.AllowUserToAddRows = false;
            this.dgvSalas.AllowUserToDeleteRows = false;
            this.dgvSalas.AllowUserToResizeColumns = false;
            this.dgvSalas.AllowUserToResizeRows = false;
            this.dgvSalas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSalas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSalas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvSalas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalas.ColumnHeadersHeight = 25;
            this.dgvSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSalas.EnableHeadersVisualStyles = false;
            this.dgvSalas.Location = new System.Drawing.Point(22, 210);
            this.dgvSalas.MultiSelect = false;
            this.dgvSalas.Name = "dgvSalas";
            this.dgvSalas.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalas.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.dgvSalas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalas.Size = new System.Drawing.Size(687, 210);
            this.dgvSalas.TabIndex = 2;
            this.dgvSalas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSalas_CellFormatting);
            this.dgvSalas.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvSalas_ColumnAdded);
            // 
            // lblSalas
            // 
            this.lblSalas.AutoSize = true;
            this.lblSalas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalas.Location = new System.Drawing.Point(47, 189);
            this.lblSalas.Name = "lblSalas";
            this.lblSalas.Size = new System.Drawing.Size(55, 18);
            this.lblSalas.TabIndex = 1;
            this.lblSalas.Text = "Salas:";
            // 
            // lblCrear
            // 
            this.lblCrear.AutoSize = true;
            this.lblCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrear.Location = new System.Drawing.Point(47, 61);
            this.lblCrear.Name = "lblCrear";
            this.lblCrear.Size = new System.Drawing.Size(91, 18);
            this.lblCrear.TabIndex = 2;
            this.lblCrear.Text = "Crear sala:";
            // 
            // btnUnirse
            // 
            this.btnUnirse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            this.btnUnirse.FlatAppearance.BorderSize = 0;
            this.btnUnirse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnirse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnirse.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUnirse.Location = new System.Drawing.Point(223, 469);
            this.btnUnirse.Name = "btnUnirse";
            this.btnUnirse.Size = new System.Drawing.Size(111, 28);
            this.btnUnirse.TabIndex = 5;
            this.btnUnirse.Text = "Unirse ";
            this.btnUnirse.UseVisualStyleBackColor = false;
            this.btnUnirse.Click += new System.EventHandler(this.btnUnirse_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Yellow;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(22, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 23);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Atras";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvGrupoMaterias
            // 
            this.dgvGrupoMaterias.AllowUserToAddRows = false;
            this.dgvGrupoMaterias.AllowUserToDeleteRows = false;
            this.dgvGrupoMaterias.AllowUserToResizeColumns = false;
            this.dgvGrupoMaterias.AllowUserToResizeRows = false;
            this.dgvGrupoMaterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrupoMaterias.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGrupoMaterias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGrupoMaterias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvGrupoMaterias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrupoMaterias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGrupoMaterias.ColumnHeadersHeight = 25;
            this.dgvGrupoMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrupoMaterias.EnableHeadersVisualStyles = false;
            this.dgvGrupoMaterias.Location = new System.Drawing.Point(402, 62);
            this.dgvGrupoMaterias.MultiSelect = false;
            this.dgvGrupoMaterias.Name = "dgvGrupoMaterias";
            this.dgvGrupoMaterias.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrupoMaterias.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGrupoMaterias.RowHeadersVisible = false;
            this.dgvGrupoMaterias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvGrupoMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupoMaterias.Size = new System.Drawing.Size(153, 104);
            this.dgvGrupoMaterias.TabIndex = 2;
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            this.btnCrear.Enabled = false;
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrear.Location = new System.Drawing.Point(561, 62);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(83, 29);
            this.btnCrear.TabIndex = 23;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtAsuntoSala
            // 
            this.txtAsuntoSala.Location = new System.Drawing.Point(151, 62);
            this.txtAsuntoSala.MaxLength = 1000;
            this.txtAsuntoSala.Multiline = true;
            this.txtAsuntoSala.Name = "txtAsuntoSala";
            this.txtAsuntoSala.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAsuntoSala.Size = new System.Drawing.Size(245, 104);
            this.txtAsuntoSala.TabIndex = 22;
            this.txtAsuntoSala.TextChanged += new System.EventHandler(this.txtAsuntoSala_TextChanged);
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHistorial.Location = new System.Drawing.Point(402, 469);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(111, 28);
            this.btnHistorial.TabIndex = 25;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // Salas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(733, 549);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.dgvGrupoMaterias);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtAsuntoSala);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUnirse);
            this.Controls.Add(this.lblCrear);
            this.Controls.Add(this.lblSalas);
            this.Controls.Add(this.dgvSalas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Salas";
            this.Text = "Salas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Salas_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Salas_FormClosed);
            this.Load += new System.EventHandler(this.Salas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoMaterias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalas;
        private System.Windows.Forms.Label lblSalas;
        private System.Windows.Forms.Label lblCrear;
        private System.Windows.Forms.Button btnUnirse;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvGrupoMaterias;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtAsuntoSala;
        private System.Windows.Forms.Button btnHistorial;
    }
}