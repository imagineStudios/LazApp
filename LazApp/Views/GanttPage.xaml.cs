using LazApp.Base.Models;
using LazApp.Base.ViewModels;

namespace LazApp.Views;

[QueryProperty(nameof(Level), "level")]
[QueryProperty(nameof(ScenarioName), "scenario")]
public partial class GanttPage : ContentPage
{
    private readonly ScenarioService scenarioService;
    private string level = string.Empty;
    private string scenarioName = string.Empty;

    public GanttPage(ScenarioService scenarioService)
    {
        this.scenarioService = scenarioService;
        InitializeComponent();
    }

    public string Level
    {
        get => level;
        set
        {
            level = value;
            scenarioService.Level = level;
            BindingContext = scenarioService.Scenario;
        }
    }

    public string ScenarioName
    {
        get => scenarioName;
        set
        {
            scenarioName = value;
            scenarioService.ScenarioName = scenarioName;
            BindingContext = scenarioService.Scenario;
        }
    }

    private async void Quest_Clicked(object sender, EventArgs e)
    {
        if (sender is Element fe && fe.BindingContext is QuestViewModel qvm)
        {
            await Shell.Current.GoToAsync($"quest?questname={qvm.Name}&timeline={qvm.Timeline}");
        }
    }
}