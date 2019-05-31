using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.CP
{
    public interface ICommonServiceService
    {
        int AddCommonService(CommonService _CommonService);
        IEnumerable<SelectListItem> GetAllAddress();
        IEnumerable<SelectListItem> GetAllGender();
        IEnumerable<SelectListItem> GetAllNationality();
        IEnumerable<SelectListItem> GetSourceofAccForDD();
        IEnumerable<SelectListItem> GetTypeofAccForDD();
        IEnumerable<SelectListItem> GetAccBalanceTypeForDD();
        IEnumerable<SelectListItem> GetAllTransType();
        IEnumerable<SelectListItem> GetTransactionSetupForDD();
        IEnumerable<SelectListItem> GetMobileOperator();
        IEnumerable<SelectListItem> GetTokenFormatForDD();
    }
    public class CommonServiceService : ICommonServiceService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        public CommonServiceService()
        {
            _IUoW = new UnitOfWork();
        }
        
        public CommonServiceService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        public int AddCommonService(CommonService _CommonService)
        {
            try
            {
                var _max = _IUoW.Repository<CommonService>().GetMaxValue(x => x.ServiceId) + 1;
                _CommonService.ServiceId = _max.ToString().PadLeft(3, '0');
                _CommonService.AuthStatusId = "A";
                _CommonService.LastAction = "ADD";
                if (_CommonService.ServiceType == "0")
                {
                    _CommonService.ServiceType = "A";
                }else if (_CommonService.ServiceType == "1")
                {
                    _CommonService.ServiceType = "G";
                }else if (_CommonService.ServiceType == "2")
                {
                    _CommonService.ServiceType = "N";
                }
                _CommonService.MakeDT = System.DateTime.Now;
                _CommonService.MakeBy = "mtaka";
                var result = _IUoW.Repository<CommonService>().Add(_CommonService);

                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCommonService(obj)", string.Empty);
                return 0;
            }
        }

        public IEnumerable<SelectListItem> GetAllAddress()
        {
            try
            {
                var List_Address = _IUoW.Repository<Address>().GetBy(x => x.AuthStatusId == "A", n => new { n.AddressId, n.AddressNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Address)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AddressId,
                        Text = element.AddressNm
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

        public IEnumerable<SelectListItem> GetAllGender()
        {
            try
            {
                var List_Gender = _IUoW.Repository<Gender>().GetBy(x => x.AuthStatusId == "A", n => new { n.GenderId, n.GenderNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Gender)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.GenderId,
                        Text = element.GenderNm
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

        public IEnumerable<SelectListItem> GetAllNationality()
        {
            try
            {
                var List_Nationality = _IUoW.Repository<Nationality>().GetBy(x => x.AuthStatusId != "D" &&
                                                                             x.LastAction != "DEL",
                                                                             n => new { n.NationalityId, n.NationalityNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Nationality)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.NationalityId,
                        Text = element.NationalityNm
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

        #region Source of Account Dropdown
        public IEnumerable<SelectListItem> GetSourceofAccForDD()
        {
            try
            {
                var List_Source_of_Account = _IUoW.Repository<SourceofAcc>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.SourceofAccountId, n.SourceofAccountName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Source_of_Account)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.SourceofAccountId,
                        Text = element.SourceofAccountName
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetSourceofAccForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Type of Account Dropdown
        public IEnumerable<SelectListItem> GetTypeofAccForDD()
        {
            try
            {
                var List_Type_of_Account = _IUoW.Repository<TypeofAcc>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.TypeofAccountId, n.TypeofAccountName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Type_of_Account)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.TypeofAccountId,
                        Text = element.TypeofAccountName
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTypeofAccForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Account Balance Type Dropdown
        public IEnumerable<SelectListItem> GetAccBalanceTypeForDD()
        {
            try
            {
                var List_Account_Balance_Type = _IUoW.Repository<AccBalanceType>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.BalanceTypeId, n.BalanceTypeName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Account_Balance_Type)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.BalanceTypeId,
                        Text = element.BalanceTypeName
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAccBalanceTypeForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        #region TransType
        public IEnumerable<SelectListItem> GetAllTransType()
        {
            try
            {
                var List_TransType = _IUoW.Repository<TransactionType>().GetBy(x => x.AuthStatusId == "A", n => new { n.TransTypeSlId, n.TransTypeName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_TransType)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.TransTypeSlId,
                        Text = element.TransTypeName
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

        #region Type of Account Dropdown
        public IEnumerable<SelectListItem> GetTransactionSetupForDD()
        {
            try
            {
                var List_TransactionSetup = _IUoW.Repository<TransactionSetup>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.TransactionSetupId, n.TransactionSetupName});
                var selectList = new List<SelectListItem>();
                foreach (var element in List_TransactionSetup)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.TransactionSetupId,
                        Text = element.TransactionSetupName
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTransactionSetupForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Mobile Operator
        public IEnumerable<SelectListItem> GetMobileOperator()
        {
            try
            {
                var List_MobileOperator = _IUoW.Repository<MobileOperator>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.OperatorId, n.OperatorNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_MobileOperator)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.OperatorId,
                        Text = element.OperatorNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetMobileOperator()", string.Empty);
                return null;
            }
        }
        #endregion

        #region TokenFormat
        public IEnumerable<SelectListItem> GetTokenFormatForDD()
        {
            try
            {
                var List_TokenFormat = _IUoW.Repository<TokenFormat>().GetBy(x => x.AuthStatusId == "A", n => new { n.TokenFormatId, n.TokenFormatName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_TokenFormat)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.TokenFormatId,
                        Text = element.TokenFormatName
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
