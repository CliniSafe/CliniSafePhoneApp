using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToPreviousPageCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for AboutViewModel
        /// </summary>
        public AboutViewModel AboutViewModel { get; set; }

        /// <summary>
        /// Declare a public property for ErrorViewModel
        /// </summary>
        public ErrorViewModel ErrorViewModel { get; set; }

        /// <summary>
        /// Declare a public property for HelpViewModel
        /// </summary>
        public HelpViewModel HelpViewModel { get; set; }

        /// <summary>
        /// Declare a public property for PrivacyViewModel
        /// </summary>
        public PrivacyViewModel PrivacyViewModel { get; set; }

        /// <summary>
        /// Declare a public property for TempTestViewModel
        /// </summary>
        public TempTestViewModel TempTestViewModel { get; set; }

        /// <summary>
        /// Declare a public property for TermsViewModel
        /// </summary>
        public TermsViewModel TermsViewModel { get; set; }

        /// <summary>
        /// Declare a public property for CountryViewModel
        /// </summary>
        public CountryViewModel CountryViewModel { get; set; }

        /// <summary>
        /// Declare a public property for ChoiceViewModel
        /// </summary>
        public ChoiceViewModel ChoiceViewModel { get; set; }

        /// <summary>
        /// Declare a public property for ProjectDetailsViewModel
        /// </summary>
        public ProjectDetailsViewModel ProjectDetailsViewModel { get; set; }


        /// <summary>
        /// Declare a public property for QuestionViewModel
        /// </summary>
        public QuestionViewModel QuestionViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="aboutViewModel"></param>
        public NavigateToPreviousPageCommand(AboutViewModel aboutViewModel)
        {
            AboutViewModel = aboutViewModel;
        }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="errorViewModel"></param>
        public NavigateToPreviousPageCommand(ErrorViewModel errorViewModel)
        {
            ErrorViewModel = errorViewModel;
        }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="helpViewModel"></param>
        public NavigateToPreviousPageCommand(HelpViewModel helpViewModel)
        {
            HelpViewModel = helpViewModel;
        }

        /// <summary>
        /// Initialise PrivacyViewModel properties in constructor.
        /// </summary>
        /// <param name="privacyViewModel"></param>
        public NavigateToPreviousPageCommand(PrivacyViewModel privacyViewModel)
        {
            PrivacyViewModel = privacyViewModel;
        }

        /// <summary>
        /// Initialise TempTestViewModel properties in constructor.
        /// </summary>
        /// <param name="tempTestViewModel"></param>
        public NavigateToPreviousPageCommand(TempTestViewModel tempTestViewModel)
        {
            TempTestViewModel = tempTestViewModel;
        }

        /// <summary>
        /// Initialise TermsViewModel properties in constructor.
        /// </summary>
        /// <param name="termsViewModel"></param>
        public NavigateToPreviousPageCommand(TermsViewModel termsViewModel)
        {
            TermsViewModel = termsViewModel;
        }

        /// <summary>
        /// Initialise CountryViewModel properties in constructor.
        /// </summary>
        /// <param name="countryViewModel"></param>
        public NavigateToPreviousPageCommand(CountryViewModel countryViewModel)
        {
            CountryViewModel = countryViewModel;
        }

        /// <summary>
        /// Initialise ChoiceViewModel properties in constructor.
        /// </summary>
        public NavigateToPreviousPageCommand(ChoiceViewModel choiceViewModel)
        {
            ChoiceViewModel = choiceViewModel;
        }

        /// <summary>
        /// Initialise ProjectDetailsViewModel properties in constructor.
        /// </summary>
        /// <param name="projectDetailsViewModel"></param>
        public NavigateToPreviousPageCommand(ProjectDetailsViewModel projectDetailsViewModel)
        {
            ProjectDetailsViewModel = projectDetailsViewModel;
        }

        /// <summary>
        /// Initialise QuestionViewModel properties in constructor.
        /// </summary>
        /// <param name="questionViewModel"></param>
        public NavigateToPreviousPageCommand(QuestionViewModel questionViewModel)
        {
            QuestionViewModel = questionViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Navigate To Previous Page Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Navigate To Previous Page Command
        /// </summary>
        /// <param name="parameter"></param>
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

            if (QuestionViewModel != null)
                QuestionViewModel.NavigateBackToPreviousPage();
        }
    }
}
