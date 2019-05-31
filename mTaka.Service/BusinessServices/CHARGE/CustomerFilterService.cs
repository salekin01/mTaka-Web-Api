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
    public interface ICustomerFilterService
    {
        IEnumerable<SelectListItem> GetCustomerFilterForDD();
    }
    public class CustomerFilterService: ICustomerFilterService
    {
        private IUnitOfWork _IUoW = null;
        public CustomerFilterService()
        {
            _IUoW = new UnitOfWork();
        }
        public CustomerFilterService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        public IEnumerable<SelectListItem> GetCustomerFilterForDD()
        {
            try
            {
                var List_CustomerFilter = _IUoW.Repository<CustomerFilter>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_CustomerFilter)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CustomerFilterId,
                        Text = element.CustomerFilterName
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
