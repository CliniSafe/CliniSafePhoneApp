using Plugin.Connectivity;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
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
            return CrossConnectivity.Current.IsConnected;
        }

        /// <summary>
        /// The CliniSafe Phone App Version Number.
        /// </summary>
        public static string CPAVersion
        {
            get
            {
                return "1.0";
            }
        }

        /// <summary>
        /// Returns DevTest CliniSafe Phone App Web Service Url.
        /// </summary>
        public static string DevTestUrl
        {
            get
            {
                return "https://developmenttesting.clinisafesandbox.com/webservices/PhoneApp.asmx";
            }
        }


        /// <summary>
        /// Returns GAMPTest CliniSafe Phone App Web Service Url.
        /// </summary>
        public static string GAMPTestUrl
        {
            get
            {
                return "https://gamptesting.clinisafesandbox.com/webservices/PhoneApp.asmx";
            }
        }



        /// <summary>
        /// Returns an Invalid for CliniSafe Phone App Web Service Url.
        /// </summary>
        public static string WrongTestUrl
        {
            get
            {
                return "https://01gamptesting.clinisafesandbox.com/webservices/PhoneApp.asmx";
            }
        }


        /// <summary>
        /// Returns Local CliniSafe Phone App Web Service Url.
        /// </summary>
        public static string LocalSoapUrl
        {
            get
            {
                return (Device.RuntimePlatform == Device.Android) ? "http://10.0.2.2:54850/WebServices/PhoneApp.asmx" : "http://localhost:54850/WebServices/PhoneApp.asmx";
            }
        }


        /// <summary>
        /// Returns CliniSafe Image Logo.
        /// </summary>
        public static string CliniSafeImage
        {
            get
            {
                return "logo.png";
            }
        }

        /// <summary>
        /// Displays PopUp Message.
        /// </summary>
        /// <param name="popUpTitle"></param>
        /// <param name="popUpMessage"></param>
        /// <returns></returns>
        public static async Task DisplayPopUp(string popUpTitle, string popUpMessage)
        {
            await App.Current.MainPage.DisplayAlert(popUpTitle, popUpMessage, "OK");
        }

        public static List<T> DeserializeXMLToList<T>(string stringXML)
        {
            StringReader stringReader = new StringReader(stringXML);

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("NewDataSet"));

            return (List<T>)serializer.Deserialize(stringReader);
        }
    }
}
