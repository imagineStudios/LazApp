using SQLite;
using System.Collections.Generic;

namespace LAZapp.Base;

public class Question
{
    [PrimaryKey, Unique, AutoIncrement]
    public int Id { get; set; }
    
    [MaxLength(1024)]
    public string Text { get; set; } = string.Empty;

    [Ignore]
    public List<Answer> Answers { get; set; } = new List<Answer>();
}
