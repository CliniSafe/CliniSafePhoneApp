using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class LogOutViewModel : BaseViewModel
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a private member for NavigateToLoginCommand.
        /// </summary>
        public NavigateToLoginCommand NavigateToLoginCommand { get; set; }


        private string logOutMessage;

        public string LogOutMessage
        {
            get { return logOutMessage; }
            set
            {
                logOutMessage = value;
                OnPropertyChanged("LogOutMessage");
            }
        }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public LogOutViewModel()
        {
            Title = "Log Out";
            LogOutMessage = "You have been logged out successfully.";
            NavigateToLoginCommand = new NavigateToLoginCommand(this);
        }

        /// <summary>
        /// Navigates back to the Login Page(LoginPage).
        /// </summary>
        /// <returns></returns>
        public void NavigateForwardToLogin()
        {
            //_navigationService.NavigateToSecondPage(new NavigationPage(new LoginPage()));

            _ = RootPage.NavigateFromMenu((int)MenuItemType.LogIn, null, null, null);
        }

    }
}
