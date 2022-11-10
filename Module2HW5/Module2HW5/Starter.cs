using System;
using System.IO;

namespace Module2HW5
{
    public class Starter
    {
        public static void Run()
        {
            Logger logger = Logger.GetInstance();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var whichMethod = new Random().Next(1, 4);
                    Result result;
                    switch (whichMethod)
                    {
                        case 1:
                            result = Actions.InfoMethod();
                            break;
                        case 2:
                            result = Actions.WarningMethod();
                            break;
                        case 3:
                            result = Actions.ErrorMethod();
                            break;
                        default:
                            result = null;
                            break;
                    }

                    if (result == null)
                    {
                        Console.WriteLine("Something went wrong with randomizer in Starter: Run()");
                    }
                }
                catch (BusinessException e)
                {
                    logger.AddLog(Type.Warning, "Action got this custom Exception: " + e.Message);
                }
                catch (Exception e)
                {
                    logger.AddLog(Type.Error, "Action failed by a reason: " + e.Message);
                }
            }

            logger.SaveLogs();
        }
    }
}
