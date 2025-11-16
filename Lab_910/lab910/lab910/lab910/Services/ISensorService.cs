using System;
using System.Collections.Generic;
using System.Text;

namespace lab910.Services
{
    public interface ISensorService
    {
        void StartLightSensor();
        void StopLightSensor();
        void StartAccelerometer();
        void StopAccelerometer();
        void StartProximity();
        void StopProximity();

        float LightLevel { get; }
        float ProximityDistance { get; }
        (float x, float y, float z) Acceleration { get; }

        event EventHandler<string> SensorDataUpdated;
    }

    public interface INotificationService
    {
        void SendNotification(string title, string message);
    }
}
