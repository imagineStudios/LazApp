namespace LazApp.Models;

public class Quest
{
    public string? Name { get; set; }

    public string? Command { get; set; }

    public string? Report { get; set; }

    public int Duration { get; set; }

    public List<string> Requires { get; set; } = [];

    public List<Step> Steps { get; set; } = [];

    public List<Mistake> Mistakes { get; set; } = [];

    public List<Quest> RequiredQuests { get; } = [];

    public Quest? Predecessor { get; set; }

    public int StartTime => RequiredQuests.Concat(Predecessor).Select(p => p.EndTime).AppendZero().Max();

    public int Pause => StartTime - (Predecessor?.EndTime ?? 0);

    public int EndTime => StartTime + Duration;
}
