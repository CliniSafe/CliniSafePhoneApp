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

        /// <summary>
        /// Declare a private member for NavigateToPreviousPageCommand.
        /// </summary>
        public NavigateToPreviousPageCommand NavigateToPreviousPageCommand { get; set; }


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
            NavigateToPreviousPageCommand = new NavigateToPreviousPageCommand(this);
            SetProjectDetails(projectUser);
        }

        /// <summary>
        /// Sets the Project Details for Project Properties
        /// </summary>
        /// <param name="projectUser"></param>
        public void SetProjectDetails(ProjectUser projectUser)
        {
            this.ProjectCode = projectUser.ProjectCode;
            this.Sponsor = projectUser.Sponsor;
            this.ContractResearchOrganisation = projectUser.ContractResearchOrganisation;
            this.ProjectTitleFull = projectUser.ProjectTitleFull;
        }

        /// <summary>
        /// Navigate to the right page based on the user role on project.
        /// </summary>
        /// <param name="projectUser"></param>
        public void NavigateToMonitorORResearchSiteORChoice(ProjectUser projectUser)
        {
            //if (DrugRuleBuilder) Navigate To ErrorPage
            if (projectUser.DrugRuleBuilderDashboard == "View") //Auth
            {
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Error))
                    RootPage.MenuPages.Remove((int)MenuItemType.Error);

                _ = RootPage.NavigateFromMenu((int)MenuItemType.Error, null, null, "The User is an authorised Drug Rule Builder.");
            }
            else if (projectUser.WizardDashboard == "View") //Auth
            {
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Countries))
                    RootPage.MenuPages.Remove((int)MenuItemType.Countries);

                //Monitor Navigate To CountriesPage (Project_ID) GetCountriesForProjectForMonitorUser
                _ = RootPage.NavigateFromMenu((int)MenuItemType.Countries, null, null, projectUser);
            }
            //else if (Investigator)
            else if (projectUser.InvestigatorDashboard == "View") //Auth
            {
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.ResearchSites))
                    RootPage.MenuPages.Remove((int)MenuItemType.ResearchSites);

                //Investigator Navigate To ResearchSitesPage (Project_ID) GetResearchSitesForProjectForInvestigtorUser
                _ = RootPage.NavigateFromMenu((int)MenuItemType.ResearchSites, null, null, projectUser);
            }
            else if (projectUser.InvestigatorDashboard == "Auth" && projectUser.WizardDashboard == "Auth")//Auth 
            {
                // Remove Page Enum from the MenuPages List
                if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Choice))
                    RootPage.MenuPages.Remove((int)MenuItemType.Choice);

                //(Monitor AND Investigator) Navigate To ChoicePage (Project_ID)
                _ = RootPage.NavigateFromMenu((int)MenuItemType.Choice, null, null, projectUser);
            }
        }

        /// <summary>
        /// Returns the user to the previous page.
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
