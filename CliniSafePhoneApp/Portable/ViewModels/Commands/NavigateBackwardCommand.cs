using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateBackwardCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for NoConnectionViewModel
        /// </summary>
        public NoConnectionViewModel NoConnectionViewModel { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="noConnectionViewModel"></param>
        public NavigateBackwardCommand(NoConnectionViewModel noConnectionViewModel)
        {
            NoConnectionViewModel = noConnectionViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Navigate Backward Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Navigate Backward Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            NoConnectionViewModel.NavigateBack();
        }
    }
}
