using System.ComponentModel;
using System.Runtime.CompilerServices;
using LazApp.Base.Models;

namespace LazApp.Base.ViewModels;

public class AnswerViewModel : INotifyPropertyChanged
{
    private bool isSelected;
    private bool? answeredCorrectly;

    public AnswerViewModel(Answer answer)
    {
        ToggleSelectionCommand = new Command(o => IsSelected = !IsSelected);
        Text = answer.Text;
        IsCorrect = answer.IsCorrect;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public Command ToggleSelectionCommand { get; }

    public string Text { get; }

    public bool IsCorrect { get; }

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            isSelected = value;
            OnPropertyChanged();
        }
    }

    public bool? AnsweredCorrectly
    {
        get => answeredCorrectly;
        private set
        {
            answeredCorrectly = value;
            OnPropertyChanged();
        }
    }

    public void Check()
    {
        AnsweredCorrectly = IsSelected == IsCorrect;
        IsSelected = IsCorrect;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
