﻿using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.SERVICES
{
    /// <summary>
    /// class chứa các hàm dùng chung
    /// </summary>
    /// created by: ntkien5 12.02.2020
    public  class CommonFunction
    {
        /// <summary>
        /// hàm thực hiện khởi tạo đổi tượng FILE_SERVER_DATAInfo
        /// </summary>
        /// <param name="source">dữ liệu đầu vào</param>
        /// <returns></returns>
        /// creared by: ntkien5 12.02.2020
        public static FILE_SERVER_DATAInfo InitFileServerInfo(FILE_SERVER_DATAObject source)
        {
            FILE_SERVER_DATAInfo objInit = new FILE_SERVER_DATAInfo();
            string fileID = (string.IsNullOrWhiteSpace(source.FILE_ID))? Guid.NewGuid().ToString(): source.FILE_ID;
            string fileName = Guid.NewGuid().ToString();
            decimal version = 0;
            if (!string.IsNullOrWhiteSpace( source.FILE_ID))
            {
                int totalcount = 0;
                //ntkien5: 12.02.2020 vì trong store oracle đã sắp xếp theo ID giảm dần nên chỉ cần lấy top 1 là auto version mới nhất
                List<FILE_SERVER_DATAInfo> files = DataObjectFactory.GetInstanceFILE_SERVER_DATA().FILE_SERVER_DATA_GetAllWithPadding(fileID, string.Empty,string.Empty,string.Empty,string.Empty,0,1,1,ref totalcount);
                var file = files.FirstOrDefault();
                if (file!=null)
                {
                    version = file.VERSION != null ? file.VERSION.Value + 1 : 1;
                }
            }
            objInit.FILE_ID = fileID;
            objInit.FILE_NAME = fileName;
            objInit.VERSION = version;

            objInit.CUSER = source.CUSER;
            objInit.DOC_TYPE = source.DOC_TYPE;
            objInit.EXTENSION = source.EXTENSION;
            objInit.DESCRIPTION = source.DESCRIPTION;
            objInit.TRAN_ID = source.TRAN_ID;
            objInit.REGION_ID = source.REGION_ID;
            objInit.SOURCE = source.SOURCE;
            objInit.IS_DELETE = false;

            return objInit;
        }
    }
}