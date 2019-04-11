namespace SangAdv.Updater.Client
{
    partial class ucError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucError));
            this.pbUpdateStatus = new System.Windows.Forms.PictureBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblErrorHeading = new System.Windows.Forms.Label();
            this.ilStatus = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdateStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUpdateStatus
            // 
            this.pbUpdateStatus.Image = ((System.Drawing.Image)(resources.GetObject("pbUpdateStatus.Image")));
            this.pbUpdateStatus.Location = new System.Drawing.Point(89, 98);
            this.pbUpdateStatus.Name = "pbUpdateStatus";
            this.pbUpdateStatus.Size = new System.Drawing.Size(64, 64);
            this.pbUpdateStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbUpdateStatus.TabIndex = 58;
            this.pbUpdateStatus.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.Location = new System.Drawing.Point(178, 141);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(105, 17);
            this.lblErrorMessage.TabIndex = 57;
            this.lblErrorMessage.Text = "lblErrorMessage";
            // 
            // lblErrorHeading
            // 
            this.lblErrorHeading.AutoSize = true;
            this.lblErrorHeading.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorHeading.Location = new System.Drawing.Point(176, 94);
            this.lblErrorHeading.Name = "lblErrorHeading";
            this.lblErrorHeading.Size = new System.Drawing.Size(141, 30);
            this.lblErrorHeading.TabIndex = 56;
            this.lblErrorHeading.Text = "Error Heading";
            // 
            // ilStatus
            // 
            this.ilStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilStatus.ImageStream")));
            this.ilStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.ilStatus.Images.SetKeyName(0, "info.png");
            this.ilStatus.Images.SetKeyName(1, "warning.png");
            this.ilStatus.Images.SetKeyName(2, "stop.png");
            // 
            // ucError
            // 
            this.ActionButtonImage = ((System.Drawing.Image)(resources.GetObject("$this.ActionButtonImage")));
            this.ActionButtonText = "Quit";
            this.ActionButtonWidth = 60;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbUpdateStatus);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.lblErrorHeading);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucError";
            this.Controls.SetChildIndex(this.lblErrorHeading, 0);
            this.Controls.SetChildIndex(this.lblErrorMessage, 0);
            this.Controls.SetChildIndex(this.pbUpdateStatus, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdateStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbUpdateStatus;
        internal System.Windows.Forms.Label lblErrorHeading;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.ImageList ilStatus;
    }
}
