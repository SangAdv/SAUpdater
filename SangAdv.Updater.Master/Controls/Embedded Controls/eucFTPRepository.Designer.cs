namespace SangAdv.Updater.Master
{
    partial class eucFTPRepository
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtApplicationFolder = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtFTPPassword = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtFTPUsername = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtFTPServer = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtFTPServerDownloadUri = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Application Folder:";
            // 
            // txtApplicationFolder
            // 
            this.txtApplicationFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationFolder.Location = new System.Drawing.Point(0, 120);
            this.txtApplicationFolder.Name = "txtApplicationFolder";
            this.txtApplicationFolder.Size = new System.Drawing.Size(686, 22);
            this.txtApplicationFolder.TabIndex = 43;
            this.txtApplicationFolder.TextChanged += new System.EventHandler(this.txtApplicationFolder_TextChanged);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(567, 159);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(107, 17);
            this.chkShowPassword.TabIndex = 40;
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(294, 160);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(82, 13);
            this.Label11.TabIndex = 38;
            this.Label11.Text = "FTP Password:";
            // 
            // txtFTPPassword
            // 
            this.txtFTPPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTPPassword.Location = new System.Drawing.Point(382, 157);
            this.txtFTPPassword.Name = "txtFTPPassword";
            this.txtFTPPassword.PasswordChar = '*';
            this.txtFTPPassword.Size = new System.Drawing.Size(179, 22);
            this.txtFTPPassword.TabIndex = 39;
            this.txtFTPPassword.TextChanged += new System.EventHandler(this.txtFTPPassword_TextChanged);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(-2, 160);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(84, 13);
            this.Label10.TabIndex = 36;
            this.Label10.Text = "FTP Username:";
            // 
            // txtFTPUsername
            // 
            this.txtFTPUsername.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTPUsername.Location = new System.Drawing.Point(88, 157);
            this.txtFTPUsername.Name = "txtFTPUsername";
            this.txtFTPUsername.Size = new System.Drawing.Size(170, 22);
            this.txtFTPUsername.TabIndex = 37;
            this.txtFTPUsername.TextChanged += new System.EventHandler(this.txtFTPUsername_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(-2, 2);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(360, 13);
            this.Label9.TabIndex = 34;
            this.Label9.Text = "FTP Upload Server URL (eg. FTP://www.contosa.com/applications/):";
            // 
            // txtFTPServer
            // 
            this.txtFTPServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFTPServer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTPServer.Location = new System.Drawing.Point(0, 18);
            this.txtFTPServer.Name = "txtFTPServer";
            this.txtFTPServer.Size = new System.Drawing.Size(1005, 22);
            this.txtFTPServer.TabIndex = 35;
            this.txtFTPServer.TextChanged += new System.EventHandler(this.txtFTPServer_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(-2, 52);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(384, 13);
            this.Label3.TabIndex = 47;
            this.Label3.Text = "FTP Download Server URL (eg. HTTP://www.contosa.com/applications/):";
            // 
            // txtFTPServerDownloadUri
            // 
            this.txtFTPServerDownloadUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFTPServerDownloadUri.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTPServerDownloadUri.Location = new System.Drawing.Point(0, 68);
            this.txtFTPServerDownloadUri.Name = "txtFTPServerDownloadUri";
            this.txtFTPServerDownloadUri.Size = new System.Drawing.Size(1005, 22);
            this.txtFTPServerDownloadUri.TabIndex = 47;
            this.txtFTPServerDownloadUri.TextChanged += new System.EventHandler(this.txtFTPServerDownloadUri_TextChanged);
            // 
            // eucFTPRepository
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtApplicationFolder);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.txtFTPPassword);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.txtFTPServerDownloadUri);
            this.Controls.Add(this.txtFTPUsername);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtFTPServer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "eucFTPRepository";
            this.Controls.SetChildIndex(this.txtFTPServer, 0);
            this.Controls.SetChildIndex(this.Label9, 0);
            this.Controls.SetChildIndex(this.txtFTPUsername, 0);
            this.Controls.SetChildIndex(this.txtFTPServerDownloadUri, 0);
            this.Controls.SetChildIndex(this.Label10, 0);
            this.Controls.SetChildIndex(this.txtFTPPassword, 0);
            this.Controls.SetChildIndex(this.Label11, 0);
            this.Controls.SetChildIndex(this.chkShowPassword, 0);
            this.Controls.SetChildIndex(this.txtApplicationFolder, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtApplicationFolder;
        internal System.Windows.Forms.CheckBox chkShowPassword;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtFTPPassword;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtFTPUsername;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtFTPServer;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtFTPServerDownloadUri;
    }
}
