using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class QuestionViewModel
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a private member for NavigateToPreviousPageCommand.
        /// </summary>
        public NavigateToPreviousPageCommand NavigateToPreviousPageCommand { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public QuestionViewModel()
        {
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);
        }


        /// <summary>
        /// Returns the user to the previous page(ProjectPage).
        /// </summary>
        public void NavigateBackToPreviousPage()
        {
            // Remove Page Enum from the MenuPages List
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Project))
                RootPage.MenuPages.Remove((int)MenuItemType.Project);

            _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, null, null, null);
        }
    }
}
