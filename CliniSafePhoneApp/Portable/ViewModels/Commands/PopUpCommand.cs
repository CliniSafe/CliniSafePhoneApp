using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class PopUpCommand : ICommand
    {
        public FindDrugsViewModel _findDrugsViewModels { get; set; }

        public PopUpCommand(FindDrugsViewModel findDrugsViewModel)
        {
            _findDrugsViewModels = findDrugsViewModel;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _findDrugsViewModels.PopUpSiteDetails();

        }
    }
}
