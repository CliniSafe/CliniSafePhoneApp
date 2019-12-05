using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToProjectDetailCommand : ICommand, INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a public property for ProjectsViewModel
        /// </summary>
        public ProjectsViewModel ProjectsViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="projectsViewModel"></param>
        public NavigateToProjectDetailCommand(ProjectsViewModel projectsViewModel)
        {
            ProjectsViewModel = projectsViewModel;
        }


        private ProjectUser selectedProjectUser;

        public ProjectUser SelectedProjectUser
        {
            get { return selectedProjectUser; }
            set
            {
                selectedProjectUser = value;
                OnPropertyChanged("SelectedProjectUser");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Navigate To Project Detail Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            var projectUser = (ProjectUser)parameter;

            if (projectUser == null)
                return false;

            if (string.IsNullOrEmpty(projectUser.ProjectCode) || string.IsNullOrEmpty(projectUser.ProjectTitleShortPhoneDisplay))
                return false;

            return true;
        }

        /// <summary>
        /// Execute Navigate To Project Detail Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var projectUser = (ProjectUser)parameter;
            ProjectsViewModel.NavigateToProjectDetails(projectUser);
        }
    }
}

