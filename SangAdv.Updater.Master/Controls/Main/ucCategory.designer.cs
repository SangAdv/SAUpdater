namespace SangAdv.Updater.Master
{
    partial class ucCategory
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvwCategories = new System.Windows.Forms.ListView();
            this.lblAppHeader = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.txtCategory);
            this.Panel1.Controls.Add(this.btnAdd);
            this.Panel1.Controls.Add(this.btnCancel);
            this.Panel1.Controls.Add(this.lvwCategories);
            this.Panel1.Controls.Add(this.lblAppHeader);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1020, 587);
            this.Panel1.TabIndex = 1;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(409, 52);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(56, 13);
            this.Label7.TabIndex = 45;
            this.Label7.Text = "Category:";
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(412, 68);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(579, 22);
            this.txtCategory.TabIndex = 44;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(916, 108);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(916, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvwCategories
            // 
            this.lvwCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwCategories.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCategories.Location = new System.Drawing.Point(23, 52);
            this.lvwCategories.MultiSelect = false;
            this.lvwCategories.Name = "lvwCategories";
            this.lvwCategories.Size = new System.Drawing.Size(358, 513);
            this.lvwCategories.TabIndex = 41;
            this.lvwCategories.UseCompatibleStateImageBehavior = false;
            this.lvwCategories.View = System.Windows.Forms.View.List;
            this.lvwCategories.Click += new System.EventHandler(this.lvwCategories_Click);
            // 
            // lblAppHeader
            // 
            this.lblAppHeader.AutoSize = true;
            this.lblAppHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppHeader.Location = new System.Drawing.Point(24, 23);
            this.lblAppHeader.Name = "lblAppHeader";
            this.lblAppHeader.Size = new System.Drawing.Size(125, 17);
            this.lblAppHeader.TabIndex = 7;
            this.lblAppHeader.Text = "Manage Categories";
            // 
            // ucCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel1);
            this.Name = "ucCategory";
            this.Size = new System.Drawing.Size(1020, 587);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtCategory;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.ListView lvwCategories;
        internal System.Windows.Forms.Label lblAppHeader;
    }
}
