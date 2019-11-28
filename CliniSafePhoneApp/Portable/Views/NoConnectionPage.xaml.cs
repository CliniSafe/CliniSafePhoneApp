using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class NoConnectionPage : ContentPage
    {
        /// <summary>
        /// Define NoConnectionViewModel.
        /// </summary>
        private readonly NoConnectionViewModel NoConnectionVM;

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public NoConnectionPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            //Initialise NoConnectionViewModel.
            NoConnectionVM = new NoConnectionViewModel();

            // Set the Page Binding Context to the NoConnectionViewModel(NoConnectionVM)
            BindingContext = NoConnectionVM;
        }
    }
}
