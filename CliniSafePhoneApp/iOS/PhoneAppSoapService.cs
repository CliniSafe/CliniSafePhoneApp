﻿using CliniSafePhoneApp.iOS.DevTestPhoneAppService;
using CliniSafePhoneApp.Portable;
using CliniSafePhoneApp.Portable.Data;
using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xamarin.Forms;

[assembly: Dependency(typeof(CliniSafePhoneApp.iOS.PhoneAppSoapService))]
namespace CliniSafePhoneApp.iOS
{
    public class PhoneAppSoapService : ISoapService, INotifyPropertyChanged
    {
        public MainPage RootPage { get => App.Current.MainPage as MainPage; }

        PhoneApp devTestPhoneAppService;
        TaskCompletionSource<bool> helloWorldRequestComplete = null;
        TaskCompletionSource<bool> handshakeRequestComplete = null;
        TaskCompletionSource<bool> authenticateRequestComplete = null;
        TaskCompletionSource<bool> helloErrorRequestComplete = null;
        TaskCompletionSource<bool> echoRequestComplete = null;
        TaskCompletionSource<bool> projectsForUserComplete = null;
        TaskCompletionSource<bool> countriesForProjectForMonitorUserComplete = null;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public PhoneAppSoapService()
        {
            devTestPhoneAppService = new PhoneApp() { Url = Constants.DevTestUrl };
            devTestPhoneAppService.HelloWorldCompleted += PhoneApp_HelloWorldCompleted;
            devTestPhoneAppService.HandshakeCompleted += PhoneApp_HandshakeCompleted;
            devTestPhoneAppService.AuthenticateCompleted += PhoneApp_AuthenticateCompleted;
            devTestPhoneAppService.HelloErrorCompleted += PhoneApp_HelloErrorCompleted;
            devTestPhoneAppService.EchoCompleted += PhonaApp_EchoComplted;
            devTestPhoneAppService.GetProjectsForUserCompleted += PhoneApp_ProjectsForUserCompleted;
            devTestPhoneAppService.GetCountriesForProjectForMonitorUserCompleted += PhoneApp_CountriesForProjectForMonitorUserCompleted;


        }

        public string helloWorldResult;

        public string handshakeResult;

        public static string authenticationResult;

        public static string projectForUserResult;

        public static string xmlProjectForUserResult;

        public static string xmlCountriesForProjectForMonitorUserResult;

        public static List<ProjectUser> projectForUserListResult { get; set; }

        public static int Project_ID;

        public static List<CountriesForProjectForMonitorUser> CountriesForProjectForMonitorUserListResult { get; set; }

        public string echoResult;

        /// <summary>
        /// Declare private member for assigning Soap Header results returned from Web Service.
        /// </summary>
        private Portable.Models.AuthHeader authHeaderResults = new Portable.Models.AuthHeader();


        /// <summary>
        /// Declare private member for assigning Soap Header results returned from Web Service.
        /// </summary>
        private Portable.Models.HandshakeHeader handshakeHeaderResults = new Portable.Models.HandshakeHeader();



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


        public static Portable.Models.HandshakeHeader FromPhoneAppSoapServiceHandshake(DevTestPhoneAppService.HandshakeHeader handshakeHeader)
        {
            return new Portable.Models.HandshakeHeader
            {
                CPAVersion = handshakeHeader.CPAVersion,
                CPANeedsUpdating = handshakeHeader.CPANeedsUpdating,
                CPAVersionExact = handshakeHeader.CPAVersionExact,
                HasIssues = handshakeHeader.HasIssues,
                MaintenanceMode = handshakeHeader.MaintenanceMode,
                Message = handshakeHeader.Message,
                MessageCode = handshakeHeader.MessageCode
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
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
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
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
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
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
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
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
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
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
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
            DevTestPhoneAppService.HandshakeHeader handshakeHeader1 = new DevTestPhoneAppService.HandshakeHeader();
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




        private void PhoneApp_ProjectsForUserCompleted(object sender, GetProjectsForUserCompletedEventArgs e)
        {
            try
            {
                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        projectsForUserComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        projectsForUserComplete?.TrySetException(e.Error);
                    else
                        projectsForUserComplete?.TrySetException(e.Error);

                devTestPhoneAppService.GetProjectsForUserAsync();
                xmlProjectForUserResult = e.Result;
                projectsForUserComplete = projectsForUserComplete ?? new TaskCompletionSource<bool>();

                XDocument xDocumentProjectForUser = new XDocument();

                //Decode xml(xmlProjectForUserResult) into a list and assign to projectForUserListResult model
                if (!string.IsNullOrEmpty(xmlProjectForUserResult))
                {
                    xDocumentProjectForUser = XDocument.Parse(xmlProjectForUserResult);
                }

                if (!string.IsNullOrEmpty(xmlProjectForUserResult) && xDocumentProjectForUser.Root.Elements().Any())
                {
                    projectForUserListResult = xDocumentProjectForUser.Descendants("ProjectsForUser").Select(d =>
                    new ProjectUser
                    {
                        ID = Convert.ToInt32(d.Element("ID").Value),
                        Sponsor = d.Element("Sponsor").Value,
                        ContractResearchOrganisation = d.Element("ContractResearchOrganisation").Value,
                        ProjectCode = d.Element("ProjectCode").Value,
                        ProjectTitleShortPhoneDisplay = (d.Element("ProjectTitleShort").Value.Length <= 28) ? d.Element("ProjectTitleShort").Value : d.Element("ProjectTitleShort").Value.Substring(0, 25) + "...",
                        ProjectTitleShort = d.Element("ProjectTitleShort").Value,
                        ProjectTitleFull = d.Element("ProjectTitleFull").Value,
                        DropDownDesc = d.Element("ProjectCode").Value + " - " + d.Element("ProjectTitleShort").Value,
                        IRPUserDashboard = d.Element("IRPUserDashboard").Value,
                        StudyDashboard = d.Element("StudyDashboard").Value,
                        DrugRuleBuilderDashboard = d.Element("DrugRuleBuilderDashboard").Value,
                        ExploreDrugsDashboard = d.Element("ExploreDrugsDashboard").Value,
                        TeamDashboard = d.Element("TeamDashboard").Value,
                        TranslationDashboard = d.Element("TranslationDashboard").Value,
                        ReportsDashboard = d.Element("ReportsDashboard").Value,
                        EndUserDashboard = d.Element("EndUserDashboard").Value,
                        WizardDashboard = d.Element("WizardDashboard").Value,
                        InvestigatorDashboard = d.Element("InvestigatorDashboard").Value

                    }).ToList();
                }

                projectsForUserComplete?.TrySetResult(true);
            }
            catch (SoapException se)
            {
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }


        public async Task<List<ProjectUser>> GetProjectsForUserListAysnc(Portable.Models.AuthHeader authHeader)
        {
            projectsForUserComplete = new TaskCompletionSource<bool>();
            DevTestPhoneAppService.AuthHeader authHeader1 = new DevTestPhoneAppService.AuthHeader()
            {
                Username = authHeader.Username,
                Password = authHeader.Password,
                CPAVersion = authHeader.CPAVersion
            };

            devTestPhoneAppService.AuthHeaderValue = authHeader1;
            devTestPhoneAppService.GetProjectsForUserAsync(authHeader);
            await projectsForUserComplete.Task;
            return projectForUserListResult;
        }


        private void PhoneApp_CountriesForProjectForMonitorUserCompleted(object sender, GetCountriesForProjectForMonitorUserCompletedEventArgs e)
        {
            try
            {
                countriesForProjectForMonitorUserComplete = countriesForProjectForMonitorUserComplete ?? new TaskCompletionSource<bool>();

                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        countriesForProjectForMonitorUserComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        countriesForProjectForMonitorUserComplete?.TrySetException(e.Error);
                    else
                        countriesForProjectForMonitorUserComplete?.TrySetException(e.Error);

                devTestPhoneAppService.GetCountriesForProjectForMonitorUserAsync(Project_ID);
                xmlCountriesForProjectForMonitorUserResult = e.Result;

                // Decode xml(xmlCountriesForProjectForMonitorUserResult) into a list and assign to countriesForUserListResult model
                StringReader stringReader = new StringReader(xmlCountriesForProjectForMonitorUserResult);

                XmlSerializer serializer = new XmlSerializer(typeof(List<CountriesForProjectForMonitorUser>), new XmlRootAttribute("NewDataSet"));

                CountriesForProjectForMonitorUserListResult = (List<CountriesForProjectForMonitorUser>)serializer.Deserialize(stringReader);

                countriesForProjectForMonitorUserComplete?.TrySetResult(true);
            }
            catch (SoapException se)
            {
                DisplaySoapException(se);
            }
            catch (WebException we)
            {
                DisplayWebException(we);
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }

        }


        public async Task<List<CountriesForProjectForMonitorUser>> GetCountriesForProjectForMonitorUserListAsync(ProjectUser projectUser)
        {
            countriesForProjectForMonitorUserComplete = new TaskCompletionSource<bool>();

            if (projectUser != null)
                Project_ID = projectUser.ID;

            devTestPhoneAppService.GetCountriesForProjectForMonitorUserAsync(Project_ID);
            await countriesForProjectForMonitorUserComplete.Task;
            return CountriesForProjectForMonitorUserListResult;
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
        /// Assign the Soap Header Values Returned by the Handshake Method from the Web Service.
        /// </summary>
        /// <returns></returns>
        public Portable.Models.HandshakeHeader GetHandshakeHeader()
        {
            handshakeHeaderResults = FromPhoneAppSoapServiceHandshake(devTestPhoneAppService.HandshakeHeaderValue);
            return handshakeHeaderResults;
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

            // Navigate to the error page
            await RootPage.NavigateFromMenu((int)MenuItemType.Error, null, null, strDisplayMessage);




            //await App.Current.MainPage.DisplayAlert("Error", strDisplayMessage, "Cancel");

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

            // Navigate to the error page
            await RootPage.NavigateFromMenu((int)MenuItemType.Error, null, null, strDisplayMessage);

            //await App.Current.MainPage.DisplayAlert("Error", strDisplayMessage, "Cancel");

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

            // Navigate to the error page
            await RootPage.NavigateFromMenu((int)MenuItemType.Error, null, null, strDisplayMessage);



            //await App.Current.MainPage.DisplayAlert("Error", strDisplayMessage, "Cancel");


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