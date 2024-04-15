using System.Collections.Generic;

namespace LazApp.Base.Models;

public class Scenario
{
    public string Name { get; set; } = string.Empty;

    public List<TimeLine> TimeLines { get; set; } = [];

    public List<Mistake> Mistakes { get; set; } = [];
}
