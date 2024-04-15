using System.Collections.Generic;

namespace LazApp.Base.Models;

public class Quest
{
    public string? Name { get; set; }

    public string? Command { get; set; }

    public string? Report { get; set; }

    public int Duration { get; set; }

    public List<string> Requires { get; set; } = [];

    public List<Step> Steps { get; set; } = [];
}
