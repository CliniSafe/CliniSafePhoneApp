using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CliniSafePhoneApp.Portable.Models
{
    [XmlRoot("NewDataSet")]
    public class ResearchSitesForProjectForInvestigatorUser : INotifyPropertyChanged, IResearchSitesForProjectForInvestigatorUser
    {
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


        private int country_ID;

        public int Country_ID
        {
            get { return country_ID; }
            set
            {
                country_ID = value;
                OnPropertyChanged("Country_ID");
            }
        }

        private int trial_ID;

        public int Trial_ID
        {
            get { return trial_ID; }
            set
            {
                trial_ID = value;
                OnPropertyChanged("Trial_ID");
            }
        }

        private string siteCode;

        public string SiteCode
        {
            get { return siteCode; }
            set
            {
                siteCode = value;
                OnPropertyChanged("SiteCode");
            }
        }


        private string siteTitle;

        public string SiteTitle
        {
            get { return siteTitle; }
            set
            {
                siteTitle = value;
                OnPropertyChanged("SiteTitle");
            }
        }


        private string address1;

        public string Address1
        {
            get { return address1; }
            set
            {
                address1 = value;
                OnPropertyChanged("Address1");
            }
        }


        private int researchSiteStatus_ID;

        public int ResearchSiteStatus_ID
        {
            get { return researchSiteStatus_ID; }
            set
            {
                researchSiteStatus_ID = value;
                OnPropertyChanged("ResearchSiteStatus_ID");
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


        private string localCountryName;

        public string LocalCountryName
        {
            get { return localCountryName; }
            set
            {
                localCountryName = value;
                OnPropertyChanged("LocalCountryName");
            }
        }

        private string siteStatus;

        public string SiteStatus
        {
            get { return siteStatus; }
            set
            {
                siteStatus = value;
                OnPropertyChanged("SiteStatus");
            }
        }


        private string combineDisplayTrialCodeSiteTitle;

        public string CombineDisplayTrialCodeSiteTitle
        {
            get { return combineDisplayTrialCodeSiteTitle; }
            set { combineDisplayTrialCodeSiteTitle = value;
                OnPropertyChanged("CombineDisplayTrialCodeSiteTitle");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Returns ResearchSites for User after authentication from the Web Service Proxy Class.
        /// </summary>
        /// <param name="projectUser"></param>
        /// <returns></returns>
        public static async Task<List<ResearchSitesForProjectForInvestigatorUser>> GetResearchSitesForProjectForInvestigtorUserListAsync(ProjectUser projectUser)
        {
            List<ResearchSitesForProjectForInvestigatorUser> result = await App.PhoneAppSoapService.GetResearchSitesForProjectForInvestigtorUserListAsync(projectUser);
            return result;
        }
    }
}
