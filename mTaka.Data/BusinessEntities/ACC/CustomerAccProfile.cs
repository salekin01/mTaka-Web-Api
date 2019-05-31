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
    [Table("MTK_ACC_CUSTOMER_ACC_PROFILE")]
    public class CustomerAccProfile
    {
        //Customer Information

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ACC_PROFILE_ID")]
        [Display(Name = "Account Profile Id")]
        public string AccountProfileId { set; get; }

        [Column("USER_NM")]
        [Display(Name = "User Name")]
        public string UserName { set; get; }

        [Column("FATHER_NM")]
        [Display(Name = "Father's Name")]
        public string FatherName { set; get; }

        [Column("MOTHEER_NM")]
        [Display(Name = "Mother's Name")]
        public string MotherName { set; get; }

        [Column("DOB")]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { set; get; }

        [Column("NAT_ID")]
        [Display(Name = "Nationality")]
        public string NationalityId { set; get; }

        [Column("GENDER")]
        [Display(Name = "Gender")]
        public string GenderId { set; get; }

        [Column("WALLET_ACC_NO")]
        [Display(Name = "Wallet Account No.")]
        public string WalletAccountNo { set; get; }

        [Column("SYS_ACC_NO")]
        [Display(Name = "System Account No.")]
        public string SystemAccountNo { set; get; }

        [Column("IDENTI_TYPE")]
        [Display(Name = "Identification Type")]
        public string IdentificationId { set; get; }

        [Column("IDENTIFICATION_NO")]
        [Display(Name = "Identification No")]
        public string IdentificationNo { set; get; }

        //Present Address
        [Column("PRE_ADDRESS1")]
        [Display(Name = "Address 1")]
        public string PresentAddress1 { set; get; }

        [Column("PRE_ADDRESS2")]
        [Display(Name = "Address 2")]
        public string PresentAddress2 { set; get; }

        [Column("PRE_COUNTRY")]
        [Display(Name = "Country")]
        //public string PresentCountry { set; get; }
        public string CountryId { get; set; }

        [Column("PRE_CITY")]
        [Display(Name = "City")]
        public string PresentCity { set; get; }

        [Column("PRE_DISTRICT")]
        [Display(Name = "District")]
        public string PresentDistrict { set; get; }

        [Column("PRE_THANA")]
        [Display(Name = "Thana")]
        public string PresentThana { set; get; }

        [Column("PRE_AREA")]
        [Display(Name = "Area")]
        public string PresentArea { set; get; }

        //Permanent Address
        [Column("PER_ADDRESS1")]
        [Display(Name = "Address 1")]
        public string PermanentAddress1 { set; get; }

        [Column("PER_ADDRESS2")]
        [Display(Name = "Address 2")]
        public string PermanentAddress2 { set; get; }

        [Column("PER_COUNTRY")]
        [Display(Name = "Country")]
        public string PermanentCountry { set; get; }

        [Column("PER_CITY")]
        [Display(Name = "City")]
        public string PermanentCity { set; get; }

        [Column("PER_DISTRICT")]
        [Display(Name = "District")]
        public string PermanentDistrict { set; get; }

        [Column("PER_THANA")]
        [Display(Name = "Thana")]
        public string PermanentThana { set; get; }

        [Column("PER_AREA")]
        [Display(Name = "Area")]
        public string PermanentArea { set; get; }

        //[Column("BRANCH")]
        //[Display(Name = "Branch")]
        //public string Branch { set; get; }

        [Column("BANK_ACC_NO")]
        [Display(Name = "Bank Account No")]
        public string BankAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "Bank Account Name")]
        public string BankAccountName { set; get; }

        [Column("PRNT_ACC_TYPE_ID")]
        [Display(Name = "Parent Account Type Id")]
        public string ParentAccountTypeId { set; get; }

        [Column("PRNT_ACC_PROFILE_ID")]
        [Display(Name = "Parent Account profile Id")]
        public string ParentAccountProfileId { set; get; }

        //Others Information

        [Column("OCCUPATION")]
        [Display(Name = "Occupation")]
        public string Occupation { set; get; }

        [Column("ALTERNATE_MBL_NO")]
        [Display(Name = "Alternate Mobile No")]
        public string AlternativeMblNo { set; get; }

        [Column("TRANS_PURPOSE")]
        [Display(Name = "Purpose of Transaction")]
        public string TransPurpose { set; get; }

        [Column("ACC_STATUS_ID")]
        [Display(Name = "Account Status Id")]
        public string AccountStatusId { set; get; }

        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type")]
        public string AccTypeId { set; get; }

        [NotMapped]
        public string sameAsPeranent { set; get; }

        //Introducer’s Information
        [Column("INTRODUCER_ACC_TYPE_ID")]
        [Display(Name = "Introducer Account Type Id")]
        public string IntroducerAccountTypeId { set; get; }

        [Column("INTRODUCER_SYS_ACC_NO")]
        [Display(Name = "Introducer System Account No")]
        public string IntroducerSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "Introducer Name")]
        public string IntroducerName { set; get; }

        [Column("EMAIL")]
        [Display(Name = "Email ")]
        public string Email { set; get; }

        [Column("SOURCE_OF_FUND")]
        [Display(Name = "Source of fund")]
        public string SourceOfFund { set; get; }

        //Common
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
        public DateTime? MakeDT { set; get; }

        //[NotMapped]
        //[Display(Name = "Account Id of Account Info")]
        //public string AccIdofAccInfo { set; get; }

        public virtual AccType AccType { get; set; }
        public virtual Gender Genders { get; set; }
        public virtual IdentificationType IdentificationTypes { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual CountryInfo CountryInfo { get; set; }

        [NotMapped]
        public string AccTypeNm { set; get; }
        [NotMapped]
        public string GenderNm { set; get; }
        [NotMapped]
        public string IdentificationNM { set; get; }
        [NotMapped]
        public string NationalityNm { set; get; }
        [NotMapped]
        public string CountryNm { set; get; }

        [NotMapped]
        public string FunctionId { get; set; }

        //[NotMapped]
        //public string UserName { get; set; }
    }
}

