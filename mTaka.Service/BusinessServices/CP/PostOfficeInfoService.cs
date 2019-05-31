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
    public interface IPostOfficeInfoService
    {
        IEnumerable<PostOfficeInfo> GetAllPO();
        PostOfficeInfo GetPOInfoById(string _POInfoId);
        PostOfficeInfo GetPOInfoeBy(PostOfficeInfo _POInfo);
        int AddPOInfo(PostOfficeInfo _POInfo);
        int UpdatePOInfo(PostOfficeInfo _POInfo);
        int DeletePOInfo(PostOfficeInfo _POInfo);

        IEnumerable<SelectListItem> GetPostOfficeInfoForDD();
    }
    public class PostOfficeInfoService:IPostOfficeInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public PostOfficeInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public PostOfficeInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<PostOfficeInfo> GetAllPO()
        {
            try
            {
                var abc = _IUoW.Repository<PostOfficeInfo>().Get(x => x.AuthStatusId == "A" &&
                                                               x.LastAction != "DEL").OrderByDescending(x => x.PostOfficeId);
                return abc;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllPO()", string.Empty);
                return null;
            }
        }

        public PostOfficeInfo GetPOInfoById(string _POInfoId)
        {
            try
            {
                return _IUoW.Repository<PostOfficeInfo>().GetById(_POInfoId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetPOInfoById(string)", string.Empty);
                return null;
            }
        }

        public PostOfficeInfo GetPOInfoeBy(PostOfficeInfo _POInfo)
        {
            try
            {
                if (_POInfo == null)
                {
                    return _POInfo;
                }
                return _IUoW.Repository<PostOfficeInfo>().GetBy(x => x.PostOfficeId == _POInfo.PostOfficeId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetPOInfoeBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddPOInfo(PostOfficeInfo _POInfo)
        {
            try
            {
                var _max = _IUoW.Repository<PostOfficeInfo>().GetMaxValue(x => x.PostOfficeId) + 1;
                _POInfo.PostOfficeId = _max.ToString().PadLeft(3, '0');
                _POInfo.AuthStatusId = "U";
                _POInfo.LastAction = "ADD";
                _POInfo.MakeDT = System.DateTime.Now;
                _POInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<PostOfficeInfo>().Add(_POInfo);


                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _POInfo, "ADD", "0001", "090101009", 1, "PostOfficeInfo", "MTK_CP_PO_INFO", "_POInfoId", _POInfo.PostOfficeId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddPOInfo(obj)", string.Empty);
                return 0;
                //throw ex;
            }
        }
        #endregion

        #region Edit
        public int UpdatePOInfo(PostOfficeInfo _POInfo)
        {

            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_POInfo.PostOfficeId))
                {
                    IsRecordExist = _IUoW.Repository<PostOfficeInfo>().IsRecordExist(x => x.PostOfficeId == _POInfo.PostOfficeId);
                    if (IsRecordExist)
                    {
                        var _oldPostOfficeInfo = _IUoW.Repository<PostOfficeInfo>().GetBy(x => x.PostOfficeId == _POInfo.PostOfficeId);
                        var _oldPostOfficeInfoForLog = ObjectCopier.DeepCopy(_oldPostOfficeInfo);

                        _oldPostOfficeInfo.AuthStatusId = _POInfo.AuthStatusId = "U";
                        _oldPostOfficeInfo.LastAction = _POInfo.LastAction = "EDT";
                        _oldPostOfficeInfo.LastUpdateDT = _POInfo.LastUpdateDT = System.DateTime.Now;
                        _POInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<PostOfficeInfo>().Update(_oldPostOfficeInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldPostOfficeInfoForLog, _POInfo, "EDT", "0001", "090101009", 1, "PostOfficeInfo", "MTK_CP_PO_INFO", "PostOfficeId", _POInfo.PostOfficeId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateManagerCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeletePOInfo(PostOfficeInfo _POInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_POInfo.PostOfficeId))
                {
                    IsRecordExist = _IUoW.Repository<PostOfficeInfo>().IsRecordExist(x => x.PostOfficeId == _POInfo.PostOfficeId);
                    if (IsRecordExist)
                    {
                        var _old_POInfo = _IUoW.Repository<PostOfficeInfo>().GetBy(x => x.PostOfficeId == _POInfo.PostOfficeId);
                        var _old_POInfoForLog = ObjectCopier.DeepCopy(_old_POInfo);

                        _old_POInfo.AuthStatusId = _POInfo.AuthStatusId = "U";
                        _old_POInfo.LastAction = _POInfo.LastAction = "DEL";
                        _old_POInfo.LastUpdateDT = _POInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<PostOfficeInfo>().Update(_old_POInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, null, _POInfo, "ADD", "0001", "090101009", 1, "PostOfficeInfo", "MTK_CP_PO_INFO", "_POInfoId", _POInfo.PostOfficeId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                            //_IAuthLogService.AddAuthLog(_IUoW, null, ListTest, "ADD", "0001", "010101002", 0, "TEST", "ID", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeletePOInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetPostOfficeInfoForDD()
        {
            try
            {
                var List_PostOffice_Info = _IUoW.Repository<PostOfficeInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.PostOfficeId, n.PostOfficeNM });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_PostOffice_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.PostOfficeId,
                        Text = element.PostOfficeNM
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
