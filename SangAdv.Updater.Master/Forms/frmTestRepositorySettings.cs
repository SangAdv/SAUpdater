using SangAdv.Updater.Common;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class frmTestRepositorySettings : Form
    {
        #region Variables

        private const string mLocalTestFolder = @"TestFolder\";
        private ASAUpdaterRepositoryBase mRepository;

        #endregion Variables

        #region Constructor

        public frmTestRepositorySettings(ASAUpdaterRepositoryBase repository)
        {
            InitializeComponent();

            lstBox.Items.Clear();

            mRepository = repository;
            mRepository.MessageChanged += DisplayResult;
        }

        #endregion Constructor

        #region Methods

        private async void DoTestAsync()
        {
            DisplayResult($"Test started ....");

            var tResult = mRepository.UploadTestFile();
            if (tResult) tResult = await mRepository.DownloadTestFileAsync(mLocalTestFolder);
            if (tResult) tResult = mRepository.TestCleaningUp(mLocalTestFolder);

            DisplayResult(!tResult ? "Test FAILED!" : "Test passed.");
        }

        private void DisplayResult(string message, bool removeLastEntry = false)
        {
            if (removeLastEntry) lstBox.Items.RemoveAt(lstBox.Items.Count - 1);
            lstBox.Items.Add(message);
            Application.DoEvents();
        }

        #endregion Methods

        #region Process UI

        private void btnStartTest_Click(object sender, System.EventArgs e)
        {
            lstBox.Items.Clear();
            btnStartTest.Enabled = false;
            btnClose.Enabled = false;

            DoTestAsync();

            btnStartTest.Enabled = true;
            btnClose.Enabled = true;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #endregion Process UI
    }
}