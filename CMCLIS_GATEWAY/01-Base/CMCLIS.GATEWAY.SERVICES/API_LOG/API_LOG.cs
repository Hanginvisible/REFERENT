﻿using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.SETTING;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Text;

namespace CMCLIS.GATEWAY.SERVICES
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class API_LOG : IAPI_LOG
    {
        private static string Authorization = string.Empty;
        protected API_LOG()
        {
            var request = OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            Authorization = request.Headers[Config.API_KEY];
            if (string.IsNullOrEmpty(Authorization))
            {
                Authorization = Config.KEY_AUTHORIZATION;
            }

        }

        /// <summary>
        /// hthang: Thêm mới thông tin vào bảng LOG_CHUC_NANG
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        #region Create Functions "LOG_CHUC_NANG"
        public Response LOG_CHUC_NANG_Add(LOG_CHUC_NANGInfo info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    if (string.IsNullOrEmpty(info.USER_NAME))
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "USER_NAME không được để trống !"

                        };

                    var CharUserName = info.USER_NAME.ToCharArray();
                    foreach (var charUser in CharUserName)
                    {
                        if (Char.IsWhiteSpace(charUser))
                            return new Response
                            {
                                ResultCode = Constant.RETURN_CODE_ERROR,
                                Message = "USER_NAME không được có khoảng trắng !"
                            };
                    }

                    if (string.IsNullOrEmpty(info.FUNCTION_NAME))
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "FUNCTION_NAME không được để trống !"
                        };

                    if (string.IsNullOrEmpty(info.ACTION))
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "ACTION không được để trống !"

                        };

                    if (info.TIME == null)
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "TIME không được để trống !"

                        };

                    LOG_CHUC_NANGInfo obj = new LOG_CHUC_NANGInfo();
                    obj.ID = info.ID;
                    obj.USER_NAME = info.USER_NAME;
                    obj.FUNCTION_NAME = info.FUNCTION_NAME;
                    obj.ACTION = info.ACTION;
                    obj.TIME = info.TIME;
                    obj.ERROR = info.ERROR;
                    obj.IS_DELETE = info.IS_DELETE;
                    obj.CDATE = info.CDATE;
                    obj.LDATE = info.LDATE;
                    obj.CUSER = info.CUSER; 
                    obj.LUSER = info.LUSER;
                    obj.STT = info.STT;

                    CVAN_LOG_SENDMQInfo log = new CVAN_LOG_SENDMQInfo()
                    {
                        Type_Log = (int)Constant.TYPE_OF_LOG.LOG_CHUC_NANG,
                        Log_Value = JsonConvert.SerializeObject(obj)
                    };

                    string LOG_CHUC_NANG_JSON = JsonConvert.SerializeObject(log);
                    byte[] data = Encoding.UTF8.GetBytes(LOG_CHUC_NANG_JSON);
                    var result = MQProcess.SendDataToMQ(data, Config.CMCLIS_LOG_INFO);

                    return new Response
                    {
                        ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result > 0 ? Constant.MESSAGE_SUCCESS_ADD : Constant.MESSAGE_ERROR_ADD,
                        ReturnValue = result.ToString()
                    };
                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR_ADD + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }

        /// <summary>
        /// hthang: tra cứu thông tin từ bảng LOG_CHUC_NANG theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ResponseInfo<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetInfo(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    LOG_CHUC_NANGInfo result = DataObjectFactory.GetInstanceLOG_CHUC_NANG().GetInfo(int.Parse(ID));
                    return new ResponseInfo<LOG_CHUC_NANGInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        TotalRecords = result != null ? 1 : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseInfo<LOG_CHUC_NANGInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<LOG_CHUC_NANGInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    TotalRecords = 0,
                    Data = null
                };
            }
        }
        /// <summary>
        /// hthang: tra cứu thông tin từ bảng LOG_CHUC_NANG theo điều kiện
        /// </summary>
        /// <param name="USER_NAME"></param>
        /// <param name="FUNCTION_NAME"></param>
        /// <param name="ACTION"></param>
        /// <param name="TIME_START_DATE"></param>
        /// <param name="TIME_END_DATE"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ResponsePage<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetAllWithPadding(string USER_NAME, string FUNCTION_NAME, string ACTION, string TIME_START_DATE, string TIME_END_DATE, string pageIndex, string pageSize)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalRecords = 0;
                    USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
                    FUNCTION_NAME = FUNCTION_NAME == "-1" ? string.Empty : FUNCTION_NAME;
                    ACTION = ACTION == "-1" ? string.Empty : ACTION;
                    //DateTime _TIME_START_DATE = TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(TIME_START_DATE.Split('-')[2]), int.Parse(TIME_START_DATE.Split('-')[1]), int.Parse(TIME_START_DATE.Split('-')[0]), 0, 0, 0);
                    //DateTime _TIME_END_DATE = TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(TIME_END_DATE.Split('-')[2]), int.Parse(TIME_END_DATE.Split('-')[1]), int.Parse(TIME_END_DATE.Split('-')[0]), 23, 59, 59);
                    DateTime? _TIME_START_DATE = null;
                    if (TIME_START_DATE != "-1")
                    {
                        TIME_START_DATE += " " + "00:00:00";
                        _TIME_START_DATE = DateTime.ParseExact(TIME_START_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    }
                    DateTime? _TIME_END_DATE = null;
                    if (TIME_END_DATE != "-1")
                    {
                        TIME_END_DATE += " " + "23:59:59";
                        _TIME_END_DATE = DateTime.ParseExact(TIME_END_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    List<LOG_CHUC_NANGInfo> result = DataObjectFactory.GetInstanceLOG_CHUC_NANG().LOG_CHUC_NANG_QuerySolr_GetAllWithPadding(string.Empty, USER_NAME, FUNCTION_NAME, ACTION, _TIME_START_DATE, _TIME_END_DATE, 0, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
                    return new ResponsePage<LOG_CHUC_NANGInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = result != null ? totalRecords : 0,
                        Data = result
                    };
                }
                else
                {

                    return new ResponsePage<LOG_CHUC_NANGInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponsePage<LOG_CHUC_NANGInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    PageIndex = int.Parse(pageIndex),
                    PageSize = int.Parse(pageSize),
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        #endregion
        #region Create Functions "LOG_DATA"

        /// <summary>
        /// hthang: Thêm mới vào bảng LOG_DATA
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Response LOG_DATA_Add(LOG_DATAInfo info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    if (string.IsNullOrEmpty(info.IP))
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "IP không được để trống !"

                        };
                    if (info.PORT == null)
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "PORT không được để trống !"

                        };
                    if (string.IsNullOrEmpty(info.APPLICATION_NAME))
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "APPLICATION_NAME không được để trống !"

                        };
                    if (info.LOG_TYPE == null)
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "LOG_TYPE không được để trống !"

                        };
                    LOG_DATAInfo obj = new LOG_DATAInfo();
                    obj.ID = info.ID;
                    obj.IP = info.IP;
                    obj.PORT = info.PORT;
                    obj.APPLICATION_NAME = info.MESSAGE;
                    obj.LOG_TYPE = info.LOG_TYPE;
                    obj.IS_DELETE = info.IS_DELETE;
                    obj.CDATE = info.CDATE;
                    obj.LDATE = info.LDATE;
                    obj.CUSER = info.CUSER;
                    obj.LUSER = info.LUSER;
                    obj.MESSAGE = info.MESSAGE;
                    obj.STT = info.STT;

                    CVAN_LOG_SENDMQInfo log = new CVAN_LOG_SENDMQInfo()
                    {
                        Type_Log = (int)Constant.TYPE_OF_LOG.LOG_DATA,
                        Log_Value = JsonConvert.SerializeObject(obj)
                    };

                    string LOG_DA_TA_JSON = JsonConvert.SerializeObject(log);
                    byte[] data = Encoding.UTF8.GetBytes(LOG_DA_TA_JSON);
                    var result = MQProcess.SendDataToMQ(data, Config.CMCLIS_LOG_INFO);

                    return new Response
                    {
                        ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result > 0 ? Constant.MESSAGE_SUCCESS_ADD : Constant.MESSAGE_ERROR_ADD,
                        ReturnValue = result.ToString()
                    };
                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR_ADD + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin trong từ bảng LOG_DATA theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ResponseInfo<LOG_DATAInfo> LOG_DATA_GetInfo(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    LOG_DATAInfo result = DataObjectFactory.GetInstanceLOG_DATA().GetInfo(int.Parse(ID));
                    return new ResponseInfo<LOG_DATAInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        TotalRecords = result != null ? 1 : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseInfo<LOG_DATAInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<LOG_DATAInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_DATA theo điều kiện
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="PORT"></param>
        /// <param name="APPLICATION_NAME"></param>
        /// <param name="MESSAGE"></param>
        /// <param name="LOG_TYPE"></param>
        /// <param name="CDATE_START_DATE"></param>
        /// <param name="CDATE_END_DATE"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ResponsePage<LOG_DATAInfo> LOG_DATA_GetAllWithPadding(string IP, string PORT, string APPLICATION_NAME, string MESSAGE, string LOG_TYPE, string CDATE_START_DATE, string CDATE_END_DATE, string pageIndex, string pageSize)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalRecords = 0;
                    IP = IP == "-1" ? string.Empty : IP;
                    APPLICATION_NAME = APPLICATION_NAME == "-1" ? string.Empty : APPLICATION_NAME;
                    MESSAGE = MESSAGE == "-1" ? string.Empty : MESSAGE;
                    //DateTime _CDATE_START_DATE = CDATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(CDATE_START_DATE.Split('-')[2]), int.Parse(CDATE_START_DATE.Split('-')[1]), int.Parse(CDATE_START_DATE.Split('-')[0]), 0, 0, 0);
                    //DateTime _CDATE_END_DATE = CDATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(CDATE_END_DATE.Split('-')[2]), int.Parse(CDATE_END_DATE.Split('-')[1]), int.Parse(CDATE_END_DATE.Split('-')[0]), 23, 59, 59);

                    DateTime? _CDATE_START_DATE = null;
                    if (CDATE_START_DATE != "-1")
                    {
                        CDATE_START_DATE += " " + "00:00:00";
                        _CDATE_START_DATE = DateTime.ParseExact(CDATE_START_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    }
                    DateTime? _CDATE_END_DATE = null;
                    if (CDATE_END_DATE != "-1")
                    {
                        CDATE_END_DATE += " " + "23:59:59";
                        _CDATE_END_DATE = DateTime.ParseExact(CDATE_END_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    List<LOG_DATAInfo> result = DataObjectFactory.GetInstanceLOG_DATA().LOG_DATA_QuerySolr_GetAllWithPadding(string.Empty, IP, int.Parse(PORT), APPLICATION_NAME, MESSAGE, int.Parse(LOG_TYPE), 0, _CDATE_START_DATE, _CDATE_END_DATE, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
                    return new ResponsePage<LOG_DATAInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = result != null ? totalRecords : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponsePage<LOG_DATAInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponsePage<LOG_DATAInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    PageIndex = int.Parse(pageIndex),
                    PageSize = int.Parse(pageSize),
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        #endregion
        #region Create Functions "LOG_DU_LIEU_DB"

        /// <summary>
        /// hthang: Thêm mới thông tin vào bảng LOG_DU_LIEU_DB
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Response LOG_DU_LIEU_DB_Add(LOG_DU_LIEU_DBInfo info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    if (string.IsNullOrEmpty(info.USER_NAME))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "USER_NAME không được để trống !"
                        };
                    }

                    var CharUserName = info.USER_NAME.ToCharArray();
                    foreach (var charUser in CharUserName)
                    {
                        if (Char.IsWhiteSpace(charUser))
                            return new Response
                            {
                                ResultCode = Constant.RETURN_CODE_ERROR,
                                Message = "USER_NAME không được có khoảng trắng !"
                            };
                    }

                    if (string.IsNullOrEmpty(info.TABLE_NAME))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "TABLE_NAME không được để trống !"
                        };
                    }

                    if (string.IsNullOrEmpty(info.ACTION))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "ACTION không được để trống !"
                        };
                    }

                    if (string.IsNullOrEmpty(info.OLD_VALUE))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "OLD_VALUE không được để trống !"
                        };
                    }

                    if (string.IsNullOrEmpty(info.NEW_VALUE))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "NEW_VALUE không được để trống !"
                        };
                    }

                    LOG_DU_LIEU_DBInfo obj = new LOG_DU_LIEU_DBInfo();
                    obj.ID = info.ID;
                    obj.USER_NAME = info.USER_NAME;
                    obj.TABLE_NAME = info.TABLE_NAME;
                    obj.ACTION = info.ACTION;
                    obj.OLD_VALUE = info.OLD_VALUE;
                    obj.NEW_VALUE = info.NEW_VALUE;
                    obj.IS_DELETE = info.IS_DELETE;
                    obj.CDATE = info.CDATE;
                    obj.LDATE = info.LDATE;
                    obj.CUSER = info.CUSER;
                    obj.LUSER = info.LUSER;
                    obj.STT = info.STT;

                    CVAN_LOG_SENDMQInfo log = new CVAN_LOG_SENDMQInfo()
                    {
                        Type_Log = (int)Constant.TYPE_OF_LOG.LOG_DU_LIEU_DB,
                        Log_Value = JsonConvert.SerializeObject(obj)
                    };

                    string LOG_DU_LIEU_DB_JSON = JsonConvert.SerializeObject(log);
                    byte[] data = Encoding.UTF8.GetBytes(LOG_DU_LIEU_DB_JSON);
                    var result = MQProcess.SendDataToMQ(data, Config.CMCLIS_LOG_INFO);
                    return new Response
                    {
                        ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result > 0 ? Constant.MESSAGE_SUCCESS_ADD : Constant.MESSAGE_ERROR_ADD,
                        ReturnValue = result.ToString()
                    };
                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR_ADD + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_DU_LIEU_DB theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ResponseInfo<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetInfo(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    LOG_DU_LIEU_DBInfo result = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().GetInfo(int.Parse(ID));
                    return new ResponseInfo<LOG_DU_LIEU_DBInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        TotalRecords = result != null ? 1 : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseInfo<LOG_DU_LIEU_DBInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<LOG_DU_LIEU_DBInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_DU_LIEU_DB theo điều kiện
        /// </summary>
        /// <param name="USER_NAME"></param>
        /// <param name="TABLE_NAME"></param>
        /// <param name="ACTION"></param>
        /// <param name="CDATE_START_DATE"></param>
        /// <param name="CDATE_END_DATE"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ResponsePage<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetAllWithPadding(string USER_NAME, string TABLE_NAME, string ACTION, string CDATE_START_DATE, string CDATE_END_DATE, string pageIndex, string pageSize)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalRecords = 0;
                    USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
                    TABLE_NAME = TABLE_NAME == "-1" ? string.Empty : TABLE_NAME;
                    ACTION = ACTION == "-1" ? string.Empty : ACTION;
                    //DateTime _CDATE_START_DATE = CDATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(CDATE_START_DATE.Split('-')[2]), int.Parse(CDATE_START_DATE.Split('-')[1]), int.Parse(CDATE_START_DATE.Split('-')[0]), 0, 0, 0);
                    //DateTime _CDATE_END_DATE = CDATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(CDATE_END_DATE.Split('-')[2]), int.Parse(CDATE_END_DATE.Split('-')[1]), int.Parse(CDATE_END_DATE.Split('-')[0]), 23, 59, 59);

                    DateTime? _CDATE_START_DATE = null;
                    if (CDATE_START_DATE != "-1")
                    {
                        CDATE_START_DATE += " " + "00:00:00";
                        _CDATE_START_DATE = DateTime.ParseExact(CDATE_START_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    }
                    DateTime? _CDATE_END_DATE = null;
                    if (CDATE_END_DATE != "-1")
                    {
                        CDATE_END_DATE += " " + "23:59:59";
                        _CDATE_END_DATE = DateTime.ParseExact(CDATE_END_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    List<LOG_DU_LIEU_DBInfo> result = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().LOG_DU_LIEU_DB_QuerySolr_GetAllWithPadding(string.Empty, USER_NAME, TABLE_NAME, ACTION, 0, _CDATE_START_DATE, _CDATE_END_DATE, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
                    return new ResponsePage<LOG_DU_LIEU_DBInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = result != null ? totalRecords : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponsePage<LOG_DU_LIEU_DBInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponsePage<LOG_DU_LIEU_DBInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    PageIndex = int.Parse(pageIndex),
                    PageSize = int.Parse(pageSize),
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        #endregion
        #region Create Functions "LOG_TRUY_CAP"

        /// <summary>
        /// hthang: Thêm mới thông tin vào bảng LOG_TRUY_CAP
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Response LOG_TRUY_CAP_Add(LOG_TRUY_CAPInfo info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    if (string.IsNullOrEmpty(info.USER_NAME))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "USER_NAME không được để trống !"
                        };
                    }

                    var CharUserName = info.USER_NAME.ToCharArray();
                    foreach (var charUser in CharUserName)
                    {
                        if (Char.IsWhiteSpace(charUser))
                            return new Response
                            {
                                ResultCode = Constant.RETURN_CODE_ERROR,
                                Message = "USER_NAME không được có khoảng trắng !"
                            };
                    }

                    if (info.LOG_TIME == null)
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "LOG_TIME không được để trống !"
                        };
                    }

                    if (string.IsNullOrEmpty(info.ACTION))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "ACTION không được để trống !"
                        };
                    }

                    LOG_TRUY_CAPInfo obj = new LOG_TRUY_CAPInfo();
                    obj.ID = info.ID;
                    obj.USER_NAME = info.USER_NAME;
                    obj.LOG_TIME = info.LOG_TIME;
                    obj.ACTION = info.ACTION;
                    obj.IS_DELETE = info.IS_DELETE;
                    obj.CDATE = info.CDATE;
                    obj.LDATE = info.LDATE;
                    obj.CUSER = info.CUSER;
                    obj.LUSER = info.LUSER;
                    obj.STT = info.STT;

                    CVAN_LOG_SENDMQInfo log = new CVAN_LOG_SENDMQInfo()
                    {
                        Type_Log = (int)Constant.TYPE_OF_LOG.LOG_TRUY_CAP,
                        Log_Value = JsonConvert.SerializeObject(obj)
                    };

                    string LOG_TRUY_CAP_JSON = JsonConvert.SerializeObject(log);
                    byte[] data = Encoding.UTF8.GetBytes(LOG_TRUY_CAP_JSON);
                    var result = MQProcess.SendDataToMQ(data, Config.CMCLIS_LOG_INFO);
                    return new Response
                    {
                        ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result > 0 ? Constant.MESSAGE_SUCCESS_ADD : Constant.MESSAGE_ERROR_ADD,
                        ReturnValue = result.ToString()
                    };
                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR_ADD + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_TRUY_CAP theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ResponseInfo<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetInfo(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    LOG_TRUY_CAPInfo result = DataObjectFactory.GetInstanceLOG_TRUY_CAP().GetInfo(int.Parse(ID));
                    return new ResponseInfo<LOG_TRUY_CAPInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        TotalRecords = result != null ? 1 : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseInfo<LOG_TRUY_CAPInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<LOG_TRUY_CAPInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_TRUY_CAP theo điều kiện
        /// </summary>
        /// <param name="USER_NAME"></param>
        /// <param name="LOG_TIME_START_DATE"></param>
        /// <param name="LOG_TIME_END_DATE"></param>
        /// <param name="ACTION"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ResponsePage<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetAllWithPadding(string USER_NAME, string LOG_TIME_START_DATE, string LOG_TIME_END_DATE, string ACTION, string pageIndex, string pageSize)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalRecords = 0;
                    USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
                    //DateTime _LOG_TIME_START_DATE = LOG_TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(LOG_TIME_START_DATE.Split('-')[2]), int.Parse(LOG_TIME_START_DATE.Split('-')[1]), int.Parse(LOG_TIME_START_DATE.Split('-')[0]), 0, 0, 0);
                    //DateTime _LOG_TIME_END_DATE = LOG_TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(LOG_TIME_END_DATE.Split('-')[2]), int.Parse(LOG_TIME_END_DATE.Split('-')[1]), int.Parse(LOG_TIME_END_DATE.Split('-')[0]), 23, 59, 59);

                    DateTime? _LOG_TIME_START_DATE = null;
                    if (LOG_TIME_START_DATE != "-1")
                    {
                        LOG_TIME_START_DATE += " " + "00:00:00";
                        _LOG_TIME_START_DATE = DateTime.ParseExact(LOG_TIME_START_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    }
                    DateTime? _LOG_TIME_END_DATE = null;
                    if (LOG_TIME_END_DATE != "-1")
                    {
                        LOG_TIME_END_DATE += " " + "23:59:59";
                        _LOG_TIME_END_DATE = DateTime.ParseExact(LOG_TIME_END_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    ACTION = ACTION == "-1" ? string.Empty : ACTION;
                    List<LOG_TRUY_CAPInfo> result = DataObjectFactory.GetInstanceLOG_TRUY_CAP().LOG_TRUY_CAP_QuerySolr_GetAllWithPadding(string.Empty, USER_NAME, _LOG_TIME_START_DATE, _LOG_TIME_END_DATE, ACTION, 0, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
                    return new ResponsePage<LOG_TRUY_CAPInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = result != null ? totalRecords : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponsePage<LOG_TRUY_CAPInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponsePage<LOG_TRUY_CAPInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    PageIndex = int.Parse(pageIndex),
                    PageSize = int.Parse(pageSize),
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        #endregion
        #region Create Functions "LOG_XL_HANG_LOAT"

        /// <summary>
        /// hthang: Thêm mới thông tin vào bảng LOG_XL_HANG_LOAT
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Response LOG_XL_HANG_LOAT_Add(LOG_XL_HANG_LOATInfo info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    if (string.IsNullOrEmpty(info.USER_NAME))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "USER_NAME không được để trống !"
                        };
                    }

                    var CharUserName = info.USER_NAME.ToCharArray();
                    foreach (var charUser in CharUserName)
                    {
                        if (Char.IsWhiteSpace(charUser))
                            return new Response
                            {
                                ResultCode = Constant.RETURN_CODE_ERROR,
                                Message = "USER_NAME không được có khoảng trắng !"
                            };
                    }

                    if (string.IsNullOrEmpty(info.FUNCTION_NAME))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "FUNCTION_NAME không được để trống !"
                        };
                    }

                    if (string.IsNullOrEmpty(info.MASTER_DATA))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "MASTER_DATA không được để trống !"
                        };
                    }

                    if (info.TIME == null)
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "TIME không được để trống !"
                        };
                    }

                    if (string.IsNullOrEmpty(info.DATA_VOLUME))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "DATA_VOLUME không được để trống !"
                        };
                    }

                    LOG_XL_HANG_LOATInfo obj = new LOG_XL_HANG_LOATInfo();
                    obj.ID = info.ID;
                    obj.USER_NAME = info.USER_NAME;
                    obj.FUNCTION_NAME = info.FUNCTION_NAME;
                    obj.MASTER_DATA = info.MASTER_DATA;
                    obj.TIME = info.TIME;
                    obj.DATA_VOLUME = info.DATA_VOLUME;
                    obj.DETAIL = info.DETAIL;
                    obj.IS_DELETE = info.IS_DELETE;
                    obj.CDATE = info.CDATE;
                    obj.LDATE = info.LDATE;
                    obj.CUSER = info.CUSER;
                    obj.LUSER = info.LUSER;
                    obj.STT = info.STT;

                    CVAN_LOG_SENDMQInfo log = new CVAN_LOG_SENDMQInfo()
                    {
                        Type_Log = (int)Constant.TYPE_OF_LOG.LOG_XU_LY_HANG_LOAT,
                        Log_Value = JsonConvert.SerializeObject(obj)
                    };

                    string LOG_XU_LY_HANG_LOAT_JSON = JsonConvert.SerializeObject(log);
                    byte[] data = Encoding.UTF8.GetBytes(LOG_XU_LY_HANG_LOAT_JSON);
                    var result = MQProcess.SendDataToMQ(data, Config.CMCLIS_LOG_INFO);
                    return new Response
                    {
                        ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result > 0 ? Constant.MESSAGE_SUCCESS_ADD : Constant.MESSAGE_ERROR_ADD,
                        ReturnValue = result.ToString()
                    };
                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR_ADD + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_XL_HANG_LOAT theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ResponseInfo<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetInfo(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    LOG_XL_HANG_LOATInfo result = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().GetInfo(int.Parse(ID));
                    return new ResponseInfo<LOG_XL_HANG_LOATInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        TotalRecords = result != null ? 1 : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseInfo<LOG_XL_HANG_LOATInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<LOG_XL_HANG_LOATInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_XL_HANG_LOAT theo điều kiện
        /// </summary>
        /// <param name="USER_NAME"></param>
        /// <param name="FUNCTION_NAME"></param>
        /// <param name="TIME_START_DATE"></param>
        /// <param name="TIME_END_DATE"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ResponsePage<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetAllWithPadding(string USER_NAME, string FUNCTION_NAME, string TIME_START_DATE, string TIME_END_DATE, string pageIndex, string pageSize)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalRecords = 0;
                    USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
                    FUNCTION_NAME = FUNCTION_NAME == "-1" ? string.Empty : FUNCTION_NAME;
                    //DateTime _TIME_START_DATE = TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(TIME_START_DATE.Split('-')[2]), int.Parse(TIME_START_DATE.Split('-')[1]), int.Parse(TIME_START_DATE.Split('-')[0]), 0, 0, 0);
                    //DateTime _TIME_END_DATE = TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(TIME_END_DATE.Split('-')[2]), int.Parse(TIME_END_DATE.Split('-')[1]), int.Parse(TIME_END_DATE.Split('-')[0]), 23, 59, 59);

                    DateTime? _TIME_START_DATE = null;
                    if (TIME_START_DATE != "-1")
                    {
                        TIME_START_DATE += " " + "00:00:00";
                        _TIME_START_DATE = DateTime.ParseExact(TIME_START_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    }
                    DateTime? _TIME_END_DATE = null;
                    if (TIME_END_DATE != "-1")
                    {
                        TIME_END_DATE += " " + "23:59:59";
                        _TIME_END_DATE = DateTime.ParseExact(TIME_END_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    List<LOG_XL_HANG_LOATInfo> result = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().LOG_XL_HANG_LOAT_QuerySolr_GetAllWithPadding(string.Empty, USER_NAME, FUNCTION_NAME, _TIME_START_DATE, _TIME_END_DATE, 0, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
                    return new ResponsePage<LOG_XL_HANG_LOATInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = result != null ? totalRecords : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponsePage<LOG_XL_HANG_LOATInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponsePage<LOG_XL_HANG_LOATInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    PageIndex = int.Parse(pageIndex),
                    PageSize = int.Parse(pageSize),
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        #endregion
        #region Create Functions "LOG_XL_QUY_TRINH"

        /// <summary>
        /// hthang: Thêm mới thông tin vào bảng LOG_XL_QUY_TRINH
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Response LOG_XL_QUY_TRINH_Add(LOG_XL_QUY_TRINHInfo info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    if (string.IsNullOrEmpty(info.USER_NAME))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "USER_NAME không được để trống !"
                        };
                    }

                    var CharUserName = info.USER_NAME.ToCharArray();
                    foreach (var charUser in CharUserName)
                    {
                        if (Char.IsWhiteSpace(charUser))
                            return new Response
                            {
                                ResultCode = Constant.RETURN_CODE_ERROR,
                                Message = "USER_NAME không được có khoảng trắng !"
                            };
                    }

                    if (string.IsNullOrEmpty(info.STEP))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "STEP không được để trống !"
                        };
                    }

                    if (info.LOG_TIME == null)
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "LOG_TIME không được để trống !"
                        };
                    }

                    if (string.IsNullOrEmpty(info.ACTION))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "ACTION không được để trống !"
                        };
                    }

                    if (info.START_TIME == null)
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "START_TIME không được để trống !"
                        };
                    }

                    if (info.END_TIME == null)
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "END_TIME không được để trống !"
                        };
                    }

                    LOG_XL_QUY_TRINHInfo obj = new LOG_XL_QUY_TRINHInfo();
                    obj.ID = info.ID;
                    obj.USER_NAME = info.USER_NAME;
                    obj.STEP = info.STEP;
                    obj.LOG_TIME = info.LOG_TIME;
                    obj.ACTION = info.ACTION;
                    obj.START_TIME = info.START_TIME;
                    obj.END_TIME = info.END_TIME;
                    obj.DESCRIPTION = info.DESCRIPTION;
                    obj.IS_DELETE = info.IS_DELETE;
                    obj.CDATE = info.CDATE;
                    obj.LDATE = info.LDATE;
                    obj.CUSER = info.CUSER;
                    obj.LUSER = info.LUSER;

                    CVAN_LOG_SENDMQInfo log = new CVAN_LOG_SENDMQInfo()
                    {
                        Type_Log = (int)Constant.TYPE_OF_LOG.LOG_XU_LY_QUY_TRINH,
                        Log_Value = JsonConvert.SerializeObject(obj)
                    };

                    string LOG_XU_LY_QUY_TRINH_JSON = JsonConvert.SerializeObject(log);
                    byte[] data = Encoding.UTF8.GetBytes(LOG_XU_LY_QUY_TRINH_JSON);
                    var result = MQProcess.SendDataToMQ(data, Config.CMCLIS_LOG_INFO);
                    return new Response
                    {
                        ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result > 0 ? Constant.MESSAGE_SUCCESS_ADD : Constant.MESSAGE_ERROR_ADD,
                        ReturnValue = result.ToString()
                    };
                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR_ADD + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_XL_QUY_TRINH theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ResponseInfo<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetInfo(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    LOG_XL_QUY_TRINHInfo result = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().GetInfo(int.Parse(ID));
                    return new ResponseInfo<LOG_XL_QUY_TRINHInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        TotalRecords = result != null ? 1 : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseInfo<LOG_XL_QUY_TRINHInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<LOG_XL_QUY_TRINHInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        /// <summary>
        /// hthang: Tra cứu thông tin từ bảng LOG_XL_QUY_TRINH theo điều kiện
        /// </summary>
        /// <param name="USER_NAME"></param>
        /// <param name="STEP"></param>
        /// <param name="LOG_TIME_START_DATE"></param>
        /// <param name="LOG_TIME_END_DATE"></param>
        /// <param name="ACTION"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ResponsePage<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetAllWithPadding(string USER_NAME, string STEP, string LOG_TIME_START_DATE, string LOG_TIME_END_DATE, string ACTION, string pageIndex, string pageSize)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalRecords = 0;
                    USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
                    STEP = STEP == "-1" ? string.Empty : STEP;
                    //DateTime _LOG_TIME_START_DATE = LOG_TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(LOG_TIME_START_DATE.Split('-')[2]), int.Parse(LOG_TIME_START_DATE.Split('-')[1]), int.Parse(LOG_TIME_START_DATE.Split('-')[0]), 0, 0, 0);
                    //DateTime _LOG_TIME_END_DATE = LOG_TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(LOG_TIME_END_DATE.Split('-')[2]), int.Parse(LOG_TIME_END_DATE.Split('-')[1]), int.Parse(LOG_TIME_END_DATE.Split('-')[0]), 23, 59, 59);

                    DateTime? _LOG_TIME_START_DATE = null;
                    if (LOG_TIME_START_DATE != "-1")
                    {
                        LOG_TIME_START_DATE += " " + "00:00:00";
                        _LOG_TIME_START_DATE = DateTime.ParseExact(LOG_TIME_START_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    }
                    DateTime? _LOG_TIME_END_DATE = null;
                    if (LOG_TIME_END_DATE != "-1")
                    {
                        LOG_TIME_END_DATE += " " + "23:59:59";
                        _LOG_TIME_END_DATE = DateTime.ParseExact(LOG_TIME_END_DATE, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    ACTION = ACTION == "-1" ? string.Empty : ACTION;
                    List<LOG_XL_QUY_TRINHInfo> result = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().LOG_XL_QUY_TRINH_QuerySolr_GetAllWithPadding(string.Empty, USER_NAME, STEP, _LOG_TIME_START_DATE, _LOG_TIME_END_DATE, ACTION, 0, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
                    return new ResponsePage<LOG_XL_QUY_TRINHInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = result != null ? totalRecords : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponsePage<LOG_XL_QUY_TRINHInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponsePage<LOG_XL_QUY_TRINHInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    PageIndex = int.Parse(pageIndex),
                    PageSize = int.Parse(pageSize),
                    TotalRecords = 0,
                    Data = null
                };
            }
        }

        #endregion

    }
}
