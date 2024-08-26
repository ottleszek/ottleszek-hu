using Microsoft.Extensions.DependencyInjection;

namespace WillBeThere.Shared.Helper
{
    public static class ServiceHelper
    {
        /*
         public static T GetService<TService>() =>      Current.GetService<TService>();

         public static IServiceProvider Current =>
 #if WINDOWS10_0_17763_0_OR_GREATER
     MauiWinUIApplication.Current.Services;
 #elif ANDROID
     MauiApplication.Current.Services;
 #elif IOS || MACCATALYST
     MauiUIApplicationDelegate.Current.Services;
 #else
             null;
 #endif */
        public static IServiceProvider? Services { get; private set; } = null;

        public static void Initialize(IServiceProvider serviceProvider) => Services = serviceProvider;

        public static T? GetService<T>() => Services != null ? Services.GetService<T>() : default;

    }
}
