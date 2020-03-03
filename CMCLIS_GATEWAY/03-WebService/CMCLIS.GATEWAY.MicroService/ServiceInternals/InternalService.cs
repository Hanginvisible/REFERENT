using CMCLIS.GATEWAY.CORE;
using System;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;

namespace CMCLIS.GATEWAY.MicroService.ServiceInternals
{
    public class InternalService : ServiceBase
    {
        internal static event Action OsStarted;
        internal static event Action OsStopped;
        private Timer timer = null;

        public InternalService()
        {
            try
            {
                //Test();
                timer = new Timer();
                this.timer.Interval = int.Parse(ConfigurationManager.AppSettings["Interval"]);
                this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Tick);
            }
            catch (Exception ex)
            {
                //LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                timer.Enabled = true;
                timer.Start();
            }
        }
        protected override void OnStart(string[] args)
        {
            timer.Enabled = true;
            timer.Start();
            LogEventError.LogEvent("Service OnStart successfully" + "[" + DateTime.Now.ToString() + "]");
            OsStarted.Invoke();
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            timer.Stop();
            LogEventError.LogEvent("Service OnStop successfully" + "[" + DateTime.Now.ToString() + "]");
            OsStopped.Invoke();
        }


    }
}
