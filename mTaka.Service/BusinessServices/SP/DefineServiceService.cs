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
    public interface IDefineServiceService
    {
        IEnumerable<DefineService> GetAllDefineService();
        DefineService GetDefineServiceById(string _DefineServiceId);
        DefineService GetDefineServiceBy(DefineService _DefineService);
        string AddDefineService(DefineService _DefineService);
        int UpdateDefineService(DefineService _DefineService);
        int DeleteDefineService(DefineService _DefineService);
        IEnumerable<SelectListItem> GetDefineServiceForDD();
        IEnumerable<SelectListItem> GetDefineServiceUSBForDD();
    }

    public class DefineServiceService : IDefineServiceService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public DefineServiceService()
        {
            _IUoW = new UnitOfWork();
        }

        public DefineServiceService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<DefineService> GetAllDefineService()
        {
            try
            {
                //return _IUoW.Repository<DefineService>().GetAll();
                var _ListDefineService = _IUoW.Repository<DefineService>().Get(x => x.AuthStatusId == "A" &&
                                                                        x.LastAction != "DEL").OrderByDescending(x => x.DefineServiceId);
                return _ListDefineService;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllDefineService()", string.Empty);
                return null;
            }
        }

        public DefineService GetDefineServiceById(string _DefineServiceId)
        {
            try
            {
                return _IUoW.Repository<DefineService>().GetById(_DefineServiceId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDefineServiceById(string)", string.Empty);
                return null;
            }
        }
        public DefineService GetDefineServiceBy(DefineService _DefineService)
        {
            try
            {
                if (_DefineService == null)
                {
                    return _DefineService;
                }
                return _IUoW.Repository<DefineService>().GetBy(x => x.DefineServiceId == _DefineService.DefineServiceId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDefineServiceBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public string AddDefineService(DefineService _DefineService)
        {
            int result = 0;
            string MainResult = string.Empty;
            DefineServiceService OBJ_DefineServiceService = new DefineServiceService();
            try
            {
                var duplicateCheck = OBJ_DefineServiceService.IsDefineServiceExist(_DefineService);
                if (duplicateCheck == "NotExist")
                {
                    var _max = _IUoW.Repository<DefineService>().GetMaxValue(x => x.DefineServiceId) + 1;
                    _DefineService.DefineServiceId = _max.ToString().PadLeft(3, '0');
                    _DefineService.AuthStatusId = "U";
                    _DefineService.LastAction = "ADD";
                    _DefineService.MakeDT = System.DateTime.Now;
                    _DefineService.MakeBy = "prova";
                    result = _IUoW.Repository<DefineService>().Add(_DefineService);
                    #region Auth Log
                    if (result == 1)
                    {
                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, _DefineService, "ADD", "0001", _DefineService.FunctionId, 1, "DefineService", "MTK_SP_DEFINE_SERVICE", "DefineServiceId", _DefineService.DefineServiceId, _DefineService.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    }
                    #endregion
                    if (result == 1)
                    {
                        _IUoW.Commit();
                    }
                    MainResult = result + ":" + "Successfull";
                    return MainResult;
                }
                else
                {
                    MainResult = result + ":" + "Define service already exists..";
                    return MainResult;
                }                
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddDefineService(obj)", string.Empty);
                MainResult = result + ":" + "NotSuccessfull";
                return MainResult;
            }
        }
        #endregion

        #region Edit
        public int UpdateDefineService(DefineService _DefineService)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_DefineService.DefineServiceId))
                {
                    IsRecordExist = _IUoW.Repository<DefineService>().IsRecordExist(x => x.DefineServiceId == _DefineService.DefineServiceId);
                    if (IsRecordExist)
                    {
                        var _oldDefineService = _IUoW.Repository<DefineService>().GetBy(x => x.DefineServiceId == _DefineService.DefineServiceId);
                        var _oldDefineServiceForLog = ObjectCopier.DeepCopy(_oldDefineService);

                        _oldDefineService.AuthStatusId = _DefineService.AuthStatusId = "U";
                        _oldDefineService.LastAction = _DefineService.LastAction = "EDT";
                        _oldDefineService.LastUpdateDT = _DefineService.LastUpdateDT = System.DateTime.Now;
                        _DefineService.MakeBy = "prova";
                        result = _IUoW.Repository<DefineService>().Update(_oldDefineService);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldDefineServiceForLog, _DefineService, "EDT", "0001", _DefineService.FunctionId, 1, "DefineService", "MTK_SP_DEFINE_SERVICE", "DefineServiceId", _DefineService.DefineServiceId, _DefineService.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateDefineService(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteDefineService(DefineService _DefineService)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_DefineService.DefineServiceId))
                {
                    IsRecordExist = _IUoW.Repository<DefineService>().IsRecordExist(x => x.DefineServiceId == _DefineService.DefineServiceId);
                    if (IsRecordExist)
                    {
                        var _oldDefineService = _IUoW.Repository<DefineService>().GetBy(x => x.DefineServiceId == _DefineService.DefineServiceId);
                        var _oldDefineServiceForLog = ObjectCopier.DeepCopy(_oldDefineService);

                        _oldDefineService.AuthStatusId = _DefineService.AuthStatusId = "U";
                        _oldDefineService.LastAction = _DefineService.LastAction = "DEL";
                        _oldDefineService.LastUpdateDT = _DefineService.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<DefineService>().Update(_oldDefineService);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldDefineServiceForLog, _DefineService, "DEL", "0001", _DefineService.FunctionId, 1, "DefineService", "MTK_SP_DEFINE_SERVICE", "DefineServiceId", _DefineService.DefineServiceId, _DefineService.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteDefineService(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetDefineServiceForDD()
        {
            try
            {
                var List_Define_Service = _IUoW.Repository<DefineService>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.DefineServiceId, n.DefineServiceNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Define_Service)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.DefineServiceId,
                        Text = element.DefineServiceNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDefineServiceForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        #region For USB Dropdown
        public IEnumerable<SelectListItem> GetDefineServiceUSBForDD()
        {
            try
            {
                var List_Define_Service = _IUoW.Repository<DefineService>().GetBy(x => x.AuthStatusId == "A" && x.FunctionIdForDefineService == "0006031" &&
                                                                             x.LastAction != "DEL", n => new { n.DefineServiceId, n.DefineServiceNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Define_Service)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.DefineServiceId,
                        Text = element.DefineServiceNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDefineServiceForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        #region IsDefineServiceExist
        public string IsDefineServiceExist(DefineService _DefineService)
        {
            try
            {
                var Define_Service = _IUoW.Repository<DefineService>().GetBy(x => x.DefineServiceNm == _DefineService.DefineServiceNm && x.LastAction != "DEL");
                if (Define_Service == null)
                {
                    return "NotExist";
                }
                return "Exist";
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "IsDefineServiceExist(obj)", string.Empty);
                throw ex;
            }
        }
        #endregion
    }
}
