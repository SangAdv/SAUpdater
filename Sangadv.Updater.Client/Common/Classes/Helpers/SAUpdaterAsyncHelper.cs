using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterAsyncHelper

    {
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;
            return Task.Factory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap().GetAwaiter().GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            Task.Factory.StartNew(func).Unwrap().GetAwaiter().GetResult();
        }
    }
}