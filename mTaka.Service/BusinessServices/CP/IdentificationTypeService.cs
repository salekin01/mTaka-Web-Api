using mTaka.Data.BusinessEntities.CP;
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

namespace mTaka.Service.BusinessServices.CP
{
    public interface IIdentificationTypeService
    {
        IEnumerable<IdentificationType> GetAllIdentificationType();
        IdentificationType GetIdentificationTypeById(string _IdentificationId);
        IdentificationType GetIdentificationTypeBy(IdentificationType _IdentificationId);
        int AddIdentificationType(IdentificationType _IdentificationType);
        int UpdateIdentificationType(IdentificationType _IdentificationType);
        int DeleteIdentificationType(IdentificationType _IdentificationType);
        IEnumerable<SelectListItem> GetIdentificationTypeForDD();
    }


    public class IdentificationTypeService : IIdentificationTypeService
    {
        private IUnitOfWork _IUoW = null;
        ErrorLogService _ObjErrorLogService = null;
        private AuthLogService _IAuthLogService;

        public IdentificationTypeService()
        {
            _IUoW = new UnitOfWork();
        }
        public IdentificationTypeService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Fetch
        public IEnumerable<IdentificationType> GetAllIdentificationType()
        {
            try
            {
                return _IUoW.Repository<IdentificationType>().Get(x => x.AuthStatusId == "A" &&
                                                                x.LastAction != "DEL").OrderByDescending(x => x.IdentificationId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllIdentificationType()", string.Empty);
                return null;
            }
        }
        public IdentificationType GetIdentificationTypeById(string _IdentificationId)
        {
            try
            {
                return _IUoW.Repository<IdentificationType>().GetById(_IdentificationId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCusIdentificationTypeById(string)", string.Empty);
                return null;
            }
        }
        public IdentificationType GetIdentificationTypeBy(IdentificationType _IdentificationId)
        {
            try
            {
                return _IUoW.Repository<IdentificationType>().GetBy(x => x.IdentificationId == _IdentificationId.IdentificationId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetIdentificationTypeBy(string)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddIdentificationType(IdentificationType _IdentificationType)
        {
            try
            {
                var _max = _IUoW.Repository<IdentificationType>().GetMaxValue(x => x.IdentificationId) + 1;
                _IdentificationType.IdentificationId = _max.ToString().PadLeft(2, '0');
                _IdentificationType.AuthStatusId = "U";
                _IdentificationType.LastAction = "ADD";
                _IdentificationType.MakeDT = System.DateTime.Now;
                _IdentificationType.MakeBy = "mtaka";
                var result = _IUoW.Repository<IdentificationType>().Add(_IdentificationType);

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _IdentificationType, "ADD", "0001", "010101001", 1, "IdentificationType", "MTK_CP_IDENTIFICATION_TYPE", "IdentificationId", _IdentificationType.IdentificationId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                }
                #endregion

                if (result == 1)
                {
                    _IUoW.Commit();
                }

                _IUoW.Commit();
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddIdentificationType(obj)", string.Empty);
                return 0; ;
            }
        }
        #endregion

        #region Edit
        public int UpdateIdentificationType(IdentificationType _IdentificationType)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_IdentificationType.IdentificationId))
                {
                    IsRecordExist = _IUoW.Repository<IdentificationType>().IsRecordExist(x => x.IdentificationId == _IdentificationType.IdentificationId);
                    if (IsRecordExist)
                    {
                        var _oldIdentificationType = _IUoW.Repository<IdentificationType>().GetBy(x => x.IdentificationId == _IdentificationType.IdentificationId);
                        var _oldIdentificationTypeForLog = ObjectCopier.DeepCopy(_oldIdentificationType);

                        _oldIdentificationType.AuthStatusId = _IdentificationType.AuthStatusId = "U";
                        _oldIdentificationType.LastAction = _IdentificationType.LastAction = "EDT";
                        _oldIdentificationType.LastUpdateDT = _IdentificationType.LastUpdateDT = System.DateTime.Now;
                        _oldIdentificationType.MakeBy = "mtaka";
                        result = _IUoW.Repository<IdentificationType>().Update(_oldIdentificationType);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldIdentificationTypeForLog, _IdentificationType, "EDT", "0001", "010101001", 1, "IdentificationType", "MTK_CP_IDENTIFICATION_TYPE", "IdentificationId", _IdentificationType.IdentificationId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateIdentificationType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteIdentificationType(IdentificationType _IdentificationType)
        {
            try
            {
                int result = 0;
                if (!string.IsNullOrWhiteSpace(_IdentificationType.IdentificationId))
                {
                    var _oldIdentificationType = _IUoW.Repository<IdentificationType>().GetBy(x => x.IdentificationId == _IdentificationType.IdentificationId);
                    var _oldIdentificationTypeForLog = ObjectCopier.DeepCopy(_oldIdentificationType);

                    _oldIdentificationType.AuthStatusId = _IdentificationType.AuthStatusId = "U";
                    _oldIdentificationType.LastAction = _IdentificationType.LastAction = "DEL";
                    _oldIdentificationType.LastUpdateDT = _IdentificationType.LastUpdateDT = System.DateTime.Now;
                    result = _IUoW.Repository<IdentificationType>().Update(_oldIdentificationType);

                    #region Auth Log
                    if (result == 1)
                    {
                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        result = _IAuthLogService.AddAuthLog(_IUoW, _oldIdentificationTypeForLog, _IdentificationType, "DEL", "0001", "010101001", 1, "IdentificationType", "MTK_CP_IDENTIFICATION_TYPE", "IdentificationId", _IdentificationType.IdentificationId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteIdentificationType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region DropDown
        public IEnumerable<SelectListItem> GetIdentificationTypeForDD()
        {
            try
            {
                var List_Cus_Group = _IUoW.Repository<IdentificationType>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.IdentificationId, n.IdentificationNM });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Cus_Group)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.IdentificationId,
                        Text = element.IdentificationNM
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetIdentificationTypeForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
