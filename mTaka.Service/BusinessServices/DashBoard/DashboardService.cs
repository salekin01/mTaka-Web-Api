using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.DashBoard;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace mTaka.Service.BusinessServices.DashBoard
{
    public interface IDashboardService
    {
        string GetDashBoardInfo(LedgerTxn _DashBoardInfo);
        string GetCommonDashboardInfo();
    }
    public class DashboardService : IDashboardService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;


        public DashboardService()
        {
            _IUoW = new UnitOfWork();
        }
        public DashboardService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Common Dashboard
        public string GetCommonDashboardInfo()
        {
            var NoOfAccount = _IUoW.Repository<AccMaster>().Get(x => x.AuthStatusId == "A" &&
                                                               x.LastAction != "DEL").Count().ToString();

            var NoOfActiveAccount = _IUoW.Repository<CustomerAccProfile>().Get(x => x.AuthStatusId == "A" &&
                                                              x.LastAction != "DEL").Count().ToString();

            var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            var TotalCashIn = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.DefineServiceId=="003").Sum(t => t.Amount).ToString();

            var TotalCashOut = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.DefineServiceId == "004").Sum(t => t.Amount).ToString();

            var CusTotalUSB = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.FunctionId == "0006031"
                                                            && x.AccountTypeId=="003").Sum(t => t.Amount).ToString();

            var CusTotalNoOfUSB = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.FunctionId == "0006031"
                                                            && x.AccountTypeId=="003").Count().ToString();

            var AgentTotalUSB = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.FunctionId == "0006031"
                                                            && x.AccountTypeId == "004").Sum(t => t.Amount).ToString();

            var AgentTotalNoOfUSB = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.FunctionId == "0006031"
                                                            && x.AccountTypeId == "004").Count().ToString();

            var TotalDescoBill = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.DefineServiceId == "006").Sum(t => t.Amount).ToString();

            var TotalNoDescoBill = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.DefineServiceId == "006").Count().ToString();

            #region Test
            List<LedgerTxn> _ListLedgerTxn = new List<LedgerTxn>();
            List<LedgerTxnHist> _ListLedgerTxnHist = new List<LedgerTxnHist>();

            _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == date
                                                            && x.DefineServiceId == "006");

            _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.TransectionDate == date
                                                            && x.DefineServiceId == "006");
            var Type = AutoMapperCFG.SetListMapping<LedgerTxn, LedgerTxnHist>(_ListLedgerTxn);
            #endregion

            List<DashBoardView> DashBoardInfo = new List<DashBoardView>{
                   new DashBoardView{Value = NoOfAccount},
                   new DashBoardView{Value = NoOfActiveAccount},
                   new DashBoardView{Value = TotalCashIn},
                   new DashBoardView{Value = TotalCashOut},
                   new DashBoardView{Value = CusTotalUSB},
                   new DashBoardView{Value = CusTotalNoOfUSB },
                   new DashBoardView{Value = AgentTotalUSB },
                   new DashBoardView{Value = AgentTotalNoOfUSB },
                   new DashBoardView{Value = TotalDescoBill },
                   new DashBoardView{Value = TotalNoDescoBill,}
                   };


            var jsonString = new JavaScriptSerializer().Serialize(DashBoardInfo);
            return jsonString;
        }
        #endregion


        #region Channel Member Wise Dashboard
        public string GetDashBoardInfo(LedgerTxn _DashBoardInfo)
        {

            dynamic CashInAmount = null, CashoutAmount = null, UsbAmountDESCO = null, TotalNoOfUSB = null;


            if (_DashBoardInfo.StartDate != null && _DashBoardInfo.EndDate != null)
            {
                var StartDate = _DashBoardInfo.StartDate.Value.Date;
                var EndDate = _DashBoardInfo.EndDate.Value.Date;

                CashInAmount = _IUoW.Repository<LedgerTxn>().Get(x =>  x.TransectionDate >= StartDate
                                                            && x.TransectionDate <= EndDate
                                                            && x.AccountTypeId == _DashBoardInfo.AccountTypeId
                                                            && x.DefineServiceId == "003").Sum(s => s.Amount).ToString();

                CashoutAmount = _IUoW.Repository<LedgerTxn>().Get(x =>  x.TransectionDate >= StartDate
                                                            && x.TransectionDate <= EndDate
                                                            && x.AccountTypeId == _DashBoardInfo.AccountTypeId
                                                            && x.DefineServiceId == "004").Sum(s => s.Amount).ToString();

                TotalNoOfUSB = _IUoW.Repository<LedgerTxn>().Get(x =>  x.TransectionDate >= StartDate
                                                            && x.TransectionDate <= EndDate
                                                            && x.AccountTypeId == _DashBoardInfo.AccountTypeId
                                                            && x.FunctionId == "0006031").Count().ToString();

                UsbAmountDESCO = _IUoW.Repository<LedgerTxn>().Get(x =>  x.TransectionDate >= StartDate
                                                            && x.TransectionDate <= EndDate
                                                            && x.AccountTypeId == _DashBoardInfo.AccountTypeId
                                                            && x.DefineServiceId == "006").Sum(s => s.Amount).ToString();
            }
            else
            {
                var Today = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                CashInAmount = _IUoW.Repository<LedgerTxn>().Get(x =>  x.TransectionDate == Today
                                                              && x.AccountTypeId == _DashBoardInfo.AccountTypeId
                                                              && x.DefineServiceId == "003").Sum(s => s.Amount).ToString();

                CashoutAmount = _IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate == Today
                                                                  && x.AccountTypeId == _DashBoardInfo.AccountTypeId
                                                                  && x.DefineServiceId == "004").Sum(s => s.Amount).ToString();

                UsbAmountDESCO = _IUoW.Repository<LedgerTxn>().Get(x =>  x.TransectionDate == Today
                                                                  && x.AccountTypeId == _DashBoardInfo.AccountTypeId
                                                                  && x.DefineServiceId == "006").Sum(s => s.Amount).ToString();
            }

            //return DashboardInfo;

            List<DashBoardView> DashBoardInfo = new List<DashBoardView>{
                   new DashBoardView{ReceiveAmount = CashInAmount, DefineServiceId = "003"},
                   new DashBoardView{ReceiveAmount = CashoutAmount, DefineServiceId = "004"},
                   new DashBoardView{ReceiveAmount = UsbAmountDESCO, DefineServiceId = "006"},
                   new DashBoardView{ReceiveAmount = TotalNoOfUSB, DefineServiceId = "004"}
                   };


            var jsonString = new JavaScriptSerializer().Serialize(DashBoardInfo);
            return jsonString;
        }
        #endregion
    }
}
