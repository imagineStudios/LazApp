using System.ComponentModel;
using System.Runtime.CompilerServices;
using LazApp.Base.Models;

namespace LazApp.Base.ViewModels;

public class AnswerViewModel(Answer answer) : INotifyPropertyChanged
{
    private bool isSelected;
    private bool? answeredCorrectly;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Text => answer.Text;

    public bool IsCorrect => answer.IsCorrect;

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
