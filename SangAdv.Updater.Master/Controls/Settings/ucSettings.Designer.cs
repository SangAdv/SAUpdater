namespace SangAdv.Updater.Master
{
    partial class ucSettings
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlRepository = new System.Windows.Forms.Panel();
            this.cmbRepositoryType = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.pnlRepository);
            this.groupBox4.Controls.Add(this.cmbRepositoryType);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(22, 77);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1092, 284);
            this.groupBox4.TabIndex = 84;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Backup Repository";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 67;
            this.label15.Text = "Repository Type:";
            // 
            // pnlRepository
            // 
            this.pnlRepository.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRepository.Location = new System.Drawing.Point(9, 71);
            this.pnlRepository.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRepository.Name = "pnlRepository";
            this.pnlRepository.Size = new System.Drawing.Size(1005, 200);
            this.pnlRepository.TabIndex = 66;
            // 
            // cmbRepositoryType
            // 
            this.cmbRepositoryType.DisplayMember = "Description";
            this.cmbRepositoryType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRepositoryType.FormattingEnabled = true;
            this.cmbRepositoryType.Location = new System.Drawing.Point(9, 37);
            this.cmbRepositoryType.Name = "cmbRepositoryType";
            this.cmbRepositoryType.Size = new System.Drawing.Size(101, 21);
            this.cmbRepositoryType.TabIndex = 68;
            this.cmbRepositoryType.ValueMember = "Value";
            // 
            // ucSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "ucSettings";
            this.Size = new System.Drawing.Size(1350, 633);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnlRepository;
        internal System.Windows.Forms.ComboBox cmbRepositoryType;
    }
}
