using System.Collections.Generic;

namespace LazApp.Base.Models;

public class Step
{
    public string Description { get; set; } = string.Empty;

    public List<string> OnlyIf { get; set; } = [];

    public List<Mistake> Mistakes { get; set; } = [];
}
