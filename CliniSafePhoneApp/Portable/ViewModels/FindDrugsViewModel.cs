using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System;
using System.Collections.Generic;
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
            await App.Current.MainPage.DisplayAlert(_researchSitesForProjectForInvestigatorUser != null ? "Site Details" : "Trial Short Description", _researchSitesForProjectForInvestigatorUser != null ? _researchSitesForProjectForInvestigatorUser.Address1 : _countriesForProjectForMonitorUser.TrialTitleShort, "OK");
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
                OnPropertyChanged("GenericDrugsFound");
            }
        }


        private GenericDrugsFound selectedGenericDrugsFound;

        public GenericDrugsFound SelectedGenericDrugsFound
        {
            get { return selectedGenericDrugsFound; }
            set
            {
                selectedGenericDrugsFound = value;
                OnPropertyChanged("SelectedGenericDrugsFound");
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

            _countriesForProjectForMonitorUser = countriesForProjectForMonitorUser;

            if (_countriesForProjectForMonitorUser != null)
            {
                this.TrialId = countriesForProjectForMonitorUser.ID;
                this.projectCodeORSiteTitle = countriesForProjectForMonitorUser.TrialCode;
            }

            GetDrugDetails(/*countriesForProjectForMonitorUser.ID, genericDrugNameToFind*/);
        }


        public FindDrugsViewModel(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser)
        {
            PopUpCommand = new PopUpCommand(this);

            GenericDrugNameToFindCommand = new GenericDrugNameToFindCommand(this);

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
                    await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
                else if (authHeader.CPAVersionExact)
                    if (authHeader.CPANeedsUpdating)
                        await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
            }
        }



        public async void GetGenericDrugDetails(/*int trail_ID,*/ string drugNameToFind)
        {

            GenericDrugsFoundList = await GenericDrugsFound.FindGenericDrugNameListAsync(TrialId, drugNameToFind);
        }



        public void NavigateToSelectedDrugs(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser)
        {

            throw new NotImplementedException();
            //// Remove Page Enum from the MenuPages List 
            //if (RootPage.MenuPages.ContainsKey((int)MenuItemType.SelectedDrugs))
            //    RootPage.MenuPages.Remove((int)MenuItemType.SelectedDrugs);

            //// Navigate to the Find Drugs page
            //_ = RootPage.NavigateFromMenu((int)MenuItemType.FindDrugs, null, null, researchSitesForProjectForInvestigatorUser);
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
