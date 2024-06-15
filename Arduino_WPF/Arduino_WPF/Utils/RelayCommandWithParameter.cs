﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arduino_WPF.Utils;

class RelayCommandWithParameter(Action<object> execute, Func<bool>? canExecute = null) : ICommand
{
    private readonly Action<object> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
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
        _execute(parameter);
    }

    /// <summary>
    /// This method raises the CanExecuteChanged event.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
