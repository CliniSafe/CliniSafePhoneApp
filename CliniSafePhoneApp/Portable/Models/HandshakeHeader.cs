using System.ComponentModel;
using System.Threading.Tasks;

namespace CliniSafePhoneApp.Portable.Models
{
    public class HandshakeHeader : INotifyPropertyChanged, IHandshakeHeader
    {
        private string cPAVersion;

        public string CPAVersion
        {
            get { return cPAVersion; }
            set
            {
                cPAVersion = value;
                OnPropertyChanged("CPAVersion");
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


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///  Handshake Logic to get value from the Web Serivice Proxy Class. 
        /// </summary>
        /// <param name="handshakeHeader"></param>
        /// <returns></returns>
        public static async Task<string> HandShakeAsync(HandshakeHeader handshakeHeader)
        {
            string result = await App.PhoneAppSoapService.HandShakeAsync(handshakeHeader);
            return result;
        }

        /// <summary>
        /// Returns HandshakeHeader values from the Web Serivice Proxy Class. 
        /// </summary>
        /// <returns></returns>
        public static HandshakeHeader GetHandshakeHeader()
        {
            return App.PhoneAppSoapService.GetHandshakeHeader();
        }
    }

}
