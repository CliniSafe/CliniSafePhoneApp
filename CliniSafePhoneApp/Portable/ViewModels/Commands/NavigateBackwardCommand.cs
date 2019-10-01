using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateBackwardCommand : ICommand
    {
        public NoConnectionViewModel _noConnectionViewModel { get; set; }

        public NavigateBackwardCommand(NoConnectionViewModel noConnectionViewModel)
        {
            _noConnectionViewModel = noConnectionViewModel;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // _noConnectionViewModel.NavigateToHomePage();

            _noConnectionViewModel.NavigateBack();
        }
    }
}
