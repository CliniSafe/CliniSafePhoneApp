using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// Returns GAMPTest CliniSafe Phone App Web Service Url.
        /// </summary>
        public static string GAMPTestUrl
        {
            get
            {
                string phoneUrl = "https://gamptesting.clinisafesandbox.com/webservices/PhoneApp.asmx";
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
                string phoneUrl = "https://01gamptesting.clinisafesandbox.com/webservices/PhoneApp.asmx";
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


        /// <summary>
        /// Returns CliniSafe Image Logo.
        /// </summary>
        public static string CliniSafeImage
        {
            get
            {
                string cliniSafeImage = "logo.png";

                return cliniSafeImage;
            }
        }


        public static Task<List<Object>> DeserializeXMLToList(string rawXml)
        {
            //// Decode xml(rawXml) into a list and assign to CountriesForProjectForMonitorUser model
            //StringReader stringReader = new StringReader(rawXml);

            //XmlSerializer serializer = new XmlSerializer(typeof(List<Object>), new XmlRootAttribute("NewDataSet"));

            //List<Object> listResult = (List<Object>)serializer.Deserialize(stringReader);

            //return listResult;

            throw new NotImplementedException();

        }
    }
}
