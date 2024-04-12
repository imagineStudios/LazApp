using System.Runtime.Serialization;

namespace LazApp.Models;

public class Scenario
{
    public string Name { get; set; } = string.Empty;

    public List<TimeLine> TimeLines { get; set; } = [];

    public TimeLine? this[string name] => TimeLines.SingleOrDefault(t => t.Name == name);

    internal void Init()
    {
        TimeLines.ForEach(t => t.Init());
        foreach (var quest in TimeLines.SelectMany(tl => tl.Quests))
        {
            foreach (var requirement in quest.Requires.Select(r => r.Split('|')))
            {
                quest.RequiredQuests.Add(this[requirement[0]][requirement[1]]);
            }
        }
    }
}
