﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalCW.BLL
{
    internal class CommandViewModel: ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public bool CanExecute(object parameter) => _canExecuteAction == null ? true : _canExecuteAction(parameter);
        public void Execute(object parameter) => _executeAction(parameter);

        public CommandViewModel(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public CommandViewModel(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }
    }
}
