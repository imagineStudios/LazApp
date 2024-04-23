using LazApp.Base.Models;
using LazApp.Base.ViewModels;
using LazApp.Views;
using Microsoft.Extensions.Logging;

namespace LazApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            //.UseTimeLine()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
            });

        builder.Services.AddSingleton(s =>
            ActivatorUtilities.CreateInstance<AssetService<Scenario>>(s, "HilfeleistungSilber.json|BrandeinsatzSilber.json"));
        builder.Services.AddSingleton(s =>
            ActivatorUtilities.CreateInstance<AssetService<Question[]>>(s, "mannschaft.json"));

        builder.Services.AddSingleton(typeof(ScenarioService));
        builder.Services.AddSingleton(typeof(ScenarioViewModel));
        //builder.Services.AddSingleton(typeof(GanttPage));
        builder.Services.AddSingleton(typeof(MainPage));
        builder.Services.AddSingleton(typeof(TrainingPage));
        builder.Services.AddSingleton(typeof(QuizPage));
        builder.Services.AddSingleton(typeof(QuestPage));

        builder.Services.AddTransient(typeof(GanttPage));
#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
