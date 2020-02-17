using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToReviewCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for QuestionViewModel
        /// </summary>
        public QuestionViewModel QuestionViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="questionViewModel"></param>
        public NavigateToReviewCommand(QuestionViewModel questionViewModel)
        {
            QuestionViewModel = questionViewModel;
        }

        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// Enable Navigate To Question Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            var questionSelectedDrug = (QuestionSelectedDrug)parameter;

            if (questionSelectedDrug == null)
            {
                return false;
            }

            if (questionSelectedDrug != null)
            {
                if (questionSelectedDrug.Yes == null && questionSelectedDrug.No == null)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Execute Navigate To Question Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var questionSelectedDrug = (QuestionSelectedDrug)parameter;
            _ = QuestionViewModel.NavigateToReview(questionSelectedDrug);
        }
    }
}

