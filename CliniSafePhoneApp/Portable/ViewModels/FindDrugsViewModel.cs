using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class FindDrugsViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a private member for NavigateForwardCommand.
        /// </summary>
        public PopUpCommand PopUpCommand { get; set; }


        /// <summary>
        /// Declare a private member for GenericDrugNameToFindCommand.
        /// </summary>
        public GenericDrugNameToFindCommand GenericDrugNameToFindCommand { get; set; }

        public NavigateToQuestionsCommand NavigateToQuestionsCommand { get; set; }

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

        /// <summary>
        /// Display the Address Deatils of the Selected Site.
        /// </summary>
        public async void PopUpSiteDetails()
        {
            await Constants.DisplayPopUp(_researchSitesForProjectForInvestigatorUser != null ? "Site Details" : "Trial Short Description", _researchSitesForProjectForInvestigatorUser != null ? _researchSitesForProjectForInvestigatorUser.Address1 : _countriesForProjectForMonitorUser.TrialTitleShort);
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
        private string projectCodeORSiteTitle;

        public string ProjectCodeORSiteTitle
        {
            get { return projectCodeORSiteTitle; }
            set
            {
                projectCodeORSiteTitle = value;
                OnPropertyChanged("ProjectCodeORSiteTitle");
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


        private GenericDrugsFound selectedGenericDrugsFound;

        public GenericDrugsFound SelectedGenericDrugsFound
        {
            get { return selectedGenericDrugsFound; }
            set
            {
                selectedGenericDrugsFound = value;
                if (selectedGenericDrugsFound != null)
                {
                    if (!SelectedDrugsList.Contains(selectedGenericDrugsFound))
                    {
                        if (!SelectedGenericDrugsFound.Select)
                            SelectedGenericDrugsFound.Select = true;

                        SelectedDrugsList.Add(SelectedGenericDrugsFound);

                        if (!ReviewSelectedDrugsList.Contains(selectedGenericDrugsFound))
                            ReviewSelectedDrugsList.Add(SelectedGenericDrugsFound);


                        ShowSeletedDrugTitle = true;
                    }
                }

                OnPropertyChanged("SelectedGenericDrugsFound");
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


        private bool showSeletedDrugTitle;

        public bool ShowSeletedDrugTitle
        {
            get { return showSeletedDrugTitle; }
            set
            {
                showSeletedDrugTitle = value;
                OnPropertyChanged("ShowSeletedDrugTitle");
            }
        }


        private ObservableCollection<GenericDrugsFound> selectedDrugsList;

        public ObservableCollection<GenericDrugsFound> SelectedDrugsList
        {
            get { return selectedDrugsList; }
            set
            {
                selectedDrugsList = value;
                OnPropertyChanged("SelectedDrugsList");
            }
        }



        private GenericDrugsFound selectedDrug;

        public GenericDrugsFound SelectedDrug
        {
            get { return selectedDrug; }
            set
            {
                selectedDrug = value;
                OnPropertyChanged("SelectedDrug");
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

        //private List<ResearchSitesForProjectForInvestigatorUser> researchSiteList;

        //public List<ResearchSitesForProjectForInvestigatorUser> ResearchSiteList

        //{
        //    get { return researchSiteList; }
        //    set
        //    {
        //        researchSiteList = value;
        //        OnPropertyChanged("ResearchSiteList");
        //    }
        //}


        //private ResearchSitesForProjectForInvestigatorUser selectedResearchSite;

        //public ResearchSitesForProjectForInvestigatorUser SelectedResearchSite
        //{
        //    get { return selectedResearchSite; }
        //    set
        //    {
        //        selectedResearchSite = value;
        //        new ResearchSitesForProjectForInvestigatorUser()
        //        {
        //            CombineDisplayTrialCodeSiteTitle = ProjectUser.ProjectCode + " " + SelectedResearchSite.SiteTitle
        //        };
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
        /// <param name="countriesForProjectForMonitorUser"></param>
        /// <param name="projectCode"></param>
        public FindDrugsViewModel(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, ProjectUser projectUser)
        {
            PopUpCommand = new PopUpCommand(this);
            GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);
            NavigateToQuestionsCommand = new NavigateToQuestionsCommand(this);

            SelectedDrugsList = new ObservableCollection<GenericDrugsFound>();

            _projectUser = projectUser;
            _countriesForProjectForMonitorUser = countriesForProjectForMonitorUser;

            if (_countriesForProjectForMonitorUser != null)
            {
                this.TrialId = countriesForProjectForMonitorUser.ID;
                this.ProjectCodeORSiteTitle = countriesForProjectForMonitorUser.TrialCode;
                this.ProjectCode = projectUser.ProjectCode;
            }

            GetDrugDetailsAsync();
        }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="researchSitesForProjectForInvestigatorUser"></param>
        /// <param name="projectCode"></param>
        public FindDrugsViewModel(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, ProjectUser projectUser)
        {
            PopUpCommand = new PopUpCommand(this);
            GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);
            NavigateToQuestionsCommand = new NavigateToQuestionsCommand(this);

            SelectedDrugsList = new ObservableCollection<GenericDrugsFound>();

            ReviewSelectedDrugsList = new List<GenericDrugsFound>();

            _projectUser = projectUser;
            _researchSitesForProjectForInvestigatorUser = researchSitesForProjectForInvestigatorUser;

            if (_researchSitesForProjectForInvestigatorUser != null)
            {
                this.TrialId = researchSitesForProjectForInvestigatorUser.Trial_ID;
                this.ProjectCodeORSiteTitle = researchSitesForProjectForInvestigatorUser.SiteTitle;
                this.ProjectCode = projectUser.ProjectCode;
            }

            GetDrugDetailsAsync();
        }








        public async void GetDrugDetailsAsync()
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
        }







        public async Task GetGenericDrugDetails(string drugNameToFind)
        {
            GenericDrugsFoundList = await GenericDrugsFound.FindGenericDrugNameListAsync(TrialId, drugNameToFind);
        }


        /// <summary>
        /// Navigate to the Questions page
        /// </summary>
        /// <param name="projectUser"></param>
        public async Task NavigateToQuestions(GenericDrugsFound genericDrugsFound)
        {
            if (_researchSitesForProjectForInvestigatorUser != null)
                await RootPage.NavigateFromMenu((int)MenuItemType.QuestionsForResearchSite, null, null, _researchSitesForProjectForInvestigatorUser, ProjectUser, null, reviewSelectedDrugsList);
            else if (_countriesForProjectForMonitorUser != null)
                await RootPage.NavigateFromMenu((int)MenuItemType.QuestionsForCountry, null, null, _countriesForProjectForMonitorUser, ProjectUser, null, reviewSelectedDrugsList);
            else
                return;
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
