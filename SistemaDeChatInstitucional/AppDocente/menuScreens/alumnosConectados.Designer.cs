namespace AppDocente.menuScreens
{
    partial class alumnosConectados
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
            this.flowPanelOnline = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowPanelOnline
            // 
            this.flowPanelOnline.AutoScroll = true;
            this.flowPanelOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelOnline.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelOnline.Location = new System.Drawing.Point(0, 0);
            this.flowPanelOnline.Name = "flowPanelOnline";
            this.flowPanelOnline.Size = new System.Drawing.Size(671, 487);
            this.flowPanelOnline.TabIndex = 1;
            this.flowPanelOnline.WrapContents = false;
            // 
            // alumnosConectados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(671, 487);
            this.Controls.Add(this.flowPanelOnline);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "alumnosConectados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.alumnosConectados_FormClosing);
            this.Resize += new System.EventHandler(this.replyScreen_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelOnline;
    }
}