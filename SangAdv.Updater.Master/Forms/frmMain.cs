using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class frmMain : Form
    {
        #region Variables

        private static bool ProgressCancelled { get; set; } = false;
        private MasterDataFile mDataFile;
        private bool mHasError = false;

        #endregion Variables

        #region Constructor

        public frmMain()
        {
            InitializeComponent();

            //Do the application setup
            var f = new frmStartup();
            f.ShowDialog();
            if (f.HasError)
            {
                mHasError = true;
                return;
            }

            mDataFile = SAUpdaterMasterCommon.MasterData;

            tsMenu.Renderer = new MainFormToolStripRenderer();

            SetUIDefaults();

            DisplayControl(new ucAbout());

            //Set the app defaults
            SetAppDefaults();
        }

        #endregion Constructor

        #region Process UI

        private void frmMain_Shown(object sender, System.EventArgs e)
        {
            if (mHasError)
            {
                Close();
                return;
            }
            //Check internet connection
            //SAUpdateCore.InternetConnectionStateChanged += SetConnectionState;
            //if (!SAUpdateCore.Connected(true)) SetStatusMessage("Application is not connected to the internet. Please connect before continuing!");

            //Hook up events
            SAUpdaterMasterCommon.AppSelected += AppSelected;
        }

        #region Toolbar Buttons

        private void tsbNewApplication_Click(object sender, System.EventArgs e)
        {
            var f = new frmNewApplication();
            f.ShowDialog(this);
        }

        private void tsbApplications_Click(object sender, System.EventArgs e)
        {
            DisplayControl(new ucApplications());
        }

        private void tsbExit_Click(object sender, System.EventArgs e)
        {
            string message = "Are you sure you want to quit the application?";
            const string caption = "Confirm quit";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No) return;
            this.Close();
        }

        private void tsbCategory_Click(object sender, System.EventArgs e)
        {
            DisplayControl(new ucCategory());
        }

        private void tsbOpenSource_Click(object sender, System.EventArgs e)
        {
            DisplayControl(new ucOpenSource());
        }

        private void tsbAbout_Click(object sender, System.EventArgs e)
        {
            DisplayControl(new ucAbout());
        }

        #endregion Toolbar Buttons

        #endregion Process UI

        #region Private Methods

        private void SetConnectionState(bool connected)
        {
            tsiConnection.Image = connected ? Properties.Resources.link_16 : Properties.Resources.link_broken_1x_16;
        }

        private void SetAppDefaults()
        {
            SetApplicationButtonEnabled();
            SAUpdaterMasterCommon.UpdateAvailable = false;
        }

        private void SetApplicationButtonEnabled()
        {
            tsbApplications.Enabled = mDataFile.Applications.Count != 0;
        }

        private void DisplayControl(ucTemplate userControl)
        {
            foreach (ucTemplate uc in clientPanel.Controls) DetachEvents(uc);
            AttachEvents(userControl);

            clientPanel.SuspendLayout();
            clientPanel.Controls.Clear();

            userControl.Dock = DockStyle.Fill;
            clientPanel.ResumeLayout();

            clientPanel.Controls.Add(userControl);

            userControl.Visible = false;
            Application.DoEvents();

            userControl.LoadStartData();
            userControl.Visible = true;
        }

        private void AttachEvents(ucTemplate userControl)
        {
            userControl.StatusMessageChanged += SetStatusMessage;
            userControl.MainFormEnabledChanged += SetMainFormEnabled;
        }

        private void DetachEvents(ucTemplate userControl)
        {
            userControl.StatusMessageChanged -= SetStatusMessage;
            userControl.MainFormEnabledChanged -= SetMainFormEnabled;
        }

        #region Event Response

        private void SetMenuEnabled(bool enabled)
        {
            tsMenu.Enabled = enabled;
        }

        private void SetStatusMessage(string message)
        {
            bstStatus.Text = message;
            Application.DoEvents();
        }

        private void SetMainFormEnabled(bool enabled)
        {
            Enabled = enabled;
        }

        private void AppSelected(int selectedAppId)
        {
            SetApplicationButtonEnabled();
            var tCurrentApplication = mDataFile.Applications.Get(selectedAppId);
            SetStatusMessage($"{tCurrentApplication.ApplicationTitle} > selected");
            SetFormTitle(tCurrentApplication.ApplicationTitle);

            DisplayControl(new ucApplicationContainer(tCurrentApplication));
        }

        #endregion Event Response

        #region Message Notifier

        //private void OnTaskMessage(MessageType messageType, MessageContent messageContent)
        //{
        //    //string tContent = messageContent.Message;
        //    //bool tSuccess = messageContent.Success;

        //    //switch (messageType)
        //    //{
        //    //    case MessageType.AppSelected:
        //    //        Status($"{MasterDataFile.ApplicationTitle} > selected");
        //    //        SetApplicationButtons(true);
        //    //        ShowCurrentApp();
        //    //        break;

        //    //Case Is = Messenger.MessageType.ChangePage
        //    //    Select Case tContent
        //    //        Case Is = "Version"
        //    //            ShowVersionPage()
        //    //    End Select

        //    //Case Is = Messenger.MessageType.CategoryEdit
        //    //    HideSubMenu()
        //    //    OpenCategoriesPage()

        //    //Case Is = Messenger.MessageType.UpdateApp
        //    //    HideSubMenu()
        //    //    UpdateApplication()

        //    //Case Is = Messenger.MessageType.About
        //    //    HideSubMenu()
        //    //    OpenInfoPage()

        //    //Case Is = Messenger.MessageType.Library
        //    //    HideSubMenu()
        //    //    OpenLibraryPage()

        //    //Case Is = Messenger.MessageType.About
        //    //    HideSubMenu()
        //    //    OpenInfoPage()

        //    //Case Is = Messenger.MessageType.WaitformOpen
        //    //    p = ProgressWaitForm.ShowProgress(Me)

        //    //Case Is = Messenger.MessageType.WaitFormMessage
        //    //    p.UpdateProgress(tContent)

        //    //Case Is = Messenger.MessageType.WaitFormClose
        //    //    p.CloseProgress()

        //    //Case Is = Messenger.MessageType.UpdateStart
        //    //    Status(tContent)
        //    //    Me.Enabled = False

        //    //case MessageType.UpdateEnd:
        //    //    Status(tContent);
        //    //this.Enabled = true;
        //    //}
        //}

        #endregion Message Notifier

        #endregion Private Methods

        #region Prepare UI

        private void SetUIDefaults()
        {
            tsbNewApplication.Text = "New\nApplication";
            tsbApplications.Text = " \nApplications";
            tsbExit.Text = " \nExit";
            tsbInformation.Text = " \nInformation";
            tsbSettings.Text = " \nSettings";

            bstVersion.Text = Application.ProductVersion;

            SetStatusMessage("");
            SetFormTitle(string.Empty);
            SetUpdateIcon();
        }

        private void SetFormTitle(string applicationTitle)
        {
            Text = applicationTitle == string.Empty ? "SA Updater" : $"SA Updater > {applicationTitle}";
        }

        private void SetUpdateIcon()
        {
            tsiUpdate.Visible = SAUpdaterMasterCommon.UpdateAvailable;
            tsbUpdate.Visible = SAUpdaterMasterCommon.UpdateAvailable;
        }

        #endregion Prepare UI
    }
}