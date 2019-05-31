using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface IChargeRateTypeService
    {
        IEnumerable<SelectListItem> GetChargeRateTypeForDD();
    }
    public class ChargeRateTypeService : IChargeRateTypeService
    {
        private IUnitOfWork _IUoW = null;
        public ChargeRateTypeService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChargeRateTypeService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public IEnumerable<SelectListItem> GetChargeRateTypeForDD()
        {
            try
            {
                var List_ChargeRateType = _IUoW.Repository<ChargeRateType>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_ChargeRateType)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.RateTypeId,
                        Text = element.RateTypeName
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
    }
}
