using mTaka.Data.BusinessEntities.Process;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.BusinessServices.Process
{
    public interface IEODService
    {
        IEnumerable<EOD> GetEOD();
        int AddEOD(EOD _EOD);
    }
    public class EODService:IEODService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        EOD _EOD = null;

        public EODService()
        {
            _IUoW = new UnitOfWork();
        }
        public EODService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<EOD> GetEOD()
        {
            try
            {
                var _ListEOD = _IUoW.Repository<EOD>().Get(x => x.AuthStatusId == "A" &&
                                                                        x.LastAction != "DEL").OrderByDescending(x => x.EodId);

                return _ListEOD;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllEOD()", string.Empty);
                return null;
                //throw ex;
            }
        }
        #endregion

        #region Add
        public int AddEOD(EOD _EOD)
        {
            try
            {
                var _max = _IUoW.Repository<EOD>().GetMaxValue(x => x.EodId) + 1;
                _EOD.EodId = _max.ToString().PadLeft(3, '0');
                _EOD.AuthStatusId = "U";
                _EOD.LastAction = "ADD";
                _EOD.MakeDT = System.DateTime.Now;
                _EOD.MakeBy = "mtaka";
                var result = _IUoW.Repository<EOD>().Add(_EOD);

                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddEOD(obj)", string.Empty);
                return 0;
            }
        }

        #endregion
    }
}
