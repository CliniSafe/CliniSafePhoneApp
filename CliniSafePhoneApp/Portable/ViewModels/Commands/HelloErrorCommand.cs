using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class HelloErrorCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for TempTestViewModel
        /// </summary>
        public TempTestViewModel TempTestViewModels { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="tempTestViewModel"></param>
        public HelloErrorCommand(TempTestViewModel tempTestViewModel)
        {
            TempTestViewModels = tempTestViewModel;
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
        /// Execute Hello Command Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            TempTestViewModels.HelloErrorAsync();
        }
    }
}
