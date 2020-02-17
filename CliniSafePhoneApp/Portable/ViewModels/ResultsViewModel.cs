using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.ComponentModel;
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
        public ResultsViewModel(string projectCode)
        {
            NavigateToProjectCommand = new NavigateToProjectCommand(this);
            NavigateToMainCommand = new NavigateToMainCommand(this);
            this.ProjectCode = projectCode;
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
