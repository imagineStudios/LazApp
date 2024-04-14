using System.ComponentModel;
using System.Runtime.CompilerServices;
using LAZapp.Base;

namespace LAZapp;

internal class QuizViewModel : INotifyPropertyChanged
{
    private List<QuestionViewModel>? questions;
    private int questionIndex;
    private bool isChecked;

    public QuizViewModel()
    {
        BackCommand = new Command(PreviousQuestion, () => questionIndex > 0);
        NextCommand = new Command(NextQuestion, () => questionIndex + 1 < (questions?.Count ?? 0));
        CheckQuestionCommand = new Command(CheckQuestion);
        NewQuiz();
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

    private async void NewQuiz()
    {
        Question[]? q = null;
        //using (var client = new LAZapiClient(new Uri("https://localhost:7242")))
        //{
        //    q = await client.GetRandomQuestions(5);
        //}

        if (q == null)
        {
            q = new LAZapiReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "mannschaft.json")).GetRandomQuestions(5);
        }
        questions = q?.Select(questionIndex => new QuestionViewModel(questionIndex)).ToList();

        QuestionIndex = 0;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
