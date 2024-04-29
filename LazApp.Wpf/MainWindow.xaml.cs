using System.Windows;
using LazApp.ViewModels;

namespace LazApp.Wpf
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Quest_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel mvm
                && (sender as FrameworkElement)?.DataContext is QuestViewModel qvm)
            {
                mvm.SelectedQuest = qvm;
            }
        }
    }
}
