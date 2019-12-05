using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToLoginCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for HandshakeViewModel
        /// </summary>
        public HandshakeViewModel HandshakeViewModel { get; set; }

        /// <summary>
        /// Declare a public property for ErrorViewModel
        /// </summary>
        public ErrorViewModel ErrorViewModel { get; set; }

        /// <summary>
        /// Declare a public property for LogOutViewModel
        /// </summary>
        public LogOutViewModel LogOutViewModel { get; set; }

        /// <summary>
        /// Initialise HandshakeViewModel properties in constructor.
        /// </summary>
        /// <param name="handshakeViewModel"></param>
        public NavigateToLoginCommand(HandshakeViewModel handshakeViewModel)
        {
            HandshakeViewModel = handshakeViewModel;
        }

        /// <summary>
        /// Initialise ErrorViewModel properties in constructor.
        /// </summary>
        /// <param name="errorViewModel"></param>
        public NavigateToLoginCommand(ErrorViewModel errorViewModel)
        {
            ErrorViewModel = errorViewModel;
        }

        /// <summary>
        /// Initialise LogOutViewModel properties in constructor.
        /// </summary>
        /// <param name="logOutViewModel"></param>
        public NavigateToLoginCommand(LogOutViewModel logOutViewModel)
        {
            LogOutViewModel = logOutViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Navigate To Login Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Navigate To Login Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (HandshakeViewModel != null)
                HandshakeViewModel.NavigateForwardToLogin();

            if (ErrorViewModel != null)
                ErrorViewModel.NavigateForwardToLogin();

            if (LogOutViewModel != null)
                LogOutViewModel.NavigateForwardToLogin();
        }
    }
}
