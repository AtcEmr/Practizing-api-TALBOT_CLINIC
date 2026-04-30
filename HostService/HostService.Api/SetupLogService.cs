using PractiZing.Base.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HostService.Api
{
    public class SetupLogService : ISetupLogService
    {
        public void Log(string message)
        {
            SetupLog.Log(message);
        }
    }
}
