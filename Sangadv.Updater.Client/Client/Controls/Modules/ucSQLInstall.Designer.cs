namespace SangAdv.Updater.Client
{
    partial class ucSQLInstall
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
            this.txtPWord = new System.Windows.Forms.TextBox();
            this.txtUName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cmbAuth = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblSQLMessage = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPWord
            // 
            this.txtPWord.Location = new System.Drawing.Point(198, 170);
            this.txtPWord.Name = "txtPWord";
            this.txtPWord.PasswordChar = '*';
            this.txtPWord.Size = new System.Drawing.Size(273, 22);
            this.txtPWord.TabIndex = 71;
            // 
            // txtUName
            // 
            this.txtUName.Location = new System.Drawing.Point(198, 142);
            this.txtUName.Name = "txtUName";
            this.txtUName.Size = new System.Drawing.Size(273, 22);
            this.txtUName.TabIndex = 70;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(132, 170);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(60, 17);
            this.Label5.TabIndex = 69;
            this.Label5.Text = "Password:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(122, 142);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 17);
            this.Label4.TabIndex = 68;
            this.Label4.Text = "User name:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(101, 111);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(91, 17);
            this.Label3.TabIndex = 67;
            this.Label3.Text = "Authentication:";
            // 
            // cmbAuth
            // 
            this.cmbAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuth.FormattingEnabled = true;
            this.cmbAuth.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cmbAuth.Location = new System.Drawing.Point(198, 111);
            this.cmbAuth.Name = "cmbAuth";
            this.cmbAuth.Size = new System.Drawing.Size(273, 21);
            this.cmbAuth.TabIndex = 66;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Red;
            this.Label2.Location = new System.Drawing.Point(195, 81);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(365, 15);
            this.Label2.TabIndex = 65;
            this.Label2.Text = "MS SQL Server 2012 or later is required as a locally installed instance.";
            // 
            // lblSQLMessage
            // 
            this.lblSQLMessage.AutoSize = true;
            this.lblSQLMessage.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQLMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSQLMessage.Location = new System.Drawing.Point(195, 59);
            this.lblSQLMessage.Name = "lblSQLMessage";
            this.lblSQLMessage.Size = new System.Drawing.Size(226, 15);
            this.lblSQLMessage.TabIndex = 64;
            this.lblSQLMessage.Text = "eg, default for SQL Express is .\\SQLExpress";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(119, 38);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 17);
            this.Label1.TabIndex = 63;
            this.Label1.Text = "SQL Server:";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(43, 229);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(44, 17);
            this.lblProgress.TabIndex = 62;
            this.lblProgress.Text = "Label1";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(43, 257);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(46, 17);
            this.lblMessage.TabIndex = 61;
            this.lblMessage.Text = "Label1";
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(198, 38);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(273, 21);
            this.cmbServer.TabIndex = 60;
            // 
            // btnAction
            // 
            this.btnAction.Enabled = false;
            this.btnAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.Image = global::SangAdv.Updater.Client.Properties.Resources.install_16px;
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAction.Location = new System.Drawing.Point(588, 271);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(82, 24);
            this.btnAction.TabIndex = 59;
            this.btnAction.Text = "Install";
            this.btnAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.UseVisualStyleBackColor = true;
            // 
            // ucSQLInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPWord);
            this.Controls.Add(this.txtUName);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cmbAuth);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblSQLMessage);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmbServer);
            this.Controls.Add(this.btnAction);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucSQLInstall";
            this.Size = new System.Drawing.Size(700, 319);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtPWord;
        internal System.Windows.Forms.TextBox txtUName;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cmbAuth;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblSQLMessage;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblProgress;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.ComboBox cmbServer;
        internal System.Windows.Forms.Button btnAction;
    }
}
