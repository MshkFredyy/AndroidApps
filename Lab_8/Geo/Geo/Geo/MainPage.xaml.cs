using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Mapsui;
using Mapsui.Projections;
using Mapsui.UI.Forms;
using Mapsui.Layers;
using Mapsui.Styles;
using Mapsui.Utilities;
using BruTile.Predefined;
using Mapsui.Tiling.Layers;
using System.Linq;
using Map = Mapsui.Map;
using Mapsui.Providers;

namespace Geo
{
    public partial class MainPage : ContentPage
    {
        private MapView _mapView;

        public MainPage()
        {
            InitializeComponent();
            InitializeMapWithPins();
        }

        private void InitializeMapWithPins()
        {
            // Создаем карту
            var map = new Map();

            // Добавляем слой OpenStreetMap
            var osmLayer = new TileLayer(KnownTileSources.Create())
            {
                Name = "OpenStreetMap"
            };
            map.Layers.Add(osmLayer);

            // Устанавливаем начальную позицию (Москва)
            var (startX, startY) = SphericalMercator.FromLonLat(37.6173, 55.7558);
            var startPoint = new MPoint(startX, startY);

            map.Navigator.CenterOn(startPoint);
            //map.Viewport.Resolution = 5000;

            // Создаем MapView
            _mapView = new MapView
            {
                Map = map,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = System.Drawing.Color.Gray
            };

            // Добавляем MapView в контейнер
            MapContainer.Children.Add(_mapView);

            LocationLabel.Text = "Карта загружена. Нажмите 'Моё местоположение'";
        }

        private async void GetLocationBtn_Clicked(object sender, EventArgs e)
        {
            await GetCurrentLocation();
        }

        private async Task GetCurrentLocation()
        {
            try
            {
                GetLocationBtn.IsEnabled = false;
                LocationLabel.Text = "🔍 Определение местоположения...";

                // Проверяем разрешения
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status != PermissionStatus.Granted)
                {
                    LocationLabel.Text = "❌ Разрешение на геолокацию не предоставлено";
                    GetLocationBtn.IsEnabled = true;
                    return;
                }

                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });

                if (location != null)
                {
                    ShowLocationWithPin(location);
                }
                else
                {
                    LocationLabel.Text = "❌ Не удалось получить местоположение";
                }
            }
            catch (Exception ex)
            {
                LocationLabel.Text = $"❌ Ошибка: {ex.Message}";
            }
            finally
            {
                GetLocationBtn.IsEnabled = true;
            }
        }

        private void ShowLocationWithPin(Location location)
        {
            // Преобразуем координаты
            var (x, y) = SphericalMercator.FromLonLat(location.Longitude, location.Latitude);
            var point = new MPoint(x, y);

            // Очищаем старые пины
            _mapView.Pins.Clear();

            // Создаем новый пин
            var pin = new Pin(_mapView)
            {
                Position = new Mapsui.UI.Forms.Position(location.Latitude, location.Longitude),
                Label = "Вы здесь",
                Type = PinType.Pin,
                Scale = 0.7f,
                Color = Xamarin.Forms.Color.Red
            };

            // Добавляем пин на карту
            _mapView.Pins.Add(pin);

            // Обновляем информацию
            LocationLabel.Text = $"📍 Ш: {location.Latitude:0.0000}° Д: {location.Longitude:0.0000}°";

            // Перемещаем карту
            _mapView.Map.Navigator.CenterOn(point);
            //_mapView.Map.Viewport.Resolution = 500;

            // Обновляем карту
            _mapView.Refresh();

            // Пытаемся получить адрес
            _ = TryGetAddress(location.Latitude, location.Longitude);
        }

        private async Task TryGetAddress(double latitude, double longitude)
        {
            try
            {
                var placemarks = await Geocoding.GetPlacemarksAsync(latitude, longitude);
                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    var address = "";
                    if (!string.IsNullOrEmpty(placemark.Locality))
                        address += placemark.Locality;
                    if (!string.IsNullOrEmpty(placemark.Thoroughfare))
                        address += $", {placemark.Thoroughfare}";

                    if (!string.IsNullOrEmpty(address))
                    {
                        Device.BeginInvokeOnMainThread(() => {
                            LocationLabel.Text += $"\n🏠 {address}";
                        });
                    }
                }
            }
            catch
            {
                // Игнорируем ошибки
            }
        }

        private void ZoomInBtn_Clicked(object sender, EventArgs e)
        {
            _mapView.Map.Navigator.ZoomIn();
        }

        private void ZoomOutBtn_Clicked(object sender, EventArgs e)
        {
            _mapView.Map.Navigator.ZoomOut();
        }

    }
}
