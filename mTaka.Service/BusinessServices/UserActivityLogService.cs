using mTaka.Data.BusinessEntities;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.BusinessServices
{
    public interface IUserActivityLogService
    {
        IEnumerable<UserActivityLog> UserActivityLogByAccNo(string _WalletAccountNo);
        int AddUserActivityLog(UserActivityLog _UserActivityLog);
        IEnumerable<UserActivityLog> UserActivityLogByDate(UserActivityLog _UserActivityLog);
    }
    public class UserActivityLogService : IUserActivityLogService
    {
        private IUnitOfWork _IUoW = null;
        ErrorLogService _ObjErrorLogService = null;

        public UserActivityLogService()
        {
            _IUoW = new UnitOfWork();
        }

        public UserActivityLogService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Add
        public int AddUserActivityLog(UserActivityLog _UserActivityLog)
        {
            try
            {
                var _max = _IUoW.Repository<UserActivityLog>().GetMaxValue(x => x.SlId) + 1;
                _UserActivityLog.SlId = _max.ToString().PadLeft(9, '0');
                _UserActivityLog.DateTime = System.DateTime.Now;
                //_UserActivityLog.TransectionDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                _UserActivityLog.TransectionDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                //DateTime TransectionDate = Convert.ToDateTime(_UserActivityLog.TransectionDate.ToString("MM/dd/yyyy"));
                // _UserActivityLog.TransectionDate = Convert.ToDateTime(_UserActivityLog.DateTime.ToString("MM/dd/yyyy"));
                var result = _IUoW.Repository<UserActivityLog>().Add(_UserActivityLog);

                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddUserActivityLog(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region UserActivityLogByAccNo
        public IEnumerable<UserActivityLog> UserActivityLogByAccNo(string _WalletAccountNo)
        {
            try
            {
                var AllctivityLog = _IUoW.Repository<UserActivityLog>().Get(x => x.WalletAccountNo == _WalletAccountNo).OrderByDescending(x => x.SlId);
                return AllctivityLog;
            }

            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UserActivityLogByAccNo()", string.Empty);
                return null;
            }
        }
        #endregion

        #region UserActivityLogByDate
        public IEnumerable<UserActivityLog> UserActivityLogByDate(UserActivityLog _UserActivityLog)
        {
            try
            { //int result1 = DateTime.Compare(toTxnDate.Date, txnDate1.Date);
                //DateTime FormDate = Convert.ToDateTime(_UserActivityLog.FormDate.ToString("dd/MM/yyyy"));
                //DateTime ToDate = Convert.ToDateTime(_UserActivityLog.ToDate.ToString("dd/MM/yyyy"));

                _UserActivityLog.FormDate = Convert.ToDateTime(_UserActivityLog.FormDate.ToShortDateString());
                _UserActivityLog.ToDate = Convert.ToDateTime(_UserActivityLog.ToDate.ToShortDateString());

                var AllctivityLog = _IUoW.Repository<UserActivityLog>().Get(x => x.TransectionDate >= _UserActivityLog.FormDate && x.TransectionDate <= _UserActivityLog.ToDate).OrderByDescending(x => x.SlId).ToList();
                return AllctivityLog;
            }

            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UserActivityLogByDate()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
