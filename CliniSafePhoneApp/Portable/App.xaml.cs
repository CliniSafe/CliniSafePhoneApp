using CliniSafePhoneApp.Portable.Data;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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
            AppCenter.Start("android=86a0a5c5-9f08-4228-b9dc-09768b8ba115;" +
                  "uwp={Your UWP App secret here};" +
                  "ios=0a256258-4e32-4540-af33-c8c1fa6b99f2;",
                  typeof(Analytics), typeof(Crashes));
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
