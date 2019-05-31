using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface IChargeActTypeService
    {
        IEnumerable<SelectListItem> GetChargeActTypeForDD();
    }
    public class ChargeActTypeService: IChargeActTypeService
    {
        private IUnitOfWork _IUoW = null;
        ErrorLogService _ObjErrorLogService = null;
        public ChargeActTypeService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChargeActTypeService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public IEnumerable<SelectListItem> GetChargeActTypeForDD()
        {
            try
            {
                var List_CalenderPeriod = _IUoW.Repository<ChargeActType>().GetAll();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_CalenderPeriod)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CrgActTypeId,
                        Text = element.CrgActTypeName
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
