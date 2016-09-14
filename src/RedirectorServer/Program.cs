using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;
using Service.IOCP;
using System.Net;

namespace RedirectorServer
{
    public class Program
    {
        public static string IpAddress = string.Empty;
        public static int Port;
        public static int MaxListenCount;
        public static Socket ServiceSocket;

        public static void Main(string[] args)
        {
            LoadSettings();

            StartLisen();

            Console.WriteLine("Press any key to exist");
            Console.ReadLine();
        }


        private static void LoadSettings()
        {
            // 支持中文编码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // 加载日志配置文件
            var setttins = new ConfigurationBuilder().AddJsonFile("Config.json").Build();
            IpAddress = setttins["AppSetting:HostName"];
            Port = int.Parse(setttins["AppSetting:Port"]);
            MaxListenCount = int.Parse(setttins["AppSetting:MaxConnections"]);
        }

        /// <summary>
        /// 启动侦听
        /// </summary>
        /// <returns></returns>
        public static void StartLisen()
        {
            AsyncIOCPServer server = new AsyncIOCPServer(IPAddress.Parse(IpAddress), Port, MaxListenCount);
            server.Start();
            Console.WriteLine("Server Started:{0}:{1}!", IpAddress, Port);
            System.Console.ReadLine();
        }
    }
}
