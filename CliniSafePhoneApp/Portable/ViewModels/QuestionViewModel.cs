using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

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



        private QuestionSelectedDrug questionSelectedDrug;

        public QuestionSelectedDrug QuestionSelectedDrug
        {
            get { return questionSelectedDrug; }
            set
            {
                questionSelectedDrug = value;
                OnPropertyChanged("QuestionSelectedDrug");
            }
        }



        //private ResearchSitesForProjectForInvestigatorUser selectedResearchSite;

        //public ResearchSitesForProjectForInvestigatorUser SelectedResearchSite
        //{
        //    get { return selectedResearchSite; }
        //    set
        //    {
        //        selectedResearchSite = value;
        //        OnPropertyChanged("SelectedResearchSite");
        //    }
        //}






        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public QuestionViewModel()
        {
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);
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


        public QuestionViewModel(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, string projectCode)
        {
            //PopUpCommand = new PopUpCommand(this);
            //GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);
            //NavigateToQuestionsCommand = new NavigateToQuestionsCommand(this);

            //SelectedDrugsList = new ObservableCollection<GenericDrugsFound>();

            _countriesForProjectForMonitorUser = countriesForProjectForMonitorUser;

            if (_countriesForProjectForMonitorUser != null)
            {
                this.TrialId = countriesForProjectForMonitorUser.ID;
                this.ProjectCode = projectCode;
            }

            GetQuestions(TrialId);
        }


        public QuestionViewModel(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, string projectCode)
        {
            //PopUpCommand = new PopUpCommand(this);
            //GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);
            //NavigateToQuestionsCommand = new NavigateToQuestionsCommand(this);

            //SelectedDrugsList = new ObservableCollection<GenericDrugsFound>();

            _researchSitesForProjectForInvestigatorUser = researchSitesForProjectForInvestigatorUser;

            if (_researchSitesForProjectForInvestigatorUser != null)
            {
                this.TrialId = researchSitesForProjectForInvestigatorUser.Trial_ID;
                this.ProjectCode = projectCode;
            }

            GetQuestions(TrialId);
        }







        public async void GetQuestions(int trialID)
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
    }
}
