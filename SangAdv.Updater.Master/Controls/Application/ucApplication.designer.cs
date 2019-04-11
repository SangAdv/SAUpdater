namespace SangAdv.Updater.Master
{
    partial class ucApplication
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Directory");
            this.lblAppHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlRepository = new System.Windows.Forms.Panel();
            this.cmbRepositoryType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvwFolders = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAppFolder = new System.Windows.Forms.TextBox();
            this.btnDirCancel = new System.Windows.Forms.Button();
            this.btnDirAdd = new System.Windows.Forms.Button();
            this.btnDirDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbOSType = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            this.txtLocalDirectory = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbNetVersion = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbOSVersion = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtAppDescription = new System.Windows.Forms.TextBox();
            this.lblCreatedOn = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.chkRequire64BitOS = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAppHeader
            // 
            this.lblAppHeader.AutoSize = true;
            this.lblAppHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppHeader.Location = new System.Drawing.Point(25, 20);
            this.lblAppHeader.Name = "lblAppHeader";
            this.lblAppHeader.Size = new System.Drawing.Size(129, 17);
            this.lblAppHeader.TabIndex = 7;
            this.lblAppHeader.Text = "Manage Application";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(28, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 575);
            this.panel1.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.pnlRepository);
            this.groupBox4.Controls.Add(this.cmbRepositoryType);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(11, 271);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1092, 284);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Repository";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 67;
            this.label15.Text = "Repository Type:";
            // 
            // pnlRepository
            // 
            this.pnlRepository.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRepository.Location = new System.Drawing.Point(9, 71);
            this.pnlRepository.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRepository.Name = "pnlRepository";
            this.pnlRepository.Size = new System.Drawing.Size(1005, 200);
            this.pnlRepository.TabIndex = 66;
            // 
            // cmbRepositoryType
            // 
            this.cmbRepositoryType.DisplayMember = "Description";
            this.cmbRepositoryType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRepositoryType.FormattingEnabled = true;
            this.cmbRepositoryType.Location = new System.Drawing.Point(9, 37);
            this.cmbRepositoryType.Name = "cmbRepositoryType";
            this.cmbRepositoryType.Size = new System.Drawing.Size(101, 21);
            this.cmbRepositoryType.TabIndex = 68;
            this.cmbRepositoryType.ValueMember = "Value";
            this.cmbRepositoryType.SelectedValueChanged += new System.EventHandler(this.cmbRepositoryType_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lvwFolders);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtAppFolder);
            this.groupBox3.Controls.Add(this.btnDirCancel);
            this.groupBox3.Controls.Add(this.btnDirAdd);
            this.groupBox3.Controls.Add(this.btnDirDelete);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 561);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1092, 192);
            this.groupBox3.TabIndex = 82;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Installation Folders";
            // 
            // lvwFolders
            // 
            this.lvwFolders.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwFolders.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwFolders.Location = new System.Drawing.Point(9, 24);
            this.lvwFolders.Name = "lvwFolders";
            this.lvwFolders.Size = new System.Drawing.Size(403, 153);
            this.lvwFolders.TabIndex = 70;
            this.lvwFolders.UseCompatibleStateImageBehavior = false;
            this.lvwFolders.View = System.Windows.Forms.View.List;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(424, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(307, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Path: (Relative to App Root, eg. DATA will become ...\\DATA\\)";
            // 
            // txtAppFolder
            // 
            this.txtAppFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppFolder.Location = new System.Drawing.Point(427, 40);
            this.txtAppFolder.Name = "txtAppFolder";
            this.txtAppFolder.Size = new System.Drawing.Size(485, 22);
            this.txtAppFolder.TabIndex = 72;
            // 
            // btnDirCancel
            // 
            this.btnDirCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirCancel.Location = new System.Drawing.Point(516, 68);
            this.btnDirCancel.Name = "btnDirCancel";
            this.btnDirCancel.Size = new System.Drawing.Size(75, 23);
            this.btnDirCancel.TabIndex = 75;
            this.btnDirCancel.Text = "Cancel";
            this.btnDirCancel.UseVisualStyleBackColor = true;
            this.btnDirCancel.Click += new System.EventHandler(this.btnDirCancel_Click);
            // 
            // btnDirAdd
            // 
            this.btnDirAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirAdd.Location = new System.Drawing.Point(435, 68);
            this.btnDirAdd.Name = "btnDirAdd";
            this.btnDirAdd.Size = new System.Drawing.Size(75, 23);
            this.btnDirAdd.TabIndex = 73;
            this.btnDirAdd.Text = "Add";
            this.btnDirAdd.UseVisualStyleBackColor = true;
            this.btnDirAdd.Click += new System.EventHandler(this.btnDirAdd_Click);
            // 
            // btnDirDelete
            // 
            this.btnDirDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirDelete.Location = new System.Drawing.Point(516, 97);
            this.btnDirDelete.Name = "btnDirDelete";
            this.btnDirDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDirDelete.TabIndex = 74;
            this.btnDirDelete.Text = "Delete";
            this.btnDirDelete.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkRequire64BitOS);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.cmbOSType);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.btnChooseDirectory);
            this.groupBox1.Controls.Add(this.txtLocalDirectory);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cmbNetVersion);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbOSVersion);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Controls.Add(this.txtAppDescription);
            this.groupBox1.Controls.Add(this.lblCreatedOn);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1092, 261);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(930, 232);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 68;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "OS Type:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1011, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnAppCancel_Click);
            // 
            // cmbOSType
            // 
            this.cmbOSType.DisplayMember = "Description";
            this.cmbOSType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOSType.FormattingEnabled = true;
            this.cmbOSType.Location = new System.Drawing.Point(9, 141);
            this.cmbOSType.Name = "cmbOSType";
            this.cmbOSType.Size = new System.Drawing.Size(193, 21);
            this.cmbOSType.TabIndex = 67;
            this.cmbOSType.ValueMember = "Value";
            this.cmbOSType.SelectedValueChanged += new System.EventHandler(this.cmbOSType_SelectedValueChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(6, 21);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 62;
            this.Label2.Text = "Description:";
            // 
            // btnChooseDirectory
            // 
            this.btnChooseDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseDirectory.Location = new System.Drawing.Point(1020, 183);
            this.btnChooseDirectory.Name = "btnChooseDirectory";
            this.btnChooseDirectory.Size = new System.Drawing.Size(35, 23);
            this.btnChooseDirectory.TabIndex = 55;
            this.btnChooseDirectory.Text = "...";
            this.btnChooseDirectory.UseVisualStyleBackColor = true;
            this.btnChooseDirectory.Click += new System.EventHandler(this.btnChooseDirectory_Click);
            // 
            // txtLocalDirectory
            // 
            this.txtLocalDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalDirectory.Location = new System.Drawing.Point(9, 183);
            this.txtLocalDirectory.Name = "txtLocalDirectory";
            this.txtLocalDirectory.ReadOnly = true;
            this.txtLocalDirectory.Size = new System.Drawing.Size(1005, 22);
            this.txtLocalDirectory.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(910, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = ".NET Version Required:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 167);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(149, 13);
            this.label17.TabIndex = 53;
            this.label17.Text = "Local Source Files Location:";
            // 
            // cmbNetVersion
            // 
            this.cmbNetVersion.DisplayMember = "Description";
            this.cmbNetVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNetVersion.FormattingEnabled = true;
            this.cmbNetVersion.Location = new System.Drawing.Point(913, 141);
            this.cmbNetVersion.Name = "cmbNetVersion";
            this.cmbNetVersion.Size = new System.Drawing.Size(101, 21);
            this.cmbNetVersion.TabIndex = 57;
            this.cmbNetVersion.ValueMember = "Value";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(516, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "OS Version Required:";
            // 
            // cmbOSVersion
            // 
            this.cmbOSVersion.DisplayMember = "Description";
            this.cmbOSVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOSVersion.FormattingEnabled = true;
            this.cmbOSVersion.Location = new System.Drawing.Point(519, 141);
            this.cmbOSVersion.Name = "cmbOSVersion";
            this.cmbOSVersion.Size = new System.Drawing.Size(280, 21);
            this.cmbOSVersion.TabIndex = 59;
            this.cmbOSVersion.ValueMember = "Value";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 79);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 13);
            this.Label1.TabIndex = 60;
            this.Label1.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DisplayMember = "CategoryDesc";
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(9, 95);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(339, 21);
            this.cmbCategory.TabIndex = 61;
            this.cmbCategory.ValueMember = "ID";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(6, 62);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(67, 13);
            this.Label5.TabIndex = 64;
            this.Label5.Text = "Created on:";
            // 
            // txtAppDescription
            // 
            this.txtAppDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppDescription.Location = new System.Drawing.Point(9, 37);
            this.txtAppDescription.Name = "txtAppDescription";
            this.txtAppDescription.Size = new System.Drawing.Size(1005, 22);
            this.txtAppDescription.TabIndex = 63;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.AutoSize = true;
            this.lblCreatedOn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedOn.Location = new System.Drawing.Point(72, 62);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(90, 13);
            this.lblCreatedOn.TabIndex = 65;
            this.lblCreatedOn.Text = "Created on date";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(25, 648);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 13);
            this.lblMessage.TabIndex = 34;
            this.lblMessage.Text = "lblMessage";
            // 
            // chkRequire64BitOS
            // 
            this.chkRequire64BitOS.AutoSize = true;
            this.chkRequire64BitOS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRequire64BitOS.Location = new System.Drawing.Point(208, 141);
            this.chkRequire64BitOS.Name = "chkRequire64BitOS";
            this.chkRequire64BitOS.Size = new System.Drawing.Size(129, 21);
            this.chkRequire64BitOS.TabIndex = 69;
            this.chkRequire64BitOS.Text = "Require 64 Bit OS";
            this.chkRequire64BitOS.UseVisualStyleBackColor = true;
            // 
            // ucApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAppHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucApplication";
            this.Size = new System.Drawing.Size(1212, 679);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblAppHeader;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblCreatedOn;
        internal System.Windows.Forms.TextBox txtAppDescription;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbOSVersion;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ComboBox cmbNetVersion;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtLocalDirectory;
        internal System.Windows.Forms.Button btnChooseDirectory;
        internal System.Windows.Forms.ComboBox cmbRepositoryType;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnlRepository;
        internal System.Windows.Forms.Button btnDirCancel;
        internal System.Windows.Forms.Button btnDirDelete;
        internal System.Windows.Forms.Button btnDirAdd;
        internal System.Windows.Forms.TextBox txtAppFolder;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ListView lvwFolders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cmbOSType;
        internal System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkRequire64BitOS;
    }
}
