using System;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.ServiceProcess;
using CMCLIS.CVAN.MicroService.Network;
using CMCLIS.CVAN.MicroService.ServiceInternals;
using CMCLIS.CVAN.SETTING;

namespace CMCLIS.CVAN.MicroService
{
    public class MicroService
    {
        #region Events

        public event Action OnServiceStarted;
        public event Action OnServiceStopped;

        #endregion

        #region Fields

        private readonly string _serviceDisplayName;
        private readonly int _port;
        private readonly WindowsServiceManager _serviceManager;
        private readonly RegistryManipulator _registryManipulator;
        private SelfHostServer _selfHostServer;

        #endregion

        #region C'tor

        public MicroService(int port, string serviceDisplayName, string serviceName)
        {
            //port = int.Parse(Config.MICRO_SERVICE_PORT);
            _port = port;

            var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            _serviceDisplayName = serviceDisplayName ?? assemblyName;
            serviceName = serviceName ?? assemblyName;

            _serviceManager = new WindowsServiceManager(_serviceDisplayName);
            _registryManipulator = new RegistryManipulator(serviceName);

            InternalService.OsStarted += Start;
            InternalService.OsStopped += Stop;
            ProjectInstaller.InitInstaller(_serviceDisplayName,serviceName);

        }

        #endregion

        #region Public

        public void Run(string[] args)
        {            
            if (args.Length == 0)
            {
                //UnInstallService();
                RunConsole();
                return;
            }

            switch (args[0])
            {
                case "-service":
                    RunService();
                    break;
                case "-install":
                    UnInstallService();
                    //InstallService();
                    break;
                case "-uninstall":
                    UnInstallService();
                    break;
                default:
                    throw new Exception(args[0] + " is not a valid command!");
            }
        }

        #endregion

        #region Private

        private void RunConsole()
        {
            //Start();
            //UnInstallService();
            //InstallService();
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadLine();
            ////UnInstallService();
            //Stop();
            Start();
            ServiceController ctl = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == Config.MICRO_SERVICE_NAME);
            if (ctl != null)
                UnInstallService();
            InstallService();
            Console.WriteLine("******************************************************");
            Console.WriteLine("*INTPUT : REMOVE - REMOVE SERVICE                    *");
            Console.WriteLine("*INTPUT : PRESS ANY KEY TO EXIT                      *");
            Console.WriteLine("******************************************************");
            string line = Console.ReadLine(); // Get string from user
            if (line.ToUpper() == "REMOVE") // Check string
            {
                UnInstallService();
                Console.WriteLine("REMOVE SERVICE COMPLETE...");
                Console.WriteLine("PRESS ANY KEY TO EXIT...");
                Console.ReadLine();
            }
            //UnInstallService();
            Stop();
        }

        public static void RunService()
        {
            ServiceBase[] servicesToRun = {new InternalService()};
            ServiceBase.Run(servicesToRun);
        }

        public void InstallService()
        {
            _serviceManager.Install();
            _registryManipulator.AddMinusServiceToRegistry();
            _serviceManager.Start();
        }

        public void UnInstallService()
        {
            _serviceManager.Stop();
            _registryManipulator.RemoveMinusServiceFromRegistry();
            _serviceManager.UnInstall();
        }

        public void Stop()
        {
            _selfHostServer.Dispose();
            if ( OnServiceStopped != null)
                OnServiceStopped.Invoke();
        }

        public void Start()
        {
            _selfHostServer = new SelfHostServer("http://localhost:" + _port);
            _selfHostServer.Connect();
            Console.WriteLine("Service {0} started on port {1}", _serviceDisplayName,_port);
            if ( OnServiceStarted != null)
                OnServiceStarted.Invoke();
        }

        #endregion
    }
}
