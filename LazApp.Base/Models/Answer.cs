namespace LazApp.Base.Models;

public class Answer
{
    public int Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
}

public class Environment
{
    public string Department { get; set; }

    public string CallSign { get; set; }

    public bool HasTank { get; set; }

    public bool HasSchnellangriffsverteiler { get; set; }

    public HydraulicType HydraulicGear { get; set; }

    public HaspelType Haspel { get; set; }
}

public enum HydraulicType
{
    Combustion,
    Electric,
    Battery,
}

public enum HaspelType
{
    None,
    Einperson,
    Zweiperson,
}