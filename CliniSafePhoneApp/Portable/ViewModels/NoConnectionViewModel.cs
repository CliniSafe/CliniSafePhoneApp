using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class NoConnectionViewModel
    {

        private readonly INavigationService _navigationService;

        /// <summary>
        /// Declare a private member for HomeNavigationCommand.
        /// </summary>
        //public HomeNavigationCommand HomeNavigationCommand { get; set; }


        /// <summary>
        /// Declare a private member for NavigateBackwardCommand.
        /// </summary>
        public NavigateBackwardCommand NavigateBackwardCommand { get; set; }



        public NavigateForwardCommand NavigateForwardCommand { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public NoConnectionViewModel()
        {
            //HomeNavigationCommand = new HomeNavigationCommand(this);

            NavigateBackwardCommand = new NavigateBackwardCommand(this);

            NavigateForwardCommand = new NavigateForwardCommand(this);
            _navigationService = new NavigationService();
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

        public void NavigateToHomePage()
        {
            _navigationService.NavigateToSecondPage(new MainPage());

            //Working Okay
            //await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
