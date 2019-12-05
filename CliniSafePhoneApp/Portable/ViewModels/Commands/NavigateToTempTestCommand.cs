using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToTempTestCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for ErrorViewModel
        /// </summary>
        public ErrorViewModel ErrorViewModel { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="errorViewModel"></param>
        public NavigateToTempTestCommand(ErrorViewModel errorViewModel)
        {
            ErrorViewModel = errorViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Navigate To Temp Test Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Navigate To Temp Test Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (ErrorViewModel != null)
                ErrorViewModel.NavigateForwardToTempTest();
        }
    }
}
