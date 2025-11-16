using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace clientMobilka
{
    public partial class MainPage : ContentPage
    {
        private TcpClientService _tcpClient;

        public MainPage()
        {
            InitializeComponent();

            // Настройки подключения к серверу
            string serverIp = "192.168.1.72"; // IP сервера
            int serverPort = 8888;

            _tcpClient = new TcpClientService(serverIp, serverPort);
        }

        private async void OnLoadDataClicked(object sender, EventArgs e)
        {
            string tableName = tableNameEntry.Text?.Trim();

            if (string.IsNullOrEmpty(tableName))
            {
                await DisplayAlert("Error", "Please enter table name", "OK");
                return;
            }

            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;
            statusLabel.Text = "Loading data...";
            dataCollectionView.ItemsSource = null;

            try
            {
                var result = await _tcpClient.GetTableDataAsync(tableName);

                if (result.Success && result.Data != null)
                {
                    DisplayData(result.Data);
                    statusLabel.Text = $"Loaded {result.Data.Count} records from '{tableName}'";
                }
                else
                {
                    statusLabel.Text = $"Error: {result.Error}";
                    await DisplayAlert("Error", result.Error, "OK");
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Connection error: {ex.Message}";
                await DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                loadingIndicator.IsVisible = false;
                loadingIndicator.IsRunning = false;
            }
        }

        private void DisplayData(List<Dictionary<string, object>> data)
        {
            if (data == null || data.Count == 0)
            {
                dataCollectionView.ItemsSource = new List<TableRow>
                {
                    new TableRow { IsHeader = true, Values = new List<string> { "No data found" } }
                };
                return;
            }

            
            var displayRows = new List<TableRow>();

            
            if (data.Count > 0)
            {
                var headerRow = new TableRow
                {
                    IsHeader = true,
                    Values = data[0].Keys.ToList()
                };
                displayRows.Add(headerRow);
            }

            
            foreach (var row in data)
            {
                var displayRow = new TableRow
                {
                    IsHeader = false,
                    Values = row.Values.Select(v => v?.ToString() ?? "NULL").ToList()
                };
                displayRows.Add(displayRow);
            }

            dataCollectionView.ItemsSource = displayRows;
        }
    }

    
    public class TableRow
    {
        public bool IsHeader { get; set; }
        public List<string> Values { get; set; }

        // Для удобства привязки в XAML
        public string Column1 => Values?.Count > 0 ? Values[0] : "";
        public string Column2 => Values?.Count > 1 ? Values[1] : "";
        public string Column3 => Values?.Count > 2 ? Values[2] : "";
        public string Column4 => Values?.Count > 3 ? Values[3] : "";
        public string Column5 => Values?.Count > 4 ? Values[4] : "";

        // Свойства для стилей
        public Color BackgroundColor => IsHeader ? Color.FromHex("#2196F3") : Color.FromHex("#FFFFFF");
        public Color TextColor => IsHeader ? Color.White : Color.Black;
        public Color BorderColor => IsHeader ? Color.FromHex("#1976D2") : Color.FromHex("#E0E0E0");
        public FontAttributes FontAttributes => IsHeader ? FontAttributes.Bold : FontAttributes.None;
        public int FontSize => IsHeader ? 14 : 12;
    }
}
