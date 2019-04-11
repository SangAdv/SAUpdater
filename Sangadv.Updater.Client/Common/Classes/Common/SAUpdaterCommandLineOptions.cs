namespace SangAdv.Updater.Common
{
    public class SAUpdaterCommandLineOptions
    {
        public string ApplicationFolder { get; set; } = string.Empty;
        public SAUpdaterReleaseType AllowedReleaseType { get; set; } = SAUpdaterReleaseType.Release;
        public bool ResetStartupSettings { get; set; } = false;
    }
}