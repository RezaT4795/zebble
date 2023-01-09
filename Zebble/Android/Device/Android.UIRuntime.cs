namespace Zebble
{
    using System;

    partial class UIRuntime
    {
        public static Android.App.Activity CurrentActivity;

        public static Android.Content.Context AppContext
            => CurrentActivity?.ApplicationContext ?? Android.App.Application.Context;

        /// <summary>
        /// This will be called whenever a new Intent starts
        /// </summary>
        public static readonly AsyncEvent<Android.Content.Intent> OnNewIntent = new();

        public static readonly AsyncEvent<Tuple<int, Android.App.Result, Android.Content.Intent>> OnActivityResult = new();

        internal const bool IsDevMode = false;

        public static Android.Content.Intent LauncherActivity
        {
            get
            {
                var context = Android.App.Application.Context;
                return context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
            }
        }

        public static TService GetService<TService>(string serviceName) where TService : Java.Lang.Object
        {
            return (TService)CurrentActivity.GetSystemService(serviceName);
        }
    }
}