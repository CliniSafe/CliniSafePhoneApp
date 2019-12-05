using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class FindDrugsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define FindDrugsViewModel.
        /// </summary>
        private readonly FindDrugsViewModel FindDrugsVM;

        /// <summary>
        /// Initialise properties in constructor for Countries for Project User as a Monitor.
        /// </summary>
        public FindDrugsPage(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise FindDrugsViewModel.
            FindDrugsVM = new FindDrugsViewModel(countriesForProjectForMonitorUser);

            // Set the Page Binding Context to the FindDrugsViewModel(FindDrugsVM)
            BindingContext = FindDrugsVM;
        }

        /// <summary>
        /// Initialise properties in constructor for Countries for Project User as an Investigator.
        /// </summary>
        /// <param name="researchSitesForProjectForInvestigatorUser"></param>
        public FindDrugsPage(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise FindDrugsViewModel.
            FindDrugsVM = new FindDrugsViewModel(researchSitesForProjectForInvestigatorUser);

            // Set the Page Binding Context to the FindDrugsViewModel(FindDrugsVM)
            BindingContext = FindDrugsVM;
        }
    }
}
