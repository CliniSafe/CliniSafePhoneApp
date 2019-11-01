using CliniSafePhoneApp.Portable.Service;
using System;
using System.Windows.Input;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class PrivacyPage : ContentPage
    {
        /// <summary>
        /// Define PrivacyViewModel.
        /// </summary>
        //PrivacyViewModel PrivacyVM;

        public ICommand TapCommand => new Command<string>(OpenBrowser);

        public PrivacyPage()
        {
            InitializeComponent();
            BindingContext = this;

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            ////Initialise PrivacyViewModel.
            //PrivacyVM = new PrivacyViewModel();

            //// Set the Page Binding Context to the PrivacyViewModel(PrivacyVM)
            //BindingContext = PrivacyVM;
        }

        [Obsolete]
        void OpenBrowser(string url)
        {
            Device.OpenUri(new Uri(url));
        }
    }
}
