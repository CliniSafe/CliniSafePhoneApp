using Plugin.Connectivity;

using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.Service
{
    public static class Constants
    {
        /// <summary>
        /// Checks for Internet Connectivity of the Phone.
        /// </summary>
        /// <returns></returns>
        public static bool CheckConnectivity()
        {
            bool isConnected = CrossConnectivity.Current.IsConnected;
            return isConnected;
        }

        /// <summary>
        /// The CliniSafe Phone App Version Number.
        /// </summary>
        public static string CPAVersion
        {
            get
            {
                string cPAVersion = "1.0";
                return cPAVersion;
            }
        }


        /// <summary>
        /// Returns DevTest CliniSafe Phone App Web Service Url.
        /// </summary>
        public static string DevTestUrl
        {
            get
            {
                string phoneUrl = "https://developmenttesting.clinisafesandbox.com/webservices/PhoneApp.asmx";
                return phoneUrl;
            }
        }


        /// <summary>
        /// Returns an Invalid for CliniSafe Phone App Web Service Url.
        /// </summary>
        public static string WrongTestUrl
        {
            get
            {
                string phoneUrl = "https://gamptesting.clinisafesandbox.com/webservices/PhoneApp.asmx";
                return phoneUrl;
            }
        }


        /// <summary>
        /// Returns Local CliniSafe Phone App Web Service Url.
        /// </summary>
        public static string LocalSoapUrl
        {
            get
            {
                string phoneUrl = "http://localhost:54850/webservices/PhoneApp.asmx";

                if (Device.RuntimePlatform == Device.Android)
                    phoneUrl = "http://10.0.2.2:54850/webservices/PhoneApp.asmx";

                return phoneUrl;
            }
        }
    }
}
