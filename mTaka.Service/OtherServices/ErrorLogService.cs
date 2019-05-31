using mTaka.Data.Infrastructure;
using mTaka.Data.OtherEntities;
using mTaka.Service.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.OtherServices
{
    public interface IErrorLogService
    {
        IEnumerable<ErrorLog> GetAllErrorLog();
        void AddErrorLog(Exception _exObj, string _FunctionId, string _ErrMethod, string _makeBy);
        int DeleteErrorLog(ErrorLog _ErrorLog);
    }
    public class ErrorLogService : IErrorLogService
    {
        private IUnitOfWork _IUoW = null;
        public ErrorLogService()
        {
            _IUoW = new UnitOfWork();
        }
        public ErrorLogService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }


        #region Fetch
        public IEnumerable<ErrorLog> GetAllErrorLog()
        {
            try
            {
                return _IUoW.Repository<ErrorLog>().GetAll().OrderByDescending(a => a.SL);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Add
        public void AddErrorLog(Exception _exObj, string _FunctionId, string _ErrMethod, string _makeBy)
        {
            try
            {
                var _max = _IUoW.Repository<ErrorLog>().GetMaxValue(x => x.SL) + 1;

                ErrorLog _ObjErrorLog = new ErrorLog();
                _ObjErrorLog.SL = _max.ToString();
                _ObjErrorLog.FunctionId = _FunctionId;
                _ObjErrorLog.ErrorSource = _exObj.Source;
                _ObjErrorLog.ErrorMethod = _ErrMethod;
                _ObjErrorLog.ErrorMessage = _exObj.Message;
                _ObjErrorLog.InnerException = ExceptionExtendedMethods.GetInnerExceptions(_exObj);
                _ObjErrorLog.StackTrace = _exObj.StackTrace;
                _ObjErrorLog.AuthStatusId = "A";
                _ObjErrorLog.LastAction = "ADD";
                _ObjErrorLog.MakeBy = _makeBy;
                _ObjErrorLog.MakeDT = System.DateTime.Now;

                var result = _IUoW.Repository<ErrorLog>().Add(_ObjErrorLog);
                _IUoW.Commit();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Delete
        public int DeleteErrorLog(ErrorLog _ErrorLog)
        {
            try
            {
                int result = 0;
                if (!string.IsNullOrWhiteSpace(_ErrorLog.SL))
                {
                    result = _IUoW.Repository<ErrorLog>().Delete(_ErrorLog);
                    _IUoW.Commit();
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
