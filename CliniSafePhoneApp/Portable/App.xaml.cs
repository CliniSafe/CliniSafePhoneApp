using CliniSafePhoneApp.Portable.Data;
using CliniSafePhoneApp.Portable.Service;
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

            // Check the internet connectivity
            if (!Constants.CheckConnectivity())
                MainPage = new NavigationPage(new NoConnectionPage());
            else
                MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
