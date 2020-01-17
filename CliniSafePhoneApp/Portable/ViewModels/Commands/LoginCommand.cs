using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for LoginViewModel
        /// </summary>
        public LoginViewModel LoginViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="loginViewModels"></param>
        public LoginCommand(LoginViewModel loginViewModels)
        {
            LoginViewModel = loginViewModels;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Login Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            var authHeader = (AuthHeader)parameter;

            if (authHeader == null)
                return false;

            if (string.IsNullOrEmpty(authHeader.Username) || string.IsNullOrEmpty(authHeader.Password))
                return false;

            return true;
        }

        /// <summary>
        /// Execute Login Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            LoginViewModel.AuthenticateAsync();
        }
    }
}
