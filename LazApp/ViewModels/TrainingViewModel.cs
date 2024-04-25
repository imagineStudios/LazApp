using LazApp.Base.Models;
using LazApp.Models;

namespace LazApp.Base.ViewModels;

public class TrainingViewModel : ViewModelBase
{
    private readonly AssetService<Question[]> repo;
    private readonly Repository<GivenAnswer> answers;
    private readonly Repository<AnswerProbs> probabilityRepo;
    private QuestionViewModel currentQuestion;
    private bool isChecked;

    public TrainingViewModel(
        AssetService<Question[]> repo,
        Repository<GivenAnswer> answers,
        Repository<AnswerProbs> probabilityRepo)
    {
        this.repo = repo;
        this.answers = answers;
        this.probabilityRepo = probabilityRepo;
        NextQuestion();
        CheckCommand = new Command(o => Check());
        NextCommand = new Command(o => NextQuestion());
    }

    public Command CheckCommand { get; }

    public Command NextCommand { get; }

    public QuestionViewModel CurrentQuestion
    {
        get => currentQuestion;
        private set
        {
            currentQuestion = value;
            OnPropertyChanged();
        }
    }

    public bool IsChecked
    {
        get => isChecked;
        private set
        {
            isChecked = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsNotChecked));
        }
    }

    public bool IsNotChecked => !isChecked;

    private void Check()
    {
        var wasCorrect = CurrentQuestion.Check();
        IsChecked = true;
        var answer = new GivenAnswer()
        {
            QuestionId = CurrentQuestion.Id,
            WasCorrect = wasCorrect,
            TimeStamp = DateTime.Now,
        };
        answers.Add(answer);
        var prob = probabilityRepo.Get(p => p.QuestionId == CurrentQuestion.Id);
        if (prob == null)
        {
            probabilityRepo.Add(new AnswerProbs()
            {
                QuestionId = currentQuestion.Id,
                Probability = wasCorrect ? 0.67 : 1.0,
            });
        }
        else
        {
            prob.Probability = wasCorrect ? prob.Probability * 0.66 : 1.0;
            probabilityRepo.Update(prob);
        }
    }

    private void NextQuestion()
    {
        var items = repo["mannschaft"].Select(GetProbabilityDecorator);
        var picker = new RandomPicker<ProbabilityDecorator<Question>>(items);
        var question = picker.Draw().Item;
        CurrentQuestion = new QuestionViewModel(question);
        IsChecked = false;
    }

    private ProbabilityDecorator<Question> GetProbabilityDecorator(Question q)
    {
        var probability = probabilityRepo.Get(p => p.QuestionId == q.Id);
        return new ProbabilityDecorator<Question>(q, probability?.Probability ?? 1.0);
    }
}
