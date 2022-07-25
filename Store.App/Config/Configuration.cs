using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Config
{
    public static class Configuration
    {
        private static Dictionary<string, string> AppSettings { get; set; }

        static Configuration()
        {
            AppSettings = new();
            string? assemblyName = Assembly.GetCallingAssembly().GetName().Name;
            var config = GetAssemblyConfiguration(assemblyName);
            var appSettings = config.AppSettings.Settings;
            foreach (var setting in appSettings.AllKeys)
            {
                AppSettings.Add(setting, appSettings[setting].Value);
            }
        }

        public static string Url => AppSettings[nameof(Url)];

        public static string UserName => AppSettings[nameof(UserName)];

        public static string Password => AppSettings[nameof(Password)];


        private static System.Configuration.Configuration GetAssemblyConfiguration(string assemblyName)
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            string filePath = string.Format("{0}\\{1}.dll.config", AppDomain.CurrentDomain.BaseDirectory, assemblyName);
            configFileMap.ExeConfigFilename = filePath;
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            return config;
        }
    }
}
