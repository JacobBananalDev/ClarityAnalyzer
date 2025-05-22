using System;
using System.Windows.Input;

namespace ClarityAnalyzer.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> m_execute;
        private readonly Predicate<object> m_canExecute;


        public RelayCommand(Action<object> execute)
           : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            m_execute = execute;
            m_canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return m_canExecute == null || m_canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            m_execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                //CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                //CanExecuteChangedInternal -= value;
            }
        }
    }
}
