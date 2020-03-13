using CliniSafePhoneApp.iOS.DevTestPhoneAppService;
using CliniSafePhoneApp.Portable;
using CliniSafePhoneApp.Portable.Data;
using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.Views;
using System;
using System.Collections.Generic;
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
    public class PhoneAppSoapService : ISoapService
    {
        public MainPage RootPage { get => App.Current.MainPage as MainPage; }

        private readonly PhoneApp devTestPhoneAppService;
        TaskCompletionSource<bool> helloWorldRequestComplete = null;
        TaskCompletionSource<bool> handshakeRequestComplete = null;
        TaskCompletionSource<bool> authenticateRequestComplete = null;
        TaskCompletionSource<bool> helloErrorRequestComplete = null;
        TaskCompletionSource<bool> echoRequestComplete = null;
        TaskCompletionSource<bool> projectsForUserComplete = null;
        TaskCompletionSource<bool> countriesForProjectForMonitorUserComplete = null;
        TaskCompletionSource<bool> researchSitesForProjectForInvestigtorUserComplete = null;
        TaskCompletionSource<bool> findGenericDrugNameComplete = null;
        TaskCompletionSource<bool> questionsComplete = null;
        TaskCompletionSource<bool> validateDrugsComplete = null;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public PhoneAppSoapService()
        {
            //devTestPhoneAppService = new PhoneApp() { Url = Constants.GAMPTestUrl };

            devTestPhoneAppService = new PhoneApp() { Url = Constants.GAMPTestUrl };

            devTestPhoneAppService.HelloWorldCompleted += PhoneApp_HelloWorldCompleted;
            devTestPhoneAppService.HandshakeCompleted += PhoneApp_HandshakeCompleted;
            devTestPhoneAppService.AuthenticateCompleted += PhoneApp_AuthenticateCompleted;
            devTestPhoneAppService.HelloErrorCompleted += PhoneApp_HelloErrorCompleted;
            devTestPhoneAppService.EchoCompleted += PhonaApp_EchoComplted;
            devTestPhoneAppService.GetProjectsForUserCompleted += PhoneApp_ProjectsForUserCompleted;
            devTestPhoneAppService.GetCountriesForProjectForMonitorUserCompleted += PhoneApp_CountriesForProjectForMonitorUserCompleted;
            devTestPhoneAppService.GetResearchSitesForProjectForInvestigtorUserCompleted += PhoneApp_ResearchSitesForProjectForInvestigtorUserCompleted;
            devTestPhoneAppService.FindGenericDrugNameCompleted += PhoneApp_FindGenericDrugNameCompleted;
            devTestPhoneAppService.GetQuestionsCompleted += PhoneApp_QuestionsCompleted;
            devTestPhoneAppService.ValidateDrugsCompleted += PhoneApp_ValidateDrugsCompleted;
        }

        public string helloWorldResult;

        public string handshakeResult;

        public string echoResult;

        public static string authenticationResult;

        public static string ProjectForUserResult;

        public static int Project_ID;

        public int Trial_ID;

        public DevTestPhoneAppService.ValidateDrugsInputs ValidateDrugsInputValue;

        public string GenericDrugNameToFind;

        public static string xmlProjectForUserResult;

        public static string xmlCountriesForProjectForMonitorUserResult;

        public static string xmlResearchSitesForProjectForInvestigatorUserResult;

        public static string xmlGenericDrugsFoundResult;

        public static string xmlQuestionSelectedDrugsResult;

        public static ValidateDrugsOutputs xmlValidateDrugsOutputsResult;

        public static List<ProjectUser> ProjectForUserListResult { get; set; }

        public static List<CountriesForProjectForMonitorUser> CountriesForProjectForMonitorUserListResult { get; set; }

        public static List<ResearchSitesForProjectForInvestigatorUser> ResearchSitesForProjectForInvestigatorUserListResult { get; set; }

        public static List<GenericDrugsFound> GenericDrugsFoundListResult { get; set; }

        public static List<QuestionSelectedDrug> QuestionSelectedDrugListResult { get; set; }



        public static ValidateDrugsOutput ValidateDrugsOutputResult { get; set; }

        /// <summary>
        /// Declare private member for assigning Soap Header results returned from Web Service.
        /// </summary>
        private Portable.Models.AuthHeader authHeaderResults = new Portable.Models.AuthHeader();

        /// <summary>
        /// Declare private member for assigning Soap Header results returned from Web Service.
        /// </summary>
        private Portable.Models.HandshakeHeader handshakeHeaderResults = new Portable.Models.HandshakeHeader();


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
        /// Returns Projects List.
        /// </summary>
        /// <param name="authHeader"></param>
        /// <returns></returns>
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
            return ProjectForUserListResult;
        }

        /// <summary>
        /// Private Projects Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    ProjectForUserListResult = (from d in xDocumentProjectForUser.Root.Elements("ProjectsForUser")
                                                select new ProjectUser
                                                {
                                                    ID = d.Element("ID").Value != null ? Convert.ToInt32(d.Element("ID").Value) : 0,
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

        /// <summary>
        /// Returns Countries For Projects For Monitor List.
        /// </summary>
        /// <param name="projectUser"></param>
        /// <returns></returns>
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
        /// Private Countries Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Returns Research Site For Projects For Investigator List.
        /// </summary>
        /// <param name="projectUser"></param>
        /// <returns></returns>
        public async Task<List<ResearchSitesForProjectForInvestigatorUser>> GetResearchSitesForProjectForInvestigtorUserListAsync(ProjectUser projectUser)
        {
            researchSitesForProjectForInvestigtorUserComplete = new TaskCompletionSource<bool>();

            if (projectUser != null)
                Project_ID = projectUser.ID;

            devTestPhoneAppService.GetResearchSitesForProjectForInvestigtorUserAsync(Project_ID);
            await researchSitesForProjectForInvestigtorUserComplete.Task;
            return ResearchSitesForProjectForInvestigatorUserListResult;
        }

        /// <summary>
        /// Private ResearchSite Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneApp_ResearchSitesForProjectForInvestigtorUserCompleted(object sender, GetResearchSitesForProjectForInvestigtorUserCompletedEventArgs e)
        {
            try
            {
                researchSitesForProjectForInvestigtorUserComplete = researchSitesForProjectForInvestigtorUserComplete ?? new TaskCompletionSource<bool>();

                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        researchSitesForProjectForInvestigtorUserComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        researchSitesForProjectForInvestigtorUserComplete?.TrySetException(e.Error);
                    else
                        researchSitesForProjectForInvestigtorUserComplete?.TrySetException(e.Error);

                devTestPhoneAppService.GetResearchSitesForProjectForInvestigtorUserAsync(Project_ID);
                xmlResearchSitesForProjectForInvestigatorUserResult = e.Result;

                // Decode xml(xmlResearchSitesForProjectForInvestigatorUserResult) into a list and assign to ResearchSitesForProjectForInvestigatorUser model
                StringReader stringReader = new StringReader(xmlResearchSitesForProjectForInvestigatorUserResult);

                XmlSerializer serializer = new XmlSerializer(typeof(List<ResearchSitesForProjectForInvestigatorUser>), new XmlRootAttribute("NewDataSet"));

                ResearchSitesForProjectForInvestigatorUserListResult = (List<ResearchSitesForProjectForInvestigatorUser>)serializer.Deserialize(stringReader);

                researchSitesForProjectForInvestigtorUserComplete?.TrySetResult(true);
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
        /// Returns Found Generic Drug Name List.
        /// </summary>
        /// <param name="trialID"></param>
        /// <param name="genericDrugNameToFind"></param>
        /// <returns></returns>
        public async Task<List<GenericDrugsFound>> FindGenericDrugNameListAsync(int trialID, string genericDrugNameToFind)
        {
            findGenericDrugNameComplete = new TaskCompletionSource<bool>();

            if (trialID != 0 && !string.IsNullOrEmpty(genericDrugNameToFind))
            {
                Trial_ID = trialID;
                GenericDrugNameToFind = genericDrugNameToFind;
            }

            devTestPhoneAppService.FindGenericDrugNameAsync(Trial_ID, GenericDrugNameToFind);
            await findGenericDrugNameComplete.Task;
            return GenericDrugsFoundListResult;
        }

        /// <summary>
        /// Private Find Generic Drugs Name Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneApp_FindGenericDrugNameCompleted(object sender, FindGenericDrugNameCompletedEventArgs e)
        {
            try
            {
                findGenericDrugNameComplete = findGenericDrugNameComplete ?? new TaskCompletionSource<bool>();

                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        findGenericDrugNameComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        findGenericDrugNameComplete?.TrySetException(e.Error);
                    else
                        findGenericDrugNameComplete?.TrySetException(e.Error);

                devTestPhoneAppService.FindGenericDrugName(Trial_ID, GenericDrugNameToFind);
                xmlGenericDrugsFoundResult = e.Result;

                // Decode xml(xmlGenericDrugsFoundResult) into a list and assign to GenericDrugsFound model
                StringReader stringReader = new StringReader(xmlGenericDrugsFoundResult);

                XmlSerializer serializer = new XmlSerializer(typeof(List<GenericDrugsFound>), new XmlRootAttribute("NewDataSet"));

                GenericDrugsFoundListResult = (List<GenericDrugsFound>)serializer.Deserialize(stringReader);

                findGenericDrugNameComplete?.TrySetResult(true);
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


        public async Task<List<QuestionSelectedDrug>> GetQuestionSelectedDrugsListAsync(int trialID)
        {
            questionsComplete = new TaskCompletionSource<bool>();

            if (trialID != 0)
            {
                Trial_ID = trialID;
            }

            devTestPhoneAppService.GetQuestionsAsync(Trial_ID);
            await questionsComplete.Task;
            return QuestionSelectedDrugListResult;
        }

        /// <summary>
        /// Private Questions Name Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneApp_QuestionsCompleted(object sender, GetQuestionsCompletedEventArgs e)
        {
            try
            {
                questionsComplete = questionsComplete ?? new TaskCompletionSource<bool>();

                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        questionsComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        questionsComplete?.TrySetException(e.Error);
                    else
                        questionsComplete?.TrySetException(e.Error);

                devTestPhoneAppService.GetQuestions(Trial_ID);
                xmlQuestionSelectedDrugsResult = e.Result;

                XDocument xDocumentQuestionSelectedDrug = new XDocument();

                //Decode xml(xmlQuestionSelectedDrugsResult) into a list and assign to QuestionSelectedDrug model
                if (!string.IsNullOrEmpty(xmlQuestionSelectedDrugsResult))
                {
                    xDocumentQuestionSelectedDrug = XDocument.Parse(xmlQuestionSelectedDrugsResult);
                }

                if (!string.IsNullOrEmpty(xmlProjectForUserResult) && xDocumentQuestionSelectedDrug.Root.Elements().Any())
                {

                    QuestionSelectedDrugListResult = (from d in xDocumentQuestionSelectedDrug.Root.Elements("Questions")
                                                      select new QuestionSelectedDrug
                                                      {
                                                          Question_ID = d.Element("Question_ID").Value != null ? Convert.ToInt32(d.Element("Question_ID").Value) : 0,
                                                          Question = d.Element("Question").Value
                                                      }).ToList();

                }

                questionsComplete?.TrySetResult(true);
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



        public async Task<ValidateDrugsOutput> ValidateDrugsListAsync(Portable.Models.ValidateDrugsInput validateDrugsInput)
        {
            validateDrugsComplete = new TaskCompletionSource<bool>();

            if (validateDrugsInput != null)
            {
                ValidateDrugsInputValue = new DevTestPhoneAppService.ValidateDrugsInputs()
                {
                    Project_ID = validateDrugsInput.Project_ID,
                    PatientID = validateDrugsInput.Patient_ID,
                    ResearchSiteID = validateDrugsInput.ResearchSite_ID,
                    theTrialID = validateDrugsInput.Trial_ID,
                    DrugNames = validateDrugsInput.DrugName,
                    QuestionsAndAnswers = validateDrugsInput.QuestionsAndAnswers
                };
            }

            devTestPhoneAppService.ValidateDrugsAsync(ValidateDrugsInputValue);
            await validateDrugsComplete.Task;
            return ValidateDrugsOutputResult;
        }

        private void PhoneApp_ValidateDrugsCompleted(object sender, ValidateDrugsCompletedEventArgs e)
        {
            try
            {
                validateDrugsComplete = validateDrugsComplete ?? new TaskCompletionSource<bool>();

                // Check and Set Specified Exceptions
                if (e.Error != null)
                    if (e.Error is WebException)
                        validateDrugsComplete?.TrySetException(e.Error);
                    else if (e.Error is SoapException)
                        validateDrugsComplete?.TrySetException(e.Error);
                    else
                        validateDrugsComplete?.TrySetException(e.Error);

                devTestPhoneAppService.ValidateDrugsAsync(ValidateDrugsInputValue);
                xmlValidateDrugsOutputsResult = e.Result;

                ValidateDrugsOutputResult = new ValidateDrugsOutput()
                {
                    HTMLResult = xmlValidateDrugsOutputsResult.HTMLResult,
                    XMLResult = xmlValidateDrugsOutputsResult.XMLResult,
                    XMLDrugRuleMessage = xmlValidateDrugsOutputsResult.XMLDrugRuleMessages
                };

                validateDrugsComplete?.TrySetResult(true);
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
        /// Private Hello World Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Private Handshake Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Private Authenticate Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Private Echo Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Displays the Exception on the Error Page.
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
        }

        /// <summary>
        /// Displays the Web Exception on the Error Page.
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
        }

        /// <summary>
        /// Displays the SOAP Exception on the Error Page.
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