namespace SangAdv.Updater.Common
{
    public class SAUpdaterRepositorySettings<T> where T : new()
    {
        #region Properties

        public T Settings { get; set; } = new T();

        #endregion Properties

        #region Methods

        public void Reset() => new T();

        public override string ToString()
        {
            return Settings.SAUpdaterSerialise();
        }

        public void FromString(string stringData)
        {
            Settings = stringData.SAUpdaterDeserialise<T>();
        }

        #endregion Methods
    }
}