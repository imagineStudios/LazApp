using LazApp.Base.Models;
using System.Collections.Generic;
using System.Linq;

namespace LazApp.ViewModels;

public class QuestionViewModel(Question question) : ViewModelBase
{
    public int Id => question.Id;

    public string Text => question.Text;

    public List<AnswerViewModel> Answers { get; } = question.Answers.Select(a => new AnswerViewModel(a)).ToList();

    public bool Check()
    {
        Answers.ForEach(a => a.Check());
        return Answers.All(a => a.AnsweredCorrectly ?? false);
    }
}