namespace SangAdv.Updater.Master
{
    partial class ucAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAbout));
            this.pnlAbout = new System.Windows.Forms.Panel();
            this.llSanguineAdv = new System.Windows.Forms.LinkLabel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAbout
            // 
            this.pnlAbout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAbout.Controls.Add(this.llSanguineAdv);
            this.pnlAbout.Controls.Add(this.Label1);
            this.pnlAbout.Controls.Add(this.Label4);
            this.pnlAbout.Controls.Add(this.lblVersion);
            this.pnlAbout.Controls.Add(this.Label2);
            this.pnlAbout.Controls.Add(this.PictureBox1);
            this.pnlAbout.Location = new System.Drawing.Point(100, 19);
            this.pnlAbout.Name = "pnlAbout";
            this.pnlAbout.Size = new System.Drawing.Size(700, 531);
            this.pnlAbout.TabIndex = 1;
            // 
            // llSanguineAdv
            // 
            this.llSanguineAdv.AutoSize = true;
            this.llSanguineAdv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.llSanguineAdv.Location = new System.Drawing.Point(163, 120);
            this.llSanguineAdv.Name = "llSanguineAdv";
            this.llSanguineAdv.Size = new System.Drawing.Size(263, 15);
            this.llSanguineAdv.TabIndex = 7;
            this.llSanguineAdv.TabStop = true;
            this.llSanguineAdv.Text = "Copyright (c) 2015 Sanguine Advantage PTY LTD";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.Label1.Location = new System.Drawing.Point(160, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(186, 25);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Sanguine Advantage";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.Label4.Location = new System.Drawing.Point(163, 260);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(457, 247);
            this.Label4.TabIndex = 4;
            this.Label4.Text = resources.GetString("Label4.Text");
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.lblVersion.Location = new System.Drawing.Point(160, 78);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(64, 25);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "0.1.0.0";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.Label2.Location = new System.Drawing.Point(157, 31);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(135, 45);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Updater";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::SangAdv.Updater.Master.Properties.Resources.SAUpdater_128;
            this.PictureBox1.Location = new System.Drawing.Point(16, 8);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(128, 128);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // ucAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlAbout);
            this.Name = "ucAbout";
            this.Size = new System.Drawing.Size(900, 579);
            this.Resize += new System.EventHandler(this.ucAbout_Resize);
            this.pnlAbout.ResumeLayout(false);
            this.pnlAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlAbout;
        internal System.Windows.Forms.LinkLabel llSanguineAdv;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}
