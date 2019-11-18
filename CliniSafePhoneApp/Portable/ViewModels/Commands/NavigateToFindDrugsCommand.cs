using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToFindDrugsCommand : ICommand
    {
        public CountryViewModel _countryViewModel { get; set; }

        public ResearchSitesViewModel _researchSitesViewModel { get; set; }

        public NavigateToFindDrugsCommand(CountryViewModel countryViewModel)
        {
            _countryViewModel = countryViewModel;
        }


        public NavigateToFindDrugsCommand(ResearchSitesViewModel researchSitesViewModel)
        {
            _researchSitesViewModel = researchSitesViewModel;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {

            if (_countryViewModel != null)
            {
                var country = (CountriesForProjectForMonitorUser)parameter;

                if (country == null)
                    return false;

                if (string.IsNullOrEmpty(country.TrialCode) || string.IsNullOrEmpty(country.EnglishCountryName))
                    return false;

                return true;
            }
            else //(_researchSitesViewModel != null)
            {
                var researchSite = (ResearchSitesForProjectForInvestigatorUser)parameter;

                if (researchSite == null)
                    return false;

                if (string.IsNullOrEmpty(researchSite.SiteCode) || string.IsNullOrEmpty(researchSite.SiteTitle))
                    return false;

                return true;
            }

        }

        public void Execute(object parameter)
        {
            if (_countryViewModel != null)
            {
                var counrty = (CountriesForProjectForMonitorUser)parameter;
                _countryViewModel.NavigateToFindDrugs(counrty);
            }
            else //(_researchSitesViewModel != null)
            {
                var researchSite = (ResearchSitesForProjectForInvestigatorUser)parameter;
                _researchSitesViewModel.NavigateToFindDrugs(researchSite);
            }
        }
    }
}

