﻿using LazApp.Views;

namespace LazApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("levelstart", typeof(LevelStartPage));
            Routing.RegisterRoute("gantt", typeof(GanttPage));
            Routing.RegisterRoute("quest", typeof(QuestPage));
            Routing.RegisterRoute("quiz", typeof(QuizPage));
        }
    }
}
