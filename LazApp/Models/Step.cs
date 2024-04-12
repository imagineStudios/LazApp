namespace LazApp.Models;

public class Step
{
    public string Description { get; set; } = string.Empty;

    public List<string> OnlyIf { get; set; } = [];
}
