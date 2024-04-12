using LazApp.Models;

namespace LazApp.ViewModels;

public class TimeLineViewModel(TimeLine timeLine) : ViewModelBase
{
    private readonly TimeLine timeLine = timeLine;

    public string Name => timeLine.Name;

    public List<QuestViewModel> Quests { get; } = timeLine.Quests.Select(q => new QuestViewModel(q)).ToList();
}
