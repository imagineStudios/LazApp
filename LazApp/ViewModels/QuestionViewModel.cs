using LAZapp.Base;
using System.ComponentModel;

namespace LAZapp;

internal class QuestionViewModel(Question question) : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public int Id => question.Id;

    public string Text => question.Text;

    public List<AnswerViewModel> Answers { get; } = question.Answers.Select(a => new AnswerViewModel(a)).ToList();

    public void Check()
    {
        Answers.ForEach(a => a.Check());
    }
}