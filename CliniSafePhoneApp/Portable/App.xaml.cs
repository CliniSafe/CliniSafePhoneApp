using CliniSafePhoneApp.Portable.Data;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using CliniSafePhoneApp.Portable.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CliniSafePhoneApp.Portable
{
    public partial class App : Application
    {

        private static ISoapService soapService;

        public static ISoapService PhoneAppSoapService
        {
            get
            {
                if (soapService == null)
                    soapService = DependencyService.Get<ISoapService>();
                return soapService;
            }
        }

        public App()
        {
            InitializeComponent();

            // Set MainPage as the root page
            // MainPage = new NavigationPage(new HandShakePage());


            //Ok working
            //MainPage = new NavigationPage(new LoginPage());


            // Check the internet connectivity
            if (!Constants.CheckConnectivity())
                //MainPage.Navigation.PushAsync(new NoConnectionPage());

                MainPage.Navigation.PushAsync(new NavigationPage(new NoConnectionPage()));

            else
                //Call Handshake method (function); 
                //MainPage = new NavigationPage(new HandShakePage());


                // WITH SPLASH
                //MainPage = new MainPage();
                MainPage = new NavigationPage(new MainPage());
        }




        /// <summary>
        /// Define HandshakeViewModel.
        /// </summary>
        HandshakeViewModel HandshakeVM;




        protected override void OnStart()
        {
            // Handle when your app starts

            //Initialise HandshakeViewModel.
            // HandshakeVM = new HandshakeViewModel();

            // // Set the Page Binding Context to the HandshakeViewModel(HandshakeVM)
            //BindingContext = HandshakeVM;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
