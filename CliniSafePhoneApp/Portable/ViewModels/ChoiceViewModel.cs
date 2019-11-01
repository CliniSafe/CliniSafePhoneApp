using CliniSafePhoneApp.Portable.Models;
using System.ComponentModel;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ChoiceViewModel : INotifyPropertyChanged
    {
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


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ChoiceViewModel(ProjectUser projectUser)
        {
            ProjectUser = new ProjectUser()
            {
                ID = projectUser.ID,
                ProjectCode = projectUser.ProjectCode,
                ProjectTitleShort = projectUser.ProjectTitleShort,
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

            GetProjectDetails(projectUser);
        }

        public void GetProjectDetails(ProjectUser projectUser)
        {
            this.Id = projectUser.ID;
            this.ProjectCode = projectUser.ProjectCode;
            this.Sponsor = projectUser.Sponsor;
            this.ContractResearchOrganisation = projectUser.ContractResearchOrganisation;
            this.DropDownDesc = projectUser.DropDownDesc;
        }
    }
}
