using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// đối tượng dùng để  chứa dữ liệu được gửi từ các ứng dụng khác
/// </summary>
/// created by: ntkien 20.02.2020
namespace CMCLIS.GATEWAY.ENTITY
{
    public class FILE_SERVER_DATAObject
    {
        public string FILE_ID { get; set; }
        
        public string DOC_TYPE { get; set; }
       
        public string FILE_NAME { get; set; }

        /// <summary>
        /// string base 64
        /// </summary>
        public string FILE_CONTENT { get; set; }

        public string EXTENSION { get; set; }
        
        public string DESCRIPTION { get; set; }
       
        public decimal? VERSION { get; set; }
       
        public string TRAN_ID { get; set; }
       
        public string REGION_ID { get; set; }
       
        public string SOURCE { get; set; }
        
        public string CUSER { get; set; }
        
        public string LUSER { get; set; }

    }
}
