using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Linq;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class TermsViewModel
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a private member for NavigateToPreviousPageCommand.
        /// </summary>
        public NavigateToPreviousPageCommand NavigateToPreviousPageCommand { get; set; }

        public TermsViewModel()
        {
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);
        }

        public void NavigateBackToPreviousPage()
        {

            //_navigationService.NavigateBack();

            //var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

            //NavigationPage navigationPage = new NavigationPage(currentPage);
            //navigationPage.PopAsync();

            //if (RootPage.MenuPages.Remove((RootPage.MenuPages.Keys.LastOrDefault() - 1)))
            _ = RootPage.NavigateFromMenu((RootPage.MenuPages.Keys.LastOrDefault() - 1), null, null, null);

            // _ = RootPage.NavigateFromMenu(RootPage.MenuPages.Count(), null, null, null);


            //_ = RootPage.Detail.Navigation.PushAsync(RootPage.MenuPages);// .NavigateFromMenu((int)MenuItemType.LogIn, null, null, null);
        }
    }
}
