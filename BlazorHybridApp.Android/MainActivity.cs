using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.MobileBlazorBindings.WebView.Android;
using Xamarin.Forms.Platform.Android;

namespace BlazorHybridApp.Droid
{
    [Activity(Label = "BlazorHybridApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            BlazorHybridAndroid.Init();

            var fileProvider = new AssetFileProvider(Assets, "wwwroot");

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            LoadApplication(new App(fileProvider));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
