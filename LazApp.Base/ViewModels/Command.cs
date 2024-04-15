using System;
using System.Windows.Input;

namespace LazApp.Base.ViewModels;

public class Command(Action<object> action, Func<object, bool>? canExecute = null) : ICommand
{
    private readonly Action<object> action = action;
    private readonly Func<object, bool>? canExecute = canExecute;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

    public void Execute(object parameter) => action?.Invoke(parameter);

    public void ChangeCanExecute() => CanExecuteChanged?.Invoke(this, new EventArgs());
}
