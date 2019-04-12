using SangAdv.Updater.Common;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxItem(false)]
    public partial class ucBaseControl : UserControl
    {
        #region Events

        internal event UpdaterEmptyDelegate ActionButtonClicked = () => { };

        internal event UpdaterStringStringStatusDelegate ErrorOccured = (s1, s2, i) => { };

        internal event UpdaterEmptyDelegate CloseInstaller = () => { };

        internal event UpdaterEmptyDelegate InstallCompleted = () => { };

        internal event UpdaterBooleanDelegate ChangeControlBoxStatus = b => { };

        internal void RaiseActionButtonClickedEvent() => ExecuteAction();

        internal void RaiseErrorOccuredEvent(string stringValue1, string stringValue2, SAUpdaterStatusIcon icon) => ErrorOccured(stringValue1, stringValue2, icon);

        internal void RaiseCloseInstallerEvent() => CloseInstaller();

        internal void RaiseInstallCompletedEvent() => InstallCompleted();

        internal void RaiseChangeControlBoxStatusEvent(bool enabled) => ChangeControlBoxStatus(enabled);

        #endregion Events

        #region Properties

        [Category("Action Button")]
        public string ActionButtonText
        {
            get => btnAction.Text;
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                btnAction.Text = value;
            }
        }

        [Category("Action Button")]
        public Image ActionButtonImage
        {
            get => btnAction.Image;
            set
            {
                btnAction.Image = value;
                btnAction.TextAlign = btnAction.Image is null ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleLeft;
            }
        }

        [Category("Action Button")]
        public int ActionButtonWidth
        {
            get => btnAction.Width;
            set
            {
                btnAction.Width = value;
                var newLocation = new Point(576 + 98 - value, 271);
                btnAction.Location = newLocation;
            }
        }

        [Category("Action Button")]
        public bool ActionButtonVisible
        {
            get => btnAction.Visible;
            set => btnAction.Visible = value;
        }

        #endregion Properties

        #region Constructor

        public ucBaseControl()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        public virtual async Task ExecuteStartAsync()
        {
            await Task.Delay(0);
        }

        public void DisplayErrorMessage(string exMessage) => DisplayErrorMessage(exMessage, null);

        public void DisplayErrorMessage(string exMessage, Color? color = null)
        {
            if (color == null) lblError.ForeColor = Color.Black;
            lblError.Text = exMessage;
            Application.DoEvents();
        }

        public void DisplayMessage(string message) => DisplayMessage(message, false);

        public void DisplayMessage(string message, bool isBold)
        {
            var fnt = isBold ? new Font(lblMessage.Font.FontFamily, lblMessage.Font.Size, FontStyle.Bold) : new Font(lblMessage.Font.FontFamily, lblMessage.Font.Size);

            lblMessage.Font = fnt;
            lblMessage.Text = message;
            Application.DoEvents();
        }

        public virtual void BeforeExecuteAction()
        {
        }

        public virtual void ExecuteAction()
        {
            BeforeExecuteAction();
            ActionButtonClicked();
        }

        #endregion Methods

        #region Process UI

        private void btnAction_Click(object sender, System.EventArgs e)
        {
            ExecuteAction();
        }

        #endregion Process UI
    }
}