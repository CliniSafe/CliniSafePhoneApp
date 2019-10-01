using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ErrorViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;

        private HandshakeHeader handshakeHeader;

        public HandshakeHeader HandshakeHeader
        {
            get { return handshakeHeader; }
            set
            {
                handshakeHeader = value;
                OnPropertyChanged("HandshakeHeader");
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Declare a private member for NavigateToLoginCommand.
        /// </summary>
        public NavigateToLoginCommand NavigateToLoginCommand { get; set; }

        public NavigateToTempTestCommand NavigateToTempTestCommand { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ErrorViewModel()
        {
            NavigateToLoginCommand = new NavigateToLoginCommand(this);
            NavigateToTempTestCommand = new NavigateToTempTestCommand(this);
            HandshakeHeader = new HandshakeHeader();
            Message = HandshakeHeader.GetHandshakeHeader().Message;
            _navigationService = new NavigationService();
        }

        /// <summary>
        /// Navigates back to the Login Page(LoginPage).
        /// </summary>
        /// <returns></returns>
        public void NavigateForwardToLogin()
        {
            _navigationService.NavigateToSecondPage(new NavigationPage(new LoginPage()));
        }


        /// <summary>
        /// Navigates back to the Temp Test Page(TempTestPage).
        /// </summary>
        /// <returns></returns>
        public void NavigateForwardToTempTest()
        {
            _navigationService.NavigateToSecondPage(new NavigationPage(new TempTestPage() { Title = "Temporary Test Page" }));
        }
    }
}
