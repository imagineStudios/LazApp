using LazApp.Base.Models;
using System.Collections.Generic;
using System.Linq;

namespace LazApp.Base.ViewModels;

public class TimeLineViewModel(TimeLine timeLine) : ViewModelBase
{
    private readonly TimeLine timeLine = timeLine;

    public string Name => timeLine.Name;

    public List<QuestViewModel> Quests { get; } = timeLine.Quests.Select(q => new QuestViewModel(q)).ToList();

    internal void Init(IEnumerable<TimeLineViewModel> timeLines)
    {
        QuestViewModel? last = null;
        foreach (var q in Quests)
        {
            q.Predecessor = last;
            last = q;

            foreach (var requirement in q.Requires.Select(r => r.Split('|')))
            {
                if (requirement.Length == 2
                    && timeLines.SingleOrDefault(t => t.Name == requirement[0]) is TimeLineViewModel tlvm
                    && tlvm.Quests.SingleOrDefault(q => q.Name == requirement[1]) is QuestViewModel qvm)
                {
                    q.RequiredQuests.Add(qvm);
                }
            }
        }
    }
}
