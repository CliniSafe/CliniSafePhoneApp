using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class FindDrugsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        /// <summary>
        /// Define AboutViewModel.
        /// </summary>
        //AboutViewModel AboutVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public FindDrugsPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise AboutViewModel.
            //AboutVM = new AboutViewModel();

            // Set the Page Binding Context to the AboutViewModel(AboutVM)
            //BindingContext = AboutVM;
        }

        private void NextNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Selected Drugs page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.SelectedDrugs);
        }
    }
}
