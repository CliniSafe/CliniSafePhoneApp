using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ResearchSitesViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

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




        private List<ResearchSitesForProjectForInvestigatorUser> researchSiteList;

        public List<ResearchSitesForProjectForInvestigatorUser> ResearchSiteList

        {
            get { return researchSiteList; }
            set
            {
                researchSiteList = value;
                OnPropertyChanged("ResearchSiteList");
            }
        }


        private ResearchSitesForProjectForInvestigatorUser selectedResearchSite;

        public ResearchSitesForProjectForInvestigatorUser SelectedResearchSite
        {
            get { return selectedResearchSite; }
            set
            {
                selectedResearchSite = value;
                OnPropertyChanged("SelectedResearchSite");
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ResearchSitesViewModel(ProjectUser projectUser)
        {
            _projectUser = projectUser;

            if (_projectUser != null)
                GetProjectDetails(projectUser);

            NavigateToFindDrugsCommand = new NavigateToFindDrugsCommand(this);

            GetResearchSitesForProjectForInvestigatorUser(projectUser);
        }

        private void GetProjectDetails(ProjectUser projectUser)
        {
            this.Id = projectUser.ID;
            this.ProjectCode = projectUser.ProjectCode;
            this.Sponsor = projectUser.Sponsor;
            this.ContractResearchOrganisation = projectUser.ContractResearchOrganisation;
            this.DropDownDesc = projectUser.DropDownDesc;
        }



        //ResearchSitesForProjectForInvestigatorUser
        /// <summary>
        /// Returns Research Site(s) or that the selected Project belongs to.
        /// </summary>
        /// <param name="projectUser"></param>
        public async void GetResearchSitesForProjectForInvestigatorUser(ProjectUser projectUser)
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
                ResearchSiteList = await ResearchSitesForProjectForInvestigatorUser.GetResearchSitesForProjectForInvestigtorUserListAsync(projectUser);
            }
        }

        public void NavigateToFindDrugs(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser)
        {
            // Remove Page Enum from the MenuPages List 
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.FindDrugsForResearchSite))
                RootPage.MenuPages.Remove((int)MenuItemType.FindDrugsForResearchSite);

            // Navigate to the Find Drugs page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.FindDrugsForResearchSite, null, null, researchSitesForProjectForInvestigatorUser);
        }

        /// <summary>
        /// Returns the user to the Previous Page.
        /// </summary>
        public void NavigateBackToPreviousPage()
        {
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Project))
                RootPage.MenuPages.Remove((int)MenuItemType.Project);

            // Navigate to the Project page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, "", "", null);


            //TODO
            //if (ProjectUser.InvestigatorDashboard == "Auth" && ProjectUser.WizardDashboard == "Auth")//Auth 
            //{
            //    //(Monitor AND Investigator) Navigate To ChoicePage (Project_ID)
            //    // Remove Page Enum from the MenuPages List
            //    if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Choice))
            //        RootPage.MenuPages.Remove((int)MenuItemType.Choice);

            //    _ = RootPage.NavigateFromMenu((int)MenuItemType.Choice, null, null, _projectUser);
            //}
            //else
            //{
            //    // Remove Page Enum from the MenuPages List
            //    if (RootPage.MenuPages.ContainsKey((int)MenuItemType.ProjectDetails))
            //        RootPage.MenuPages.Remove((int)MenuItemType.ProjectDetails);

            //    _ = RootPage.NavigateFromMenu((int)MenuItemType.ProjectDetails, null, null, _projectUser);
            //}
        }

    }
}
