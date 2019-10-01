using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class HelloErrorCommand : ICommand
    {
        public TempTestViewModel _tempTestViewModels { get; set; }

        public HelloErrorCommand(TempTestViewModel tempTestViewModel)
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
            _tempTestViewModels.HelloErrorAsync();

        }
    }
}
