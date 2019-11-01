using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class HandshakeViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Declare private members
        /// </summary>
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

        private string cPAVersion;

        public string CPAVersion
        {
            get { return cPAVersion; }
            set
            {
                cPAVersion = value;
                OnPropertyChanged("CPAVersion");
            }
        }


        private bool hasIssues;

        public bool HasIssues
        {
            get { return hasIssues; }
            set
            {
                hasIssues = value;
                OnPropertyChanged("HasIssues");
            }
        }

        private bool maintenanceMode;

        public bool MaintenanceMode
        {
            get { return maintenanceMode; }
            set
            {
                maintenanceMode = value;
                OnPropertyChanged("MaintenanceMode");
            }
        }

        private bool cPAVersionExact;

        public bool CPAVersionExact
        {
            get { return cPAVersionExact; }
            set
            {
                cPAVersionExact = value;
                OnPropertyChanged("CPAVersionExact");
            }
        }

        private bool cPANeedsUpdating;

        public bool CPANeedsUpdating
        {
            get { return cPANeedsUpdating; }
            set
            {
                cPANeedsUpdating = value;
                OnPropertyChanged("CPANeedsUpdating");
            }
        }

        private int messageCode;

        public int MessageCode
        {
            get { return messageCode; }
            set
            {
                messageCode = value;
                OnPropertyChanged("MessageCode");
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
        /// Declare a private member for NavigateForwardCommand.
        /// </summary>
        public NavigateForwardCommand NavigateForwardCommand { get; set; }


        /// <summary>
        /// Declare a private member for NavigateToLoginCommand.
        /// </summary>
        public NavigateToLoginCommand NavigateToLoginCommand { get; set; }

        private string handshakeResult;

        public string HandshakeResult
        {
            get { return handshakeResult; }
            set
            {
                handshakeResult = value;
                OnPropertyChanged("HandshakeResult");
            }
        }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public HandshakeViewModel()
        {
            NavigateForwardCommand = new NavigateForwardCommand(this);
            NavigateToLoginCommand = new NavigateToLoginCommand(this);
            _navigationService = new NavigationService();
            CheckHandshake();
        }

        public async void CheckHandshake()
        {
            if (HandshakeHeader == null)
                HandshakeHeader = new HandshakeHeader()
                {
                    CPAVersion = Constants.CPAVersion
                };

            HandshakeResult = await HandshakeHeader.HandShakeAsync(HandshakeHeader);
            NavigateForward();
        }


        /// <summary>
        /// Navigates back to the HandShake Page(HandShakePage).
        /// </summary>
        /// <returns></returns>
        public void NavigateForward()
        {
            if (HandshakeResult != null)
                if (HandshakeResult == "Hello")
                    return;  //Stay at the HandShakePage
                             // _navigationService.NavigateToSecondPage(new MainPage());
                else
                    _navigationService.NavigateToSecondPage(new NavigationPage(new ErrorPage() { Title = "Error" }));
            else
                _navigationService.NavigateToSecondPage(new NavigationPage(new ErrorPage() { Title = "Error" }));
        }

        /// <summary>
        /// Navigates back to the Login Page(LoginPage).
        /// </summary>
        /// <returns></returns>
        public void NavigateForwardToLogin()
        {
            //_navigationService.NavigateToSecondPage(new NavigationPage(new LoginPage()));

            _navigationService.NavigateToSecondPage(new MainPage());
        }
    }
}
