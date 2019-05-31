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
    [Table("MTK_CP_BANK_INFO")]
    public class BankInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("BANK_ID")]
        [Display(Name = "Bank Id")]
        public string BankId { set; get; }

        [Column("BANK_NM")]
        [Display(Name = "Bank Name")]
        public string BankNM { set; get; }

        [Column("BANK_SH_NM")]
        [Display(Name = "Bank Short Name")]
        public string BankShortNM { set; get; }

        [Column("BANK_REPORT_NM")]
        [Display(Name = "Bank Report Name")]
        public string BankReportNM { set; get; }

        [Column("CB_ID")]
        [Display(Name = "CB ID")]
        public string CbId { set; get; }

        [Column("ADDRESS")]
        [Display(Name = "Address")]
        public string Address { set; get; }

        [Column("COUNTRY_ID")]
        [Display(Name = "Country Id")]
        public string CountryId { set; get; }
        //
        [Column("DIVISION_ID")]
        [Display(Name = "Division Id")]
        public string DivisionId { set; get; }

        [Column("CITY_ID")]
        [Display(Name = "City Id")]
        public string CityId { set; get; }

        [Column("DISTRICT_ID")]
        [Display(Name = "District Id")]
        public string DistrictId { set; get; }

        [Column("UPAZILA_ID")]
        [Display(Name = "Upazila Id")]
        public string UpazilaId { set; get; }

        [Column("UNION_ID")]
        [Display(Name = "Union Id")]
        public string UnionId { set; get; }

        [Column("PS_ID")]
        [Display(Name = "PS Id")]
        public string PSId { set; get; }

        [Column("PO_ID")]
        [Display(Name = "PO Id")]
        public string POId { set; get; }

        [Column("AREA_ID")]
        [Display(Name = "Area Id")]
        public string AreaId { set; get; }

        [Column("PHONE")]
        [Display(Name = "Phone")]
        public string Phone { set; get; }

        [Column("FAX")]
        [Display(Name = "Fax")]
        public string Fax { set; get; }

        [Column("SWIFT")]
        [Display(Name = "Swift")]
        public string Swift { set; get; }

        [Column("EMAIL")]
        [Display(Name = "Email")]
        public string Email { set; get; }

        //

        [Column("WEB")]
        [Display(Name = "Web")]
        public string Web { set; get; }

        [Column("CONTACT_PERSON")]
        [Display(Name = "Contact Person")]
        public string ContactPerson { set; get; }

        [Column("BANK_TYPE_ID")]
        [Display(Name = "Bank Type Id")]
        public string BankTypeId { set; get; }

        [Column("HOME_BANK_APP_FLAG")]
        [Display(Name = "Home Bank App Flag")]
        public string HomeBankAppFlag { set; get; }

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
    }
}
