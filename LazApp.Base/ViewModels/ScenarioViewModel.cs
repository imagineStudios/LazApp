using System.Collections.Generic;
using System.Linq;
using LazApp.Base.Models;

namespace LazApp.Base.ViewModels;

public class ScenarioViewModel : ViewModelBase
{
    private readonly Scenario? scenario;

    public ScenarioViewModel(Scenario scenario)
    {
        this.scenario = scenario;
        TimeLines = this.scenario.TimeLines.Select(tl => new TimeLineViewModel(tl)).ToList();
        TimeLines.ForEach(t => t.Init(TimeLines));
    }

    public string? Name => scenario?.Name;

    public List<TimeLineViewModel> TimeLines { get; set; }
}
