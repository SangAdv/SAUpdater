namespace SangAdv.Updater.Master
{
    partial class ucVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVersion));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblVersionHeader = new System.Windows.Forms.Label();
            this.lvwVersions = new System.Windows.Forms.ListView();
            this.imlVersions = new System.Windows.Forms.ImageList(this.components);
            this.Panel2 = new System.Windows.Forms.Panel();
            this.cmbRelease = new System.Windows.Forms.ComboBox();
            this.btnPublishVersion = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtAppVersion = new System.Windows.Forms.TextBox();
            this.lblPublishedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnPublishFiles = new System.Windows.Forms.Button();
            this.btnVersionAdd = new System.Windows.Forms.Button();
            this.btnVersionCancel = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabVersion = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btnClrAllVerFiles = new System.Windows.Forms.Button();
            this.btnSelAllVerFiles = new System.Windows.Forms.Button();
            this.btnUpdateOptions = new System.Windows.Forms.Button();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.lvwVersionFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.pnlNotes = new System.Windows.Forms.Panel();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnClrAll = new System.Windows.Forms.Button();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.lvwAppFiles = new System.Windows.Forms.ListView();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlGeneral = new System.Windows.Forms.ImageList(this.components);
            this.btnTagMissing = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.tabVersion.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.pnlNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.lblVersionHeader);
            this.Panel1.Controls.Add(this.lvwVersions);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.SplitContainer1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1277, 635);
            this.Panel1.TabIndex = 1;
            // 
            // lblVersionHeader
            // 
            this.lblVersionHeader.AutoSize = true;
            this.lblVersionHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionHeader.Location = new System.Drawing.Point(10, 10);
            this.lblVersionHeader.Name = "lblVersionHeader";
            this.lblVersionHeader.Size = new System.Drawing.Size(61, 17);
            this.lblVersionHeader.TabIndex = 41;
            this.lblVersionHeader.Text = "Versions:";
            // 
            // lvwVersions
            // 
            this.lvwVersions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwVersions.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwVersions.Location = new System.Drawing.Point(13, 33);
            this.lvwVersions.MultiSelect = false;
            this.lvwVersions.Name = "lvwVersions";
            this.lvwVersions.Size = new System.Drawing.Size(143, 587);
            this.lvwVersions.SmallImageList = this.imlVersions;
            this.lvwVersions.TabIndex = 40;
            this.lvwVersions.UseCompatibleStateImageBehavior = false;
            this.lvwVersions.View = System.Windows.Forms.View.SmallIcon;
            this.lvwVersions.Click += new System.EventHandler(this.lvwVersions_Click);
            // 
            // imlVersions
            // 
            this.imlVersions.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlVersions.ImageStream")));
            this.imlVersions.TransparentColor = System.Drawing.Color.Transparent;
            this.imlVersions.Images.SetKeyName(0, "new-16.png");
            this.imlVersions.Images.SetKeyName(1, "admin-16.png");
            this.imlVersions.Images.SetKeyName(2, "upload-16.png");
            this.imlVersions.Images.SetKeyName(3, "done-16.png");
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.cmbRelease);
            this.Panel2.Controls.Add(this.btnPublishVersion);
            this.Panel2.Controls.Add(this.btnDelete);
            this.Panel2.Controls.Add(this.txtAppVersion);
            this.Panel2.Controls.Add(this.lblPublishedDate);
            this.Panel2.Controls.Add(this.lblCreatedDate);
            this.Panel2.Controls.Add(this.Label5);
            this.Panel2.Controls.Add(this.Label4);
            this.Panel2.Controls.Add(this.btnPublishFiles);
            this.Panel2.Controls.Add(this.btnVersionAdd);
            this.Panel2.Controls.Add(this.btnVersionCancel);
            this.Panel2.Controls.Add(this.Label7);
            this.Panel2.Location = new System.Drawing.Point(162, 33);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1101, 72);
            this.Panel2.TabIndex = 39;
            // 
            // cmbRelease
            // 
            this.cmbRelease.DisplayMember = "Description";
            this.cmbRelease.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRelease.FormattingEnabled = true;
            this.cmbRelease.Location = new System.Drawing.Point(225, 4);
            this.cmbRelease.Name = "cmbRelease";
            this.cmbRelease.Size = new System.Drawing.Size(101, 21);
            this.cmbRelease.TabIndex = 63;
            this.cmbRelease.ValueMember = "Value";
            // 
            // btnPublishVersion
            // 
            this.btnPublishVersion.Enabled = false;
            this.btnPublishVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnPublishVersion.Location = new System.Drawing.Point(562, 32);
            this.btnPublishVersion.Name = "btnPublishVersion";
            this.btnPublishVersion.Size = new System.Drawing.Size(94, 22);
            this.btnPublishVersion.TabIndex = 61;
            this.btnPublishVersion.Text = "Publish Version";
            this.btnPublishVersion.UseVisualStyleBackColor = true;
            this.btnPublishVersion.Click += new System.EventHandler(this.btnPublishVersion_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(737, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 23);
            this.btnDelete.TabIndex = 60;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtAppVersion
            // 
            this.txtAppVersion.Location = new System.Drawing.Point(119, 4);
            this.txtAppVersion.Name = "txtAppVersion";
            this.txtAppVersion.Size = new System.Drawing.Size(100, 22);
            this.txtAppVersion.TabIndex = 27;
            this.txtAppVersion.TextChanged += new System.EventHandler(this.txtAppVersion_TextChanged);
            // 
            // lblPublishedDate
            // 
            this.lblPublishedDate.AutoSize = true;
            this.lblPublishedDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublishedDate.Location = new System.Drawing.Point(116, 54);
            this.lblPublishedDate.Name = "lblPublishedDate";
            this.lblPublishedDate.Size = new System.Drawing.Size(82, 13);
            this.lblPublishedDate.TabIndex = 24;
            this.lblPublishedDate.Text = "PublishedDate";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedDate.Location = new System.Drawing.Point(116, 36);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(71, 13);
            this.lblCreatedDate.TabIndex = 23;
            this.lblCreatedDate.Text = "CreatedDate";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(3, 54);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(61, 13);
            this.Label5.TabIndex = 22;
            this.Label5.Text = "Published:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(3, 36);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 13);
            this.Label4.TabIndex = 21;
            this.Label4.Text = "Created:";
            // 
            // btnPublishFiles
            // 
            this.btnPublishFiles.Enabled = false;
            this.btnPublishFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnPublishFiles.Location = new System.Drawing.Point(562, 4);
            this.btnPublishFiles.Name = "btnPublishFiles";
            this.btnPublishFiles.Size = new System.Drawing.Size(94, 22);
            this.btnPublishFiles.TabIndex = 20;
            this.btnPublishFiles.Text = "Publish Files";
            this.btnPublishFiles.UseVisualStyleBackColor = true;
            this.btnPublishFiles.Click += new System.EventHandler(this.btnPublishFiles_Click);
            // 
            // btnVersionAdd
            // 
            this.btnVersionAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnVersionAdd.Location = new System.Drawing.Point(447, 4);
            this.btnVersionAdd.Name = "btnVersionAdd";
            this.btnVersionAdd.Size = new System.Drawing.Size(59, 23);
            this.btnVersionAdd.TabIndex = 19;
            this.btnVersionAdd.Text = "Add";
            this.btnVersionAdd.UseVisualStyleBackColor = true;
            this.btnVersionAdd.Click += new System.EventHandler(this.btnVersionAdd_Click);
            // 
            // btnVersionCancel
            // 
            this.btnVersionCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnVersionCancel.Location = new System.Drawing.Point(447, 32);
            this.btnVersionCancel.Name = "btnVersionCancel";
            this.btnVersionCancel.Size = new System.Drawing.Size(59, 23);
            this.btnVersionCancel.TabIndex = 18;
            this.btnVersionCancel.Text = "Cancel";
            this.btnVersionCancel.UseVisualStyleBackColor = true;
            this.btnVersionCancel.Click += new System.EventHandler(this.btnVersionCancel_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(3, 6);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(110, 13);
            this.Label7.TabIndex = 15;
            this.Label7.Text = "Application Version:";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer1.Location = new System.Drawing.Point(162, 111);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.tabVersion);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.btnClrAll);
            this.SplitContainer1.Panel2.Controls.Add(this.btnSelAll);
            this.SplitContainer1.Panel2.Controls.Add(this.Label2);
            this.SplitContainer1.Panel2.Controls.Add(this.btnAddFiles);
            this.SplitContainer1.Panel2.Controls.Add(this.lvwAppFiles);
            this.SplitContainer1.Size = new System.Drawing.Size(1101, 509);
            this.SplitContainer1.SplitterDistance = 554;
            this.SplitContainer1.TabIndex = 38;
            // 
            // tabVersion
            // 
            this.tabVersion.Controls.Add(this.TabPage1);
            this.tabVersion.Controls.Add(this.TabPage3);
            this.tabVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabVersion.Location = new System.Drawing.Point(0, 0);
            this.tabVersion.Name = "tabVersion";
            this.tabVersion.SelectedIndex = 0;
            this.tabVersion.Size = new System.Drawing.Size(554, 509);
            this.tabVersion.TabIndex = 43;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btnTagMissing);
            this.TabPage1.Controls.Add(this.btnClrAllVerFiles);
            this.TabPage1.Controls.Add(this.btnSelAllVerFiles);
            this.TabPage1.Controls.Add(this.btnUpdateOptions);
            this.TabPage1.Controls.Add(this.btnClearFiles);
            this.TabPage1.Controls.Add(this.lvwVersionFiles);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(546, 483);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Version Files";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClrAllVerFiles
            // 
            this.btnClrAllVerFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClrAllVerFiles.Location = new System.Drawing.Point(76, 2);
            this.btnClrAllVerFiles.Name = "btnClrAllVerFiles";
            this.btnClrAllVerFiles.Size = new System.Drawing.Size(67, 23);
            this.btnClrAllVerFiles.TabIndex = 45;
            this.btnClrAllVerFiles.Text = "Clear All";
            this.btnClrAllVerFiles.UseVisualStyleBackColor = true;
            this.btnClrAllVerFiles.Click += new System.EventHandler(this.btnClrAllVerFiles_Click);
            // 
            // btnSelAllVerFiles
            // 
            this.btnSelAllVerFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSelAllVerFiles.Location = new System.Drawing.Point(3, 2);
            this.btnSelAllVerFiles.Name = "btnSelAllVerFiles";
            this.btnSelAllVerFiles.Size = new System.Drawing.Size(67, 23);
            this.btnSelAllVerFiles.TabIndex = 44;
            this.btnSelAllVerFiles.Text = "Select All";
            this.btnSelAllVerFiles.UseVisualStyleBackColor = true;
            this.btnSelAllVerFiles.Click += new System.EventHandler(this.btnSelAllVerFiles_Click);
            // 
            // btnUpdateOptions
            // 
            this.btnUpdateOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateOptions.Enabled = false;
            this.btnUpdateOptions.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnUpdateOptions.Location = new System.Drawing.Point(259, 2);
            this.btnUpdateOptions.Name = "btnUpdateOptions";
            this.btnUpdateOptions.Size = new System.Drawing.Size(103, 23);
            this.btnUpdateOptions.TabIndex = 43;
            this.btnUpdateOptions.Text = "Update Options";
            this.btnUpdateOptions.UseVisualStyleBackColor = true;
            this.btnUpdateOptions.Click += new System.EventHandler(this.btnUpdateOptions_Click);
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFiles.Enabled = false;
            this.btnClearFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClearFiles.Location = new System.Drawing.Point(365, 2);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(72, 23);
            this.btnClearFiles.TabIndex = 42;
            this.btnClearFiles.Text = "Clear Files";
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.btnClearFiles_Click);
            // 
            // lvwVersionFiles
            // 
            this.lvwVersionFiles.AllowDrop = true;
            this.lvwVersionFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwVersionFiles.CheckBoxes = true;
            this.lvwVersionFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.ColumnHeader4});
            this.lvwVersionFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lvwVersionFiles.FullRowSelect = true;
            this.lvwVersionFiles.GridLines = true;
            this.lvwVersionFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwVersionFiles.HideSelection = false;
            this.lvwVersionFiles.Location = new System.Drawing.Point(0, 31);
            this.lvwVersionFiles.Name = "lvwVersionFiles";
            this.lvwVersionFiles.Size = new System.Drawing.Size(545, 452);
            this.lvwVersionFiles.TabIndex = 36;
            this.lvwVersionFiles.UseCompatibleStateImageBehavior = false;
            this.lvwVersionFiles.View = System.Windows.Forms.View.Details;
            this.lvwVersionFiles.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwVersionFiles_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Folder";
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Update Rule";
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.pnlNotes);
            this.TabPage3.Controls.Add(this.btnClearAll);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(546, 483);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Notes";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // pnlNotes
            // 
            this.pnlNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNotes.Controls.Add(this.rtbNotes);
            this.pnlNotes.Location = new System.Drawing.Point(0, 31);
            this.pnlNotes.Name = "pnlNotes";
            this.pnlNotes.Size = new System.Drawing.Size(545, 452);
            this.pnlNotes.TabIndex = 54;
            // 
            // rtbNotes
            // 
            this.rtbNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNotes.Location = new System.Drawing.Point(0, 0);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbNotes.Size = new System.Drawing.Size(543, 450);
            this.rtbNotes.TabIndex = 52;
            this.rtbNotes.Text = "";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClearAll.Location = new System.Drawing.Point(441, 1);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(103, 23);
            this.btnClearAll.TabIndex = 53;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            // 
            // btnClrAll
            // 
            this.btnClrAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClrAll.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClrAll.Location = new System.Drawing.Point(253, 2);
            this.btnClrAll.Name = "btnClrAll";
            this.btnClrAll.Size = new System.Drawing.Size(67, 23);
            this.btnClrAll.TabIndex = 46;
            this.btnClrAll.Text = "Clear All";
            this.btnClrAll.UseVisualStyleBackColor = true;
            this.btnClrAll.Click += new System.EventHandler(this.btnClrAll_Click);
            // 
            // btnSelAll
            // 
            this.btnSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelAll.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSelAll.Location = new System.Drawing.Point(180, 2);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(67, 23);
            this.btnSelAll.TabIndex = 42;
            this.btnSelAll.Text = "Select All";
            this.btnSelAll.UseVisualStyleBackColor = true;
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(3, 7);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(95, 13);
            this.Label2.TabIndex = 39;
            this.Label2.Text = "Application Files:";
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFiles.Enabled = false;
            this.btnAddFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddFiles.Location = new System.Drawing.Point(437, 2);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(103, 23);
            this.btnAddFiles.TabIndex = 41;
            this.btnAddFiles.Text = "Add Selected Files";
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
            this.ColumnHeader5,
            this.ColumnHeader10,
            this.columnHeader7,
            this.ColumnHeader6,
            this.ColumnHeader3});
            this.lvwAppFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lvwAppFiles.FullRowSelect = true;
            this.lvwAppFiles.GridLines = true;
            this.lvwAppFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwAppFiles.HideSelection = false;
            this.lvwAppFiles.Location = new System.Drawing.Point(0, 29);
            this.lvwAppFiles.Name = "lvwAppFiles";
            this.lvwAppFiles.Size = new System.Drawing.Size(543, 480);
            this.lvwAppFiles.SmallImageList = this.imlGeneral;
            this.lvwAppFiles.TabIndex = 36;
            this.lvwAppFiles.UseCompatibleStateImageBehavior = false;
            this.lvwAppFiles.View = System.Windows.Forms.View.Details;
            this.lvwAppFiles.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwAppFiles_ItemChecked);
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "File";
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Published";
            this.ColumnHeader10.Width = 65;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Version";
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Latest";
            this.ColumnHeader6.Width = 65;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Available";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // btnTagMissing
            // 
            this.btnTagMissing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTagMissing.Enabled = false;
            this.btnTagMissing.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnTagMissing.Location = new System.Drawing.Point(443, 2);
            this.btnTagMissing.Name = "btnTagMissing";
            this.btnTagMissing.Size = new System.Drawing.Size(79, 23);
            this.btnTagMissing.TabIndex = 46;
            this.btnTagMissing.Text = "Tag Missing";
            this.btnTagMissing.UseVisualStyleBackColor = true;
            this.btnTagMissing.Click += new System.EventHandler(this.btnTagMissing_Click);
            // 
            // ucVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucVersion";
            this.Size = new System.Drawing.Size(1277, 635);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.tabVersion.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.pnlNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lblVersionHeader;
        internal System.Windows.Forms.ListView lvwVersions;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TextBox txtAppVersion;
        internal System.Windows.Forms.Label lblPublishedDate;
        internal System.Windows.Forms.Label lblCreatedDate;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnPublishFiles;
        internal System.Windows.Forms.Button btnVersionAdd;
        internal System.Windows.Forms.Button btnVersionCancel;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.TabControl tabVersion;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Button btnClrAllVerFiles;
        internal System.Windows.Forms.Button btnSelAllVerFiles;
        internal System.Windows.Forms.Button btnUpdateOptions;
        internal System.Windows.Forms.Button btnAddFiles;
        internal System.Windows.Forms.Button btnClearFiles;
        private System.Windows.Forms.ListView lvwVersionFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.Panel pnlNotes;
        internal System.Windows.Forms.RichTextBox rtbNotes;
        internal System.Windows.Forms.Button btnClearAll;
        internal System.Windows.Forms.Button btnSelAll;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ListView lvwAppFiles;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ImageList imlVersions;
        internal System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ImageList imlGeneral;
        internal System.Windows.Forms.Button btnPublishVersion;
        internal System.Windows.Forms.Button btnClrAll;
        internal System.Windows.Forms.ComboBox cmbRelease;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        internal System.Windows.Forms.Button btnTagMissing;
    }
}
