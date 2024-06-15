using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arduino_WPF.Utils;

public class RelayCommand(Action execute, Func<bool>? canExecute = null) : ICommand
{
    private readonly Action _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    private readonly Func<bool> _canExecute = canExecute;

    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// This method determines if the command can be executed.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns> Returns true if the command can be executed. </returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute();
    }

    /// <summary>
    /// This method executes the command.
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object parameter)
    {
        _execute();
    }

    /// <summary>
    /// This method raises the CanExecuteChanged event.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

public class RelayCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Predicate<T> _canExecute;

    public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// This method determines if the command can be executed.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns> Returns true if the command can be executed. </returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute((T)parameter);
    }

    /// <summary>
    /// This method executes the command.
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object parameter)
    {
        _execute((T)parameter);
    }

    /// <summary>
    /// This method raises the CanExecuteChanged event.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
