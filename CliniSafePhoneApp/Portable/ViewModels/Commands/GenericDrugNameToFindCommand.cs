using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class GenericDrugNameToFindCommand : ICommand
    {
        public FindDrugsViewModel _findDrugsViewModels { get; set; }

        public GenericDrugNameToFindCommand(FindDrugsViewModel findDrugsViewModel)
        {
            _findDrugsViewModels = findDrugsViewModel;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            //var drugNameToFind = (string)parameter;

            //if (drugNameToFind == null)
            //    return true;

            //if (string.IsNullOrEmpty(drugNameToFind))
            //    return true;

            return true;
        }

        public void Execute(object parameter)
        {
            var drugNameToFind = (string)parameter;
            _findDrugsViewModels.GetGenericDrugDetails(drugNameToFind);

        }
    }
}
