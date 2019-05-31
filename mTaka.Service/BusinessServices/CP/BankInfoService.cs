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
    public interface IBankInfoService
    {
        IEnumerable<BankInfo> GetAllBankInfo();
        BankInfo GetBankInfoById(string _BankId);
        BankInfo GetBankInfoBy(BankInfo _BankInfo);
        int AddBankInfo(BankInfo _BankInfo);
        int UpdateBankInfo(BankInfo _BankInfo);
        int DeleteBankInfo(BankInfo _BankInfo);
        IEnumerable<SelectListItem> GetBankInfoForDD();
    }
    public class BankInfoService:IBankInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public BankInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public BankInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<BankInfo> GetAllBankInfo()
        {
            try
            {
                var abc = _IUoW.Repository<BankInfo>().Get(x => x.AuthStatusId == "A" &&
                                                               x.LastAction != "DEL").OrderByDescending(x => x.BankId);
                return abc;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllBankInfo()", string.Empty);
                return null;
            }
        }

        public BankInfo GetBankInfoById(string _BankId)
        {
            try
            {
                return _IUoW.Repository<BankInfo>().GetById(_BankId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetBankInfoById(string)", string.Empty);
                return null;
            }
        }

        public BankInfo GetBankInfoBy(BankInfo _BankInfo)
        {
            try
            {
                if (_BankInfo == null)
                {
                    return _BankInfo;
                }
                return _IUoW.Repository<BankInfo>().GetBy(x => x.BankId == _BankInfo.BankId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetBankInfofoeBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddBankInfo(BankInfo _BankInfo)
        {
            try
            {
                var _max = _IUoW.Repository<BankInfo>().GetMaxValue(x => x.BankId) + 1;
                _BankInfo.BankId = _max.ToString().PadLeft(3, '0');
                _BankInfo.AuthStatusId = "U";
                _BankInfo.LastAction = "ADD";
                _BankInfo.BankTypeId = "005";
                _BankInfo.MakeDT = System.DateTime.Now;
                _BankInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<BankInfo>().Add(_BankInfo);


                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _BankInfo, "ADD", "0001", "090101011", 1, "BankInfo", "MTK_CP_BANK_INFO", "BankId", _BankInfo.BankId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddBankInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateBankInfo(BankInfo _BankInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_BankInfo.BankId))
                {
                    IsRecordExist = _IUoW.Repository<BankInfo>().IsRecordExist(x => x.BankId == _BankInfo.BankId);
                    if (IsRecordExist)
                    {
                        var _oldBankInfo = _IUoW.Repository<BankInfo>().GetBy(x => x.BankId == _BankInfo.BankId);
                        var _oldBankInfoForLog = ObjectCopier.DeepCopy(_oldBankInfo);

                        _oldBankInfo.AuthStatusId = _BankInfo.AuthStatusId = "U";
                        _oldBankInfo.LastAction = _BankInfo.LastAction = "EDT";
                        _oldBankInfo.LastUpdateDT = _BankInfo.LastUpdateDT = System.DateTime.Now;
                        _BankInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<BankInfo>().Update(_oldBankInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldBankInfoForLog, _BankInfo, "EDT", "0001", "090101011", 1, "BankInfo", "MTK_CP_BANK_INFO", "BankId", _BankInfo.BankId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateBankInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete

        public int DeleteBankInfo(BankInfo _BankInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_BankInfo.BankId))
                {
                    IsRecordExist = _IUoW.Repository<BankInfo>().IsRecordExist(x => x.BankId == _BankInfo.BankId);
                    if (IsRecordExist)
                    {
                        var _oldBankInfo = _IUoW.Repository<BankInfo>().GetBy(x => x.BankId == _BankInfo.BankId);
                        var _oldBankInfoForLog = ObjectCopier.DeepCopy(_oldBankInfo);

                        _oldBankInfo.AuthStatusId = _BankInfo.AuthStatusId = "U";
                        _oldBankInfo.LastAction = _BankInfo.LastAction = "DEL";
                        _oldBankInfo.LastUpdateDT = _BankInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<BankInfo>().Update(_oldBankInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldBankInfoForLog, _BankInfo, "DEL", "0001", "090101011", 1, "BankInfo", "MTK_CP_BANK_INFO", "BankId", _BankInfo.BankId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<BankInfo>().Delete(_BankInfo);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteBankInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Dropdown
        public IEnumerable<SelectListItem> GetBankInfoForDD()
        {
            try
            {
                var List_BankInfo = _IUoW.Repository<BankInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.BankId, n.BankNM });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_BankInfo)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.BankId,
                        Text = element.BankNM
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
