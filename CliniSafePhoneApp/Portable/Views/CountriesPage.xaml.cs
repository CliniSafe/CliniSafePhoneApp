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
        private readonly CountryViewModel CountryVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public CountriesPage(ProjectUser projectUser)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise CountryViewModel.
            CountryVM = new CountryViewModel(projectUser);

            // Set the Page Binding Context to the CountriesViewModel(CountryVM)
            BindingContext = CountryVM;
        }
    }
}
