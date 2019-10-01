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
        /// Define private members (LoginViemModel)
        /// </summary>
        private LoginViewModel LoginVM;


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
            cliniSafeImage.Source = "logo.png";

            //this.Master = new LeftMenuPage();//name of your menupage                
            //this.Detail = new ContentPage();//name of your detailpage


            //MasterBehavior = MasterBehavior.Popover;

            // MenuPages.Add((int)MenuItemType.LogIn, (NavigationPage)Detail);
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
