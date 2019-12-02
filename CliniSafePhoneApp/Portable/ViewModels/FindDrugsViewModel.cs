using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
                    SelectedDrugsList = new ObservableCollection<GenericDrugsFound>()
                    {
                        selectedGenericDrugsFound
                    };
                }

                OnPropertyChanged("SelectedGenericDrugsFound");
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

        public FindDrugsViewModel(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser)
        {
            PopUpCommand = new PopUpCommand(this);
            GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);
            NavigateToQuestionsCommand = new NavigateToQuestionsCommand(this);

            _countriesForProjectForMonitorUser = countriesForProjectForMonitorUser;

            if (_countriesForProjectForMonitorUser != null)
            {
                this.TrialId = countriesForProjectForMonitorUser.ID;
                this.ProjectCodeORSiteTitle = countriesForProjectForMonitorUser.TrialCode;
            }

            GetDrugDetails(/*countriesForProjectForMonitorUser.ID, genericDrugNameToFind*/);
        }


        public FindDrugsViewModel(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser)
        {
            PopUpCommand = new PopUpCommand(this);
            GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);
            NavigateToQuestionsCommand = new NavigateToQuestionsCommand(this);

            _researchSitesForProjectForInvestigatorUser = researchSitesForProjectForInvestigatorUser;

            if (_researchSitesForProjectForInvestigatorUser != null)
            {
                this.TrialId = researchSitesForProjectForInvestigatorUser.Trial_ID;
                this.ProjectCodeORSiteTitle = researchSitesForProjectForInvestigatorUser.SiteTitle;
            }

            GetDrugDetails(/*researchSitesForProjectForInvestigatorUser.Trial_ID, genericDrugNameToFind*/);
        }


        public async void GetDrugDetails(/*int trail_ID, string drugNameToFind*/)
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



        public async void GetGenericDrugDetails(/*int trail_ID,*/ string drugNameToFind)
        {
            GenericDrugsFoundList = await GenericDrugsFound.FindGenericDrugNameListAsync(TrialId, drugNameToFind);
        }


        /// <summary>
        /// Navigate to the Questions page
        /// </summary>
        /// <param name="projectUser"></param>
        public void NavigateToQuestions(GenericDrugsFound genericDrugsFound)
        {
            //ProjectCodeORSiteTitle pass to Question Page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Questions, null, null, null);
        }




        //public void NavigateToSelectedDrugs(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser)
        //{

        //    throw new NotImplementedException();
        //    //// Remove Page Enum from the MenuPages List 
        //    //if (RootPage.MenuPages.ContainsKey((int)MenuItemType.SelectedDrugs))
        //    //    RootPage.MenuPages.Remove((int)MenuItemType.SelectedDrugs);

        //    //// Navigate to the Find Drugs page
        //    //_ = RootPage.NavigateFromMenu((int)MenuItemType.FindDrugs, null, null, researchSitesForProjectForInvestigatorUser);
        //}

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
