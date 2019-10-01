using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToTempTestCommand : ICommand
    {
        public ErrorViewModel _errorViewModel { get; set; }

        public NavigateToTempTestCommand(ErrorViewModel errorViewModel)
        {
            _errorViewModel = errorViewModel;
        }


        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_errorViewModel != null)
                _errorViewModel.NavigateForwardToTempTest();
        }
    }
}
