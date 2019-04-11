using SangAdv.Updater.Common;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class eucRepositoryBase : UserControl
    {
        #region Events

        internal event UpdaterBooleanDelegate ValidityChanged = b => { };

        internal void RaiseValidityChangedEvent(bool valid) => ValidityChanged(valid);

        #endregion Events

        #region Properties

        internal virtual string SettingsToString { get; }

        internal string GetRepositoryDefinition
        {
            get
            {
                GetVariableDefaults();
                return SettingsToString;
            }
        }

        internal string ErrorMessage { get; set; } = string.Empty;
        internal bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        #endregion Properties

        #region Constructor

        public eucRepositoryBase()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Virtual Methods

        internal virtual void SetVariableDefaults()
        {
            throw new System.NotImplementedException();
        }

        internal virtual void GetVariableDefaults()
        {
            throw new System.NotImplementedException();
        }

        internal virtual void ResetFields()
        {
            throw new System.NotImplementedException();
        }

        internal virtual void ResetSettings()
        {
            throw new System.NotImplementedException();
        }

        internal virtual void SettingsFromString(string repositoryString)
        {
            throw new System.NotImplementedException();
        }

        internal virtual void DoRepositoryTest()
        {
            throw new System.NotImplementedException();
        }

        #endregion Virtual Methods

        #region Methods

        internal void SetRepositoryDefinition(string repositoryString)
        {
            if (string.IsNullOrEmpty(repositoryString))
            {
                ResetSettings();
                return;
            }
            SettingsFromString(repositoryString);
            SetVariableDefaults();
        }

        internal void SetTestButton(bool active = true)
        {
            btnTestSettings.Enabled = active;
        }

        #endregion Methods

        private void btnTestSettings_Click(object sender, System.EventArgs e)
        {
            DoRepositoryTest();
        }
    }
}