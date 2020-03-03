using CMCLIS.CVAN.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// đối tượng lưu dữ liệu trả về cho clien khi người dùng tìm kiếm file
/// </summary>
/// created by: ntkien5 10.02.2020
namespace CMCLIS.CVAN.UPLOADFILE
{
    public class ResponseFileInfo
    {
        public string FILE_ID { get; set; }
        public string FILE_CONTENT { get; set; }
        public FILE_SERVER_DATAInfo DATA { get; set; }
    }
}
