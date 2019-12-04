using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class HelloCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for TempTestViewModel
        /// </summary>
        public TempTestViewModel TempTestViewModel { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="tempTestViewModel"></param>
        public HelloCommand(TempTestViewModel tempTestViewModel)
        {
            TempTestViewModel = tempTestViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Hello Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Hello Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            TempTestViewModel.HelloAsync();
        }
    }
}


