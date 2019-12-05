using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToLogOutCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for TermsViewModel
        /// </summary>
        public TermsViewModel TermsViewModel { get; set; }

        /// <summary>
        /// Declare a public property for ProjectsViewModel
        /// </summary>
        public ProjectsViewModel ProjectsViewModel { get; set; }

        /// <summary>
        /// Initialise TermsViewModel properties in constructor.
        /// </summary>
        public NavigateToLogOutCommand(TermsViewModel termsViewModel)
        {
            TermsViewModel = termsViewModel;
        }

        /// <summary>
        /// Initialise ProjectsViewModel properties in constructor.
        /// </summary>
        /// <param name="projectsViewModel"></param>
        public NavigateToLogOutCommand(ProjectsViewModel projectsViewModel)
        {
            ProjectsViewModel = projectsViewModel;
        }

        /// <summary>
        /// Enable Navigate To Log Out Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Execute Navigate To Log Out Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (TermsViewModel != null)
                TermsViewModel.NavigateToLogOut();

            if (ProjectsViewModel != null)
                ProjectsViewModel.NavigateToLogOut();

        }
    }
}
