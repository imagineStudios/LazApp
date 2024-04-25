using LazApp.Base.ViewModels;

namespace LazApp.Views;

[QueryProperty(nameof(Scenario), "scenario")]
[QueryProperty(nameof(TimeLine), "timeline")]
[QueryProperty(nameof(QuestName), "questname")]
public partial class QuestPage : ContentPage
{
    private readonly ScenarioService scenarioService;

    public QuestPage(ScenarioService scenarioService)
	{
		this.scenarioService = scenarioService;
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        BindingContext = scenarioService[Scenario][TimeLine][QuestName];
    }

    public string Scenario { get; set; }

    public string TimeLine { get; set; }

	public string QuestName { get; set; }

    public QuestViewModel Quest { get; private set; }
}