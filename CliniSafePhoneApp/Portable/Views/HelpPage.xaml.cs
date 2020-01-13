using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class HelpPage : ContentPage
    {
        /// <summary>
        /// Define Private Member HelpViewModel.
        /// </summary>
        private readonly HelpViewModel HelpVM;

        public HelpPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            ////Initialise HelpViewModel.
            HelpVM = new HelpViewModel();

            /// Set the Page Binding Context to the HelpViewModel(HelpVM)
            BindingContext = HelpVM;
        }
    }
}
