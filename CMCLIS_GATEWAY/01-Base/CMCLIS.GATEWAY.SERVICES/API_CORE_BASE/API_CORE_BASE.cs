﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Activation;
using System.Web;
using System.IO;
using Aspose.Cells;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.SETTING;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.DATA.OBJECTS;

namespace CMCLIS.GATEWAY.SERVICES
{
	//------------------------------------------------------------------------------------------------------------------------
	//-- Created By: Ngô Văn Nghị
	//-- Date: 02/20/2020 9:30:53 AM
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
       
		#region Create Functions "CVAN_DM_LT_THUE"
		public Response CVAN_DM_LT_THUE_Add(CVAN_DM_LT_THUEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_LT_THUE().Add(info);
				    if(result == 0)
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
		public Response CVAN_DM_LT_THUE_Update(CVAN_DM_LT_THUEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_LT_THUE().Update(info);
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
		public Response CVAN_DM_LT_THUE_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_LT_THUE().Delete(int.Parse(ID));
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
		public ResponseInfo<CVAN_DM_LT_THUEInfo> CVAN_DM_LT_THUE_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CVAN_DM_LT_THUEInfo result = DataObjectFactory.GetInstanceCVAN_DM_LT_THUE().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CVAN_DM_LT_THUEInfo>
				    {
				        ResultCode = Constant.RETURN_CODE_SUCCESS,
				        Message = Constant.MESSAGE_SUCCESS,
				        TotalRecords = result != null ? 1 : 0,
				        Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CVAN_DM_LT_THUEInfo>
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
				return new ResponseInfo<CVAN_DM_LT_THUEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CVAN_DM_LT_THUEInfo> CVAN_DM_LT_THUE_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CVAN_DM_LT_THUEInfo> result = DataObjectFactory.GetInstanceCVAN_DM_LT_THUE().GetList();
				    return new ResponseList<CVAN_DM_LT_THUEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CVAN_DM_LT_THUEInfo>
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
				return new ResponseList<CVAN_DM_LT_THUEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CVAN_DM_LT_THUEInfo> CVAN_DM_LT_THUE_GetAllWithPadding(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_PARENT,string  CVAN_STATUS,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_NAME = CVAN_NAME == "-1" ? string.Empty : CVAN_NAME;
		                CVAN_PARENT = CVAN_PARENT == "-1" ? string.Empty : CVAN_PARENT;
				    List<CVAN_DM_LT_THUEInfo> result = DataObjectFactory.GetInstanceCVAN_DM_LT_THUE().CVAN_DM_LT_THUE_GetAllWithPadding(CVAN_CODE,CVAN_NAME,CVAN_PARENT,int.Parse(CVAN_STATUS),int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CVAN_DM_LT_THUEInfo>
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
				    return new ResponsePage<CVAN_DM_LT_THUEInfo>
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
				return new ResponsePage<CVAN_DM_LT_THUEInfo>
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
		public Response CVAN_DM_LT_THUE_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_DM_LT_THUE_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_DM_LT_THUE_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_DM_LT_THUE_EXPORT_TEMPLATE");
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
		public Response CVAN_DM_LT_THUE_EXPORT_DATA(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_PARENT,string  CVAN_STATUS,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_DM_LT_THUE_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_NAME = CVAN_NAME == "-1" ? string.Empty : CVAN_NAME;
		                CVAN_PARENT = CVAN_PARENT == "-1" ? string.Empty : CVAN_PARENT;
		                List<CVAN_DM_LT_THUEInfo> resultCVAN_DM_LT_THUE = DataObjectFactory.GetInstanceCVAN_DM_LT_THUE().CVAN_DM_LT_THUE_GetAllWithPadding(CVAN_CODE,CVAN_NAME,CVAN_PARENT,int.Parse(CVAN_STATUS),int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCVAN_DM_LT_THUE = DataObjectFactory.GetInstanceCVAN_DM_LT_THUE().ToDataTable(resultCVAN_DM_LT_THUE);
		                designer.SetDataSource("CVAN_DM_LT_THUE", dataTableCVAN_DM_LT_THUE.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_DM_LT_THUE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_DM_LT_THUE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CVAN_DM_LT_THUE_EXPORT_DATA");
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
		#region Create Functions "CVAN_DM_MSG_TYPE"
		public Response CVAN_DM_MSG_TYPE_Add(CVAN_DM_MSG_TYPEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().Add(info);
				    if(result == 0)
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
		public Response CVAN_DM_MSG_TYPE_Update(CVAN_DM_MSG_TYPEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().Update(info);
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
		public Response CVAN_DM_MSG_TYPE_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().Delete(int.Parse(ID));
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
		public ResponseInfo<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CVAN_DM_MSG_TYPEInfo result = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CVAN_DM_MSG_TYPEInfo>
				    {
				        ResultCode = Constant.RETURN_CODE_SUCCESS,
				        Message = Constant.MESSAGE_SUCCESS,
				        TotalRecords = result != null ? 1 : 0,
				        Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CVAN_DM_MSG_TYPEInfo>
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
				return new ResponseInfo<CVAN_DM_MSG_TYPEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CVAN_DM_MSG_TYPEInfo> result = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().GetList();
				    return new ResponseList<CVAN_DM_MSG_TYPEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CVAN_DM_MSG_TYPEInfo>
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
				return new ResponseList<CVAN_DM_MSG_TYPEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_GetAllWithPadding(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_STATUS,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_NAME = CVAN_NAME == "-1" ? string.Empty : CVAN_NAME;
				    List<CVAN_DM_MSG_TYPEInfo> result = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().CVAN_DM_MSG_TYPE_GetAllWithPadding(CVAN_CODE,CVAN_NAME,int.Parse(CVAN_STATUS),int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CVAN_DM_MSG_TYPEInfo>
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
				    return new ResponsePage<CVAN_DM_MSG_TYPEInfo>
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
				return new ResponsePage<CVAN_DM_MSG_TYPEInfo>
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
		public Response CVAN_DM_MSG_TYPE_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_DM_MSG_TYPE_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_DM_MSG_TYPE_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_DM_MSG_TYPE_EXPORT_TEMPLATE");
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
		public Response CVAN_DM_MSG_TYPE_EXPORT_DATA(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_STATUS,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_DM_MSG_TYPE_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_NAME = CVAN_NAME == "-1" ? string.Empty : CVAN_NAME;
		                List<CVAN_DM_MSG_TYPEInfo> resultCVAN_DM_MSG_TYPE = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().CVAN_DM_MSG_TYPE_GetAllWithPadding(CVAN_CODE,CVAN_NAME,int.Parse(CVAN_STATUS),int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCVAN_DM_MSG_TYPE = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().ToDataTable(resultCVAN_DM_MSG_TYPE);
		                designer.SetDataSource("CVAN_DM_MSG_TYPE", dataTableCVAN_DM_MSG_TYPE.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_DM_MSG_TYPE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_DM_MSG_TYPE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CVAN_DM_MSG_TYPE_EXPORT_DATA");
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
		#region Create Functions "CVAN_DM_STATUS"
		public Response CVAN_DM_STATUS_Add(CVAN_DM_STATUSInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_STATUS().Add(info);
				    if(result == 0)
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
		public Response CVAN_DM_STATUS_Update(CVAN_DM_STATUSInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_STATUS().Update(info);
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
		public Response CVAN_DM_STATUS_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_DM_STATUS().Delete(int.Parse(ID));
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
		public ResponseInfo<CVAN_DM_STATUSInfo> CVAN_DM_STATUS_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CVAN_DM_STATUSInfo result = DataObjectFactory.GetInstanceCVAN_DM_STATUS().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CVAN_DM_STATUSInfo>
				    {
				        ResultCode = Constant.RETURN_CODE_SUCCESS,
				        Message = Constant.MESSAGE_SUCCESS,
				        TotalRecords = result != null ? 1 : 0,
				        Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CVAN_DM_STATUSInfo>
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
				return new ResponseInfo<CVAN_DM_STATUSInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CVAN_DM_STATUSInfo> CVAN_DM_STATUS_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CVAN_DM_STATUSInfo> result = DataObjectFactory.GetInstanceCVAN_DM_STATUS().GetList();
				    return new ResponseList<CVAN_DM_STATUSInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CVAN_DM_STATUSInfo>
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
				return new ResponseList<CVAN_DM_STATUSInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CVAN_DM_STATUSInfo> CVAN_DM_STATUS_GetAllWithPadding(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_STATUS,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_NAME = CVAN_NAME == "-1" ? string.Empty : CVAN_NAME;
				    List<CVAN_DM_STATUSInfo> result = DataObjectFactory.GetInstanceCVAN_DM_STATUS().CVAN_DM_STATUS_GetAllWithPadding(CVAN_CODE,CVAN_NAME,int.Parse(CVAN_STATUS),int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CVAN_DM_STATUSInfo>
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
				    return new ResponsePage<CVAN_DM_STATUSInfo>
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
				return new ResponsePage<CVAN_DM_STATUSInfo>
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
		public Response CVAN_DM_STATUS_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_DM_STATUS_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_DM_STATUS_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_DM_STATUS_EXPORT_TEMPLATE");
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
		public Response CVAN_DM_STATUS_EXPORT_DATA(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_STATUS,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_DM_STATUS_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_NAME = CVAN_NAME == "-1" ? string.Empty : CVAN_NAME;
		                List<CVAN_DM_STATUSInfo> resultCVAN_DM_STATUS = DataObjectFactory.GetInstanceCVAN_DM_STATUS().CVAN_DM_STATUS_GetAllWithPadding(CVAN_CODE,CVAN_NAME,int.Parse(CVAN_STATUS),int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCVAN_DM_STATUS = DataObjectFactory.GetInstanceCVAN_DM_STATUS().ToDataTable(resultCVAN_DM_STATUS);
		                designer.SetDataSource("CVAN_DM_STATUS", dataTableCVAN_DM_STATUS.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_DM_STATUS_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_DM_STATUS_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CVAN_DM_STATUS_EXPORT_DATA");
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
		#region Create Functions "CVAN_EXCHANGE"
		public Response CVAN_EXCHANGE_Add(CVAN_EXCHANGEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_EXCHANGE().Add(info);
				    if(result == 0)
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
		public Response CVAN_EXCHANGE_Update(CVAN_EXCHANGEInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_EXCHANGE().Update(info);
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
		public Response CVAN_EXCHANGE_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_EXCHANGE().Delete(int.Parse(ID));
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
		public ResponseInfo<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CVAN_EXCHANGEInfo result = DataObjectFactory.GetInstanceCVAN_EXCHANGE().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CVAN_EXCHANGEInfo>
				    {
				        ResultCode = Constant.RETURN_CODE_SUCCESS,
				        Message = Constant.MESSAGE_SUCCESS,
				        TotalRecords = result != null ? 1 : 0,
				        Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CVAN_EXCHANGEInfo>
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
				return new ResponseInfo<CVAN_EXCHANGEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CVAN_EXCHANGEInfo> result = DataObjectFactory.GetInstanceCVAN_EXCHANGE().GetList();
				    return new ResponseList<CVAN_EXCHANGEInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CVAN_EXCHANGEInfo>
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
				return new ResponseList<CVAN_EXCHANGEInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_GetAllWithPadding(string  CVAN_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_STATUS_CODE,string  CVAN_MA_GD,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_MSG_TYPE_CODE = CVAN_MSG_TYPE_CODE == "-1" ? string.Empty : CVAN_MSG_TYPE_CODE;
		                CVAN_STATUS_CODE = CVAN_STATUS_CODE == "-1" ? string.Empty : CVAN_STATUS_CODE;
		                CVAN_MA_GD = CVAN_MA_GD == "-1" ? string.Empty : CVAN_MA_GD;
				    List<CVAN_EXCHANGEInfo> result = DataObjectFactory.GetInstanceCVAN_EXCHANGE().CVAN_EXCHANGE_GetAllWithPadding(CVAN_CODE,CVAN_MSG_TYPE_CODE,CVAN_STATUS_CODE,CVAN_MA_GD,int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CVAN_EXCHANGEInfo>
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
				    return new ResponsePage<CVAN_EXCHANGEInfo>
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
				return new ResponsePage<CVAN_EXCHANGEInfo>
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
		public Response CVAN_EXCHANGE_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_EXCHANGE_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_EXCHANGE_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_EXCHANGE_EXPORT_TEMPLATE");
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
		public Response CVAN_EXCHANGE_EXPORT_DATA(string  CVAN_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_STATUS_CODE,string  CVAN_MA_GD,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_EXCHANGE_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_MSG_TYPE_CODE = CVAN_MSG_TYPE_CODE == "-1" ? string.Empty : CVAN_MSG_TYPE_CODE;
		                CVAN_STATUS_CODE = CVAN_STATUS_CODE == "-1" ? string.Empty : CVAN_STATUS_CODE;
		                CVAN_MA_GD = CVAN_MA_GD == "-1" ? string.Empty : CVAN_MA_GD;
		                List<CVAN_EXCHANGEInfo> resultCVAN_EXCHANGE = DataObjectFactory.GetInstanceCVAN_EXCHANGE().CVAN_EXCHANGE_GetAllWithPadding(CVAN_CODE,CVAN_MSG_TYPE_CODE,CVAN_STATUS_CODE,CVAN_MA_GD,int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCVAN_EXCHANGE = DataObjectFactory.GetInstanceCVAN_EXCHANGE().ToDataTable(resultCVAN_EXCHANGE);
		                designer.SetDataSource("CVAN_EXCHANGE", dataTableCVAN_EXCHANGE.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_EXCHANGE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_EXCHANGE_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CVAN_EXCHANGE_EXPORT_DATA");
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
		#region Create Functions "CVAN_MAIL"
		public Response CVAN_MAIL_Add(CVAN_MAILInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MAIL().Add(info);
				    if(result == 0)
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
		public Response CVAN_MAIL_Update(CVAN_MAILInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MAIL().Update(info);
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
		public Response CVAN_MAIL_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MAIL().Delete(int.Parse(ID));
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
		public ResponseInfo<CVAN_MAILInfo> CVAN_MAIL_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CVAN_MAILInfo result = DataObjectFactory.GetInstanceCVAN_MAIL().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CVAN_MAILInfo>
				    {
				        ResultCode = Constant.RETURN_CODE_SUCCESS,
				        Message = Constant.MESSAGE_SUCCESS,
				        TotalRecords = result != null ? 1 : 0,
				        Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CVAN_MAILInfo>
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
				return new ResponseInfo<CVAN_MAILInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CVAN_MAILInfo> CVAN_MAIL_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CVAN_MAILInfo> result = DataObjectFactory.GetInstanceCVAN_MAIL().GetList();
				    return new ResponseList<CVAN_MAILInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CVAN_MAILInfo>
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
				return new ResponseList<CVAN_MAILInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CVAN_MAILInfo> CVAN_MAIL_GetAllWithPadding(string  CVAN_FROM,string  CVAN_TO,string  CVAN_SUBJECT,string  CVAN_TYPE_CODE,string  CVAN_STATUS,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CVAN_FROM = CVAN_FROM == "-1" ? string.Empty : CVAN_FROM;
		                CVAN_TO = CVAN_TO == "-1" ? string.Empty : CVAN_TO;
		                CVAN_SUBJECT = CVAN_SUBJECT == "-1" ? string.Empty : CVAN_SUBJECT;
		                CVAN_TYPE_CODE = CVAN_TYPE_CODE == "-1" ? string.Empty : CVAN_TYPE_CODE;
				    List<CVAN_MAILInfo> result = DataObjectFactory.GetInstanceCVAN_MAIL().CVAN_MAIL_GetAllWithPadding(CVAN_FROM,CVAN_TO,CVAN_SUBJECT,CVAN_TYPE_CODE,int.Parse(CVAN_STATUS),int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CVAN_MAILInfo>
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
				    return new ResponsePage<CVAN_MAILInfo>
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
				return new ResponsePage<CVAN_MAILInfo>
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
		public Response CVAN_MAIL_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_MAIL_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_MAIL_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_MAIL_EXPORT_TEMPLATE");
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
		public Response CVAN_MAIL_EXPORT_DATA(string  CVAN_FROM,string  CVAN_TO,string  CVAN_SUBJECT,string  CVAN_TYPE_CODE,string  CVAN_STATUS,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_MAIL_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CVAN_FROM = CVAN_FROM == "-1" ? string.Empty : CVAN_FROM;
		                CVAN_TO = CVAN_TO == "-1" ? string.Empty : CVAN_TO;
		                CVAN_SUBJECT = CVAN_SUBJECT == "-1" ? string.Empty : CVAN_SUBJECT;
		                CVAN_TYPE_CODE = CVAN_TYPE_CODE == "-1" ? string.Empty : CVAN_TYPE_CODE;
		                List<CVAN_MAILInfo> resultCVAN_MAIL = DataObjectFactory.GetInstanceCVAN_MAIL().CVAN_MAIL_GetAllWithPadding(CVAN_FROM,CVAN_TO,CVAN_SUBJECT,CVAN_TYPE_CODE,int.Parse(CVAN_STATUS),int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCVAN_MAIL = DataObjectFactory.GetInstanceCVAN_MAIL().ToDataTable(resultCVAN_MAIL);
		                designer.SetDataSource("CVAN_MAIL", dataTableCVAN_MAIL.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_MAIL_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_MAIL_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CVAN_MAIL_EXPORT_DATA");
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
		#region Create Functions "CVAN_MSGI"
		public Response CVAN_MSGI_Add(CVAN_MSGIInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MSGI().Add(info);
				    if(result == 0)
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
		public Response CVAN_MSGI_Update(CVAN_MSGIInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MSGI().Update(info);
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
		public Response CVAN_MSGI_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MSGI().Delete(int.Parse(ID));
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
		public ResponseInfo<CVAN_MSGIInfo> CVAN_MSGI_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CVAN_MSGIInfo result = DataObjectFactory.GetInstanceCVAN_MSGI().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CVAN_MSGIInfo>
				    {
				        ResultCode = Constant.RETURN_CODE_SUCCESS,
				        Message = Constant.MESSAGE_SUCCESS,
				        TotalRecords = result != null ? 1 : 0,
				        Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CVAN_MSGIInfo>
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
				return new ResponseInfo<CVAN_MSGIInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CVAN_MSGIInfo> CVAN_MSGI_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CVAN_MSGIInfo> result = DataObjectFactory.GetInstanceCVAN_MSGI().GetList();
				    return new ResponseList<CVAN_MSGIInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CVAN_MSGIInfo>
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
				return new ResponseList<CVAN_MSGIInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CVAN_MSGIInfo> CVAN_MSGI_GetAllWithPadding(string  CVAN_CODE,string  CVAN_MSGO_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_STATUS_CODE,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_MSGO_CODE = CVAN_MSGO_CODE == "-1" ? string.Empty : CVAN_MSGO_CODE;
		                CVAN_MSG_TYPE_CODE = CVAN_MSG_TYPE_CODE == "-1" ? string.Empty : CVAN_MSG_TYPE_CODE;
		                CVAN_STATUS_CODE = CVAN_STATUS_CODE == "-1" ? string.Empty : CVAN_STATUS_CODE;
				    List<CVAN_MSGIInfo> result = DataObjectFactory.GetInstanceCVAN_MSGI().CVAN_MSGI_GetAllWithPadding(CVAN_CODE,CVAN_MSGO_CODE,CVAN_MSG_TYPE_CODE,CVAN_STATUS_CODE,int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CVAN_MSGIInfo>
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
				    return new ResponsePage<CVAN_MSGIInfo>
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
				return new ResponsePage<CVAN_MSGIInfo>
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
		public Response CVAN_MSGI_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_MSGI_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_MSGI_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_MSGI_EXPORT_TEMPLATE");
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
		public Response CVAN_MSGI_EXPORT_DATA(string  CVAN_CODE,string  CVAN_MSGO_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_STATUS_CODE,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_MSGI_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_MSGO_CODE = CVAN_MSGO_CODE == "-1" ? string.Empty : CVAN_MSGO_CODE;
		                CVAN_MSG_TYPE_CODE = CVAN_MSG_TYPE_CODE == "-1" ? string.Empty : CVAN_MSG_TYPE_CODE;
		                CVAN_STATUS_CODE = CVAN_STATUS_CODE == "-1" ? string.Empty : CVAN_STATUS_CODE;
		                List<CVAN_MSGIInfo> resultCVAN_MSGI = DataObjectFactory.GetInstanceCVAN_MSGI().CVAN_MSGI_GetAllWithPadding(CVAN_CODE,CVAN_MSGO_CODE,CVAN_MSG_TYPE_CODE,CVAN_STATUS_CODE,int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCVAN_MSGI = DataObjectFactory.GetInstanceCVAN_MSGI().ToDataTable(resultCVAN_MSGI);
		                designer.SetDataSource("CVAN_MSGI", dataTableCVAN_MSGI.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_MSGI_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_MSGI_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CVAN_MSGI_EXPORT_DATA");
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
		#region Create Functions "CVAN_MSGO"
		public Response CVAN_MSGO_Add(CVAN_MSGOInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MSGO().Add(info);
				    if(result == 0)
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
		public Response CVAN_MSGO_Update(CVAN_MSGOInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MSGO().Update(info);
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
		public Response CVAN_MSGO_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceCVAN_MSGO().Delete(int.Parse(ID));
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
		public ResponseInfo<CVAN_MSGOInfo> CVAN_MSGO_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    CVAN_MSGOInfo result = DataObjectFactory.GetInstanceCVAN_MSGO().GetInfo(int.Parse(ID));
				    return new ResponseInfo<CVAN_MSGOInfo>
				    {
				        ResultCode = Constant.RETURN_CODE_SUCCESS,
				        Message = Constant.MESSAGE_SUCCESS,
				        TotalRecords = result != null ? 1 : 0,
				        Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<CVAN_MSGOInfo>
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
				return new ResponseInfo<CVAN_MSGOInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<CVAN_MSGOInfo> CVAN_MSGO_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<CVAN_MSGOInfo> result = DataObjectFactory.GetInstanceCVAN_MSGO().GetList();
				    return new ResponseList<CVAN_MSGOInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<CVAN_MSGOInfo>
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
				return new ResponseList<CVAN_MSGOInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<CVAN_MSGOInfo> CVAN_MSGO_GetAllWithPadding(string  CVAN_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_SENDER_CODE,string  CVAN_STATUS_SEND,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_MSG_TYPE_CODE = CVAN_MSG_TYPE_CODE == "-1" ? string.Empty : CVAN_MSG_TYPE_CODE;
		                CVAN_SENDER_CODE = CVAN_SENDER_CODE == "-1" ? string.Empty : CVAN_SENDER_CODE;
				    List<CVAN_MSGOInfo> result = DataObjectFactory.GetInstanceCVAN_MSGO().CVAN_MSGO_GetAllWithPadding(CVAN_CODE,CVAN_MSG_TYPE_CODE,CVAN_SENDER_CODE, int.Parse(CVAN_STATUS_SEND),int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<CVAN_MSGOInfo>
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
				    return new ResponsePage<CVAN_MSGOInfo>
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
				return new ResponsePage<CVAN_MSGOInfo>
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
		public Response CVAN_MSGO_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_MSGO_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_MSGO_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_MSGO_EXPORT_TEMPLATE");
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
		public Response CVAN_MSGO_EXPORT_DATA(string  CVAN_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_SENDER_CODE,string  CVAN_STATUS_SEND,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/CVAN_MSGO_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                CVAN_CODE = CVAN_CODE == "-1" ? string.Empty : CVAN_CODE;
		                CVAN_MSG_TYPE_CODE = CVAN_MSG_TYPE_CODE == "-1" ? string.Empty : CVAN_MSG_TYPE_CODE;
		                CVAN_SENDER_CODE = CVAN_SENDER_CODE == "-1" ? string.Empty : CVAN_SENDER_CODE;
		                List<CVAN_MSGOInfo> resultCVAN_MSGO = DataObjectFactory.GetInstanceCVAN_MSGO().CVAN_MSGO_GetAllWithPadding(CVAN_CODE,CVAN_MSG_TYPE_CODE,CVAN_SENDER_CODE,int.Parse(CVAN_STATUS_SEND),int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableCVAN_MSGO = DataObjectFactory.GetInstanceCVAN_MSGO().ToDataTable(resultCVAN_MSGO);
		                designer.SetDataSource("CVAN_MSGO", dataTableCVAN_MSGO.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "CVAN_MSGO_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "CVAN_MSGO_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "CVAN_MSGO_EXPORT_DATA");
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
		#region Create Functions "FILE_SERVER_DATA"
		public Response FILE_SERVER_DATA_Add(FILE_SERVER_DATAInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceFILE_SERVER_DATA().Add(info);
				    if(result == 0)
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
		public Response FILE_SERVER_DATA_Update(FILE_SERVER_DATAInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceFILE_SERVER_DATA().Update(info);
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
		public Response FILE_SERVER_DATA_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceFILE_SERVER_DATA().Delete(int.Parse(ID));
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
		public ResponseInfo<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetInfo(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    FILE_SERVER_DATAInfo result = DataObjectFactory.GetInstanceFILE_SERVER_DATA().GetInfo(int.Parse(ID));
				    return new ResponseInfo<FILE_SERVER_DATAInfo>
				    {
				        ResultCode = Constant.RETURN_CODE_SUCCESS,
				        Message = Constant.MESSAGE_SUCCESS,
				        TotalRecords = result != null ? 1 : 0,
				        Data = result
				    };
				}
				else
				{
				    return new ResponseInfo<FILE_SERVER_DATAInfo>
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
				return new ResponseInfo<FILE_SERVER_DATAInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponseList<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<FILE_SERVER_DATAInfo> result = DataObjectFactory.GetInstanceFILE_SERVER_DATA().GetList();
				    return new ResponseList<FILE_SERVER_DATAInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<FILE_SERVER_DATAInfo>
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
				return new ResponseList<FILE_SERVER_DATAInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetAllWithPadding(string  FILE_ID,string  DOC_TYPE,string  FILE_NAME,string  TRAN_ID,string  REGION_ID,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                FILE_ID = FILE_ID == "-1" ? string.Empty : FILE_ID;
		                DOC_TYPE = DOC_TYPE == "-1" ? string.Empty : DOC_TYPE;
		                FILE_NAME = FILE_NAME == "-1" ? string.Empty : FILE_NAME;
		                TRAN_ID = TRAN_ID == "-1" ? string.Empty : TRAN_ID;
		                REGION_ID = REGION_ID == "-1" ? string.Empty : REGION_ID;
				    List<FILE_SERVER_DATAInfo> result = DataObjectFactory.GetInstanceFILE_SERVER_DATA().FILE_SERVER_DATA_GetAllWithPadding(FILE_ID,DOC_TYPE,FILE_NAME,TRAN_ID,REGION_ID,int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
				    return new ResponsePage<FILE_SERVER_DATAInfo>
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
				    return new ResponsePage<FILE_SERVER_DATAInfo>
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
				return new ResponsePage<FILE_SERVER_DATAInfo>
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
		public Response FILE_SERVER_DATA_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/FILE_SERVER_DATA_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "FILE_SERVER_DATA_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "FILE_SERVER_DATA_EXPORT_TEMPLATE");
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
		public Response FILE_SERVER_DATA_EXPORT_DATA(string  FILE_ID,string  DOC_TYPE,string  FILE_NAME,string  TRAN_ID,string  REGION_ID,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/FILE_SERVER_DATA_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                FILE_ID = FILE_ID == "-1" ? string.Empty : FILE_ID;
		                DOC_TYPE = DOC_TYPE == "-1" ? string.Empty : DOC_TYPE;
		                FILE_NAME = FILE_NAME == "-1" ? string.Empty : FILE_NAME;
		                TRAN_ID = TRAN_ID == "-1" ? string.Empty : TRAN_ID;
		                REGION_ID = REGION_ID == "-1" ? string.Empty : REGION_ID;
		                List<FILE_SERVER_DATAInfo> resultFILE_SERVER_DATA = DataObjectFactory.GetInstanceFILE_SERVER_DATA().FILE_SERVER_DATA_GetAllWithPadding(FILE_ID,DOC_TYPE,FILE_NAME,TRAN_ID,REGION_ID,int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableFILE_SERVER_DATA = DataObjectFactory.GetInstanceFILE_SERVER_DATA().ToDataTable(resultFILE_SERVER_DATA);
		                designer.SetDataSource("FILE_SERVER_DATA", dataTableFILE_SERVER_DATA.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "FILE_SERVER_DATA_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "FILE_SERVER_DATA_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "FILE_SERVER_DATA_EXPORT_DATA");
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
		#region Create Functions "LOG_CHUC_NANG"
		public Response LOG_CHUC_NANG_Add(LOG_CHUC_NANGInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_CHUC_NANG().Add(info);
				    if(result == 0)
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
		public Response LOG_CHUC_NANG_Update(LOG_CHUC_NANGInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_CHUC_NANG().Update(info);
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
		public Response LOG_CHUC_NANG_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_CHUC_NANG().Delete(int.Parse(ID));
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
		public ResponseList<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<LOG_CHUC_NANGInfo> result = DataObjectFactory.GetInstanceLOG_CHUC_NANG().GetList();
				    return new ResponseList<LOG_CHUC_NANGInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<LOG_CHUC_NANGInfo>
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
				return new ResponseList<LOG_CHUC_NANGInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetAllWithPadding(string  USER_NAME,string  FUNCTION_NAME,string  ACTION,string TIME_START_DATE,string TIME_END_DATE,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                FUNCTION_NAME = FUNCTION_NAME == "-1" ? string.Empty : FUNCTION_NAME;
		                ACTION = ACTION == "-1" ? string.Empty : ACTION;
		                DateTime _TIME_START_DATE = TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(TIME_START_DATE.Split('-')[2]), int.Parse(TIME_START_DATE.Split('-')[1]), int.Parse(TIME_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _TIME_END_DATE = TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(TIME_END_DATE.Split('-')[2]), int.Parse(TIME_END_DATE.Split('-')[1]), int.Parse(TIME_END_DATE.Split('-')[0]), 23, 59, 59);
				    List<LOG_CHUC_NANGInfo> result = DataObjectFactory.GetInstanceLOG_CHUC_NANG().LOG_CHUC_NANG_GetAllWithPadding(USER_NAME,FUNCTION_NAME,ACTION,_TIME_START_DATE, _TIME_END_DATE,int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
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
		public Response LOG_CHUC_NANG_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_CHUC_NANG_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_CHUC_NANG_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_CHUC_NANG_EXPORT_TEMPLATE");
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
		public Response LOG_CHUC_NANG_EXPORT_DATA(string  USER_NAME,string  FUNCTION_NAME,string  ACTION,string TIME_START_DATE,string TIME_END_DATE,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_CHUC_NANG_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                FUNCTION_NAME = FUNCTION_NAME == "-1" ? string.Empty : FUNCTION_NAME;
		                ACTION = ACTION == "-1" ? string.Empty : ACTION;
		                DateTime _TIME_START_DATE = TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(TIME_START_DATE.Split('-')[2]), int.Parse(TIME_START_DATE.Split('-')[1]), int.Parse(TIME_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _TIME_END_DATE = TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(TIME_END_DATE.Split('-')[2]), int.Parse(TIME_END_DATE.Split('-')[1]), int.Parse(TIME_END_DATE.Split('-')[0]), 23, 59, 59);
		                List<LOG_CHUC_NANGInfo> resultLOG_CHUC_NANG = DataObjectFactory.GetInstanceLOG_CHUC_NANG().LOG_CHUC_NANG_GetAllWithPadding(USER_NAME,FUNCTION_NAME,ACTION,_TIME_START_DATE, _TIME_END_DATE,int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableLOG_CHUC_NANG = DataObjectFactory.GetInstanceLOG_CHUC_NANG().ToDataTable(resultLOG_CHUC_NANG);
		                designer.SetDataSource("LOG_CHUC_NANG", dataTableLOG_CHUC_NANG.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_CHUC_NANG_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_CHUC_NANG_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "LOG_CHUC_NANG_EXPORT_DATA");
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
		#region Create Functions "LOG_DATA"
		public Response LOG_DATA_Add(LOG_DATAInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_DATA().Add(info);
				    if(result == 0)
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
		public Response LOG_DATA_Update(LOG_DATAInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_DATA().Update(info);
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
		public Response LOG_DATA_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_DATA().Delete(int.Parse(ID));
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
		public ResponseList<LOG_DATAInfo> LOG_DATA_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<LOG_DATAInfo> result = DataObjectFactory.GetInstanceLOG_DATA().GetList();
				    return new ResponseList<LOG_DATAInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<LOG_DATAInfo>
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
				return new ResponseList<LOG_DATAInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<LOG_DATAInfo> LOG_DATA_GetAllWithPadding(string  IP,string  PORT,string  APPLICATION_NAME,string  MESSAGE,string  LOG_TYPE,string  IS_DELETE,string CDATE_START_DATE,string CDATE_END_DATE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                IP = IP == "-1" ? string.Empty : IP;
		                APPLICATION_NAME = APPLICATION_NAME == "-1" ? string.Empty : APPLICATION_NAME;
		                MESSAGE = MESSAGE == "-1" ? string.Empty : MESSAGE;
		                DateTime _CDATE_START_DATE = CDATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(CDATE_START_DATE.Split('-')[2]), int.Parse(CDATE_START_DATE.Split('-')[1]), int.Parse(CDATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _CDATE_END_DATE = CDATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(CDATE_END_DATE.Split('-')[2]), int.Parse(CDATE_END_DATE.Split('-')[1]), int.Parse(CDATE_END_DATE.Split('-')[0]), 23, 59, 59);
				    List<LOG_DATAInfo> result = DataObjectFactory.GetInstanceLOG_DATA().LOG_DATA_GetAllWithPadding(IP,int.Parse(PORT),APPLICATION_NAME,MESSAGE,int.Parse(LOG_TYPE),int.Parse(IS_DELETE),_CDATE_START_DATE, _CDATE_END_DATE, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
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
		public Response LOG_DATA_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_DATA_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_DATA_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_DATA_EXPORT_TEMPLATE");
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
		public Response LOG_DATA_EXPORT_DATA(string  IP,string  PORT,string  APPLICATION_NAME,string  MESSAGE,string  LOG_TYPE,string  IS_DELETE,string CDATE_START_DATE,string CDATE_END_DATE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_DATA_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                IP = IP == "-1" ? string.Empty : IP;
		                APPLICATION_NAME = APPLICATION_NAME == "-1" ? string.Empty : APPLICATION_NAME;
		                MESSAGE = MESSAGE == "-1" ? string.Empty : MESSAGE;
		                DateTime _CDATE_START_DATE = CDATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(CDATE_START_DATE.Split('-')[2]), int.Parse(CDATE_START_DATE.Split('-')[1]), int.Parse(CDATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _CDATE_END_DATE = CDATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(CDATE_END_DATE.Split('-')[2]), int.Parse(CDATE_END_DATE.Split('-')[1]), int.Parse(CDATE_END_DATE.Split('-')[0]), 23, 59, 59);
		                List<LOG_DATAInfo> resultLOG_DATA = DataObjectFactory.GetInstanceLOG_DATA().LOG_DATA_GetAllWithPadding(IP,int.Parse(PORT),APPLICATION_NAME,MESSAGE,int.Parse(LOG_TYPE),int.Parse(IS_DELETE),_CDATE_START_DATE, _CDATE_END_DATE, 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableLOG_DATA = DataObjectFactory.GetInstanceLOG_DATA().ToDataTable(resultLOG_DATA);
		                designer.SetDataSource("LOG_DATA", dataTableLOG_DATA.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_DATA_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_DATA_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "LOG_DATA_EXPORT_DATA");
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
		#region Create Functions "LOG_DU_LIEU_DB"
		public Response LOG_DU_LIEU_DB_Add(LOG_DU_LIEU_DBInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().Add(info);
				    if(result == 0)
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
		public Response LOG_DU_LIEU_DB_Update(LOG_DU_LIEU_DBInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().Update(info);
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
		public Response LOG_DU_LIEU_DB_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().Delete(int.Parse(ID));
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
		public ResponseList<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<LOG_DU_LIEU_DBInfo> result = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().GetList();
				    return new ResponseList<LOG_DU_LIEU_DBInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<LOG_DU_LIEU_DBInfo>
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
				return new ResponseList<LOG_DU_LIEU_DBInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetAllWithPadding(string  USER_NAME,string  TABLE_NAME,string  ACTION,string  IS_DELETE,string CDATE_START_DATE,string CDATE_END_DATE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                TABLE_NAME = TABLE_NAME == "-1" ? string.Empty : TABLE_NAME;
		                ACTION = ACTION == "-1" ? string.Empty : ACTION;
		                DateTime _CDATE_START_DATE = CDATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(CDATE_START_DATE.Split('-')[2]), int.Parse(CDATE_START_DATE.Split('-')[1]), int.Parse(CDATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _CDATE_END_DATE = CDATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(CDATE_END_DATE.Split('-')[2]), int.Parse(CDATE_END_DATE.Split('-')[1]), int.Parse(CDATE_END_DATE.Split('-')[0]), 23, 59, 59);
				    List<LOG_DU_LIEU_DBInfo> result = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().LOG_DU_LIEU_DB_GetAllWithPadding(USER_NAME,TABLE_NAME,ACTION,int.Parse(IS_DELETE),_CDATE_START_DATE, _CDATE_END_DATE, int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
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
		public Response LOG_DU_LIEU_DB_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_DU_LIEU_DB_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_DU_LIEU_DB_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_DU_LIEU_DB_EXPORT_TEMPLATE");
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
		public Response LOG_DU_LIEU_DB_EXPORT_DATA(string  USER_NAME,string  TABLE_NAME,string  ACTION,string  IS_DELETE,string CDATE_START_DATE,string CDATE_END_DATE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_DU_LIEU_DB_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                TABLE_NAME = TABLE_NAME == "-1" ? string.Empty : TABLE_NAME;
		                ACTION = ACTION == "-1" ? string.Empty : ACTION;
		                DateTime _CDATE_START_DATE = CDATE_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(CDATE_START_DATE.Split('-')[2]), int.Parse(CDATE_START_DATE.Split('-')[1]), int.Parse(CDATE_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _CDATE_END_DATE = CDATE_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(CDATE_END_DATE.Split('-')[2]), int.Parse(CDATE_END_DATE.Split('-')[1]), int.Parse(CDATE_END_DATE.Split('-')[0]), 23, 59, 59);
		                List<LOG_DU_LIEU_DBInfo> resultLOG_DU_LIEU_DB = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().LOG_DU_LIEU_DB_GetAllWithPadding(USER_NAME,TABLE_NAME,ACTION,int.Parse(IS_DELETE),_CDATE_START_DATE, _CDATE_END_DATE, 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableLOG_DU_LIEU_DB = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().ToDataTable(resultLOG_DU_LIEU_DB);
		                designer.SetDataSource("LOG_DU_LIEU_DB", dataTableLOG_DU_LIEU_DB.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_DU_LIEU_DB_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_DU_LIEU_DB_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "LOG_DU_LIEU_DB_EXPORT_DATA");
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
		#region Create Functions "LOG_TRUY_CAP"
		public Response LOG_TRUY_CAP_Add(LOG_TRUY_CAPInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_TRUY_CAP().Add(info);
				    if(result == 0)
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
		public Response LOG_TRUY_CAP_Update(LOG_TRUY_CAPInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_TRUY_CAP().Update(info);
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
		public Response LOG_TRUY_CAP_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_TRUY_CAP().Delete(int.Parse(ID));
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
		public ResponseList<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<LOG_TRUY_CAPInfo> result = DataObjectFactory.GetInstanceLOG_TRUY_CAP().GetList();
				    return new ResponseList<LOG_TRUY_CAPInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<LOG_TRUY_CAPInfo>
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
				return new ResponseList<LOG_TRUY_CAPInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetAllWithPadding(string  USER_NAME,string LOG_TIME_START_DATE,string LOG_TIME_END_DATE,string  ACTION,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                DateTime _LOG_TIME_START_DATE = LOG_TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(LOG_TIME_START_DATE.Split('-')[2]), int.Parse(LOG_TIME_START_DATE.Split('-')[1]), int.Parse(LOG_TIME_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _LOG_TIME_END_DATE = LOG_TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(LOG_TIME_END_DATE.Split('-')[2]), int.Parse(LOG_TIME_END_DATE.Split('-')[1]), int.Parse(LOG_TIME_END_DATE.Split('-')[0]), 23, 59, 59);
		                ACTION = ACTION == "-1" ? string.Empty : ACTION;
				    List<LOG_TRUY_CAPInfo> result = DataObjectFactory.GetInstanceLOG_TRUY_CAP().LOG_TRUY_CAP_GetAllWithPadding(USER_NAME,_LOG_TIME_START_DATE, _LOG_TIME_END_DATE,ACTION,int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
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
		public Response LOG_TRUY_CAP_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_TRUY_CAP_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_TRUY_CAP_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_TRUY_CAP_EXPORT_TEMPLATE");
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
		public Response LOG_TRUY_CAP_EXPORT_DATA(string  USER_NAME,string LOG_TIME_START_DATE,string LOG_TIME_END_DATE,string  ACTION,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_TRUY_CAP_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                DateTime _LOG_TIME_START_DATE = LOG_TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(LOG_TIME_START_DATE.Split('-')[2]), int.Parse(LOG_TIME_START_DATE.Split('-')[1]), int.Parse(LOG_TIME_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _LOG_TIME_END_DATE = LOG_TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(LOG_TIME_END_DATE.Split('-')[2]), int.Parse(LOG_TIME_END_DATE.Split('-')[1]), int.Parse(LOG_TIME_END_DATE.Split('-')[0]), 23, 59, 59);
		                ACTION = ACTION == "-1" ? string.Empty : ACTION;
		                List<LOG_TRUY_CAPInfo> resultLOG_TRUY_CAP = DataObjectFactory.GetInstanceLOG_TRUY_CAP().LOG_TRUY_CAP_GetAllWithPadding(USER_NAME,_LOG_TIME_START_DATE, _LOG_TIME_END_DATE,ACTION,int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableLOG_TRUY_CAP = DataObjectFactory.GetInstanceLOG_TRUY_CAP().ToDataTable(resultLOG_TRUY_CAP);
		                designer.SetDataSource("LOG_TRUY_CAP", dataTableLOG_TRUY_CAP.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_TRUY_CAP_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_TRUY_CAP_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "LOG_TRUY_CAP_EXPORT_DATA");
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
		#region Create Functions "LOG_XL_HANG_LOAT"
		public Response LOG_XL_HANG_LOAT_Add(LOG_XL_HANG_LOATInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().Add(info);
				    if(result == 0)
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
		public Response LOG_XL_HANG_LOAT_Update(LOG_XL_HANG_LOATInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().Update(info);
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
		public Response LOG_XL_HANG_LOAT_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().Delete(int.Parse(ID));
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
		public ResponseList<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<LOG_XL_HANG_LOATInfo> result = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().GetList();
				    return new ResponseList<LOG_XL_HANG_LOATInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<LOG_XL_HANG_LOATInfo>
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
				return new ResponseList<LOG_XL_HANG_LOATInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetAllWithPadding(string  USER_NAME,string  FUNCTION_NAME,string TIME_START_DATE,string TIME_END_DATE,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                FUNCTION_NAME = FUNCTION_NAME == "-1" ? string.Empty : FUNCTION_NAME;
		                DateTime _TIME_START_DATE = TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(TIME_START_DATE.Split('-')[2]), int.Parse(TIME_START_DATE.Split('-')[1]), int.Parse(TIME_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _TIME_END_DATE = TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(TIME_END_DATE.Split('-')[2]), int.Parse(TIME_END_DATE.Split('-')[1]), int.Parse(TIME_END_DATE.Split('-')[0]), 23, 59, 59);
				    List<LOG_XL_HANG_LOATInfo> result = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().LOG_XL_HANG_LOAT_GetAllWithPadding(USER_NAME,FUNCTION_NAME,_TIME_START_DATE, _TIME_END_DATE,int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
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
		public Response LOG_XL_HANG_LOAT_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_XL_HANG_LOAT_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_XL_HANG_LOAT_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_XL_HANG_LOAT_EXPORT_TEMPLATE");
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
		public Response LOG_XL_HANG_LOAT_EXPORT_DATA(string  USER_NAME,string  FUNCTION_NAME,string TIME_START_DATE,string TIME_END_DATE,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_XL_HANG_LOAT_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                FUNCTION_NAME = FUNCTION_NAME == "-1" ? string.Empty : FUNCTION_NAME;
		                DateTime _TIME_START_DATE = TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(TIME_START_DATE.Split('-')[2]), int.Parse(TIME_START_DATE.Split('-')[1]), int.Parse(TIME_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _TIME_END_DATE = TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(TIME_END_DATE.Split('-')[2]), int.Parse(TIME_END_DATE.Split('-')[1]), int.Parse(TIME_END_DATE.Split('-')[0]), 23, 59, 59);
		                List<LOG_XL_HANG_LOATInfo> resultLOG_XL_HANG_LOAT = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().LOG_XL_HANG_LOAT_GetAllWithPadding(USER_NAME,FUNCTION_NAME,_TIME_START_DATE, _TIME_END_DATE,int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableLOG_XL_HANG_LOAT = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().ToDataTable(resultLOG_XL_HANG_LOAT);
		                designer.SetDataSource("LOG_XL_HANG_LOAT", dataTableLOG_XL_HANG_LOAT.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_XL_HANG_LOAT_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_XL_HANG_LOAT_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "LOG_XL_HANG_LOAT_EXPORT_DATA");
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
		#region Create Functions "LOG_XL_QUY_TRINH"
		public Response LOG_XL_QUY_TRINH_Add(LOG_XL_QUY_TRINHInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().Add(info);
				    if(result == 0)
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
		public Response LOG_XL_QUY_TRINH_Update(LOG_XL_QUY_TRINHInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().Update(info);
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
		public Response LOG_XL_QUY_TRINH_Delete(string ID)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().Delete(int.Parse(ID));
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
		public ResponseList<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetList()
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    List<LOG_XL_QUY_TRINHInfo> result = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().GetList();
				    return new ResponseList<LOG_XL_QUY_TRINHInfo>
				    {
						ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
						Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
						TotalRecords = result != null ? result.Count : 0,
						Data = result
				    };
				}
				else
				{
				    return new ResponseList<LOG_XL_QUY_TRINHInfo>
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
				return new ResponseList<LOG_XL_QUY_TRINHInfo>
				{
				    ResultCode = Constant.RETURN_CODE_ERROR,
				    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
				    TotalRecords = 0,
				    Data = null
				};
		    }
		}
		public ResponsePage<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetAllWithPadding(string  USER_NAME,string  STEP,string LOG_TIME_START_DATE,string LOG_TIME_END_DATE,string  ACTION,string IS_DELETE, string pageIndex, string pageSize)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                STEP = STEP == "-1" ? string.Empty : STEP;
		                DateTime _LOG_TIME_START_DATE = LOG_TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(LOG_TIME_START_DATE.Split('-')[2]), int.Parse(LOG_TIME_START_DATE.Split('-')[1]), int.Parse(LOG_TIME_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _LOG_TIME_END_DATE = LOG_TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(LOG_TIME_END_DATE.Split('-')[2]), int.Parse(LOG_TIME_END_DATE.Split('-')[1]), int.Parse(LOG_TIME_END_DATE.Split('-')[0]), 23, 59, 59);
		                ACTION = ACTION == "-1" ? string.Empty : ACTION;
				    List<LOG_XL_QUY_TRINHInfo> result = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().LOG_XL_QUY_TRINH_GetAllWithPadding(USER_NAME,STEP,_LOG_TIME_START_DATE, _LOG_TIME_END_DATE,ACTION,int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
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
		public Response LOG_XL_QUY_TRINH_EXPORT_TEMPLATE(string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_XL_QUY_TRINH_EXPORT_TEMPLATE.xlsx";
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
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_XL_QUY_TRINH_EXPORT_TEMPLATE");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_XL_QUY_TRINH_EXPORT_TEMPLATE");
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
		public Response LOG_XL_QUY_TRINH_EXPORT_DATA(string  USER_NAME,string  STEP,string LOG_TIME_START_DATE,string LOG_TIME_END_DATE,string  ACTION,string IS_DELETE, string extension)
		{
		    try
		    {
		        if (!string.IsNullOrEmpty(Authorization))
		        {
		            string pathFileExcel = string.Empty;
		            string designerFile = HttpContext.Current.Server.MapPath("~") + "/Report/Template/LOG_XL_QUY_TRINH_EXPORT_DATA.xlsx";
		            if (File.Exists(designerFile))
		            {
		                int totalRecords = 0;
		                USER_NAME = USER_NAME == "-1" ? string.Empty : USER_NAME;
		                STEP = STEP == "-1" ? string.Empty : STEP;
		                DateTime _LOG_TIME_START_DATE = LOG_TIME_START_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddYears(-10) : new DateTime(int.Parse(LOG_TIME_START_DATE.Split('-')[2]), int.Parse(LOG_TIME_START_DATE.Split('-')[1]), int.Parse(LOG_TIME_START_DATE.Split('-')[0]), 0, 0, 0);
		                DateTime _LOG_TIME_END_DATE = LOG_TIME_END_DATE == "-1" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : new DateTime(int.Parse(LOG_TIME_END_DATE.Split('-')[2]), int.Parse(LOG_TIME_END_DATE.Split('-')[1]), int.Parse(LOG_TIME_END_DATE.Split('-')[0]), 23, 59, 59);
		                ACTION = ACTION == "-1" ? string.Empty : ACTION;
		                List<LOG_XL_QUY_TRINHInfo> resultLOG_XL_QUY_TRINH = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().LOG_XL_QUY_TRINH_GetAllWithPadding(USER_NAME,STEP,_LOG_TIME_START_DATE, _LOG_TIME_END_DATE,ACTION,int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
		                var designer = new WorkbookDesigner();
		                var loadOptions = new LoadOptions(LoadFormat.Xlsx);
		                designer.Workbook = new Workbook(designerFile, loadOptions);
		                DataTable dataTableLOG_XL_QUY_TRINH = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().ToDataTable(resultLOG_XL_QUY_TRINH);
		                designer.SetDataSource("LOG_XL_QUY_TRINH", dataTableLOG_XL_QUY_TRINH.DefaultView);
		                designer.Process();
		                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Report/Export"))
		                {
		                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "/Report/Export");
		                }
		                switch (extension.ToLower())
		                {
		                    case "xls":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xls", "LOG_XL_QUY_TRINH_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Excel97To2003);
		                        break;
		                    case "xlsx":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.xlsx", "LOG_XL_QUY_TRINH_EXPORT_DATA");
		                        designer.Workbook.Save(Path.Combine(HttpContext.Current.Server.MapPath("~") + pathFileExcel), SaveFormat.Xlsx);
		                        break;
		                    case "pdf":
		                        pathFileExcel = "/Report/Export/" + String.Format("{0}.pdf", "LOG_XL_QUY_TRINH_EXPORT_DATA");
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
		#region Create Functions "SHARE_DD_MO_TD"
		public Response SHARE_DD_MO_TD_Add(SHARE_DD_MO_TDInfo info)
		{
		    try
		    {
				if (!string.IsNullOrEmpty(Authorization))
				{
				    int result = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().Add(info);
				    if(result == 0)
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
		public ResponsePage<SHARE_DD_MO_TDInfo> SHARE_DD_MO_TD_GetAllWithPadding(string  MA_DVI,string  LOAIDAT,string  SOTOGOC,string  SOTOCU,string  SOTHUACU,string  MAKVUC,string  MAHUYEN,string  MAXA,string  SOTO,string  SOTHUA,string IS_DELETE, string pageIndex, string pageSize)
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
				    List<SHARE_DD_MO_TDInfo> result = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().SHARE_DD_MO_TD_GetAllWithPadding(MA_DVI,LOAIDAT,SOTOGOC,SOTOCU,SOTHUACU,MAKVUC,MAHUYEN,MAXA,int.Parse(SOTO),int.Parse(SOTHUA),int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
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
		public Response SHARE_DD_MO_TD_EXPORT_DATA(string  MA_DVI,string  LOAIDAT,string  SOTOGOC,string  SOTOCU,string  SOTHUACU,string  MAKVUC,string  MAHUYEN,string  MAXA,string  SOTO,string  SOTHUA,string IS_DELETE, string extension)
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
		                List<SHARE_DD_MO_TDInfo> resultSHARE_DD_MO_TD = DataObjectFactory.GetInstanceSHARE_DD_MO_TD().SHARE_DD_MO_TD_GetAllWithPadding(MA_DVI,LOAIDAT,SOTOGOC,SOTOCU,SOTHUACU,MAKVUC,MAHUYEN,MAXA,int.Parse(SOTO),int.Parse(SOTHUA),int.Parse(IS_DELETE), 1, int.MaxValue, ref totalRecords);
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
