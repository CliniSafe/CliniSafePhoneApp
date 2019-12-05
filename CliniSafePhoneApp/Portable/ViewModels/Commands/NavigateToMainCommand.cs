using CliniSafePhoneApp.Portable.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToMainCommand : ICommand
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare a public property for ResultsViewModel
        /// </summary>
        public ResultsViewModel ResultsViewModel { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        /// <param name="resultsViewModel"></param>
        public NavigateToMainCommand(ResultsViewModel resultsViewModel)
        {
            ResultsViewModel = resultsViewModel;
        }

        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// Enable Navigate To Main Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Navigate To Main Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            ResultsViewModel.NavigateToMainPage();
        }
    }
}

