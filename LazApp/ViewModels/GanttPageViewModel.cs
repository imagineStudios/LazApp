﻿using LazApp.Models;
using System.Text.Json;

namespace LazApp.ViewModels
{
    public class GanttPageViewModel : ViewModelBase
    {
        private readonly Scenario? scenario;
        private double zoom = 1.0;
        private QuestViewModel? selectedQuest;

        public GanttPageViewModel(string? level)
        {
            var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", $"Hilfeleistung{level ?? string.Empty}.json");
            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                scenario = JsonSerializer.Deserialize<Scenario>(json);
                if (scenario != null)
                {
                    scenario.Init();
                    TimeLines = scenario.TimeLines.Select(tl => new TimeLineViewModel(tl)).ToList();
                }
            }
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