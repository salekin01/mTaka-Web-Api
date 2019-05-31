using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.BusinessEntities.CP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.SP
{
    [Serializable]
    [Table("MTK_SP_SPECIAL_OFFERS")]
    public class SpecialOffers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("OFFER_ID")]
        [Display(Name = "Offer ID")]
        public string OfferId { set; get; }

        [Column("OFFER_NAME")]
        [Display(Name = "Offer Name")]
        public string OfferName { set; get; }

        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccTypeId { set; get; }

        [Column("DEFINE_SERVICE_ID")]
        [Display(Name = "DefineService Id")]
        public string DefineServiceId { set; get; }

        [Column("RATE_TYPE_ID")]
        [Display(Name = "Rate Type Id")]
        public string RateTypeId { set; get; }

        [Column("RATE_AMOUNT")]
        [Display(Name = "Rate Amount")]
        public string RateAmount { set; get; }

        [Column("RATE_PERSENT")]
        [Display(Name = "Rate Persent")]
        public string RatePersent { set; get; }

        [Column("MIN_AMOUNT")]
        [Display(Name = "Min Amount")]
        public string MinAmount { set; get; }

        [Column("MAX_AMOUNT")]
        [Display(Name = "Max Amount")]
        public string MaxAmount { set; get; }

        [Column("GL_ACCOUNT")]
        [Display(Name = "GL Account")]
        public string glAccount { set; get; }

        [Column("MESSAGE")]
        [Display(Name = "Message")]
        public string offerMessage { set; get; }

        [Column("DISTRICT")]
        [Display(Name = "District")]
        public string DistrictId { set; get; }

        [Column("START_DATE")]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { set; get; }

        [Column("END_DATE")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { set; get; }

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

        public virtual DefineService DefineService { get; set; }
        [NotMapped]
        public string DefineServiceNm { set; get; }

        public virtual ChargeRateType ChargeRateType { get; set; }
        [NotMapped]
        public string RuleTypeName { set; get; }

        public virtual AccType AccTypes { get; set; }
        [NotMapped]
        public string AccTypeNm { set; get; }

        public virtual DistrictInfo DistrictInfos { get; set; }
        [NotMapped]
        public string DistrictNm { set; get; }

        [NotMapped]
        public string WalletAccountNo { set; get; }

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }

    }
}
