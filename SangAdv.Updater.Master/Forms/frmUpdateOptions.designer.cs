namespace SangAdv.Updater.Master
{
    partial class frmUpdateOptions
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.cmbUpdateOptions = new System.Windows.Forms.ComboBox();
            this.keyValuePairBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.keyValuePairBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(10, 93);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 62;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(7, 77);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(110, 13);
            this.lblInput.TabIndex = 61;
            this.lblInput.Text = "Application Version:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(202, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(121, 222);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 59;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(10, 15);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(91, 13);
            this.Label4.TabIndex = 58;
            this.Label4.Text = "Update Options:";
            // 
            // cmbUpdateOptions
            // 
            this.cmbUpdateOptions.DataSource = this.keyValuePairBindingSource;
            this.cmbUpdateOptions.DisplayMember = "Name";
            this.cmbUpdateOptions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUpdateOptions.FormattingEnabled = true;
            this.cmbUpdateOptions.Location = new System.Drawing.Point(10, 31);
            this.cmbUpdateOptions.Name = "cmbUpdateOptions";
            this.cmbUpdateOptions.Size = new System.Drawing.Size(261, 21);
            this.cmbUpdateOptions.TabIndex = 57;
            this.cmbUpdateOptions.ValueMember = "Value";
            this.cmbUpdateOptions.SelectedIndexChanged += new System.EventHandler(this.cmbUpdateOptions_SelectedIndexChanged);
            // 
            // keyValuePairBindingSource
            // 
            this.keyValuePairBindingSource.DataSource = typeof(EnumFunctions.KeyValuePair);
            // 
            // frmUpdateOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cmbUpdateOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUpdateOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Options";
            this.Load += new System.EventHandler(this.frmUpdateOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.keyValuePairBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtInput;
        internal System.Windows.Forms.Label lblInput;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cmbUpdateOptions;
        private System.Windows.Forms.BindingSource keyValuePairBindingSource;
    }
}