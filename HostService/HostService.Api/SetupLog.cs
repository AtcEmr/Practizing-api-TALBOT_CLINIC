using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HostService.Api
{

    public class SetupLog
    {
        private static StreamWriter _criticalLog;
        public static void Log(string message)
        {
            try
            {
                if (_criticalLog == null)
                    _criticalLog = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppInitialization.log"), true);

                _criticalLog.WriteLine(message);
                _criticalLog.Flush();

            }
            catch (Exception ex)
            {
                if (_criticalLog != null)
                {
                    _criticalLog.Dispose();
                    _criticalLog = null;
                }

                Console.WriteLine(ex.Message);
            }

        }

        public static void CloseSetupLog()
        {
            try
            {
                if (_criticalLog != null)
                {
                    _criticalLog.Flush();
                    _criticalLog.Dispose();
                }
            }
            catch
            {

            }
        }
    }
}
