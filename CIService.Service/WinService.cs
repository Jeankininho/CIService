using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CIService
{
    public class WinService : ServiceBase
    {
        public ILog Log;
        
        public WinService()
        {
            Log = LogManager.GetLogger(typeof(WinService));
        }

        protected override void OnStart(string[] args)
        {
            Log.Debug("Starting service");

        }


        protected override void OnStop()
        {
            Log.Debug("Stopping service");
        }

        internal void StartConsole()
        {
            OnStart(null);
        }

        internal void StopConsole()
        {
            OnStop();
        }
    }
}
