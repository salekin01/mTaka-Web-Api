using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface ICalenderPeriodService
    {
        IEnumerable<SelectListItem> GetCalenderPeriodForDD();
    }
    public class CalenderPeriodService : ICalenderPeriodService
    {
        private IUnitOfWork _IUoW = null;
        ErrorLogService _ObjErrorLogService = null;
        public CalenderPeriodService()
        {
            _IUoW = new UnitOfWork();
        }
        public CalenderPeriodService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public IEnumerable<SelectListItem> GetCalenderPeriodForDD()
        {
            try
            {
                var List_CalenderPeriod = _IUoW.Repository<CalenderPeriod>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_CalenderPeriod)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CalenderPrdId,
                        Text = element.CalenderPrdName
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

