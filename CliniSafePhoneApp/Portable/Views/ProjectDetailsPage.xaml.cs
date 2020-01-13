using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ProjectDetailsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define Private Member ProjectDetailsViewModel.
        /// </summary>
        private readonly ProjectDetailsViewModel ProjectDetailsVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ProjectDetailsPage(ProjectUser projectUser)
        {
            InitializeComponent();

            // Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ProjectDetailsViewModel.
            ProjectDetailsVM = new ProjectDetailsViewModel(projectUser);

            // Set the Page Binding Context to the ProjectDetailsViewModel(ProjectDetailsVM)
            BindingContext = ProjectDetailsVM;
        }


        //Temp Code - To Be Deleted
        //private void NextNavigationButton_Clicked(object sender, System.EventArgs e)
        //{
        //    // TODO:
        //    //if(DrugRuleBuilder)
        //    //   Navigate To ErrorPage
        //    //else if(Monitor)
        //    //  Navigate To CountriesPage
        //    //else if(Investigator)
        //    //  Navigate To ResearchSitesPage
        //    //else if(Monitor AND Investigator)
        //    // Navigate To ChoicePage


        //    // Navigate to the Choice page
        //    _ = RootPage.NavigateFromMenu((int)MenuItemType.Choice);
        //}
    }
}
