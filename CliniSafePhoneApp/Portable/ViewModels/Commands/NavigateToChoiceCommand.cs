using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToChoiceCommand : ICommand
    {


        public ProjectDetailsViewModel _projectDetailsViewModel { get; set; }

        public NavigateToChoiceCommand(ProjectDetailsViewModel projectDetailsViewModel)
        {
            _projectDetailsViewModel = projectDetailsViewModel;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            //var projectUser = (ProjectUser)parameter;

            //if (projectUser == null)
            //    return false;

            //if (string.IsNullOrEmpty(projectUser.ProjectCode) || string.IsNullOrEmpty(projectUser.ProjectTitleShortPhoneDisplay))
            //    return false;

            return true;
        }

        public void Execute(object parameter)
        {
            var projectUser = (ProjectUser)parameter;
            _projectDetailsViewModel.NavigateToMonitorORResearchSiteORChoice(projectUser);
        }
    }
}

