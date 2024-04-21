using LazApp.Base.Models;
using LazApp.Base.ViewModels;

namespace LazApp
{
    public class ScenarioService(AssetService<Scenario> assetService)
    {
        private readonly AssetService<Scenario> assetService = assetService;
        private string level = string.Empty;
        private string scenarioName = string.Empty;

        public string Level
        {
            get => level;
            set
            {
                level = value;
                UpdateScenario();
            }
        }

        public string ScenarioName
        {
            get => scenarioName;
            set
            {
                scenarioName = value;
                UpdateScenario();
            }
        }

        private void UpdateScenario()
        {
            var resourceName = $"{ScenarioName}{Level}";
            Scenario = assetService[resourceName] is Scenario s
                   ? new ScenarioViewModel(s)
                   : null;
        }


        public ScenarioViewModel? Scenario { get; private set; }
     
    }
}
