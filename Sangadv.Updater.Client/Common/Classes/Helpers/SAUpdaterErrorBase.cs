namespace SangAdv.Updater.Common
{
    public class SAUpdaterErrorBase
    {
        public SAUpdaterEventArgs Error { get; set; } = new SAUpdaterEventArgs();
        public bool HasError => Error.HasError;
        public string ErrorMessage => Error.Message;
    }
}