using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace serverXamarin
{
    public class TcpServer
    {
        private TcpListener _listener;
        private DatabaseService _dbService;
        private bool _isRunning;

        public TcpServer(string ipAddress, int port, string dbConnectionString)
        {
            _listener = new TcpListener(IPAddress.Parse(ipAddress), port);
            _dbService = new DatabaseService(dbConnectionString);
        }

        public void Start()
        {
            _isRunning = true;
            _listener.Start();
            Console.WriteLine("TCP Server started...");

            while (_isRunning)
            {
                var client = _listener.AcceptTcpClient();
                Console.WriteLine("Client connected");

                // Обрабатываем клиента в отдельном потоке
                System.Threading.Tasks.Task.Run(() => HandleClient(client));
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine($"Received request: {request}");

                // Обрабатываем запрос
                string response = ProcessRequest(request);

                // Отправляем ответ
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        private string ProcessRequest(string request)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var requestData = JsonSerializer.Deserialize<RequestData>(request, options);

                if (requestData.Action == "get_table_data" && !string.IsNullOrEmpty(requestData.TableName))
                {
                    var tableData = _dbService.GetTableData(requestData.TableName);
                    var response = new ResponseData
                    {
                        Success = true,
                        Data = tableData
                    };

                    return JsonSerializer.Serialize(response, options);
                }
                else
                {
                    return JsonSerializer.Serialize(new ResponseData
                    {
                        Success = false,
                        Error = "Invalid request"
                    }, options);
                }
            }
            catch (Exception ex)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                return JsonSerializer.Serialize(new ResponseData
                {
                    Success = false,
                    Error = ex.Message
                }, options);
            }
        }

        public void Stop()
        {
            _isRunning = false;
            _listener.Stop();
        }
    }

    // Классы для сериализации данных
    public class RequestData
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("tableName")]
        public string TableName { get; set; }
    }

    public class ResponseData
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public List<Dictionary<string, object>> Data { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}
