using CliniSafePhoneApp.Portable.Models;
using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToFindDrugsCommand : ICommand
    {
        /// <summary>
        /// Declare a public property for CountryViewModel
        /// </summary>
        public CountryViewModel CountryViewModel { get; set; }

        /// <summary>
        /// Declare a public property for ResearchSitesViewModel
        /// </summary>
        public ResearchSitesViewModel ResearchSitesViewModel { get; set; }

        /// <summary>
        /// Initialise CountryViewModel properties in constructor.
        /// </summary>
        /// <param name="countryViewModel"></param>
        public NavigateToFindDrugsCommand(CountryViewModel countryViewModel)
        {
            CountryViewModel = countryViewModel;
        }

        /// <summary>
        /// Initialise ResearchSitesViewModel properties in constructor.
        /// </summary>
        /// <param name="researchSitesViewModel"></param>
        public NavigateToFindDrugsCommand(ResearchSitesViewModel researchSitesViewModel)
        {
            ResearchSitesViewModel = researchSitesViewModel;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Enable Navigate To Find Drugs Command Button
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {

            if (CountryViewModel != null)
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

        /// <summary>
        /// Execute Navigate To Find Drugs Command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (CountryViewModel != null)
            {
                var counrty = (CountriesForProjectForMonitorUser)parameter;
                CountryViewModel.NavigateToFindDrugs(counrty);
            }
            else //(_researchSitesViewModel != null)
            {
                var researchSite = (ResearchSitesForProjectForInvestigatorUser)parameter;
                ResearchSitesViewModel.NavigateToFindDrugs(researchSite);
            }
        }
    }
}

