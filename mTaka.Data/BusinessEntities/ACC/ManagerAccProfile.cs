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
    [Table("MTK_ACC_MANAGER_PROFILE")]
    public class ManagerAccProfile
    {
        //Manager Information
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("MANAGER_ID")]
        [Display(Name = "Manager Id")]
        public string ManId { set; get; }

        [Column("MANAGER_GRP")]
        [Display(Name = "Manager Group")]
        public string ManGrp { set; get; }

        [ForeignKey("ManagerType")]
        [Column("MAN_TYPE_ID")]
        [Display(Name = "Manager Type")]
        public string ManType { set; get; }

        [NotMapped]
        [Display(Name = "Manager Type Name")]
        public string ManagerTypeNm { set; get; }

        [Column("MANAGER_NM")]
        [Display(Name = "Manager Name")]
        public string ManNm { set; get; }


        [Column("MFATHER_NM")]
        [Display(Name = "Father's Name")]
        public string ManFatherNm { set; get; }

        [Column("MMOTHEER_NM")]
        [Display(Name = "Mother's Name")]
        public string ManMotherNm { set; get; }

        [Column("MANAGER_BRANCH")]
        [Display(Name = "Branch")]
        public string ManBranchNm { set; get; }

        [Column("MANAGER_DEPARTMENT")]
        [Display(Name = "Department")]
        public string ManDepartment { set; get; }

        [Column("MANAGER_DESIGNATION")]
        [Display(Name = "Designation")]
        public string ManDesignation { set; get; }

        [Column("MANAGER_DOB")]
        [Display(Name = "Date of Birth")]
        public DateTime ManDOB { set; get; }

        [Column("MANAGER_DOJ")]
        [Display(Name = "Date of Join")]
        public DateTime ManDOJ { set; get; }

        [Column("MANAGER_NATIONAL_ID")]
        [Display(Name = "National Id")]
        public string ManNationalId { set; get; }

        [Column("MANAGER_GENDER")]
        [Display(Name = "Gender")]
        public string ManGender { set; get; }

        [Column("MANAGER_PASSPORT")]
        [Display(Name = "Passport No")]
        public string ManPassport { set; get; }

        [Column("OTHERS")]
        [Display(Name = "Others")]
        public string Others { set; get; }

        //Present Address
        [Column("PRESENT_ADDRESS1")]
        [Display(Name = "Address 1")]
        public string ManPresentAddress1 { set; get; }

        [Column("PRESENT_ADDRESS2")]
        [Display(Name = "Address 2")]
        public string ManPresentAddress2 { set; get; }

        [Column("PRESENT_COUNTRY")]
        [Display(Name = "Country")]
        public string ManPresentCountry { set; get; }

        [Column("PRESENT_CITY")]
        [Display(Name = "City")]
        public string ManPresentCity { set; get; }

        [Column("PRESENT_DISTRICT")]
        [Display(Name = "District")]
        public string ManPresentDistrict { set; get; }

        [Column("PRESENT_THANA")]
        [Display(Name = "Thana")]
        public string ManPresentThana { set; get; }

        [Column("PRESENT_AREA")]
        [Display(Name = "Area")]
        public string ManPresentArea { set; get; }

        [Column("PRESENT_PHONE")]
        [Display(Name = "Phone")]
        public string ManPresentPhone { set; get; }

        //Permanent Address
        [Column("PERMANENT_ADDRESS1")]
        [Display(Name = "Address 1")]
        public string ManPermanentAddress1 { set; get; }

        [Column("PERMANENT_ADDRESS2")]
        [Display(Name = "Address 2")]
        public string ManPermanentAddress2 { set; get; }

        [Column("PERMANENT_COUNTRY")]
        [Display(Name = "Country")]
        public string ManPermanentCountry { set; get; }

        [Column("PERMANENT_CITY")]
        [Display(Name = "City")]
        public string ManPermanentCity { set; get; }

        [Column("PERMANENT_DISTRICT")]
        [Display(Name = "District")]
        public string ManPermanentDistrict { set; get; }

        [Column("PERMANENT_THANA")]
        [Display(Name = "Thana")]
        public string ManPermanentThana { set; get; }

        [Column("PERMANENT_AREA")]
        [Display(Name = "Area")]
        public string ManPermanentArea { set; get; }

        [Column("PERMANENT_PHONE")]
        [Display(Name = "Phone")]
        public string ManPermanentPhone { set; get; }

        //Official Information

        [Column("MANAGER_EMPLOYEE_ID")]
        [Display(Name = "Emplouee ID")]
        public string ManEmpId { set; get; }

        [Column("MANAGER_POWER_OF_ATTORNEY")]
        [Display(Name = "Power of Attorney")]
        public string ManPowerOfAttorney { set; get; }

        [Column("MANAGER_TAX_ID_NO")]
        [Display(Name = "Tax Id No")]
        public string ManTaxIdNo { set; get; }

        [Column("MANAGER_PHONE")]
        [Display(Name = "Phone")]
        public string ManOfficePhone { set; get; }

        [Column("MANAGER_FAX")]
        [Display(Name = "Fax")]
        public string ManFax { set; get; }


        [Column("MANAGER_EMAIL")]
        [Display(Name = "Email")]
        public string ManEmail { set; get; }

        [Column("MANAGER_CELL_NO")]
        [Display(Name = "Cell No")]
        public string ManCell { set; get; }

        [Column("WALLET_ACC_NO")]
        [Display(Name = "Wallet Account No")]
        public string WalletAccountNo { set; get; }

        [NotMapped]
        public string sameAsPresent { set; get; }

        //Common
        [Column("AUTH_STATUS_ID")]
        [Display(Name = "Auth. Status Id")]
        public string AuthStatusId { set; get; }

        [Column("LAST_ACTION")]
        [Display(Name = "Last Action")]
        public string LastAction { set; get; }

        [Column("LAST_UPDATE_DT")]
        [Display(Name = "Last Update Date")]
        public DateTime LastUpdateDT { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime MakeDT { set; get; }

        [Column("MANAGER_SYS_ACC_NO")]
        [Display(Name = "Manager System Account")]
        public String ManagerSystemAccount { set; get; }

        [Column("MANAGER_ACCOUNT_TYPE")]
        [Display(Name = "Account Type")]
        public String ManagerAccType { set; get; }

        [Column("MANAGER_ACCOUNT_STATUS")]
        [Display(Name = "Account Status")]
        public String ManagerAccStatus { set; get; }

        #region Key
        public virtual ManagerType ManagerType { get; set; }
        #endregion

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
