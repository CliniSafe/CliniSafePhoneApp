using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ReviewViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        /// <summary>
        /// Declare a private member for NavigateToResultsCommand.
        /// </summary>
        public NavigateToResultsCommand NavigateToResultsCommand { get; set; }

        private string projectCode;

        public string ProjectCode
        {
            get { return projectCode; }
            set
            {
                projectCode = value;
                OnPropertyChanged("ProjectCode");
            }
        }

        private string genericDrugNameToFind;

        public string GenericDrugNameToFind
        {
            get { return genericDrugNameToFind; }
            set
            {
                genericDrugNameToFind = value;
                OnPropertyChanged("GenericDrugNameToFind");
            }
        }

        private List<GenericDrugsFound> genericDrugsFoundList;

        public List<GenericDrugsFound> GenericDrugsFoundList
        {
            get { return genericDrugsFoundList; }
            set
            {
                genericDrugsFoundList = value;
                OnPropertyChanged("GenericDrugsFoundList");
            }
        }


        private List<GenericDrugsFound> reviewSelectedDrugsList;

        public List<GenericDrugsFound> ReviewSelectedDrugsList
        {
            get { return reviewSelectedDrugsList; }
            set
            {
                reviewSelectedDrugsList = value;
                OnPropertyChanged("ReviewSelectedDrugsList");
            }
        }

        private List<QuestionSelectedDrug> reviewAnsweredQuestionList;

        public List<QuestionSelectedDrug> ReviewAnsweredQuestionList
        {
            get { return reviewAnsweredQuestionList; }
            set
            {
                reviewAnsweredQuestionList = value;
                OnPropertyChanged("ReviewAnsweredQuestionList");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="countriesForProjectForMonitorUser"></param>
        /// <param name="reviewAnsweredQuestionList"></param>
        /// <param name="projectUser"></param>
        /// <param name="reviewSelectedDrugsList"></param>
        public ReviewViewModel(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, List<QuestionSelectedDrug> reviewAnsweredQuestionList, ProjectUser projectUser, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            NavigateToResultsCommand = new NavigateToResultsCommand(this);
            ProjectUser = projectUser;
            CountriesForProjectForMonitorUser = countriesForProjectForMonitorUser;

            this.ReviewSelectedDrugsList = reviewSelectedDrugsList;
            this.ReviewAnsweredQuestionList = reviewAnsweredQuestionList;
            this.ProjectCode = projectUser.ProjectCode;
        }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="researchSitesForProjectForInvestigatorUser"></param>
        /// <param name="reviewAnsweredQuestionList"></param>
        /// <param name="projectUser"></param>
        /// <param name="reviewSelectedDrugsList"></param>
        public ReviewViewModel(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, List<QuestionSelectedDrug> reviewAnsweredQuestionList, ProjectUser projectUser, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            NavigateToResultsCommand = new NavigateToResultsCommand(this);
            ProjectUser = projectUser;
            ResearchSitesForProjectForInvestigatorUser = researchSitesForProjectForInvestigatorUser;

            this.ReviewSelectedDrugsList = reviewSelectedDrugsList;
            this.ReviewAnsweredQuestionList = reviewAnsweredQuestionList;
            this.ProjectCode = projectUser.ProjectCode;
        }


        private CountriesForProjectForMonitorUser _countriesForProjectForMonitorUser;

        public CountriesForProjectForMonitorUser CountriesForProjectForMonitorUser
        {
            get { return _countriesForProjectForMonitorUser; }
            set
            {
                _countriesForProjectForMonitorUser = value;
                OnPropertyChanged("CountriesForProjectForMonitorUser");
            }
        }


        private ResearchSitesForProjectForInvestigatorUser _researchSitesForProjectForInvestigatorUser;

        public ResearchSitesForProjectForInvestigatorUser ResearchSitesForProjectForInvestigatorUser
        {
            get { return _researchSitesForProjectForInvestigatorUser; }
            set
            {
                _researchSitesForProjectForInvestigatorUser = value;
                OnPropertyChanged("ResearchSitesForProjectForInvestigatorUser");
            }
        }



        private ProjectUser projectUser;

        public ProjectUser ProjectUser
        {
            get { return projectUser; }
            set
            {
                projectUser = value;
                OnPropertyChanged("ProjectUser");
            }
        }





        /// <summary>
        /// Navigate to the Results page
        /// </summary>
        /// <param name="projectUser"></param>
        public async Task NavigateToResults()
        {
            //await RootPage.NavigateFromMenu((int)MenuItemType.Results, null, null, null, ProjectUser);

            // Navigate to the Review page
            if (_researchSitesForProjectForInvestigatorUser != null) //_researchSitesForProjectForInvestigatorUser
                await RootPage.NavigateFromMenu((int)MenuItemType.ResultsResearchSite, null, null, _researchSitesForProjectForInvestigatorUser, ProjectUser, ReviewAnsweredQuestionList, ReviewSelectedDrugsList);
            else // _countriesForProjectForMonitorUser
                await RootPage.NavigateFromMenu((int)MenuItemType.ResultsCountry, null, null, _countriesForProjectForMonitorUser, ProjectUser, ReviewAnsweredQuestionList, ReviewSelectedDrugsList);
        }

        /// <summary>
        /// Returns the user to the Project Page.
        /// </summary>
        public void NavigateBackToPreviousPage()
        {
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Project))
                RootPage.MenuPages.Remove((int)MenuItemType.Project);

            // Navigate to the Project page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, "", "", null);
        }
    }
}
