namespace SangAdv.Updater.Client
{
    partial class ucBaseControl
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
            this.btnAction = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Enabled = false;
            this.btnAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.Image = global::SangAdv.Updater.Client.Properties.Resources.install_16px;
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAction.Location = new System.Drawing.Point(576, 271);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(98, 24);
            this.btnAction.TabIndex = 55;
            this.btnAction.Text = "Install";
            this.btnAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(40, 278);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(86, 17);
            this.lblError.TabIndex = 69;
            this.lblError.Text = "Error occurred";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(40, 258);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(89, 17);
            this.lblMessage.TabIndex = 68;
            this.lblMessage.Text = "Im a message";
            // 
            // ucBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAction);
            this.Name = "ucBaseControl";
            this.Size = new System.Drawing.Size(700, 319);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnAction;
        internal System.Windows.Forms.Label lblError;
        internal System.Windows.Forms.Label lblMessage;
    }
}
