﻿using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

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


        public new event PropertyChangedEventHandler PropertyChanged;

        public new void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginCommand LoginCommand { get; set; }

        private readonly INavigationService _navigationService;




        private string popUpTitle;

        public string PopUpTitle
        {
            get { return popUpTitle; }
            set
            {
                popUpTitle = value;
                OnPropertyChanged("PopUpTitle");
            }
        }

        private string loginErrorMessage;

        public string LoginErrorMessage
        {
            get { return loginErrorMessage; }
            set
            {
                loginErrorMessage = value;
                OnPropertyChanged("LoginErrorMessage");
            }
        }



        public NavigateForwardCommand NavigateForwardCommand { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public LoginViewModel()
        {
            Title = "LogIn";
            AuthHeader = new AuthHeader();
            LoginCommand = new LoginCommand(this);
            NavigateForwardCommand = new NavigateForwardCommand(this);
            _navigationService = new NavigationService();

            PopUpTitle = "Login Error";

            LoginErrorMessage = "Please check your Username and / or password. Retry after.";
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
            if (Authenticate == "Authenticated") //Navigate to the project page
                _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, Username, Password, null);


            if (AuthHeader.Username != Password || AuthHeader.Password != Username)
            {
                AuthHeader.Username = Username;
                AuthHeader.Password = Password;
                AuthHeader.CPAVersion = Constants.CPAVersion;
                Authenticate = await AuthHeader.AuthenticateAsync(AuthHeader);
            }

            if (Authenticate != null)
            {
                authHeader = AuthHeader.GetAuthHeader();

                if (authHeader.Authenticated)
                {
                    if (authHeader.HasIssues)
                    {
                        PopUpTitle = "Login Issue";

                        if (!authHeader.UserMobileTrained)
                            await Constants.DisplayPopUp(PopUpTitle, authHeader.Message);

                        else if (authHeader.MaintenanceMode)
                            await Constants.DisplayPopUp(PopUpTitle, authHeader.Message);

                        else if (authHeader.CPAVersionExact)
                            if (authHeader.CPANeedsUpdating)
                                await Constants.DisplayPopUp(PopUpTitle, authHeader.Message);
                    }
                    else
                        // Navigate to the project page
                        _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, Username, Password, null);
                }
                else  // return to login page(Popup notification to check username and password.)
                {
                    await Constants.DisplayPopUp(PopUpTitle, LoginErrorMessage);
                    authHeader = new AuthHeader();
                    Authenticate = null;
                    return;
                }
            }
            else if (Authenticate == "Not Authenticated") // return to login page(Popup notification to check username and password.)
            {
                await Constants.DisplayPopUp(PopUpTitle, LoginErrorMessage);
                authHeader = new AuthHeader();
                Authenticate = null;
                return;
            }
            else
            {
                return; // return to login page
            }
        }
    }
}


//------------------------------------------------------------------------------------------------------------------------
/*Original*/
//            if (/*!string.IsNullOrEmpty(Authenticate) && */Authenticate == "Authenticated")
//            {
//                // Navigate to the project page
//                //_ = RootPage.NavigateFromMenu((int)MenuItemType.Project, Username, Password, null);





//                authHeader = AuthHeader.GetAuthHeader();

//                if (authHeader.HasIssues)
//                {
//                    if (authHeader.MaintenanceMode)
//                        await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
//                    else if (authHeader.CPAVersionExact)
//                        if (authHeader.CPANeedsUpdating)
//                            await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
//                }
//                else
//                {
//                    if (Authenticate == "Authenticated")
//                    {
//                        // Navigate to the project page
//                        _ = RootPage.NavigateFromMenu((int) MenuItemType.Project, Username, Password, null);
//                    }
//                }

//            }
//            else if (Authenticate == "Not Authenticated")
//            {

//                // Navigate to the Login page
//                _ = RootPage.NavigateFromMenu((int) MenuItemType.LogIn, null, null, null);
//                Username = "";
//                Password = "";
//                Authenticate = null;

//                return;
//                //AuthHeader = null;

//            }
//            else
//            {
//                Authenticate = await AuthHeader.AuthenticateAsync(AuthHeader);


//authHeader = AuthHeader.GetAuthHeader();

//                if (authHeader.HasIssues)
//                {
//                    if (authHeader.MaintenanceMode)
//                        await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
//                    else if (authHeader.CPAVersionExact)
//                        if (authHeader.CPANeedsUpdating)
//                            await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
//                }
//                else
//                {
//                    if (Authenticate == "Authenticated")
//                    {
//                        // Navigate to the project page
//                        _ = RootPage.NavigateFromMenu((int) MenuItemType.Project, Username, Password, null);
//                    }
//                }

//            }


//------------------------------------------------------------------------------------------------------------------------