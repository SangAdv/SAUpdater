namespace SangAdv.Updater.Master
{
    partial class ucFiles
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFiles));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblUpdateFolder = new System.Windows.Forms.Label();
            this.chkInclude = new System.Windows.Forms.CheckBox();
            this.lblAppFileHeader = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReferenceFile = new System.Windows.Forms.TextBox();
            this.btnAddRefFiles = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnUnsetShortcut = new System.Windows.Forms.Button();
            this.btnSetShortcut = new System.Windows.Forms.Button();
            this.btnIncludeFiles = new System.Windows.Forms.Button();
            this.btnExcludeFiles = new System.Windows.Forms.Button();
            this.btnDelAllFiles = new System.Windows.Forms.Button();
            this.btnDelFiles = new System.Windows.Forms.Button();
            this.btnDirUpdate = new System.Windows.Forms.Button();
            this.cmbDirectories = new System.Windows.Forms.ComboBox();
            this.comboBoxItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.lvwAppFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlGeneral = new System.Windows.Forms.ImageList(this.components);
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.lblUpdateFolder);
            this.Panel1.Controls.Add(this.chkInclude);
            this.Panel1.Controls.Add(this.lblAppFileHeader);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Controls.Add(this.lvwAppFiles);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1149, 607);
            this.Panel1.TabIndex = 1;
            // 
            // lblUpdateFolder
            // 
            this.lblUpdateFolder.AutoSize = true;
            this.lblUpdateFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateFolder.Location = new System.Drawing.Point(13, 32);
            this.lblUpdateFolder.Name = "lblUpdateFolder";
            this.lblUpdateFolder.Size = new System.Drawing.Size(124, 13);
            this.lblUpdateFolder.TabIndex = 56;
            this.lblUpdateFolder.Text = "Update folder location";
            // 
            // chkInclude
            // 
            this.chkInclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInclude.AutoSize = true;
            this.chkInclude.Checked = true;
            this.chkInclude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInclude.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.chkInclude.Location = new System.Drawing.Point(872, 40);
            this.chkInclude.Name = "chkInclude";
            this.chkInclude.Size = new System.Drawing.Size(156, 17);
            this.chkInclude.TabIndex = 41;
            this.chkInclude.Text = "Show Included Files Only";
            this.chkInclude.UseVisualStyleBackColor = true;
            this.chkInclude.CheckedChanged += new System.EventHandler(this.chkInclude_CheckedChanged);
            // 
            // lblAppFileHeader
            // 
            this.lblAppFileHeader.AutoSize = true;
            this.lblAppFileHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFileHeader.Location = new System.Drawing.Point(13, 10);
            this.lblAppFileHeader.Name = "lblAppFileHeader";
            this.lblAppFileHeader.Size = new System.Drawing.Size(109, 17);
            this.lblAppFileHeader.TabIndex = 40;
            this.lblAppFileHeader.Text = "Application Files:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.txtReferenceFile);
            this.GroupBox1.Controls.Add(this.btnAddRefFiles);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.btnUnsetShortcut);
            this.GroupBox1.Controls.Add(this.btnSetShortcut);
            this.GroupBox1.Controls.Add(this.btnIncludeFiles);
            this.GroupBox1.Controls.Add(this.btnExcludeFiles);
            this.GroupBox1.Controls.Add(this.btnDelAllFiles);
            this.GroupBox1.Controls.Add(this.btnDelFiles);
            this.GroupBox1.Controls.Add(this.btnDirUpdate);
            this.GroupBox1.Controls.Add(this.cmbDirectories);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btnAddFiles);
            this.GroupBox1.Location = new System.Drawing.Point(859, 63);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(274, 527);
            this.GroupBox1.TabIndex = 39;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Application Files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Reference File:";
            // 
            // txtReferenceFile
            // 
            this.txtReferenceFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceFile.Location = new System.Drawing.Point(7, 366);
            this.txtReferenceFile.Name = "txtReferenceFile";
            this.txtReferenceFile.Size = new System.Drawing.Size(261, 22);
            this.txtReferenceFile.TabIndex = 55;
            this.txtReferenceFile.TextChanged += new System.EventHandler(this.txtReferenceFile_TextChanged);
            // 
            // btnAddRefFiles
            // 
            this.btnAddRefFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRefFiles.Enabled = false;
            this.btnAddRefFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddRefFiles.Location = new System.Drawing.Point(7, 394);
            this.btnAddRefFiles.Name = "btnAddRefFiles";
            this.btnAddRefFiles.Size = new System.Drawing.Size(116, 23);
            this.btnAddRefFiles.TabIndex = 54;
            this.btnAddRefFiles.Text = "Add Reference File ...";
            this.btnAddRefFiles.UseVisualStyleBackColor = true;
            this.btnAddRefFiles.Click += new System.EventHandler(this.btnAddRefFiles_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(7, 148);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(89, 13);
            this.Label3.TabIndex = 48;
            this.Label3.Text = "Include Options:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(7, 82);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(94, 13);
            this.Label2.TabIndex = 47;
            this.Label2.Text = "Shortcut options:";
            // 
            // btnUnsetShortcut
            // 
            this.btnUnsetShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnsetShortcut.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnUnsetShortcut.Location = new System.Drawing.Point(151, 98);
            this.btnUnsetShortcut.Name = "btnUnsetShortcut";
            this.btnUnsetShortcut.Size = new System.Drawing.Size(117, 23);
            this.btnUnsetShortcut.TabIndex = 46;
            this.btnUnsetShortcut.Text = "Unset Shortcut";
            this.btnUnsetShortcut.UseVisualStyleBackColor = true;
            this.btnUnsetShortcut.Click += new System.EventHandler(this.btnUnsetShortcut_Click);
            // 
            // btnSetShortcut
            // 
            this.btnSetShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetShortcut.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSetShortcut.Location = new System.Drawing.Point(7, 98);
            this.btnSetShortcut.Name = "btnSetShortcut";
            this.btnSetShortcut.Size = new System.Drawing.Size(117, 23);
            this.btnSetShortcut.TabIndex = 45;
            this.btnSetShortcut.Text = "Set Shortcut";
            this.btnSetShortcut.UseVisualStyleBackColor = true;
            this.btnSetShortcut.Click += new System.EventHandler(this.btnSetShortcut_Click);
            // 
            // btnIncludeFiles
            // 
            this.btnIncludeFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnIncludeFiles.Location = new System.Drawing.Point(7, 164);
            this.btnIncludeFiles.Name = "btnIncludeFiles";
            this.btnIncludeFiles.Size = new System.Drawing.Size(116, 23);
            this.btnIncludeFiles.TabIndex = 44;
            this.btnIncludeFiles.Text = "Include Files";
            this.btnIncludeFiles.UseVisualStyleBackColor = true;
            this.btnIncludeFiles.Click += new System.EventHandler(this.btnIncludeFiles_Click);
            // 
            // btnExcludeFiles
            // 
            this.btnExcludeFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnExcludeFiles.Location = new System.Drawing.Point(151, 164);
            this.btnExcludeFiles.Name = "btnExcludeFiles";
            this.btnExcludeFiles.Size = new System.Drawing.Size(117, 23);
            this.btnExcludeFiles.TabIndex = 43;
            this.btnExcludeFiles.Text = "Exclude Files";
            this.btnExcludeFiles.UseVisualStyleBackColor = true;
            this.btnExcludeFiles.Click += new System.EventHandler(this.btnExcludeFiles_Click);
            // 
            // btnDelAllFiles
            // 
            this.btnDelAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelAllFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnDelAllFiles.Location = new System.Drawing.Point(151, 19);
            this.btnDelAllFiles.Name = "btnDelAllFiles";
            this.btnDelAllFiles.Size = new System.Drawing.Size(117, 23);
            this.btnDelAllFiles.TabIndex = 42;
            this.btnDelAllFiles.Text = "Delete All Files";
            this.btnDelAllFiles.UseVisualStyleBackColor = true;
            this.btnDelAllFiles.Click += new System.EventHandler(this.btnDelAllFiles_Click);
            // 
            // btnDelFiles
            // 
            this.btnDelFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnDelFiles.Location = new System.Drawing.Point(151, 48);
            this.btnDelFiles.Name = "btnDelFiles";
            this.btnDelFiles.Size = new System.Drawing.Size(117, 23);
            this.btnDelFiles.TabIndex = 41;
            this.btnDelFiles.Text = "Delete Checked Files";
            this.btnDelFiles.UseVisualStyleBackColor = true;
            this.btnDelFiles.Click += new System.EventHandler(this.btnDelFiles_Click);
            // 
            // btnDirUpdate
            // 
            this.btnDirUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnDirUpdate.Location = new System.Drawing.Point(7, 281);
            this.btnDirUpdate.Name = "btnDirUpdate";
            this.btnDirUpdate.Size = new System.Drawing.Size(116, 23);
            this.btnDirUpdate.TabIndex = 40;
            this.btnDirUpdate.Text = "Update Folder";
            this.btnDirUpdate.UseVisualStyleBackColor = true;
            this.btnDirUpdate.Click += new System.EventHandler(this.btnDirUpdate_Click);
            // 
            // cmbDirectories
            // 
            this.cmbDirectories.DataSource = this.comboBoxItemBindingSource;
            this.cmbDirectories.DisplayMember = "Description";
            this.cmbDirectories.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDirectories.FormattingEnabled = true;
            this.cmbDirectories.Location = new System.Drawing.Point(7, 253);
            this.cmbDirectories.Name = "cmbDirectories";
            this.cmbDirectories.Size = new System.Drawing.Size(261, 21);
            this.cmbDirectories.TabIndex = 39;
            this.cmbDirectories.ValueMember = "Value";
            // 
            // comboBoxItemBindingSource
            // 
            this.comboBoxItemBindingSource.DataSource = typeof(SangAdv.Updater.Master.ComboBoxItem);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(7, 237);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(142, 13);
            this.Label1.TabIndex = 38;
            this.Label1.Text = "Installation folder update:";
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddFiles.Location = new System.Drawing.Point(7, 19);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(116, 23);
            this.btnAddFiles.TabIndex = 37;
            this.btnAddFiles.Text = "Add Files ...";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // lvwAppFiles
            // 
            this.lvwAppFiles.AllowDrop = true;
            this.lvwAppFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAppFiles.CheckBoxes = true;
            this.lvwAppFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6});
            this.lvwAppFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lvwAppFiles.FullRowSelect = true;
            this.lvwAppFiles.GridLines = true;
            this.lvwAppFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwAppFiles.HideSelection = false;
            this.lvwAppFiles.Location = new System.Drawing.Point(16, 53);
            this.lvwAppFiles.Name = "lvwAppFiles";
            this.lvwAppFiles.Size = new System.Drawing.Size(829, 537);
            this.lvwAppFiles.SmallImageList = this.imlGeneral;
            this.lvwAppFiles.TabIndex = 35;
            this.lvwAppFiles.UseCompatibleStateImageBehavior = false;
            this.lvwAppFiles.View = System.Windows.Forms.View.Details;
            this.lvwAppFiles.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwAppFiles_ItemChecked);
            this.lvwAppFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwAppFiles_DragDrop);
            this.lvwAppFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwAppFiles_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Folder";
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "UniqueName";
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Available";
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Include";
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "ShortCut";
            // 
            // imlGeneral
            // 
            this.imlGeneral.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlGeneral.ImageStream")));
            this.imlGeneral.TransparentColor = System.Drawing.Color.Transparent;
            this.imlGeneral.Images.SetKeyName(0, "OK-16.png");
            this.imlGeneral.Images.SetKeyName(1, "No-16.png");
            this.imlGeneral.Images.SetKeyName(2, "None-16.png");
            this.imlGeneral.Images.SetKeyName(3, "Blank-16.png");
            // 
            // openFile1
            // 
            this.openFile1.FileName = "openFileDialog1";
            // 
            // ucFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Panel1);
            this.Name = "ucFiles";
            this.Size = new System.Drawing.Size(1149, 607);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.CheckBox chkInclude;
        internal System.Windows.Forms.Label lblAppFileHeader;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnAddRefFiles;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnUnsetShortcut;
        internal System.Windows.Forms.Button btnSetShortcut;
        internal System.Windows.Forms.Button btnIncludeFiles;
        internal System.Windows.Forms.Button btnExcludeFiles;
        internal System.Windows.Forms.Button btnDelAllFiles;
        internal System.Windows.Forms.Button btnDelFiles;
        internal System.Windows.Forms.Button btnDirUpdate;
        internal System.Windows.Forms.ComboBox cmbDirectories;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.ListView lvwAppFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.OpenFileDialog openFile1;
        private System.Windows.Forms.TextBox txtReferenceFile;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lblUpdateFolder;
        private System.Windows.Forms.ImageList imlGeneral;
        private System.Windows.Forms.BindingSource comboBoxItemBindingSource;
    }
}
