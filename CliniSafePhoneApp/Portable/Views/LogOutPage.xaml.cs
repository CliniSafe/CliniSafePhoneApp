using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class LogOutPage : ContentPage
    {
        /// <summary>
        /// Define LogOutViewModel.
        /// </summary>
        private readonly LogOutViewModel LogOutVM;

        public LogOutPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            //Initialise LogOutViewModel.
            LogOutVM = new LogOutViewModel();

            // Set the Page Binding Context to the LogOutViewModel(LogOutVM)
            BindingContext = LogOutVM;
        }
    }
}
