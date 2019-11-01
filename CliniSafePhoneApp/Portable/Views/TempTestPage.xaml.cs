using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.Views
{
    public partial class TempTestPage : ContentPage
    {
        /// <summary>
        /// Define TempTestViewModel.
        /// </summary>
        private TempTestViewModel TempTestVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public TempTestPage()
        {
            InitializeComponent();

            //Initialise TempTestViewModel.
            TempTestVM = new TempTestViewModel();

            // Set the Page Binding Context to the TempTestViewModel(TempTestVM)
            BindingContext = TempTestVM;

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;
        }
    }
}
