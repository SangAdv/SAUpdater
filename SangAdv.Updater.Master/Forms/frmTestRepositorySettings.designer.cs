namespace SangAdv.Updater.Master
{
    partial class frmTestRepositorySettings
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(496, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(12, 12);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(75, 23);
            this.btnStartTest.TabIndex = 10;
            this.btnStartTest.Text = "Start Test";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(12, 45);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(559, 303);
            this.lstBox.TabIndex = 11;
            // 
            // frmTestFTPRepositorySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 393);
            this.ControlBox = false;
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Name = "frmTestFTPRepositorySettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Settings";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.ListBox lstBox;
    }
}