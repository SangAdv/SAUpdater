namespace SangAdv.Updater.Client
{
    partial class SAUpdaterExecute
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
            this.clientPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // clientPanel
            // 
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Margin = new System.Windows.Forms.Padding(0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(700, 320);
            this.clientPanel.TabIndex = 1;
            // 
            // SAUpdaterExec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientPanel);
            this.Name = "SAUpdaterExec";
            this.Size = new System.Drawing.Size(700, 320);
            this.Load += new System.EventHandler(this.SAUpdaterExec_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel clientPanel;
    }
}
