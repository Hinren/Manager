using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectManager.Commands
{
    public class RelayCommand : ICommand
    {

        //  EVENTS

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        //  VARIABLES

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> RelayCommand class constructor. </summary>
        /// <param name="execute"> Action to execute. </param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> RelayCommand class constructor. </summary>
        /// <param name="execute"> Action to execute. </param>
        /// <param name="canExecute"> Method that defines if action can be executed. </param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion CLASS METHODS

        #region COMMAND METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Specifies whether the method can be executed. </summary>
        /// <param name="parameter"> Parameter passed by canExecute method. </param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Executable action method. </summary>
        /// <param name="parameter"> Parameter passed by execute action method. </param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion COMMAND METHODS

    }
}
