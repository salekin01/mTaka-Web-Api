using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface IDecimalRoundingService
    {
        IEnumerable<SelectListItem> GetDecimalRoundingForDD();
    }
    public class DecimalRoundingService : IDecimalRoundingService
    {
        private IUnitOfWork _IUoW = null;
        public DecimalRoundingService()
        {
            _IUoW = new UnitOfWork();
        }
        public DecimalRoundingService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public IEnumerable<SelectListItem> GetDecimalRoundingForDD()
        {
            try
            {
                var List_DecimalRounding = _IUoW.Repository<DecimalRounding>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_DecimalRounding)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.RoundingId,
                        Text = element.RoundingName
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
