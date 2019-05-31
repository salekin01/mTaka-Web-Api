using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Data.Report;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using System;
using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.SP
{
    public interface IReportConfigarationService
    {
        IEnumerable<ReportConfigMaster> GetAllReportConfigMaster();
        ReportConfigMaster GetReportConfigByFunc(string _FunctionId);
        ReportConfigMaster GetReportConfigurationBy(ReportConfigMaster _ReportConfiguration);
        int AddReportConfigMaster(ReportConfigMaster _ReportConfiguration);
        int UpdateReportConfigMaster(ReportConfigMaster _ReportConfiguration);
        int DeleteReportConfiguration(ReportConfigMaster _ReportConfiguration);

        IEnumerable<ReportConfigParam> GetReportConfigParamByFunc(string _FunctionId);
        IEnumerable<ReportConfigParam> GetReportConfigParamByFuncSl(string _FunctionId,int SL);
        int AddReportConfigParam(List<ReportConfigParam> _ReportConfigurationList);
        int UpdateReportConfigParam(ReportConfigParam _ReportConfiguration);
        int DeleteReportConfigParam(ReportConfigParam _ReportConfiguration);

        IEnumerable<SelectListItem> GetConnectionForDD();
        IEnumerable<SelectListItem> GetReportForDD();

    }
    public class ReportConfigarationService : IReportConfigarationService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public ReportConfigarationService()
        {
            _IUoW = new UnitOfWork();
        }
        public ReportConfigarationService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        #region Report Configaration Master
        #region Index of Report Configaration Master
        public IEnumerable<ReportConfigMaster> GetAllReportConfigMaster()
        {
            try
            {
                return _IUoW.Repository<ReportConfigMaster>().GetAll();

            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllReportConfiguration()", string.Empty);
                return null;
            }
        }



        public ReportConfigMaster GetReportConfigByFunc(string _FunctionId)
        {
            try
            {
                return _IUoW.Repository<ReportConfigMaster>().GetById(_FunctionId);

            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetReportConfigByFunc(_FunctionId)", string.Empty);
                return null;
            }
        }

        public ReportConfigMaster GetReportConfigurationBy(ReportConfigMaster _ReportConfiguration)
        {
            try
            {
                if (_ReportConfiguration == null)
                {
                    return _ReportConfiguration;
                }
                return _IUoW.Repository<ReportConfigMaster>().GetBy(x => x.FunctionId == _ReportConfiguration.FunctionId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetReportConfigurationBy(obj)", string.Empty);
                return null;
            }
        }

        #endregion

        public int AddReportConfigMaster(ReportConfigMaster _ReportConfiguration)
        {
            try
            {

                _ReportConfiguration.GenBeforeEod = _ReportConfiguration.GenBeforeEod == "True" ? "1" : "0";
                _ReportConfiguration.AutoGenPeriod = _ReportConfiguration.AutoGenPeriod == "True" ? "1" : "0";
                _ReportConfiguration.IsVisible = _ReportConfiguration.IsVisible == "True" ? "1" : "0";

                _ReportConfiguration.MakeDt = System.DateTime.Now;
                var result = _IUoW.Repository<ReportConfigMaster>().Add(_ReportConfiguration);

                if (result == 1)
                    _IUoW.Commit();
                
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddReportConfiguration(obj)", string.Empty);
                return 0;
            }
        }

        public int UpdateReportConfigMaster(ReportConfigMaster _ReportConfiguration)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ReportConfiguration.FunctionId))
                {
                    IsRecordExist = _IUoW.Repository<ReportConfigMaster>().IsRecordExist(x => x.FunctionId == _ReportConfiguration.FunctionId);
                    if (IsRecordExist)
                    {
                        _ReportConfiguration.GenBeforeEod = _ReportConfiguration.GenBeforeEod == "True" ? "1" : "0";
                        _ReportConfiguration.AutoGenPeriod = _ReportConfiguration.AutoGenPeriod == "True" ? "1" : "0";
                        _ReportConfiguration.IsVisible = _ReportConfiguration.IsVisible == "True" ? "1" : "0";
                        result = _IUoW.Repository<ReportConfigMaster>().Update(_ReportConfiguration);
                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateReportConfiguration(obj)", string.Empty);
                return 0;
            }
        }

        public int DeleteReportConfiguration(ReportConfigMaster _ReportConfiguration)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Report Configaration Peram

        #region Index of Report Configaration Param
        public IEnumerable<ReportConfigParam> GetReportConfigParamByFunc(string _FunctionId)
        {
            try
            {
                return _IUoW.Repository<ReportConfigParam>().Get(x => x.FunctionId == _FunctionId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetReportConfigByFunc(_FunctionId)", string.Empty);
                return null;
            }
        }
        public IEnumerable<ReportConfigParam> GetReportConfigParamByFuncSl(string _FunctionId,int SL)
        {
            try
            {
                return _IUoW.Repository<ReportConfigParam>().Get(x => x.FunctionId == _FunctionId && x.SlNo==SL);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetReportConfigByFunc(_FunctionId)", string.Empty);
                return null;
            }
        }
        #endregion
        public int AddReportConfigParam(List<ReportConfigParam> _ReportConfigurationList)
        {
            try
            {
                int result = 0;
                if (_ReportConfigurationList != null && _ReportConfigurationList.Count > 0)
                {
                    List<ReportConfigParam> List_ReportConfigParam = new List<ReportConfigParam>();
                    var _max = _IUoW.mTakaDbQuery().MaxSl(_ReportConfigurationList[0].FunctionId) + 1;
                    for (int i = 0; i < _ReportConfigurationList.Count; i++)
                    {
                        ReportConfigParam _ObjReportConfigParam = new ReportConfigParam();
                        _ObjReportConfigParam.SlNo = _max;
                        _ObjReportConfigParam.IsMandatory = _ReportConfigurationList[i].IsMandatory == "True" ? "1" : "0";
                        _ObjReportConfigParam.IsVisible = _ReportConfigurationList[i].IsVisible == "True" ? "1" : "0";
                        _ObjReportConfigParam.IsReadonly = _ReportConfigurationList[i].IsReadonly == "True" ? "1" : "0";
                    
                        _ObjReportConfigParam.ControlType = _ReportConfigurationList[i].ControlType;
                        _ObjReportConfigParam.DefaultValue = _ReportConfigurationList[i].DefaultValue;
                        _ObjReportConfigParam.FunctionId = _ReportConfigurationList[i].FunctionId;
                        _ObjReportConfigParam.ListSpName = _ReportConfigurationList[i].ListSpName;
                        _ObjReportConfigParam.MaxValue = _ReportConfigurationList[i].MaxValue;
                        _ObjReportConfigParam.MinValue = _ReportConfigurationList[i].MinValue;
                        _ObjReportConfigParam.Parameter = _ReportConfigurationList[i].Parameter;
                        _ObjReportConfigParam.ParameterDatatype = _ReportConfigurationList[i].ParameterDatatype;
                        _ObjReportConfigParam.ParameterMaxlength = _ReportConfigurationList[i].ParameterMaxlength;
                        _ObjReportConfigParam.ParameterName = _ReportConfigurationList[i].ParameterName;
                        _ObjReportConfigParam.ParameterUserAsist = _ReportConfigurationList[i].ParameterUserAsist;
                        _ObjReportConfigParam.AuthStatusId = "U";
                        _ObjReportConfigParam.LastAction = "ADD";
                        _ObjReportConfigParam.MakeBy = "mtaka";
                        _ObjReportConfigParam.MakeDT = System.DateTime.Now;
                        _max += 1;
                        List_ReportConfigParam.Add(_ObjReportConfigParam);
                    }
                    result = _IUoW.Repository<ReportConfigParam>().AddRange(List_ReportConfigParam);
                    if (result == 1)
                    {
                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, List_ReportConfigParam, "ADD", "0001", _ReportConfigurationList[0].FunctionId, 1, "ReportConfigParam", "MTK_RPT_CONFIG_PARAM", "FunctionId", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    }
                    
                }
                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddReportConfigParam(obj)", string.Empty);
                return 0;
            }
        }
        public int UpdateReportConfigParam(ReportConfigParam _ReportConfiguration)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ReportConfiguration.FunctionId))
                {
                    IsRecordExist = _IUoW.Repository<ReportConfigParam>().IsRecordExist(x => x.FunctionId == _ReportConfiguration.FunctionId && x.SlNo == _ReportConfiguration.SlNo);
                   
                    if (IsRecordExist)
                    {
                        //var _oldReportConfiguration = _IUoW.Repository<ReportConfigParam>().GetBy(x => x.FunctionId == _ReportConfiguration.FunctionId && x.SlNo == _ReportConfiguration.SlNo);
                        //var _oldReportConfigurationForLog = ObjectCopier.DeepCopy(_oldReportConfiguration);

                        _ReportConfiguration.IsMandatory = _ReportConfiguration.IsMandatory == "True" ? "1" : "0";
                        _ReportConfiguration.IsVisible = _ReportConfiguration.IsVisible == "True" ? "1" : "0";
                        _ReportConfiguration.IsReadonly = _ReportConfiguration.IsReadonly == "True" ? "1" : "0";
                        _ReportConfiguration.AuthStatusId = "U";
                        _ReportConfiguration.LastAction = "EDT";
                        _ReportConfiguration.LastUpdateDT = System.DateTime.Now;
                        _ReportConfiguration.MakeBy = "mtaka";
                        result = _IUoW.Repository<ReportConfigParam>().Update(_ReportConfiguration);
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            //result = _IAuthLogService.AddAuthLog(_IUoW, null, _ReportConfiguration, "EDT", "0001", "090102010", 1, "ReportConfigParam", "MTK_SP_TRANSACTION_TEMPLATE", "FunctionId", _ReportConfiguration.FunctionId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateReportConfigParam(obj)", string.Empty);
                return 0;
            }
        }

        public int DeleteReportConfigParam(ReportConfigParam _ReportConfiguration)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region For ddl load
        public IEnumerable<SelectListItem> GetConnectionForDD()
        {
            try
            {
                var List_Report_DB_Con = _IUoW.Repository<DatabaseConnectionConfig>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Report_DB_Con)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.ConnectionId,
                        Text = element.ConnectionNm
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    return null;
                //throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetConnectionForDD()", string.Empty);
                return null;
            }
        }
        public IEnumerable<SelectListItem> GetReportForDD()
        {
            try
            {
                var List_Report_DB_Con = _IUoW.Repository<ReportConfigMaster>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Report_DB_Con)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.FunctionId,
                        Text = element.ReportName
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    return null;
                //throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetReportForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
