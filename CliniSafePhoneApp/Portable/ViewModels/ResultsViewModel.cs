using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ResultsViewModel
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        public NavigateToProjectCommand NavigateToProjectCommand { get; set; }
        public NavigateToMainCommand NavigateToMainCommand { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ResultsViewModel()
        {
            NavigateToProjectCommand = new NavigateToProjectCommand(this);
            NavigateToMainCommand = new NavigateToMainCommand(this);
        }

        /// <summary>
        /// Navigate to the Project Page
        /// </summary>
        public void NavigateToProject()
        {

            // _ = new NavigationPage(new ProjectsPage("Osei-AgyemangA", "Something4$"));

            // Navigate to the Project page
            ///_ = RootPage.NavigateFromMenu((int)MenuItemType.Project, null, null, null);

            // Navigate to the Project page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, "", "", null);
        }

        /// <summary>
        /// Navigate to the Main Page
        /// </summary>
        public void NavigateToMainPage()
        {
            // Navigate to the Main page
            Application.Current.MainPage = new MainPage();
        }
    }
}
