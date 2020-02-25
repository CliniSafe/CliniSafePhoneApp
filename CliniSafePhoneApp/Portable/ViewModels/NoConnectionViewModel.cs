using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.ComponentModel;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class NoConnectionViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Declare a private member for NavigateBackwardCommand.
        /// </summary>
        public NavigateBackwardCommand NavigateBackwardCommand { get; set; }

        public NavigateForwardCommand NavigateForwardCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public NoConnectionViewModel()
        {
            NavigateBackwardCommand = new NavigateBackwardCommand(this);
            NavigateForwardCommand = new NavigateForwardCommand(this);
            _navigationService = new NavigationService();


            NoConnectionErrorMessage = "You are not connected :(";
            NoConnectionErrorMessage += "\n";
            NoConnectionErrorMessage += "Please connect to a WiFi or a cellular connection - then click Re Try.";
        }

        /// <summary>
        /// Navigates back to the Home Page(MainPage).
        /// </summary>
        /// <returns></returns>
        public void NavigateBack()
        {
            _navigationService.NavigateBack();

            //Working Okay
            //await App.Current.MainPage.Navigation.PopAsync();
        }


        private string noConnectionErrorMessage;

        public string NoConnectionErrorMessage
        {
            get { return noConnectionErrorMessage; }
            set
            {
                noConnectionErrorMessage = value;
                OnPropertyChanged("NoConnectionErrorMessage");
            }
        }

        public void NavigateToHomePage()
        {
            _navigationService.NavigateToSecondPage(new MainPage());
        }
    }
}
