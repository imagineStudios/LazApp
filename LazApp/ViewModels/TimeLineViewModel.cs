﻿using LazApp.Base.Models;
using System.Collections.Generic;
using System.Linq;

namespace LazApp.ViewModels;

public class TimeLineViewModel : ViewModelBase
{
    private readonly TimeLine timeLine;
    private readonly Scenario scenario;

    public TimeLineViewModel(TimeLine timeLine, Scenario scenario)
    {
        this.timeLine = timeLine;
        this.scenario = scenario;
        Quests = timeLine.Quests.Select(q => new QuestViewModel(q, this)).ToList();
        Mistakes = timeLine.Mistakes.Select(m => new MistakeViewModel(m)).ToList();
    }

    public string Name => timeLine.Name;

    public string ScenarioName => scenario.Name;

    public List<QuestViewModel> Quests { get; }

    public List<MistakeViewModel> Mistakes { get; }

    public QuestViewModel this[string name] => Quests.SingleOrDefault(q => q.Name == name);

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
