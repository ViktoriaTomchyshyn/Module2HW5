using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Module2HW5
{
    public class ConfigService
    {
        public static string GetLogsPath()
        {
            return ConfigurationManager.AppSettings.Get("LogsPath").ToString();
        }
    }
}
