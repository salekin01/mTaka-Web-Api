using mTaka.Data.BusinessEntities;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Data.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.WebPages.Html;

namespace mTaka.Service.ReportService
{
    public interface IReportService
    {
        ReportConfigMaster GetReportConfigMasterByFunctionId(string _FunctionId);
        List<ReportConfigParam> GetReportConfigParamByFunctionId(string _FunctionId);
        DatabaseConnectionConfig GetDatabaseConConfigByFunctionId(string _FunctionId);
        IEnumerable<SelectListItem> GetReportFunctionForDD();
    }

    public class ReportService : IReportService
    {
        private IUnitOfWork _IUoW = null;
        ErrorLogService _ObjErrorLogService = null;
        public ReportService()
        {
            _IUoW = new UnitOfWork();
        }
        public ReportService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }



        #region Index

        public ReportConfigMaster GetReportConfigMasterByFunctionId(string _FunctionId)
        {
            try
            {
                return _IUoW.Repository<ReportConfigMaster>().GetById(_FunctionId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReportConfigParam> GetReportConfigParamByFunctionId(string _FunctionId)
        {
            try
            {
                return _IUoW.Repository<ReportConfigParam>().Get(r => r.FunctionId == _FunctionId).OrderBy(x => x.SlNo).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DatabaseConnectionConfig GetDatabaseConConfigByFunctionId(string _FunctionId)
        {
            try
            {
                return _IUoW.Repository<DatabaseConnectionConfig>().GetById(_FunctionId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region DropDown
        public IEnumerable<SelectListItem> GetReportFunctionForDD()
        {
            try
            {
                _IUoW = new UnitOfWork();
                List<GetReportFunctionIdsResult> LIST_GetMFSReportMenuResult = new List<GetReportFunctionIdsResult>();


                string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetReportFunctionIds/09?format=json";
                using (WebClient wc = new WebClient())
                {
                    ReportMenuService OBJ_GetMFSReportMenuResult = new ReportMenuService();    //commented for temporary time by salekin
                    var json = wc.DownloadString(url);
                    OBJ_GetMFSReportMenuResult = JsonConvert.DeserializeObject<ReportMenuService>(json);
                    LIST_GetMFSReportMenuResult = OBJ_GetMFSReportMenuResult.GetReportFunctionIdsResult;
                }
                if (LIST_GetMFSReportMenuResult == null)
                {
                    return null;
                }

                var selectList = new List<SelectListItem>();

                for (int j = 0; j < LIST_GetMFSReportMenuResult.Count(); j++)
                {
                    if (LIST_GetMFSReportMenuResult[j].FUNCTION_ID != null)
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = LIST_GetMFSReportMenuResult[j].FUNCTION_ID.ToString(),
                            Text = LIST_GetMFSReportMenuResult[j].FUNCTION_NM
                        });
                    }
                }

                if (selectList != null)
                    return selectList;
                else
                    return null;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetReportFunctionForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }


}
