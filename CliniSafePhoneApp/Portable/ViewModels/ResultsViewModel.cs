using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ResultsViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public NavigateToProjectCommand NavigateToProjectCommand { get; set; }

        public NavigateToMainCommand NavigateToMainCommand { get; set; }


        private string projectCode;

        public string ProjectCode
        {
            get { return projectCode; }
            set
            {
                projectCode = value;
                OnPropertyChanged("ProjectCode");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="countriesForProjectForMonitorUser"></param>
        /// <param name="projectUser"></param>
        /// <param name="reviewQuestionSelectedDrugsList"></param>
        /// <param name="reviewSelectedDrugsList"></param>
        public ResultsViewModel(CountriesForProjectForMonitorUser countriesForProjectForMonitorUser, ProjectUser projectUser, List<QuestionSelectedDrug> reviewQuestionSelectedDrugsList, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            NavigateToProjectCommand = new NavigateToProjectCommand(this);
            NavigateToMainCommand = new NavigateToMainCommand(this);
            this.ProjectCode = projectUser.ProjectCode;
            CountriesForProjectForMonitorUser = countriesForProjectForMonitorUser;

            ValidateDrugsInput = new ValidateDrugsInput()
            {
                Project_ID = projectUser.ID,
                Trial_ID = countriesForProjectForMonitorUser.ID,
                ResearchSite_ID = 0,
                QuestionsAndAnswers = ToXMLString(ConvertToQnAWebServiceList(reviewQuestionSelectedDrugsList), "QuestionsAndAnswers"),  //ConvertQuestionAndAnswerToXML(reviewQuestionSelectedDrugsList),
                DrugName = ToXMLString(reviewSelectedDrugsList, "DrugNames"),                                                           //ConvertDrugnNameToXML(reviewSelectedDrugsList),
                Patient_ID = 0
            };

            if (ValidateDrugsInput != null)
                _ = ValidateDrugsAsync(validateDrugsInput);
        }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="researchSitesForProjectForInvestigatorUser"></param>
        /// <param name="projectUser"></param>
        /// <param name="reviewQuestionSelectedDrugsList"></param>
        /// <param name="reviewSelectedDrugsList"></param>
        public ResultsViewModel(ResearchSitesForProjectForInvestigatorUser researchSitesForProjectForInvestigatorUser, ProjectUser projectUser, List<QuestionSelectedDrug> reviewQuestionSelectedDrugsList, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            NavigateToProjectCommand = new NavigateToProjectCommand(this);
            NavigateToMainCommand = new NavigateToMainCommand(this);
            this.ProjectCode = projectUser.ProjectCode;
            ResearchSitesForProjectForInvestigatorUser = researchSitesForProjectForInvestigatorUser;

            ValidateDrugsInput = new ValidateDrugsInput()
            {
                Project_ID = projectUser.ID,
                Trial_ID = researchSitesForProjectForInvestigatorUser.Trial_ID,
                ResearchSite_ID = researchSitesForProjectForInvestigatorUser.ID,
                QuestionsAndAnswers = ToXMLString(ConvertToQnAWebServiceList(reviewQuestionSelectedDrugsList), "QuestionsAndAnswers"),      //ConvertQuestionAndAnswerToXML(reviewQuestionSelectedDrugsList),
                DrugName = ToXMLString(reviewSelectedDrugsList, "DrugNames"),                                                              //ConvertDrugnNameToXML(reviewSelectedDrugsList),
                Patient_ID = 0
            };

            if (ValidateDrugsInput != null)
                _ = ValidateDrugsAsync(validateDrugsInput);
        }



        private List<QnAWebService> ConvertToQnAWebServiceList(List<QuestionSelectedDrug> list)
        {
            List<QnAWebService> qnQWebServiceList = new List<QnAWebService>();

            foreach (QuestionSelectedDrug item in list)
            {
                QnAWebService qnQWebService = new QnAWebService
                {
                    Question_ID = item.Question_ID,
                    Question = item.Question,
                    Answer = item.Yes != null ? Convert.ToBoolean(item.Yes) : Convert.ToBoolean(item.No)
                };
                qnQWebServiceList.Add(qnQWebService);
            }

            return qnQWebServiceList;
        }



        //private List<X> ConvertToWebService(List<Y> list)
        //{
        //    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
        //    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(X));

        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptor prop = props[i];
        //        table.Columns.Add(prop.Name, prop.PropertyType);
        //    }
        //    object[] values = new object[props.Count];
        //    foreach (Y item in list)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item);
        //        }
        //        table.Rows.Add(values);
        //    }
        //}





        public static string ToXMLString<T>(List<T> genericList, string tableName)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable { TableName = tableName };

            string xmlString = string.Empty;
            DataSet dataSet = new DataSet("CliniSafePhoneApp_WebService");


            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in genericList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            dataSet.Tables.Add(table);
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            table.WriteXml(stringWriter, XmlWriteMode.WriteSchema, true);
            xmlString = stringWriter.ToString();
            return xmlString;
        }


        private CountriesForProjectForMonitorUser _countriesForProjectForMonitorUser;

        public CountriesForProjectForMonitorUser CountriesForProjectForMonitorUser
        {
            get { return _countriesForProjectForMonitorUser; }
            set
            {
                _countriesForProjectForMonitorUser = value;
                OnPropertyChanged("CountriesForProjectForMonitorUser");
            }
        }

        private ResearchSitesForProjectForInvestigatorUser _researchSitesForProjectForInvestigatorUser;

        public ResearchSitesForProjectForInvestigatorUser ResearchSitesForProjectForInvestigatorUser
        {
            get { return _researchSitesForProjectForInvestigatorUser; }
            set
            {
                _researchSitesForProjectForInvestigatorUser = value;
                OnPropertyChanged("ResearchSitesForProjectForInvestigatorUser");
            }
        }

        private ValidateDrugsInput validateDrugsInput;

        public ValidateDrugsInput ValidateDrugsInput
        {
            get { return validateDrugsInput; }
            set
            {
                validateDrugsInput = value;
                OnPropertyChanged("ValidateDrugsInput");
            }
        }

        private ValidateDrugsOutput validateDrugsOutput;

        public ValidateDrugsOutput ValidateDrugsOutput
        {
            get { return validateDrugsOutput; }
            set
            {
                validateDrugsOutput = value;
                OnPropertyChanged("ValidateDrugsOutput");
            }
        }


        public async Task ValidateDrugsAsync(ValidateDrugsInput validateDrugsInput)
        {
            ValidateDrugsOutput = await ValidateDrugsInput.ValidateDrugsListAsync(validateDrugsInput);
        }


        /// <summary>
        /// Navigate to the Project Page
        /// </summary>
        public void NavigateToProject()
        {
            // Remove Page Enum from the MenuPages List
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Project))
                RootPage.MenuPages.Remove((int)MenuItemType.Project);

            // Navigate to the Project page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, "", "", null);
        }

        /// <summary>
        /// Navigate to the Main Page
        /// </summary>
        public void NavigateToMainPage()
        {
            // Navigate to the Main page
            Application.Current.MainPage = new MainPage();
        }
    }
}
