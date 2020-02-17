using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using System.Collections.Generic;
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
        public QuestionsPage(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, string projectCode, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise QuestionViewModel.
            QuestionVM = new QuestionViewModel(countriesForProjectForMonitorUser, projectCode, reviewSelectedDrugsList);

            // Set the Page Binding Context to the QuestionViewModel(QuestionVM)
            BindingContext = QuestionVM;
        }

        /// <summary>
        /// Initialise properties in constructor for ResearchSites for Project User as an Investigator.
        /// </summary>
        /// <param name="researchSitesForProjectForInvestigatorUser"></param>
        public QuestionsPage(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, string projectCode, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise QuestionViewModel.
            QuestionVM = new QuestionViewModel(researchSitesForProjectForInvestigatorUser, projectCode, reviewSelectedDrugsList);

            //OnAppearing();

            // Set the Page Binding Context to the QuestionViewModel(QuestionVM)
            BindingContext = QuestionVM;
        }


        /// <summary>
        /// Prepare the Question Grid for Fresh Selection.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (QuestionVM.SelectedQuestion != null)
            {
                QuestionVM.SelectedQuestion.Yes = null;
                QuestionVM.SelectedQuestion.No = null;
            }
            questionsListDataGrid.SelectedItems.Clear();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }
}
