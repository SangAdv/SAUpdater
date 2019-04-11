namespace SangAdv.Updater.Client
{
    partial class frmInstallInstaller
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.saUInstall = new SangAdv.Updater.Client.SAUpdaterInstallInstaller();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(73, 33);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(268, 30);
            this.lblVersion.TabIndex = 72;
            this.lblVersion.Text = "Application Installer Update";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(471, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 24);
            this.btnCancel.TabIndex = 85;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // saUInstall
            // 
            this.saUInstall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saUInstall.DisplaySuccessMessage = true;
            this.saUInstall.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saUInstall.Location = new System.Drawing.Point(78, 79);
            this.saUInstall.Name = "saUInstall";
            this.saUInstall.Size = new System.Drawing.Size(400, 90);
            this.saUInstall.TabIndex = 0;
            // 
            // frmInstallInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 236);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.saUInstall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInstallInstaller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.frmInstallInstaller_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SAUpdaterInstallInstaller saUInstall;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Button btnCancel;
    }
}