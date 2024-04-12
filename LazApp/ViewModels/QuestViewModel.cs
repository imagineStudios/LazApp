using LazApp.Models;

namespace LazApp.ViewModels;

public class QuestViewModel(Quest quest) : ViewModelBase 
{
    private readonly Quest quest = quest;

    public string? Name => quest.Name;

    public int StartTime => quest.StartTime;

    public int EndTime => quest.EndTime;

    public int Duration => quest.Duration;

    public int Pause => quest.Pause;

    public string? Command => quest.Command;

    public string? Report => quest.Report;

    public List<MistakeViewModel> Mistakes { get; } = quest.Mistakes.Select(m => new MistakeViewModel(m)).ToList();

    public string Description => string.Join(" ", quest.Steps.Select(s => s.Description));
}
