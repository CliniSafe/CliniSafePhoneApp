using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class HelloCommand : ICommand
    {
        public TempTestViewModel _tempTestViewModels { get; set; }

        public HelloCommand(TempTestViewModel tempTestViewModel)
        {
            _tempTestViewModels = tempTestViewModel;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _tempTestViewModels.HelloAsync();

        }
    }
}
