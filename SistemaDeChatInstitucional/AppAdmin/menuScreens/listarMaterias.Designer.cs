namespace AppAdmin.menuScreens
{
    partial class listarMaterias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listarMaterias));
            this.dgvListarMaterias = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbMaterias = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clbGrupos = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarMaterias)).BeginInit();
            this.gbMaterias.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListarMaterias
            // 
            this.dgvListarMaterias.AllowUserToAddRows = false;
            this.dgvListarMaterias.AllowUserToDeleteRows = false;
            this.dgvListarMaterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListarMaterias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListarMaterias.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvListarMaterias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListarMaterias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListarMaterias.ColumnHeadersHeight = 25;
            this.dgvListarMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListarMaterias.EnableHeadersVisualStyles = false;
            this.dgvListarMaterias.Location = new System.Drawing.Point(144, 32);
            this.dgvListarMaterias.MultiSelect = false;
            this.dgvListarMaterias.Name = "dgvListarMaterias";
            this.dgvListarMaterias.ReadOnly = true;
            this.dgvListarMaterias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListarMaterias.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvListarMaterias.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListarMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarMaterias.Size = new System.Drawing.Size(250, 294);
            this.dgvListarMaterias.TabIndex = 0;
            this.dgvListarMaterias.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvListarMaterias_DataBindingComplete);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(25, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 34);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // gbMaterias
            // 
            this.gbMaterias.Controls.Add(this.textBox1);
            this.gbMaterias.Controls.Add(this.clbGrupos);
            this.gbMaterias.Controls.Add(this.label2);
            this.gbMaterias.Controls.Add(this.label1);
            this.gbMaterias.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaterias.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbMaterias.Location = new System.Drawing.Point(528, 23);
            this.gbMaterias.Name = "gbMaterias";
            this.gbMaterias.Size = new System.Drawing.Size(336, 303);
            this.gbMaterias.TabIndex = 3;
            this.gbMaterias.TabStop = false;
            this.gbMaterias.Text = "Ingresar nueva materia";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 25);
            this.textBox1.TabIndex = 3;
            // 
            // clbGrupos
            // 
            this.clbGrupos.FormattingEnabled = true;
            this.clbGrupos.Location = new System.Drawing.Point(89, 120);
            this.clbGrupos.Name = "clbGrupos";
            this.clbGrupos.Size = new System.Drawing.Size(222, 164);
            this.clbGrupos.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Grupos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(647, 340);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(112, 32);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // listarMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(920, 384);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.gbMaterias);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvListarMaterias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "listarMaterias";
            this.Text = "listar";
            this.Load += new System.EventHandler(this.listarMaterias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarMaterias)).EndInit();
            this.gbMaterias.ResumeLayout(false);
            this.gbMaterias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListarMaterias;
        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbMaterias;
        private System.Windows.Forms.CheckedListBox clbGrupos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnIngresar;
    }
}