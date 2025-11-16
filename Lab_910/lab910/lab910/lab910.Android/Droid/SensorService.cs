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
using Android.Hardware;
using lab910.Droid;
using Xamarin.Forms;
using lab910.Droid.Droid;
using lab910.Services;

[assembly: Dependency(typeof(SensorService))]

namespace lab910.Droid.Droid
{
    public class SensorService : Java.Lang.Object, ISensorService, ISensorEventListener
    {
        private SensorManager _sensorManager;
        private Sensor _lightSensor;
        private Sensor _accelerometer;
        private Sensor _proximitySensor;

        public float LightLevel { get; private set; }
        public float ProximityDistance { get; private set; }
        public (float x, float y, float z) Acceleration { get; private set; }

        public event EventHandler<string> SensorDataUpdated;

        public SensorService()
        {
            _sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService);
            _lightSensor = _sensorManager.GetDefaultSensor(SensorType.Light);
            _accelerometer = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);
            _proximitySensor = _sensorManager.GetDefaultSensor(SensorType.Proximity);
        }

        public void StartLightSensor()
        {
            if (_lightSensor != null)
            {
                _sensorManager.RegisterListener(this, _lightSensor, SensorDelay.Ui);
            }
        }

        public void StopLightSensor()
        {
            if (_lightSensor != null)
            {
                _sensorManager.UnregisterListener(this, _lightSensor);
            }
        }

        public void StartAccelerometer()
        {
            if (_accelerometer != null)
            {
                _sensorManager.RegisterListener(this, _accelerometer, SensorDelay.Ui);
            }
        }

        public void StopAccelerometer()
        {
            if (_accelerometer != null)
            {
                _sensorManager.UnregisterListener(this, _accelerometer);
            }
        }

        public void StartProximity()
        {
            if (_proximitySensor != null)
            {
                _sensorManager.RegisterListener(this, _proximitySensor, SensorDelay.Ui);
            }
        }

        public void StopProximity()
        {
            if (_proximitySensor != null)
            {
                _sensorManager.UnregisterListener(this, _proximitySensor);
            }
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }

        public void OnSensorChanged(SensorEvent e)
        {
            if (e.Sensor.Type == SensorType.Light)
            {
                LightLevel = e.Values[0];
                SensorDataUpdated?.Invoke(this, "Light");
            }
            else if (e.Sensor.Type == SensorType.Accelerometer)
            {
                Acceleration = (e.Values[0], e.Values[1], e.Values[2]);
                SensorDataUpdated?.Invoke(this, "Accelerometer");
            }
            else if (e.Sensor.Type == SensorType.Proximity)
            {
                ProximityDistance = e.Values[0];
                SensorDataUpdated?.Invoke(this, "Proximity");
            }
        }
    }
}