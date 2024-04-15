using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LazApp.Base.Models;
using LazApp.Base.ViewModels;
using Newtonsoft.Json;

namespace LazApp.Wpf
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double zoom = 1.0;
        private QuestViewModel selectedQuest;

        public MainWindowViewModel()
        {
            var json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "HilfeleistungSilber.json"));
            var scenario = JsonConvert.DeserializeObject<Scenario>(json);
            Scenario = new ScenarioViewModel(scenario);
        }

        public ScenarioViewModel Scenario { get; }

        public List<int> Ticks { get; } = Enumerable.Range(0, (480 / 30) + 1).Select(i => i * 30).ToList();

        public double Zoom
        {
            get => zoom;
            set
            {
                zoom = value;
                OnPropertyChanged();
            }
        }

        public QuestViewModel SelectedQuest
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
