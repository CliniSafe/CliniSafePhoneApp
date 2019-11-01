
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using System.Threading;

namespace CliniSafePhoneApp.Android
{
    [Activity(Label = "Welcome to Clinisafe", NoHistory = true, MainLauncher = true, HardwareAccelerated = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class HandshakeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Display Handshake Splash Screen
            SetContentView(Resource.Layout.HandshakeLayout);
            _ = FindViewById<LinearLayout>(Resource.Id.handshake_linear_layout);
            _ = FindViewById<ImageView>(Resource.Id.handshake_logo_image_view);
            _ = FindViewById<TextView>(Resource.Id.handshake_loading_text);
            _ = (ProgressBar)FindViewById(Resource.Id.handshake_progress_bar);

            //Display Handshake Splash Screen for 4 Sec  
            System.Threading.Tasks.Task.Run(() =>
            {
                Thread.Sleep(4000);

                // Create your application here
                StartActivity(typeof(MainActivity));
            });
        }
    }
}
