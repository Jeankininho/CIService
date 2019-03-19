using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIService
{
    public class WinService : SkySoftwareLibs.Service.SkyServiceBase
    {
        public WinService()
        {

        }

        protected override void OnStart(string[] args)
        {
            Log.Debug("Starting service");
        }


        protected override void OnStop()
        {
            Log.Debug("Stopping service");
        }
    }
}
