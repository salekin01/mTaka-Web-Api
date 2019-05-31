using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.CP
{
    public interface IUnionInfoService
    {
        List<UnionInfo> GetAllUnionInfo();
        UnionInfo GetUnionInfoById(string _UnionId);
        UnionInfo GetUnionInfo(UnionInfo _UnionInfo);
        int AddUnionInfo(UnionInfo _UnionInfo);
        int UpdateUnionInfo(UnionInfo _UnionInfo);
        int DeleteUnionInfo(UnionInfo _UnionInfo);
        IEnumerable<SelectListItem> GetUnionInfoForDD();
    }
    public class UnionInfoService : IUnionInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public UnionInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public UnionInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        #region Index
        public List<UnionInfo> GetAllUnionInfo()
        {

            try
            {

                var aaa = _IUoW.Repository<UnionInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                 x.LastAction != "DEL", n => new { n.UnionId, n.UnionNm, n.UnionShortNm, n.MakeDT, n.UpazilaId });
                var bbb = _IUoW.Repository<UpazilaInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.UpazilaId, n.UpazilaNm });
                List<UnionInfo> OBJ_LIST_UnionInfo = aaa.Join(bbb, p => p.UpazilaId, pc => pc.UpazilaId, (p, pc) => new UnionInfo
                {
                    UnionId = p.UnionId,
                    UnionNm = p.UnionNm,
                    UnionShortNm = p.UnionShortNm,
                    UpazilaNm = pc.UpazilaNm,
                    UpazilaId=p.UpazilaId,
                    MakeDT = p.MakeDT

                }).ToList();
                return OBJ_LIST_UnionInfo;
                
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllUnionInfo()", string.Empty);
                return null;
            }
        }

        public UnionInfo GetUnionInfoById(string _UnionId)
        {
            try
            {
                return _IUoW.Repository<UnionInfo>().GetById(_UnionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UnionInfo GetUnionInfo(UnionInfo _UnionInfo)
        {
            try
            {
                if (_UnionInfo == null)
                {
                    return _UnionInfo;
                }
                return _IUoW.Repository<UnionInfo>().GetBy(x => x.UnionId == _UnionInfo.UnionId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add
        public int AddUnionInfo(UnionInfo _UnionInfo)
        {
            try
            {
                var _max = _IUoW.Repository<UnionInfo>().GetMaxValue(x => x.UnionId) + 1;
                _UnionInfo.UnionId = _max.ToString().PadLeft(3, '0');
                _UnionInfo.AuthStatusId = "U";
                _UnionInfo.LastAction = "ADD";
                _UnionInfo.MakeDT = System.DateTime.Now;
                _UnionInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<UnionInfo>().Add(_UnionInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _UnionInfo, "ADD", "0001", "090101010", 1, "UnionInfo", "MTK_CP_UNION_INFO", "UnionID", _UnionInfo.UnionId, "mtaka", 0, out _outMaxSlAuthLogDtl);
                }
                #endregion
                _IUoW.Commit();
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddUnionInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateUnionInfo(UnionInfo _UnionInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_UnionInfo.UnionId))
                {
                    IsRecordExist = _IUoW.Repository<UnionInfo>().IsRecordExist(x => x.UnionId == _UnionInfo.UnionId);
                    if (IsRecordExist)
                    {
                        _UnionInfo.AuthStatusId = "U";
                        _UnionInfo.LastAction = "EDT";
                        _UnionInfo.LastUpdateDT = System.DateTime.Now;
                        _UnionInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<UnionInfo>().Update(_UnionInfo);
                        _IUoW.Commit();
                        return result;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateUnionInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteUnionInfo(UnionInfo _UnionInfo)
        {
            try
            {
                int result = 0;
                if (!string.IsNullOrWhiteSpace(_UnionInfo.UnionId))
                {
                    result = _IUoW.Repository<UnionInfo>().Delete(_UnionInfo);
                    _IUoW.Commit();
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteUnionInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetUnionInfoForDD()
        {
            try
            {
                var List_Union_Info = _IUoW.Repository<UnionInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.UnionId, n.UnionNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Union_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.UnionId,
                        Text = element.UnionNm
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
