using CommunityToolkit.Maui;
using LazApp.Base.Models;
using LazApp.Models;
using LazApp.ViewModels;
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
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesome6");
            });

        builder.Services.AddSingleton(new AssetService<Scenario>("HilfeleistungSilber.json|BrandeinsatzSilber.json"));
        builder.Services.AddSingleton(new AssetService<Question[]>("mannschaft.json"));
        builder.Services.AddSingleton(new Repository<GivenAnswer>(Path.Combine(FileSystem.AppDataDirectory, "User.db")));
        builder.Services.AddSingleton(new Repository<AnswerProbs>(Path.Combine(FileSystem.AppDataDirectory, "User.db")));

        builder.Services.AddSingleton(typeof(ScenarioService));
        builder.Services.AddSingleton(typeof(ScenarioViewModel));
        builder.Services.AddSingleton(typeof(MainPage));
        builder.Services.AddSingleton(typeof(QuizPage));
        builder.Services.AddSingleton(typeof(QuestPage));

        builder.Services.AddTransient(typeof(TrainingPage));
        builder.Services.AddTransient(typeof(TrainingViewModel));
        builder.Services.AddTransient(typeof(StatisticsPage));
        builder.Services.AddTransient(typeof(StatisticsViewModel));
        builder.Services.AddTransient(typeof(GanttPage));
        builder.Services.AddTransient(typeof(MistakesPage));
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
