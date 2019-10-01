using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ErrorPage : ContentPage
    {
        /// <summary>
        /// Define private Member (ErrorViewModel).
        /// </summary>
        private ErrorViewModel ErrorVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ErrorPage()
        {
            InitializeComponent();

            //Initialise ErrorViewModel.
            ErrorVM = new ErrorViewModel();

            // Set the Page Binding Context to the ErrorViewModel(ErrorVM)
            BindingContext = ErrorVM;

            //Set the Image Source
            cliniSafeImage.Source = "logo.png";
        }
    }
}
