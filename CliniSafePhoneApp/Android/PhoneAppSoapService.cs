using CliniSafePhoneApp.Android.DevTestPhoneAppService;
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
using Xamarin.Forms;



[assembly: Dependency(typeof(CliniSafePhoneApp.Android.PhoneAppSoapService))]
namespace CliniSafePhoneApp.Android


{
    public class PhoneAppSoapService : ISoapService, INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        PhoneApp devTestPhoneAppService;
        TaskCompletionSource<bool> helloWorldRequestComplete = null;
        TaskCompletionSource<bool> handshakeRequestComplete = null;
        TaskCompletionSource<bool> authenticateRequestComplete = null;
        TaskCompletionSource<bool> helloErrorRequestComplete = null;
        TaskCompletionSource<bool> echoRequestComplete = null;
        TaskCompletionSource<bool> projectsForUserComplete = null;
        TaskCompletionSource<bool> countriesForProjectForMonitorUserComplete = null;



        /// <summary>
        /// Initialize Web Service Url property and Event Handlers in constructor.
        /// </summary>
        public PhoneAppSoapService()
        {
            devTestPhoneAppService = new PhoneApp() { Url = Constants.DevTestUrl };
            devTestPhoneAppService.HelloWorldCompleted += PhoneApp_HelloWorldCompleted;
            devTestPhoneAppService.HandshakeCompleted += PhoneApp_HandshakeCompleted;
            devTestPhoneAppService.AuthenticateCompleted += PhoneApp_AuthenticateCompleted;
            devTestPhoneAppService.HelloErrorCompleted += PhoneApp_HelloErrorCompleted;
            devTestPhoneAppService.EchoCompleted += PhoneApp_EchoComplted;
            devTestPhoneAppService.GetProjectsForUserCompleted += PhoneApp_ProjectsForUserCompleted;
            devTestPhoneAppService.GetCountriesForProjectForMonitorUserCompleted += PhoneApp_CountriesForProjectForMonitorUserCompleted;

            //CountriesForProjectForMonitorUserListResult = new List<Country>();
        }



        public string helloWorldResult;

        public string handshakeResult;

        public static string authenticationResult;

        public static string xmlProjectForUserResult;

        public static string xmlCountriesForProjectForMonitorUserResult;

        public static List<ProjectUser> projectForUserListResult { get; set; }

        public int Project_ID;

        public static List<Country> CountriesForProjectForMonitorUserListResult { get; set; }



        //private List<Country> countriesForProjectForMonitorUserListResult;

        //public List<Country> CountriesForProjectForMonitorUserListResult
        //{
        //    get { return countriesForProjectForMonitorUserListResult; }
        //    set
        //    {
        //        countriesForProjectForMonitorUserListResult = value;
        //        OnPropertyChanged("CountriesForProjectForMonitorUserListResult");
        //    }
        //}



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


        private void PhoneApp_CountriesForProjectForMonitorUserCompleted(object sender, GetCountriesForProjectForMonitorUserCompletedEventArgs e)
        {

            try
            {
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
                countriesForProjectForMonitorUserComplete = countriesForProjectForMonitorUserComplete ?? new TaskCompletionSource<bool>();

                XDocument xDocumentCountriesForProjectForMonitorUser = new XDocument();

                //Decode xml(xmlCountryForProjectResult) into a list and assign to countriesForUserListResult model
                if (!string.IsNullOrEmpty(xmlCountriesForProjectForMonitorUserResult))
                {
                    xDocumentCountriesForProjectForMonitorUser = XDocument.Parse(xmlCountriesForProjectForMonitorUserResult);
                }

                if (!string.IsNullOrEmpty(xmlCountriesForProjectForMonitorUserResult) && xDocumentCountriesForProjectForMonitorUser.Root.Elements().Any())
                {



                    //XmlSerializer serializer = new XmlSerializer(typeof(List<Country>));

                    //XmlReader reader = xDocumentCountriesForProjectForMonitorUser.CreateReader();

                    //reader.ReadToDescendant("CountriesForProjectForMonitorUser");

                    //CountriesForProjectForMonitorUserListResult = (List<Country>)serializer.Deserialize(reader);
                    //reader.Close();



                    //-------------------------------------------------------------------------------------------------------------------



                    //List<Country> countyList = new List<Country>();
                    //countriesForProjectForMonitorUserListResult = new List<Country>();
                    Country country = new Country();




                    CountriesForProjectForMonitorUserListResult = (from xe in xDocumentCountriesForProjectForMonitorUser.Root.Elements("CountriesForProjectForMonitorUser")
                                                                   select new Country
                                                                   {
                                                                       ID = Convert.ToInt32(xe.Element("ID").Value),
                                                                       Country_ID = Convert.ToInt32(xe.Element("Country_ID").Value),
                                                                       Description = xe.Element("Description").Value,
                                                                       DisplayTrialCode = xe.Element("DisplayTrialCode").Value,
                                                                       EnglishCountryName = xe.Element("EnglishCountryName").Value,
                                                                       EnglishLanguageName = xe.Element("EnglishLanguageName").Value,
                                                                       TrialCode = xe.Element("TrialCode").Value,
                                                                       TrialDetails = xe.Element("TrialDetails").Value,
                                                                       TrialStatus_ID = Convert.ToInt32(xe.Element("TrialStatus_ID").Value),
                                                                       TrialTitleFull = xe.Element("TrialTitleFull").Value,
                                                                       TrialTitleShort = xe.Element("TrialTitleShort").Value


                                                                   }).Distinct().ToList();



                    //----------------------------------------------------------------------------------------------------


                    //foreach (XElement xe in xDocumentCountriesForProjectForMonitorUser.Descendants("CountriesForProjectForMonitorUser").Distinct())
                    //{

                    //    if (CountriesForProjectForMonitorUserListResult.Contains(xe.))
                    //    //    lines2.Add(str);
                    //    {
                    //        country.ID = Convert.ToInt32(xe.Element("ID").Value);
                    //        country.Country_ID = Convert.ToInt32(xe.Element("Country_ID").Value);
                    //        country.Description = xe.Element("Description").Value;
                    //        country.DisplayTrialCode = xe.Element("DisplayTrialCode").Value;
                    //        country.EnglishCountryName = xe.Element("EnglishCountryName").Value;
                    //        country.EnglishLanguageName = xe.Element("EnglishLanguageName").Value;
                    //        country.TrialCode = xe.Element("TrialCode").Value;
                    //        country.TrialDetails = xe.Element("TrialDetails").Value;
                    //        country.TrialStatus_ID = Convert.ToInt32(xe.Element("TrialStatus_ID").Value);
                    //        country.TrialTitleFull = xe.Element("TrialTitleFull").Value;
                    //        country.TrialTitleShort = xe.Element("TrialTitleShort").Value;

                    //        CountriesForProjectForMonitorUserListResult.Add(country);
                    //    }
                    //}



                    //-----------------------------------------------------------------------------------------------------------------------

                    //countriesForProjectForMonitorUserListResult = xDocumentCountriesForProjectForMonitorUser.Descendants("CountriesForProjectForMonitorUser").Select(d =>
                    //new Country
                    //{
                    //    ID = Convert.ToInt32(d.Element("ID").Value),
                    //    Country_ID = Convert.ToInt32(d.Element("Country_ID").Value),
                    //    Description = d.Element("Description").Value,
                    //    DisplayTrialCode = d.Element("DisplayTrialCode").Value,
                    //    EnglishCountryName = d.Element("EnglishCountryName").Value,
                    //    EnglishLanguageName = d.Element("EnglishLanguageName").Value,
                    //    TrialCode = d.Element("TrialCode").Value,
                    //    TrialDetails = d.Element("TrialDetails").Value,
                    //    TrialStatus_ID = Convert.ToInt32(d.Element("TrialStatus_ID").Value),
                    //    TrialTitleFull = d.Element("TrialTitleFull").Value,
                    //    TrialTitleShort = d.Element("TrialTitleShort").Value
                    //}).ToList();
                }

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




        public async Task<List<Country>> GetCountriesForProjectForMonitorUserListAsync(Portable.Models.ProjectUser projectUser)
        {
            countriesForProjectForMonitorUserComplete = new TaskCompletionSource<bool>();

            if (projectUser != null)
                Project_ID = projectUser.ID;

            devTestPhoneAppService.GetCountriesForProjectForMonitorUserAsync(Project_ID);
            await countriesForProjectForMonitorUserComplete.Task;
            return CountriesForProjectForMonitorUserListResult;
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



                    projectForUserListResult = (from d in xDocumentProjectForUser.Root.Elements("ProjectsForUser")
                                                select new ProjectUser
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


                                                }).Distinct().ToList();




                    //projectForUserListResult = xDocumentProjectForUser.Descendants("ProjectsForUser").Select(d =>
                    //new CliniSafePhoneApp.Portable.Models.ProjectUser
                    //{
                    //    ID = Convert.ToInt32(d.Element("ID").Value),
                    //    Sponsor = d.Element("Sponsor").Value,
                    //    ContractResearchOrganisation = d.Element("ContractResearchOrganisation").Value,
                    //    ProjectCode = d.Element("ProjectCode").Value,
                    //    ProjectTitleShortPhoneDisplay = (d.Element("ProjectTitleShort").Value.Length <= 28) ? d.Element("ProjectTitleShort").Value : d.Element("ProjectTitleShort").Value.Substring(0, 25) + "...",
                    //    ProjectTitleShort = d.Element("ProjectTitleShort").Value,
                    //    ProjectTitleFull = d.Element("ProjectTitleFull").Value,
                    //    DropDownDesc = d.Element("ProjectCode").Value + " - " + d.Element("ProjectTitleShort").Value,
                    //    IRPUserDashboard = d.Element("IRPUserDashboard").Value,
                    //    StudyDashboard = d.Element("StudyDashboard").Value,
                    //    DrugRuleBuilderDashboard = d.Element("DrugRuleBuilderDashboard").Value,
                    //    ExploreDrugsDashboard = d.Element("ExploreDrugsDashboard").Value,
                    //    TeamDashboard = d.Element("TeamDashboard").Value,
                    //    TranslationDashboard = d.Element("TranslationDashboard").Value,
                    //    ReportsDashboard = d.Element("ReportsDashboard").Value,
                    //    EndUserDashboard = d.Element("EndUserDashboard").Value,
                    //    WizardDashboard = d.Element("WizardDashboard").Value,
                    //    InvestigatorDashboard = d.Element("InvestigatorDashboard").Value

                    //}).ToList();
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
                devTestPhoneAppService.HandshakeAsync();
                handshakeResult = e.Result;


                // Check if user is Authenticated then Get the Header Values
                if (handshakeResult == "Hello")
                    GetHandshakeHeader();


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
            if (string.IsNullOrEmpty(authenticationResult))
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


                    devTestPhoneAppService.AuthenticateAsync();
                    authenticationResult = e.Result;
                    authenticateRequestComplete = authenticateRequestComplete ?? new TaskCompletionSource<bool>();

                    // Check if user is Authenticated then Get the Header Values
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

        private void PhoneApp_EchoComplted(object sender, EchoCompletedEventArgs e)
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
            DevTestPhoneAppService.HandshakeHeader handshakeHeader1 = new DevTestPhoneAppService.HandshakeHeader() { CPAVersion = handShakeHeader.CPAVersion };
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
            DevTestPhoneAppService.AuthHeader authHeader1 = new DevTestPhoneAppService.AuthHeader()
            {
                Username = authHeader.Username,
                Password = authHeader.Password,
                CPAVersion = authHeader.CPAVersion
            };

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


        public Portable.Models.HandshakeHeader Get()
        {
            handshakeHeaderResults = FromPhoneAppSoapServiceHandshake(devTestPhoneAppService.HandshakeHeaderValue);
            return handshakeHeaderResults;
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

            //Navigate to Error Page
            await RootPage.NavigateFromMenu((int)MenuItemType.Error, null, null, strDisplayMessage);
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

            // await App.Current.MainPage.DisplayAlert("Error", strDisplayMessage, "Cancel");

            //Navigate to Error Page
            await RootPage.NavigateFromMenu((int)MenuItemType.Error, null, null, strDisplayMessage);
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