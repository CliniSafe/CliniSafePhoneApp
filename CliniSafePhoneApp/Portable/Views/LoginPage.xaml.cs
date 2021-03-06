using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        //Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        /// <summary>
        /// Define Private Members (LoginViemModel)
        /// </summary>
        private readonly LoginViewModel LoginVM;



        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();

            //Initialise LoginViemModel.
            LoginVM = new LoginViewModel();

            // Set the Page Binding Context to the LoginViewModel(LoginVM)
            BindingContext = LoginVM;

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (LoginVM.AuthHeader != null)
            {
                LoginVM.AuthHeader = null;
                usernameEntry.Text = null;
                passwordEntry.Text = null;
                authenticationLabel.Text = null;
            }
        }


        //public async Task NavigateFromMenu(int id)
        //{
        //    if (!MenuPages.ContainsKey(id))
        //    {
        //        switch (id)
        //        {
        //            case (int)MenuItemType.LogIn:
        //                MenuPages.Add(id, new NavigationPage(new LoginPage() { Title = "Login" }));
        //                break;
        //            case (int)MenuItemType.About:
        //                MenuPages.Add(id, new NavigationPage(new AboutPage() { Title = "About" }));
        //                break;
        //            case (int)MenuItemType.Help:
        //                MenuPages.Add(id, new NavigationPage(new HelpPage() { Title = "Help" }));
        //                break;
        //            case (int)MenuItemType.Privacy:
        //                MenuPages.Add(id, new NavigationPage(new PrivacyPage() { Title = "Privacy" }));
        //                break;
        //            case (int)MenuItemType.Terms:
        //                MenuPages.Add(id, new NavigationPage(new TermsPage() { Title = "Terms" }));
        //                break;
        //            case (int)MenuItemType.TempTest:
        //                MenuPages.Add(id, new NavigationPage(new TempTestPage() { Title = "Temporary Test Page" }));
        //                break;
        //            case (int)MenuItemType.LogOut:
        //                MenuPages.Add(id, new NavigationPage(new LogOutPage() { Title = "Log Out" }));
        //                break;

        //        }
        //    }

        //    var newPage = MenuPages[id];

        //    if (newPage != null && Detail != newPage)
        //    {
        //        Detail = newPage;

        //        if (Device.RuntimePlatform == Device.Android)
        //            await Task.Delay(100);

        //        IsPresented = false;
        //    }
        //}
    }
}


