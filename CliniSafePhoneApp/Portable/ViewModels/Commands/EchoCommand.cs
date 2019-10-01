using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class EchoCommand : ICommand
    {
        public TempTestViewModel _tempTestViewModels { get; set; }

        public EchoCommand(TempTestViewModel tempTestViewModel)
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
            _tempTestViewModels.EchoAsync();

        }
    }
}
