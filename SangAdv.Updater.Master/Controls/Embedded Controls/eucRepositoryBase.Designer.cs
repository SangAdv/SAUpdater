namespace SangAdv.Updater.Master
{
    partial class eucRepositoryBase
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
            this.btnTestSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestSettings
            // 
            this.btnTestSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestSettings.Location = new System.Drawing.Point(1221, 214);
            this.btnTestSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestSettings.Name = "btnTestSettings";
            this.btnTestSettings.Size = new System.Drawing.Size(115, 28);
            this.btnTestSettings.TabIndex = 49;
            this.btnTestSettings.Text = "Test Settings";
            this.btnTestSettings.UseVisualStyleBackColor = true;
            this.btnTestSettings.Click += new System.EventHandler(this.btnTestSettings_Click);
            // 
            // eucRepositoryBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTestSettings);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "eucRepositoryBase";
            this.Size = new System.Drawing.Size(1340, 246);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestSettings;
    }
}
