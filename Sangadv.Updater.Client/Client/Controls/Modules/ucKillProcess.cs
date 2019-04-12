using SangAdv.Updater.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxItem(false)]
    public partial class ucKillProcess : ucBaseControl
    {
        #region Variables

        private bool mStopProcessing = false;
        private bool mGotoNextPage = false;
        private List<Process> mActiveProcessList = new List<Process>();

        #endregion Variables

        #region Constructor

        public ucKillProcess()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Process UI

        private void btnKill_Click(object sender, EventArgs e)
        {
            mStopProcessing = true;
            foreach (var item in mActiveProcessList)
            {
                item.Kill();
            }

            btnKill.Enabled = false;
            mStopProcessing = false;
        }

        #endregion Process UI

        #region Methods

        public override async Task ExecuteStartAsync()
        {
            if (mActiveProcessList.Count < 1) RaiseActionButtonClickedEvent();
            await Task.Delay(0);
        }

        public void Execute()
        {
            btnKill.Enabled = false;

            if (SAUpdaterGlobal.Options.ProcessNameList.Count == 0) RaiseActionButtonClickedEvent();

            var tSeconds = 0;
            var tCurrentProcesscount = 0;

            mStopProcessing = false;
            lstProcess.Items.Clear();
            Cursor = Cursors.Default;
            Application.DoEvents();

            //Manage open processes
            try
            {
                var tStartTime = DateTime.Now;
                var tNextTime = DateTime.Now;
                do
                {
                    do
                    {
                        Thread.Sleep(10);
                    } while (mStopProcessing);

                    //Check if the process is running
                    mActiveProcessList = new List<Process>();
                    foreach (var entry in SAUpdaterGlobal.Options.ProcessNameList)
                    {
                        var proc = Process.GetProcessesByName(entry);
                        if (proc.Any())
                        {
                            foreach (var item in proc) mActiveProcessList.Add(item);
                        }
                    }

                    if (mActiveProcessList.Count != tCurrentProcesscount) DisplayProcessNames();
                    tCurrentProcesscount = mActiveProcessList.Count;

                    if (mActiveProcessList.Count > 0)
                    {
                        TimeSpan tDuration;
                        do
                        {
                            tDuration = DateTime.Now.Subtract(tNextTime);
                            Application.DoEvents();
                        } while (tDuration.TotalMilliseconds < 1000);
                        tNextTime = DateTime.Now;

                        var tCurrentSeconds = Convert.ToInt32(DateTime.Now.Subtract(tStartTime).TotalSeconds);
                        if (tCurrentSeconds != tSeconds)
                        {
                            tSeconds = tCurrentSeconds;
                            btnKill.Width = 95;
                            btnKill.Text = $"Kill All ({tSeconds})";
                        }
                        if (tSeconds > 20)
                        {
                            btnKill.Enabled = true;
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        mGotoNextPage = true;
                    }
                } while (!mGotoNextPage);

                if (mGotoNextPage) RaiseActionButtonClickedEvent();
            }
            catch (Exception ex)
            {
                RaiseErrorOccuredEvent("Kill Process Error", $"Error: {ex.Message}", SAUpdaterStatusIcon.Warning);
            }
        }

        private void DisplayProcessNames()
        {
            lstProcess.Items.Clear();
            foreach (var item in mActiveProcessList)
            {
                lstProcess.Items.Add($"{item.ProcessName} ({item.SessionId})");
            }
            Application.DoEvents();
        }

        #endregion Methods
    }
}