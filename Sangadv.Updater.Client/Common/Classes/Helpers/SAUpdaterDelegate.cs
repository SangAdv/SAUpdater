namespace SangAdv.Updater.Common
{
    public delegate void UpdaterEmptyDelegate();

    public delegate void UpdaterBooleanDelegate(bool booleanValue);

    public delegate void UpdaterIntegerDelegate(int integerValue);

    public delegate void UpdaterStringDelegate(string stringValue);

    public delegate void UpdaterStringBooleanDelegate(string stringValue, bool booleanValue);

    public delegate void UpdaterStringStringStatusDelegate(string stringValue1, string stringValue2, SAUpdaterStatusIcon icon);
}