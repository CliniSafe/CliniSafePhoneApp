using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class CountryViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a private member for NavigateToPreviousPageCommand.
        /// </summary>
        public NavigateToPreviousPageCommand NavigateToPreviousPageCommand { get; set; }

        public NavigateToFindDrugsCommand NavigateToFindDrugsCommand { get; set; }

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



        private string wizardDashboard;
        public string WizardDashboard
        {
            get { return wizardDashboard; }
            set
            {
                wizardDashboard = value;
                OnPropertyChanged("WizardDashboard");
            }
        }


        private string investigatorDashboard;
        public string InvestigatorDashboard
        {
            get { return investigatorDashboard; }
            set
            {
                investigatorDashboard = value;
                OnPropertyChanged("InvestigatorDashboard");
            }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
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
        public CountryViewModel(ProjectUser projectUser)
        {
            _projectUser = projectUser;

            if (_projectUser != null)
                SetProjectDetails(_projectUser);

            NavigateToFindDrugsCommand = new NavigateToFindDrugsCommand(this);
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);

            GetCountriesForProjectForMonitorUser(projectUser);
        }

        /// <summary>
        /// Sets the Project Details for Project Properties
        /// </summary>
        /// <param name="projectUser"></param>
        private void SetProjectDetails(ProjectUser projectUser)
        {
            this.Id = projectUser.ID;
            this.ProjectCode = projectUser.ProjectCode;
            this.InvestigatorDashboard = projectUser.InvestigatorDashboard;
            this.WizardDashboard = projectUser.WizardDashboard;

            //this.Sponsor = projectUser.Sponsor;
            //this.ContractResearchOrganisation = projectUser.ContractResearchOrganisation;
            //this.DropDownDesc = projectUser.DropDownDesc;
        }



        private List<CountriesForProjectForMonitorUser> countryList;

        public List<CountriesForProjectForMonitorUser> CountryList
        {
            get { return countryList; }
            set
            {
                countryList = value;
                foreach (var c in CountryList)
                {
                    this.TrialCode = c.TrialCode;
                    this.EnglishCountryName = c.EnglishCountryName;
                }
                OnPropertyChanged("CountryList");
            }
        }


        private CountriesForProjectForMonitorUser selectedCountry;

        public CountriesForProjectForMonitorUser SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                selectedCountry = value;
                new CountriesForProjectForMonitorUser()
                {
                    TrialCode = SelectedCountry.TrialCode,
                    TrialTitleShort = SelectedCountry.TrialTitleShort
                };

                OnPropertyChanged("SelectedCountry");
            }
        }


        private string trialCode;

        public string TrialCode
        {
            get { return trialCode; }
            set
            {
                trialCode = value;
                OnPropertyChanged("TrialCode");
            }
        }


        private string englishCountryName;

        public string EnglishCountryName
        {
            get { return englishCountryName; }
            set
            {
                englishCountryName = value;
                OnPropertyChanged("EnglishCountryName");
            }
        }

        /// <summary>
        /// Returns Trial(s) or (Country / Countries) that the selected Project belongs to.
        /// </summary>
        /// <param name="projectUser"></param>
        public async void GetCountriesForProjectForMonitorUser(ProjectUser projectUser)
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
            else
            {
                CountryList = await CountriesForProjectForMonitorUser.GetCountriesForProjectForMonitorUserListAsync(projectUser);

                _ = RootPage.NavigateFromMenu((int)MenuItemType.Countries, null, null, _projectUser);
            }
        }


        public void NavigateToFindDrugs(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser)
        {
            // Remove Page Enum from the MenuPages List 
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.FindDrugs))
                RootPage.MenuPages.Remove((int)MenuItemType.FindDrugs);

            // Navigate to the Find Drugs page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.FindDrugs, null, null, countriesForProjectForMonitorUser);
        }

        /// <summary>
        /// Returns the user to the Previous Page.
        /// </summary>
        public void NavigateBackToPreviousPage()
        {
            if (ProjectUser.InvestigatorDashboard == "Auth" && ProjectUser.WizardDashboard == "Auth")//Auth 
            {
                //(Monitor AND Investigator) Navigate To ChoicePage (Project_ID)
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Project))
                    RootPage.MenuPages.Remove((int)MenuItemType.Project);

                // Navigate to the Project page
                _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, "", "", null);
            }
            else
            {
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.ProjectDetails))
                    RootPage.MenuPages.Remove((int)MenuItemType.ProjectDetails);

                _ = RootPage.NavigateFromMenu((int)MenuItemType.ProjectDetails, null, null, _projectUser);
            }
        }
    }
}
