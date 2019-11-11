namespace SangAdv.Updater.Client
{
    partial class ucDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDesigner));
            this.lblError = new System.Windows.Forms.Label();
            this.pbSettingsfile = new System.Windows.Forms.PictureBox();
            this.lblSettingsFile = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.btnDir = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pbConnected = new System.Windows.Forms.PictureBox();
            this.lblConnected = new System.Windows.Forms.Label();
            this.pbOSStatus = new System.Windows.Forms.PictureBox();
            this.lblOS = new System.Windows.Forms.Label();
            this.pbFWStatus = new System.Windows.Forms.PictureBox();
            this.lblFramework = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFWDownload = new System.Windows.Forms.Button();
            this.lblInstallFolderTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettingsfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOSStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFWStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(52, 350);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(118, 23);
            this.lblError.TabIndex = 67;
            this.lblError.Text = "Error occurred";
            // 
            // pbSettingsfile
            // 
            this.pbSettingsfile.Image = ((System.Drawing.Image)(resources.GetObject("pbSettingsfile.Image")));
            this.pbSettingsfile.Location = new System.Drawing.Point(56, 123);
            this.pbSettingsfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbSettingsfile.Name = "pbSettingsfile";
            this.pbSettingsfile.Size = new System.Drawing.Size(16, 16);
            this.pbSettingsfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSettingsfile.TabIndex = 66;
            this.pbSettingsfile.TabStop = false;
            // 
            // lblSettingsFile
            // 
            this.lblSettingsFile.AutoSize = true;
            this.lblSettingsFile.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsFile.Location = new System.Drawing.Point(85, 122);
            this.lblSettingsFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSettingsFile.Name = "lblSettingsFile";
            this.lblSettingsFile.Size = new System.Drawing.Size(111, 23);
            this.lblSettingsFile.TabIndex = 65;
            this.lblSettingsFile.Text = "lblSettingsFile";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCount.Location = new System.Drawing.Point(52, 202);
            this.lblFileCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(51, 23);
            this.lblFileCount.TabIndex = 64;
            this.lblFileCount.Text = "0 files";
            // 
            // btnDir
            // 
            this.btnDir.Location = new System.Drawing.Point(849, 268);
            this.btnDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(36, 28);
            this.btnDir.TabIndex = 63;
            this.btnDir.Text = "...";
            this.btnDir.UseVisualStyleBackColor = true;
            // 
            // txtDir
            // 
            this.txtDir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDir.Location = new System.Drawing.Point(56, 270);
            this.txtDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDir.Name = "txtDir";
            this.txtDir.ReadOnly = true;
            this.txtDir.Size = new System.Drawing.Size(784, 26);
            this.txtDir.TabIndex = 62;
            // 
            // btnAction
            // 
            this.btnAction.Enabled = false;
            this.btnAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAction.ImageIndex = 1;
            this.btnAction.Location = new System.Drawing.Point(768, 334);
            this.btnAction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(131, 30);
            this.btnAction.TabIndex = 61;
            this.btnAction.Text = "Download";
            this.btnAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(52, 325);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(115, 23);
            this.lblMessage.TabIndex = 60;
            this.lblMessage.Text = "Im a message";
            // 
            // pbConnected
            // 
            this.pbConnected.Image = ((System.Drawing.Image)(resources.GetObject("pbConnected.Image")));
            this.pbConnected.Location = new System.Drawing.Point(56, 90);
            this.pbConnected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbConnected.Name = "pbConnected";
            this.pbConnected.Size = new System.Drawing.Size(16, 16);
            this.pbConnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbConnected.TabIndex = 59;
            this.pbConnected.TabStop = false;
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnected.Location = new System.Drawing.Point(85, 89);
            this.lblConnected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(108, 23);
            this.lblConnected.TabIndex = 58;
            this.lblConnected.Text = "lblConnected";
            // 
            // pbOSStatus
            // 
            this.pbOSStatus.Image = ((System.Drawing.Image)(resources.GetObject("pbOSStatus.Image")));
            this.pbOSStatus.Location = new System.Drawing.Point(56, 23);
            this.pbOSStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbOSStatus.Name = "pbOSStatus";
            this.pbOSStatus.Size = new System.Drawing.Size(16, 16);
            this.pbOSStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOSStatus.TabIndex = 57;
            this.pbOSStatus.TabStop = false;
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOS.Location = new System.Drawing.Point(85, 22);
            this.lblOS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(50, 23);
            this.lblOS.TabIndex = 56;
            this.lblOS.Text = "lblOS";
            // 
            // pbFWStatus
            // 
            this.pbFWStatus.Image = ((System.Drawing.Image)(resources.GetObject("pbFWStatus.Image")));
            this.pbFWStatus.Location = new System.Drawing.Point(56, 57);
            this.pbFWStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbFWStatus.Name = "pbFWStatus";
            this.pbFWStatus.Size = new System.Drawing.Size(16, 16);
            this.pbFWStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFWStatus.TabIndex = 55;
            this.pbFWStatus.TabStop = false;
            // 
            // lblFramework
            // 
            this.lblFramework.AutoSize = true;
            this.lblFramework.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFramework.Location = new System.Drawing.Point(85, 55);
            this.lblFramework.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFramework.Name = "lblFramework";
            this.lblFramework.Size = new System.Drawing.Size(110, 23);
            this.lblFramework.TabIndex = 54;
            this.lblFramework.Text = "lblFramework";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(849, 52);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(36, 30);
            this.btnRefresh.TabIndex = 53;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            // 
            // btnFWDownload
            // 
            this.btnFWDownload.Enabled = false;
            this.btnFWDownload.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFWDownload.Image = global::SangAdv.Updater.Client.Properties.Resources.internet_download;
            this.btnFWDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFWDownload.Location = new System.Drawing.Point(724, 52);
            this.btnFWDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFWDownload.Name = "btnFWDownload";
            this.btnFWDownload.Size = new System.Drawing.Size(117, 30);
            this.btnFWDownload.TabIndex = 52;
            this.btnFWDownload.Text = "Download";
            this.btnFWDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFWDownload.UseVisualStyleBackColor = true;
            this.btnFWDownload.Visible = false;
            // 
            // lblInstallFolderTitle
            // 
            this.lblInstallFolderTitle.AutoSize = true;
            this.lblInstallFolderTitle.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallFolderTitle.Location = new System.Drawing.Point(52, 245);
            this.lblInstallFolderTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstallFolderTitle.Name = "lblInstallFolderTitle";
            this.lblInstallFolderTitle.Size = new System.Drawing.Size(253, 23);
            this.lblInstallFolderTitle.TabIndex = 51;
            this.lblInstallFolderTitle.Text = "pharmatrack installation directory:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(49, 165);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(89, 37);
            this.lblVersion.TabIndex = 50;
            this.lblVersion.Text = "Label1";
            // 
            // ucDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pbSettingsfile);
            this.Controls.Add(this.lblSettingsFile);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.btnDir);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pbConnected);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.pbOSStatus);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.pbFWStatus);
            this.Controls.Add(this.lblFramework);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFWDownload);
            this.Controls.Add(this.lblInstallFolderTitle);
            this.Controls.Add(this.lblVersion);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucDesigner";
            this.Size = new System.Drawing.Size(933, 393);
            ((System.ComponentModel.ISupportInitialize)(this.pbSettingsfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOSStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFWStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblError;
        internal System.Windows.Forms.PictureBox pbSettingsfile;
        internal System.Windows.Forms.Label lblSettingsFile;
        internal System.Windows.Forms.Label lblFileCount;
        internal System.Windows.Forms.Button btnDir;
        internal System.Windows.Forms.TextBox txtDir;
        internal System.Windows.Forms.Button btnAction;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.PictureBox pbConnected;
        internal System.Windows.Forms.Label lblConnected;
        internal System.Windows.Forms.PictureBox pbOSStatus;
        internal System.Windows.Forms.Label lblOS;
        internal System.Windows.Forms.PictureBox pbFWStatus;
        internal System.Windows.Forms.Label lblFramework;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnFWDownload;
        internal System.Windows.Forms.Label lblInstallFolderTitle;
        internal System.Windows.Forms.Label lblVersion;
    }
}
