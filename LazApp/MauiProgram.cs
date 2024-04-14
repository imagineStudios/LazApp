using LazApp.Models;
using LazApp.ViewModels;
using LazApp.Views;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace LazApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(typeof(AssetService));
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<GanttPageViewModel>(s));
            builder.Services.AddSingleton(typeof(GanttPage));
            builder.Services.AddSingleton(typeof(MainPage));
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
