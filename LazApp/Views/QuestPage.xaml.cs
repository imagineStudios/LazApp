using LazApp.Base.ViewModels;

namespace LazApp.Views;

[QueryProperty(nameof(TimeLine), "timeline")]
[QueryProperty(nameof(QuestName), "questname")]
public partial class QuestPage : ContentPage
{
    private readonly ScenarioService scenarioService;

    public QuestPage(ScenarioService scenarioService)
	{
		this.scenarioService = scenarioService;
        Loaded += QuestPage_Loaded;
		InitializeComponent();
	}

    private void QuestPage_Loaded(object? sender, EventArgs e)
    {
        BindingContext = scenarioService.Scenario[TimeLine][QuestName];
    }

    public string TimeLine { get; set; }

	public string QuestName { get; set; }

    public QuestViewModel Quest { get; private set; }
}