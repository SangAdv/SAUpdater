namespace SangAdv.Updater.Master
{
    partial class frmPublishVersion
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
            this.components = new System.ComponentModel.Container();
            this.Label4 = new System.Windows.Forms.Label();
            this.cmbReleaseVersion = new System.Windows.Forms.ComboBox();
            this.comboBoxItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPreReleaseVersion = new System.Windows.Forms.ComboBox();
            this.cmbPreReleaseType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUploadInstaller = new System.Windows.Forms.Button();
            this.lblCurrentInstallerVersion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInstallerSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelectedInstallerVersion = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxItemBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(6, 21);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(89, 13);
            this.Label4.TabIndex = 60;
            this.Label4.Text = "Release Version:";
            // 
            // cmbReleaseVersion
            // 
            this.cmbReleaseVersion.DataSource = this.comboBoxItemBindingSource;
            this.cmbReleaseVersion.DisplayMember = "Description";
            this.cmbReleaseVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReleaseVersion.FormattingEnabled = true;
            this.cmbReleaseVersion.Location = new System.Drawing.Point(6, 37);
            this.cmbReleaseVersion.Name = "cmbReleaseVersion";
            this.cmbReleaseVersion.Size = new System.Drawing.Size(89, 21);
            this.cmbReleaseVersion.TabIndex = 59;
            this.cmbReleaseVersion.ValueMember = "Value";
            // 
            // comboBoxItemBindingSource
            // 
            this.comboBoxItemBindingSource.DataSource = typeof(SangAdv.Updater.Master.ComboBoxItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Pre-release Version:";
            // 
            // cmbPreReleaseVersion
            // 
            this.cmbPreReleaseVersion.DataSource = this.comboBoxItemBindingSource;
            this.cmbPreReleaseVersion.DisplayMember = "Description";
            this.cmbPreReleaseVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPreReleaseVersion.FormattingEnabled = true;
            this.cmbPreReleaseVersion.Location = new System.Drawing.Point(6, 80);
            this.cmbPreReleaseVersion.Name = "cmbPreReleaseVersion";
            this.cmbPreReleaseVersion.Size = new System.Drawing.Size(89, 21);
            this.cmbPreReleaseVersion.TabIndex = 63;
            this.cmbPreReleaseVersion.ValueMember = "Value";
            // 
            // cmbPreReleaseType
            // 
            this.cmbPreReleaseType.DataSource = this.comboBoxItemBindingSource;
            this.cmbPreReleaseType.DisplayMember = "Description";
            this.cmbPreReleaseType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPreReleaseType.FormattingEnabled = true;
            this.cmbPreReleaseType.Location = new System.Drawing.Point(101, 80);
            this.cmbPreReleaseType.Name = "cmbPreReleaseType";
            this.cmbPreReleaseType.Size = new System.Drawing.Size(58, 21);
            this.cmbPreReleaseType.TabIndex = 65;
            this.cmbPreReleaseType.ValueMember = "Value";
            this.cmbPreReleaseType.SelectedIndexChanged += new System.EventHandler(this.cmbPreReleaseType_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(531, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPublish.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublish.Location = new System.Drawing.Point(450, 284);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(75, 23);
            this.btnPublish.TabIndex = 67;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblSelectedInstallerVersion);
            this.groupBox2.Controls.Add(this.btnInstallerSelect);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnUploadInstaller);
            this.groupBox2.Controls.Add(this.lblCurrentInstallerVersion);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 110);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Installer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Published Version:";
            // 
            // btnUploadInstaller
            // 
            this.btnUploadInstaller.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadInstaller.Location = new System.Drawing.Point(84, 72);
            this.btnUploadInstaller.Name = "btnUploadInstaller";
            this.btnUploadInstaller.Size = new System.Drawing.Size(75, 23);
            this.btnUploadInstaller.TabIndex = 78;
            this.btnUploadInstaller.Text = "Upload";
            this.btnUploadInstaller.UseVisualStyleBackColor = true;
            this.btnUploadInstaller.Click += new System.EventHandler(this.btnUploadInstaller_Click);
            // 
            // lblCurrentInstallerVersion
            // 
            this.lblCurrentInstallerVersion.AutoSize = true;
            this.lblCurrentInstallerVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentInstallerVersion.Location = new System.Drawing.Point(114, 21);
            this.lblCurrentInstallerVersion.Name = "lblCurrentInstallerVersion";
            this.lblCurrentInstallerVersion.Size = new System.Drawing.Size(40, 13);
            this.lblCurrentInstallerVersion.TabIndex = 77;
            this.lblCurrentInstallerVersion.Text = "2.0.0.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label4);
            this.groupBox1.Controls.Add(this.cmbReleaseVersion);
            this.groupBox1.Controls.Add(this.cmbPreReleaseVersion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPreReleaseType);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 111);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application";
            // 
            // btnInstallerSelect
            // 
            this.btnInstallerSelect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallerSelect.Location = new System.Drawing.Point(6, 72);
            this.btnInstallerSelect.Name = "btnInstallerSelect";
            this.btnInstallerSelect.Size = new System.Drawing.Size(75, 23);
            this.btnInstallerSelect.TabIndex = 79;
            this.btnInstallerSelect.Text = "Select ...";
            this.btnInstallerSelect.UseVisualStyleBackColor = true;
            this.btnInstallerSelect.Click += new System.EventHandler(this.btnInstallerSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Selected Version:";
            // 
            // lblSelectedInstallerVersion
            // 
            this.lblSelectedInstallerVersion.AutoSize = true;
            this.lblSelectedInstallerVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedInstallerVersion.Location = new System.Drawing.Point(114, 46);
            this.lblSelectedInstallerVersion.Name = "lblSelectedInstallerVersion";
            this.lblSelectedInstallerVersion.Size = new System.Drawing.Size(40, 13);
            this.lblSelectedInstallerVersion.TabIndex = 81;
            this.lblSelectedInstallerVersion.Text = "2.0.0.0";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(9, 267);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 13);
            this.lblMessage.TabIndex = 84;
            this.lblMessage.Text = "lblMessage";
            // 
            // frmPublishVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 319);
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPublish);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPublishVersion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Publish Version ...";
            this.Shown += new System.EventHandler(this.frmPublishVersion_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxItemBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cmbReleaseVersion;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbPreReleaseVersion;
        internal System.Windows.Forms.ComboBox cmbPreReleaseType;
        private System.Windows.Forms.BindingSource comboBoxItemBindingSource;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnUploadInstaller;
        internal System.Windows.Forms.Label lblCurrentInstallerVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblSelectedInstallerVersion;
        internal System.Windows.Forms.Button btnInstallerSelect;
        internal System.Windows.Forms.Label lblMessage;
    }
}