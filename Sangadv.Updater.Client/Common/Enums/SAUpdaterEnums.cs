namespace SangAdv.Updater.Common
{
    public enum SAUpdaterRepositoryType : int
    {
        FTP = 1
    }

    public enum SAUpdaterAppStatus : int
    {
        New = 0,
        Defined = 1,
        Uploaded = 2,
        Published = 3,
        OK = 4,
        Missing = 5
    }

    public enum SAUpdaterAppVersionStatus : int
    {
        New = 0,
        Defined = 1,
        Uploaded = 2,
        Published = 3
    }

    public enum SAUpdaterAppFileStatus : int
    {
        OK = 0,
        No = 1,
        Dot = 2,
        Blank = 3
    }

    public enum SAUpdaterFrameworkVersions
    {
        None = 0,
        Version45 = 1,
        Version451 = 2,
        Version452 = 3,
        Version46 = 4,
        Version461 = 5,
        Version462 = 6,
        Version47 = 7,
        Version471 = 8,
        Version472 = 9,
        Version48 = 10
    }

    public enum SAUpdaterOSType
    {
        Windows = 1,
        MacOs = 2,
        Linux = 3
    }

    public enum SAUpdaterWinOSVersion
    {
        Unknown = -1,
        Old = 0,
        Win7 = 1,
        Win8 = 2,
        Win81 = 3,
        Win10 = 4,
        Win101511 = 5,
        Win101607 = 6,
        Win101703 = 7,
        Win101709 = 8,
        Win101803 = 9,
        Win101809 = 10,
        vNext = 99
    }

    public enum SAUpdaterOption : int
    {
        AlwaysUpdate = 1,
        UpdateIfOlderThan = 2,
        UpdateIfMissing = 3,
        NeverUpdate = 4
    }

    public enum SAUpdaterReleaseType
    {
        Alpha = 0,
        Beta = 1,
        RC1 = 2,
        RC2 = 3,
        Release = 9
    }

    internal enum SAUpdaterDefinitionType : int
    {
        Notes = 1,
        Files = 2
    }
}