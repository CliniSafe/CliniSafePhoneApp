using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.Service
{
    public interface INavigationService
    {
        void NavigateToSecondPage(Page page);
        void NavigateBack();
    }
}