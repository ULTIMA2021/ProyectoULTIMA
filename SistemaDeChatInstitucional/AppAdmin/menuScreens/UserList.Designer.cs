namespace AppAdmin.menuScreens
{
    partial class UserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDatagridViews = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSalas = new System.Windows.Forms.Label();
            this.lblConsultas = new System.Windows.Forms.Label();
            this.dgvSalas = new System.Windows.Forms.DataGridView();
            this.dgvListarConsultasPrivs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDatagridViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarConsultasPrivs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(24, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 34);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(24, 52);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(15, 3, 15, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(872, 281);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panelDatagridViews
            // 
            this.panelDatagridViews.Controls.Add(this.label3);
            this.panelDatagridViews.Controls.Add(this.textBox2);
            this.panelDatagridViews.Controls.Add(this.label2);
            this.panelDatagridViews.Controls.Add(this.textBox1);
            this.panelDatagridViews.Controls.Add(this.lblSalas);
            this.panelDatagridViews.Controls.Add(this.lblConsultas);
            this.panelDatagridViews.Controls.Add(this.dgvSalas);
            this.panelDatagridViews.Controls.Add(this.dgvListarConsultasPrivs);
            this.panelDatagridViews.Location = new System.Drawing.Point(24, 363);
            this.panelDatagridViews.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.panelDatagridViews.Name = "panelDatagridViews";
            this.panelDatagridViews.Size = new System.Drawing.Size(872, 144);
            this.panelDatagridViews.TabIndex = 5;
            this.panelDatagridViews.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(681, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "filtrar";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(730, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 20);
            this.textBox2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(247, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "filtrar";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(294, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 9;
            // 
            // lblSalas
            // 
            this.lblSalas.AutoSize = true;
            this.lblSalas.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalas.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSalas.Location = new System.Drawing.Point(439, 7);
            this.lblSalas.Name = "lblSalas";
            this.lblSalas.Size = new System.Drawing.Size(135, 19);
            this.lblSalas.TabIndex = 8;
            this.lblSalas.Text = "Salas del usuario";
            // 
            // lblConsultas
            // 
            this.lblConsultas.AutoSize = true;
            this.lblConsultas.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultas.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblConsultas.Location = new System.Drawing.Point(3, 7);
            this.lblConsultas.Name = "lblConsultas";
            this.lblConsultas.Size = new System.Drawing.Size(169, 19);
            this.lblConsultas.TabIndex = 7;
            this.lblConsultas.Text = "Consultas del usuario";
            // 
            // dgvSalas
            // 
            this.dgvSalas.AllowUserToAddRows = false;
            this.dgvSalas.AllowUserToDeleteRows = false;
            this.dgvSalas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalas.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvSalas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalas.ColumnHeadersHeight = 25;
            this.dgvSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSalas.EnableHeadersVisualStyles = false;
            this.dgvSalas.Location = new System.Drawing.Point(439, 29);
            this.dgvSalas.Margin = new System.Windows.Forms.Padding(0);
            this.dgvSalas.MultiSelect = false;
            this.dgvSalas.Name = "dgvSalas";
            this.dgvSalas.ReadOnly = true;
            this.dgvSalas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSalas.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSalas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalas.Size = new System.Drawing.Size(433, 112);
            this.dgvSalas.TabIndex = 6;
            // 
            // dgvListarConsultasPrivs
            // 
            this.dgvListarConsultasPrivs.AllowUserToAddRows = false;
            this.dgvListarConsultasPrivs.AllowUserToDeleteRows = false;
            this.dgvListarConsultasPrivs.AllowUserToResizeColumns = false;
            this.dgvListarConsultasPrivs.AllowUserToResizeRows = false;
            this.dgvListarConsultasPrivs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListarConsultasPrivs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvListarConsultasPrivs.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvListarConsultasPrivs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListarConsultasPrivs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListarConsultasPrivs.ColumnHeadersHeight = 25;
            this.dgvListarConsultasPrivs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListarConsultasPrivs.EnableHeadersVisualStyles = false;
            this.dgvListarConsultasPrivs.Location = new System.Drawing.Point(0, 29);
            this.dgvListarConsultasPrivs.Margin = new System.Windows.Forms.Padding(0);
            this.dgvListarConsultasPrivs.MultiSelect = false;
            this.dgvListarConsultasPrivs.Name = "dgvListarConsultasPrivs";
            this.dgvListarConsultasPrivs.ReadOnly = true;
            this.dgvListarConsultasPrivs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListarConsultasPrivs.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvListarConsultasPrivs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListarConsultasPrivs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarConsultasPrivs.Size = new System.Drawing.Size(433, 112);
            this.dgvListarConsultasPrivs.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(87, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuarios del sistema";
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(920, 519);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelDatagridViews);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserList";
            this.Text = "listarAlumnos";
            this.panelDatagridViews.ResumeLayout(false);
            this.panelDatagridViews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarConsultasPrivs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelDatagridViews;
        private System.Windows.Forms.Label lblSalas;
        private System.Windows.Forms.Label lblConsultas;
        private System.Windows.Forms.DataGridView dgvSalas;
        private System.Windows.Forms.DataGridView dgvListarConsultasPrivs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}