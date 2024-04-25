using LazApp.Base.ViewModels;
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

        public ScenarioViewModel BrandeinsatzSilber => scenarioService["BrandeinsatzSilber"];

        public ScenarioViewModel HilfeleistungSilber => scenarioService["HilfeleistungSilber"];

        public ScenarioViewModel BrandeinsatzGold => scenarioService["BrandeinsatzSilber"];

        public ScenarioViewModel HilfeleistungGold => scenarioService["HilfeleistungSilber"];

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
        }
    }
}
