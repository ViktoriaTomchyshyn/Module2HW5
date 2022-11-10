using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5
{
    public class Result
    {
        private bool _status;

        private string _message = string.Empty;
        public Result()
        {
            _status = true;
        }

        public Result(bool status)
        {
            _status = status;
        }

        public Result(bool status, string message)
        {
            _status = status;
            _message = message;
        }

        public bool Status
        {
            get { return _status; }
            set { _status = value; }
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
    }
}
