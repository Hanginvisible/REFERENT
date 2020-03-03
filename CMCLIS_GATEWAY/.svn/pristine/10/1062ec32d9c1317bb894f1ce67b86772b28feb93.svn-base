using CMCLIS.GATEWAY.CORE;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.WServiceMQMail
{
    public partial class MQServiceMail : ServiceBase
    {
        public MQServiceMail()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CommonFunction.ConsumeQueue();
        }

        protected override void OnStop()
        {
        }
    }
}
