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


        public ProjectsViewModel _projectsViewModel { get; set; }

        public NavigateToProjectDetailCommand(ProjectsViewModel projectsViewModel)
        {
            _projectsViewModel = projectsViewModel;
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


        public bool CanExecute(object parameter)
        {
            var projectUser = (ProjectUser)parameter;

            if (projectUser == null)
                return false;

            if (string.IsNullOrEmpty(projectUser.ProjectCode) || string.IsNullOrEmpty(projectUser.ProjectTitleShortPhoneDisplay))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            var projectUser = (ProjectUser)parameter;
            _projectsViewModel.NavigateToProjectDetails(projectUser);
        }
    }
}

