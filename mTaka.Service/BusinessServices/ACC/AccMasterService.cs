using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.ACC
{
    public interface IAccInfoService
    {
        IEnumerable<AccMaster> GetAllAccInfo();

        int AddAccInfo(AccMaster _AccInfo);
        AccMaster GetAccInfo(AccMaster _AccInfo);
        IEnumerable<SelectListItem> GetAccNoForDD();

        AccMaster GetAccInfoForDetails(string WalletAccNo);
        CustomerAccProfile GetCusAccInfoForDetails(string WalletAccNo);
        AccMaster GetBankAccInfoByWalletAccNo(AccMaster _AccInfo);
    }


    public class AccMasterService:IAccInfoService
    {

        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public AccMasterService()
        {
            _IUoW = new UnitOfWork();
        }
        public AccMasterService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<AccMaster> GetAllAccInfo()
        {
            try
            {
                var _ListAccInfo = _IUoW.Repository<AccMaster>().Get(x => x.AuthStatusId == "A" &&
                                                                        x.LastAction != "DEL").OrderByDescending(x => x.AccountId).ToList();

                return _ListAccInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllAccInfo()", string.Empty);
                return null;
                //throw ex;
            }
        }
        #endregion

        #region Add
        public int AddAccInfo(AccMaster _AccInfo)
        {
            try
            {
                var _max = _IUoW.Repository<AccMaster>().GetMaxValue(x => x.AccountId) + 1;
                _AccInfo.AccountId = _max.ToString().PadLeft(3, '0');
                _AccInfo.AuthStatusId = "U";
                _AccInfo.LastAction = "ADD";
                _AccInfo.MakeDT = System.DateTime.Now;
                _AccInfo.MakeBy = "prova";
                var result = _IUoW.Repository<AccMaster>().Add(_AccInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _AccInfo, "ADD", "0001", _AccInfo.FunctionId, 1, "AccInfo", "MTK_ACC_INFO", "AccountId", _AccInfo.AccountId, _AccInfo.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAccInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region GetAccInfo
        public AccMaster GetAccInfo(AccMaster _AccInfo)
        {
            AccMaster Acc_Info1 = null;
            AccMaster Acc_Info2 = null;
            AccMaster Acc_Info3 = new AccMaster();
            try
            {
                if(_AccInfo.FunctionId == "090107006")
                {
                    Acc_Info1 = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _AccInfo.FromSystemAccountNo || x.BankAccountNo == _AccInfo.FromSystemAccountNo && x.AuthStatusId == "A" && x.LastAction != "DEL");
                    Acc_Info2 = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _AccInfo.ToSystemAccountNo && x.AuthStatusId == "A" && x.LastAction != "DEL");
                }
                else
                {
                    Acc_Info1 = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _AccInfo.FromSystemAccountNo && x.AuthStatusId == "A" && x.LastAction != "DEL");
                    Acc_Info2 = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _AccInfo.ToSystemAccountNo && x.AuthStatusId == "A" && x.LastAction != "DEL");
                }
                if (Acc_Info1 != null && Acc_Info2 != null)
                {
                    Acc_Info3.FromSystemAccountNo = Acc_Info1.SystemAccountNo;
                    Acc_Info3.FromAccType = Acc_Info1.AccTypeId;
                    Acc_Info3.ToSystemAccountNo = Acc_Info2.SystemAccountNo;
                    Acc_Info3.ToAccType = Acc_Info2.AccTypeId;
                }
                return Acc_Info3;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAccNoForDD
        public IEnumerable<SelectListItem> GetAccNoForDD()
        {
            try
            {
                var List_AccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.AuthStatusId != "D" &&
                                                                             x.LastAction != "DEL", n => new { n.AccountId, n.WalletAccountNo });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_AccNo)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AccountId,
                        Text = element.WalletAccountNo
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

        #region GetAccInfoForDetails
        public AccMaster GetAccInfoForDetails(string WalletAccNo)
        {
            try
            {
                return _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == WalletAccNo && x.AuthStatusId == "A" && x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAccInfoForDetails(string)", string.Empty);
                return null;
            }
        }

        public CustomerAccProfile GetCusAccInfoForDetails(string WalletAccNo)
        {
            try
            {
                return _IUoW.Repository<CustomerAccProfile>().GetById(WalletAccNo);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCusAccInfoForDetails(string)", string.Empty);
                return null;
            }
        }
        #endregion

        #region GetBankAccInfoByWalletAccNo
        public AccMaster GetBankAccInfoByWalletAccNo(AccMaster _AccInfo)
        {
            AccMaster _Acc_Info = new AccMaster();
            CustomerAccProfile _CustomerAccProfile = new CustomerAccProfile();
            try
            {
                var _accInfo = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _AccInfo.FromSystemAccountNo && x.AuthStatusId == "A" && x.LastAction != "DEL");
                if (_accInfo != null)
                {
                    if(_accInfo.AccTypeId == "004")
                    {
                        _CustomerAccProfile = _IUoW.Repository<CustomerAccProfile>().GetBy(x => x.SystemAccountNo == _accInfo.SystemAccountNo);
                        if(_CustomerAccProfile != null)
                        {
                            _Acc_Info.FromSystemAccountNo = _CustomerAccProfile.BankAccountNo;
                        }
                    }
                }
                return _Acc_Info;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetBankAccInfoByWalletAccNo(obj)", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
