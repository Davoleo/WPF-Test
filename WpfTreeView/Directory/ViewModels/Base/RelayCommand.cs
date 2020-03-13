using System;
using System.Windows.Input;

namespace WpfTreeView.Directory.ViewModels
{

    /// <summary>
    /// A General Command that runs an Action
    /// </summary>
    class RelayCommand : ICommand
    {

        #region Private Members

        private Action action;

        #endregion

        #region Public Events

        /// <summary>
        /// The fired event when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => {};

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            this.action = action;
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }

        #endregion
    }
}
