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
    public interface IManagerTypeService
    {
        IEnumerable<ManagerType> GetAllManagerType();
        ManagerType GetManagerTypeById(string _ManTypeId);
        ManagerType GetManagerTypeBy(ManagerType _ManagerTypeBy);
        int AddManagerType(ManagerType _ManagerType);
        int UpdateManagerType(ManagerType _ManagerType);
        int DeleteManagerType(ManagerType _ManagerType);
        IEnumerable<SelectListItem> GetManagerTypeForDD();
    }
    public class ManagerTypeService : IManagerTypeService
    {
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        private IUnitOfWork _IUoW = null;

        public ManagerTypeService()
        {
            _IUoW = new UnitOfWork();
        }

        public ManagerTypeService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region index
        public IEnumerable<ManagerType> GetAllManagerType()
        {
            try
            {
                var AllManagerType = _IUoW.mTakaDbQuery().GetAllManType_LQ().OrderByDescending(x => x.ManTypeId);
                return AllManagerType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllManagerType()", string.Empty);
                return null;
            }
        }

        public ManagerType GetManagerTypeById(string _ManTypeId)
        {
            try
            {
                return _IUoW.Repository<ManagerType>().GetById(_ManTypeId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ManagerType GetManagerTypeBy(ManagerType _ManagerTypeBy)
        {
            try
            {
                if (_ManagerTypeBy == null)
                {
                    return _ManagerTypeBy;
                }
                else
                {
                    return _IUoW.Repository<ManagerType>().GetBy(x => x.ManTypeId == _ManagerTypeBy.ManTypeId &&
                                                                    x.AuthStatusId != "D" &&
                                                                    x.LastAction != "DEL");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region add
        public int AddManagerType(ManagerType _ManagerType)
        {
            try
            {
                var _max = _IUoW.Repository<ManagerType>().GetMaxValue(x => x.ManTypeId) + 1;
                _ManagerType.ManTypeId = _max.ToString().PadLeft(3, '0');
                _ManagerType.AuthStatusId = "U";
                _ManagerType.LastAction = "ADD";
                _ManagerType.MakeDT = System.DateTime.Now;
                _ManagerType.MakeBy = "mtaka";
                var result = _IUoW.Repository<ManagerType>().Add(_ManagerType);


                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _ManagerType, "ADD", "0001", _ManagerType.FunctionId, 1, "ManagerType", "MTK_SP_MANAGER_TYPE", "ManTypeId", _ManagerType.ManTypeId, _ManagerType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    //_IAuthLogService.AddAuthLog(_IUoW, null, ListTest, "ADD", "0001", "010101002", 0, "TEST", "ID", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddManagerType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region edit
        public int UpdateManagerType(ManagerType _ManagerType)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ManagerType.ManTypeId))
                {
                    IsRecordExist = _IUoW.Repository<ManagerType>().IsRecordExist(x => x.ManTypeId == _ManagerType.ManTypeId);
                    if (IsRecordExist)
                    {
                        var _oldManagerType = _IUoW.Repository<ManagerType>().GetBy(x => x.ManTypeId == _ManagerType.ManTypeId);
                        var _oldManagerTypeForLog = ObjectCopier.DeepCopy(_oldManagerType);

                        _oldManagerType.AuthStatusId = _ManagerType.AuthStatusId = "U";
                        _oldManagerType.LastAction = _ManagerType.LastAction = "EDT";
                        _oldManagerType.LastUpdateDT = _ManagerType.LastUpdateDT = System.DateTime.Now;
                        _ManagerType.MakeBy = "mtaka";
                        result = _IUoW.Repository<ManagerType>().Update(_oldManagerType);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldManagerTypeForLog, _ManagerType, "EDT", "0001", _ManagerType.FunctionId, 1, "ManagerType", "MTK_SP_MANAGER_TYPE", "ManTypeId", _ManagerType.ManTypeId, _ManagerType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                            //_IAuthLogService.AddAuthLog(_IUoW, ListTest1, ListTest, "EDT", "0001", "010101002", 0, "TEST", "Id", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateManagerType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region delete
        public int DeleteManagerType(ManagerType _ManagerType)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ManagerType.ManTypeId))
                {
                    IsRecordExist = _IUoW.Repository<ManagerType>().IsRecordExist(x => x.ManTypeId == _ManagerType.ManTypeId);
                    if (IsRecordExist)
                    {
                        var _oldManagerType = _IUoW.Repository<ManagerType>().GetBy(x => x.ManTypeId == _ManagerType.ManTypeId);
                        var _oldManagerTypeForLog = ObjectCopier.DeepCopy(_oldManagerType);

                        _oldManagerType.AuthStatusId = _ManagerType.AuthStatusId = "U";
                        _oldManagerType.LastAction = _ManagerType.LastAction = "DEL";
                        _oldManagerType.LastUpdateDT = _ManagerType.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<ManagerType>().Update(_oldManagerType);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldManagerTypeForLog, _ManagerType, "DEL", "0001", _ManagerType.FunctionId, 1, "ManagerType", "MTK_SP_MANAGER_TYPE", "ManTypeId", _ManagerType.ManTypeId, _ManagerType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<ManagerType>().Delete(_ManagerType);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteManagerType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Dropdown
        public IEnumerable<SelectListItem> GetManagerTypeForDD()
        {
            try
            {
                var List_Manager_Type = _IUoW.Repository<ManagerType>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.ManTypeId, n.ManTypeNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Manager_Type)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.ManTypeId,
                        Text = element.ManTypeNm
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
