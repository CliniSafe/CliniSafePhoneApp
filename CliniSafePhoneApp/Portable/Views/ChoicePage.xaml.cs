using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ChoicePage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define private Member ChoiceViewModel.
        /// </summary>
        private readonly ChoiceViewModel ChoiceVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ChoicePage(ProjectUser projectUser)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ChoiceViewModel.
            ChoiceVM = new ChoiceViewModel(projectUser);

            // Set the Page Binding Context to the ChoiceViewModel(ChoiceVM)
            BindingContext = ChoiceVM;
        }

        private void MonitorNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Countries page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Countries);
        }

        private void InvestigatorNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Research Sites page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.ResearchSites);
        }
    }
}
