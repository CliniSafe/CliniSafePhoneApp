using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private AuthHeader authHeader;
        public AuthHeader AuthHeader
        {
            get { return authHeader; }
            set
            {
                authHeader = value;
                OnPropertyChanged("AuthHeader");
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                //Sets the AuthHeader values anytime the textbox values are updated.
                AuthHeader = new AuthHeader()
                {
                    Username = this.Username,
                    Password = this.Password,
                    CPAVersion = Constants.CPAVersion
                };
                OnPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;

                //Sets the AuthHeader values anytime the textbox values are updated.
                AuthHeader = new AuthHeader()
                {
                    Username = this.Username,
                    Password = this.Password,
                    CPAVersion = Constants.CPAVersion
                };
                OnPropertyChanged("Password");
            }
        }

        private string authenticate;

        public string Authenticate
        {
            get { return authenticate; }
            set
            {
                authenticate = value;
                OnPropertyChanged("Authenticate");
            }
        }



        #region Update Soap Header Values Returned from Web Service



        //New Property Authenticate(Check if user is Authenticated return value from the Web Service)
        #region AuthHeader Values Returned


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

        private bool usernamePasswordValid;

        public bool UsernamePasswordValid
        {
            get { return usernamePasswordValid; }
            set
            {
                usernamePasswordValid = value;
                OnPropertyChanged("UsernamePasswordValid");
            }
        }

        private bool userTypeValid;

        public bool UserTypeValid
        {
            get { return userTypeValid; }
            set
            {
                userTypeValid = value;
                OnPropertyChanged("UserTypeValid");
            }
        }

        private bool userMobileTrained;

        public bool UserMobileTrained
        {
            get { return userMobileTrained; }
            set
            {
                userMobileTrained = value;
                OnPropertyChanged("UserMobileTrained");
            }
        }

        private bool trialActive;

        public bool TrialActive
        {
            get { return trialActive; }
            set
            {
                trialActive = value;
                OnPropertyChanged("TrialActive");
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


        private bool authenticated;

        public bool Authenticated
        {
            get { return authenticated; }
            set
            {
                authenticated = value;
                OnPropertyChanged("Authenticated");
            }
        }


        #endregion



        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginCommand LoginCommand { get; set; }


        private readonly INavigationService _navigationService;

        public NavigateForwardCommand NavigateForwardCommand { get; set; }
        public LoginViewModel()
        {
            AuthHeader = new AuthHeader();
            LoginCommand = new LoginCommand(this);
            NavigateForwardCommand = new NavigateForwardCommand(this);
            _navigationService = new NavigationService();
        }


        public void NavigateForward()
        {
            _navigationService.NavigateToSecondPage(new NavigationPage(new ErrorPage() { Title = "Error" }));
        }


        /// <summary>
        /// Authenticate Logic to authenticate user credientials from Web Service Proxy Class.
        /// </summary>
        /// <returns></returns>
        public async void AuthenticateAsync()
        {
            Authenticate = await AuthHeader.AuthenticateAsync(AuthHeader);


            authHeader = AuthHeader.GetAuthHeader();

            if (authHeader.HasIssues)
                if (authHeader.MaintenanceMode)
                    await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
                else if (authHeader.CPAVersionExact)
                    if (authHeader.CPANeedsUpdating)
                        await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
        }





        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        //public async Task NavigateFromMenu(int id)
        //{
        //    if (!MenuPages.ContainsKey(id))
        //    {
        //        switch (id)
        //        {
        //            case (int)MenuItemType.Login:
        //                MenuPages.Add(id, new NavigationPage(new LoginPage()));
        //                break;
        //            case (int)MenuItemType.Browse:
        //                MenuPages.Add(id, new NavigationPage(new BrowsePage()));
        //                break;
        //            case (int)MenuItemType.About:
        //                MenuPages.Add(id, new NavigationPage(new AboutPage()));
        //                break;
        //            case (int)MenuItemType.Help:
        //                MenuPages.Add(id, new NavigationPage(new HelpPage()));
        //                break;
        //        }
        //    }

        //    var newPage = MenuPages[id];

        //    if (newPage != null && Detail != newPage)
        //    {
        //        Detail = newPage;

        //        if (Device.RuntimePlatform == Device.Android)
        //            await Task.Delay(100);

        //        IsPresented = false;
        //    }
        //}
    }
}
