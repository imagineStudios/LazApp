﻿using LazApp.Base;
using LazApp.Base.Models;

namespace LazApp.ViewModels;

public class QuestViewModel(Quest quest, TimeLineViewModel timeline) : ViewModelBase 
{
    private readonly Quest quest = quest;

    public TimeLineViewModel Timeline { get; } = timeline;

    public string? Name => quest.Name;

    public int Duration => quest.Duration;

    public IEnumerable<string> Requires => quest.Requires;

    public string? Command => quest.Command;

    public string? Report => quest.Report;

    public List<QuestViewModel> RequiredQuests { get; } = [];

    public int StartTime => RequiredQuests.Concat(Predecessor).Select(p => p.EndTime).AppendZero().Max();

    public int EndTime => StartTime + Duration;

    public int Pause => StartTime - (Predecessor?.EndTime ?? 0);

    public List<MistakeViewModel> Mistakes { get; } = quest.Steps.SelectMany(s => s.Mistakes).Select(m => new MistakeViewModel(m)).ToList();

    public string Description => string.Join(" ", quest.Steps.Select(s => s.Description));

    public QuestViewModel? Predecessor { get; internal set; }
}
