namespace SangAdv.Updater.Master
{
    partial class ucApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucApplications));
            this.imlStatus = new System.Windows.Forms.ImageList(this.components);
            this.lvwApplications = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // imlStatus
            // 
            this.imlStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlStatus.ImageStream")));
            this.imlStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imlStatus.Images.SetKeyName(0, "new-24.png");
            this.imlStatus.Images.SetKeyName(1, "admin-24.png");
            this.imlStatus.Images.SetKeyName(2, "upload-24.png");
            this.imlStatus.Images.SetKeyName(3, "done-24.png");
            this.imlStatus.Images.SetKeyName(4, "OK-24.png");
            this.imlStatus.Images.SetKeyName(5, "Missing-24.png");
            // 
            // lvwApplications
            // 
            this.lvwApplications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwApplications.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwApplications.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwApplications.LargeImageList = this.imlStatus;
            this.lvwApplications.Location = new System.Drawing.Point(0, 0);
            this.lvwApplications.MultiSelect = false;
            this.lvwApplications.Name = "lvwApplications";
            this.lvwApplications.Size = new System.Drawing.Size(1091, 514);
            this.lvwApplications.SmallImageList = this.imlStatus;
            this.lvwApplications.StateImageList = this.imlStatus;
            this.lvwApplications.TabIndex = 1;
            this.lvwApplications.UseCompatibleStateImageBehavior = false;
            this.lvwApplications.View = System.Windows.Forms.View.Details;
            this.lvwApplications.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwApplications_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Application";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Release";
            this.columnHeader5.Width = 110;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "PreRelease";
            this.columnHeader8.Width = 110;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Type";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Has Database";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 110;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Is Published";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            // 
            // ucApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwApplications);
            this.Name = "ucApplications";
            this.Size = new System.Drawing.Size(1091, 514);
            this.Load += new System.EventHandler(this.ucApplications_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwApplications;
        private System.Windows.Forms.ImageList imlStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}
