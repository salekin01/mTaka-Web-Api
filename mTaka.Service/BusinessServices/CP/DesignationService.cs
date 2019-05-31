using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.CP
{
    public interface IDesignationService
    {
        IEnumerable<SelectListItem> GetDesignationInfoForDD();
    }

    public class DesignationService:IDesignationService
    {
        private IUnitOfWork _IUoW = null;
        public DesignationService()
        {
            _IUoW = new UnitOfWork();
        }
        public DesignationService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region
        public IEnumerable<SelectListItem> GetDesignationInfoForDD()
        {
            try
            {
                var List_Designation_Info = _IUoW.Repository<Designation>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.DesignationId, n.DesignationtNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Designation_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.DesignationId,
                        Text = element.DesignationtNm
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
        #endregion
    }
}
