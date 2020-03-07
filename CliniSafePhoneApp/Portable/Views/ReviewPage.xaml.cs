using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ReviewPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define ReviewViewModel.
        /// </summary>
        private readonly ReviewViewModel ReviewVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        //public ReviewPage(List<QuestionSelectedDrug> reviewAnsweredQuestionList, ProjectUser projectUser, List<GenericDrugsFound> reviewSelectedDrugsList)
        public ReviewPage(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, ProjectUser projectUser, List<QuestionSelectedDrug> reviewAnsweredQuestionList, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ReviewViewModel.
            ReviewVM = new ReviewViewModel(countriesForProjectForMonitorUser, reviewAnsweredQuestionList, projectUser, reviewSelectedDrugsList);

            // Set the Page Binding Context to the ReviewViewModel(ReviewVM)
            BindingContext = ReviewVM;
        }

        public ReviewPage(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, ProjectUser projectUser, List<QuestionSelectedDrug> reviewAnsweredQuestionList, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ReviewViewModel.
            ReviewVM = new ReviewViewModel(researchSitesForProjectForInvestigatorUser, reviewAnsweredQuestionList, projectUser, reviewSelectedDrugsList);

            // Set the Page Binding Context to the ReviewViewModel(ReviewVM)
            BindingContext = ReviewVM;
        }





        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (ReviewVM.ReviewSelectedDrugsList != null)
                ReviewVM.ReviewSelectedDrugsList = null;
        }
    }
}
