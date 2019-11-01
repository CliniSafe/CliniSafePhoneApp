using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CliniSafePhoneApp.Portable.Models
{
    public class ProjectUser : INotifyPropertyChanged, IProjectUser
    {

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


        private string projectTitleShort;

        public string ProjectTitleShort
        {
            get { return projectTitleShort; }
            set
            {
                projectTitleShort = value;
                OnPropertyChanged("ProjectTitleShort");
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


        private string projectTitleShortPhoneDisplay;
        public string ProjectTitleShortPhoneDisplay
        {
            get { return projectTitleShortPhoneDisplay; }
            set
            {
                projectTitleShortPhoneDisplay = value;
                OnPropertyChanged("ProjectTitleShortPhoneDisplay");
            }
        }

        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
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

        private string iRPUserDashboard;
        public string IRPUserDashboard
        {
            get { return iRPUserDashboard; }
            set
            {
                iRPUserDashboard = value;
                OnPropertyChanged("IRPUserDashboard");
            }
        }

        private string studyDashboard;
        public string StudyDashboard
        {
            get { return studyDashboard; }
            set
            {
                studyDashboard = value;
                OnPropertyChanged("StudyDashboard");
            }
        }

        private string drugRuleBuilderDashboard;
        public string DrugRuleBuilderDashboard
        {
            get { return drugRuleBuilderDashboard; }
            set
            {
                drugRuleBuilderDashboard = value;
                OnPropertyChanged("DrugRuleBuilderDashboard");
            }
        }


        private string exploreDrugsDashboard;
        public string ExploreDrugsDashboard
        {
            get { return exploreDrugsDashboard; }
            set
            {
                exploreDrugsDashboard = value;
                OnPropertyChanged("ExploreDrugsDashboard");
            }
        }


        private string teamDashboard;
        public string TeamDashboard
        {
            get { return teamDashboard; }
            set
            {
                teamDashboard = value;
                OnPropertyChanged("TeamDashboard");
            }
        }

        private string translationDashboard;
        public string TranslationDashboard
        {
            get { return translationDashboard; }
            set
            {
                translationDashboard = value;
                OnPropertyChanged("TranslationDashboard");
            }
        }


        private string reportsDashboard;
        public string ReportsDashboard
        {
            get { return reportsDashboard; }
            set
            {
                reportsDashboard = value;
                OnPropertyChanged("ReportsDashboard");
            }
        }

        private string endUserDashboard;
        public string EndUserDashboard
        {
            get { return endUserDashboard; }
            set
            {
                endUserDashboard = value;
                OnPropertyChanged("EndUserDashboard");
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Returns Project for User after authentication from the Web Service Proxy Class.
        /// </summary>
        /// <param name="authHeader"></param>
        /// <returns></returns>
        public static async Task<List<ProjectUser>> GetProjectsForUserListAysnc(AuthHeader authHeader)
        {
            List<ProjectUser> result = await App.PhoneAppSoapService.GetProjectsForUserListAysnc(authHeader);
            return result;
        }

    }
}
