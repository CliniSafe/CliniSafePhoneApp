using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToChoiceCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for ProjectDetailsViewModel
        /// </summary>
        public ProjectDetailsViewModel ProjectDetailsViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="projectDetailsViewModel"></param>
        public NavigateToChoiceCommand(ProjectDetailsViewModel projectDetailsViewModel)
        {
            ProjectDetailsViewModel = projectDetailsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Navigate To Choice Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Navigate To Choice Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var projectUser = (ProjectUser)parameter;
            ProjectDetailsViewModel.NavigateToMonitorORResearchSiteORChoice(projectUser);
        }
    }
}

