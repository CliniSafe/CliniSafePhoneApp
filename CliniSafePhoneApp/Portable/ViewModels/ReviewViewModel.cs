using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ReviewViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        /// <summary>
        /// Declare a private member for NavigateToResultsCommand.
        /// </summary>
        public NavigateToResultsCommand NavigateToResultsCommand { get; set; }

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

        private string genericDrugNameToFind;

        public string GenericDrugNameToFind
        {
            get { return genericDrugNameToFind; }
            set
            {
                genericDrugNameToFind = value;
                OnPropertyChanged("GenericDrugNameToFind");
            }
        }

        private List<GenericDrugsFound> genericDrugsFoundList;

        public List<GenericDrugsFound> GenericDrugsFoundList
        {
            get { return genericDrugsFoundList; }
            set
            {
                genericDrugsFoundList = value;
                OnPropertyChanged("GenericDrugsFoundList");
            }
        }


        private List<GenericDrugsFound> reviewSelectedDrugsList;

        public List<GenericDrugsFound> ReviewSelectedDrugsList
        {
            get { return reviewSelectedDrugsList; }
            set
            {
                reviewSelectedDrugsList = value;
                OnPropertyChanged("ReviewSelectedDrugsList");
            }
        }

        private List<QuestionSelectedDrug> reviewAnsweredQuestionList;

        public List<QuestionSelectedDrug> ReviewAnsweredQuestionList
        {
            get { return reviewAnsweredQuestionList; }
            set
            {
                reviewAnsweredQuestionList = value;
                OnPropertyChanged("ReviewAnsweredQuestionList");
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
        /// <param name="reviewAnsweredQuestionList"></param>
        /// <param name="projectCode"></param>
        /// <param name="reviewSelectedDrugsList"></param>
        public ReviewViewModel(List<QuestionSelectedDrug> reviewAnsweredQuestionList, string projectCode, List<GenericDrugsFound> reviewSelectedDrugsList)
        {
            NavigateToResultsCommand = new NavigateToResultsCommand(this);
            this.ReviewSelectedDrugsList = reviewSelectedDrugsList;
            this.ReviewAnsweredQuestionList = reviewAnsweredQuestionList;
            this.ProjectCode = projectCode;
        }


        /// <summary>
        /// Navigate to the Results page
        /// </summary>
        /// <param name="projectUser"></param>
        public async Task NavigateToResults()
        {
            await RootPage.NavigateFromMenu((int)MenuItemType.Results, null, null, null, projectCode);
        }

        /// <summary>
        /// Returns the user to the Project Page.
        /// </summary>
        public void NavigateBackToPreviousPage()
        {
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.Project))
                RootPage.MenuPages.Remove((int)MenuItemType.Project);

            // Navigate to the Project page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, "", "", null);
        }
    }
}
