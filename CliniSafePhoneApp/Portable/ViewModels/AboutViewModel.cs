using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Linq;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a private member for NavigateToPreviousPageCommand.
        /// </summary>
        public NavigateToPreviousPageCommand NavigateToPreviousPageCommand { get; set; }

        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public AboutViewModel()
        {
            Title = "About";
            _navigationService = new NavigationService();
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);
        }


        public void NavigateBackToPreviousPage()
        {
            _ = RootPage.NavigateFromMenu((RootPage.MenuPages.Keys.LastOrDefault() - 1), null, null, null);
        }
    }
}
