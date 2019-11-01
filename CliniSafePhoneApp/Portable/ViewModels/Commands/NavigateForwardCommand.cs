using CliniSafePhoneApp.Portable.Views;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateForwardCommand : ICommand
    {
        public LoginViewModel _loginViewModel { get; set; }

        public NavigateForwardCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }


        public HandshakeViewModel _handshakeViewModel { get; set; }

        public NavigateForwardCommand(HandshakeViewModel handshakeViewModel)
        {
            _handshakeViewModel = handshakeViewModel;
        }

        public NoConnectionViewModel _noConnectionViewModel { get; set; }

        public NavigateForwardCommand(NoConnectionViewModel noConnectionViewModel)
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
            if (_loginViewModel != null)
                _loginViewModel.NavigateForward();

            if (_handshakeViewModel != null)
                _handshakeViewModel.NavigateForward();
            // await _noConnectionViewModel.NavigateToHomePage();

            if (_noConnectionViewModel != null)
                _noConnectionViewModel.NavigateToHomePage();
        }
    }
}

