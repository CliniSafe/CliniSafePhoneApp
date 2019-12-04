using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class EchoCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for TempTestViewModels
        /// </summary>
        public TempTestViewModel TempTestViewModels { get; set; }


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="tempTestViewModel"></param>
        public EchoCommand(TempTestViewModel tempTestViewModel)
        {
            TempTestViewModels = tempTestViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Echo Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Echo Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            TempTestViewModels.EchoAsync();
        }
    }
}
