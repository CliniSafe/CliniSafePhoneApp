using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToPreviousPageCommand : ICommand
    {
        public AboutViewModel AboutViewModel { get; set; }

        public NavigateToPreviousPageCommand(AboutViewModel aboutViewModel)
        {
            AboutViewModel = aboutViewModel;
        }


        public ErrorViewModel ErrorViewModel { get; set; }

        public NavigateToPreviousPageCommand(ErrorViewModel errorViewModel)
        {
            ErrorViewModel = errorViewModel;
        }

        public HelpViewModel HelpViewModel { get; set; }

        public NavigateToPreviousPageCommand(HelpViewModel helpViewModel)
        {
            HelpViewModel = helpViewModel;
        }


        public PrivacyViewModel PrivacyViewModel { get; set; }

        public NavigateToPreviousPageCommand(PrivacyViewModel privacyViewModel)
        {
            PrivacyViewModel = privacyViewModel;
        }

        public TempTestViewModel TempTestViewModel { get; set; }

        public NavigateToPreviousPageCommand(TempTestViewModel tempTestViewModel)
        {
            TempTestViewModel = tempTestViewModel;
        }

        public TermsViewModel TermsViewModel { get; set; }

        public NavigateToPreviousPageCommand(TermsViewModel termsViewModel)
        {
            TermsViewModel = termsViewModel;
        }

        public CountryViewModel CountryViewModel { get; set; }

        public NavigateToPreviousPageCommand(CountryViewModel countryViewModel)
        {
            CountryViewModel = countryViewModel;
        }


        public ChoiceViewModel ChoiceViewModel { get; set; }

        public NavigateToPreviousPageCommand(ChoiceViewModel choiceViewModel)
        {
            ChoiceViewModel = choiceViewModel;
        }


        public ProjectDetailsViewModel ProjectDetailsViewModel { get; set; }

        public NavigateToPreviousPageCommand(ProjectDetailsViewModel projectDetailsViewModel)
        {
            ProjectDetailsViewModel = projectDetailsViewModel;
        }


        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (AboutViewModel != null)
                AboutViewModel.NavigateBackToPreviousPage();

            if (ErrorViewModel != null)
                ErrorViewModel.NavigateForwardToLogin();

            if (HelpViewModel != null)
                HelpViewModel.NavigateBackToPreviousPage();

            if (PrivacyViewModel != null)
                PrivacyViewModel.NavigateBackToPreviousPage();

            if (TempTestViewModel != null)
                TempTestViewModel.NavigateBackToPreviousPage();

            if (TermsViewModel != null)
                TermsViewModel.NavigateBackToPreviousPage();

            if (CountryViewModel != null)
                CountryViewModel.NavigateBackToPreviousPage();

            if (ChoiceViewModel != null)
                ChoiceViewModel.NavigateBackToPreviousPage();

            if (ProjectDetailsViewModel != null)
                ProjectDetailsViewModel.NavigateBackToPreviousPage();
        }
    }
}
