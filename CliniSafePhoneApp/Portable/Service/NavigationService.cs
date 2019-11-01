using CliniSafePhoneApp.Portable.Views;
using System.Linq;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.Service
{
    public class NavigationService : INavigationService
    {
        public async void NavigateToSecondPage(Page page)
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PushModalAsync(page, true);
        }

        public async void NavigateBack()
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PopAsync(); //.PopModalAsync();
        }

        private Page GetCurrentPage()
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            if (currentPage == null)
                currentPage = Application.Current.MainPage = new MainPage();
            return currentPage;
        }
    }
}