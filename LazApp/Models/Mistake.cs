namespace LazApp.Models;

public class Mistake
{
    public int Points { get; set; }

    public bool IsMulti { get; set; }

    public string Description { get; set; } = string.Empty;
}
