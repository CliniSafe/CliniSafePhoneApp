using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateForwardCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for LoginViewModel
        /// </summary>
        public LoginViewModel LoginViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="loginViewModel"></param>
        public NavigateForwardCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }


        /// <summary>
        /// Declare a public property for HandshakeViewModel
        /// </summary>
        public HandshakeViewModel HandshakeViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="handshakeViewModel"></param>
        public NavigateForwardCommand(HandshakeViewModel handshakeViewModel)
        {
            HandshakeViewModel = handshakeViewModel;
        }


        /// <summary>
        /// Declare a public property for NoConnectionViewModel
        /// </summary>
        public NoConnectionViewModel NoConnectionViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="noConnectionViewModel"></param>
        public NavigateForwardCommand(NoConnectionViewModel noConnectionViewModel)
        {
            NoConnectionViewModel = noConnectionViewModel;
        }

        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// Enable Navigate Forward Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Navigate Forward Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (LoginViewModel != null)
                LoginViewModel.NavigateForward();

            if (HandshakeViewModel != null)
                HandshakeViewModel.NavigateForward();

            if (NoConnectionViewModel != null)
                NoConnectionViewModel.NavigateToHomePage();
        }
    }
}

