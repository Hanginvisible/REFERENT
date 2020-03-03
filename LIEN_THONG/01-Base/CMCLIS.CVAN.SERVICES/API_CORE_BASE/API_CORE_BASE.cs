using Aspose.Cells;
using CMCLIS.CVAN.CORE;
using CMCLIS.CVAN.DATA.OBJECTS;
using CMCLIS.CVAN.ENTITY;
using CMCLIS.CVAN.SETTING;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Web;

namespace CTS.GATEWAY.SERVICES
{
    //------------------------------------------------------------------------------------------------------------------------
    //-- Created By: Ngô Văn Nghị
    //-- Date: 01/05/2020 12:36:37 AM
    //-- Todo: 
    //------------------------------------------------------------------------------------------------------------------------ 
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class API_CORE_BASE : IAPI_CORE_BASE
    {
        private static string Authorization = string.Empty;
        protected API_CORE_BASE()
        {      
            var request = OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            Authorization = request.Headers[Config.API_KEY];
            if (string.IsNullOrEmpty(Authorization))
            {
				Authorization = Config.KEY_AUTHORIZATION;
                //string hostReferer = request.Headers[Constant.API_KEY];
                //string[] arrListHost = Config.LIST_HOST_REFERER;
                //List<object> list = arrListHost.Cast<Object>().ToList();
                //if (list.IndexOf((object)hostReferer) != -1)
                //    Authorization = Config.KEY_AUTHORIZATION;
            }
        }
       
		#region Create Functions "CLIENT_SENDER"
		public Response CLIENT_SENDER_Add(CLIENT_SENDERInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCLIENT_SENDER().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response CLIENT_SENDER_Update(CLIENT_SENDERInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCLIENT_SENDER().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response CLIENT_SENDER_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCLIENT_SENDER().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<CLIENT_SENDERInfo> CLIENT_SENDER_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CLIENT_SENDERInfo result = DataObjectFactory.GetInstanceCLIENT_SENDER().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CLIENT_SENDERInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CLIENT_SENDERInfo>
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
				return new ResponseInfo<CLIENT_SENDERInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CLIENT_SENDERInfo> CLIENT_SENDER_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CLIENT_SENDERInfo> result = DataObjectFactory.GetInstanceCLIENT_SENDER().GetList();
				    return new ResponseList<CLIENT_SENDERInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CLIENT_SENDERInfo>
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
				return new ResponseList<CLIENT_SENDERInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CLIENT_SENDERInfo> CLIENT_SENDER_GetAllWithPadding(string  CLIENT_CODE,string  CLIENT_NAME,string  CLIENT_TYPE,string  CLIENT_DOMAIN,string STATUS, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CLIENT_CODE = CLIENT_CODE == "-1" ? string.Empty : CLIENT_CODE;
		                CLIENT_NAME = CLIENT_NAME == "-1" ? string.Empty : CLIENT_NAME;
		                CLIENT_TYPE = CLIENT_TYPE == "-1" ? string.Empty : CLIENT_TYPE;
		                CLIENT_DOMAIN = CLIENT_DOMAIN == "-1" ? string.Empty : CLIENT_DOMAIN;
				    List<CLIENT_SENDERInfo> result = DataObjectFactory.GetInstanceCLIENT_SENDER().CLIENT_SENDER_GetAllWithPadding(CLIENT_CODE,CLIENT_NAME,CLIENT_TYPE,CLIENT_DOMAIN,int.Parse(STATUS), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CLIENT_SENDERInfo>
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
				    return new ResponsePage<CLIENT_SENDERInfo>
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
				return new ResponsePage<CLIENT_SENDERInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response CLIENT_SENDER_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CLIENT_SENDER_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CLIENT_SENDER_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CLIENT_SENDER_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response CLIENT_SENDER_EXPORT_DATA(string  CLIENT_CODE,string  CLIENT_NAME,string  CLIENT_TYPE,string  CLIENT_DOMAIN,string STATUS, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CLIENT_SENDER_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CLIENT_CODE = CLIENT_CODE == "-1" ? string.Empty : CLIENT_CODE;
		                CLIENT_NAME = CLIENT_NAME == "-1" ? string.Empty : CLIENT_NAME;
		                CLIENT_TYPE = CLIENT_TYPE == "-1" ? string.Empty : CLIENT_TYPE;
		                CLIENT_DOMAIN = CLIENT_DOMAIN == "-1" ? string.Empty : CLIENT_DOMAIN;
		                List<CLIENT_SENDERInfo> resultCLIENT_SENDER = DataObjectFactory.GetInstanceCLIENT_SENDER().CLIENT_SENDER_GetAllWithPadding(CLIENT_CODE,CLIENT_NAME,CLIENT_TYPE,CLIENT_DOMAIN,int.Parse(STATUS), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCLIENT_SENDER = DataObjectFactory.GetInstanceCLIENT_SENDER().ToDataTable(resultCLIENT_SENDER);
		                designer.SetDataSource("CLIENT_SENDER", dataTableCLIENT_SENDER.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CLIENT_SENDER_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CLIENT_SENDER_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CLIENT_SENDER_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
		#region Create Functions "CONFIG"
		public Response CONFIG_Add(CONFIGInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCONFIG().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response CONFIG_Update(CONFIGInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCONFIG().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response CONFIG_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCONFIG().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<CONFIGInfo> CONFIG_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CONFIGInfo result = DataObjectFactory.GetInstanceCONFIG().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CONFIGInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CONFIGInfo>
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
				return new ResponseInfo<CONFIGInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CONFIGInfo> CONFIG_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CONFIGInfo> result = DataObjectFactory.GetInstanceCONFIG().GetList();
				    return new ResponseList<CONFIGInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CONFIGInfo>
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
				return new ResponseList<CONFIGInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CONFIGInfo> CONFIG_GetAllWithPadding(string  CONFIG_KEY,string  CONFIG_VALUE,string  CONFIG_TYPE,string STATUS, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CONFIG_KEY = CONFIG_KEY == "-1" ? string.Empty : CONFIG_KEY;
		                CONFIG_VALUE = CONFIG_VALUE == "-1" ? string.Empty : CONFIG_VALUE;
		                CONFIG_TYPE = CONFIG_TYPE == "-1" ? string.Empty : CONFIG_TYPE;
				    List<CONFIGInfo> result = DataObjectFactory.GetInstanceCONFIG().CONFIG_GetAllWithPadding(CONFIG_KEY,CONFIG_VALUE,CONFIG_TYPE,int.Parse(STATUS), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CONFIGInfo>
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
				    return new ResponsePage<CONFIGInfo>
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
				return new ResponsePage<CONFIGInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response CONFIG_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CONFIG_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CONFIG_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CONFIG_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response CONFIG_EXPORT_DATA(string  CONFIG_KEY,string  CONFIG_VALUE,string  CONFIG_TYPE,string STATUS, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CONFIG_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CONFIG_KEY = CONFIG_KEY == "-1" ? string.Empty : CONFIG_KEY;
		                CONFIG_VALUE = CONFIG_VALUE == "-1" ? string.Empty : CONFIG_VALUE;
		                CONFIG_TYPE = CONFIG_TYPE == "-1" ? string.Empty : CONFIG_TYPE;
		                List<CONFIGInfo> resultCONFIG = DataObjectFactory.GetInstanceCONFIG().CONFIG_GetAllWithPadding(CONFIG_KEY,CONFIG_VALUE,CONFIG_TYPE,int.Parse(STATUS), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCONFIG = DataObjectFactory.GetInstanceCONFIG().ToDataTable(resultCONFIG);
		                designer.SetDataSource("CONFIG", dataTableCONFIG.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CONFIG_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CONFIG_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CONFIG_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
		#region Create Functions "CONFIG_MESSAGE"
		public Response CONFIG_MESSAGE_Add(CONFIG_MESSAGEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCONFIG_MESSAGE().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response CONFIG_MESSAGE_Update(CONFIG_MESSAGEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCONFIG_MESSAGE().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response CONFIG_MESSAGE_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCONFIG_MESSAGE().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<CONFIG_MESSAGEInfo> CONFIG_MESSAGE_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CONFIG_MESSAGEInfo result = DataObjectFactory.GetInstanceCONFIG_MESSAGE().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CONFIG_MESSAGEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CONFIG_MESSAGEInfo>
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
				return new ResponseInfo<CONFIG_MESSAGEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CONFIG_MESSAGEInfo> CONFIG_MESSAGE_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CONFIG_MESSAGEInfo> result = DataObjectFactory.GetInstanceCONFIG_MESSAGE().GetList();
				    return new ResponseList<CONFIG_MESSAGEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CONFIG_MESSAGEInfo>
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
				return new ResponseList<CONFIG_MESSAGEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CONFIG_MESSAGEInfo> CONFIG_MESSAGE_GetAllWithPadding(string  MESSAGE_CODE,string  MESSAGE_NAME,string  KEY_CODE,string  TARGET_COLUMN_NAME,string STATUS, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                MESSAGE_CODE = MESSAGE_CODE == "-1" ? string.Empty : MESSAGE_CODE;
		                MESSAGE_NAME = MESSAGE_NAME == "-1" ? string.Empty : MESSAGE_NAME;
		                KEY_CODE = KEY_CODE == "-1" ? string.Empty : KEY_CODE;
		                TARGET_COLUMN_NAME = TARGET_COLUMN_NAME == "-1" ? string.Empty : TARGET_COLUMN_NAME;
				    List<CONFIG_MESSAGEInfo> result = DataObjectFactory.GetInstanceCONFIG_MESSAGE().CONFIG_MESSAGE_GetAllWithPadding(MESSAGE_CODE,MESSAGE_NAME,KEY_CODE,TARGET_COLUMN_NAME,int.Parse(STATUS), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CONFIG_MESSAGEInfo>
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
				    return new ResponsePage<CONFIG_MESSAGEInfo>
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
				return new ResponsePage<CONFIG_MESSAGEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response CONFIG_MESSAGE_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CONFIG_MESSAGE_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CONFIG_MESSAGE_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CONFIG_MESSAGE_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response CONFIG_MESSAGE_EXPORT_DATA(string  MESSAGE_CODE,string  MESSAGE_NAME,string  KEY_CODE,string  TARGET_COLUMN_NAME,string STATUS, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CONFIG_MESSAGE_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                MESSAGE_CODE = MESSAGE_CODE == "-1" ? string.Empty : MESSAGE_CODE;
		                MESSAGE_NAME = MESSAGE_NAME == "-1" ? string.Empty : MESSAGE_NAME;
		                KEY_CODE = KEY_CODE == "-1" ? string.Empty : KEY_CODE;
		                TARGET_COLUMN_NAME = TARGET_COLUMN_NAME == "-1" ? string.Empty : TARGET_COLUMN_NAME;
		                List<CONFIG_MESSAGEInfo> resultCONFIG_MESSAGE = DataObjectFactory.GetInstanceCONFIG_MESSAGE().CONFIG_MESSAGE_GetAllWithPadding(MESSAGE_CODE,MESSAGE_NAME,KEY_CODE,TARGET_COLUMN_NAME,int.Parse(STATUS), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCONFIG_MESSAGE = DataObjectFactory.GetInstanceCONFIG_MESSAGE().ToDataTable(resultCONFIG_MESSAGE);
		                designer.SetDataSource("CONFIG_MESSAGE", dataTableCONFIG_MESSAGE.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CONFIG_MESSAGE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CONFIG_MESSAGE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CONFIG_MESSAGE_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
		#region Create Functions "DM_API_SERVICE"
		public Response DM_API_SERVICE_Add(DM_API_SERVICEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_API_SERVICE().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response DM_API_SERVICE_Update(DM_API_SERVICEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_API_SERVICE().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response DM_API_SERVICE_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_API_SERVICE().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<DM_API_SERVICEInfo> DM_API_SERVICE_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    DM_API_SERVICEInfo result = DataObjectFactory.GetInstanceDM_API_SERVICE().GetInfo(int.Parse(ID));
				    return new ResponseInfo<DM_API_SERVICEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<DM_API_SERVICEInfo>
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
				return new ResponseInfo<DM_API_SERVICEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<DM_API_SERVICEInfo> DM_API_SERVICE_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<DM_API_SERVICEInfo> result = DataObjectFactory.GetInstanceDM_API_SERVICE().GetList();
				    return new ResponseList<DM_API_SERVICEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<DM_API_SERVICEInfo>
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
				return new ResponseList<DM_API_SERVICEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<DM_API_SERVICEInfo> DM_API_SERVICE_GetAllWithPadding(string  CODE,string  NAME,string STATUS, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                NAME = NAME == "-1" ? string.Empty : NAME;
				    List<DM_API_SERVICEInfo> result = DataObjectFactory.GetInstanceDM_API_SERVICE().DM_API_SERVICE_GetAllWithPadding(CODE,NAME,int.Parse(STATUS), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<DM_API_SERVICEInfo>
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
				    return new ResponsePage<DM_API_SERVICEInfo>
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
				return new ResponsePage<DM_API_SERVICEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response DM_API_SERVICE_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/DM_API_SERVICE_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "DM_API_SERVICE_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "DM_API_SERVICE_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response DM_API_SERVICE_EXPORT_DATA(string  CODE,string  NAME,string STATUS, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/DM_API_SERVICE_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                NAME = NAME == "-1" ? string.Empty : NAME;
		                List<DM_API_SERVICEInfo> resultDM_API_SERVICE = DataObjectFactory.GetInstanceDM_API_SERVICE().DM_API_SERVICE_GetAllWithPadding(CODE,NAME,int.Parse(STATUS), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableDM_API_SERVICE = DataObjectFactory.GetInstanceDM_API_SERVICE().ToDataTable(resultDM_API_SERVICE);
		                designer.SetDataSource("DM_API_SERVICE", dataTableDM_API_SERVICE.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "DM_API_SERVICE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "DM_API_SERVICE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "DM_API_SERVICE_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
		#region Create Functions "DM_MESSAGE"
		public Response DM_MESSAGE_Add(DM_MESSAGEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_MESSAGE().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response DM_MESSAGE_Update(DM_MESSAGEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_MESSAGE().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response DM_MESSAGE_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_MESSAGE().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<DM_MESSAGEInfo> DM_MESSAGE_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    DM_MESSAGEInfo result = DataObjectFactory.GetInstanceDM_MESSAGE().GetInfo(int.Parse(ID));
				    return new ResponseInfo<DM_MESSAGEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<DM_MESSAGEInfo>
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
				return new ResponseInfo<DM_MESSAGEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<DM_MESSAGEInfo> DM_MESSAGE_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<DM_MESSAGEInfo> result = DataObjectFactory.GetInstanceDM_MESSAGE().GetList();
				    return new ResponseList<DM_MESSAGEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<DM_MESSAGEInfo>
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
				return new ResponseList<DM_MESSAGEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<DM_MESSAGEInfo> DM_MESSAGE_GetAllWithPadding(string  CODE,string  MESSAGE_NAME,string  PARENT_CODE,string STATUS, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                MESSAGE_NAME = MESSAGE_NAME == "-1" ? string.Empty : MESSAGE_NAME;
		                PARENT_CODE = PARENT_CODE == "-1" ? string.Empty : PARENT_CODE;
				    List<DM_MESSAGEInfo> result = DataObjectFactory.GetInstanceDM_MESSAGE().DM_MESSAGE_GetAllWithPadding(CODE,MESSAGE_NAME,PARENT_CODE,int.Parse(STATUS), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<DM_MESSAGEInfo>
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
				    return new ResponsePage<DM_MESSAGEInfo>
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
				return new ResponsePage<DM_MESSAGEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response DM_MESSAGE_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/DM_MESSAGE_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "DM_MESSAGE_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "DM_MESSAGE_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response DM_MESSAGE_EXPORT_DATA(string  CODE,string  MESSAGE_NAME,string  PARENT_CODE,string STATUS, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/DM_MESSAGE_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                MESSAGE_NAME = MESSAGE_NAME == "-1" ? string.Empty : MESSAGE_NAME;
		                PARENT_CODE = PARENT_CODE == "-1" ? string.Empty : PARENT_CODE;
		                List<DM_MESSAGEInfo> resultDM_MESSAGE = DataObjectFactory.GetInstanceDM_MESSAGE().DM_MESSAGE_GetAllWithPadding(CODE,MESSAGE_NAME,PARENT_CODE,int.Parse(STATUS), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableDM_MESSAGE = DataObjectFactory.GetInstanceDM_MESSAGE().ToDataTable(resultDM_MESSAGE);
		                designer.SetDataSource("DM_MESSAGE", dataTableDM_MESSAGE.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "DM_MESSAGE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "DM_MESSAGE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "DM_MESSAGE_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
		#region Create Functions "DM_MESSAGE_STATUS"
		public Response DM_MESSAGE_STATUS_Add(DM_MESSAGE_STATUSInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_MESSAGE_STATUS().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response DM_MESSAGE_STATUS_Update(DM_MESSAGE_STATUSInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_MESSAGE_STATUS().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response DM_MESSAGE_STATUS_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceDM_MESSAGE_STATUS().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<DM_MESSAGE_STATUSInfo> DM_MESSAGE_STATUS_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    DM_MESSAGE_STATUSInfo result = DataObjectFactory.GetInstanceDM_MESSAGE_STATUS().GetInfo(int.Parse(ID));
				    return new ResponseInfo<DM_MESSAGE_STATUSInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<DM_MESSAGE_STATUSInfo>
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
				return new ResponseInfo<DM_MESSAGE_STATUSInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<DM_MESSAGE_STATUSInfo> DM_MESSAGE_STATUS_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<DM_MESSAGE_STATUSInfo> result = DataObjectFactory.GetInstanceDM_MESSAGE_STATUS().GetList();
				    return new ResponseList<DM_MESSAGE_STATUSInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<DM_MESSAGE_STATUSInfo>
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
				return new ResponseList<DM_MESSAGE_STATUSInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<DM_MESSAGE_STATUSInfo> DM_MESSAGE_STATUS_GetAllWithPadding(string  CODE,string  NAME,string  PARENT_CODE,string STATUS, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                NAME = NAME == "-1" ? string.Empty : NAME;
		                PARENT_CODE = PARENT_CODE == "-1" ? string.Empty : PARENT_CODE;
				    List<DM_MESSAGE_STATUSInfo> result = DataObjectFactory.GetInstanceDM_MESSAGE_STATUS().DM_MESSAGE_STATUS_GetAllWithPadding(CODE,NAME,PARENT_CODE,int.Parse(STATUS), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<DM_MESSAGE_STATUSInfo>
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
				    return new ResponsePage<DM_MESSAGE_STATUSInfo>
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
				return new ResponsePage<DM_MESSAGE_STATUSInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response DM_MESSAGE_STATUS_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/DM_MESSAGE_STATUS_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "DM_MESSAGE_STATUS_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "DM_MESSAGE_STATUS_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response DM_MESSAGE_STATUS_EXPORT_DATA(string  CODE,string  NAME,string  PARENT_CODE,string STATUS, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/DM_MESSAGE_STATUS_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                NAME = NAME == "-1" ? string.Empty : NAME;
		                PARENT_CODE = PARENT_CODE == "-1" ? string.Empty : PARENT_CODE;
		                List<DM_MESSAGE_STATUSInfo> resultDM_MESSAGE_STATUS = DataObjectFactory.GetInstanceDM_MESSAGE_STATUS().DM_MESSAGE_STATUS_GetAllWithPadding(CODE,NAME,PARENT_CODE,int.Parse(STATUS), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableDM_MESSAGE_STATUS = DataObjectFactory.GetInstanceDM_MESSAGE_STATUS().ToDataTable(resultDM_MESSAGE_STATUS);
		                designer.SetDataSource("DM_MESSAGE_STATUS", dataTableDM_MESSAGE_STATUS.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "DM_MESSAGE_STATUS_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "DM_MESSAGE_STATUS_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "DM_MESSAGE_STATUS_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
		#region Create Functions "LOG_ERROR"
		public Response LOG_ERROR_Add(LOG_ERRORInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_ERROR().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response LOG_ERROR_Update(LOG_ERRORInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_ERROR().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response LOG_ERROR_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_ERROR().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<LOG_ERRORInfo> LOG_ERROR_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    LOG_ERRORInfo result = DataObjectFactory.GetInstanceLOG_ERROR().GetInfo(int.Parse(ID));
				    return new ResponseInfo<LOG_ERRORInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<LOG_ERRORInfo>
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
				return new ResponseInfo<LOG_ERRORInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<LOG_ERRORInfo> LOG_ERROR_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<LOG_ERRORInfo> result = DataObjectFactory.GetInstanceLOG_ERROR().GetList();
				    return new ResponseList<LOG_ERRORInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<LOG_ERRORInfo>
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
				return new ResponseList<LOG_ERRORInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<LOG_ERRORInfo> LOG_ERROR_GetAllWithPadding(string  CODE,string  FUNC_NAME,string  TYPE_CODE,string  ERROR_CODE,string CDATE_START_DATE,string CDATE_END_DATE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                FUNC_NAME = FUNC_NAME == "-1" ? string.Empty : FUNC_NAME;
		                TYPE_CODE = TYPE_CODE == "-1" ? string.Empty : TYPE_CODE;
		                ERROR_CODE = ERROR_CODE == "-1" ? string.Empty : ERROR_CODE;
		                DateTime _CDATE_START_DATE = CDATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(CDATE_START_DATE.Split('-')[2]), int.Parse(CDATE_START_DATE.Split('-')[1]), int.Parse(CDATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _CDATE_END_DATE = CDATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(CDATE_END_DATE.Split('-')[2]), int.Parse(CDATE_END_DATE.Split('-')[1]), int.Parse(CDATE_END_DATE.Split('-')[0]), 23, 59, 59);
				    List<LOG_ERRORInfo> result = DataObjectFactory.GetInstanceLOG_ERROR().LOG_ERROR_GetAllWithPadding(CODE,FUNC_NAME,TYPE_CODE,ERROR_CODE,_CDATE_START_DATE, _CDATE_END_DATE, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<LOG_ERRORInfo>
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
				    return new ResponsePage<LOG_ERRORInfo>
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
				return new ResponsePage<LOG_ERRORInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response LOG_ERROR_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_ERROR_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_ERROR_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_ERROR_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response LOG_ERROR_EXPORT_DATA(string  CODE,string  FUNC_NAME,string  TYPE_CODE,string  ERROR_CODE,string CDATE_START_DATE,string CDATE_END_DATE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_ERROR_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                FUNC_NAME = FUNC_NAME == "-1" ? string.Empty : FUNC_NAME;
		                TYPE_CODE = TYPE_CODE == "-1" ? string.Empty : TYPE_CODE;
		                ERROR_CODE = ERROR_CODE == "-1" ? string.Empty : ERROR_CODE;
		                DateTime _CDATE_START_DATE = CDATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(CDATE_START_DATE.Split('-')[2]), int.Parse(CDATE_START_DATE.Split('-')[1]), int.Parse(CDATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _CDATE_END_DATE = CDATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(CDATE_END_DATE.Split('-')[2]), int.Parse(CDATE_END_DATE.Split('-')[1]), int.Parse(CDATE_END_DATE.Split('-')[0]), 23, 59, 59);
		                List<LOG_ERRORInfo> resultLOG_ERROR = DataObjectFactory.GetInstanceLOG_ERROR().LOG_ERROR_GetAllWithPadding(CODE,FUNC_NAME,TYPE_CODE,ERROR_CODE,_CDATE_START_DATE, _CDATE_END_DATE, 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableLOG_ERROR = DataObjectFactory.GetInstanceLOG_ERROR().ToDataTable(resultLOG_ERROR);
		                designer.SetDataSource("LOG_ERROR", dataTableLOG_ERROR.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_ERROR_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_ERROR_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "LOG_ERROR_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
		#region Create Functions "MSGI"
		public Response MSGI_Add(MSGIInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceMSGI().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response MSGI_Update(MSGIInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceMSGI().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response MSGI_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceMSGI().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<MSGIInfo> MSGI_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    MSGIInfo result = DataObjectFactory.GetInstanceMSGI().GetInfo(int.Parse(ID));
				    return new ResponseInfo<MSGIInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<MSGIInfo>
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
				return new ResponseInfo<MSGIInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<MSGIInfo> MSGI_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<MSGIInfo> result = DataObjectFactory.GetInstanceMSGI().GetList();
				    return new ResponseList<MSGIInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<MSGIInfo>
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
				return new ResponseList<MSGIInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<MSGIInfo> MSGI_GetAllWithPadding(string  CODE,string  MESSAGE_CODE,string SEND_DATE_START_DATE,string SEND_DATE_END_DATE,string  SENDER_CODE,string STATUS, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                MESSAGE_CODE = MESSAGE_CODE == "-1" ? string.Empty : MESSAGE_CODE;
		                DateTime _SEND_DATE_START_DATE = SEND_DATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(SEND_DATE_START_DATE.Split('-')[2]), int.Parse(SEND_DATE_START_DATE.Split('-')[1]), int.Parse(SEND_DATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _SEND_DATE_END_DATE = SEND_DATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(SEND_DATE_END_DATE.Split('-')[2]), int.Parse(SEND_DATE_END_DATE.Split('-')[1]), int.Parse(SEND_DATE_END_DATE.Split('-')[0]), 23, 59, 59);
		                SENDER_CODE = SENDER_CODE == "-1" ? string.Empty : SENDER_CODE;
		                STATUS = STATUS == "-1" ? string.Empty : STATUS;
				    List<MSGIInfo> result = DataObjectFactory.GetInstanceMSGI().MSGI_GetAllWithPadding(CODE,MESSAGE_CODE,_SEND_DATE_START_DATE, _SEND_DATE_END_DATE,SENDER_CODE,STATUS, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<MSGIInfo>
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
				    return new ResponsePage<MSGIInfo>
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
				return new ResponsePage<MSGIInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response MSGI_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/MSGI_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "MSGI_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "MSGI_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response MSGI_EXPORT_DATA(string  CODE,string  MESSAGE_CODE,string SEND_DATE_START_DATE,string SEND_DATE_END_DATE,string  SENDER_CODE,string STATUS, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/MSGI_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CODE = CODE == "-1" ? string.Empty : CODE;
		                MESSAGE_CODE = MESSAGE_CODE == "-1" ? string.Empty : MESSAGE_CODE;
		                DateTime _SEND_DATE_START_DATE = SEND_DATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(SEND_DATE_START_DATE.Split('-')[2]), int.Parse(SEND_DATE_START_DATE.Split('-')[1]), int.Parse(SEND_DATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _SEND_DATE_END_DATE = SEND_DATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(SEND_DATE_END_DATE.Split('-')[2]), int.Parse(SEND_DATE_END_DATE.Split('-')[1]), int.Parse(SEND_DATE_END_DATE.Split('-')[0]), 23, 59, 59);
		                SENDER_CODE = SENDER_CODE == "-1" ? string.Empty : SENDER_CODE;
		                STATUS = STATUS == "-1" ? string.Empty : STATUS;
		                List<MSGIInfo> resultMSGI = DataObjectFactory.GetInstanceMSGI().MSGI_GetAllWithPadding(CODE,MESSAGE_CODE,_SEND_DATE_START_DATE, _SEND_DATE_END_DATE,SENDER_CODE,STATUS, 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableMSGI = DataObjectFactory.GetInstanceMSGI().ToDataTable(resultMSGI);
		                designer.SetDataSource("MSGI", dataTableMSGI.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "MSGI_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "MSGI_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "MSGI_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
		#region Create Functions "MSGO"
		public Response MSGO_Add(MSGOInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceMSGO().Add(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_ADD,
				    ReturnValue = "0"
				};
		    }
		}
		public Response MSGO_Update(MSGOInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceMSGO().Update(info);
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_UPDATE,
				    ReturnValue = "0"
				};
		    }
		}
		public Response MSGO_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceMSGO().Delete(int.Parse(ID));
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
						ReturnValue = "0"
				    };
				}
		    }
		    catch (Exception ex)
		    {
				LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
				return new Response
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR_DELETE,
				    ReturnValue = "0"
				};
		    }
		}
		public ResponseInfo<MSGOInfo> MSGO_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    MSGOInfo result = DataObjectFactory.GetInstanceMSGO().GetInfo(int.Parse(ID));
				    return new ResponseInfo<MSGOInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? 1 : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<MSGOInfo>
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
				return new ResponseInfo<MSGOInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<MSGOInfo> MSGO_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<MSGOInfo> result = DataObjectFactory.GetInstanceMSGO().GetList();
				    return new ResponseList<MSGOInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<MSGOInfo>
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
				return new ResponseList<MSGOInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<MSGOInfo> MSGO_GetAllWithPadding(string  MSGI_CODE,string  MESSAGE_CODE,string SEND_DATE_START_DATE,string SEND_DATE_END_DATE,string  SENDER_CODE,string STATUS, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                MSGI_CODE = MSGI_CODE == "-1" ? string.Empty : MSGI_CODE;
		                MESSAGE_CODE = MESSAGE_CODE == "-1" ? string.Empty : MESSAGE_CODE;
		                DateTime _SEND_DATE_START_DATE = SEND_DATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(SEND_DATE_START_DATE.Split('-')[2]), int.Parse(SEND_DATE_START_DATE.Split('-')[1]), int.Parse(SEND_DATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _SEND_DATE_END_DATE = SEND_DATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(SEND_DATE_END_DATE.Split('-')[2]), int.Parse(SEND_DATE_END_DATE.Split('-')[1]), int.Parse(SEND_DATE_END_DATE.Split('-')[0]), 23, 59, 59);
		                SENDER_CODE = SENDER_CODE == "-1" ? string.Empty : SENDER_CODE;
		                STATUS = STATUS == "-1" ? string.Empty : STATUS;
				    List<MSGOInfo> result = DataObjectFactory.GetInstanceMSGO().MSGO_GetAllWithPadding(MSGI_CODE,MESSAGE_CODE,_SEND_DATE_START_DATE, _SEND_DATE_END_DATE,SENDER_CODE,STATUS, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<MSGOInfo>
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
				    return new ResponsePage<MSGOInfo>
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
				return new ResponsePage<MSGOInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR,
				    PageIndex = int.Parse(pageIndex),
				    PageSize = int.Parse(pageSize),
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public Response MSGO_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/MSGO_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "MSGO_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "MSGO_EXPORT_TEMPLATE");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}
		public Response MSGO_EXPORT_DATA(string  MSGI_CODE,string  MESSAGE_CODE,string SEND_DATE_START_DATE,string SEND_DATE_END_DATE,string  SENDER_CODE,string STATUS, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/MSGO_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                MSGI_CODE = MSGI_CODE == "-1" ? string.Empty : MSGI_CODE;
		                MESSAGE_CODE = MESSAGE_CODE == "-1" ? string.Empty : MESSAGE_CODE;
		                DateTime _SEND_DATE_START_DATE = SEND_DATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(SEND_DATE_START_DATE.Split('-')[2]), int.Parse(SEND_DATE_START_DATE.Split('-')[1]), int.Parse(SEND_DATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _SEND_DATE_END_DATE = SEND_DATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(SEND_DATE_END_DATE.Split('-')[2]), int.Parse(SEND_DATE_END_DATE.Split('-')[1]), int.Parse(SEND_DATE_END_DATE.Split('-')[0]), 23, 59, 59);
		                SENDER_CODE = SENDER_CODE == "-1" ? string.Empty : SENDER_CODE;
		                STATUS = STATUS == "-1" ? string.Empty : STATUS;
		                List<MSGOInfo> resultMSGO = DataObjectFactory.GetInstanceMSGO().MSGO_GetAllWithPadding(MSGI_CODE,MESSAGE_CODE,_SEND_DATE_START_DATE, _SEND_DATE_END_DATE,SENDER_CODE,STATUS, 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableMSGO = DataObjectFactory.GetInstanceMSGO().ToDataTable(resultMSGO);
		                designer.SetDataSource("MSGO", dataTableMSGO.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "MSGO_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "MSGO_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "MSGO_EXPORT_DATA");
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
		            Message = Constant.MESSAGE_ERROR,
		            ReturnValue = string.Empty
		        };
		    }
		}

		#endregion
    }
}
