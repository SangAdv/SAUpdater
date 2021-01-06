namespace SangAdv.Updater.Client
{
    partial class ucInstallInstaller
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucInstallInstaller));
            this.saUInstall = new SangAdv.Updater.Client.SAUpdaterInstallInstaller();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pbConnected = new System.Windows.Forms.PictureBox();
            this.lblConnected = new System.Windows.Forms.Label();
            this.pbOSStatus = new System.Windows.Forms.PictureBox();
            this.lblOS = new System.Windows.Forms.Label();
            this.pbFWStatus = new System.Windows.Forms.PictureBox();
            this.lblFramework = new System.Windows.Forms.Label();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbConnected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOSStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFWStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // saUInstall
            // 
            this.saUInstall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saUInstall.DisplaySuccessMessage = true;
            this.saUInstall.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saUInstall.Location = new System.Drawing.Point(43, 159);
            this.saUInstall.Name = "saUInstall";
            this.saUInstall.Size = new System.Drawing.Size(631, 90);
            this.saUInstall.TabIndex = 70;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(38, 35);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(293, 30);
            this.lblVersion.TabIndex = 71;
            this.lblVersion.Text = "Prepare Application Installer ...";
            // 
            // pbConnected
            // 
            this.pbConnected.Image = global::SangAdv.Updater.Client.Properties.Resources.button_error_16px;
            this.pbConnected.Location = new System.Drawing.Point(43, 132);
            this.pbConnected.Name = "pbConnected";
            this.pbConnected.Size = new System.Drawing.Size(16, 16);
            this.pbConnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbConnected.TabIndex = 79;
            this.pbConnected.TabStop = false;
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnected.Location = new System.Drawing.Point(65, 131);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(81, 17);
            this.lblConnected.TabIndex = 78;
            this.lblConnected.Text = "lblConnected";
            // 
            // pbOSStatus
            // 
            this.pbOSStatus.Image = global::SangAdv.Updater.Client.Properties.Resources.button_error_16px;
            this.pbOSStatus.Location = new System.Drawing.Point(43, 78);
            this.pbOSStatus.Name = "pbOSStatus";
            this.pbOSStatus.Size = new System.Drawing.Size(16, 16);
            this.pbOSStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOSStatus.TabIndex = 77;
            this.pbOSStatus.TabStop = false;
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOS.Location = new System.Drawing.Point(65, 77);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(38, 17);
            this.lblOS.TabIndex = 76;
            this.lblOS.Text = "lblOS";
            // 
            // pbFWStatus
            // 
            this.pbFWStatus.Image = global::SangAdv.Updater.Client.Properties.Resources.button_error_16px;
            this.pbFWStatus.Location = new System.Drawing.Point(43, 105);
            this.pbFWStatus.Name = "pbFWStatus";
            this.pbFWStatus.Size = new System.Drawing.Size(16, 16);
            this.pbFWStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFWStatus.TabIndex = 75;
            this.pbFWStatus.TabStop = false;
            // 
            // lblFramework
            // 
            this.lblFramework.AutoSize = true;
            this.lblFramework.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFramework.Location = new System.Drawing.Point(65, 104);
            this.lblFramework.Name = "lblFramework";
            this.lblFramework.Size = new System.Drawing.Size(82, 17);
            this.lblFramework.TabIndex = 74;
            this.lblFramework.Text = "lblFramework";
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "button-error@16px.png");
            this.ImageList1.Images.SetKeyName(1, "button-ok@16px.png");
            // 
            // ucInstallInstaller
            // 
            this.ActionButtonImage = global::SangAdv.Updater.Client.Properties.Resources.install_16px;
            this.ActionButtonWidth = 70;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbConnected);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.pbOSStatus);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.pbFWStatus);
            this.Controls.Add(this.lblFramework);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.saUInstall);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucInstallInstaller";
            this.Controls.SetChildIndex(this.saUInstall, 0);
            this.Controls.SetChildIndex(this.lblVersion, 0);
            this.Controls.SetChildIndex(this.lblFramework, 0);
            this.Controls.SetChildIndex(this.pbFWStatus, 0);
            this.Controls.SetChildIndex(this.lblOS, 0);
            this.Controls.SetChildIndex(this.pbOSStatus, 0);
            this.Controls.SetChildIndex(this.lblConnected, 0);
            this.Controls.SetChildIndex(this.pbConnected, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbConnected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOSStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFWStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SAUpdaterInstallInstaller saUInstall;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.PictureBox pbConnected;
        internal System.Windows.Forms.Label lblConnected;
        internal System.Windows.Forms.PictureBox pbOSStatus;
        internal System.Windows.Forms.Label lblOS;
        internal System.Windows.Forms.PictureBox pbFWStatus;
        internal System.Windows.Forms.Label lblFramework;
        internal System.Windows.Forms.ImageList ImageList1;
    }
}
