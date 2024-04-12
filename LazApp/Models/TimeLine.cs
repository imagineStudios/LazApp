using System.Runtime.Serialization;

namespace LazApp.Models;

public class TimeLine
{
    public string Name { get; set; } = string.Empty;

    public List<Quest> Quests { get; set; } = [];

    public List<Mistake> Mistakes { get; set; } = [];

    public Quest? this[string questName] => Quests.SingleOrDefault(q => q.Name == questName);

    internal void Init()
    {
        Quest? last = null;
        foreach (var q in Quests)
        {
            q.Predecessor = last;
            last = q;
        }
    }
}
