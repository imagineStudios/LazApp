using System.Collections.Generic;

namespace LazApp.Base.Models;

public class TimeLine
{
    public string Name { get; set; } = string.Empty;

    public List<Quest> Quests { get; set; } = [];

    public List<Mistake> Mistakes { get; set; } = [];
}
