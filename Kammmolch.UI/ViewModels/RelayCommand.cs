using System;
using System.Windows.Input;

namespace Kammmolch.UI.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action _executeHandler;
        private readonly Func<bool> _canExecuteHandler;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute)
        {
            _executeHandler = execute ?? throw new ArgumentNullException(nameof(execute), "Execute must not be null!");
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
            : this(execute)
        {
            _canExecuteHandler = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteHandler == null ? true : _canExecuteHandler();
        }

        public void Execute(object parameter)
        {
            _executeHandler();
        }
    }
}
