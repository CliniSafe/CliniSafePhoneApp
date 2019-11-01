using CliniSafePhoneApp.Portable.Service;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class HelpPage : ContentPage
    {
        /// <summary>
        /// Define HelpViewModel.
        /// </summary>
        //PrivacyViewModel HelpVM;

        public HelpPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            ////Initialise HelpViewModel.
            //HelpVM = new HelpViewModel();

            //// Set the Page Binding Context to the HelpViewModel(HelpVM)
            //BindingContext = HelpVM;
        }
    }
}
