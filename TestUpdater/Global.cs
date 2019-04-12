namespace SangAdv.Updater.Client
{
    internal class Global
    {
        internal static bool HasCommandLineArgs
        {
            get
            {
                if (CommandLineArgs == null) return false;
                if (CommandLineArgs.Length == 0) return false;
                return true;
            }
        }

        internal static string[] CommandLineArgs { get; set; }
    }
}