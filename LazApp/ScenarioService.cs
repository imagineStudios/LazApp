using LazApp.Base.Models;
using LazApp.Base.ViewModels;

namespace LazApp
{
    public class ScenarioService(AssetService<Scenario> assetService)
    {
        private readonly AssetService<Scenario> assetService = assetService;
        private string scenarioName = string.Empty;

        public string ScenarioName
        {
            get => scenarioName;
            set
            {
                scenarioName = value;
                Scenario = assetService[scenarioName] is Scenario s
                       ? new ScenarioViewModel(s)
                       : null;
            }
        }


        public ScenarioViewModel? Scenario { get; private set; }
    }
}
