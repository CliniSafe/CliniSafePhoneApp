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
                QuestionsAndAnswers = ConvertQuestionAndAnswerToXML(reviewQuestionSelectedDrugsList),
                DrugName = ConvertDrugnNameToXML(reviewSelectedDrugsList),
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
                QuestionsAndAnswers = ConvertQuestionAndAnswerToXML(reviewQuestionSelectedDrugsList),
                DrugName = ConvertDrugnNameToXML(reviewSelectedDrugsList),
                Patient_ID = 0
            };

            if (ValidateDrugsInput != null)
                _ = ValidateDrugsAsync(validateDrugsInput);
        }


        /// <summary>
        /// Converts QuestionAndAnswer to XML String.
        /// </summary>
        /// <param name="questionSelectedDrugsList"></param>
        /// <returns></returns>
        private string ConvertQuestionAndAnswerToXML(List<QuestionSelectedDrug> questionSelectedDrugsList)
        {
            string xmlQuestionSelectedDrug = string.Empty;
            DataSet questionAndAnswerDataSet = new DataSet();
            DataTable questionAndAnswerDataTable = new DataTable { TableName = "QuestionsAndAnswers" };

            DataColumn colQuestion_ID = new DataColumn("Question_ID", typeof(Int32)) { Caption = "Name" };
            questionAndAnswerDataTable.Columns.Add(colQuestion_ID);

            DataColumn colQuestion = new DataColumn("Question", typeof(string)) { Caption = "Name" };
            questionAndAnswerDataTable.Columns.Add(colQuestion);

            DataColumn colAnswer = new DataColumn("Answer", typeof(bool)) { Caption = "Name" };
            questionAndAnswerDataTable.Columns.Add(colAnswer);


            //go through each property on QuestionSelectedDrug and add each value to the table
            foreach (QuestionSelectedDrug item in questionSelectedDrugsList)
            {
                questionAndAnswerDataTable.Columns["Question_ID"].DefaultValue = item.Question_ID;
                questionAndAnswerDataTable.Columns["Question"].DefaultValue = item.Question;
                questionAndAnswerDataTable.Columns["Answer"].DefaultValue = item.Yes != null ? item.Yes : item.No;
            }

            questionAndAnswerDataSet.Tables.Add(questionAndAnswerDataTable);
            System.IO.StringWriter questionAndAnswerWriter = new System.IO.StringWriter();
            questionAndAnswerDataTable.WriteXml(questionAndAnswerWriter, XmlWriteMode.WriteSchema, false);
            xmlQuestionSelectedDrug = questionAndAnswerWriter.ToString();

            return xmlQuestionSelectedDrug;
        }


        /// <summary>
        /// Converts DrugName to XML String.
        /// </summary>
        /// <param name="selectedDrugsFoundList"></param>
        /// <returns></returns>
        private string ConvertDrugnNameToXML(List<GenericDrugsFound> selectedDrugsFoundList)
        {
            string xmlGenericeDrugsFound = string.Empty;
            DataSet drugNameDataSet = new DataSet();
            DataTable drugNameDataTable = new DataTable { TableName = "DrugNames" };

            DataColumn colDrug_ID = new DataColumn("Drug_ID", typeof(Int32)) { Caption = "Name" };
            drugNameDataTable.Columns.Add(colDrug_ID);

            DataColumn colDrugName = new DataColumn("DrugName", typeof(string)) { Caption = "Name" };
            drugNameDataTable.Columns.Add(colDrugName);

            DataColumn colExists = new DataColumn("Exists", typeof(string)) { Caption = "Name" };
            drugNameDataTable.Columns.Add(colExists);

            //go through each property on GenericDrugsFound and add each value to the table
            foreach (GenericDrugsFound item in selectedDrugsFoundList)
            {
                drugNameDataTable.Columns["Drug_ID"].DefaultValue = item.Drug_ID;
                drugNameDataTable.Columns["DrugName"].DefaultValue = item.DrugName;
                drugNameDataTable.Columns["Exists"].DefaultValue = item.Select;
            }

            drugNameDataSet.Tables.Add(drugNameDataTable);

            System.IO.StringWriter drugNameWriter = new System.IO.StringWriter();
            drugNameDataTable.WriteXml(drugNameWriter, XmlWriteMode.WriteSchema, false);
            xmlGenericeDrugsFound = drugNameWriter.ToString();
            return xmlGenericeDrugsFound;
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
