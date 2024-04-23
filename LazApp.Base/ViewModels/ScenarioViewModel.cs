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
        Mistakes = scenario.Mistakes.Select(m => new MistakeViewModel(m)).ToList();
        TimeLines = this.scenario.TimeLines.Select(tl => new TimeLineViewModel(tl)).ToList();
        TimeLines.ForEach(t => t.Init(TimeLines));
    }

    public string? Name => scenario?.Name;

    public List<MistakeViewModel> Mistakes { get; }

    public List<TimeLineViewModel> TimeLines { get; set; }

    public TimeLineViewModel this[string name] => TimeLines.SingleOrDefault(t => t.Name == name);
}
