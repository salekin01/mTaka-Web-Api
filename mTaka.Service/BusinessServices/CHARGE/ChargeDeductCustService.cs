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
    public interface IChargeDeductCustService
    {
        IEnumerable<ChargeDeductCust> GetAllChargeDeductCust();
        ChargeDeductCust GetChargeDeductCustById(string _ChargeDedCustId);
        IEnumerable<ChargeDeductCust> GetChargeDeductCustBy(ChargeDeductCust _ChargeDeductCust);
        int AddChargeDeductCust(ChargeDeductCust _ChargeDeductCust);
        int UpdateChargeDeductCust(ChargeDeductCust _ChargeDeductCust);
        int DeleteChargeDeductCust(ChargeDeductCust _ChargeDeductCust);
        
    }

    public class ChargeDeductCustService : IChargeDeductCustService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public ChargeDeductCustService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChargeDeductCustService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public int AddChargeDeductCust(ChargeDeductCust _ChargeDeductCust)
        {
            try
            {

                _ChargeDeductCust.AuthStatusId = "U";
                _ChargeDeductCust.LastAction = "ADD";
                _ChargeDeductCust.MakeDT = System.DateTime.Now;
                var result = _IUoW.Repository<ChargeDeductCust>().Add(_ChargeDeductCust);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _ChargeDeductCust, "ADD", "0001", "090102003", 1, "ChargeDeductCust", "MTK_CHG_DEDUCT_CUST", "ChargeRuleId", _ChargeDeductCust.ChargeRuleId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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

        public int DeleteChargeDeductCust(ChargeDeductCust _ChargeDeductCust)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChargeDeductCust> GetAllChargeDeductCust()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChargeDeductCust> GetChargeDeductCustBy(ChargeDeductCust _ChargeDeductCust)
        {
            throw new NotImplementedException();
        }

        public ChargeDeductCust GetChargeDeductCustById(string _ChargeDedCustId)
        {
            throw new NotImplementedException();
        }

        public int UpdateChargeDeductCust(ChargeDeductCust _ChargeDeductCust)
        {
            throw new NotImplementedException();
        }

       
    }
}
