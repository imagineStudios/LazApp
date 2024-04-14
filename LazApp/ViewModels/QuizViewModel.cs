using System.ComponentModel;
using System.Runtime.CompilerServices;
using LazApp.Base;

namespace LazApp.ViewModels;

internal class QuizViewModel : INotifyPropertyChanged
{
    private List<QuestionViewModel>? questions;
    private int questionIndex;
    private bool isChecked;

    public QuizViewModel(IEnumerable<Question> questions)
    {
        NewQuiz(questions, 10);
        BackCommand = new Command(PreviousQuestion, () => questionIndex > 0);
        NextCommand = new Command(NextQuestion, () => questionIndex + 1 < (this.questions?.Count ?? 0));
        CheckQuestionCommand = new Command(CheckQuestion);
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

    private void PreviousQuestion()
    {
        QuestionIndex--;
    }

    private void NextQuestion()
    {
        QuestionIndex++;
        IsChecked = false;
    }

    private void CheckQuestion()
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
