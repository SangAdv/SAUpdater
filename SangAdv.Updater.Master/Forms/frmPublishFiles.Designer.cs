namespace SangAdv.Updater.Master
{
    partial class frmPublishFiles
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
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnAppCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.pbProgress = new SangAdv.Updater.Master.eucSAUpdaterProgressBar();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnPublish
            // 
            this.btnPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPublish.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublish.Location = new System.Drawing.Point(397, 401);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(75, 23);
            this.btnPublish.TabIndex = 16;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnAppCancel
            // 
            this.btnAppCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAppCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppCancel.Location = new System.Drawing.Point(478, 401);
            this.btnAppCancel.Name = "btnAppCancel";
            this.btnAppCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAppCancel.TabIndex = 15;
            this.btnAppCancel.Text = "Cancel";
            this.btnAppCancel.UseVisualStyleBackColor = true;
            this.btnAppCancel.Click += new System.EventHandler(this.btnAppCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(9, 443);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 13);
            this.lblMessage.TabIndex = 32;
            this.lblMessage.Text = "lblMessage";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(478, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeading.Location = new System.Drawing.Point(8, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(90, 21);
            this.lblHeading.TabIndex = 35;
            this.lblHeading.Text = "lblHeading";
            // 
            // pbProgress
            // 
            this.pbProgress.BackColour = System.Drawing.Color.DarkGray;
            this.pbProgress.FillColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.pbProgress.Location = new System.Drawing.Point(12, 380);
            this.pbProgress.MarqueeFillPercentage = 20;
            this.pbProgress.MarqueeStepSize = 10;
            this.pbProgress.Maximum = 100;
            this.pbProgress.Minimum = 0;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.ProgressStyle = SangAdv.Updater.Master.eucSAUpdaterProgressBar.SAProgressStyle.Marquee;
            this.pbProgress.Size = new System.Drawing.Size(541, 8);
            this.pbProgress.TabIndex = 34;
            this.pbProgress.TimerInterVal = 300;
            this.pbProgress.Value = 45;
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(12, 36);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(541, 329);
            this.lstBox.TabIndex = 36;
            // 
            // frmPublishFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 465);
            this.ControlBox = false;
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnAppCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPublishFiles";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Publish Files ...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btnPublish;
        internal System.Windows.Forms.Button btnAppCancel;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Button btnClose;
        private eucSAUpdaterProgressBar pbProgress;
        internal System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ListBox lstBox;
    }
}