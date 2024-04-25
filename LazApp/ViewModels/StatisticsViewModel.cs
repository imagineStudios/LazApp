using LazApp.Base.Models;
using LazApp.Models;
using System.Collections.ObjectModel;

namespace LazApp.Base.ViewModels;

public class StatisticsViewModel : ViewModelBase
{
    private readonly Question[] questions;
    private readonly Repository<GivenAnswer> answerRepo;
    private bool isInitialized;

    public StatisticsViewModel(
        AssetService<Question[]> repo,
        Repository<GivenAnswer> answers)
    {
        questions = repo["mannschaft"] ?? [];
        answerRepo = answers;
    }

    public ObservableCollection<QuestionStatisticsViewModel> Questions { get; } = [];

    public bool IsBusy { get; private set; } = true;

    internal async Task InitAsync()
    {
        if (!isInitialized)
        {
            IsBusy = true;
            await LoadAsync();
            isInitialized = true;
        }
    }

    public async Task LoadAsync()
    {
        await Task.Run(() =>
        {
            foreach (var question in questions)
            {
                Questions.Add(new QuestionStatisticsViewModel(answerRepo, question));
            }
        });
    }
}
