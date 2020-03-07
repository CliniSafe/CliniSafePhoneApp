using System.ComponentModel;
using System.Threading.Tasks;

namespace CliniSafePhoneApp.Portable.Models
{
    public class ValidateDrugsInput : INotifyPropertyChanged, IValidateDrugsInput
    {
        private int project_ID;

        public int Project_ID
        {
            get { return project_ID; }
            set
            {
                project_ID = value;
                OnPropertyChanged("Project_ID");
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

        private int researchSite_ID;

        public int ResearchSite_ID
        {
            get { return researchSite_ID; }
            set
            {
                researchSite_ID = value;
                OnPropertyChanged("ResearchSite_ID");
            }
        }

        private int patient_ID;

        public int Patient_ID
        {
            get { return patient_ID; }
            set
            {
                patient_ID = value;
                OnPropertyChanged("Patient_ID");
            }
        }

        private string drugName;

        public string DrugName
        {
            get { return drugName; }
            set
            {
                drugName = value;
                OnPropertyChanged("DrugName");
            }
        }


        private string questionsAndAnswers;

        public string QuestionsAndAnswers
        {
            get { return questionsAndAnswers; }
            set
            {
                questionsAndAnswers = value;
                OnPropertyChanged("QuestionsAndAnswers");
            }
        }



        //New Property Authenticate(Check if user is Authenticated return value from the Web Service)
        #region AuthHeader Values Returned

        private string authenticate;

        public string Authenticate
        {
            get { return authenticate; }
            set
            {
                authenticate = value;
                OnPropertyChanged("Authenticate");
            }
        }



        private bool hasIssues;

        public bool HasIssues
        {
            get { return hasIssues; }
            set
            {
                hasIssues = value;
                OnPropertyChanged("HasIssues");
            }
        }

        private bool maintenanceMode;

        public bool MaintenanceMode
        {
            get { return maintenanceMode; }
            set
            {
                maintenanceMode = value;
                OnPropertyChanged("MaintenanceMode");
            }
        }


        private bool cPAVersionExact;

        public bool CPAVersionExact
        {
            get { return cPAVersionExact; }
            set
            {
                cPAVersionExact = value;
                OnPropertyChanged("CPAVersionExact");
            }
        }

        private bool cPANeedsUpdating;

        public bool CPANeedsUpdating
        {
            get { return cPANeedsUpdating; }
            set
            {
                cPANeedsUpdating = value;
                OnPropertyChanged("CPANeedsUpdating");
            }
        }

        private bool usernamePasswordValid;

        public bool UsernamePasswordValid
        {
            get { return usernamePasswordValid; }
            set
            {
                usernamePasswordValid = value;
                OnPropertyChanged("UsernamePasswordValid");
            }
        }

        private bool userTypeValid;

        public bool UserTypeValid
        {
            get { return userTypeValid; }
            set
            {
                userTypeValid = value;
                OnPropertyChanged("UserTypeValid");
            }
        }

        private bool userMobileTrained;

        public bool UserMobileTrained
        {
            get { return userMobileTrained; }
            set
            {
                userMobileTrained = value;
                OnPropertyChanged("UserMobileTrained");
            }
        }

        private bool trialActive;

        public bool TrialActive
        {
            get { return trialActive; }
            set
            {
                trialActive = value;
                OnPropertyChanged("TrialActive");
            }
        }

        private int messageCode;

        public int MessageCode
        {
            get { return messageCode; }
            set
            {
                messageCode = value;
                OnPropertyChanged("MessageCode");
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }


        private bool authenticated;

        public bool Authenticated
        {
            get { return authenticated; }
            set
            {
                authenticated = value;
                OnPropertyChanged("Authenticated");
            }
        }


        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Validate Drugs List Logic returns XMl / HMTL from Web Service Proxy Class.
        /// </summary>
        /// <param name="validateDrugsInput"></param>
        /// <returns></returns>
        public static async Task<ValidateDrugsOutput> ValidateDrugsListAsync(ValidateDrugsInput validateDrugsInput)
        {
            ValidateDrugsOutput result = await App.PhoneAppSoapService.ValidateDrugsListAsync(validateDrugsInput);
            return result;
        }
    }
}
