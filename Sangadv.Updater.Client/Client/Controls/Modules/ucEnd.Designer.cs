namespace SangAdv.Updater.Client
{
    partial class ucEnd
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
            this.pbUpdateStatus = new System.Windows.Forms.PictureBox();
            this.lblEndMessage = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.btnLaunch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdateStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUpdateStatus
            // 
            this.pbUpdateStatus.Image = global::SangAdv.Updater.Client.Properties.Resources.ok_button;
            this.pbUpdateStatus.Location = new System.Drawing.Point(68, 72);
            this.pbUpdateStatus.Name = "pbUpdateStatus";
            this.pbUpdateStatus.Size = new System.Drawing.Size(48, 48);
            this.pbUpdateStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbUpdateStatus.TabIndex = 49;
            this.pbUpdateStatus.TabStop = false;
            // 
            // lblEndMessage
            // 
            this.lblEndMessage.AutoSize = true;
            this.lblEndMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndMessage.Location = new System.Drawing.Point(172, 116);
            this.lblEndMessage.Name = "lblEndMessage";
            this.lblEndMessage.Size = new System.Drawing.Size(123, 23);
            this.lblEndMessage.TabIndex = 48;
            this.lblEndMessage.Text = "lblEndMessage";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccess.Location = new System.Drawing.Point(170, 69);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(114, 37);
            this.lblSuccess.TabIndex = 47;
            this.lblSuccess.Text = "Success!";
            // 
            // btnLaunch
            // 
            this.btnLaunch.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLaunch.Image = global::SangAdv.Updater.Client.Properties.Resources.OK;
            this.btnLaunch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLaunch.Location = new System.Drawing.Point(175, 165);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(77, 24);
            this.btnLaunch.TabIndex = 70;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // ucEnd
            // 
            this.ActionButtonWidth = 175;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.pbUpdateStatus);
            this.Controls.Add(this.lblEndMessage);
            this.Controls.Add(this.lblSuccess);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "ucEnd";
            this.Size = new System.Drawing.Size(1244, 574);
            this.Controls.SetChildIndex(this.lblSuccess, 0);
            this.Controls.SetChildIndex(this.lblEndMessage, 0);
            this.Controls.SetChildIndex(this.pbUpdateStatus, 0);
            this.Controls.SetChildIndex(this.btnLaunch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdateStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbUpdateStatus;
        internal System.Windows.Forms.Label lblSuccess;
        internal System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Label lblEndMessage;
    }
}
