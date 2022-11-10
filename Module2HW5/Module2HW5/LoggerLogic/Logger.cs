using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5
{
    public class Logger
    {
        private static Logger _instance;
        private LoggerItem[] _logs;
        private Logger()
        {
            _logs = null;
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }

        public void AddLog(Type type, string message)
        {
            if (_logs == null)
            {
                _logs = new LoggerItem[1] { new LoggerItem(type, message) };
            }
            else
            {
                Array.Resize<LoggerItem>(ref _logs, _logs.Length + 1);
                _logs[_logs.Length - 1] = new LoggerItem(type, message);
            }

            Console.Write(_logs[_logs.Length - 1]);
        }

        public LoggerItem[] GetLogs()
        {
            return _logs;
        }

        public void PrintLogs()
        {
            if (_logs != null)
            {
                foreach (var item in _logs)
                {
                    Console.Write(item);
                }
            }
        }

        public void SaveLogs()
        {
            FileService fs = new FileService();
            fs.WriteToFile(ToString());
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in _logs)
            {
                result += item.ToString();
            }

            return result;
        }
    }
}
