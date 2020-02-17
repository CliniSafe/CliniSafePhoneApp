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








        //private bool? no;

        //public bool? No
        //{
        //    get { return no; }
        //    set
        //    {
        //        //no = value;

        //        if (this.no != value)
        //        {
        //            no = value;

        //            if (Convert.ToBoolean(no))
        //                Yes = false;

        //            OnPropertyChanged("No");
        //        }

        //        //OnPropertyChanged("No");
        //    }
        //}


        //private bool? yes;

        //public bool? Yes
        //{
        //    get { return this.yes; }
        //    set
        //    {


        //        //yes = value;

        //        if (this.yes != value)
        //        {
        //            this.yes = value;
        //            if (Convert.ToBoolean(yes))
        //                No = false;

        //            OnPropertyChanged("Yes");
        //        }

        //        //OnPropertyChanged("Yes");
        //    }
        //}










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
        public QuestionViewModel(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, string projectCode, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            //PopUpCommand = new PopUpCommand(this);
            //GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);


            NavigateToReviewCommand = new NavigateToReviewCommand(this);

            //AnsweredQuestionList = new ObservableCollection<QuestionSelectedDrug>();

            AnsweredQuestionList = new List<QuestionSelectedDrug>();


            _countriesForProjectForMonitorUser = countriesForProjectForMonitorUser;

            if (_countriesForProjectForMonitorUser != null)
            {
                this.TrialId = countriesForProjectForMonitorUser.ID;
                this.ProjectCode = projectCode;
                this.ReviewSelectedDrugsList = reviewSelectedDrugsList;
            }

            _ = GetQuestions(TrialId);
        }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public QuestionViewModel(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, string projectCode, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            //PopUpCommand = new PopUpCommand(this);
            //GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);


            NavigateToReviewCommand = new NavigateToReviewCommand(this);

            //AnsweredQuestionList = new ObservableCollection<QuestionSelectedDrug>();

            AnsweredQuestionList = new List<QuestionSelectedDrug>();


            _researchSitesForProjectForInvestigatorUser = researchSitesForProjectForInvestigatorUser;

            if (_researchSitesForProjectForInvestigatorUser != null)
            {
                this.TrialId = researchSitesForProjectForInvestigatorUser.Trial_ID;
                this.ProjectCode = projectCode;
                this.ReviewSelectedDrugsList = reviewSelectedDrugsList;
            }

            _ = GetQuestions(TrialId);
        }



        public async Task GetQuestions(int trialID)
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
            // Remove Page Enum from the MenuPages List
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Project))
                RootPage.MenuPages.Remove((int)MenuItemType.Project);

            _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, null, null, null);
        }



        /// <summary>
        /// Navigate to the Review page
        /// /// </summary>
        /// <param name="questionSelectedDrug"></param>
        /// <returns></returns>
        public async Task NavigateToReview(QuestionSelectedDrug questionSelectedDrug)
        {
            // Navigate to the Review page
            await RootPage.NavigateFromMenu((int)MenuItemType.Review, null, null, null, ProjectCode, AnsweredQuestionList, ReviewSelectedDrugsList);  // AnsweredQuestionList, 


            //TODO:AOA -  To Be Deleted
            //if (_researchSitesForProjectForInvestigatorUser != null)
            //    _ = RootPage.NavigateFromMenu((int)MenuItemType.QuestionsForResearchSite, null, null, _researchSitesForProjectForInvestigatorUser, projectCode);
            //else if (_countriesForProjectForMonitorUser != null)
            //    _ = RootPage.NavigateFromMenu((int)MenuItemType.QuestionsForCountry, null, null, _countriesForProjectForMonitorUser, projectCode);
            //else
            //    return;
        }
    }
}
