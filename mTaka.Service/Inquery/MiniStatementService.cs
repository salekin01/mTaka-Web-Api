using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Data.Inquery;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.Inquery
{
    public interface IMiniStatementService
    {
        IEnumerable<StatementDataModel> GetMiniStatment(StatementDataModel _Organogram);

    }
    public class MiniStatementService : IMiniStatementService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        private ErrorLogService _ObjErrorLogService = null;


        public MiniStatementService()
        {
            _IUoW = new UnitOfWork();
        }

        public MiniStatementService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        public IEnumerable<StatementDataModel> GetMiniStatment(StatementDataModel _Organogram)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<StatementDataModel> GetMiniStatment(StatementDataModel _StatementDataModel)
        //{
        //    List<StatementDataModel> StatementList = new List<StatementDataModel>();
        //    try
        //    {
        //        var date = _StatementDataModel.StatementDate.Date;
        //        StatementList = _IUoW.Repository<LedgerTxn>().Get(a => a.TransectionDate == date).Select(s =>
        //                new StatementDataModel
        //                {
        //                    ServiceName = _IUoW.Repository<DefineService>().Get(a => a.DefineServiceId == s.DefineServiceId).FirstOrDefault().ToString(),
        //                    Amount = s.PaymentAmount != 0 ? s.PaymentAmount.ToString() : s.ReceiveAmount.ToString(),
        //                    DebitCredit = s.PaymentAmount != 0 ? "Debit" : "Credit",
        //                    CurrentBalance = s.CurrentBalance.ToString(),
        //                    Description = null,
        //                    StatementDate = s.TransectionDate   
        //                }).ToList();
        //        return StatementList;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
