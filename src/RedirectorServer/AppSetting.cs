using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectorServer
{
    public class AppSettingOptions
    {
        static AppSettingOptions _appSetting;
        static IConfigurationRoot _config;

        static AppSettingOptions()
        {
            _config = new ConfigurationBuilder().AddJsonFile("Config.json").Build();
        }

        //Must be public and parameter-less
        public AppSettingOptions()
        { }

        public static AppSettingOptions GetAppSetting()
        {
            if (_appSetting == null)
            {
                _appSetting = new ServiceCollection()
                    .AddOptions()
                    .Configure<AppSettingOptions>(_config.GetSection("AppSetting"))
                    .BuildServiceProvider()
                    .GetService<IOptions<AppSettingOptions>>()
                    .Value;
            }
            return _appSetting;
        }

        public string HostName { get; set; }
        public int Port { get; set; }
        public int MaxConnections { get; set; }
        public string ConnectionSQL { get; set; }
    }
}
