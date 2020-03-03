using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.ENTITY
{
    public class FILE_SERVER_RESPONSE
    {
        public string FILE_ID { get; set; }
        public string FILE_CONTENT { get; set; }
        public FILE_SERVER_DATAObject DATA { get; set; }
    }
}
