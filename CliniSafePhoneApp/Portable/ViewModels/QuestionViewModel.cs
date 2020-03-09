using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a private member for NavigateToReviewCommand.
        /// </summary>
        public NavigateToReviewCommand NavigateToReviewCommand { get; set; }

        /// <summary>
        /// Declare a private member for NavigateToPreviousPageCommand.
        /// </summary>
        public NavigateToPreviousPageCommand NavigateToPreviousPageCommand { get; set; }

        private AuthHeader authHeader;

        public AuthHeader AuthHeader
        {
            get { return authHeader; }
            set
            {
                authHeader = value;
                OnPropertyChanged("AuthHeader");
            }
        }



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



        private int trialId;

        public int TrialId
        {
            get { return trialId; }
            set
            {
                trialId = value;
                OnPropertyChanged("Id");
            }
        }


        private ProjectUser _projectUser;

        public ProjectUser ProjectUser
        {
            get { return _projectUser; }
            set
            {
                _projectUser = value;
                OnPropertyChanged("ProjectUser");
            }
        }


        private List<QuestionSelectedDrug> questionSelectedDrugList;

        public List<QuestionSelectedDrug> QuestionSelectedDrugList
        {
            get { return questionSelectedDrugList; }
            set
            {
                questionSelectedDrugList = value;
                OnPropertyChanged("QuestionSelectedDrugList");
            }
        }

        private QuestionSelectedDrug selectedQuestion;

        public QuestionSelectedDrug SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                selectedQuestion = value;
                if (selectedQuestion != null)
                {
                    if ((selectedQuestion.Yes != null) || (selectedQuestion.No != null))
                    {
                        if (!AnsweredQuestionList.Contains(selectedQuestion))
                            AnsweredQuestionList.Add(selectedQuestion);
                    }
                    else
                    {
                        _ = Constants.DisplayPopUp("Questions", "Please all questions  first, before proceeding.");
                        SelectedQuestion = null;
                    }
                }

                OnPropertyChanged("SelectedQuestion");
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



        private List<QuestionSelectedDrug> answeredQuestionList;

        public List<QuestionSelectedDrug> AnsweredQuestionList
        {
            get { return answeredQuestionList; }
            set
            {
                answeredQuestionList = value;
                OnPropertyChanged("AnsweredQuestionList");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public QuestionViewModel(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, ProjectUser projectUser, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            NavigateToReviewCommand = new NavigateToReviewCommand(this);
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);
            AnsweredQuestionList = new List<QuestionSelectedDrug>();
            _projectUser = projectUser;
            _countriesForProjectForMonitorUser = countriesForProjectForMonitorUser;

            if (_countriesForProjectForMonitorUser != null)
            {
                this.TrialId = countriesForProjectForMonitorUser.ID;
                this.ProjectCode = projectUser.ProjectCode;
                this.ReviewSelectedDrugsList = reviewSelectedDrugsList;
            }

            _ = GetQuestionsAsync(TrialId);
        }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public QuestionViewModel(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, ProjectUser projectUser, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            NavigateToReviewCommand = new NavigateToReviewCommand(this);
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);
            AnsweredQuestionList = new List<QuestionSelectedDrug>();
            _projectUser = projectUser;
            _researchSitesForProjectForInvestigatorUser = researchSitesForProjectForInvestigatorUser;

            if (_researchSitesForProjectForInvestigatorUser != null)
            {
                this.TrialId = researchSitesForProjectForInvestigatorUser.Trial_ID;
                this.ProjectCode = projectUser.ProjectCode;
                this.ReviewSelectedDrugsList = reviewSelectedDrugsList;
            }

            _ = GetQuestionsAsync(TrialId);
        }



        public async Task GetQuestionsAsync(int trialID)
        {
            authHeader = AuthHeader.GetAuthHeader();

            if (authHeader.HasIssues)
            {
                if (authHeader.MaintenanceMode)
                    await Constants.DisplayPopUp("Error", authHeader.Message);
                else if (authHeader.CPAVersionExact)
                    if (authHeader.CPANeedsUpdating)
                        await Constants.DisplayPopUp("Error", authHeader.Message);
            }
            else
            {
                QuestionSelectedDrugList = await QuestionSelectedDrug.GetQuestionSelectedDrugsListAysnc(trialID);

                SelectedQuestion = null;
            }
        }

        /// <summary>
        /// Returns the user to the previous page(ProjectPage).
        /// </summary>
        public void NavigateBackToPreviousPage()
        {
            if (_researchSitesForProjectForInvestigatorUser != null)
            {
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.FindDrugsForResearchSite))
                    RootPage.MenuPages.Remove((int)MenuItemType.FindDrugsForResearchSite);

                _ = RootPage.NavigateFromMenu((int)MenuItemType.FindDrugsForResearchSite, null, null, _researchSitesForProjectForInvestigatorUser, ProjectUser);
            }
            else
            {
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.FindDrugsForCountry))
                    RootPage.MenuPages.Remove((int)MenuItemType.FindDrugsForCountry);

                _ = RootPage.NavigateFromMenu((int)MenuItemType.FindDrugsForCountry, null, null, _countriesForProjectForMonitorUser, ProjectUser);
            }
        }



        /// <summary>
        /// Navigate to the Review page
        /// /// </summary>
        /// <param name="questionSelectedDrug"></param>
        /// <returns></returns>
        public async Task NavigateToReview(QuestionSelectedDrug questionSelectedDrug)
        {
            // Navigate to the Review page
            if (_researchSitesForProjectForInvestigatorUser != null) //_researchSitesForProjectForInvestigatorUser
                await RootPage.NavigateFromMenu((int)MenuItemType.ReviewResearchSite, null, null, _researchSitesForProjectForInvestigatorUser, ProjectUser, AnsweredQuestionList, ReviewSelectedDrugsList);
            else // _countriesForProjectForMonitorUser
                await RootPage.NavigateFromMenu((int)MenuItemType.ReviewCountry, null, null, _countriesForProjectForMonitorUser, ProjectUser, AnsweredQuestionList, ReviewSelectedDrugsList);
        }
    }
}
