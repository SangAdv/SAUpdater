namespace SangAdv.Updater.Client
{
    partial class ucKillProcess
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
            this.lblInstallFolderTitle = new System.Windows.Forms.Label();
            this.lstProcess = new System.Windows.Forms.ListBox();
            this.btnKill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstallFolderTitle
            // 
            this.lblInstallFolderTitle.AutoSize = true;
            this.lblInstallFolderTitle.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallFolderTitle.Location = new System.Drawing.Point(40, 35);
            this.lblInstallFolderTitle.Name = "lblInstallFolderTitle";
            this.lblInstallFolderTitle.Size = new System.Drawing.Size(248, 17);
            this.lblInstallFolderTitle.TabIndex = 48;
            this.lblInstallFolderTitle.Text = "Waiting for the following processes to close";
            // 
            // lstProcess
            // 
            this.lstProcess.FormattingEnabled = true;
            this.lstProcess.Location = new System.Drawing.Point(43, 59);
            this.lstProcess.Name = "lstProcess";
            this.lstProcess.Size = new System.Drawing.Size(631, 186);
            this.lstProcess.TabIndex = 47;
            // 
            // btnKill
            // 
            this.btnKill.Enabled = false;
            this.btnKill.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKill.Image = global::SangAdv.Updater.Client.Properties.Resources.gear_filled_cancel_2_16px;
            this.btnKill.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKill.Location = new System.Drawing.Point(595, 271);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(79, 24);
            this.btnKill.TabIndex = 56;
            this.btnKill.Text = "Kill All";
            this.btnKill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // ucKillProcess
            // 
            this.ActionButtonImage = global::SangAdv.Updater.Client.Properties.Resources.gear_filled_cancel_2_16px;
            this.ActionButtonText = "Kill All";
            this.ActionButtonVisible = false;
            this.ActionButtonWidth = 70;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.lblInstallFolderTitle);
            this.Controls.Add(this.lstProcess);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucKillProcess";
            this.Controls.SetChildIndex(this.lstProcess, 0);
            this.Controls.SetChildIndex(this.lblInstallFolderTitle, 0);
            this.Controls.SetChildIndex(this.btnKill, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label lblInstallFolderTitle;
        internal System.Windows.Forms.ListBox lstProcess;
        internal System.Windows.Forms.Button btnKill;
    }
}
