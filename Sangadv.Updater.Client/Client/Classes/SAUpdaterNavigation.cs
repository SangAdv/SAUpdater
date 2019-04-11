﻿using SangAdv.Updater.Common;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    internal class SAUpdaterNavigation
    {
        #region Events

        internal event UpdaterEmptyDelegate CloseInstaller = () => { };

        internal event UpdaterBooleanDelegate InstallCompleted = (b) => { };

        internal event UpdaterBooleanDelegate ChangeControlBoxStatus = b => { };

        #endregion Events

        #region Variables

        private Panel mClientPanel;
        private Dictionary<int, ucBaseControl> mQueue = new Dictionary<int, ucBaseControl>();
        private int mCurrentIndex = 0;

        #endregion Variables

        #region Properties

        internal int Count => mQueue.Count;

        #endregion Properties

        #region Constructor

        public SAUpdaterNavigation(Panel clientPanel)
        {
            mClientPanel = clientPanel;
        }

        #endregion Constructor

        #region Methods

        public void Add(ucBaseControl control)
        {
            var tNewIndex = !mQueue.Any() ? 1 : mQueue.Keys.Max() + 1;
            mQueue.Add(tNewIndex, control);
        }

        public void Add(SAApplicationType applicationType)
        {
            switch (applicationType)
            {
                case SAApplicationType.KillProcess: Add(new ucKillProcess()); break;
                case SAApplicationType.Download: Add(new ucDownload()); break;
                case SAApplicationType.DownloadFiles: Add(new ucDownloadFiles()); break;
                case SAApplicationType.Install: Add(new ucInstall()); break;
                case SAApplicationType.InstallEnd: Add(new ucEnd()); break;
            }
        }

        public void ShowFirst()
        {
            mCurrentIndex = 1;
            DisplayControl(mQueue[mCurrentIndex]);
        }

        internal void DisplayError(string heading, string message, SAUpdaterStatusIcon icon)
        {
            var ec = new ucError(heading, message, icon);
            DisplayControl(ec);
            InstallCompleted(false);
        }

        internal void AddInstallInstaller(ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client, SAUpdaterUpdateOptions options, string applicationTitle)
        {
            var uc2 = new ucInstallInstaller();
            Add(uc2);
        }

        #endregion Methods

        #region Private Methods

        private void GotoNext()
        {
            mCurrentIndex++;
            if (mCurrentIndex > mQueue.Count)
            {
                InstallCompleted(true);
                return;
            }
            ControlLoadState();
            DisplayControl(mQueue[mCurrentIndex]);
        }

        private void ControlLoadState()
        {
            mClientPanel.Enabled = false;
            mClientPanel.Cursor = Cursors.WaitCursor;
            mClientPanel.Controls.Clear();
        }

        private void DisplayControl(ucBaseControl control)
        {
            control.ActionButtonClicked += GotoNext;
            control.ErrorOccured += DisplayError;
            control.CloseInstaller += CloseInstaller;
            control.InstallCompleted += InstallCompletedTrue;
            control.ChangeControlBoxStatus += ChangeControlBoxStatus;

            mClientPanel.SuspendLayout();
            mClientPanel.Controls.Add(control);
            control.BringToFront();
            control.Dock = DockStyle.Fill;
            mClientPanel.Cursor = Cursors.Default;
            mClientPanel.Enabled = true;
            mClientPanel.ResumeLayout();

            control.ExecuteStart();
        }

        private void InstallCompletedTrue() => InstallCompleted(true);

        #endregion Private Methods
    }
}