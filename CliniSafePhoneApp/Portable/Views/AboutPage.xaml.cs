using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class AboutPage : ContentPage
    {
        /// <summary>
        /// Define AboutViewModel.
        /// </summary>
        private readonly AboutViewModel AboutVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public AboutPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise AboutViewModel.
            AboutVM = new AboutViewModel();

            // Set the Page Binding Context to the AboutViewModel(AboutVM)
            BindingContext = AboutVM;
        }
    }
}
