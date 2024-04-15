using System.Collections.Generic;

namespace LazApp.Base.Models;

public class Question
{
    public int Id { get; set; }
    
    public string Text { get; set; } = string.Empty;

    public List<Answer> Answers { get; set; } = new List<Answer>();
}
