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


        //----------------------------------------------------------------------

        private string sponsor;

        public string Sponsor
        {
            get { return sponsor; }
            set
            {
                sponsor = value;
                OnPropertyChanged("Sponsor");
            }
        }

        private string contractResearchOrganisation;

        public string ContractResearchOrganisation
        {
            get { return contractResearchOrganisation; }
            set
            {
                contractResearchOrganisation = value;
                OnPropertyChanged("ContractResearchOrganisation");
            }
        }

        private string dropDownDesc;

        public string DropDownDesc
        {
            get { return dropDownDesc; }
            set
            {
                dropDownDesc = value;
                OnPropertyChanged("DropDownDesc");
            }
        }
        //----------------------------------------------------------------------





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

            SetProjectDetails(_projectUser);

            NavigateToFindDrugsCommand = new NavigateToFindDrugsCommand(this);
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);

     

            //Need to fix countries
            GetCountriesForProjectForMonitorUser();
        }

        /// <summary>
        /// Sets the Project Details for Project Properties
        /// </summary>
        /// <param name="projectUser"></param>
        private void SetProjectDetails(ProjectUser projectUser)
        {
            this.Id = projectUser.ID;
            this.ProjectCode = projectUser.ProjectCode;


            this.Sponsor = projectUser.Sponsor;
            this.ContractResearchOrganisation = projectUser.ContractResearchOrganisation;
            this.DropDownDesc = projectUser.DropDownDesc;
        }



        private List<Country> countryList;

        public List<Country> CountryList
        {
            get { return countryList; }
            set
            {
                countryList = value;
                OnPropertyChanged("CountryList");
            }
        }


        private Country selectedCountry;

        public Country SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                selectedCountry = value;
                new Country()
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


        public async void GetCountriesForProjectForMonitorUser()
        {
            CountryList = await Country.GetCountriesForProjectForMonitorUserListAsync(_projectUser);

            authHeader = AuthHeader.GetAuthHeader();


           // _ = RootPage.NavigateFromMenu((int)MenuItemType.Countries, null, null, _projectUser);
        }


        public void NavigateToFindDrugs(Country counrty)
        {
            // Remove Page Enum from the MenuPages List 
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.FindDrugs))
                RootPage.MenuPages.Remove((int)MenuItemType.FindDrugs);

            _ = RootPage.NavigateFromMenu((int)MenuItemType.FindDrugs, null, null, counrty);
        }

        /// <summary>
        /// Returns the user to the previous page.
        /// </summary>
        public void NavigateBackToPreviousPage()
        {
            if (_projectUser.InvestigatorDashboard == "Auth" && _projectUser.WizardDashboard == "Auth")//Auth 
            {
                //(Monitor AND Investigator) Navigate To ChoicePage (Project_ID)
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Choice))
                    RootPage.MenuPages.Remove((int)MenuItemType.Choice);

                _ = RootPage.NavigateFromMenu((int)MenuItemType.Choice, null, null, _projectUser);
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
