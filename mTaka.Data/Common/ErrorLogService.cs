using mTaka.Data.Infrastructure;
using mTaka.Data.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Common
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
                _ObjErrorLog.MakeDT = Convert.ToDateTime(DateTime.Now.ToShortDateString());

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

    public class ExceptionExtendedMethods
    {
        //sample methods
        private string _getInnerExceptions(Exception ex)
        {
            var exceptionMessages = new StringBuilder();
            do
            {
                ex = ex.InnerException;
                exceptionMessages.Append(ex);
            }
            while (ex != null);
            return exceptionMessages.ToString();
        }

        //sample methods
        private void _raiseException(Exception ex)
        {
            var exceptionMessages = new StringBuilder();
            do
            {
                exceptionMessages.Append(ex.Message);
                ex = ex.InnerException;
            }
            while (ex != null);
            throw new Exception(exceptionMessages.ToString());
        }

        //sample calling methods
        public void SomeMethod1()
        {
            try
            {
                //some code to try
            }
            catch (Exception e)
            {
                throw new Exception(this._getInnerExceptions(e));
            }
        }

        //sample calling methods
        public void SomeMethod2()
        {
            try
            {
                //some code to try
            }
            catch (Exception e)
            {
                this._raiseException(e);
            }
        }

        public static string GetInnerExceptions(Exception ex)
        {
            string exceptionMessages = string.Empty;
            do
            {
                exceptionMessages += ex.Message + ";;;;";
                ex = ex.InnerException;
            }
            while (ex != null);
            return exceptionMessages;
        }
    }
}
