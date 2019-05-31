using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Data.Performance;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.Performance
{
    public interface ITopPerformerService
    {
        IEnumerable<dynamic> TopPerformerInfo(LedgerTxn _ledgerTxn);
        IEnumerable<dynamic> LowestPerformerInfo(LedgerTxn _ledgerTxn);
    }
    public class TopPerformerService : ITopPerformerService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        TopPerformer _TopPerformer = null;

        public TopPerformerService()
        {
            _IUoW = new UnitOfWork();
        }
        public TopPerformerService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        

        public IEnumerable<dynamic> TopPerformerInfo(LedgerTxn _ledgerTxn)
        {
            if (_ledgerTxn.TotalAmountOfTransaction == "True")
            {
                dynamic TopPerformer = _IUoW.mTakaDbQuery().TopPerformer_LQ(_ledgerTxn);
                return TopPerformer;
            }
            else if(_ledgerTxn.TotalNoOfTransaction == "True")
            {
                dynamic TopPerformer = _IUoW.mTakaDbQuery().TopPerformerByNo_LQ(_ledgerTxn);
                return TopPerformer;
            }
            else
            {
                return null;
            }
            //var FromDate = _ledgerTxn.FromDate.Value.Date;
            //var Todate = _ledgerTxn.ToDate.Value.Date;
            //var _TopPerformerInfo = _IUoW.Repository<LedgerTxn>().Get(x => x.AccountTypeId == _ledgerTxn.AccountTypeId &&
            //                                                         x.TransectionDate >= FromDate &&
            //                                                         x.TransectionDate <= Todate).
            //    OrderByDescending(s => s.PaymentAmount).Select(s => new TopPerformer
            //    {
            //       // AccName = s.WalletAccountNo,
            //        AccNo = s.FromSystemAccountNo,
            //       // Amount = s.PaymentAmount
            //    }).ToList();
            ////var FromDate = _ledgerTxn.FromDate.Value.Date;
            ////var Todate = _ledgerTxn.ToDate.Value.Date;
            ////var _TopPerformerInfo = _IUoW.Repository<LedgerTxn>().Get(x => x.AccountTypeId == _ledgerTxn.AccountTypeId &&
            ////                                                         x.TransectionDate >= FromDate &&
            ////                                                         x.TransectionDate <= Todate).
            ////    OrderByDescending(s => s.PaymentAmount).Select(s => new TopPerformer
            ////    {
            ////        AccName = s.WalletAccountNo,
            ////    }).ToList();

            //foreach(var element in _TopPerformerInfo)
            //{
            //    var aaa = _IUoW.Repository<LedgerTxn>().Get(x => x.FromSystemAccountNo == element.AccNo).
            //                                         Sum(s => s.PaymentAmount).ToString().ToList();
            //}
            //return _TopPerformerInfo;
        }

        public IEnumerable<dynamic> LowestPerformerInfo(LedgerTxn _ledgerTxn)
        {
            if (_ledgerTxn.TotalAmountOfTransaction == "True")
            {
                dynamic LowestPerformer = _IUoW.mTakaDbQuery().LowestPerformer_LQ(_ledgerTxn);
                return LowestPerformer;
            }
            else if (_ledgerTxn.TotalNoOfTransaction == "True")
            {
                dynamic LowestPerformer = _IUoW.mTakaDbQuery().LowestPerformerByNo_LQ(_ledgerTxn);
                return LowestPerformer;
            }
            else
            {
                return null;
            }
            //var _TopPerformerInfo = _IUoW.Repository<LedgerTxn>().Get(x => x.AccountTypeId == _ledgerTxn.AccountTypeId).
            //    OrderBy(s => s.PaymentAmount ).Select(s => new TopPerformer
            //    {
            //        AccName = s.WalletAccountNo,
            //        AccNo = s.FromSystemAccountNo,
            //        Amount = s.PaymentAmount
            //    }).Take(5);
            //return _TopPerformerInfo;
        }
    }
}
