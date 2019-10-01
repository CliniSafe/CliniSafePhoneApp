using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginViewModel _loginViewModels { get; set; }

        public LoginCommand(LoginViewModel loginViewModels)
        {
            _loginViewModels = loginViewModels;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            var authHeader = (AuthHeader)parameter;

            if (authHeader == null)
                return false;

            if (string.IsNullOrEmpty(authHeader.Username) || string.IsNullOrEmpty(authHeader.Password))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            _loginViewModels.AuthenticateAsync();

        }
    }
}
