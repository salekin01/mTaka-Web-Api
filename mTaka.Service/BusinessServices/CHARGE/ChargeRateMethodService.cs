using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface IChargeRateMethodService
    {
        IEnumerable<SelectListItem> GetChargeRateMethodForDD();
    }
    public class ChargeRateMethodService : IChargeRateMethodService
    {
        private IUnitOfWork _IUoW = null;
        ErrorLogService _ObjErrorLogService = null;
        public ChargeRateMethodService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChargeRateMethodService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public IEnumerable<SelectListItem> GetChargeRateMethodForDD()
        {
            try
            {
                var List_ChargeRateMethod = _IUoW.Repository<ChargeRateMethod>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_ChargeRateMethod)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.RateMethodId,
                        Text = element.RateMethodName
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
