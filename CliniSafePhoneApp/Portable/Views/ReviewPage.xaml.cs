using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ReviewPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define ReviewViewModel.
        /// </summary>
        //ReviewViewModel ReviewVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ReviewPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ReviewViewModel.
            //ReviewVM = new ReviewViewModel();

            // Set the Page Binding Context to the ReviewViewModel(ReviewVM)
            //BindingContext = ReviewVM;
        }

        private void NextNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Results page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Results);
        }
    }
}
