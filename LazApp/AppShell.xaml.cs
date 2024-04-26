using LazApp.ViewModels;
using LazApp.Views;

namespace LazApp
{
    public partial class AppShell : Shell
    {
        private readonly ScenarioService scenarioService;

        public AppShell(ScenarioService scenarioService)
        {
            this.scenarioService = scenarioService;
            InitializeComponent();
            BindingContext = this;
            Routing.RegisterRoute("levelstart", typeof(LevelStartPage));
            Routing.RegisterRoute("gantt", typeof(GanttPage));
            Routing.RegisterRoute("quest", typeof(QuestPage));
            Routing.RegisterRoute("quiz", typeof(QuizPage));
        }

        public GanttPageViewModel BrandeinsatzBronze => new GanttPageViewModel(scenarioService["BrandeinsatzSilber"]);

        public GanttPageViewModel BrandeinsatzSilber => new GanttPageViewModel(scenarioService["BrandeinsatzSilber"]);

        public GanttPageViewModel HilfeleistungSilber => new GanttPageViewModel(scenarioService["HilfeleistungSilber"]);

        public GanttPageViewModel BrandeinsatzGold => new GanttPageViewModel(scenarioService["BrandeinsatzSilber"]);

        public GanttPageViewModel HilfeleistungGold => new GanttPageViewModel(scenarioService["HilfeleistungSilber"]);

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
        }
    }
}
