using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.Views
{
    public partial class HandShakePage : ContentPage
    {
        /// <summary>
        /// Define private Member HandshakeViewModel.
        /// </summary>
        private readonly HandshakeViewModel HandshakeVM;


        public HandShakePage()
        {
            InitializeComponent();

            //Initialise HandshakeViewModel.
            HandshakeVM = new HandshakeViewModel();

            // Set the Page Binding Context to the HandshakeViewModel(HandshakeVM)
            BindingContext = HandshakeVM;

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;
        }
    }
}
