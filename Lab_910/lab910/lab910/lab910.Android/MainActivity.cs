using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.AppCompat.App;
using lab910.Droid.Droid;
using Xamarin.Essentials;

namespace lab910.Droid
{
    [Activity(Label = "lab910", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // Запрашиваем разрешения при запуске
            RequestRequiredPermissions();
        }

        private async void RequestRequiredPermissions()
        {
            try
            {
                // Для Android 13+ запрашиваем разрешение на уведомления
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
                {
                    var status = await Permissions.CheckStatusAsync<NotificationsPermission>();
                    if (status != PermissionStatus.Granted)
                    {
                        await Permissions.RequestAsync<NotificationsPermission>();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка запроса разрешений: {ex.Message}");
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}