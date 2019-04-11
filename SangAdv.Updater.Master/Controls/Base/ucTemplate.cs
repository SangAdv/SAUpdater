using SangAdv.Updater.Common;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucTemplate : UserControl
    {
        #region Events

        public event UpdaterIntegerDelegate ProgressChanged = (i) => { };

        public event UpdaterStringDelegate StatusMessageChanged = (m) => { };

        public event UpdaterBooleanDelegate MainFormEnabledChanged = (b) => { };

        public event UpdaterBooleanDelegate ButtonsEnabled = (b) => { };

        #endregion Events

        #region Constructor

        public ucTemplate()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Abstract Methods

        public virtual void LoadStartData()
        {
        }

        #endregion Abstract Methods

        #region Trigger Events

        public void RaiseEventStatusMessageChanged(string message)
        {
            StatusMessageChanged(message);
        }

        public void RaiseEventMainFormEnabledChanged(bool enabled)
        {
            MainFormEnabledChanged(enabled);
        }

        public void RaiseEventProgressChanged(int progress)
        {
            ProgressChanged(progress);
        }

        public void RaiseEventDisableMainAndStatusChanged(string message)
        {
            RaiseEventStatusMessageChanged(message);
            RaiseEventMainFormEnabledChanged(false);
        }

        public void RaiseEventEnableMainAndStatusChanged(string message)
        {
            RaiseEventStatusMessageChanged(message);
            RaiseEventMainFormEnabledChanged(true);
        }

        public void RaiseButtonsEnabledEvent(bool enabled)
        {
            ButtonsEnabled(enabled);
        }

        #endregion Trigger Events
    }
}