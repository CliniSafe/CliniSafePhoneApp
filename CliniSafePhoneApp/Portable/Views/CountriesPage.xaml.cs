using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class CountriesPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define CountriesViewModel.
        /// </summary>
        CountriesViewModel CountriesVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public CountriesPage(ProjectUser projectUser)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise AboutViewModel.
            CountriesVM = new CountriesViewModel(projectUser);

            // Set the Page Binding Context to the CountriesViewModel(CountriesVM)
            BindingContext = CountriesVM;
        }

        private void NextNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Find Drugs page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.FindDrugs);
        }
    }
}
