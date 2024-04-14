using LazApp.Models;
using System.Reflection;
using System.Text.Json;

namespace LazApp.ViewModels
{
    public class GanttPageViewModel : ViewModelBase
    {
        private readonly Scenario? scenario;
        private double zoom = 1.0;
        private QuestViewModel? selectedQuest;

        public GanttPageViewModel(string? level, AssetService assetService)
        {
            scenario = assetService[level];
            scenario.Init();
            TimeLines = scenario.TimeLines.Select(tl => new TimeLineViewModel(tl)).ToList();
        }

        public string? Name => scenario?.Name;

        public List<TimeLineViewModel> TimeLines { get; } = [];

        public double Zoom
        {
            get => zoom;
            set
            {
                zoom = value;
                OnPropertyChanged();
            }
        }

        public QuestViewModel? SelectedQuest
        {
            get => selectedQuest;
            set
            {
                selectedQuest = value;
                OnPropertyChanged();
            }
        }
    }
}
