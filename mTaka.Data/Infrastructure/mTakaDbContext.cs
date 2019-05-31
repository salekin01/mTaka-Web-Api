using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.OtherEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.Report;
using mTaka.Data.BusinessEntities.USB;
using mTaka.Data.BusinessEntities.GL;
using mTaka.Data.BusinessEntities.Process;
using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Performance;
using mTaka.Data.BusinessEntities.Commission;
using mTaka.Utility.Crypto;
using mTaka.Data.BusinessEntities.Upload_File;

namespace mTaka.Data.Infrastructure
{
    public class mTakaDbContext : DbContext
    {
        private string connectionStr = string.Empty;

        public mTakaDbContext()
            : base("AppDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false; 
            Database.SetInitializer<mTakaDbContext>(null);
            connectionStr = this.Database.Connection.ConnectionString;
        }

        public DbSet<CusCategory> CusCategories { get; set; }
        public DbSet<CusType> CusTypes { get; set; }
        public DbSet<AccCategory> AccCategorys { get; set; }
        public DbSet<AccType> AccTypes { get; set; }
        public DbSet<DefineService> DefineServices { get; set; }
        public DbSet<StatusWiseService> StatusWiseServices { get; set; }
        public DbSet<AccStatusSetup> AccStatusSetups { get; set; }
        public DbSet<ErrorLog> mTakaErrorLog { get; set; }
        public DbSet<ManCategory> ManagerGroups { get; set; }
        public DbSet<ManagerType> ManagerTypes { get; set; }
        public DbSet<ChannelAccProfile> ChannelAccProfiles { get; set; }
        public DbSet<CurrencyInfo> CurrencyInfos { get; set; }
        public DbSet<CountryInfo> CountryInfos { get; set; }
        public DbSet<DivisionInfo> DivisionInfos { get; set; }
        public DbSet<CityInfo> CityInfos { get; set; }
        public DbSet<DistrictInfo> DistrictInfos { get; set; }
        public DbSet<UpazilaInfo> UpazilaInfos { get; set; }
        public DbSet<AreaInfo> AreaInfos { get; set; }
        public DbSet<PSInfo> PSInfos { get; set; }
        public DbSet<AuthLevelLog> AuthLevelLogs { get; set; }
        public DbSet<AuthLog> AuthLogs { get; set; }
        public DbSet<AuthLogDtl> AuthLogDtls { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<ManagerAccProfile> ManagerProfiles { get; set; }
        public DbSet<BranchInfo> BranchInfos { get; set; }
        public DbSet<AccMaster> AccInfos { get; set; }
        public DbSet<AccLimitSetup> AccLimitSetups { get; set; }
        public DbSet<FundIn> FundIns { get; set; }
        public DbSet<FundOut> FundOuts { get; set; }
        public DbSet<UserTransaction> UserTransactions { get; set; }
        public DbSet<CashOut> CashOuts { get; set; }
        public DbSet<LedgerMaster> LedgerMasters { get; set; }
        public DbSet<LedgerMasterHist> LedgerMasterHists { get; set; }
        public DbSet<LedgerTxn> LedgerTxns { get; set; }
        public DbSet<LedgerTxnHist> LedgerTxnHists { get; set; }
        public DbSet<PostOfficeInfo> PostOfficeInfos { get; set; }
        public DbSet<UnionInfo> UnionInfos { get; set; }
        public DbSet<BankInfo> BankInfos { get; set; }
        public DbSet<CustomerAccProfile> CustomerProfiles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<ReportConfigMaster> ReportConfigMasters { get; set; }
        public DbSet<ReportConfigParam> ReportConfigParams { get; set; }
        public DbSet<DatabaseConnectionConfig> DatabaseConnectionConfigs { get; set; }
        public DbSet<UserActivityLog> UserActivityLog { get; set; }
        public DbSet<CusTypeWiseServiceList> CusTypeWiseServiceLists { get; set; }
        public DbSet<TransactionRules> AccRules { get; set; }
        public DbSet<FTAuthLevelLog> FTAuthLevelLogs { get; set; }
        public DbSet<FTAuthLog> FTAuthLogs { get; set; }
        public DbSet<FTAuthLogDtl> FTAuthLogDtls { get; set; }
        public DbSet<UsbParam> UsbParams { get; set; }
        public DbSet<CommonService> CommonServices { get; set; }
        public DbSet<UsbReceive> UsbReceives { get; set; }
        public DbSet<USBReportingField> USBReportingFields { get; set; }
        public DbSet<UsbParamConfig> UsbParamConfigs { get; set; }
        public DbSet<TransactionTemplate> TransactionTemplates { get; set; }
        public DbSet<SourceofAcc> SourceofAccs { get; set; }
        public DbSet<TypeofAcc> TypeofAccs { get; set; }
        public DbSet<AccBalanceType> AccBalanceTypes { get; set; }
        public DbSet<UsbInqHeader> UsbInqHeaders { get; set; }
        public DbSet<UsbCollection> UsbCollections { get; set; }
        public DbSet<Nationality> Nationalitys { get; set; }
        public DbSet<GLChart> GLCharts { get; set; }
        public DbSet<ApplPrefix> ApplPrefixes { get; set; }
        public DbSet<GLLevel> GLLeveles { get; set; }
        public DbSet<GLMaster> GLMasters { get; set; }
        public DbSet<EOD> EODs { get; set; }
        public DbSet<TransGL> TransGLs { get; set; }
        public DbSet<FundTransfer> FundTransfers { get; set; }
        public DbSet<ChargeRule> ChargeRules { get; set; }
        public DbSet<ChargesCategory> ChargesCategoryes { get; set; }
        public DbSet<ChargeRateMethod> ChargeRateMethodes { get; set; }
        public DbSet<ChargeRateType> ChargeRateTypes { get; set; }
        public DbSet<CalenderPeriod> CalenderPeriods { get; set; }
        public DbSet<DecimalRounding> DecimalRoundings { get; set; }
        public DbSet<ChargeRuleType> ChargeRuleTypes { get; set; }
        public DbSet<CustomerFilter> CustomerFilter { get; set; }
        public DbSet<Organogram> Organograms { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<AccTypeWiseTarget> AccTypeWiseTargets { get; set; }
        public DbSet<ChargeActType> ChargeActTypes { get; set; }
        public DbSet<ChargeDeductCust> ChargeDeductCustomers { get; set; }
        public DbSet<TransactionSetup> TransactionSetups { get; set; }
        public DbSet<MobileOperator> MobileOperators { get; set; }
        public DbSet<TopPerformer> TopPerformer { get; set; }
        public DbSet<PromoCodeConfig> PromoCodeConfigs { get; set; }
        public DbSet<ChargeApplyDateTime> ChargeApplyDateTimes { get; set; }
        public DbSet<SpecialOffers> SpecialOffers { get; set; }
        public DbSet<CommissionSetup> CommissionSetup { get; set; }
        public DbSet<CommissionSetupDTL> CommissionSetupDTL { get; set; }
        public DbSet<CryptoKeyModel> CryptoKeyModels { get; set;  }
        public DbSet<File_Upload> File_Uploads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Oracle.ManagedDataAccess.Client.OracleConnectionStringBuilder con = new Oracle.ManagedDataAccess.Client.OracleConnectionStringBuilder(connectionStr);
            string userName = con.UserID;
            modelBuilder.HasDefaultSchema(userName.ToUpper());
           
        }
    }
}
