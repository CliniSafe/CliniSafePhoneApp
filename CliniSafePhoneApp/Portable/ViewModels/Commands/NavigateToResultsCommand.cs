using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;


namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToResultsCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for ReviewViewModel
        /// </summary>
        public ReviewViewModel ReviewViewModel { get; set; }

        public NavigateToResultsCommand(ReviewViewModel reviewViewModel)
        {
            ReviewViewModel = reviewViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //var questionSelectedDrug = (GenericDrugsFound)parameter;
            _ = ReviewViewModel.NavigateToResults();
        }
    }
}

