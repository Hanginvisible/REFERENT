using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string MICRO_SERVICE_IP = "localhost";
            string MICRO_SERVICE_PORT = "38241";
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                MESSAGE_TYPE = "10",
                XML_CONTENT = Utility.LoadFile(@"C:\Users\HTHANG\Desktop\XML\GuiPhieuChuyen_Request.xml")
            });
            Response response = HttpWebRequestBase.POST<Response>(json, "http://localhost:38241/REST/API_LIEN_THONG/CVAN_TIEP_NHAN_HO_SO");
            var a = response;
        }
    }
}
