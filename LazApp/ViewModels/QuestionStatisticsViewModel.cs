using LazApp.Base.Models;
using LazApp.Models;

namespace LazApp.ViewModels;

public class QuestionStatisticsViewModel
{
    private static readonly Color RightColor = Color.FromArgb("4000ff4c");
    private static readonly Color WrongColor = Color.FromArgb("ffff3c00");

    public QuestionStatisticsViewModel(Repository<GivenAnswer> answerRepo, Question question)
    {
        var answers = answerRepo
            .GetAll(a => a.QuestionId == question.Id)
            .OrderByDescending(a => a.TimeStamp)
            .Take(5)
            .Reverse();

        var col = new Color(255, 255, 255, 20);
        foreach (var a in answers)
        { 
            col = (a.WasCorrect ? RightColor : WrongColor).OverlayOnto(col);
        }
        Color = col;
        Id = question.Id;
        Question = question.Text;
    }

    public int Id { get; }

    public string Question { get; }

    public Color Color { get; }
}
