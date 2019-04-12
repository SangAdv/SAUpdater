namespace SangAdv.Updater
{
    public enum SAUpdaterModuleType
    {
        Download = 1,
        DownloadFiles = 2,
        Install = 3,
        KillProcess = 4,
        InstallEnd = 10,
        SQLInstall = 100
    }

    public enum SAUpdaterStatusIcon
    {
        Info = 0,
        Warning = 1,
        Stop = 2
    }

}