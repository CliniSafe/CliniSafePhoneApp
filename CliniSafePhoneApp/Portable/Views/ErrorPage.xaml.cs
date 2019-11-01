using CliniSafePhoneApp.Portable.Service;
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
        public ErrorPage(string strDisplayMessage = null)
        {
            InitializeComponent();

            //Initialise ErrorViewModel.
            ErrorVM = strDisplayMessage == null ? new ErrorViewModel() : new ErrorViewModel(strDisplayMessage);

            // Set the Page Binding Context to the ErrorViewModel(ErrorVM)
            BindingContext = ErrorVM;

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;
        }
    }
}
