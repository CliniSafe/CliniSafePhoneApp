using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToQuestionsCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for FindDrugsViewModel
        /// </summary>
        public FindDrugsViewModel FindDrugsViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="findDrugsViewModel"></param>
        public NavigateToQuestionsCommand(FindDrugsViewModel findDrugsViewModel)
        {
            FindDrugsViewModel = findDrugsViewModel;
        }

        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// Enable Navigate To Question Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            var selectedDrug = (GenericDrugsFound)parameter;

            if (selectedDrug == null)
                return false;

            if (string.IsNullOrEmpty(selectedDrug.DrugName) || selectedDrug.Drug_ID == 0)
                return false;

            return true;
        }

        /// <summary>
        /// Execute Navigate To Question Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var selectedDrug = (GenericDrugsFound)parameter;
            FindDrugsViewModel.NavigateToQuestions(selectedDrug);
        }
    }
}

