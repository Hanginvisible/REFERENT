using CMCLIS.GATEWAY.SETTING;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.UPLOADFILE
{
    class Program
    {
        static void Main(string[] args)
        {
            var microService = new CMCLIS.GATEWAY.MicroService.MicroService(int.Parse(Config.MICRO_SERVICE_PORT), Config.MICRO_SERVICE_DISPLAY_NAME, Config.MICRO_SERVICE_NAME);
            microService.Run(args);
        }
    }
}
