using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CIService
{
    class Program
    {
        public static ILog Log = LogManager.GetLogger(typeof(Program));
        public static WinService WinService;


        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            //if (ServiceUtil.CheckIfsRunning(out CurrentProcess))
            //    Environment.Exit(-1);

            try
            {
                //ServiceUtil.Initialize(getpublicIp: false);

                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
                WinService = new WinService();

                if (Environment.UserInteractive || (args?.Length > 0 && args.Contains("-Console")))
                {
                    ////---------------Publicação em ConsoleApplication;----------------/////
                    Console.CancelKeyPress += Console_CancelKeyPress;
                    Console.Title = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                    WinService.StartConsole(); //A bagaça começa aqui.
                    ReadCommands();
                }
                else
                {
                    ////---------------------Publicação em serviço;---------------------/////
                    ServiceBase.Run(WinService);
                }
                Environment.Exit(-1);
            }
            catch (Exception ex)
            {
                Log.Fatal($"Erro fatal no Program !", ex);
                Console.Write("Press any key");
                Console.ReadLine();
            }
        }
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (StaticObjects.Stopped)
                return;
            e.Cancel = true;
            WinService.StopConsole();
            Environment.Exit(-1);
        }

        private static void ReadCommands()
        {
            while (true)
            {
                var r = Console.ReadKey(true);

                switch (char.ToLower(r.KeyChar))
                {
                    case 'q':
                        WinService.StopConsole(); return;//return;
                    default:
                        break;
                }
            }
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Log.Fatal($"[FirstChanceException] ", e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject != null)
                Log.Fatal($"UnhandledException {e.ExceptionObject.ToString()}");
            else
                Log.Fatal($"UnhandledException");
        }
    }
}
