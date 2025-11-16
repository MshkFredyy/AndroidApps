using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverXamarin
{
    class Program
    {
        static void Main()
        {
            // Настройки подключения к PostgreSQL
            string dbConnectionString = "Host=localhost;Port=5432;Database=notesdb;Username=postgres;Password=G_!$204_!";

            // Настройки TCP сервера
            string ipAddress = "192.168.1.72"; // IP компьютера
            int port = 8888;

            var server = new TcpServer(ipAddress, port, dbConnectionString);

            try
            {
                server.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server error: {ex.Message}");
            }
        }
    }
}
