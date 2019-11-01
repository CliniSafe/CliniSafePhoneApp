using CliniSafePhoneApp.Portable.Service;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class LogOutPage : ContentPage
    {
        /// <summary>
        /// Define LogOutViewModel.
        /// </summary>
        //LogOutViewModel LogOutVM;

        public LogOutPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            ////Initialise LogOutViewModel.
            //LogOutViewModel = new LogOutViewModel();

            //// Set the Page Binding Context to the LogOutViewModel(LogOutVM)
            //BindingContext = LogOutVM;
        }
    }
}
