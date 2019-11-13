namespace SangAdv.Updater.Client
{
    partial class ucDownloadFiles
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
            this.lblDownloadFile = new System.Windows.Forms.Label();
            this.btnRetry = new System.Windows.Forms.Button();
            this.pbTotalProgress = new SangAdv.Updater.Client.eucSAUpdaterProgressBar();
            this.pbDownloadProgress = new SangAdv.Updater.Client.eucSAUpdaterProgressBar();
            this.lblDownloadProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDownloadFile
            // 
            this.lblDownloadFile.AutoSize = true;
            this.lblDownloadFile.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadFile.Location = new System.Drawing.Point(40, 136);
            this.lblDownloadFile.Name = "lblDownloadFile";
            this.lblDownloadFile.Size = new System.Drawing.Size(99, 17);
            this.lblDownloadFile.TabIndex = 53;
            this.lblDownloadFile.Text = "downloading file";
            // 
            // btnRetry
            // 
            this.btnRetry.Enabled = false;
            this.btnRetry.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetry.Image = global::SangAdv.Updater.Client.Properties.Resources.internet_refresh_16px;
            this.btnRetry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetry.Location = new System.Drawing.Point(542, 271);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(61, 24);
            this.btnRetry.TabIndex = 52;
            this.btnRetry.Text = "Retry";
            this.btnRetry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetry.UseVisualStyleBackColor = true;
            // 
            // pbTotalProgress
            // 
            this.pbTotalProgress.BackColour = System.Drawing.Color.DarkGray;
            this.pbTotalProgress.FillColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.pbTotalProgress.Location = new System.Drawing.Point(43, 124);
            this.pbTotalProgress.Margin = new System.Windows.Forms.Padding(4);
            this.pbTotalProgress.MarqueeFillPercentage = 25;
            this.pbTotalProgress.MarqueeStepSize = 5;
            this.pbTotalProgress.Maximum = 100;
            this.pbTotalProgress.Minimum = 0;
            this.pbTotalProgress.Name = "pbTotalProgress";
            this.pbTotalProgress.ProgressStyle = SangAdv.Updater.Client.eucSAUpdaterProgressBar.SAProgressStyle.Continuous;
            this.pbTotalProgress.Size = new System.Drawing.Size(631, 8);
            this.pbTotalProgress.TabIndex = 56;
            this.pbTotalProgress.TimerInterVal = 5000;
            this.pbTotalProgress.Value = 0;
            this.pbTotalProgress.Visible = false;
            // 
            // pbDownloadProgress
            // 
            this.pbDownloadProgress.BackColour = System.Drawing.Color.DarkGray;
            this.pbDownloadProgress.FillColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.pbDownloadProgress.Location = new System.Drawing.Point(43, 173);
            this.pbDownloadProgress.Margin = new System.Windows.Forms.Padding(4);
            this.pbDownloadProgress.MarqueeFillPercentage = 25;
            this.pbDownloadProgress.MarqueeStepSize = 5;
            this.pbDownloadProgress.Maximum = 100;
            this.pbDownloadProgress.Minimum = 0;
            this.pbDownloadProgress.Name = "pbDownloadProgress";
            this.pbDownloadProgress.ProgressStyle = SangAdv.Updater.Client.eucSAUpdaterProgressBar.SAProgressStyle.Continuous;
            this.pbDownloadProgress.Size = new System.Drawing.Size(631, 8);
            this.pbDownloadProgress.TabIndex = 57;
            this.pbDownloadProgress.TimerInterVal = 5000;
            this.pbDownloadProgress.Value = 0;
            this.pbDownloadProgress.Visible = false;
            // 
            // lblDownloadProgress
            // 
            this.lblDownloadProgress.AutoSize = true;
            this.lblDownloadProgress.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadProgress.Location = new System.Drawing.Point(40, 183);
            this.lblDownloadProgress.Name = "lblDownloadProgress";
            this.lblDownloadProgress.Size = new System.Drawing.Size(43, 17);
            this.lblDownloadProgress.TabIndex = 58;
            this.lblDownloadProgress.Text = "... 10%";
            this.lblDownloadProgress.Visible = false;
            // 
            // ucDownloadFiles
            // 
            this.ActionButtonImage = global::SangAdv.Updater.Client.Properties.Resources.button_arrow_right_16px;
            this.ActionButtonText = "Next";
            this.ActionButtonWidth = 65;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDownloadProgress);
            this.Controls.Add(this.pbDownloadProgress);
            this.Controls.Add(this.pbTotalProgress);
            this.Controls.Add(this.lblDownloadFile);
            this.Controls.Add(this.btnRetry);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucDownloadFiles";
            this.Controls.SetChildIndex(this.btnRetry, 0);
            this.Controls.SetChildIndex(this.lblDownloadFile, 0);
            this.Controls.SetChildIndex(this.pbTotalProgress, 0);
            this.Controls.SetChildIndex(this.pbDownloadProgress, 0);
            this.Controls.SetChildIndex(this.lblDownloadProgress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label lblDownloadFile;
        internal System.Windows.Forms.Button btnRetry;
        private eucSAUpdaterProgressBar pbTotalProgress;
        private eucSAUpdaterProgressBar pbDownloadProgress;
        internal System.Windows.Forms.Label lblDownloadProgress;
    }
}
