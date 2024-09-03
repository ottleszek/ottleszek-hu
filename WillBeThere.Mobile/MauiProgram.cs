using Microsoft.Extensions.Logging;
using WillBeThere.Mobile.Extensions;
using WillBeThere.Domain.Helper;

namespace WillBeThere.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.ConfigureHttpClient();
            builder.Services.ConfigureAssamblers();
            builder.Services.ConfigureServices();
            builder.Services.ConfigureViewModels();
            builder.Services.ConfigurePages();
            
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            

            // return builder.Build();
            var app = builder.Build();
            //var service= app.Services.GetService<MainPageViewModel>();
            ServiceHelper.Initialize(app.Services);

            return app;
        }
    }
}
