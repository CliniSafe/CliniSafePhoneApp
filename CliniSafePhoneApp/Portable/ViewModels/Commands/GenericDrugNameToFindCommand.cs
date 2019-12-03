using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class GenericDrugNameToFindCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for FindDrugsViewModel
        /// </summary>
        public FindDrugsViewModel FindDrugsViewModel { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="findDrugsViewModel"></param>
        public GenericDrugNameToFindCommand(FindDrugsViewModel findDrugsViewModel)
        {
            FindDrugsViewModel = findDrugsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable FindDrugs(GenericDrugNameToFindCommand) Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute FindDrugs(GenericDrugNameToFindCommand) Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var drugNameToFind = (string)parameter;
            FindDrugsViewModel.GetGenericDrugDetails(drugNameToFind);
        }
    }
}
