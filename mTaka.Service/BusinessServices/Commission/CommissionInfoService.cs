using mTaka.Data.BusinessEntities.Commission;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mTaka.Service.BusinessServices.Commission
{
    public interface ICommissionInfoService
    {
        List<CommissionSetup> GetAllCommissionSetup();
        CommissionSetup GetCommissionSetupId(string _CommissionSetupId);
        CommissionSetup GetCommissionSetupBy(CommissionSetup _CommissionSetup);
        int AddCommissionSetup(CommissionSetup _CommissionSetup);
        int UpdateCommissionSetup(CommissionSetup _CommissionSetup);
        int DeleteCommissionSetup(CommissionSetup _CommissionSetup);
    }
    public class CommissionInfoService : ICommissionInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public CommissionInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public CommissionInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<CommissionSetup> GetAllCommissionSetup()
        {
            try
            {
                return _IUoW.Repository<CommissionSetup>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.CommissionId).ToList();
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCommissionSetup()", string.Empty);
                return null;
            }

        }

        public CommissionSetup GetCommissionSetupBy(CommissionSetup _CommissionSetup)
        {
            try
            {
                if (_CommissionSetup == null)
                {
                    return _CommissionSetup;
                }
                return _IUoW.Repository<CommissionSetup>().GetBy(x => x.CommissionId == _CommissionSetup.CommissionId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCommissionSetupBy(obj)", string.Empty);
                return null;
            }
        }

        public CommissionSetup GetCommissionSetupId(string _CommissionSetupId)
        {
            try
            {
                return _IUoW.Repository<CommissionSetup>().GetById(_CommissionSetupId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCommissionSetupId(string)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddCommissionSetup(CommissionSetup _CommissionSetup)
        {
            try
            {
                var _max = _IUoW.Repository<CommissionSetup>().GetMaxValue(x => x.CommissionId) + 1;
                _CommissionSetup.CommissionId = _max.ToString().PadLeft(8, '0');
                _CommissionSetup.AuthStatusId = "A";
                _CommissionSetup.LastAction = "ADD";
                _CommissionSetup.MakeDT = System.DateTime.Now;
                _CommissionSetup.MakeBy = "mtaka";
                var result = _IUoW.Repository<CommissionSetup>().Add(_CommissionSetup);

                List<CommissionSetupDTL> objListCommissionSetupDTL = new List<CommissionSetupDTL>();
                var _maxCus = _IUoW.Repository<CommissionSetupDTL>().GetMaxValue(x => x.CommissionDtlId) + 1;
                for (int i = 0; i < _CommissionSetup.ListCommissionSetupDTL.Length; i++)
                {
                    CommissionSetupDTL _objCommissionSetupDTL = new CommissionSetupDTL();

                    _objCommissionSetupDTL.CommissionDtlId = _maxCus.ToString().PadLeft(8, '0');
                    _objCommissionSetupDTL.CommissionId = _CommissionSetup.CommissionId;
                    _objCommissionSetupDTL.AccTypeId = _CommissionSetup.ListCommissionSetupDTL[i].AccTypeId;
                    _objCommissionSetupDTL.CommissionRate = _CommissionSetup.ListCommissionSetupDTL[i].CommissionRate;
                    _objCommissionSetupDTL.AIT = _CommissionSetup.ListCommissionSetupDTL[i].AIT;
                    _objCommissionSetupDTL.AuthStatusId = "U";
                    _objCommissionSetupDTL.LastAction = "ADD";
                    _objCommissionSetupDTL.MakeBy = "mTaka";
                    _objCommissionSetupDTL.MakeDT = System.DateTime.Now;
                    objListCommissionSetupDTL.Add(_objCommissionSetupDTL);
                    _maxCus += 1;
                }
                result = _IUoW.Repository<CommissionSetupDTL>().AddRange(objListCommissionSetupDTL);

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _CommissionSetup, "ADD", "0001", _CommissionSetup.FunctionId, 1, "CommissionSetupDTL", "MTK_COMMISSION_SETUP_DTL", "CommisionId", _CommissionSetup.CommissionId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCommissionSetup(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateCommissionSetup(CommissionSetup _CommissionSetup)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CommissionSetup.CommissionId))
                {
                    IsRecordExist = _IUoW.Repository<CommissionSetup>().IsRecordExist(x => x.CommissionId == _CommissionSetup.CommissionId);
                    if (IsRecordExist)
                    {
                        var _oldCommissionSetup = _IUoW.Repository<CommissionSetup>().GetBy(x => x.CommissionId == _CommissionSetup.CommissionId);
                        var _oldCommissionSetupForLog = ObjectCopier.DeepCopy(_oldCommissionSetup);

                        _oldCommissionSetup.AuthStatusId = _CommissionSetup.AuthStatusId = "U";
                        _oldCommissionSetup.LastAction = _CommissionSetup.LastAction = "EDT";
                        _oldCommissionSetup.LastUpdateDT = _CommissionSetup.LastUpdateDT = System.DateTime.Now;
                        _CommissionSetup.MakeBy = "mtaka";
                        result = _IUoW.Repository<CommissionSetup>().Update(_oldCommissionSetup);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCommissionSetupForLog, _CommissionSetup, "EDT", "0001", "090101008", 1, "CommissionSetup", "MTK_COMMISSION_SETUP", "CommisionId", _CommissionSetup.CommissionId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateCommissionSetup(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteCommissionSetup(CommissionSetup _CommissionSetup)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CommissionSetup.CommissionId))
                {
                    IsRecordExist = _IUoW.Repository<CommissionSetup>().IsRecordExist(x => x.CommissionId == _CommissionSetup.CommissionId);
                    if (IsRecordExist)
                    {
                        var _oldCommissionSetup = _IUoW.Repository<CommissionSetup>().GetBy(x => x.CommissionId == _CommissionSetup.CommissionId);
                        var _oldCommissionSetupForLog = ObjectCopier.DeepCopy(_oldCommissionSetup);

                        _oldCommissionSetup.AuthStatusId = _CommissionSetup.AuthStatusId = "U";
                        _oldCommissionSetup.LastAction = _CommissionSetup.LastAction = "DEL";
                        _oldCommissionSetup.LastUpdateDT = _CommissionSetup.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<CommissionSetup>().Update(_oldCommissionSetup);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCommissionSetupForLog, _CommissionSetup, "DEL", "0001", "090101008", 1, "CommissionSetup", "MTK_COMMISSION_SETUP", "CommissionId", _CommissionSetup.CommissionId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteCommissionSetup(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

    }
}
