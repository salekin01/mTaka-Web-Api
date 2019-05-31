using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface IChargeApplyDateTimeService
    {
        int AddChargeApplyDateTime(ChargeApplyDateTime _ChargeApplyDateTime);
    }
    public class ChargeApplyDateTimeService : IChargeApplyDateTimeService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public ChargeApplyDateTimeService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChargeApplyDateTimeService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public int AddChargeApplyDateTime(ChargeApplyDateTime _ChargeApplyDateTime)
        {
            try
            {

                _ChargeApplyDateTime.AuthStatusId = "U";
                _ChargeApplyDateTime.LastAction = "ADD";
                _ChargeApplyDateTime.MakeDT = System.DateTime.Now;
                var result = _IUoW.Repository<ChargeApplyDateTime>().Add(_ChargeApplyDateTime);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _ChargeApplyDateTime, "ADD", "0001", "090102003", 1, "ChargeApplyDateTime", "MTK_CHG_APPLY_DT", "ChargeRuleId", _ChargeApplyDateTime.ChargeRuleId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                }
                #endregion

                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddChargeRule(obj)", string.Empty);
                return 0;
            }
        }
       
    }
}
