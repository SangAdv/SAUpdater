namespace SangAdv.Updater.Master
{
    partial class ucApplicationContainer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucApplicationContainer));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbCurrentApplication = new System.Windows.Forms.ToolStripButton();
            this.tsbFiles = new System.Windows.Forms.ToolStripButton();
            this.tsbVersions = new System.Windows.Forms.ToolStripButton();
            this.clientPanel = new System.Windows.Forms.Panel();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCurrentApplication,
            this.tsbFiles,
            this.tsbVersions});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tsMenu.Size = new System.Drawing.Size(1409, 67);
            this.tsMenu.Stretch = true;
            this.tsMenu.TabIndex = 3;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbCurrentApplication
            // 
            this.tsbCurrentApplication.AutoSize = false;
            this.tsbCurrentApplication.ForeColor = System.Drawing.Color.White;
            this.tsbCurrentApplication.Image = ((System.Drawing.Image)(resources.GetObject("tsbCurrentApplication.Image")));
            this.tsbCurrentApplication.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCurrentApplication.Name = "tsbCurrentApplication";
            this.tsbCurrentApplication.Padding = new System.Windows.Forms.Padding(5);
            this.tsbCurrentApplication.Size = new System.Drawing.Size(73, 60);
            this.tsbCurrentApplication.Text = "Application";
            this.tsbCurrentApplication.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbCurrentApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCurrentApplication.Click += new System.EventHandler(this.tsbCurrentApplication_Click);
            // 
            // tsbFiles
            // 
            this.tsbFiles.AutoSize = false;
            this.tsbFiles.ForeColor = System.Drawing.Color.White;
            this.tsbFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbFiles.Image")));
            this.tsbFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiles.Name = "tsbFiles";
            this.tsbFiles.Padding = new System.Windows.Forms.Padding(5);
            this.tsbFiles.Size = new System.Drawing.Size(73, 60);
            this.tsbFiles.Text = "Files";
            this.tsbFiles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFiles.Click += new System.EventHandler(this.tsbFiles_Click);
            // 
            // tsbVersions
            // 
            this.tsbVersions.AutoSize = false;
            this.tsbVersions.ForeColor = System.Drawing.Color.White;
            this.tsbVersions.Image = ((System.Drawing.Image)(resources.GetObject("tsbVersions.Image")));
            this.tsbVersions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVersions.Name = "tsbVersions";
            this.tsbVersions.Padding = new System.Windows.Forms.Padding(5);
            this.tsbVersions.Size = new System.Drawing.Size(73, 60);
            this.tsbVersions.Text = "Versions";
            this.tsbVersions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbVersions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbVersions.Click += new System.EventHandler(this.tsbVersions_Click);
            // 
            // clientPanel
            // 
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 67);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(1409, 615);
            this.clientPanel.TabIndex = 4;
            // 
            // ucApplicationContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.tsMenu);
            this.Name = "ucApplicationContainer";
            this.Size = new System.Drawing.Size(1409, 682);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbCurrentApplication;
        private System.Windows.Forms.ToolStripButton tsbFiles;
        private System.Windows.Forms.ToolStripButton tsbVersions;
        private System.Windows.Forms.Panel clientPanel;
    }
}
