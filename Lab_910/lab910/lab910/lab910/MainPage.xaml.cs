using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using lab910.Services;

namespace lab910
{
    public partial class MainPage : ContentPage
    {
        private readonly ISensorService _sensorService;
        private readonly INotificationService _notificationService;

        public MainPage()
        {
            InitializeComponent();

            _sensorService = DependencyService.Get<ISensorService>();
            _notificationService = DependencyService.Get<INotificationService>();

            _sensorService.SensorDataUpdated += OnSensorDataUpdated;
        }

        private void OnSensorDataUpdated(object sender, string sensorType)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                switch (sensorType)
                {
                    case "Light":
                        LightLabel.Text = $"Освещенность: {_sensorService.LightLevel:F2} lux";
                        break;
                    case "Accelerometer":
                        var accel = _sensorService.Acceleration;
                        AccelLabel.Text = $"X: {accel.x:F2}, Y: {accel.y:F2}, Z: {accel.z:F2}";
                        break;
                    case "Proximity":
                        ProximityLabel.Text = $"Расстояние: {_sensorService.ProximityDistance:F2} cm";
                        break;
                }
            });
        }

        private void StartLight_Clicked(object sender, EventArgs e)
        {
            _sensorService.StartLightSensor();
            StartLightBtn.IsEnabled = false;
            StopLightBtn.IsEnabled = true;
        }

        private void StopLight_Clicked(object sender, EventArgs e)
        {
            _sensorService.StopLightSensor();
            StartLightBtn.IsEnabled = true;
            StopLightBtn.IsEnabled = false;
            LightLabel.Text = "Освещенность: ---";
        }

        private void StartAccel_Clicked(object sender, EventArgs e)
        {
            _sensorService.StartAccelerometer();
            StartAccelBtn.IsEnabled = false;
            StopAccelBtn.IsEnabled = true;
        }

        private void StopAccel_Clicked(object sender, EventArgs e)
        {
            _sensorService.StopAccelerometer();
            StartAccelBtn.IsEnabled = true;
            StopAccelBtn.IsEnabled = false;
            AccelLabel.Text = "X: ---, Y: ---, Z: ---";
        }

        private void StartProximity_Clicked(object sender, EventArgs e)
        {
            _sensorService.StartProximity();
            StartProximityBtn.IsEnabled = false;
            StopProximityBtn.IsEnabled = true;
        }

        private void StopProximity_Clicked(object sender, EventArgs e)
        {
            _sensorService.StopProximity();
            StartProximityBtn.IsEnabled = true;
            StopProximityBtn.IsEnabled = false;
            ProximityLabel.Text = "Расстояние: ---";
        }

        private void SendNotification_Clicked(object sender, EventArgs e)
        {
            var light = _sensorService.LightLevel;
            var accel = _sensorService.Acceleration;
            var proximity = _sensorService.ProximityDistance;

            string message = $" Текущие показания:\n" +
                           $"• Освещенность: {light:F2} lux\n" +
                           $"• Ускорение: X:{accel.x:F2}, Y:{accel.y:F2}, Z:{accel.z:F2}\n" +
                           $"• Приближение: {proximity:F2} cm\n\n" +
                           $" {DateTime.Now:HH:mm:ss}";

            _notificationService.SendNotification("🔍 Данные датчиков", message);

            // Можно оставить или убрать DisplayAlert, так как уведомление уже покажется
            DisplayAlert("Уведомление", "Уведомление отправлено в системную шторку!", "OK");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Останавливаем все датчики при закрытии страницы
            _sensorService.StopLightSensor();
            _sensorService.StopAccelerometer();
            _sensorService.StopProximity();
        }
    }
}
