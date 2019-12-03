using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class PopUpCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for FindDrugsViewModel
        /// </summary>
        public FindDrugsViewModel _findDrugsViewModels { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="findDrugsViewModel"></param>
        public PopUpCommand(FindDrugsViewModel findDrugsViewModel)
        {
            _findDrugsViewModels = findDrugsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable PopUp Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute PopUp Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _findDrugsViewModels.PopUpSiteDetails();
        }
    }
}
