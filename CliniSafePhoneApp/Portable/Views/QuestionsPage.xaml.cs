using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class QuestionsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define QuestionViewModel.
        /// </summary>
        private readonly QuestionViewModel QuestionVM;


        /// <summary>
        /// Initialise properties in constructor for Countries for Project User as a Monitor.
        /// </summary>
        public QuestionsPage(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, string projectCode)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise QuestionViewModel.
            QuestionVM = new QuestionViewModel(countriesForProjectForMonitorUser, projectCode);

            // Set the Page Binding Context to the QuestionViewModel(QuestionVM)
            BindingContext = QuestionVM;
        }

        /// <summary>
        /// Initialise properties in constructor for ResearchSites for Project User as an Investigator.
        /// </summary>
        /// <param name="researchSitesForProjectForInvestigatorUser"></param>
        public QuestionsPage(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, string projectCode)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise QuestionViewModel.
            QuestionVM = new QuestionViewModel(researchSitesForProjectForInvestigatorUser, projectCode);

            // Set the Page Binding Context to the QuestionViewModel(QuestionVM)
            BindingContext = QuestionVM;
        }




        private void NextNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Review page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Review);
        }
    }
}
