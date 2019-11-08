using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToLoginCommand : ICommand
    {
        public HandshakeViewModel _handshakeViewModel { get; set; }

        public NavigateToLoginCommand(HandshakeViewModel handshakeViewModel)
        {
            _handshakeViewModel = handshakeViewModel;
        }


        public ErrorViewModel _errorViewModel { get; set; }

        public NavigateToLoginCommand(ErrorViewModel errorViewModel)
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
            if (_handshakeViewModel != null)
                _handshakeViewModel.NavigateForwardToLogin();

            if (_errorViewModel != null)
                _errorViewModel.NavigateForwardToLogin();
        }
    }
}
