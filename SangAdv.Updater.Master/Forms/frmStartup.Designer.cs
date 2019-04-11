namespace SangAdv.Updater.Master
{
    partial class frmStartup
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
            this.llSanguineAdv = new System.Windows.Forms.LinkLabel();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // llSanguineAdv
            // 
            this.llSanguineAdv.AutoSize = true;
            this.llSanguineAdv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.llSanguineAdv.Location = new System.Drawing.Point(270, 162);
            this.llSanguineAdv.Name = "llSanguineAdv";
            this.llSanguineAdv.Size = new System.Drawing.Size(263, 15);
            this.llSanguineAdv.TabIndex = 11;
            this.llSanguineAdv.TabStop = true;
            this.llSanguineAdv.Text = "Copyright (c) 2015 Sanguine Advantage PTY LTD";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.Label1.Location = new System.Drawing.Point(267, 50);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(186, 25);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Sanguine Advantage";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.lblVersion.Location = new System.Drawing.Point(267, 120);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(64, 25);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "0.1.0.0";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.Label2.Location = new System.Drawing.Point(264, 73);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(135, 45);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Updater";
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(361, 404);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 12;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.lblMessage.Location = new System.Drawing.Point(116, 309);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(93, 21);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "lblMessage";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::SangAdv.Updater.Master.Properties.Resources.SAUpdater_128;
            this.PictureBox1.Location = new System.Drawing.Point(121, 50);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(128, 128);
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(121, 333);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Do Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.llSanguineAdv);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.PictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmStartup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.frmStartup_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.LinkLabel llSanguineAdv;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnContinue;
        internal System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnUpdate;
    }
}