
namespace LazApp.Views;

[QueryProperty(nameof(Level), "level")]
[QueryProperty(nameof(ScenarioName), "scenario")]
public partial class MistakesPage : ContentPage
{
    private readonly ScenarioService scenarioService;

    public MistakesPage(ScenarioService scenarioService)
	{
        this.scenarioService = scenarioService;
        Loaded += MistakesPage_Loaded;
        InitializeComponent();
    }

    private void MistakesPage_Loaded(object? sender, EventArgs e)
    {
        scenarioService.ScenarioName = $"{ScenarioName}{Level}";
        BindingContext = scenarioService.Scenario;
    }

    public string Level { get; set; } = string.Empty;

    public string ScenarioName { get; set; } = string.Empty;
}