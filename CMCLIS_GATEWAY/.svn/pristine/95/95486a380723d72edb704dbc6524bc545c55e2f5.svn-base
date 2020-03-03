using Aspose.Cells;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.CORE.Redis;
using CMCLIS.GATEWAY.CORE.Sercurity;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.SETTING;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Web;

namespace CMCLIS.GATEWAY.SERVICES
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class API_TIM_KIEM : IAPI_TIM_KIEM
    {
        private static string Authorization = string.Empty;
        protected API_TIM_KIEM()
        {
            var request = OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            Authorization = request.Headers[Config.API_KEY];
            if (string.IsNullOrEmpty(Authorization))
            {
                Authorization = Config.KEY_AUTHORIZATION;
            }

        }

        #region Create Functions "SHARE_DD_MO_TD"
        public Response SHARE_DD_MO_TD_Add(SHARE_DD_MO_TDInfo info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int result = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().Add(info);
                    if (result == 0)
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_WARNING,
                            Message = Constant.MESSAGE_ERROR_EXIST,
                            ReturnValue = result.ToString()
                        };
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
        public Response SHARE_DD_MO_TD_Update(SHARE_DD_MO_TDInfo info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int result = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().Update(info);
                    return new Response
                    {
                        ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result > 0 ? Constant.MESSAGE_SUCCESS_UPDATE : Constant.MESSAGE_ERROR_UPDATE,
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
                    Message = Constant.MESSAGE_ERROR_UPDATE + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }
        public Response SHARE_DD_MO_TD_Delete(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int result = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().Delete(int.Parse(ID));
                    return new Response
                    {
                        ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result > 0 ? Constant.MESSAGE_SUCCESS_DELETE : Constant.MESSAGE_ERROR_DELETE,
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
                    Message = Constant.MESSAGE_ERROR_DELETE + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }
        public ResponseInfo<SHARE_DD_MO_TDInfo> SHARE_DD_MO_TD_GetInfo(string ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    SHARE_DD_MO_TDInfo result = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().GetInfo(int.Parse(ID));
                    return new ResponseInfo<SHARE_DD_MO_TDInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        TotalRecords = result != null ? 1 : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseInfo<SHARE_DD_MO_TDInfo>
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
                return new ResponseInfo<SHARE_DD_MO_TDInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    TotalRecords = 0,
                    Data = null
                };
            }
        }
        public ResponseList<SHARE_DD_MO_TDInfo> SHARE_DD_MO_TD_GetList()
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    List<SHARE_DD_MO_TDInfo> result = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().GetList();
                    return new ResponseList<SHARE_DD_MO_TDInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        TotalRecords = result != null ? result.Count : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseList<SHARE_DD_MO_TDInfo>
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
                return new ResponseList<SHARE_DD_MO_TDInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    TotalRecords = 0,
                    Data = null
                };
            }
        }
        public ResponsePage<SHARE_DD_MO_TDInfo> SHARE_DD_MO_TD_GetAllWithPadding(string MA_DVI, string LOAIDAT, string SOTOGOC, string SOTOCU, string SOTHUACU, string MAKVUC, string MAHUYEN, string MAXA, string SOTO, string SOTHUA, string IS_DELETE, string pageIndex, string pageSize)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalRecords = 0;
                    MA_DVI = MA_DVI == "-1" ? string.Empty : MA_DVI;
                    LOAIDAT = LOAIDAT == "-1" ? string.Empty : LOAIDAT;
                    SOTOGOC = SOTOGOC == "-1" ? string.Empty : SOTOGOC;
                    SOTOCU = SOTOCU == "-1" ? string.Empty : SOTOCU;
                    SOTHUACU = SOTHUACU == "-1" ? string.Empty : SOTHUACU;
                    MAKVUC = MAKVUC == "-1" ? string.Empty : MAKVUC;
                    MAHUYEN = MAHUYEN == "-1" ? string.Empty : MAHUYEN;
                    MAXA = MAXA == "-1" ? string.Empty : MAXA;
                    List<SHARE_DD_MO_TDInfo> result = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().SHARE_DD_MO_TD_GetAllWithPadding(MA_DVI, LOAIDAT, SOTOGOC, SOTOCU, SOTHUACU, MAKVUC, MAHUYEN, MAXA, decimal.Parse(SOTO), decimal.Parse(SOTHUA), int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
                    return new ResponsePage<SHARE_DD_MO_TDInfo>
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
                    return new ResponsePage<SHARE_DD_MO_TDInfo>
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
                return new ResponsePage<SHARE_DD_MO_TDInfo>
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
        public Response SHARE_DD_MO_TD_EXPORT_TEMPLATE(string extension)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    string pathFileExcel = string.Empty;
                    string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/SHARE_DD_MO_TD_EXPORT_TEMPLATE.xlsx";
                    if (File.Exists(designerFile))
                    {
                        var designer = new WorkbookDesigner();
                        var loadOptions = new LoadOptions(LoadFormat.Xlsx);
                        designer.Workbook = new Workbook(designerFile, loadOptions);
                        designer.Process();
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
                        }
                        switch (extension.ToLower())
                        {
                            case "xls":
                                pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "SHARE_DD_MO_TD_EXPORT_TEMPLATE");
                                designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
                                break;
                            case "xlsx":
                                pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "SHARE_DD_MO_TD_EXPORT_TEMPLATE");
                                designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
                                break;
                        }
                    }
                    return new Response
                    {
                        ResultCode = !string.IsNullOrEmpty(pathFileExcel) ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = !string.IsNullOrEmpty(pathFileExcel) ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        ReturnValue = "/Services" + pathFileExcel
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
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }
        public Response SHARE_DD_MO_TD_EXPORT_DATA(string MA_DVI, string LOAIDAT, string SOTOGOC, string SOTOCU, string SOTHUACU, string MAKVUC, string MAHUYEN, string MAXA, string SOTO, string SOTHUA, string IS_DELETE, string extension)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    string pathFileExcel = string.Empty;
                    string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/SHARE_DD_MO_TD_EXPORT_DATA.xlsx";
                    if (File.Exists(designerFile))
                    {
                        int totalRecords = 0;
                        MA_DVI = MA_DVI == "-1" ? string.Empty : MA_DVI;
                        LOAIDAT = LOAIDAT == "-1" ? string.Empty : LOAIDAT;
                        SOTOGOC = SOTOGOC == "-1" ? string.Empty : SOTOGOC;
                        SOTOCU = SOTOCU == "-1" ? string.Empty : SOTOCU;
                        SOTHUACU = SOTHUACU == "-1" ? string.Empty : SOTHUACU;
                        MAKVUC = MAKVUC == "-1" ? string.Empty : MAKVUC;
                        MAHUYEN = MAHUYEN == "-1" ? string.Empty : MAHUYEN;
                        MAXA = MAXA == "-1" ? string.Empty : MAXA;
                        List<SHARE_DD_MO_TDInfo> resultSHARE_DD_MO_TD = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().SHARE_DD_MO_TD_GetAllWithPadding(MA_DVI, LOAIDAT, SOTOGOC, SOTOCU, SOTHUACU, MAKVUC, MAHUYEN, MAXA, decimal.Parse(SOTO), decimal.Parse(SOTHUA), int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
                        var designer = new WorkbookDesigner();
                        var loadOptions = new LoadOptions(LoadFormat.Xlsx);
                        designer.Workbook = new Workbook(designerFile, loadOptions);
                        DataTable dataTableSHARE_DD_MO_TD = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().ToDataTable(resultSHARE_DD_MO_TD);
                        designer.SetDataSource("SHARE_DD_MO_TD", dataTableSHARE_DD_MO_TD.DefaultView);
                        designer.Process();
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
                        }
                        switch (extension.ToLower())
                        {
                            case "xls":
                                pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "SHARE_DD_MO_TD_EXPORT_DATA");
                                designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
                                break;
                            case "xlsx":
                                pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "SHARE_DD_MO_TD_EXPORT_DATA");
                                designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
                                break;
                            case "pdf":
                                pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "SHARE_DD_MO_TD_EXPORT_DATA");
                                designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Pdf);
                                break;
                        }
                    }
                    return new Response
                    {
                        ResultCode = !string.IsNullOrEmpty(pathFileExcel) ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = !string.IsNullOrEmpty(pathFileExcel) ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        ReturnValue = "/Services" + pathFileExcel
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
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }

        #endregion
    }
}
