using System.ComponentModel;
using System.Threading.Tasks;

namespace CliniSafePhoneApp.Portable.Models
{
    public class ValidateDrugsOutput : INotifyPropertyChanged, IValidateDrugsOutput
    {
        private string hTMLResult;

        public string HTMLResult
        {
            get { return hTMLResult; }
            set
            {
                hTMLResult = value;
                OnPropertyChanged("HTMLResult");
            }
        }

        private string xMLResult;

        public string XMLResult
        {
            get { return xMLResult; }
            set
            {
                xMLResult = value;
                OnPropertyChanged("XMLResult");
            }
        }

        private string xMLDrugRuleMessage;

        public string XMLDrugRuleMessage
        {
            get { return xMLDrugRuleMessage; }
            set
            {
                xMLDrugRuleMessage = value;
                OnPropertyChanged("XMLDrugRuleMessage");
            }
        }




        //New Property Authenticate(Check if user is Authenticated return value from the Web Service)
        #region AuthHeader Values Returned

        //private string authenticate;

        //public string Authenticate
        //{
        //    get { return authenticate; }
        //    set
        //    {
        //        authenticate = value;
        //        OnPropertyChanged("Authenticate");
        //    }
        //}



        //private bool hasIssues;

        //public bool HasIssues
        //{
        //    get { return hasIssues; }
        //    set
        //    {
        //        hasIssues = value;
        //        OnPropertyChanged("HasIssues");
        //    }
        //}

        //private bool maintenanceMode;

        //public bool MaintenanceMode
        //{
        //    get { return maintenanceMode; }
        //    set
        //    {
        //        maintenanceMode = value;
        //        OnPropertyChanged("MaintenanceMode");
        //    }
        //}


        //private bool cPAVersionExact;

        //public bool CPAVersionExact
        //{
        //    get { return cPAVersionExact; }
        //    set
        //    {
        //        cPAVersionExact = value;
        //        OnPropertyChanged("CPAVersionExact");
        //    }
        //}

        //private bool cPANeedsUpdating;

        //public bool CPANeedsUpdating
        //{
        //    get { return cPANeedsUpdating; }
        //    set
        //    {
        //        cPANeedsUpdating = value;
        //        OnPropertyChanged("CPANeedsUpdating");
        //    }
        //}

        //private bool usernamePasswordValid;

        //public bool UsernamePasswordValid
        //{
        //    get { return usernamePasswordValid; }
        //    set
        //    {
        //        usernamePasswordValid = value;
        //        OnPropertyChanged("UsernamePasswordValid");
        //    }
        //}

        //private bool userTypeValid;

        //public bool UserTypeValid
        //{
        //    get { return userTypeValid; }
        //    set
        //    {
        //        userTypeValid = value;
        //        OnPropertyChanged("UserTypeValid");
        //    }
        //}

        //private bool userMobileTrained;

        //public bool UserMobileTrained
        //{
        //    get { return userMobileTrained; }
        //    set
        //    {
        //        userMobileTrained = value;
        //        OnPropertyChanged("UserMobileTrained");
        //    }
        //}

        //private bool trialActive;

        //public bool TrialActive
        //{
        //    get { return trialActive; }
        //    set
        //    {
        //        trialActive = value;
        //        OnPropertyChanged("TrialActive");
        //    }
        //}

        //private int messageCode;

        //public int MessageCode
        //{
        //    get { return messageCode; }
        //    set
        //    {
        //        messageCode = value;
        //        OnPropertyChanged("MessageCode");
        //    }
        //}

        //private string message;

        //public string Message
        //{
        //    get { return message; }
        //    set
        //    {
        //        message = value;
        //        OnPropertyChanged("Message");
        //    }
        //}


        //private bool authenticated;

        //public bool Authenticated
        //{
        //    get { return authenticated; }
        //    set
        //    {
        //        authenticated = value;
        //        OnPropertyChanged("Authenticated");
        //    }
        //}


        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Validate Drugs List Logic returns a List of drugs, questions and answers from Web Service Proxy Class.
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
