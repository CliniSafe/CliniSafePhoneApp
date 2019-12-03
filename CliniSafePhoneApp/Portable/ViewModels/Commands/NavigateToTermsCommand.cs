using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToTermsCommand : ICommand
    {
        public ErrorViewModel ErrorViewModel { get; set; }

        public NavigateToTermsCommand(ErrorViewModel ErrorViewModel)
        {
            this.ErrorViewModel = ErrorViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (ErrorViewModel != null)
                ErrorViewModel.NavigateForwardToTerms();
        }
    }
}
