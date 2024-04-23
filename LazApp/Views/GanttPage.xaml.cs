using LazApp.Base.ViewModels;

namespace LazApp.Views;

[QueryProperty(nameof(ScenarioName), "scenario")]
public partial class GanttPage : ContentPage
{
    private readonly ScenarioService scenarioService;

    public GanttPage(ScenarioService scenarioService)
    {
        this.scenarioService = scenarioService;
        InitializeComponent();
    }

    public string ScenarioName
    {
        set
        {
            scenarioService.ScenarioName = value;
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