using LazApp.Base.Models;
using LazApp.ViewModels;

namespace LazApp
{
    public class ScenarioService(AssetService<Scenario> assetService)
    {
        private readonly AssetService<Scenario> assetService = assetService;
        private string scenarioName = string.Empty;

        public ScenarioViewModel? this[string scenario] => new ScenarioViewModel(assetService[scenario]);
    }
}
