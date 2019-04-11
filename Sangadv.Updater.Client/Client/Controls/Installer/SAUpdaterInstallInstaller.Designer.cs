namespace SangAdv.Updater.Client
{
    partial class SAUpdaterInstallInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAUpdaterInstallInstaller));
            this.btnAction = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pbProgress = new SangAdv.Updater.Client.eucSAUpdaterProgressBar();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Enabled = false;
            this.btnAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.Image = ((System.Drawing.Image)(resources.GetObject("btnAction.Image")));
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAction.Location = new System.Drawing.Point(-1, 3);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(98, 24);
            this.btnAction.TabIndex = 56;
            this.btnAction.Text = "Install";
            this.btnAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(-4, 75);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 13);
            this.lblMessage.TabIndex = 57;
            this.lblMessage.Text = "lblMessage";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(-4, 47);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(75, 17);
            this.lblProgress.TabIndex = 59;
            this.lblProgress.Text = "lblProgress";
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.BackColour = System.Drawing.Color.DarkGray;
            this.pbProgress.FillColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.pbProgress.Location = new System.Drawing.Point(0, 36);
            this.pbProgress.MarqueeFillPercentage = 25;
            this.pbProgress.MarqueeStepSize = 5;
            this.pbProgress.Maximum = 100;
            this.pbProgress.Minimum = 0;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.ProgressStyle = SangAdv.Updater.Client.eucSAUpdaterProgressBar.SAProgressStyle.Continuous;
            this.pbProgress.Size = new System.Drawing.Size(400, 8);
            this.pbProgress.TabIndex = 58;
            this.pbProgress.TimerInterVal = 5000;
            this.pbProgress.Value = 0;
            // 
            // SAUpdaterInstallInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAction);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SAUpdaterInstallInstaller";
            this.Size = new System.Drawing.Size(400, 90);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SAUpdaterInstallInstaller_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label lblMessage;
        private eucSAUpdaterProgressBar pbProgress;
        private System.Windows.Forms.Label lblProgress;
    }
}
