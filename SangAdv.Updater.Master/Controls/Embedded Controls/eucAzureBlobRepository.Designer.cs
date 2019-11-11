namespace SangAdv.Updater.Master
{
    partial class eucAzureBlobRepository
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
            this.Label9 = new System.Windows.Forms.Label();
            this.txtAzureBlobConnectionString = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApplicationFolder = new System.Windows.Forms.TextBox();
            this.txtAzureBlobDownloadUri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAzureBlobCotainerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(0, 1);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(267, 19);
            this.Label9.TabIndex = 50;
            this.Label9.Text = "Azure Blob Storage Connection String:";
            // 
            // txtAzureBlobConnectionString
            // 
            this.txtAzureBlobConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzureBlobConnectionString.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAzureBlobConnectionString.Location = new System.Drawing.Point(2, 17);
            this.txtAzureBlobConnectionString.Name = "txtAzureBlobConnectionString";
            this.txtAzureBlobConnectionString.Size = new System.Drawing.Size(558, 26);
            this.txtAzureBlobConnectionString.TabIndex = 51;
            this.txtAzureBlobConnectionString.TextChanged += new System.EventHandler(this.txtAzureBlobConnectionString_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(0, 101);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(551, 19);
            this.Label3.TabIndex = 54;
            this.Label3.Text = "Azure Blob Storage Download URL (eg. HTTP://www.contosa.com/applications/):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 19);
            this.label1.TabIndex = 52;
            this.label1.Text = "Application Folder:";
            // 
            // txtApplicationFolder
            // 
            this.txtApplicationFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationFolder.Location = new System.Drawing.Point(2, 168);
            this.txtApplicationFolder.Name = "txtApplicationFolder";
            this.txtApplicationFolder.Size = new System.Drawing.Size(686, 26);
            this.txtApplicationFolder.TabIndex = 53;
            this.txtApplicationFolder.TextChanged += new System.EventHandler(this.txtApplicationFolder_TextChanged);
            // 
            // txtAzureBlobDownloadUri
            // 
            this.txtAzureBlobDownloadUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzureBlobDownloadUri.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAzureBlobDownloadUri.Location = new System.Drawing.Point(2, 117);
            this.txtAzureBlobDownloadUri.Name = "txtAzureBlobDownloadUri";
            this.txtAzureBlobDownloadUri.Size = new System.Drawing.Size(558, 26);
            this.txtAzureBlobDownloadUri.TabIndex = 55;
            this.txtAzureBlobDownloadUri.TextChanged += new System.EventHandler(this.txtAzureBlobDownloadUri_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 19);
            this.label2.TabIndex = 56;
            this.label2.Text = "Azure Blob Storage Cotainer Name:";
            // 
            // txtAzureBlobCotainerName
            // 
            this.txtAzureBlobCotainerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzureBlobCotainerName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAzureBlobCotainerName.Location = new System.Drawing.Point(3, 68);
            this.txtAzureBlobCotainerName.Name = "txtAzureBlobCotainerName";
            this.txtAzureBlobCotainerName.Size = new System.Drawing.Size(238, 26);
            this.txtAzureBlobCotainerName.TabIndex = 57;
            this.txtAzureBlobCotainerName.TextChanged += new System.EventHandler(this.txtAzureBlobCotainerName_TextChanged);
            // 
            // eucAzureBlobRepository
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAzureBlobCotainerName);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtApplicationFolder);
            this.Controls.Add(this.txtAzureBlobDownloadUri);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtAzureBlobConnectionString);
            this.Name = "eucAzureBlobRepository";
            this.Controls.SetChildIndex(this.txtAzureBlobConnectionString, 0);
            this.Controls.SetChildIndex(this.Label9, 0);
            this.Controls.SetChildIndex(this.txtAzureBlobDownloadUri, 0);
            this.Controls.SetChildIndex(this.txtApplicationFolder, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Label3, 0);
            this.Controls.SetChildIndex(this.txtAzureBlobCotainerName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtAzureBlobConnectionString;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtApplicationFolder;
        private System.Windows.Forms.TextBox txtAzureBlobDownloadUri;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtAzureBlobCotainerName;
    }
}
