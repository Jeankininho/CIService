using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CIService
{
    public class WinService : ServiceBase
    {
        public ILog Log;
        public Timer MaintTimer;

        public WinService()
        {
            Log = LogManager.GetLogger(typeof(WinService));
            MaintTimer = new Timer();
            MaintTimer.Interval = 1000;
            MaintTimer.Elapsed += (a, b) => { Loop(); };
        }

        protected override void OnStart(string[] args)
        {
            Log.Debug("Starting service");
            MaintTimer.Start();
        }

        public void Loop()
        {
            Log.Debug("Service is running");
        }


        protected override void OnStop()
        {
            Log.Debug("Stopping service");
            MaintTimer.Stop();
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
