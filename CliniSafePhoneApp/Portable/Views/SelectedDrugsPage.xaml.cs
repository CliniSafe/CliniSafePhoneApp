using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class SelectedDrugsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        /// <summary>
        /// Define SelectedDrugsViewModel.
        /// </summary>
        //SelectedDrugsViewModel SelectedDrugsVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public SelectedDrugsPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise SelectedDrugsViewModel.NextNavigationButton_Clicked
            //SelectedDrugsVM = new SelectedDrugsViewModel();

            // Set the Page Binding Context to the SelectedDrugsViewModel(SelectedDrugsVM)
            //BindingContext = SelectedDrugsVM;
        }

        private void NextNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Questions page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.QuestionsForResearchSite);
        }
    }
}
