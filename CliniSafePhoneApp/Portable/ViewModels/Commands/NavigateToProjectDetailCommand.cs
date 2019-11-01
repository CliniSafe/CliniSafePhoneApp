using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToProjectDetailCommand : ICommand
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        public ProjectsViewModel _projectsViewModel { get; set; }

        public NavigateToProjectDetailCommand(ProjectsViewModel projectsViewModel)
        {
            _projectsViewModel = projectsViewModel;
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

