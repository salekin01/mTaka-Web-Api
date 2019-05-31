using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.BusinessServices.CP;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.SP
{
    public interface IStatusWiseServiceService
    {
        List<StatusWiseService> GetAllStatusWiseService();
        StatusWiseService GetStatusWiseServiceById(string _StatusWiseServiceId);
        StatusWiseService GetStatusWiseServiceBy(StatusWiseService _StatusWiseService);
        int AddStatusWiseService(StatusWiseService _StatusWiseService);
        int UpdateStatusWiseService(StatusWiseService _StatusWiseService);
        int DeleteStatusWiseService(StatusWiseService _StatusWiseService);
        int CheckStatusWiseService(StatusWiseService _StatusWiseService);
    }
    public class StatusWiseServiceService : IStatusWiseServiceService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public StatusWiseServiceService()
        {
            _IUoW = new UnitOfWork();
        }
        public StatusWiseServiceService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<StatusWiseService> GetAllStatusWiseService()
        {
            try
            {
                List<StatusWiseService> OBJ_LIST_StatusWiseService = new List<StatusWiseService>();
                var _ListStatusWiseService = _IUoW.Repository<StatusWiseService>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.StatusWiseServiceId);
                foreach (var item in _ListStatusWiseService)
                {
                    StatusWiseService OBJ_StatusWiseService = new StatusWiseService();
                    DefineServiceService OBJ_DefineServiceService = new DefineServiceService();
                    AccStatusSetupService OBJ_AccStatusSetupService = new AccStatusSetupService();

                    OBJ_StatusWiseService.StatusWiseServiceId = item.StatusWiseServiceId;
                    OBJ_StatusWiseService.DefineServiceId = item.DefineServiceId;
                    foreach (var item1 in OBJ_DefineServiceService.GetDefineServiceForDD())
                    {
                        if (item1.Value == OBJ_StatusWiseService.DefineServiceId)
                        {
                            OBJ_StatusWiseService.DefineServiceNm = item1.Text;
                        }
                    }
                    OBJ_StatusWiseService.AccountStatusId = item.AccountStatusId;
                    foreach (var item1 in OBJ_AccStatusSetupService.GetAccStatusSetupForDD())
                    {
                        if (item1.Value == OBJ_StatusWiseService.AccountStatusId)
                        {
                            OBJ_StatusWiseService.AccountStatusName = item1.Text;
                        }
                    }
                    OBJ_StatusWiseService.AuthStatusId = item.AuthStatusId;
                    OBJ_StatusWiseService.LastAction = item.LastAction;
                    OBJ_StatusWiseService.LastUpdateDT = item.LastUpdateDT;
                    OBJ_StatusWiseService.MakeBy = item.MakeBy;
                    OBJ_StatusWiseService.MakeDT = item.MakeDT;
                    OBJ_StatusWiseService.TransDT = item.TransDT;
                    OBJ_LIST_StatusWiseService.Add(OBJ_StatusWiseService);
                }
                return OBJ_LIST_StatusWiseService;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllStatusWiseService()", string.Empty);
                return null;
            }
        }

        public StatusWiseService GetStatusWiseServiceById(string _StatusWiseServiceId)
        {
            try
            {
                return _IUoW.Repository<StatusWiseService>().GetById(_StatusWiseServiceId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetStatusWiseServiceById(string)", string.Empty);
                return null;
            }
        }
        public StatusWiseService GetStatusWiseServiceBy(StatusWiseService _StatusWiseService)
        {
            try
            {
                if (_StatusWiseService == null)
                {
                    return _StatusWiseService;
                }
                return _IUoW.Repository<StatusWiseService>().GetBy(x => x.StatusWiseServiceId == _StatusWiseService.StatusWiseServiceId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetStatusWiseServiceBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddStatusWiseService(StatusWiseService _StatusWiseService)
        {
            try
            {
                var _max = _IUoW.Repository<StatusWiseService>().GetMaxValue(x => x.StatusWiseServiceId) + 1;
                _StatusWiseService.StatusWiseServiceId = _max.ToString().PadLeft(3, '0');
                _StatusWiseService.AuthStatusId = "U";
                _StatusWiseService.LastAction = "ADD";
                _StatusWiseService.MakeDT = System.DateTime.Now;
                _StatusWiseService.MakeBy = "prova";
                var result = _IUoW.Repository<StatusWiseService>().Add(_StatusWiseService);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _StatusWiseService, "ADD", "0001", _StatusWiseService.FunctionId, 1, "StatusWiseService", "MTK_SP_STATUS_WISE_SERVICE", "StatusWiseServiceId", _StatusWiseService.StatusWiseServiceId, _StatusWiseService.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                }
                #endregion

                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddStatusWiseService(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateStatusWiseService(StatusWiseService _StatusWiseService)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_StatusWiseService.StatusWiseServiceId))
                {
                    IsRecordExist = _IUoW.Repository<StatusWiseService>().IsRecordExist(x => x.StatusWiseServiceId == _StatusWiseService.StatusWiseServiceId);
                    if (IsRecordExist)
                    {
                        var _oldStatusWiseService = _IUoW.Repository<StatusWiseService>().GetBy(x => x.StatusWiseServiceId == _StatusWiseService.StatusWiseServiceId);
                        var _oldStatusWiseServiceForLog = ObjectCopier.DeepCopy(_oldStatusWiseService);

                        _oldStatusWiseService.AuthStatusId = _StatusWiseService.AuthStatusId = "U";
                        _oldStatusWiseService.LastAction = _StatusWiseService.LastAction = "EDT";
                        _oldStatusWiseService.LastUpdateDT = _StatusWiseService.LastUpdateDT = System.DateTime.Now;
                        _StatusWiseService.MakeBy = "prova";
                        result = _IUoW.Repository<StatusWiseService>().Update(_oldStatusWiseService);                        

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldStatusWiseServiceForLog, _StatusWiseService, "EDT", "0001", _StatusWiseService.FunctionId, 1, "StatusWiseService", "MTK_SP_STATUS_WISE_SERVICE", "StatusWiseServiceId", _StatusWiseService.StatusWiseServiceId, _StatusWiseService.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateStatusWiseService(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteStatusWiseService(StatusWiseService _StatusWiseService)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_StatusWiseService.StatusWiseServiceId))
                {
                    IsRecordExist = _IUoW.Repository<StatusWiseService>().IsRecordExist(x => x.StatusWiseServiceId == _StatusWiseService.StatusWiseServiceId);
                    if (IsRecordExist)
                    {
                        var _oldStatusWiseService = _IUoW.Repository<StatusWiseService>().GetBy(x => x.StatusWiseServiceId == _StatusWiseService.StatusWiseServiceId);
                        var _oldStatusWiseServiceForLog = ObjectCopier.DeepCopy(_oldStatusWiseService);

                        _oldStatusWiseService.AuthStatusId = _StatusWiseService.AuthStatusId = "U";
                        _oldStatusWiseService.LastAction = _StatusWiseService.LastAction = "DEL";
                        _oldStatusWiseService.LastUpdateDT = _StatusWiseService.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<StatusWiseService>().Update(_oldStatusWiseService);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldStatusWiseServiceForLog, _StatusWiseService, "DEL", "0001", _StatusWiseService.FunctionId, 1, "StatusWiseService", "MTK_SP_STATUS_WISE_SERVICE", "StatusWiseServiceId", _StatusWiseService.StatusWiseServiceId, _StatusWiseService.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteStatusWiseService(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region CheckStatusWiseService
        public int CheckStatusWiseService(StatusWiseService _StatusWiseService)
        {
            int Check = 0;
            try
            {
                var _Acc_Info = _IUoW.Repository<AccMaster>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                    x.SystemAccountNo == _StatusWiseService.ToSystemAccountNo);
                if (_Acc_Info != null)
                {
                    var _Status_Wise_Service_Map = _IUoW.Repository<StatusWiseService>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                    x.AccountStatusId == _Acc_Info.AccountStatusId && x.DefineServiceId == _StatusWiseService.DefineServiceId);
                    if (_Status_Wise_Service_Map != null && _Status_Wise_Service_Map.TransactionAllow == "0")
                    {
                        Check = 0;
                    }
                    if (_Status_Wise_Service_Map != null && _Status_Wise_Service_Map.TransactionAllow == "1")
                    {
                        Check = 1;
                    }
                }
                return Check;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "CheckStatusWiseService(obj)", string.Empty);
                return Check;
            }
        }
        #endregion
    }
}
