using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.WServiceMQD;
using CMCLIS.GATEWAY.WServiceMQDB.Properties;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMCLIS.GATEWAY.WServiceMQDB
{
    static class Program
    {
        #region DllImport
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern IntPtr GetShellWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        #endregion

        #region Define
        static NotifyIcon notifyIcon;
        static IntPtr processHandle;
        static IntPtr WinShell;
        static IntPtr WinDesktop;
        public static ContextMenu menu;
        public static MenuItem mnuExit;
        public static MenuItem mnuShow;
        public static MenuItem mnuHide;
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        #endregion

        static void Main(string[] args)
        {
            
            var factory = new ConnectionFactory()
            {
                HostName = ConfigurationManager.AppSettings["MQ_HOST"],
                UserName = ConfigurationManager.AppSettings["MQ_USER"],
                Password = ConfigurationManager.AppSettings["MQ_PASSWORD"],
                Port = int.Parse(ConfigurationManager.AppSettings["MQ_PORT"])
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: ConfigurationManager.AppSettings["MQ_NAME"],
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    if (message == "CONNECT_MQ")
                        Console.WriteLine(" [x] Received {" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + " }---{" + message + "}");
                    else
                    {
                        Console.WriteLine("--------------------------------------------------");
                        var result = MQ_PROCESS_DATA.MSGO_INSERT_MSG_XML(message, null, ConfigurationManager.AppSettings["MQ_NAME"]);
                        if (int.Parse(result.ToString()) != -1)
                        {
                            Console.WriteLine(" [->] Received {" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + "}");                            
                        }
                        else
                        {
                            Console.WriteLine(" [->] Received {" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + " }---{Error !}");
                        }
                        Console.WriteLine("--------------------------------------------------");
                    }

                    //CMCLIS.GATEWAY.DataObjects.DataObjectFactory.GetInstanceCVAN_MSGO().CVAN_MSGI_INSERT_MSGXML_2_MSGOUT(ea.Exchange, ea.Body, ConfigurationManager.AppSettings["MQ_NAME"]);
                    //Console.WriteLine(" [x] Received {0}", Encoding.UTF8.GetString(ea.Body));
                };
                channel.BasicConsume(queue: ConfigurationManager.AppSettings["MQ_NAME"],
                                     noAck: true,
                                     consumer: consumer);

                #region System tray
                menu = new ContextMenu();
                mnuShow = new MenuItem("Show");
                menu.MenuItems.Add(0, mnuShow);
                mnuHide = new MenuItem("Hide");
                menu.MenuItems.Add(1, mnuHide);
                mnuExit = new MenuItem("Exit");
                menu.MenuItems.Add(2, mnuExit);

                notifyIcon = new NotifyIcon();
                notifyIcon.ContextMenu = menu;
                //System.Resources.ResourceManager rm = CMCLIS.GATEWAY.WServiceMQDB.Properties.Resources.ResourceManager;
                notifyIcon.Icon = (System.Drawing.Icon)Resources.ResourceManager.GetObject(ConfigurationManager.AppSettings["APP_ICON"]);
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.Text = "App " + ConfigurationManager.AppSettings["MQ_NAME"];
                notifyIcon.BalloonTipTitle = "Thông tin ứng dụng " + ConfigurationManager.AppSettings["MQ_NAME"];
                notifyIcon.BalloonTipText = "Lấy thông tin từ MQ " +
                                            Environment.NewLine +
                                            "đổ dự vào DB";

                mnuShow.Click += new EventHandler(mnuShow_Click);
                mnuHide.Click += new EventHandler(mnuHide_Click);
                mnuExit.Click += new EventHandler(mnuExit_Click);
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                notifyIcon.ShowBalloonTip(5000);
                processHandle = Process.GetCurrentProcess().MainWindowHandle;

                WinShell = GetShellWindow();

                WinDesktop = GetDesktopWindow();

                SetParent(processHandle, WinShell);
                Application.Run();
                #endregion

            }

        }



        static void mnuExit_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Đóng ứng dụng việc chuyển thông tin sẽ bi gián đoạn." + Environment.NewLine + "Bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                notifyIcon.Dispose();
                Application.Exit();
            }


        }

        static void mnuShow_Click(object sender, EventArgs e)
        {

            SetParent(processHandle, WinDesktop);

        }

        static void mnuHide_Click(object sender, EventArgs e)
        {

            SetParent(processHandle, WinShell);
        }
    }
}
