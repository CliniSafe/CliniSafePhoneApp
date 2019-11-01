using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ProjectDetailsViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


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

        private string projectTitleFull;

        public string ProjectTitleFull
        {
            get { return projectTitleFull; }
            set
            {
                projectTitleFull = value;
                OnPropertyChanged("ProjectTitleFull");
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


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public NavigateToChoiceCommand NavigateToChoiceCommand { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ProjectDetailsViewModel(ProjectUser projectUser)
        {
            ProjectUser = new ProjectUser()
            {
                ID = projectUser.ID,
                ProjectCode = projectUser.ProjectCode,
                ProjectTitleShort = projectUser.ProjectTitleShort,
                ProjectTitleFull = projectUser.ProjectTitleFull,
                ProjectTitleShortPhoneDisplay = projectUser.ProjectTitleShortPhoneDisplay,
                Sponsor = projectUser.Sponsor,
                ContractResearchOrganisation = projectUser.ContractResearchOrganisation,
                DropDownDesc = projectUser.DropDownDesc,
                DrugRuleBuilderDashboard = projectUser.DrugRuleBuilderDashboard,
                EndUserDashboard = projectUser.EndUserDashboard,
                ExploreDrugsDashboard = projectUser.ExploreDrugsDashboard,
                InvestigatorDashboard = projectUser.InvestigatorDashboard,
                IRPUserDashboard = projectUser.IRPUserDashboard,
                ReportsDashboard = projectUser.ReportsDashboard,
                StudyDashboard = projectUser.StudyDashboard,
                TeamDashboard = projectUser.TeamDashboard,
                TranslationDashboard = projectUser.TranslationDashboard,
                WizardDashboard = projectUser.WizardDashboard
            };

            NavigateToChoiceCommand = new NavigateToChoiceCommand(this);

            GetProjectDetails(projectUser);
        }

        public void GetProjectDetails(ProjectUser projectUser)
        {
            this.ProjectCode = projectUser.ProjectCode;
            this.Sponsor = projectUser.Sponsor;
            this.ContractResearchOrganisation = projectUser.ContractResearchOrganisation;
            this.ProjectTitleFull = projectUser.ProjectTitleFull;
        }

        public void NavigateToMonitorORResearchSiteORChoice(ProjectUser projectUser)
        {
            //if (DrugRuleBuilder) Navigate To ErrorPage
            if (projectUser.DrugRuleBuilderDashboard == "View") //Auth
                _ = RootPage.NavigateFromMenu((int)MenuItemType.Error, null, null, "The User is an authorised Drug Rule Builder.");
            else if (projectUser.WizardDashboard == "View") //Auth
                //Monitor Navigate To CountriesPage (Project_ID) GetCountriesForProjectForMonitorUser
                _ = RootPage.NavigateFromMenu((int)MenuItemType.Countries, null, null, projectUser);
            //else if (Investigator)
            else if (projectUser.InvestigatorDashboard == "View") //Auth
                //Investigator Navigate To ResearchSitesPage (Project_ID) GetResearchSitesForProjectForInvestigtorUser
                _ = RootPage.NavigateFromMenu((int)MenuItemType.ResearchSites, null, null, projectUser);

            else if (projectUser.InvestigatorDashboard == "Auth" && projectUser.WizardDashboard == "Auth")//Auth 
                //(Monitor AND Investigator) Navigate To ChoicePage (Project_ID)
                _ = RootPage.NavigateFromMenu((int)MenuItemType.Choice, null, null, projectUser);
        }
    }
}
