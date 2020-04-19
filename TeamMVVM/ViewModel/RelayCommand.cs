using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TeamMVVM.ViewModel
{
    class RelayCommand : ICommand
    {
        readonly Action<object> execute;
        readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> _execute, Predicate<object> _canExecute)
        {
            if (_execute == null)
                throw new ArgumentNullException(nameof(_execute));
            else
                execute = _execute;
            
            canExecute = _canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null ? true : canExecute(parameter);
       
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
