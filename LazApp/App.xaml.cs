namespace LazApp
{
    public partial class App : Application
    {
        public App(ScenarioService scenarioService)
        {
            InitializeComponent();
            MainPage = new AppShell(scenarioService);
        }
    }
}
