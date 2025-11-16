using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace clientMobilka
{
    public class TcpClientService
    {
        private string _serverIp;
        private int _serverPort;

        public TcpClientService(string serverIp, int serverPort)
        {
            _serverIp = serverIp;
            _serverPort = serverPort;
        }

        public async Task<ResponseData> GetTableDataAsync(string tableName)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    await client.ConnectAsync(_serverIp, _serverPort);

                    var request = new RequestData
                    {
                        Action = "get_table_data",
                        TableName = tableName
                    };

                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    string jsonRequest = JsonSerializer.Serialize(request, options);
                    byte[] requestData = Encoding.UTF8.GetBytes(jsonRequest);

                    NetworkStream stream = client.GetStream();
                    await stream.WriteAsync(requestData, 0, requestData.Length);

                    // Читаем ответ
                    byte[] buffer = new byte[4096];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string jsonResponse = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    return JsonSerializer.Deserialize<ResponseData>(jsonResponse, options);
                }
            }
            catch (Exception ex)
            {
                return new ResponseData
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }
}
