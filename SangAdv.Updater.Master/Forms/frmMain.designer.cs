namespace SangAdv.Updater.Master
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bstVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.bstStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsiUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsiConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbApplications = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNewApplication = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsbInformation = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbOpenSource = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbGeneralSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.clientPanel = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bstVersion,
            this.bstStatus,
            this.toolStripStatusLabel1,
            this.tsiUpdate,
            this.tsiConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1249, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bstVersion
            // 
            this.bstVersion.ForeColor = System.Drawing.Color.White;
            this.bstVersion.Name = "bstVersion";
            this.bstVersion.Size = new System.Drawing.Size(40, 20);
            this.bstVersion.Text = "1.0.0.0";
            // 
            // bstStatus
            // 
            this.bstStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.bstStatus.ForeColor = System.Drawing.Color.White;
            this.bstStatus.Name = "bstStatus";
            this.bstStatus.Size = new System.Drawing.Size(43, 20);
            this.bstStatus.Text = "Status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1096, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsiUpdate
            // 
            this.tsiUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsiUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsiUpdate.Image")));
            this.tsiUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsiUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsiUpdate.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.tsiUpdate.Name = "tsiUpdate";
            this.tsiUpdate.Padding = new System.Windows.Forms.Padding(2, 0, 5, 0);
            this.tsiUpdate.Size = new System.Drawing.Size(23, 20);
            this.tsiUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // tsiConnection
            // 
            this.tsiConnection.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsiConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsiConnection.Image = ((System.Drawing.Image)(resources.GetObject("tsiConnection.Image")));
            this.tsiConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsiConnection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsiConnection.Name = "tsiConnection";
            this.tsiConnection.Padding = new System.Windows.Forms.Padding(2, 0, 5, 0);
            this.tsiConnection.Size = new System.Drawing.Size(27, 20);
            this.tsiConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // tsMenu
            // 
            this.tsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbApplications,
            this.toolStripSeparator2,
            this.tsbNewApplication,
            this.tsbExit,
            this.tsbInformation,
            this.tsbSettings});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsMenu.Size = new System.Drawing.Size(1249, 65);
            this.tsMenu.Stretch = true;
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbApplications
            // 
            this.tsbApplications.AutoSize = false;
            this.tsbApplications.ForeColor = System.Drawing.Color.White;
            this.tsbApplications.Image = ((System.Drawing.Image)(resources.GetObject("tsbApplications.Image")));
            this.tsbApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbApplications.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApplications.Name = "tsbApplications";
            this.tsbApplications.Padding = new System.Windows.Forms.Padding(5);
            this.tsbApplications.Size = new System.Drawing.Size(73, 60);
            this.tsbApplications.Text = "Applications";
            this.tsbApplications.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbApplications.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbApplications.Click += new System.EventHandler(this.tsbApplications_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 63);
            // 
            // tsbNewApplication
            // 
            this.tsbNewApplication.AutoSize = false;
            this.tsbNewApplication.ForeColor = System.Drawing.Color.White;
            this.tsbNewApplication.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewApplication.Image")));
            this.tsbNewApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNewApplication.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewApplication.Name = "tsbNewApplication";
            this.tsbNewApplication.Padding = new System.Windows.Forms.Padding(5);
            this.tsbNewApplication.Size = new System.Drawing.Size(73, 60);
            this.tsbNewApplication.Text = "New Application";
            this.tsbNewApplication.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbNewApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNewApplication.Click += new System.EventHandler(this.tsbNewApplication_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbExit.AutoSize = false;
            this.tsbExit.ForeColor = System.Drawing.Color.White;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Padding = new System.Windows.Forms.Padding(5);
            this.tsbExit.Size = new System.Drawing.Size(73, 60);
            this.tsbExit.Text = "Exit";
            this.tsbExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tsbInformation
            // 
            this.tsbInformation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbInformation.AutoSize = false;
            this.tsbInformation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpenSource,
            this.toolStripMenuItem2,
            this.tsbAbout});
            this.tsbInformation.ForeColor = System.Drawing.Color.White;
            this.tsbInformation.Image = ((System.Drawing.Image)(resources.GetObject("tsbInformation.Image")));
            this.tsbInformation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbInformation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInformation.Name = "tsbInformation";
            this.tsbInformation.Padding = new System.Windows.Forms.Padding(5);
            this.tsbInformation.Size = new System.Drawing.Size(75, 60);
            this.tsbInformation.Text = "Information";
            this.tsbInformation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbInformation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbOpenSource
            // 
            this.tsbOpenSource.Image = global::SangAdv.Updater.Master.Properties.Resources.GitHub_Filled_24;
            this.tsbOpenSource.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOpenSource.Name = "tsbOpenSource";
            this.tsbOpenSource.Size = new System.Drawing.Size(150, 30);
            this.tsbOpenSource.Text = "Open Source";
            this.tsbOpenSource.Click += new System.EventHandler(this.tsbOpenSource_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::SangAdv.Updater.Master.Properties.Resources.Help_Filled_24;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 30);
            this.toolStripMenuItem2.Text = "Help";
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = global::SangAdv.Updater.Master.Properties.Resources.About_Filled_24;
            this.tsbAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(150, 30);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSettings.AutoSize = false;
            this.tsbSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUpdate,
            this.tsbCategory,
            this.tsbGeneralSettings});
            this.tsbSettings.ForeColor = System.Drawing.Color.White;
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Padding = new System.Windows.Forms.Padding(5);
            this.tsbSettings.Size = new System.Drawing.Size(75, 60);
            this.tsbSettings.Text = "Settings";
            this.tsbSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.AutoSize = false;
            this.tsbUpdate.Image = global::SangAdv.Updater.Master.Properties.Resources.Available_Updates_Filled_24;
            this.tsbUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(168, 30);
            this.tsbUpdate.Text = "Update";
            // 
            // tsbCategory
            // 
            this.tsbCategory.AutoSize = false;
            this.tsbCategory.Image = global::SangAdv.Updater.Master.Properties.Resources.Test_Partial_Passed_Filled_24;
            this.tsbCategory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCategory.Name = "tsbCategory";
            this.tsbCategory.Size = new System.Drawing.Size(168, 30);
            this.tsbCategory.Text = "Category";
            this.tsbCategory.Click += new System.EventHandler(this.tsbCategory_Click);
            // 
            // tsbGeneralSettings
            // 
            this.tsbGeneralSettings.AutoSize = false;
            this.tsbGeneralSettings.Image = global::SangAdv.Updater.Master.Properties.Resources.Administrative_Tools_Filled_24;
            this.tsbGeneralSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGeneralSettings.Name = "tsbGeneralSettings";
            this.tsbGeneralSettings.Size = new System.Drawing.Size(168, 30);
            this.tsbGeneralSettings.Text = "Settings";
            // 
            // clientPanel
            // 
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 65);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(1249, 622);
            this.clientPanel.TabIndex = 3;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 712);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "SA Updater";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbApplications;
        private System.Windows.Forms.ToolStripStatusLabel bstVersion;
        private System.Windows.Forms.ToolStripStatusLabel bstStatus;
        private System.Windows.Forms.ToolStripButton tsbNewApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripDropDownButton tsbInformation;
        private System.Windows.Forms.ToolStripMenuItem tsbOpenSource;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsbAbout;
        private System.Windows.Forms.ToolStripDropDownButton tsbSettings;
        private System.Windows.Forms.Panel clientPanel;
        private System.Windows.Forms.ToolStripStatusLabel tsiConnection;
        private System.Windows.Forms.ToolStripStatusLabel tsiUpdate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem tsbUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsbCategory;
        private System.Windows.Forms.ToolStripMenuItem tsbGeneralSettings;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

