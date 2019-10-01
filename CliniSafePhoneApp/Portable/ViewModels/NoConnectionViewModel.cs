using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;

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

        /// <summary>
        /// Create and Initialize with NavigateBackwardCommand.
        /// </summary>
        public NoConnectionViewModel()
        {
            //HomeNavigationCommand = new HomeNavigationCommand(this);

            NavigateBackwardCommand = new NavigateBackwardCommand(this);
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
    }
}
