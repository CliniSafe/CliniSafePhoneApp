using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToFindDrugsCommand : ICommand
    {


        public CountryViewModel _countryViewModel { get; set; }

        public NavigateToFindDrugsCommand(CountryViewModel countryViewModel)
        {
            _countryViewModel = countryViewModel;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            var country = (Country)parameter;

            if (country == null)
                return false;

            if (string.IsNullOrEmpty(country.TrialCode) || string.IsNullOrEmpty(country.EnglishCountryName))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            var counrty = (Country)parameter;
            _countryViewModel.NavigateToFindDrugs(counrty);
        }
    }
}

