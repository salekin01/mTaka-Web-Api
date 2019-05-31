using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface IChargeRuleTypeService
    {
        IEnumerable<SelectListItem> GetChargeRuleTypeForDD();
    }
    public class ChargeRuleTypeService : IChargeRuleTypeService
    {
        private IUnitOfWork _IUoW = null;
        public ChargeRuleTypeService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChargeRuleTypeService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public IEnumerable<SelectListItem> GetChargeRuleTypeForDD()
        {
            try
            {
                var List_ChargeRuleType = _IUoW.Repository<ChargeRuleType>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_ChargeRuleType)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.RuleTypeId,
                        Text = element.RuleTypeName
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
