using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.Charge.ViewModel;
using mTaka.Data.BusinessEntities.GL;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.BusinessEntities.USB;
using mTaka.Data.Common;
using mTaka.Data.Performance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Infrastructure
{
    public class mTakaDbQuery
    {
        private mTakaDbContext _dbContext = null;
        ErrorLogService _ObjErrorLogService = null;
        public mTakaDbQuery(mTakaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region CusType
        public IEnumerable<CusType> GetAllCusType_LQ()
        {
            try
            {
                var _ListCusType = _dbContext.CusTypes.Include(t => t.CusCategory)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new CusType
                                   {
                                       CusTypeId = item.CusTypeId,
                                       CusTypeNm = item.CusTypeNm,
                                       CusCategoryId = item.CusCategoryId,
                                       AuthStatusId = item.AuthStatusId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       CusCategoryNm = item.CusCategory.CusCategoryNm
                                   }).ToList();

                #region Test Purpose

                //List<CusType> _ListCusType = ((List<CusType>)(from a in _dbContext.CusTypes
                //                    where a.AuthStatusId == "A" &&
                //                         a.LastAction != "DEL"
                //                    select new
                //                    {
                //                        a.CusTypeId,
                //                        a.CusTypeNm,
                //                        a.CusCategoryId,
                //                        a.AuthStatusId,
                //                        a.LastAction,
                //                        a.LastUpdateDT,
                //                        a.MakeBy,
                //                        a.MakeDT,
                //                        //a.CusCategory.CusCategoryNm
                //                    })).ToList()  ;

                //var _ListCusType = (from a in _dbContext.Set<CusType>()
                //                    where a.AuthStatusId == "A" &&
                //                         a.LastAction != "DEL"
                //                    select new CusType
                //                    {
                //                        CusTypeId = a.CusTypeId,
                //                        CusTypeNm = a.CusTypeNm,
                //                        CusCategoryId = a.CusCategoryId,
                //                        AuthStatusId = a.AuthStatusId,
                //                        LastAction = a.LastAction,
                //                        LastUpdateDT = a.LastUpdateDT,
                //                        MakeBy = a.MakeBy,
                //                        MakeDT = a.MakeDT,
                //                        //CusCategoryNm = a.CusCategory.CusCategoryNm
                //                    }).AsNoTracking().ToList();

                //var _ListCusType = from a in _dbContext.Set<CusType>()
                //                    where a.AuthStatusId == "A" &&
                //                         a.LastAction != "DEL"
                //                    select a;
                //var abc = _ListCusType.ToList();

                #endregion

                return _ListCusType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCusType_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region AccType
        public IEnumerable<AccType> GetAllAccType_LQ()
        {
            try
            {
                var _ListAccType = _dbContext.AccTypes.Include(t => t.AccCategory)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new AccType
                                   {
                                       AccTypeId = item.AccTypeId,
                                       AccTypeNm = item.AccTypeNm,
                                       AccTypeParentAcc = item.AccTypeParentAcc,
                                       //AccTypeParentAccNm = item.AccTypeNm,
                                       AccTypeShortNm = item.AccTypeShortNm,
                                       AccCategoryId = item.AccCategoryId,
                                       AuthStatusId = item.AuthStatusId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       AccCategoryNm = item.AccCategory.AccCategoryNm
                                   }).ToList();

                return _ListAccType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCusType_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Provider
        public IEnumerable<USBReportingField> GetAllProviderName_LQ()
        {
            try
            {
                var _ListProviderName = _dbContext.USBReportingFields.Include(t => t.DefineService)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new USBReportingField
                                   {
                                       ReportingId = item.ReportingId,
                                       DefineServiceId = item.DefineServiceId,
                                       FieldAccNo = item.FieldAccNo,
                                       FieldName = item.FieldName,
                                       FieldType = item.FieldType,
                                       FieldLength = item.FieldLength,
                                       AuthStatusId = item.AuthStatusId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       ProviderName = item.DefineService.DefineServiceNm
                                   }).ToList();

                return _ListProviderName;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllProviderName_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region ProviderNameForIndex
        public IEnumerable<USBReportingField> GetAllProviderNameForIndex_LQ(string DefineServiceId)
        {
            try
            {
                var _ListProviderName = _dbContext.USBReportingFields.Include(t => t.DefineService)
                                   .Where(a => a.AuthStatusId == "A" && a.DefineServiceId == DefineServiceId &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new USBReportingField
                                   {
                                       ReportingId = item.ReportingId,
                                       DefineServiceId = item.DefineServiceId,
                                       FieldAccNo = item.FieldAccNo,
                                       FieldName = item.FieldName,
                                       FieldNameForAPI = item.FieldNameForAPI,
                                       InputType = item.InputType,
                                       ReportingType = item.ReportingType,
                                       FieldType = item.FieldType,
                                       FieldLength = item.FieldLength,
                                       UserAssist = item.UserAssist,
                                       UserAssistlength = item.UserAssistlength,
                                       FieldPrefix = item.FieldPrefix,
                                       FieldSuffix = item.FieldSuffix,
                                       AuthStatusId = item.AuthStatusId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       ProviderName = item.DefineService.DefineServiceNm
                                   }).ToList();

                return _ListProviderName;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllProviderName_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Channel
        public IEnumerable<ChannelAccProfile> GetAllChannelAccProfile_LQ()
        {
            try
            {
                var _ListChannelAccProfiles = _dbContext.ChannelAccProfiles
                    ////.Include(t => t.FKAccountCategoryId)
                    .Include(t => t.FKAccountTypeId)
                    .Include(t => t.FKPresentCountryId)
                    //.Include(t => t.FKPresentCityId)
                    //.Include(t => t.FKPresentDistrictId)
                    //.Include(t => t.FKPresentPoliceStationId)
                    //.Include(t => t.FKPresentAreaId)
                    .Include(t => t.FKPermanentCountryId)
                    //.Include(t => t.FKPermanentCityId)
                    //.Include(t => t.FKPermanentDistrictId)
                    //.Include(t => t.FKPermanentPoliceStationId)
                    //.Include(t => t.FKPermanentAreaId)
                    //.Include(t => t.FKBankId)
                    //.Include(t => t.FKBranchId)
                    //.Include(t => t.FKParentAccountTypeId)
                    //.Include(t => t.FKParentAccountProfileId)
                    .Include(t => t.FKAccountStatusId)
                    ////.Include(t => t.FKManagerTypeId)
                    //.Include(t => t.FKManagerAccountProfileId)                 
                    .Where(x => x.AuthStatusId == "A" && x.LastAction != "DEL").ToList()
                    .Select(item => new ChannelAccProfile
                    {
                        AccountProfileId = item.AccountProfileId,
                        UserName = item.UserName,
                        WalletAccountNo = item.WalletAccountNo,
                        ////AccountCategoryId = item.AccountCategoryId,
                        ////AccountCategoryNm = item.FKAccountCategoryId.AccCategoryNm,
                        AccountTypeId = item.AccountTypeId,
                        AccountTypeNm = item.FKAccountTypeId.AccTypeNm,
                        FatherNm = item.FatherNm,
                        MotherNm = item.MotherNm,
                        DateofBirth = item.DateofBirth,
                        NationalityId = item.NationalityId,
                        Gender = item.Gender,
                        TAXIdNo = item.TAXIdNo,
                        PassportNo = item.PassportNo,
                        PresentAddress1 = item.PresentAddress1,
                        PresentAddress2 = item.PresentAddress2,
                        PresentCountryId = item.PresentCountryId,
                        PresentCountryNm = item.FKPresentCountryId.CountryNm,
                        //PresentCityId = item.PresentCityId,
                        //PresentCityNm = item.FKPresentCityId.CityNm,
                        //PresentDistrictId = item.PresentDistrictId,
                        //PresentDistrictNm = item.FKPresentDistrictId.DistrictNm,
                        //PresentPoliceStationId = item.PresentPoliceStationId,
                        //PresentPoliceStationNm = item.FKPresentPoliceStationId.PoliceStationNm,
                        //PresentAreaId = item.PresentAreaId,
                        //PresentAreaNm = item.FKPresentAreaId.AreaNm,
                        //PresentPhoneNo = item.PresentPhoneNo,
                        PermanentAddress1 = item.PermanentAddress1,
                        PermanentAddress2 = item.PermanentAddress2,
                        PermanentCountryId = item.PermanentCountryId,
                        //PermanentCountryNm = item.FKPermanentCountryId.CountryNm,
                        //PermanentCityId = item.PermanentCityId,
                        //PermanentCityNm = item.FKPermanentCityId.CityNm,
                        //PermanentDistrictId = item.PermanentDistrictId,
                        //PermanentDistrictNm = item.FKPermanentDistrictId.DistrictNm,
                        //PermanentPoliceStationId = item.PermanentPoliceStationId,
                        //PermanentPoliceStationNm = item.FKPermanentPoliceStationId.PoliceStationNm,
                        //PermanentAreaId = item.PermanentAreaId,
                        //PermanentAreaNm = item.FKPermanentAreaId.AreaNm,
                        //PermanentPhoneNo = item.PermanentPhoneNo,
                        //BankId = item.BankId,
                        //BankNm = item.FKBankId.BankNM,
                        //BranchId = item.BranchId,
                        //BranchNm = item.FKBranchId.BranchNm,
                        //BankAccountNo = item.BankAccountNo,
                        //ParentAccountTypeId = item.ParentAccountTypeId,
                        //ParentAccountTypeNm = item.FKParentAccountTypeId.AccTypeNm,
                        //ParentAccountProfileId = item.ParentAccountProfileId,
                        //ParentChannelAccProfileNm = item.FKParentAccountProfileId.UserName,
                        CompanyNm = item.CompanyNm,
                        Occupation = item.Occupation,
                        NationalIdNo = item.NationalIdNo,
                        VatRegistrationNo = item.VatRegistrationNo,
                        AccountStatusId = item.AccountStatusId,
                        AccountStatusName = item.FKAccountStatusId.AccountStatusName,
                        TradeLicenseNo = item.TradeLicenseNo,
                        ////ManagerTypeId = item.ManagerTypeId,
                        ////ManagerTypeNm = item.FKManagerTypeId.ManTypeNm,
                        //ManagerAccountProfileId = item.ManagerAccountProfileId,
                        //ManagerProfileNm = item.FKManagerAccountProfileId.ManNm,
                        AuthStatusId = item.AuthStatusId,
                        LastAction = item.LastAction,
                        LastUpdateDT = item.LastUpdateDT,
                        MakeBy = item.MakeBy,
                        MakeDT = item.MakeDT,
                        TransDT = item.TransDT
                    }).ToList();
                return _ListChannelAccProfiles;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllChannelAccProfiles_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region ManagerType
        public IEnumerable<ManagerType> GetAllManType_LQ()
        {
            try
            {
                var _ListManType = _dbContext.ManagerTypes.Include(t => t.ManCategory)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new ManagerType
                                   {
                                       ManTypeId = item.ManTypeId,
                                       ManTypeNm = item.ManTypeNm,
                                       ManTypeParentAcc = item.ManTypeParentAcc,
                                       ManTypeShortNm = item.ManTypeShortNm,
                                       ManagerCategoryId = item.ManagerCategoryId,
                                       AuthStatusId = item.AuthStatusId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       ManagerCategoryNm = item.ManCategory.ManagerCategoryNm
                                   }).ToList();

                return _ListManType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllManType_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region AccLimit
        public IEnumerable<AccLimitSetup> AccLimit_LQ()
        {
            try
            {
                var _AccLimit = _dbContext.AccLimitSetups.Include(t => t.AccountCategory).Include(t => t.AccountType).Include(t => t.DefineService)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new AccLimitSetup
                                   {
                                       AccLimitId = item.AccLimitId,
                                       AccCategoryId = item.AccCategoryId,
                                       AccTypeId = item.AccTypeId,
                                       DefineServiceId = item.DefineServiceId,
                                       NoOfOccurrence = item.NoOfOccurrence,
                                       AmountOfOccurrence = item.AmountOfOccurrence,
                                       AmountOftotalOccurrences = item.AmountOftotalOccurrences,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       AccCategoryNm = item.AccountCategory.AccCategoryNm,
                                       AccountTypeNm = item.AccountType.AccTypeNm,
                                       ServiceNm = item.DefineService.DefineServiceNm

                                   }).OrderByDescending(x => x.AccLimitId).ToList();

                return _AccLimit;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AccLimit_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region CusTypeWiseService
        public IEnumerable<CusTypeWiseServiceList> CusTypeWise_LQ()
        {
            try
            {
                var _CusTypeWise = _dbContext.CusTypeWiseServiceLists.Include(t => t.AccountCategory).Include(t => t.AccountType).Include(t => t.DefineService)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new CusTypeWiseServiceList
                                   {
                                       CusTypeWiseServiceId = item.CusTypeWiseServiceId,
                                       AccCategoryId = item.AccCategoryId,
                                       AccTypeId = item.AccTypeId,
                                       DefineServiceId = item.DefineServiceId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       AccCategoryNm = item.AccountCategory.AccCategoryNm,
                                       AccountTypeNm = item.AccountType.AccTypeNm,
                                       ServiceNm = item.DefineService.DefineServiceNm
                                   }).OrderByDescending(x => x.CusTypeWiseServiceId).ToList();

                return _CusTypeWise;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "CusTypeWise_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region TotalCashOut
        public string GetTotalCashOut_LQ()
        {
            try
            {
                var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var _TotalCashOut = _dbContext.CashOuts.Where(t => t.TransDT == date).Sum(t => t.Amount).ToString();

                return _TotalCashOut;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTotalCashOut_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Total CashIn
        public string GetTotalCashIn_LQ()
        {
            try
            {
                var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var _TotalCashIn = _dbContext.UserTransactions.Where(t => t.TransDT == date).Sum(t => t.Amount).ToString();

                return _TotalCashIn;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTotalCashIn_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Account Type Check
        public string getAccountType_LQ(string AccountTypeId)
        {
            try
            {

                var _AccountType = _dbContext.AccTypes.Where(t => t.AccTypeId == AccountTypeId).Select(t => t.AccTypeNm).SingleOrDefault();

                return _AccountType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "getAccountType_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region TotaUSBAmount
        public string GetTotalUSBAmount_LQ()
        {
            try
            {
                var _TotalCashOut = _dbContext.UsbCollections.Sum(t => t.totalPaidAmount).ToString();

                return _TotalCashOut;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTotalUSBAmount_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region MaxGLAccSL
        public long MaxGLAccSL(string prefix)
        {
            try
            {
                //return _dbContext.GLCharts.Where(a => a.GLPrefix == prefix).OrderByDescending(a => int.Parse(a.GLAccSl)).FirstOrDefault().GLAccSl;
                Int64 _max = _dbContext.GLCharts
                      .Where(x => x.GLPrefix == prefix)
                      .Select(i => i.GLAccSl).Cast<Int64?>().Max() ?? 0;
                return (_max == 0 ?  Convert.ToInt64((prefix + "00000001")) : _max + 1);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "MaxGLAccSL()", string.Empty);
                return 0;
            }
        }
        public bool IsGLAccNoExist(string accNo)
        {
            try
            {
                bool a = !_dbContext.GLCharts.ToList().Exists(p => p.GLAccNo.Equals(accNo, StringComparison.CurrentCultureIgnoreCase));
                return a;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "IsGLAccNoExist()", string.Empty);
                return true;
            }
        }
        #endregion

        #region Max Report Config Param Id
        public int MaxSl(string FunctionId)
        {
            try
            {
                return _dbContext.ReportConfigParams
                    .Where(r =>r.FunctionId == FunctionId).OrderByDescending(r=>r.SlNo).Take(1).Select(r=>r.SlNo).Single();


            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "MaxSl()", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Transection Rules
        public IEnumerable<TransactionRules> GetAllTransactionRules_LQ()
        {
            try
            {
                var _ListAccType = _dbContext.AccRules.Include(t => t.DefineService)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new TransactionRules
                                   {
                                       TransactionRuleId = item.TransactionRuleId,
                                       AccountType1 = item.AccountType1,
                                       AccountType2 = item.AccountType2,
                                       //AccTypeParentAccNm = item.AccTypeNm,
                                       commissionAllowed = item.commissionAllowed,
                                       TranactionAllowed = item.TranactionAllowed,
                                       DefineServiceId = item.DefineServiceId,
                                       AuthStatusId = item.AuthStatusId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       DefineServiceNm = item.DefineService.DefineServiceNm
                                   }).ToList();

                if (_ListAccType != null)
                {
                    foreach (var item in _ListAccType)
                    {
                        item.AccountType1Nm = _dbContext.AccTypes.Where(x => x.AccTypeId == item.AccountType1).Select(x => x.AccTypeNm).SingleOrDefault();
                        item.AccountType2Nm = _dbContext.AccTypes.Where(x => x.AccTypeId == item.AccountType2).Select(x => x.AccTypeNm).SingleOrDefault();
                    }
                }

                return _ListAccType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCusType_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region AccTypeWiseTarget
        public IEnumerable<AccTypeWiseTarget> AccTypeWiseTarget_LQ()
        {
            try
            {
                var _CusTypeWise = _dbContext.AccTypeWiseTargets.Include(t => t.AccountCategory).
                                                                Include(t => t.AccountType).
                                                                Include(t => t.DefineService).
                                                                Include(t => t.CalenderPeriod).
                                                                Include(t => t.TransactionType)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new AccTypeWiseTarget
                                   {
                                       TargetSlNo = item.TargetSlNo,
                                       AccCategoryId = item.AccCategoryId,
                                       AccTypeId = item.AccTypeId,
                                       DefineServiceId = item.DefineServiceId,
                                       CalenderPrdId = item.CalenderPrdId,
                                       TransTypeSlId = item.TransTypeSlId,
                                       Amount = item.Amount,
                                       District = item.District,
                                       Area = item.Area,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       AccCategoryNm = item.AccountCategory.AccCategoryNm,
                                       AccountTypeNm = item.AccountType.AccTypeNm,
                                       ServiceNm = item.DefineService.DefineServiceNm,
                                       CalenderPrdName = item.CalenderPeriod.CalenderPrdName,
                                       TransTypeName = item.TransactionType.TransTypeName
                                   }).OrderByDescending(x => x.TargetSlNo).ToList();

                return _CusTypeWise;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "CusTypeWise_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Charge Rule
        public IEnumerable<ChargeRuleViewModel> ChargeRules()
        {
            try
            {
                var _ChargeRuleView = _dbContext.ChargeRules.Join(_dbContext.ChargesCategoryes, cr => cr.ChargeCtgLogId, cc => cc.CategoryId, (cr, cc) => new { rules = cr, categories = cc })
                    .Join(_dbContext.ChargeRuleTypes, crc => crc.rules.ChargeRuleTypeId, ct => ct.RuleTypeId, (crc, ct) => new { rulesCategoris = crc, rulesTypes = ct })
                    .Join(_dbContext.ChargeRateMethodes, crct => crct.rulesCategoris.rules.RateMethodId, rm => rm.RateMethodId, (crct, rm) => new { rulesCategorisTypes = crct, rateMethods = rm })
                    .Join(_dbContext.GLCharts, crctm => crctm.rulesCategorisTypes.rulesCategoris.rules.GLAccSl, gl => gl.GLAccSl, (crctm, gl) => new { crctm, gl })
                    .Where(x => x.crctm.rulesCategorisTypes.rulesCategoris.rules.AuthStatusId == "A" &&
                             x.crctm.rulesCategorisTypes.rulesCategoris.rules.LastAction != "DEL").OrderByDescending(x => x.crctm.rulesCategorisTypes.rulesCategoris.rules.ChargeRuleId)
                    .Select(m=>new ChargeRuleViewModel
                    {
                        ChargeRuleName= m.crctm.rulesCategorisTypes.rulesCategoris.rules.ChargeRuleName,
                        RuleCategory=m.crctm.rulesCategorisTypes.rulesCategoris.categories.CategoryName,
                        RuleType=m.crctm.rulesCategorisTypes.rulesTypes.RuleTypeName,
                        RateMethod=m.crctm.rateMethods.RateMethodName,
                        GLAccNumber=m.gl.GLAccName
                    }).ToList();

                return _ChargeRuleView;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AccLimit_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region TopPerformerInfo_LQ
        public string TopPerformerInfo_LQ()
        {
            try
            {
                //var query = from item in _dbContext.LedgerTxns
                //            group item by item.AccountTypeId into g
                //            orderby g.Sum(x => x.PaymentAmount) descending
                //            select g;
                //var topTwo = query.Take(5).ToString();
                //return topTwo;
                var result = _dbContext.LedgerTxns.Select(t => t.MakeBy).Take(2).ToString();
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "TopPerformerInfo_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region ActualAmount
        public IEnumerable<decimal> ActualAmount_LQ(AccTypeWiseTarget _AccTypeWiseTarget)
        {
            try
            {
                List<decimal> sum = new List<decimal>();
                //var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                if (_AccTypeWiseTarget.AccTypeId == "004")
                {
                    var sysAccList = _dbContext.CustomerProfiles.Where(x => x.PermanentDistrict == _AccTypeWiseTarget.District &&
                                                                        x.PermanentArea == _AccTypeWiseTarget.Area && 
                                                                        x.AccTypeId == _AccTypeWiseTarget.AccTypeId)
                                                                       .Select(s => s.SystemAccountNo).ToList();

                    //if (_AccTypeWiseTarget.DefineServiceId == "003")
                    //{
                        if (_AccTypeWiseTarget.CalenderPrdId == "D")
                        {
                            foreach (var element in sysAccList)
                            {
                            sum.Add(_dbContext.LedgerTxns.Where(x => x.SystemAccountNo == element &&
                                                                         x.TransectionDate == DbFunctions.TruncateTime(DateTime.Now) &&
                                                                         x.DefineServiceId==_AccTypeWiseTarget.DefineServiceId).
                                                                         Select(s => s.AccBalance).FirstOrDefault());
                            }
                        }
                        if (_AccTypeWiseTarget.CalenderPrdId == "M")
                        {
                            if (_AccTypeWiseTarget.FormDate != null && _AccTypeWiseTarget.ToDate != null)
                            {
                                //var FormDate = _AccTypeWiseTarget.FormDate.Value.Date;
                                //var Todate = _AccTypeWiseTarget.ToDate.Value.Date;

                                foreach (var element in sysAccList)
                                {

                                    sum.Add(_dbContext.LedgerTxns.Where(x => x.SystemAccountNo == element &&
                                                                             x.TransectionDate >= DbFunctions.TruncateTime(_AccTypeWiseTarget.FormDate) &&
                                                                             x.TransectionDate <= DbFunctions.TruncateTime(_AccTypeWiseTarget.ToDate) &&
                                                                             x.DefineServiceId == _AccTypeWiseTarget.DefineServiceId).
                                                                             Select(s => s.AccBalance).FirstOrDefault());
                                                                            //Sum(s =>s.AccBalance + s.AccBalance));
                            }   
                            }
                        }
                    }
                    //total = sum.Sum(x => Convert.ToInt32(x));


                //}
                return sum;
            }
            catch(Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "ActualAmount_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region TopPerformer
        public IEnumerable<dynamic> TopPerformer_LQ(LedgerTxn _ledgerTxn)
        {
            try
            {   
                //var FromDate = _ledgerTxn.FromDate.Value.Date;
                //var Todate = _ledgerTxn.ToDate.Value.Date;

                var _TopPerformerInfo =_dbContext.LedgerTxns.Where(x => x.TransectionDate >= DbFunctions.TruncateTime(_ledgerTxn.FromDate) &&
                                                                     x.TransectionDate <= DbFunctions.TruncateTime(_ledgerTxn.ToDate) &&
                                                                     x.AccountTypeId == _ledgerTxn.AccountTypeId).
                                                                     GroupBy(x=>x.SystemAccountNo).
                                                                     Select(g => new 
                                                                     {
                                                                        AccNo =g.Key,
                                                                        //AccCount = g.Count(),
                                                                        Amount =g.Sum(a=>a.Amount)
                                                                     }).
                                                                     OrderByDescending(am=>am.Amount).
                                                                     Take(5).ToList();

                //var unique_items = new HashSet<string>(_TopPerformerInfo);
                //foreach (var element in unique_items)
                //{
                //    sum.Add(_dbContext.LedgerTxns.Where(x => x.FromSystemAccountNo == element).
                //        Select(s => s.PaymentAmount).Sum());
                //}

                return _TopPerformerInfo;
            }
            catch (Exception ex)
            {

                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "TopPerformer_LQ()", string.Empty);
                return null;
            }
        }

        public IEnumerable<dynamic> TopPerformerByNo_LQ(LedgerTxn _ledgerTxn)
        {
            try
            {  
                //var FromDate = _ledgerTxn.FromDate.Value.Date;
                //var Todate = _ledgerTxn.ToDate.Value.Date;

                var _TopPerformerInfo = _dbContext.LedgerTxns.Where(x => x.TransectionDate >= DbFunctions.TruncateTime(_ledgerTxn.FromDate) &&
                                                                      x.TransectionDate <= DbFunctions.TruncateTime(_ledgerTxn.ToDate) &&
                                                                      x.AccountTypeId == _ledgerTxn.AccountTypeId).
                                                                     GroupBy(x => x.SystemAccountNo).
                                                                     Select(g => new
                                                                     {

                                                                         AccNo = g.Key,
                                                                         AccCount=g.Count(),
                                                                         //Amount = g.Sum(a => a.Amount)
                                                                     }).
                                                                     OrderByDescending(am => am.AccCount).
                                                                     Take(5).ToList();


                return _TopPerformerInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "TopPerformerByNo_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region LowestPerformer
        public IEnumerable<dynamic> LowestPerformer_LQ(LedgerTxn _ledgerTxn)
        {
            try
            {   
                //var FromDate = _ledgerTxn.FromDate.Value.Date;
                //var Todate = _ledgerTxn.ToDate.Value.Date;

                var _LowestPerformerInfo = _dbContext.LedgerTxns.Where(x => x.TransectionDate >= DbFunctions.TruncateTime(_ledgerTxn.FromDate) &&
                                                                      x.TransectionDate <= DbFunctions.TruncateTime(_ledgerTxn.ToDate) &&
                                                                      x.AccountTypeId == _ledgerTxn.AccountTypeId).
                                                                     GroupBy(x => x.SystemAccountNo).
                                                                     Select(g => new
                                                                     {
                                                                         AccNo = g.Key,
                                                                         //AccCount = g.Count(),
                                                                         Amount = g.Sum(a => a.Amount)
                                                                     }).
                                                                     OrderBy(am => am.Amount).
                                                                     Take(5).ToList();
                return _LowestPerformerInfo;
            }
            catch (Exception ex)
            {

                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "LowestPerformer_LQ()", string.Empty);
                return null;
            }
        }

        public IEnumerable<dynamic> LowestPerformerByNo_LQ(LedgerTxn _ledgerTxn)
        {
            try
            {
                var FromDate = _ledgerTxn.FromDate.Value.Date;
                var Todate = _ledgerTxn.ToDate.Value.Date;
                var _LowestPerformerInfo = _dbContext.LedgerTxns.Where(x => x.TransectionDate >= DbFunctions.TruncateTime(_ledgerTxn.FromDate) &&
                                                                      x.TransectionDate <= DbFunctions.TruncateTime(_ledgerTxn.ToDate) &&
                                                                      x.AccountTypeId == _ledgerTxn.AccountTypeId).
                                                                     GroupBy(x => x.SystemAccountNo).
                                                                     Select(g => new
                                                                     {
                                                                         AccNo = g.Key,
                                                                         AccCount = g.Count()
                                                                         //Amount = g.Sum(a => a.PaymentAmount)
                                                                     }).
                                                                     OrderBy(am => am.AccCount).
                                                                     Take(5).ToList();
                return _LowestPerformerInfo;
            }
            catch (Exception ex)
            {

                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "LowestPerformerByNo_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region PromoCodeConfig
        public IEnumerable<PromoCodeConfig> GetAllPromoCodeConfig_LQ()
        {
            try
            {
                var _ListPromoCodeConfig = _dbContext.PromoCodeConfigs.Include(t => t.TokenFormat).Where(a => a.AuthStatusId == "A" && a.LastAction != "DEL").ToList()
                    .Select(item => new PromoCodeConfig
                    {
                        ConfigurationId = item.ConfigurationId,
                        IntroducerControlFlag = item.IntroducerControlFlag,
                        EmailFlag = item.EmailFlag,
                        SMSFlag = item.SMSFlag,
                        PromoCodeLength = item.PromoCodeLength,
                        TokenFormatId = item.TokenFormatId,
                        TokenFormatName = item.TokenFormat.TokenFormatName,
                        TotalNoOfUseForIntroducer = item.TotalNoOfUseForIntroducer,
                        TotalNoOfUse = item.TotalNoOfUse,
                        AuthStatusId = item.AuthStatusId,
                        LastAction = item.LastAction,
                        LastUpdateDT = item.LastUpdateDT,
                        MakeBy = item.MakeBy,
                        MakeDT = item.MakeDT
                    }).ToList();
                return _ListPromoCodeConfig;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllPromoCodeConfig_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region IndCustomerInfo
        public IEnumerable<CustomerAccProfile> IndCustomerInfo_LQ(CustomerAccProfile _CustomerProfile)
        {
            try
            {
                var _ListCusType = _dbContext.CustomerProfiles.Include(t => t.AccType).
                                    Include(g=>g.Genders).Include(i=>i.IdentificationTypes).
                                    Include(i=>i.Nationality).Include(c=>c.CountryInfo)
                                   .Where(a => a.AuthStatusId == "A" &&
                                          a.WalletAccountNo== _CustomerProfile.WalletAccountNo &&
                                          a.LastAction != "DEL").ToList()
                                   .Select(item => new CustomerAccProfile
                                   {
                                       AccountProfileId = item.AccountProfileId,
                                       UserName = item.UserName,
                                       FatherName = item.FatherName,
                                       MotherName = item.MotherName,
                                       DOB = item.DOB,
                                       Nationality = item.Nationality,
                                       GenderId = item.GenderId,
                                       WalletAccountNo = item.WalletAccountNo,
                                       SystemAccountNo = item.SystemAccountNo,
                                       IdentificationId = item.IdentificationId,
                                       IdentificationNo = item.IdentificationNo,
                                       PresentAddress1 = item.PresentAddress1,
                                       PresentAddress2 = item.PresentAddress2,
                                       CountryId = item.CountryId,
                                       PresentCity = item.PresentCity,
                                       PresentDistrict = item.PresentDistrict,

                                       PresentThana = item.PresentThana,
                                       PresentArea = item.PresentArea,
                                       PermanentAddress1 = item.PermanentAddress1,
                                       PermanentAddress2 = item.PermanentAddress2,
                                       PermanentCountry = item.PermanentCountry,
                                       PermanentCity = item.PermanentCity,
                                       PermanentDistrict = item.PermanentDistrict,
                                       PermanentThana = item.PermanentThana,
                                       PermanentArea = item.PermanentArea,
                                       BankAccountNo = item.BankAccountNo,
                                       BankAccountName = item.BankAccountName,
                                       ParentAccountTypeId = item.ParentAccountTypeId,
                                       ParentAccountProfileId = item.ParentAccountProfileId,
                                       Occupation = item.Occupation,

                                       AlternativeMblNo = item.AlternativeMblNo,
                                       TransPurpose = item.TransPurpose,
                                       AccountStatusId = item.AccountStatusId,
                                       AccTypeId = item.AccTypeId,
                                       IntroducerAccountTypeId = item.IntroducerAccountTypeId,
                                       IntroducerSystemAccountNo = item.IntroducerSystemAccountNo,
                                       Email = item.Email,
                                       SourceOfFund = item.SourceOfFund,
                                       AuthStatusId = item.AuthStatusId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,

                                       GenderNm = item.Genders.GenderNm,
                                       AccTypeNm = item.AccType.AccTypeNm,
                                       IdentificationNM = item.IdentificationTypes.IdentificationNM,
                                       NationalityNm = item.Nationality.NationalityNm,
                                       CountryNm=item.CountryInfo.CountryNm
                                   }).ToList();

                return _ListCusType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCusType_LQ()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Special Offer
        public IEnumerable<SpecialOffers> GetAllSpecialOffer_LQ()
        {
            try
            {
                var _ListSpecialOffers = _dbContext.SpecialOffers.Include(t => t.DefineService)
                                                           .Include(t => t.ChargeRateType)
                                                           .Include(t=>t.AccTypes)
                                                           .Include(t=>t.DistrictInfos)
                                   .Where(a => a.AuthStatusId == "A" &&
                                               //a.DistrictId != null &&
                                               a.LastAction != "DEL").ToList()
                                   .Select(item => new SpecialOffers()
                                   {
                                       OfferId = item.OfferId,
                                       OfferName = item.OfferName,
                                       AccTypeId = item.AccTypeId,
                                       DefineServiceId = item.DefineServiceId,
                                       RateTypeId = item.RateTypeId,
                                       RateAmount = item.RateAmount,
                                       RatePersent = item.RatePersent,
                                       MinAmount = item.MinAmount,
                                       MaxAmount = item.MaxAmount,
                                       StartDate = item.StartDate,
                                       EndDate = item.EndDate,
                                       offerMessage = item.offerMessage,
                                       DistrictId=item.DistrictId,
                                       glAccount = item.glAccount,
                                       AuthStatusId = item.AuthStatusId,
                                       LastAction = item.LastAction,
                                       LastUpdateDT = item.LastUpdateDT,
                                       MakeBy = item.MakeBy,
                                       MakeDT = item.MakeDT,
                                       DefineServiceNm = item.DefineService.DefineServiceNm,
                                       RuleTypeName = item.ChargeRateType.RateTypeName,
                                       AccTypeNm=item.AccTypes.AccTypeNm,
                                       DistrictNm = item.DistrictInfos.DistrictNm
                                   }).ToList();

                return _ListSpecialOffers;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllSpecialOffer_LQ()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
