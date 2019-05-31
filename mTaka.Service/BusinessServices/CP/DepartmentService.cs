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
    public interface IDepartmentService
    {
        IEnumerable<SelectListItem> GetDepartmentInfoForDD();
    }
    public class DepartmentService:IDepartmentService
    {
        private IUnitOfWork _IUoW = null;
        public DepartmentService()
        {
            _IUoW = new UnitOfWork();
        }
        public DepartmentService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Dropdown
        public IEnumerable<SelectListItem> GetDepartmentInfoForDD()
        {
            try
            {
                var List_Department_Info = _IUoW.Repository<Department>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.DepartmentId, n.DepartmentNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Department_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.DepartmentId,
                        Text = element.DepartmentNm
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
