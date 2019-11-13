using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CliniSafePhoneApp.Portable.Models
{
    [XmlRoot("NewDataSet")]
    public class CountriesForProjectForMonitorUser : INotifyPropertyChanged, ICountriesForProjectForMonitorUser
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


        private string displayTrialCode;

        public string DisplayTrialCode
        {
            get { return displayTrialCode; }
            set
            {
                displayTrialCode = value;
                OnPropertyChanged("DisplayTrialCode");
            }
        }


        private string trialTitleShort;

        public string TrialTitleShort
        {
            get { return trialTitleShort; }
            set
            {
                trialTitleShort = value;
                OnPropertyChanged("TrialTitleShort");
            }
        }


        private string trialTitleFull;

        public string TrialTitleFull
        {
            get { return trialTitleFull; }
            set
            {
                trialTitleFull = value;
                OnPropertyChanged("TrialTitleFull");
            }
        }


        private int trialStatus_ID;

        public int TrialStatus_ID
        {
            get { return trialStatus_ID; }
            set
            {
                trialStatus_ID = value;
                OnPropertyChanged("TrialStatus_ID");
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


        private string englishLanguageName;
        public string EnglishLanguageName
        {
            get { return englishLanguageName; }
            set
            {
                englishLanguageName = value;
                OnPropertyChanged("EnglishLanguageName");
            }
        }


        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }


        private string trialDetails;
        public string TrialDetails
        {
            get { return trialDetails; }
            set
            {
                trialDetails = value;
                OnPropertyChanged("TrialDetails");
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
        /// <param name="projectUser"></param>
        /// <returns></returns>
        public static async Task<List<CountriesForProjectForMonitorUser>> GetCountriesForProjectForMonitorUserListAsync(ProjectUser projectUser)
        {
            List<CountriesForProjectForMonitorUser> result = await App.PhoneAppSoapService.GetCountriesForProjectForMonitorUserListAsync(projectUser);
            return result;
        }

    }
}
