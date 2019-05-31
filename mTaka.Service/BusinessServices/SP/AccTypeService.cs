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
    public interface IAccTypeService
    {
        IEnumerable<AccType> GetAllAccType();
        AccType GetAccTypeById(string _AccTypeId);
        AccType GetAccTypeBy(AccType _AccTypeBy);
        int AddAccType(AccType _AccType);
        int UpdateAccType(AccType _AccType);
        int DeleteAccType(AccType _AccType);
        IEnumerable<SelectListItem> GetAccTypeForDD();
    }

    public class AccTypeService : IAccTypeService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public AccTypeService()
        {
            _IUoW = new UnitOfWork();
        }

        public AccTypeService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<AccType> GetAllAccType()
        {
            try
            {
                var AllAccType= _IUoW.mTakaDbQuery().GetAllAccType_LQ().OrderByDescending(x => x.AccTypeId);
                return AllAccType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllAccType()", string.Empty);
                return null;
            }
        }

        public AccType GetAccTypeById(string _AccTypeId)
        {
            try
            {
                return _IUoW.Repository<AccType>().GetById(_AccTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AccType GetAccTypeBy(AccType _AccTypeBy)
        {
            try
            {
                if (_AccTypeBy == null)
                {
                    return _AccTypeBy;
                }
                return _IUoW.Repository<AccType>().GetBy(x => x.AccTypeId == _AccTypeBy.AccTypeId &&
                                                                   x.AuthStatusId != "D" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add
        public int AddAccType(AccType _AccType)
        {
            try
            {
                var _max = _IUoW.Repository<AccType>().GetMaxValue(x => x.AccTypeId) + 1;
                _AccType.AccTypeId = _max.ToString().PadLeft(3, '0');
                _AccType.AuthStatusId = "U";
                _AccType.LastAction = "ADD";
                _AccType.MakeBy = "mTaka";
                _AccType.MakeDT = System.DateTime.Now;
                var result = _IUoW.Repository<AccType>().Add(_AccType);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _AccType, "ADD", "0001", _AccType.FunctionId, 1, "AccType", "MTK_SP_ACC_TYPE", "AccTypeId", _AccType.AccTypeId, _AccType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAccType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateAccType(AccType _AccType)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AccType.AccTypeId))
                {
                    IsRecordExist = _IUoW.Repository<AccType>().IsRecordExist(x => x.AccTypeId == _AccType.AccTypeId);
                    if (IsRecordExist)
                    {
                        var _oldAccType = _IUoW.Repository<AccType>().GetBy(x => x.AccTypeId == _AccType.AccTypeId);
                        var _oldAccTypeForLog = ObjectCopier.DeepCopy(_oldAccType);

                        _oldAccType.AuthStatusId = _AccType.AuthStatusId = "U";
                        _oldAccType.LastAction = _AccType.LastAction = "EDT";
                        _oldAccType.LastUpdateDT = _AccType.LastUpdateDT = System.DateTime.Now;
                        _AccType.MakeBy = "mtaka";
                        result = _IUoW.Repository<AccType>().Update(_oldAccType);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldAccTypeForLog, _AccType, "EDT", "0001", _AccType.FunctionId, 1, "AccType", "MTK_SP_ACC_TYPE", "AccTypeId", _AccType.AccTypeId, _AccType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateAccType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteAccType(AccType _AccType)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AccType.AccTypeId))
                {
                    IsRecordExist = _IUoW.Repository<AccType>().IsRecordExist(x => x.AccTypeId == _AccType.AccTypeId);
                    if (IsRecordExist)
                    {
                        var _oldAccType = _IUoW.Repository<AccType>().GetBy(x => x.AccTypeId == _AccType.AccTypeId);
                        var _oldAccTypeForLog = ObjectCopier.DeepCopy(_oldAccType);

                        _oldAccType.AuthStatusId = _AccType.AuthStatusId = "U";
                        _oldAccType.LastAction = _AccType.LastAction = "DEL";
                        _oldAccType.LastUpdateDT = _AccType.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<AccType>().Update(_oldAccType);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldAccTypeForLog, _AccType, "DEL", "0001", _AccType.FunctionId, 1, "AccType", "MTK_SP_ACC_TYPE", "AccTypeId", _AccType.AccTypeId, _AccType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<AccType>().Delete(_AccType);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteAccType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Dropdown    
        public IEnumerable<SelectListItem> GetAccTypeForDD()
        {
            try
            {
                var List_AccType = _IUoW.Repository<AccType>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.AccTypeId, n.AccTypeNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_AccType)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AccTypeId,
                        Text = element.AccTypeNm
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
