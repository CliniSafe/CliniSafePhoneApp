using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ResultsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define Private Member ResultsViewModel.
        /// </summary>
        private readonly ResultsViewModel ResultsVM;

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="countriesForProjectForMonitorUser"></param>
        /// <param name="projectUser"></param>
        /// <param name="reviewQuestionSelectedDrugsList"></param>
        /// <param name="reviewSelectedDrugsList"></param>
        public ResultsPage(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, ProjectUser projectUser, List<QuestionSelectedDrug> reviewQuestionSelectedDrugsList, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ResultsViewModel.
            ResultsVM = new ResultsViewModel(countriesForProjectForMonitorUser, projectUser, reviewQuestionSelectedDrugsList, reviewSelectedDrugsList);

            // Set the Page Binding Context to the ResultsViewModel(ResultsVM)
            BindingContext = ResultsVM;
        }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="researchSitesForProjectForInvestigatorUser"></param>
        /// <param name="projectUser"></param>
        /// <param name="reviewQuestionSelectedDrugsList"></param>
        /// <param name="reviewSelectedDrugsList"></param>
        public ResultsPage(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, ProjectUser projectUser, List<QuestionSelectedDrug> reviewQuestionSelectedDrugsList, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ResultsViewModel.
            ResultsVM = new ResultsViewModel(researchSitesForProjectForInvestigatorUser, projectUser, reviewQuestionSelectedDrugsList, reviewSelectedDrugsList);

            // Set the Page Binding Context to the ResultsViewModel(ResultsVM)
            BindingContext = ResultsVM;
        }
    }
}
