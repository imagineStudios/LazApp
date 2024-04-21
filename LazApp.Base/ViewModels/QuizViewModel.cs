using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using LazApp.Base.Models;

namespace LazApp.Base.ViewModels;

public class QuizViewModel : INotifyPropertyChanged
{
    private List<QuestionViewModel>? questions;
    private int questionIndex;
    private bool isChecked;

    public QuizViewModel(IEnumerable<Question> questions)
    {
        BackCommand = new Command(PreviousQuestion, o => questionIndex > 0);
        NextCommand = new Command(NextQuestion, o => questionIndex + 1 < (this.questions?.Count ?? 0));
        CheckQuestionCommand = new Command(CheckQuestion);
        NewQuiz(questions, 10);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public Command NextCommand { get; }

    public Command BackCommand { get; }

    public Command CheckQuestionCommand { get; }

    public QuestionViewModel? CurrentQuestion => questions?[questionIndex];

    public double Progress => 100 * QuestionIndex / (double)(questions?.Count ?? 1);

    private int QuestionIndex
    {
        get => questionIndex;
        set
        {
            questionIndex = value;
            OnPropertyChanged(nameof(CurrentQuestion));
            OnPropertyChanged(nameof(Progress));
            NextCommand.ChangeCanExecute();
            BackCommand.ChangeCanExecute();
        }
    }

    public bool IsChecked
    {
        get => isChecked;
        set
        {
            isChecked = value;
            OnPropertyChanged();
        }
    }

    private void PreviousQuestion(object o)
    {
        QuestionIndex--;
    }

    private void NextQuestion(object o)
    {
        QuestionIndex++;
        IsChecked = false;
    }

    private void CheckQuestion(object o)
    {
        CurrentQuestion?.Check();
        IsChecked = true;
    }

    private void NewQuiz(IEnumerable<Question> questions, int count)
    {
        this.questions = RandomPicker<ProbabilityDecorator<Question>>
                .Draw(questions.Select(q => new ProbabilityDecorator<Question>(q)), count)
                .Select(d => new QuestionViewModel(d.Item))
                .ToList();

        QuestionIndex = 0;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
