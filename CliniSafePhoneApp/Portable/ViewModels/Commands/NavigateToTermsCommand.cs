using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToTermsCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for ErrorViewModel
        /// </summary>
        public ErrorViewModel ErrorViewModel { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="ErrorViewModel"></param>
        public NavigateToTermsCommand(ErrorViewModel ErrorViewModel)
        {
            this.ErrorViewModel = ErrorViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Navigate To Terms Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Navigate To Terms Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (ErrorViewModel != null)
                ErrorViewModel.NavigateForwardToTerms();
        }
    }
}