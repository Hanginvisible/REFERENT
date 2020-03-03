using CMCLIS.GATEWAY.SETTING;

namespace CMCLIS.GATEWAY.GATEWAY
{
    class Program
    {
        static void Main(string[] args)
        {
            var microService = new CMCLIS.GATEWAY.MicroService.MicroService(int.Parse(Config.MICRO_SERVICE_PORT),Config.MICRO_SERVICE_DISPLAY_NAME,Config.MICRO_SERVICE_NAME);
            microService.Run(args);
        }
    }
}
