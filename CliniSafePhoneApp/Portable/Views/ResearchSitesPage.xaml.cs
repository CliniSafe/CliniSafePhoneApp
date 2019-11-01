using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ResearchSitesPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define AboutViewModel.
        /// </summary>
        private readonly ResearchSitesViewModel ResearchSitesVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ResearchSitesPage(ProjectUser projectUser)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ResearchSitesViewModel.
            ResearchSitesVM = new ResearchSitesViewModel(projectUser);

            // Set the Page Binding Context to the ResearchSitesViewModel(AboutVM)
            BindingContext = ResearchSitesVM;
        }

        private void NextNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Review page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Review);
        }
    }
}
