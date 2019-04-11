namespace SangAdv.Updater.Client
{
    partial class SAUpdaterVersionNotes
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
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbNotes
            // 
            this.rtbNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNotes.Location = new System.Drawing.Point(0, 0);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(865, 546);
            this.rtbNotes.TabIndex = 0;
            this.rtbNotes.Text = "";
            // 
            // SAVersionNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbNotes);
            this.Name = "SAVersionNotes";
            this.Size = new System.Drawing.Size(865, 546);
            this.Load += new System.EventHandler(this.SAVersionNotes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNotes;
    }
}
