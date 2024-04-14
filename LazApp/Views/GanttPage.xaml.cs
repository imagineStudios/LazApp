using LazApp.Models;
using LazApp.ViewModels;

namespace LazApp.Views;

[QueryProperty(nameof(Level), "level")]
[QueryProperty(nameof(ScenarioName), "scenario")]
public partial class GanttPage : ContentPage
{
    private readonly AssetService<Scenario> assetService;
    private string level = string.Empty;
    private string scenarioName = string.Empty;

    public GanttPage(AssetService<Scenario> assetService)
    {
        this.assetService = assetService;
        InitializeComponent();
    }

    public string Level
    {
        get => level;
        set
        {
            level = value;
            UpdateBindingContext();
        }
    }

    public string ScenarioName
    {
        get => scenarioName;
        set
        {
            scenarioName = value;
            UpdateBindingContext();
        }
    }

    private void UpdateBindingContext()
    {
        var resourceName = $"{ScenarioName}{Level}";
        if (assetService[resourceName] is Scenario s)
        BindingContext = new GanttPageViewModel(s);
    }
}