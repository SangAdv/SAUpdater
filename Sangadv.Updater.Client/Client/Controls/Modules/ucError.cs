using System.ComponentModel;

namespace SangAdv.Updater.Client
{
    [ToolboxItem(false)]
    public partial class ucError : ucBaseControl
    {
        public ucError(string heading, string message, SAUpdaterStatusIcon icon)
        {
            InitializeComponent();

            btnAction.Visible = false;

            DisplayMessage(string.Empty);
            DisplayErrorMessage(string.Empty);

            lblErrorHeading.Text = heading;
            lblErrorMessage.Text = message;

            pbUpdateStatus.Image = ilStatus.Images[(int)icon];
        }
    }
}