﻿namespace Gajda.NovemberTests.Client.Extensions
{
    using System;
    using System.Windows.Input;

    public sealed class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> execute;

        private readonly Predicate<object> canExecute;

        #endregion

        #region Constructors

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

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand Members [DebuggerStepThrough]

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        #endregion
    }
}
