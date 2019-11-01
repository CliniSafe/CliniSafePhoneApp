using CliniSafePhoneApp.Portable.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToMainCommand : ICommand
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        public ResultsViewModel _resultsViewModel { get; set; }

        public NavigateToMainCommand(ResultsViewModel resultsViewModel)
        {
            _resultsViewModel = resultsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _resultsViewModel.NavigateToMainPage();
        }
    }
}

