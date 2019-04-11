namespace SangAdv.Updater.Master
{
    partial class frmNewApplication
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
            this.btnAppAdd = new System.Windows.Forms.Button();
            this.btnAppCancel = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblCreatedOn = new System.Windows.Forms.Label();
            this.txtAppDescription = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAppAdd
            // 
            this.btnAppAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppAdd.Location = new System.Drawing.Point(520, 123);
            this.btnAppAdd.Name = "btnAppAdd";
            this.btnAppAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAppAdd.TabIndex = 14;
            this.btnAppAdd.Text = "Add";
            this.btnAppAdd.UseVisualStyleBackColor = true;
            this.btnAppAdd.Click += new System.EventHandler(this.btnAppAdd_Click);
            // 
            // btnAppCancel
            // 
            this.btnAppCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppCancel.Location = new System.Drawing.Point(601, 123);
            this.btnAppCancel.Name = "btnAppCancel";
            this.btnAppCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAppCancel.TabIndex = 13;
            this.btnAppCancel.Text = "Cancel";
            this.btnAppCancel.UseVisualStyleBackColor = true;
            this.btnAppCancel.Click += new System.EventHandler(this.btnAppCancel_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(12, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "Description:";
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.AutoSize = true;
            this.lblCreatedOn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedOn.Location = new System.Drawing.Point(78, 50);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(90, 13);
            this.lblCreatedOn.TabIndex = 20;
            this.lblCreatedOn.Text = "Created on date";
            // 
            // txtAppDescription
            // 
            this.txtAppDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppDescription.Location = new System.Drawing.Point(15, 25);
            this.txtAppDescription.Name = "txtAppDescription";
            this.txtAppDescription.Size = new System.Drawing.Size(661, 22);
            this.txtAppDescription.TabIndex = 18;
            this.txtAppDescription.TextChanged += new System.EventHandler(this.txtAppDescription_TextChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(12, 50);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(67, 13);
            this.Label5.TabIndex = 19;
            this.Label5.Text = "Created on:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DisplayMember = "CategoryDesc";
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(15, 93);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(339, 21);
            this.cmbCategory.TabIndex = 16;
            this.cmbCategory.ValueMember = "ID";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 77);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Category:";
            // 
            // frmNewApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 158);
            this.ControlBox = false;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblCreatedOn);
            this.Controls.Add(this.txtAppDescription);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnAppAdd);
            this.Controls.Add(this.btnAppCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNewApplication";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Application ...";
            this.Shown += new System.EventHandler(this.frmNewApplication_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btnAppAdd;
        internal System.Windows.Forms.Button btnAppCancel;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblCreatedOn;
        internal System.Windows.Forms.TextBox txtAppDescription;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label Label1;
    }
}