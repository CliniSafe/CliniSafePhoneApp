using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToLogOutCommand : ICommand
    {
        public TermsViewModel TermsViewModel { get; set; }

        public NavigateToLogOutCommand(TermsViewModel termsViewModel)
        {
            TermsViewModel = termsViewModel;
        }

        public ProjectsViewModel ProjectsViewModel { get; set; }

        public NavigateToLogOutCommand(ProjectsViewModel projectsViewModel)
        {
            ProjectsViewModel = projectsViewModel;
        }



        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (TermsViewModel != null)
                TermsViewModel.NavigateToLogOut();

            if (ProjectsViewModel != null)
                ProjectsViewModel.NavigateToLogOut();

        }
    }
}
