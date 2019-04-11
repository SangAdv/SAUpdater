    namespace SangAdv.Updater.Master
{
    partial class eucSAUpdaterProgressBar
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
            this.pnlPBOuter = new System.Windows.Forms.Panel();
            this.pnlMarqueeTail = new System.Windows.Forms.Panel();
            this.pnlPBInner = new System.Windows.Forms.Panel();
            this.pnlPBOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPBOuter
            // 
            this.pnlPBOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPBOuter.BackColor = System.Drawing.Color.DarkGray;
            this.pnlPBOuter.Controls.Add(this.pnlMarqueeTail);
            this.pnlPBOuter.Controls.Add(this.pnlPBInner);
            this.pnlPBOuter.ForeColor = System.Drawing.Color.Gray;
            this.pnlPBOuter.Location = new System.Drawing.Point(0, 0);
            this.pnlPBOuter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPBOuter.Name = "pnlPBOuter";
            this.pnlPBOuter.Size = new System.Drawing.Size(622, 8);
            this.pnlPBOuter.TabIndex = 55;
            // 
            // pnlMarqueeTail
            // 
            this.pnlMarqueeTail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMarqueeTail.BackColor = System.Drawing.Color.Red;
            this.pnlMarqueeTail.Location = new System.Drawing.Point(0, 0);
            this.pnlMarqueeTail.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMarqueeTail.Name = "pnlMarqueeTail";
            this.pnlMarqueeTail.Size = new System.Drawing.Size(85, 8);
            this.pnlMarqueeTail.TabIndex = 51;
            // 
            // pnlPBInner
            // 
            this.pnlPBInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPBInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.pnlPBInner.Location = new System.Drawing.Point(0, 0);
            this.pnlPBInner.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPBInner.Name = "pnlPBInner";
            this.pnlPBInner.Size = new System.Drawing.Size(371, 8);
            this.pnlPBInner.TabIndex = 50;
            // 
            // eucSAUpdaterProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPBOuter);
            this.Name = "eucSAUpdaterProgressBar";
            this.Size = new System.Drawing.Size(622, 8);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.eucSAUpdaterProgressBar_Paint);
            this.pnlPBOuter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlPBOuter;
        internal System.Windows.Forms.Panel pnlPBInner;
        internal System.Windows.Forms.Panel pnlMarqueeTail;
    }
}
