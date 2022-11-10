using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5
{
    public enum Type
    {
        Error,
        Info,
        Warning
    }

    public class LoggerItem
    {
        private DateTime _created;
        private Type _type;
        private string _message;

        public LoggerItem(Type type, string message)
        {
            _created = DateTime.Now;
            _type = type;
            _message = message;
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = DateTime.Now; }
        }

        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _message = value;
                }
            }
        }

        public override string ToString()
        {
            return _created.ToString() + ":" + _type.ToString() + ":" + _message + "\n";
        }
    }
}
