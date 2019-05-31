using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface IChargesCategoryService
    {
        IEnumerable<SelectListItem> GetChargesCategoryForDD();
    }

    public class ChargesCategoryService: IChargesCategoryService
    {
        private IUnitOfWork _IUoW = null;
        public ChargesCategoryService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChargesCategoryService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        public IEnumerable<SelectListItem> GetChargesCategoryForDD()
        {
            try
            {
                var List_ChargesCategory = _IUoW.Repository<ChargesCategory>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.CategoryId, n.CategoryName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_ChargesCategory)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CategoryId.ToString(),
                        Text = element.CategoryName
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
