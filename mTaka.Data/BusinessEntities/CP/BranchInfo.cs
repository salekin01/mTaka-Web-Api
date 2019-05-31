using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.CP
{
    [Serializable]
    [Table("MTK_CP_BRANCH_INFO")]
    public class BranchInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("BRANCH_ID")]
        [Display(Name = "Branch Id")]
        public string BranchId { set; get; }

        [Required]
        [Column("BRANCH_NM")]
        [Display(Name = "Branch Name")]
        public string BranchNm { set; get; }

        [Required]
        [Column("BRANCH_SH_NM")]
        [Display(Name = "Branch Short Name")]
        public string BranchShortNm { set; get; }

        [ForeignKey("CurrencyInfo")]
        [Column("CURRENCY_ID")]
        [Display(Name = "Currency Id")]
        public string CurrencyId { set; get; }
        public virtual CurrencyInfo CurrencyInfo { get; set; }

        [NotMapped]
        [Display(Name = "Currency Name")]
        public string CurrencyNm { set; get; }

        [Column("BRANCH_CLOSED_FLAG")]
        [Display(Name = "Branch Closed Flag")]
        public string BranchClosedFlag { set; get; }

        [Column("BRANCH_GRADE")]
        [Display(Name = "Branch Grade")]
        public string BranchGrade { set; get; }

        [Column("BRANCH_CLOSED_DT")]
        [Display(Name = "Branch Closed Date")]
        public DateTime? BranchClosedDate { set; get; }

        [Column("BRANCH_ID_CB_CLEARING")]
        [Display(Name = "Branch Id CB Clearing")]
        public string BranchIdCBClearing { set; get; }

        [Column("BRANCH_ID_CB_CL")]
        [Display(Name = "Branch Id CB CL")]
        public string BranchIdCBCL { set; get; }

        [Column("BRANCH_ID_CB_SBS")]
        [Display(Name = "Branch Id CB SBS")]
        public string BranchIdCBSBS { set; get; }

        [Column("BRANCH_ID_CB_CIB")]
        [Display(Name = "Branch Id CB CIB")]
        public string BranchIdCBCIB { set; get; }

        [Column("BRANCH_ID_CB_AD_FX")]
        [Display(Name = "Branch Id CB AD FX")]
        public string BranchIdCBADFX { set; get; }

        [Column("BRANCH_ID_CB_CTR")]
        [Display(Name = "Branch Id CB CTR")]
        public string BranchIdCBCTR { set; get; }

        [Column("CONTROLLING_BR_CSH_FLAG")]
        [Display(Name = "Controlling BR CSH Flag")]
        public string ControllingBRCSHFlag { set; get; }

        [Column("CONTROLLING_BR_CLG_FLAG")]
        [Display(Name = "Controlling BR CLG Flag")]
        public string ControllingBRCLGFlag { set; get; }

        [Column("RURAL_BRANCH_FLAG")]
        [Display(Name = "Rural Branch Flag")]
        public string RuralBranchFlag { set; get; }

        [Column("URBAN_BRANCH_FLAG")]
        [Display(Name = "Urban Branch Flag")]
        public string UrbanBranchFlag { set; get; }

        [Column("INSURANCE_VAULT_CASH_FLAG")]
        [Display(Name = "Insurance Vault Cash Flag")]
        public string InsuranceVaultCashFlag { set; get; }

        [Column("INSURANCE_TRANSIT_CASH_FLAG")]
        [Display(Name = "Insurance Transit Cash Flag")]
        public string InsuranceTransitCashFlag { set; get; }

        [Column("ADDRESS1")]
        [Display(Name = "Address 1")]
        public string Address1 { set; get; }

        [Column("ADDRESS2")]
        [Display(Name = "Address 2")]
        public string Address2 { set; get; }

        [ForeignKey("CityInfo")]
        [Column("CITY_ID")]
        [Display(Name = "City Id")]
        public string CityId { set; get; }
        public virtual CityInfo CityInfo { get; set; }

        [NotMapped]
        [Display(Name = "City Name")]
        public string CityNm { set; get; }

        [ForeignKey("DistrictInfo")]
        [Column("DISTRICT_ID")]
        [Display(Name = "District Id")]
        public string DistrictId { set; get; }
        public virtual DistrictInfo DistrictInfo { get; set; }

        [NotMapped]
        [Display(Name = "District Name")]
        public string DistrictNm { set; get; }

        [ForeignKey("DivisionInfo")]
        [Column("DIVISION_ID")]
        [Display(Name = "Division Id")]
        public string DivisionId { set; get; }
        public virtual DivisionInfo DivisionInfo { get; set; }

        [NotMapped]
        [Display(Name = "Division Name")]
        public string DivisionNm { set; get; }

        [ForeignKey("CountryInfo")]
        [Column("COUNTRY_ID")]
        [Display(Name = "Country Id")]
        public string CountryId { set; get; }
        public virtual CountryInfo CountryInfo { get; set; }

        [NotMapped]
        [Display(Name = "Country Name")]
        public string CountryNm { set; get; }

        [ForeignKey("PSInfo")]
        [Column("PS_ID")]
        [Display(Name = "Police Station Id")]
        public string PoliceStationId { set; get; }
        public virtual PSInfo PSInfo { get; set; }

        [NotMapped]
        [Display(Name = "Police Station Name")]
        public string PoliceStationNm { set; get; }

        [Column("PHONE")]
        [Display(Name = "Phone")]
        public string Phone { set; get; }

        [Column("FAX")]
        [Display(Name = "FAX")]
        public string FAX { set; get; }

        [Column("TELEX")]
        [Display(Name = "TELEX")]
        public string TELEX { set; get; }

        [Column("SWIFT")]
        [Display(Name = "SWIFT")]
        public string SWIFT { set; get; }

        [Column("EMAIL")]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Column("ZIP_CODE")]
        [Display(Name = "Zip Code")]
        public Nullable<int> ZipCode { set; get; }

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

        [Column("TRANS_DATE")]
        [Display(Name = "Trans Date")]
        public DateTime? TransDT { set; get; }
    }
}

