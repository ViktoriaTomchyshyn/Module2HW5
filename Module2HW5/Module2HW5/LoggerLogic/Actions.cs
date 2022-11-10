using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5
{
    public class Actions
    {
        public static Result InfoMethod()
        {
            Logger.GetInstance().AddLog(Type.Info, "Start method: " + new StackFrame().GetMethod().Name.ToString());
            return new Result(true);
        }

        public static Result WarningMethod()
        {
           throw new BusinessException("Skipped logic in method");
        }

        public static Result ErrorMethod()
        {
            throw new Exception("I broke a logic.");
        }
    }
}
