using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.ACC
{
    [Serializable]
    [Table("MTK_ACC_CHANNEL_PROFILE")]
    public class ChannelAccProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ACC_PROFILE_ID")]
        [Display(Name = "Account Profile Id")]
        public string AccountProfileId { set; get; }

        [Required]
        [Column("USER_NM")]
        [Display(Name = "User Name")]
        public string UserName { set; get; }

        ////[Required]
        ////[ForeignKey("FKAccountCategoryId")]
        ////[Column("ACC_CATEGORY_ID")]
        ////[Display(Name = "Account Category Id")]
        ////public string AccountCategoryId { set; get; }
        ////public virtual ChargeRule FKAccountCategoryId { get; set; }

        ////[NotMapped]
        ////[Display(Name = "Account Category Name")]
        ////public string AccountCategoryNm { set; get; }

        [Required]
        [ForeignKey("FKAccountTypeId")]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccountTypeId { set; get; }
        public virtual AccType FKAccountTypeId { get; set; }

        [NotMapped]
        [Display(Name = "Account Type Name")]
        public string AccountTypeNm { set; get; }

        [Required]
        [Column("WALLET_ACC_NO")]
        [Display(Name = "Wallet Account No.")]
        public string WalletAccountNo { set; get; }

        //[Required]
        [Column("SYS_ACC_NO")]
        [Display(Name = "System Account No.")]
        public string SystemAccountNo { set; get; } 

        [Column("FATHER_NM")]
        [Display(Name = "Father's Name")]
        public string FatherNm { set; get; }

        [Column("MOTHER_NM")]
        [Display(Name = "Mother's Name")]
        public string MotherNm { set; get; }

        [Column("DOB")]
        [Display(Name = "Date of Birth")]
        public DateTime? DateofBirth { set; get; }

        [Column("NAT_ID")]
        [Display(Name = "Nationality Id")]
        public string NationalityId { set; get; }

        [ForeignKey("FKGender")]
        [Column("GENDER")]
        [Display(Name = "Gender")]
        public string Gender { set; get; }
        public virtual Gender FKGender { get; set; }

        [NotMapped]
        [Display(Name = "Gender Name")]
        public string GenderNm { set; get; }

        [Column("TAX_ID_NO")]
        [Display(Name = "TAX Id No")]
        public string TAXIdNo { set; get; }

        [Column("PASSPRT_NO")]
        [Display(Name = "Passport No")]
        public string PassportNo { set; get; }

        [Column("PRE_ADDRESS1")]
        [Display(Name = "Present Address 1")]
        public string PresentAddress1 { set; get; }

        [Column("PRE_ADDRESS2")]
        [Display(Name = "Present Address 2")]
        public string PresentAddress2 { set; get; }

        [ForeignKey("FKPresentCountryId")]
        [Column("PRE_COUNTRY_ID")]
        [Display(Name = "Country Id")]
        public string PresentCountryId { set; get; }
        public virtual CountryInfo FKPresentCountryId { get; set; }

        [NotMapped]
        [Display(Name = "Country Name")]
        public string PresentCountryNm { set; get; }

        [ForeignKey("FKPresentCityId")]
        [Column("PRE_CITY_ID")]
        [Display(Name = "City Id")]
        public string PresentCityId { set; get; }
        public virtual CityInfo FKPresentCityId { get; set; }

        [NotMapped]
        [Display(Name = "City Name")]
        public string PresentCityNm { set; get; }

        [ForeignKey("FKPresentDistrictId")]
        [Column("PRE_DISTRICT_ID")]
        [Display(Name = "District Id")]
        public string PresentDistrictId { set; get; }
        public virtual DistrictInfo FKPresentDistrictId { get; set; }

        [NotMapped]
        [Display(Name = "District Name")]
        public string PresentDistrictNm { set; get; }

        [ForeignKey("FKPresentPoliceStationId")]
        [Column("PRE_PS_ID")]
        [Display(Name = "Police Station Id")]
        public string PresentPoliceStationId { set; get; }
        public virtual PSInfo FKPresentPoliceStationId { get; set; }

        [NotMapped]
        [Display(Name = "Police Station Name")]
        public string PresentPoliceStationNm { set; get; }

        [ForeignKey("FKPresentAreaId")]
        [Column("PRE_AREA_ID")]
        [Display(Name = "Area Id")]
        public string PresentAreaId { set; get; }
        public virtual AreaInfo FKPresentAreaId { get; set; }

        [NotMapped]
        [Display(Name = "Area Name")]
        public string PresentAreaNm { set; get; }

        //[Column("PRE_PHONE_NO")]
        //[Display(Name = "Phone No")]
        //public string PresentPhoneNo { set; get; }

        [Column("PER_ADDRESS1")]
        [Display(Name = "Permanent Address 1")]
        public string PermanentAddress1 { set; get; }

        [Column("PER_ADDRESS2")]
        [Display(Name = "Permanent Address 2")]
        public string PermanentAddress2 { set; get; }

        [ForeignKey("FKPermanentCountryId")]
        [Column("PER_COUNTRY_ID")]
        [Display(Name = "Country Id")]
        public string PermanentCountryId { set; get; }
        public virtual CountryInfo FKPermanentCountryId { get; set; }

        [NotMapped]
        [Display(Name = "Country Name")]
        public string PermanentCountryNm { set; get; }

        [ForeignKey("FKPermanentCityId")]
        [Column("PER_CITY_ID")]
        [Display(Name = "City Id")]
        public string PermanentCityId { set; get; }
        public virtual CityInfo FKPermanentCityId { get; set; }

        [NotMapped]
        [Display(Name = "City Name")]
        public string PermanentCityNm { set; get; }

        [ForeignKey("FKPermanentDistrictId")]
        [Column("PER_DISTRICT_ID")]
        [Display(Name = "District Id")]
        public string PermanentDistrictId { set; get; }
        public virtual DistrictInfo FKPermanentDistrictId { get; set; }

        [NotMapped]
        [Display(Name = "District Name")]
        public string PermanentDistrictNm { set; get; }

        [ForeignKey("FKPermanentPoliceStationId")]
        [Column("PER_PS_ID")]
        [Display(Name = "Police Station Name")]
        public string PermanentPoliceStationId { set; get; }
        public virtual PSInfo FKPermanentPoliceStationId { get; set; }

        [NotMapped]
        [Display(Name = "Police Station Name")]
        public string PermanentPoliceStationNm { set; get; }

        [ForeignKey("FKPermanentAreaId")]
        [Column("PER_AREA_ID")]
        [Display(Name = "Area Id")]
        public string PermanentAreaId { set; get; }
        public virtual AreaInfo FKPermanentAreaId { get; set; }

        [NotMapped]
        [Display(Name = "Area Name")]
        public string PermanentAreaNm { set; get; }

        //[Column("PER_PHONE_NO")]
        //[Display(Name = "Phone No")]
        //public string PermanentPhoneNo { set; get; }

        [ForeignKey("FKBankId")]
        [Column("BANK_ID")]
        [Display(Name = "Bank Id")]
        public string BankId { set; get; }
        public virtual BankInfo FKBankId { get; set; }

        [NotMapped]
        [Display(Name = "Bank Name")]
        public string BankNm { set; get; }

        [ForeignKey("FKBranchId")]
        [Column("BRANCH_ID")]
        [Display(Name = "Branch Id")]
        public string BranchId { set; get; }
        public virtual BranchInfo FKBranchId { get; set; }

        [NotMapped]
        [Display(Name = "Branch Name")]
        public string BranchNm { set; get; }

        [Column("BANK_ACC_NO")]
        [Display(Name = "Bank Account No")]
        public string BankAccountNo { set; get; }

        [ForeignKey("FKParentAccountTypeId")]
        [Column("PRNT_ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string ParentAccountTypeId { set; get; }
        public virtual AccType FKParentAccountTypeId { get; set; }

        [NotMapped]
        [Display(Name = "Parent Account Type Name")]
        public string ParentAccountTypeNm { set; get; }

        [ForeignKey("FKParentAccountProfileId")]
        [Column("PRNT_ACC_PROFILE_ID")]
        [Display(Name = "Parent Account Profile Id")]
        public string ParentAccountProfileId { set; get; }
        public virtual ChannelAccProfile FKParentAccountProfileId { get; set; }

        [NotMapped]
        [Display(Name = "Parent Channel Account Profile Name")]
        public string ParentChannelAccProfileNm { set; get; }

        [Column("COMPANY_NM")]
        [Display(Name = "Company Name")]
        public string CompanyNm { set; get; }

        [Column("OCCUPATION")]
        [Display(Name = "Occupation")]
        public string Occupation { set; get; }

        [Column("NATIONAL_ID")]
        [Display(Name = "National Id No")]
        public string NationalIdNo { set; get; }

        [Column("VAT_REG_NO")]
        [Display(Name = "Vat Registration No")]
        public string VatRegistrationNo { set; get; }

        //[Required]
        [ForeignKey("FKAccountStatusId")]
        [Column("ACC_STATUS_ID")]
        [Display(Name = "Account Status Id")]
        public string AccountStatusId { set; get; }
        public virtual AccStatusSetup FKAccountStatusId { get; set; }

        [NotMapped]
        [Display(Name = "Channel Status Name")]
        public string AccountStatusName { set; get; }

        [Column("TRADE_LICENSE")]
        [Display(Name = "Trade License No")]
        public string TradeLicenseNo { set; get; }

        ////[ForeignKey("FKManagerTypeId")]
        ////[Column("MANAGER_TYPE_ID")]
        ////[Display(Name = "Manager Type Id")]
        ////public string ManagerTypeId { set; get; }
        ////public virtual ManagerType FKManagerTypeId { get; set; }

        ////[NotMapped]
        ////[Display(Name = "Manager Type Name")]
        ////public string ManagerTypeNm { set; get; }

        [Column("ALTERNATE_MBL_NO")]
        [Display(Name = "Alternate Mobile No")]
        public string AlternateMobileNo { set; get; }

        [Column("EMAIL")]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Column("SOURCE_OF_FUND")]
        [Display(Name = "Source of Fund")]
        public string SourceOfFund { set; get; }

        [ForeignKey("FKManagerAccountProfileId")]
        [Column("MANAGER_ACC_PROFILE_ID")]
        [Display(Name = "Manager Account Profile Id")]
        public string ManagerAccountProfileId { set; get; }
        public virtual ManagerAccProfile FKManagerAccountProfileId { get; set; }

        [NotMapped]
        [Display(Name = "Manager Profile Name")]
        public string ManagerProfileNm { set; get; }

        [Column("AUTH_STATUS_ID")]
        [Display(Name = "Auth. Status Id")]
        public string AuthStatusId { set; get; }

        [Column("LAST_ACTION")]
        [Display(Name = "Last Action")]
        public string LastAction { set; get; }

        [Column("LAST_UPDATE_DT")]
        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDT { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime MakeDT { set; get; }

        [Column("TRANS_DATE")]
        [Display(Name = "Trans Date")]
        public DateTime? TransDT { set; get; }

        [NotMapped]
        public string FunctionId { get; set; }

        //[NotMapped]
        //public string UserName { get; set; }
    }
}

