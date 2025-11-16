using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.Core.App;
using lab910.Droid.Droid;
using Xamarin.Forms;
using lab910.Services;
using Android.Graphics;
using Xamarin.Essentials;


[assembly: Dependency(typeof(lab910.Droid.Droid.NotificationService))]

namespace lab910.Droid.Droid
{
    public class NotificationService : INotificationService
    {
        private Context _context;
        private NotificationManager _notificationManager;
        private int _notificationId = 1000;
        private const string CHANNEL_ID = "sensor_demo_channel";
        private const string CHANNEL_NAME = "Демо датчиков";

        public NotificationService()
        {
            _context = Android.App.Application.Context;
            _notificationManager = (NotificationManager)_context.GetSystemService(Context.NotificationService);
            CreateNotificationChannel();
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(CHANNEL_ID,
                    CHANNEL_NAME,
                    NotificationImportance.High)
                {
                    Description = "Уведомления от приложения Демо датчиков",
                    LockscreenVisibility = NotificationVisibility.Public
                };

                channel.EnableLights(true);
                channel.LightColor = Android.Graphics.Color.Blue;
                channel.EnableVibration(true);
                channel.SetVibrationPattern(new long[] { 0, 500, 200, 500 });

                _notificationManager.CreateNotificationChannel(channel);
            }
        }

        public async void SendNotification(string title, string message)
        {
            try
            {
                // Проверяем разрешение на уведомления для Android 13+
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
                {
                    var status = await Permissions.CheckStatusAsync<NotificationsPermission>();
                    if (status != PermissionStatus.Granted)
                    {
                        status = await Permissions.RequestAsync<NotificationsPermission>();
                        if (status != PermissionStatus.Granted)
                        {
                            System.Diagnostics.Debug.WriteLine("Разрешение на уведомления не предоставлено");
                            return;
                        }
                    }
                }

                // Создаем интент для открытия приложения
                var intent = new Intent(_context, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
                var pendingIntent = PendingIntent.GetActivity(_context, 0, intent,
                    PendingIntentFlags.Immutable | PendingIntentFlags.UpdateCurrent);

                // Создаем уведомление
                var notificationBuilder = new NotificationCompat.Builder(_context, CHANNEL_ID)
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetSmallIcon(GetNotificationIcon())
                    .SetLargeIcon(GetLargeIcon())
                    .SetContentIntent(pendingIntent)
                    .SetAutoCancel(true)
                    .SetPriority(NotificationCompat.PriorityHigh)
                    .SetDefaults((int)NotificationDefaults.All)
                    .SetStyle(new NotificationCompat.BigTextStyle().BigText(message))
                    .SetVisibility(NotificationCompat.VisibilityPublic)
                    .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                    .SetShowWhen(true)
                    .SetColor(Android.Graphics.Color.ParseColor("#2196F3"));

                // Добавляем действие "Закрыть"
                var dismissIntent = new Intent(_context, typeof(NotificationDismissReceiver));
                dismissIntent.PutExtra("notification_id", _notificationId);
                var dismissPendingIntent = PendingIntent.GetBroadcast(_context, _notificationId,
                    dismissIntent, PendingIntentFlags.Immutable | PendingIntentFlags.UpdateCurrent);

                notificationBuilder.AddAction(Resource.Drawable.abc_ic_clear_material,
                    "Закрыть", dismissPendingIntent);

                var notification = notificationBuilder.Build();

                // Показываем уведомление
                _notificationManager.Notify(_notificationId, notification);
                _notificationId++;

                System.Diagnostics.Debug.WriteLine("Уведомление отправлено успешно");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка отправки уведомления: {ex.Message}");
            }
        }

        private int GetNotificationIcon()
        {
            // Пытаемся найти подходящую иконку
            int iconId = _context.Resources.GetIdentifier("abc_ic_menu_share_mtrl_alpha", "drawable", _context.PackageName);
            if (iconId == 0)
            {
                // Если не нашли, используем стандартную иконку
                iconId = Android.Resource.Drawable.IcDialogInfo;
            }
            return iconId;
        }

        private Bitmap GetLargeIcon()
        {
            try
            {
                int iconId = GetNotificationIcon();
                return BitmapFactory.DecodeResource(_context.Resources, iconId);
            }
            catch
            {
                return null;
            }
        }
    }

    // Класс для разрешения уведомлений (для Android 13+)
    public class NotificationsPermission : Xamarin.Essentials.Permissions.BasePlatformPermission
    {
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
            new List<(string androidPermission, bool isRuntime)>
            {
                (Android.Manifest.Permission.PostNotifications, true)
            }.ToArray();
    }

    // Receiver для закрытия уведомлений
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class NotificationDismissReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var notificationId = intent.GetIntExtra("notification_id", 0);
            var notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.Cancel(notificationId);
        }
    }
}