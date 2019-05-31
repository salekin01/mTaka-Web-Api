using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
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
    public interface IAccStatusSetupService
    {
        IEnumerable<AccStatusSetup> GetAllAccStatusSetup();
        AccStatusSetup GetAccStatusSetupById(string _AccountStatusId);
        AccStatusSetup GetAccStatusSetupBy(AccStatusSetup _AccStatusSetup);
        int AddAccStatusSetup(AccStatusSetup _AccStatusSetup);
        int UpdateAccStatusSetup(AccStatusSetup _AccStatusSetup);
        int DeleteAccStatusSetup(AccStatusSetup _AccStatusSetup);
        IEnumerable<SelectListItem> GetAccStatusSetupForDD();
    }
    public class AccStatusSetupService : IAccStatusSetupService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public AccStatusSetupService()
        {
            _IUoW = new UnitOfWork();
        }
        public AccStatusSetupService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<AccStatusSetup> GetAllAccStatusSetup()
        {
            try
            {
                var AllAccStatusSetup = _IUoW.Repository<AccStatusSetup>().Get(x => x.AuthStatusId == "A" &&
                                                               x.LastAction != "DEL").OrderByDescending(x => x.AccountStatusId);
                return AllAccStatusSetup;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllAccStatusSetup()", string.Empty);
                return null;
            }
            //try
            //{
            //    List<AccStatusSetup> OBJ_LIST_AccStatusSetup = new List<AccStatusSetup>();
            //    var _ListAccStatusSetup = _IUoW.Repository<AccStatusSetup>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.AccountStatusId);
            //    foreach (var item in _ListAccStatusSetup)
            //    {
            //        AccStatusSetup OBJ_AccStatusSetup = new AccStatusSetup();

            //        OBJ_AccStatusSetup.AccountStatusId = item.AccountStatusId;
            //        OBJ_AccStatusSetup.AccountStatusName = item.AccountStatusName;
            //        OBJ_AccStatusSetup.AuthStatusId = item.AuthStatusId;
            //        OBJ_AccStatusSetup.LastAction = item.LastAction;
            //        OBJ_AccStatusSetup.LastUpdateDT = item.LastUpdateDT;
            //        OBJ_AccStatusSetup.MakeBy = item.MakeBy;
            //        OBJ_AccStatusSetup.MakeDT = item.MakeDT;
            //        OBJ_AccStatusSetup.TransDT = item.TransDT;
            //        OBJ_LIST_AccStatusSetup.Add(OBJ_AccStatusSetup);
            //    }
            //    return OBJ_LIST_AccStatusSetup;
            //}
            //catch (Exception ex)
            //{
            //    _ObjErrorLogService = new ErrorLogService();
            //    _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllAccStatusSetup()", string.Empty);
            //    return null;
            //}
        }

        public AccStatusSetup GetAccStatusSetupById(string _AccountStatusId)
        {
            try
            {
                return _IUoW.Repository<AccStatusSetup>().GetById(_AccountStatusId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAccStatusSetupById(string)", string.Empty);
                return null;
            }
        }
        public AccStatusSetup GetAccStatusSetupBy(AccStatusSetup _AccStatusSetup)
        {
            try
            {
                if (_AccStatusSetup == null)
                {
                    return _AccStatusSetup;
                }
                return _IUoW.Repository<AccStatusSetup>().GetBy(x => x.AccountStatusId == _AccStatusSetup.AccountStatusId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAccStatusSetupBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddAccStatusSetup(AccStatusSetup _AccStatusSetup)
        {
            try
            {
                var _max = _IUoW.Repository<AccStatusSetup>().GetMaxValue(x => x.AccountStatusId) + 1;
                _AccStatusSetup.AccountStatusId = _max.ToString().PadLeft(3, '0');
                _AccStatusSetup.AuthStatusId = "A";
                _AccStatusSetup.LastAction = "ADD";
                _AccStatusSetup.MakeDT = System.DateTime.Now;
                _AccStatusSetup.MakeBy = "mtaka";
                var result = _IUoW.Repository<AccStatusSetup>().Add(_AccStatusSetup);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _AccStatusSetup, "ADD", "0001", _AccStatusSetup.FunctionId, 1, "AccStatusSetup", "MTK_SP_ACC_STATUS_SETUP", "AccountStatusId", _AccStatusSetup.AccountStatusId, _AccStatusSetup.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAccStatusSetup(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateAccStatusSetup(AccStatusSetup _AccStatusSetup)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AccStatusSetup.AccountStatusId))
                {
                    IsRecordExist = _IUoW.Repository<AccStatusSetup>().IsRecordExist(x => x.AccountStatusId == _AccStatusSetup.AccountStatusId);
                    if (IsRecordExist)
                    {
                        var _oldAccStatusSetup = _IUoW.Repository<AccStatusSetup>().GetBy(x => x.AccountStatusId == _AccStatusSetup.AccountStatusId);
                        var _oldAccStatusSetupForLog = ObjectCopier.DeepCopy(_oldAccStatusSetup);

                        _oldAccStatusSetup.AuthStatusId = _AccStatusSetup.AuthStatusId = "U";
                        _oldAccStatusSetup.LastAction = _AccStatusSetup.LastAction = "EDT";
                        _oldAccStatusSetup.LastUpdateDT = _AccStatusSetup.LastUpdateDT = System.DateTime.Now;
                        _AccStatusSetup.MakeBy = "mtaka";
                        result = _IUoW.Repository<AccStatusSetup>().Update(_oldAccStatusSetup);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldAccStatusSetupForLog, _AccStatusSetup, "EDT", "0001", _AccStatusSetup.FunctionId, 1, "AccStatusSetup", "MTK_SP_ACC_STATUS_SETUP", "AccountStatusId", _AccStatusSetup.AccountStatusId, _AccStatusSetup.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateAccStatusSetup(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteAccStatusSetup(AccStatusSetup _AccStatusSetup)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AccStatusSetup.AccountStatusId))
                {
                    IsRecordExist = _IUoW.Repository<AccStatusSetup>().IsRecordExist(x => x.AccountStatusId == _AccStatusSetup.AccountStatusId);
                    if (IsRecordExist)
                    {
                        var _oldAccStatusSetup = _IUoW.Repository<AccStatusSetup>().GetBy(x => x.AccountStatusId == _AccStatusSetup.AccountStatusId);
                        var _oldAccStatusSetupForLog = ObjectCopier.DeepCopy(_oldAccStatusSetup);

                        _oldAccStatusSetup.AuthStatusId = _AccStatusSetup.AuthStatusId = "U";
                        _oldAccStatusSetup.LastAction = _AccStatusSetup.LastAction = "DEL";
                        _oldAccStatusSetup.LastUpdateDT = _AccStatusSetup.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<AccStatusSetup>().Update(_oldAccStatusSetup);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldAccStatusSetupForLog, _AccStatusSetup, "DEL", "0001", _AccStatusSetup.FunctionId, 1, "AccStatusSetup", "MTK_SP_ACC_STATUS_SETUP", "AccountStatusId", _AccStatusSetup.AccountStatusId, _AccStatusSetup.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteAccStatusSetup(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetAccStatusSetupForDD()
        {
            try
            {
                var List_Acc_Status_Setup = _IUoW.Repository<AccStatusSetup>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.AccountStatusId, n.AccountStatusName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Acc_Status_Setup)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AccountStatusId,
                        Text = element.AccountStatusName
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAccStatusSetupForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}

