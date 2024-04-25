namespace LazApp.Views;

public partial class MistakesPage : ContentPage
{
    private readonly ScenarioService scenarioService;

    public MistakesPage(ScenarioService scenarioService)
	{
        this.scenarioService = scenarioService;
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //BindingContext = scenarioService[Scenario];
    }
}