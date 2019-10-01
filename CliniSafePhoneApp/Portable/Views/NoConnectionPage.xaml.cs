using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class NoConnectionPage : ContentPage
    {
        /// <summary>
        /// Define NoConnectionViewModel.
        /// </summary>
        NoConnectionViewModel NoConnectionVM;

        public NoConnectionPage()
        {
            InitializeComponent();

            //Initialise NoConnectionViewModel.
            NoConnectionVM = new NoConnectionViewModel();

            // Set the Page Binding Context to the NoConnectionViewModel(NoConnectionVM)
            BindingContext = NoConnectionVM;
        }
    }
}
