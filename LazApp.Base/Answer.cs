using SQLite;

namespace LAZapp.Base;

[Table("Answers")]
public class Answer
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(1024)]
    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }

    [Indexed]
    public int QuestionId { get; set; }
}