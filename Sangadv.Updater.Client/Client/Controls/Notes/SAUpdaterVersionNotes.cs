using SangAdv.Updater.Common;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxBitmap("..\\Resources\\SAUpdater_16.png")]
    public partial class SAUpdaterVersionNotes : UserControl
    {
        #region Variables

        private string mNotes = string.Empty;

        #endregion Variables

        #region Constructor

        public SAUpdaterVersionNotes()
        {
            InitializeComponent();
        }

        #endregion Constructor

        private async void SAVersionNotes_Load(object sender, EventArgs e)
        {
            if (DesignMode) IsDesignMode();
            else await LoadNotesAsync();
        }

        private void IsDesignMode()
        {
            rtbNotes.Text = "Design mode";
        }

        public async Task LoadNotesAsync()
        {
            if (!SAUpdaterGlobal.IsInitialised)
            {
                rtbNotes.Text = $"Please initialise execution control before using notes control.";
                return;
            }

            var tOptions = SAUpdaterGlobal.Options;
            var tRepository = SAUpdaterGlobal.Repository;

            if (!SAUpdaterGlobal.Connected) rtbNotes.Text = $"Please connect to the internet to display notes for {tOptions.ApplicationTitle}.";
            else
            {
                rtbNotes.Text = $"Please wait ... Loading notes for {tOptions.ApplicationTitle}.";
                Application.DoEvents();
                try
                {
                    if (string.IsNullOrEmpty(mNotes)) mNotes = await tRepository.GetNotesAsync(tRepository.UpdateDefinition.NewApplicationVersion);
                    rtbNotes.Rtf = mNotes;
                }
                catch (Exception ex)
                {
                    rtbNotes.Text = $"The following error occured:\n{ex.Message}";
                }
            }
        }
    }
}