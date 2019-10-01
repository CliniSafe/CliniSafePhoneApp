﻿using CliniSafePhoneApp.iOS.DevTestPhoneAppService;
using CliniSafePhoneApp.Portable;
using CliniSafePhoneApp.Portable.Data;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using System.Xml;
using Xamarin.Forms;




[assembly: Dependency(typeof(CliniSafePhoneApp.iOS.PhoneAppSoapService))]
namespace CliniSafePhoneApp.iOS
{
    public class PhoneAppSoapService : ISoapService, INotifyPropertyChanged
    {
        PhoneApp devTestPhoneAppService;
        TaskCompletionSource<bool> helloWorldRequestComplete = null;
        TaskCompletionSource<bool> handshakeRequestComplete = null;
        TaskCompletionSource<bool> authenticateRequestComplete = null;
        TaskCompletionSource<bool> helloErrorRequestComplete = null;
        TaskCompletionSource<bool> echoRequestComplete = null;


        public PhoneAppSoapService()
        {
            devTestPhoneAppService = new PhoneApp();
            devTestPhoneAppService.Url = Constants.DevTestUrl;

            devTestPhoneAppService.HelloWorldCompleted += PhoneApp_HelloWorldCompleted;
            devTestPhoneAppService.HandshakeCompleted += PhoneApp_HandshakeCompleted;
            devTestPhoneAppService.AuthenticateCompleted += PhoneApp_AuthenticateCompleted;
            devTestPhoneAppService.HelloErrorCompleted += PhoneApp_HelloErrorCompleted;
            devTestPhoneAppService.EchoCompleted += PhonaApp_EchoComplted;
        }

        public string helloWorldResult;

        public string handshakeResult;

        public static string authenticationResult;

        public string echoResult;

        /// <summary>
        /// Declare private member for assigning Soap Header results returned from Web Service.
        /// </summary>
        private Portable.Models.AuthHeader authHeaderResults = new Portable.Models.AuthHeader();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }







        #region Update Soap Header Values Returned from Web Service


        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

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



        #endregion



        DevTestPhoneAppService.AuthHeader ToPhoneAppSoapServiceAuthenticate(Portable.Models.AuthHeader authHeader)
        {
            return new DevTestPhoneAppService.AuthHeader
            {
                Username = authHeader.Username,
                Password = authHeader.Password,
                CPAVersion = authHeader.CPAVersion
            };
        }

        public static Portable.Models.AuthHeader FromPhoneAppServiceAuthenticate(DevTestPhoneAppService.AuthHeader authHeader)
        {
            return new Portable.Models.AuthHeader
            {
                Authenticate = authenticationResult,
                HasIssues = authHeader.HasIssues,
                MaintenanceMode = authHeader.MaintenanceMode,
                CPAVersionExact = authHeader.CPAVersionExact,
                CPANeedsUpdating = authHeader.CPANeedsUpdating,
                Authenticated = authHeader.Authenticated,
                UsernamePasswordValid = authHeader.UsernamePasswordValid,
                UserTypeValid = authHeader.UserTypeValid,
                UserMobileTrained = authHeader.UserMobileTrained,
                TrialActive = authHeader.TrialActive,
                MessageCode = authHeader.MessageCode,
                Message = authHeader.Message

            };
        }


        DevTestPhoneAppService.HandshakeHeader ToPhoneAppSoapServiceHandshake(CliniSafePhoneApp.Portable.Models.HandshakeHeader handshakeHeader)
        {
            return new DevTestPhoneAppService.HandshakeHeader
            {
                CPAVersion = handshakeHeader.CPAVersion
            };
        }

        static DevTestPhoneAppService.HandshakeHeader FromPhoneAppSoapServiceHandshake(DevTestPhoneAppService.HandshakeHeader handshakeHeader)
        {
            return new DevTestPhoneAppService.HandshakeHeader
            {
                CPAVersion = handshakeHeader.CPAVersion
            };
        }

        private void PhoneApp_HelloWorldCompleted(object sender, HelloWorldCompletedEventArgs e)
        {
            try
            {
                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        helloWorldRequestComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        helloWorldRequestComplete?.TrySetException(e.Error);
                    else
                        helloWorldRequestComplete?.TrySetException(e.Error);

                helloWorldRequestComplete = helloWorldRequestComplete ?? new TaskCompletionSource<bool>();

                devTestPhoneAppService.HelloWorldAsync();
                helloWorldResult = e.Result;
                helloWorldRequestComplete?.TrySetResult(true);
            }
            catch (SoapException se)
            {
                //Debug.WriteLine("\t\t{0}", se.Detail.InnerText);
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                //Debug.WriteLine("\t\t{0}", we.Message);
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\t\tERROR {0}", ex.InnerException.Message);
                DisplayException(ex);
            }
        }

        private void PhoneApp_HandshakeCompleted(object sender, HandshakeCompletedEventArgs e)
        {
            try
            {
                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        handshakeRequestComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        handshakeRequestComplete?.TrySetException(e.Error);
                    else
                        handshakeRequestComplete?.TrySetException(e.Error);


                handshakeRequestComplete = handshakeRequestComplete ?? new TaskCompletionSource<bool>();
                //handshakeResult = devTestPhoneAppService.Handshake();


                devTestPhoneAppService.HandshakeAsync();
                handshakeResult = e.Result;
                handshakeRequestComplete?.TrySetResult(true);
            }
            catch (SoapException se)
            {
                //Debug.WriteLine("\t\tERROR {0}", se.Detail.InnerText);
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                //Debug.WriteLine("\t\tERROR {0}", we.Message);
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\t\tERROR {0}", ex.InnerException.Message);
                DisplayException(ex);
            };
        }

        private void PhoneApp_AuthenticateCompleted(object sender, AuthenticateCompletedEventArgs e)
        {
            try
            {
                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        authenticateRequestComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        authenticateRequestComplete?.TrySetException(e.Error);
                    else
                        authenticateRequestComplete?.TrySetException(e.Error);


                authenticateRequestComplete = authenticateRequestComplete ?? new TaskCompletionSource<bool>();
                devTestPhoneAppService.Authenticate();
                authenticationResult = e.Result;

                if (authenticationResult == "Authenticated")
                    GetAuthHeader();

                authenticateRequestComplete?.TrySetResult(true);
            }
            catch (SoapException se)
            {
                //Debug.WriteLine("\t\tERROR {0}", se.Detail.InnerText);
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                //Debug.WriteLine("\t\tERROR {0}", we.Message);
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\t\tERROR {0}", ex.InnerException.Message);
                DisplayException(ex);
            }
        }

        /// <summary>
        /// Returns Error Soap Exception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneApp_HelloErrorCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        helloErrorRequestComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        helloErrorRequestComplete?.TrySetException(e.Error);
                    else
                        helloErrorRequestComplete?.TrySetException(e.Error);


                helloErrorRequestComplete = helloErrorRequestComplete ?? new TaskCompletionSource<bool>();
                devTestPhoneAppService.HelloErrorAsync();
                helloErrorRequestComplete?.TrySetResult(true);
            }
            catch (SoapException se)
            {
                //Debug.WriteLine("\t\tERROR {0}", se.Detail.InnerText);
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                //Debug.WriteLine("\t\tERROR {0}", we.Message);
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\t\tERROR {0}", ex.InnerException.Message);
                DisplayException(ex);
            }
        }

        private void PhonaApp_EchoComplted(object sender, EchoCompletedEventArgs e)
        {
            try
            {
                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        echoRequestComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        echoRequestComplete?.TrySetException(e.Error);
                    else
                        echoRequestComplete?.TrySetException(e.Error);


                echoRequestComplete = echoRequestComplete ?? new TaskCompletionSource<bool>();
                devTestPhoneAppService.EchoAsync(e.Result);
                echoResult = e.Result;
                echoRequestComplete?.TrySetResult(true);
            }
            catch (SoapException se)
            {
                //Debug.WriteLine("\t\tERROR {0}", se.Detail.InnerText);
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                //Debug.WriteLine("\t\tERROR {0}", we.Message);
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\t\tERROR {0}", ex.InnerException.Message);
                DisplayException(ex);
            }
        }

        /// <summary>
        /// Returns Hello.
        /// </summary>
        /// <returns></returns>
        public async Task<string> HelloWorldAsync()
        {
            helloWorldRequestComplete = new TaskCompletionSource<bool>();
            devTestPhoneAppService.HelloWorldAsync();
            await helloWorldRequestComplete.Task;
            return helloWorldResult;
        }

        /// <summary>
        /// Returns Handshake Value.
        /// </summary>
        /// <param name="handShakeHeader"></param>
        /// <returns></returns>
        public async Task<string> HandShakeAsync(Portable.Models.HandshakeHeader handShakeHeader)
        {
            handshakeRequestComplete = new TaskCompletionSource<bool>();
            HandshakeHeader handshakeHeader1 = new HandshakeHeader();
            handshakeHeader1.CPAVersion = handShakeHeader.CPAVersion;
            devTestPhoneAppService.HandshakeHeaderValue = handshakeHeader1;
            devTestPhoneAppService.HandshakeAsync(handShakeHeader);
            await handshakeRequestComplete.Task;
            return handshakeResult;
        }

        /// <summary>
        /// Returns AuthenticateAsync Value.
        /// </summary>
        /// <param name="authHeader"></param>
        /// <returns></returns>
        public async Task<string> AuthenticateAsync(Portable.Models.AuthHeader authHeader)
        {
            authenticateRequestComplete = new TaskCompletionSource<bool>();
            DevTestPhoneAppService.AuthHeader authHeader1 = new DevTestPhoneAppService.AuthHeader();
            authHeader1.Username = authHeader.Username;
            authHeader1.Password = authHeader.Password;
            authHeader1.CPAVersion = authHeader.CPAVersion;
            devTestPhoneAppService.AuthHeaderValue = authHeader1;
            devTestPhoneAppService.AuthenticateAsync(authHeader);
            await authenticateRequestComplete.Task;
            return authenticationResult;
        }


        /// <summary>
        /// Assign the Soap Header Values Returned from the Web Service.
        /// </summary>
        /// <returns></returns>
        public Portable.Models.AuthHeader GetAuthHeader()
        {
            authHeaderResults = FromPhoneAppServiceAuthenticate(devTestPhoneAppService.AuthHeaderValue);
            return authHeaderResults;
        }


        /// <summary>
        /// Returns Soap Exception
        /// </summary>
        /// <returns></returns>
        public async Task HelloErrorAsync()
        {
            helloErrorRequestComplete = new TaskCompletionSource<bool>();
            devTestPhoneAppService.HelloErrorAsync();
            await helloErrorRequestComplete.Task;
        }

        /// <summary>
        /// Echo Returns Input Value
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public async Task<string> EchoAsync(string inputValue)
        {

            echoRequestComplete = new TaskCompletionSource<bool>();
            devTestPhoneAppService.EchoAsync(inputValue);
            await echoRequestComplete.Task;
            return echoResult;
        }


        /// <summary>
        /// Displays the Exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public async void DisplayException(Exception exception)
        {
            string strDisplayMessage;

            strDisplayMessage = "Exception in the CliniSafe Phone App.";

            strDisplayMessage += strDisplayMessage + exception.Message;

            strDisplayMessage += strDisplayMessage + exception.StackTrace;

            await App.Current.MainPage.DisplayAlert("Error", strDisplayMessage, "Cancel");



            //Device.BeginInvokeOnMainThread(() =>
            //{

            //    App.Current.MainPage.DisplayAlert("Error", strDisplayMessage, "Cancel");

            //});

            //Navigate to Error Page


            //RichTextBoxResults.Text = strDisplayMessage;
            //MessageBox.Show("Web Service SOAP Exception.", "Error")
        }

        /// <summary>
        /// Displays the Web Exception.
        /// </summary>
        /// <param name="webException"></param>
        /// <returns></returns>
        public async void DisplayWebException(WebException webException)
        {
            string strDisplayMessage;

            strDisplayMessage = "Web Exception.";

            strDisplayMessage += strDisplayMessage + webException.Message;

            await App.Current.MainPage.DisplayAlert("Error", strDisplayMessage, "Cancel");

            //Navigate to Error Page


            //RichTextBoxResults.Text = strDisplayMessage;
            //MessageBox.Show("Web Exception.", "Error")
        }

        /// <summary>
        /// Displays the SOAP Exception.
        /// </summary>
        /// <param name="soapException"></param>
        /// <returns></returns>
        public async void DisplaySoapException(SoapException soapException)
        {
            string strDisplayMessage;

            strDisplayMessage = "Soap Service SOAP Exception.";

            strDisplayMessage += strDisplayMessage + soapException.Message;

            strDisplayMessage += strDisplayMessage + soapException.Actor;

            strDisplayMessage += strDisplayMessage + FormatXml(soapException.Detail);

            await App.Current.MainPage.DisplayAlert("Error", strDisplayMessage, "Cancel");


            // Navigate to Error Page


            //RichTextBoxResults.Text = strDisplayMessage;
            //MessageBox.Show("Soap Service SOAP Exception.", "Error")
        }


        /// <summary>
        /// Create a string with of the XML section of the SOAP Exception.
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        protected string FormatXml(XmlNode xmlNode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter(stringBuilder))
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlNode.WriteTo(xmlTextWriter);
                }
            }
            return stringBuilder.ToString();
        }
    }
}