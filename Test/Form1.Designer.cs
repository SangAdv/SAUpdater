namespace Test
{
    partial class Form1
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
            this.btnDoUpdate = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMinus = new System.Windows.Forms.Label();
            this.btnMinus = new System.Windows.Forms.Button();
            this.lblSum = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.btnSum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoUpdate
            // 
            this.btnDoUpdate.Location = new System.Drawing.Point(12, 304);
            this.btnDoUpdate.Name = "btnDoUpdate";
            this.btnDoUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnDoUpdate.TabIndex = 15;
            this.btnDoUpdate.Text = "Update";
            this.btnDoUpdate.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(9, 427);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.Text = "label1";
            // 
            // lblMinus
            // 
            this.lblMinus.AutoSize = true;
            this.lblMinus.Location = new System.Drawing.Point(152, 157);
            this.lblMinus.Name = "lblMinus";
            this.lblMinus.Size = new System.Drawing.Size(35, 13);
            this.lblMinus.TabIndex = 13;
            this.lblMinus.Text = "label1";
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(12, 152);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(75, 23);
            this.btnMinus.TabIndex = 12;
            this.btnMinus.Text = "Subtract";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(152, 99);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(35, 13);
            this.lblSum.TabIndex = 11;
            this.lblSum.Text = "label1";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(155, 42);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 20);
            this.txtB.TabIndex = 10;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(12, 42);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 20);
            this.txtA.TabIndex = 9;
            // 
            // btnSum
            // 
            this.btnSum.Location = new System.Drawing.Point(12, 94);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(75, 23);
            this.btnSum.TabIndex = 8;
            this.btnSum.Text = "Sum";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDoUpdate);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblMinus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.btnSum);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoUpdate;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblMinus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Button btnSum;
    }
}

