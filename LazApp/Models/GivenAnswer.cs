using SQLite;

namespace LazApp.Models;

[Table("givenAnswer")]
public class GivenAnswer()
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public bool WasCorrect { get; set; }

    public DateTime TimeStamp { get; set; }
}

[Table("probabilities")]
public class AnswerProbs()
{
    [PrimaryKey, Column("id")]
    public int QuestionId { get; set; }

    public double Probability { get; set; }
}
