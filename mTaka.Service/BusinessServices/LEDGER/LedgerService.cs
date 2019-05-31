using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.Common;
//using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.CP;
using mTaka.Service.Common;
//using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.LEDGER
{
    public interface IChannelLedgerService
    {
        int InsertLedgerTxn(IUnitOfWork _IUoW, LedgerTxn _LedgerTxn);
        string UpdateClosingBalance(IUnitOfWork _IUoW, LedgerMaster _LedgerMaster);
        List<LedgerTxnHist> GetAllLedgerTxnByAccNoandDate(LedgerTxn _LedgerTxn);
        List<LedgerTxnHist> GetAllLedgerTxnforTopPerformerMonitoring(LedgerTxn _LedgerTxn);
        AccMaster GetAccMasterInfoByAccNo(AccMaster _AccMaster);
        string IfAccCrossTheBalanceLimit(LedgerMaster _LedgerMaster);
    }
    public class LedgerService : IChannelLedgerService
    {
        private IUnitOfWork _IUoW = null;
        ErrorLogService _ObjErrorLogService = null;
        public LedgerService()
        {
            _IUoW = new UnitOfWork();
        }
        public LedgerService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        public static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        public static String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
        public static string BinaryStringToHexString(string binary)
        {
            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... Will throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                var s = result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }
        //#region Update for LedgerTxn
        //public int InsertLedgerTxn(IUnitOfWork _IUoW, LedgerTxn _LedgerTxn)
        //{
        //    int result = 0;
        //    try
        //    {
        //        LedgerService OBJ_ChannelLedgerService = new LedgerService();
        //        int result1 = 0;
        //        int result2 = 0;
        //        int result_master = 0;
        //        int result_master1 = 0;

        //        #region UnKnown
        //        if (_LedgerTxn.PaymentAmount == 0 || _LedgerTxn.ReceiveAmount == 0)
        //        {
        //            LedgerMaster Obj_Master = new LedgerMaster();
        //            Obj_Master.AccProfileId = _LedgerTxn.AccProfileId;
        //            Obj_Master.AccountTypeId = _LedgerTxn.AccountTypeId;
        //            Obj_Master.SystemAccountNo = _LedgerTxn.FromSystemAccountNo;
        //            Obj_Master.OpeningBalance = _LedgerTxn.OpeningBalance;
        //            Obj_Master.ClosingBalance = _LedgerTxn.ClosingBalance;
        //            Obj_Master.PaymentAmount = _LedgerTxn.PaymentAmount;
        //            Obj_Master.ReceiveAmount = _LedgerTxn.ReceiveAmount;
        //            string ResultClosingBalance = OBJ_ChannelLedgerService.UpdateClosingBalance(_IUoW, Obj_Master);

        //            var split = ResultClosingBalance.ToString().Split(':');
        //            result_master = Convert.ToInt32(split[0]);
        //            _LedgerTxn.ClosingBalance = Convert.ToDecimal(split[1]);

        //            if (result_master == 1)
        //            {
        //                LedgerTxn Obj_Txn = new LedgerTxn();

        //                Obj_Txn.BatchNo = _LedgerTxn.BatchNo;
        //                Obj_Txn.TransectionId = _LedgerTxn.TransectionId;
        //                Obj_Txn.AccProfileId = _LedgerTxn.AccProfileId;
        //                Obj_Txn.AccountTypeId = _LedgerTxn.AccountTypeId;
        //                Obj_Txn.FromSystemAccountNo = _LedgerTxn.FromSystemAccountNo;
        //                Obj_Txn.ToSystemAccountNo = _LedgerTxn.ToSystemAccountNo;
        //                Obj_Txn.PaymentAmount = _LedgerTxn.PaymentAmount;
        //                Obj_Txn.ReceiveAmount = 0;
        //                Obj_Txn.CurrentBalance = _LedgerTxn.ClosingBalance;
        //                Obj_Txn.AccountTypeId = _LedgerTxn.FromAccountTypeId;
        //                Obj_Txn.MakeBy = _LedgerTxn.MakeBy;
        //                Obj_Txn.FunctionId = _LedgerTxn.FunctionId;
        //                Obj_Txn.AmountId = _LedgerTxn.AmountId;
        //                Obj_Txn.DefineServiceId = _LedgerTxn.DefineServiceId;
        //                Obj_Txn.TransectionDate = _LedgerTxn.TransectionDate;
        //                Obj_Txn.Narration = _LedgerTxn.Narration;
        //                Obj_Txn.LastAction = "ADD";
        //                Obj_Txn.LastUpdateDT = null;
        //                Obj_Txn.AuthStatusId = "A";
        //                Obj_Txn.MakeDT = System.DateTime.Now;
        //                Obj_Txn.ProductId = _LedgerTxn.ProductId;
        //                Obj_Txn.BranchId = _LedgerTxn.BranchId;
        //                //Add NEW PK
        //                //if (_LedgerTxn.TransectionParentId == null)
        //                //{
        //                //    Obj_Txn.TransectionParentId = "0";
        //                //}
        //                //else
        //                //{
        //                //    Obj_Txn.TransectionParentId = _LedgerTxn.TransectionParentId;
        //                //}
        //                result = _IUoW.Repository<LedgerTxn>().Add(Obj_Txn);
        //            }
        //        }
        //        #endregion

        //        #region Transaction
        //        if (_LedgerTxn.PaymentAmount > 0 && _LedgerTxn.ReceiveAmount > 0)
        //        {
        //            LedgerMaster Obj_Master = new LedgerMaster();
        //            Obj_Master.AccProfileId = _LedgerTxn.FromAccProfileId;
        //            Obj_Master.AccountTypeId = _LedgerTxn.FromAccountTypeId;
        //            Obj_Master.SystemAccountNo = _LedgerTxn.FromSystemAccountNo;
        //            Obj_Master.OpeningBalance = _LedgerTxn.OpeningBalance;
        //            Obj_Master.ClosingBalance = _LedgerTxn.ClosingBalance;
        //            Obj_Master.PaymentAmount = _LedgerTxn.PaymentAmount;
        //            Obj_Master.ReceiveAmount = 0;
        //            string ResultClosingBalance = OBJ_ChannelLedgerService.UpdateClosingBalance(_IUoW, Obj_Master);

        //            var split = ResultClosingBalance.ToString().Split(':');
        //            result_master = Convert.ToInt32(split[0]);
        //            _LedgerTxn.ClosingBalance = Convert.ToDecimal(split[1]);

        //            if (result_master == 1)
        //            {
        //                LedgerTxn Obj_Txn = new LedgerTxn();

        //                Obj_Txn.BatchNo = _LedgerTxn.BatchNo;
        //                Obj_Txn.TransectionId = _LedgerTxn.FromTransectionId;
        //                Obj_Txn.AccProfileId = _LedgerTxn.FromAccProfileId.ToString();
        //                Obj_Txn.AccountTypeId = _LedgerTxn.FromAccountTypeId;
        //                Obj_Txn.FromSystemAccountNo = _LedgerTxn.FromSystemAccountNo;
        //                Obj_Txn.ToSystemAccountNo = _LedgerTxn.ToSystemAccountNo;
        //                Obj_Txn.PaymentAmount = _LedgerTxn.PaymentAmount;
        //                Obj_Txn.ReceiveAmount = 0;
        //                Obj_Txn.CurrentBalance = _LedgerTxn.ClosingBalance;
        //                Obj_Txn.AccountTypeId = _LedgerTxn.FromAccountTypeId;
        //                Obj_Txn.MakeBy = _LedgerTxn.MakeBy;
        //                Obj_Txn.FunctionId = _LedgerTxn.FunctionId;
        //                Obj_Txn.AmountId = _LedgerTxn.AmountId;
        //                Obj_Txn.DefineServiceId = _LedgerTxn.DefineServiceId;
        //                Obj_Txn.TransectionDate = _LedgerTxn.TransectionDate;
        //                Obj_Txn.Narration = _LedgerTxn.Narration;
        //                Obj_Txn.LastAction = "ADD";
        //                Obj_Txn.LastUpdateDT = null;
        //                Obj_Txn.MakeDT = System.DateTime.Now;
        //                Obj_Txn.AuthStatusId = "A";
        //                Obj_Txn.ProductId = _LedgerTxn.ProductId;
        //                Obj_Txn.BranchId = _LedgerTxn.BranchId;
        //                //Add NEW PK
        //                //if (_LedgerTxn.TransectionParentId == null)
        //                //{
        //                //    Obj_Txn.TransectionParentId = "0";
        //                //}
        //                //else
        //                //{
        //                //    Obj_Txn.TransectionParentId = _LedgerTxn.TransectionParentId;
        //                //}
        //                var split_date_row1 = _LedgerTxn.TransectionDate.ToString().Split(' ');
        //                var split_date_row1_1 = split_date_row1[0].ToString().Split('/');
        //                //var TransectionCode_row1 = _LedgerTxn.FromTransectionId + split_date_row1_1[2] + split_date_row1_1[1] + split_date_row1_1[0] + _LedgerTxn.BatchNo;
        //                var TransectionCode_row1 = _LedgerTxn.FromTransectionId + split_date_row1_1[2] + split_date_row1_1[1] + split_date_row1_1[0];
        //                var value_row1 = Convert.ToInt64(TransectionCode_row1);
        //                Obj_Txn.TransectionCode = String.Format("{0:X}", value_row1);
        //                result1 = _IUoW.Repository<LedgerTxn>().Add(Obj_Txn);

        //                LedgerMaster Obj_Master1 = new LedgerMaster();
        //                Obj_Master1.AccProfileId = _LedgerTxn.ToAccProfileId;
        //                Obj_Master1.AccountTypeId = _LedgerTxn.ToAccountTypeId;
        //                Obj_Master1.SystemAccountNo = _LedgerTxn.ToSystemAccountNo;
        //                Obj_Master1.OpeningBalance = _LedgerTxn.OpeningBalance;
        //                Obj_Master1.ClosingBalance = _LedgerTxn.ClosingBalance;
        //                Obj_Master1.PaymentAmount = 0;
        //                Obj_Master1.ReceiveAmount = _LedgerTxn.ReceiveAmount;
        //                string ResultClosingBalance1 = OBJ_ChannelLedgerService.UpdateClosingBalance(_IUoW, Obj_Master1);

        //                var split1 = ResultClosingBalance1.ToString().Split(':');
        //                result_master1 = Convert.ToInt32(split1[0]);
        //                _LedgerTxn.ClosingBalance = Convert.ToDecimal(split1[1]);

        //                if (result_master1 == 1)
        //                {
        //                    LedgerTxn Obj_Txn1 = new LedgerTxn();

        //                    Obj_Txn1.BatchNo = _LedgerTxn.BatchNo;
        //                    Obj_Txn1.TransectionId = _LedgerTxn.ToTransectionId;
        //                    Obj_Txn1.AccProfileId = _LedgerTxn.ToAccProfileId;
        //                    Obj_Txn1.AccountTypeId = _LedgerTxn.ToAccountTypeId;
        //                    Obj_Txn1.FromSystemAccountNo = _LedgerTxn.ToSystemAccountNo;
        //                    Obj_Txn1.ToSystemAccountNo = _LedgerTxn.FromSystemAccountNo;
        //                    Obj_Txn1.PaymentAmount = 0;
        //                    Obj_Txn1.ReceiveAmount = _LedgerTxn.ReceiveAmount;
        //                    Obj_Txn1.CurrentBalance = _LedgerTxn.ClosingBalance;
        //                    Obj_Txn1.AccountTypeId = _LedgerTxn.ToAccountTypeId;
        //                    Obj_Txn1.MakeBy = _LedgerTxn.MakeBy;
        //                    Obj_Txn1.FunctionId = _LedgerTxn.FunctionId;
        //                    Obj_Txn1.AmountId = _LedgerTxn.AmountId;
        //                    Obj_Txn1.DefineServiceId = _LedgerTxn.DefineServiceId;
        //                    Obj_Txn1.TransectionDate = _LedgerTxn.TransectionDate;
        //                    Obj_Txn1.Narration = _LedgerTxn.Narration;
        //                    Obj_Txn1.LastAction = "ADD";
        //                    Obj_Txn1.LastUpdateDT = null;
        //                    Obj_Txn1.MakeDT = System.DateTime.Now;
        //                    Obj_Txn1.AuthStatusId = "A";
        //                    Obj_Txn1.ProductId = _LedgerTxn.ProductId;
        //                    Obj_Txn1.BranchId = _LedgerTxn.BranchId;
        //                    //Add NEW PK
        //                    //if (_LedgerTxn.TransectionParentId == null)
        //                    //{
        //                    //    Obj_Txn1.TransectionParentId = "0";
        //                    //}
        //                    //else
        //                    //{
        //                    //    Obj_Txn1.TransectionParentId = _LedgerTxn.TransectionParentId;
        //                    //}
        //                    var split_date_row2 = _LedgerTxn.TransectionDate.ToString().Split(' ');
        //                    var split_date_row2_1 = split_date_row2[0].ToString().Split('/');
        //                    //var TransectionCode_row2 = _LedgerTxn.ToTransectionId + split_date_row2_1[2] + split_date_row2_1[1] + split_date_row2_1[0] + _LedgerTxn.BatchNo;
        //                    var TransectionCode_row2 = _LedgerTxn.ToTransectionId + split_date_row2_1[2] + split_date_row2_1[1] + split_date_row2_1[0];
        //                    var value_row2 = Convert.ToInt64(TransectionCode_row2);
        //                    Obj_Txn1.TransectionCode = String.Format("{0:X}", value_row2);
        //                    result2 = _IUoW.Repository<LedgerTxn>().Add(Obj_Txn1);
        //                    if (result1 == 1 && result2 == 1)
        //                    {
        //                        result = 1;                                
        //                    }
        //                }
        //            }                
        //            else
        //                return result;
        //        }
        //        #endregion

        //        #region UtilityBill
        //        if (_LedgerTxn.PaymentAmount > 0 &&  _LedgerTxn.FunctionId== "0006031")
        //        {
        //            var _LedgerMasterInfo = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == _LedgerTxn.FromSystemAccountNo);
        //            LedgerMaster Obj_Master = new LedgerMaster();
        //            Obj_Master.AccProfileId = _LedgerTxn.AccProfileId;
        //            Obj_Master.AccountTypeId = _LedgerTxn.AccountTypeId;
        //            Obj_Master.SystemAccountNo = _LedgerTxn.FromSystemAccountNo;
        //            Obj_Master.OpeningBalance = _LedgerTxn.OpeningBalance;
        //            Obj_Master.ClosingBalance = _LedgerTxn.ClosingBalance;
        //            Obj_Master.PaymentAmount = _LedgerTxn.PaymentAmount;
        //            Obj_Master.ReceiveAmount = _LedgerTxn.ReceiveAmount;

        //            _LedgerMasterInfo.ClosingBalance= _LedgerTxn.ClosingBalance;

        //            result = _IUoW.Repository<LedgerMaster>().Update(_LedgerMasterInfo);

        //            if (result == 1)
        //            {
        //                LedgerTxn Obj_Txn = new LedgerTxn();
        //                var _max = _IUoW.Repository<LedgerTxn>().GetMaxValue(x => x.TransectionId) + 1;
        //                Obj_Txn.TransectionId = _max.ToString().PadLeft(3, '0');

        //                Obj_Txn.BatchNo = _LedgerTxn.BatchNo;
        //                //Obj_Txn.TransectionId = _LedgerTxn.TransectionId;
        //                Obj_Txn.AccProfileId = _LedgerTxn.AccProfileId;
        //                Obj_Txn.AccountTypeId = _LedgerTxn.AccountTypeId;
        //                Obj_Txn.FromSystemAccountNo = _LedgerTxn.FromSystemAccountNo;
        //                Obj_Txn.ToSystemAccountNo = _LedgerTxn.FromSystemAccountNo;
        //                Obj_Txn.PaymentAmount = _LedgerTxn.PaymentAmount;
        //                Obj_Txn.ReceiveAmount = 0;
        //                Obj_Txn.CurrentBalance = _LedgerTxn.ClosingBalance;
        //                Obj_Txn.AccountTypeId = _LedgerTxn.FromAccountTypeId;
        //                Obj_Txn.MakeBy = _LedgerTxn.MakeBy;
        //                Obj_Txn.FunctionId = _LedgerTxn.FunctionId;
        //                Obj_Txn.AmountId = _LedgerTxn.AmountId;
        //                Obj_Txn.DefineServiceId = _LedgerTxn.DefineServiceId;
        //                Obj_Txn.TransectionDate = _LedgerTxn.TransectionDate;
        //                Obj_Txn.Narration = _LedgerTxn.Narration;
        //                //Obj_Txn.TransectionParentId = "00154";
        //                Obj_Txn.LastAction = "ADD";
        //                Obj_Txn.LastUpdateDT = System.DateTime.Now;
        //                Obj_Txn.AuthStatusId = "A";
        //                Obj_Txn.MakeDT = System.DateTime.Now;
        //                Obj_Txn.ProductId = _LedgerTxn.ProductId;
        //                Obj_Txn.BranchId = _LedgerTxn.BranchId;

        //                result = _IUoW.Repository<LedgerTxn>().Add(Obj_Txn); 

        //                //Add NEW PK
        //                if (result== 1)
        //                {
        //                    return result;
        //                }
        //                else
        //                {
        //                    return 0;
        //                }
        //                //result = _IUoW.Repository<LedgerTxn>().Add(Obj_Txn);
        //            }
        //        }
        //        #endregion

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _ObjErrorLogService = new ErrorLogService();
        //        _ObjErrorLogService.AddErrorLog(ex, string.Empty, "InsertLedgerTxn(obj)", string.Empty);                
        //    }
        //    return result;
        //}
        //#endregion

        //#region Update for UpdateClosingBalance
        //public string UpdateClosingBalance(IUnitOfWork _IUoW, LedgerMaster _LedgerMaster)
        //{
        //    int result = 0;
        //    string ResultClosingBalance = string.Empty;
        //    decimal OpeningBalance = _LedgerMaster.OpeningBalance;
        //    decimal ClosingBalance = _LedgerMaster.ClosingBalance;
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(_LedgerMaster.AccProfileId))
        //        {
        //            //#region Insert a new row
        //            //if (OpeningBalance > 0)
        //            //{
        //            //    _LedgerMaster.OpeningBalance = OpeningBalance;
        //            //    _LedgerMaster.ClosingBalance = ClosingBalance;
        //            //    _LedgerMaster.LastAppliedDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
        //            //    result = _IUoW.Repository<LedgerMaster>().Add(_LedgerMaster);                        
        //            //}
        //            //#endregion
        //            #region Update Closing Balance
        //            //if (OpeningBalance == 0)
        //            //{
        //            decimal PmtAmt = Convert.ToDecimal(_LedgerMaster.PaymentAmount);
        //            decimal RcvAmt = Convert.ToDecimal(_LedgerMaster.ReceiveAmount);
        //            LedgerMaster Obj_LedgerMaster = new LedgerMaster();
        //            Obj_LedgerMaster = _IUoW.Repository<LedgerMaster>().GetBy(x => x.AccProfileId == _LedgerMaster.AccProfileId);
        //            OpeningBalance = Obj_LedgerMaster.OpeningBalance;
        //            ClosingBalance = Obj_LedgerMaster.ClosingBalance;

        //            if (PmtAmt == 0)
        //            {
        //                ClosingBalance = ClosingBalance + RcvAmt;
        //            }
        //            if (RcvAmt == 0)
        //            {
        //                ClosingBalance = ClosingBalance - PmtAmt;
        //            }
        //            if (Obj_LedgerMaster.AccProfileId != null)
        //            {
        //                Obj_LedgerMaster.ClosingBalance = ClosingBalance;
        //                Obj_LedgerMaster.LastAppliedDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));

        //                result = _IUoW.Repository<LedgerMaster>().Update(Obj_LedgerMaster);
        //            }
        //            //}
        //            #endregion
        //        }
        //        ResultClosingBalance = result + ":" + ClosingBalance;
        //        return ResultClosingBalance;
        //    }
        //    catch (Exception ex)
        //    {
        //        _ObjErrorLogService = new ErrorLogService();
        //        _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateClosingBalance(obj)", string.Empty);
        //        ResultClosingBalance = result + ":" + ClosingBalance;
        //        return ResultClosingBalance;
        //    }
        //}
        //#endregion

        #region GetAllLedgerTxnByAccNoandDate
        public List<LedgerTxnHist> GetAllLedgerTxnByAccNoandDate(LedgerTxn _LedgerTxn)
        {
            try
            {
                //DateTime txnDate1 = Convert.ToDateTime(NCORE_COB_EOD_MAP.GetTxnDate(CHANNEL_ID));
                //int result = DateTime.Compare(fromTxnDate.Date, txnDate1.Date);
                //int result1 = DateTime.Compare(toTxnDate.Date, txnDate1.Date);
                List<LedgerTxn> _ListLedgerTxn = new List<LedgerTxn>();
                List<LedgerTxnHist> _ListLedgerTxnHist = new List<LedgerTxnHist>();
                AccMaster obj_AccInfo_SystemAccNo = null;
                obj_AccInfo_SystemAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _LedgerTxn.WalletAccountNo
                                                                                && x.AuthStatusId == "A"
                                                                                && x.LastAction != "DEL");
                if (obj_AccInfo_SystemAccNo != null)
                {
                    if (_LedgerTxn.FromDate != null && _LedgerTxn.ToDate == null)     //10
                    {
                        //DateTime FromDate = Convert.ToDateTime(_LedgerTxn.FromDate);
                        //FromDate = Convert.ToDateTime(FromDate.ToString("dd/MM/yyyy"));

                        _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate >= DbFunctions.TruncateTime(_LedgerTxn.FromDate) &&
                                                                                                 x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                        _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.TransectionDate >= DbFunctions.TruncateTime(_LedgerTxn.FromDate) &&
                                                                                                             x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                    }
                    else if (_LedgerTxn.FromDate == null && _LedgerTxn.ToDate != null) //01
                    {
                        _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate <= DbFunctions.TruncateTime(_LedgerTxn.ToDate) &&
                                                                                                 x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                        _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.TransectionDate <= DbFunctions.TruncateTime(_LedgerTxn.ToDate) &&
                                                                                                             x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                    }
                    else if (_LedgerTxn.FromDate == null && _LedgerTxn.ToDate == null) //00
                    {
                        _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                        _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                    }
                    else  //11
                    {
                        _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate >= DbFunctions.TruncateTime(_LedgerTxn.FromDate) &&
                                                                                                 x.TransectionDate <= DbFunctions.TruncateTime(_LedgerTxn.ToDate) &&
                                                                                                 x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                        //var aaa = _IUoW.Repository<UnionInfo>().GetBy(x => x.AuthStatusId == "A" &&
                        //                                                 x.LastAction != "DEL", n => new { n.UnionId, n.UnionNm, n.UnionShortNm, n.MakeDT, n.UpazilaId });
                        //var bbb = _IUoW.Repository<UpazilaInfo>().GetBy(x => x.AuthStatusId == "A" &&
                        //                                                             x.LastAction != "DEL", n => new { n.UpazilaId, n.UpazilaNm });
                        //List<UnionInfo> OBJ_LIST_UnionInfo = aaa.Join(bbb, p => p.UpazilaId, pc => pc.UpazilaId, (p, pc) => new UnionInfo
                        //{
                        //    UnionId = p.UnionId,
                        //    UnionNm = p.UnionNm,
                        //    UnionShortNm = p.UnionShortNm,
                        //    UpazilaNm = pc.UpazilaNm,
                        //    UpazilaId = p.UpazilaId,
                        //    MakeDT = p.MakeDT

                        //}).ToList();
                        _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.TransectionDate >= DbFunctions.TruncateTime(_LedgerTxn.FromDate) &&
                                                                                                             x.TransectionDate <= DbFunctions.TruncateTime(_LedgerTxn.ToDate) &&
                                                                                                             x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                    }
                    if(_ListLedgerTxn != null)
                    {
                        var Type = AutoMapperCFG.SetListMapping<LedgerTxn, LedgerTxnHist>(_ListLedgerTxn);
                        _ListLedgerTxnHist.AddRange(Type);
                    }
                    
                    //GetAccMasterInfoByAccNo(new AccMaster { SystemAccountNo = obj_AccInfo_SystemAccNo.SystemAccountNo });
                }
                if (_ListLedgerTxnHist != null)
                {
                    IAccInfoService _IAccInfoService = new AccMasterService();
                    var _allAccInfo = _IAccInfoService.GetAllAccInfo();
                    foreach (var item in _ListLedgerTxnHist)
                    {
                        foreach (var item1 in _allAccInfo)
                        {
                            if (item.SystemAccountNo == item1.SystemAccountNo)
                            {
                                item.WalletAccountNo = item1.WalletAccountNo;
                                break;
                            }
                        }
                    }
                    return _ListLedgerTxnHist.OrderByDescending(x => x.TransectionDate).ThenByDescending(x => x.BatchNo).ThenByDescending(x => x.Sl).ToList();
                }
                return _ListLedgerTxnHist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAccMasterInfoByAccNo
        public AccMaster GetAccMasterInfoByAccNo(AccMaster _AccMaster)
        {
            try
            {
                _AccMaster = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _AccMaster.FromSystemAccountNo
                                                                   || x.WalletAccountNo == _AccMaster.WalletAccountNo
                                                                   || x.SystemAccountNo == _AccMaster.FromSystemAccountNo 
                                                                   && x.AuthStatusId == "A" 
                                                                   && x.LastAction != "DEL");
                return _AccMaster;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAccMasterInfoByAccNo(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region IfAccCrossTheBalanceLimit
        public string IfAccCrossTheBalanceLimit(LedgerMaster _LedgerMaster)
        {
            LedgerMaster Channel_Ledger_Master = new LedgerMaster();
            try
            {
                Channel_Ledger_Master = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == _LedgerMaster.SystemAccountNo && x.AccountTypeId == _LedgerMaster.AccountTypeId);
                
                decimal _AfterTrnBalance = 0;
                if (_LedgerMaster.DefineServiceId == "001" || _LedgerMaster.DefineServiceId == "003")
                {
                    _AfterTrnBalance = Channel_Ledger_Master.ClosingBalance - _LedgerMaster.Amount;
                }
                if (_LedgerMaster.DefineServiceId == "002" || _LedgerMaster.DefineServiceId == "004")
                {
                    _AfterTrnBalance = Channel_Ledger_Master.ClosingBalance + _LedgerMaster.Amount;
                }
                if (_AfterTrnBalance > _LedgerMaster.BalanceLimit)
                {
                    return "asgent has crossed transaction limit";
                }
                else
                {
                    return "true";
                }
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "IfAccCrossTheBalanceLimit(obj)", string.Empty);
                return null;
            }             
        }
        #endregion

        #region GetAllLedgerTxnforTopPerformerMonitoring 
        public List<LedgerTxnHist> GetAllLedgerTxnforTopPerformerMonitoring(LedgerTxn _LedgerTxn)
        {
            try
            {
                List<LedgerTxn> _ListLedgerTxn = new List<LedgerTxn>();
                List<LedgerTxnHist> _ListLedgerTxnHist = new List<LedgerTxnHist>();
                AccMaster obj_AccInfo_SystemAccNo = null;
                obj_AccInfo_SystemAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _LedgerTxn.SystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                if (obj_AccInfo_SystemAccNo != null)
                {
                    if (_LedgerTxn.FromDate != null && _LedgerTxn.ToDate == null)      //10
                    {
                        //DateTime FromDate = Convert.ToDateTime(_LedgerTxn.FromDate);
                        //FromDate = Convert.ToDateTime(FromDate.ToString("dd/MM/yyyy"));
                        _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate >= DbFunctions.TruncateTime(_LedgerTxn.FromDate) &&
                                                                                                 x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                        _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.TransectionDate >= DbFunctions.TruncateTime(_LedgerTxn.FromDate) &&
                                                                                                             x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                    }
                    else if (_LedgerTxn.FromDate == null && _LedgerTxn.ToDate != null) //01
                    {
                        _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate <= DbFunctions.TruncateTime(_LedgerTxn.ToDate) &&
                                                                                                 x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                        _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.TransectionDate <= DbFunctions.TruncateTime(_LedgerTxn.ToDate) &&
                                                                                                             x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                    }
                    else if (_LedgerTxn.FromDate == null && _LedgerTxn.ToDate == null) // 00
                    {
                        _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                        _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                    }
                    else //11
                    {
                        _ListLedgerTxn = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.TransectionDate >= DbFunctions.TruncateTime(_LedgerTxn.FromDate) &&
                                                                                                 x.TransectionDate <= DbFunctions.TruncateTime(_LedgerTxn.ToDate) &&
                                                                                                 x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                        _ListLedgerTxnHist = (List<LedgerTxnHist>)_IUoW.Repository<LedgerTxnHist>().Get(x => x.TransectionDate >= DbFunctions.TruncateTime(_LedgerTxn.FromDate) &&
                                                                                                                            x.TransectionDate <= DbFunctions.TruncateTime(_LedgerTxn.ToDate) &&
                                                                                                                            x.SystemAccountNo == obj_AccInfo_SystemAccNo.SystemAccountNo);
                    }
                    if(_ListLedgerTxn != null)
                    {
                        var Type = AutoMapperCFG.SetListMapping<LedgerTxn, LedgerTxnHist>(_ListLedgerTxn);
                        _ListLedgerTxnHist.AddRange(Type);
                    } 
                }
                if (_ListLedgerTxnHist != null)
                {
                    IAccInfoService _IAccInfoService = new AccMasterService();
                    var _allAccInfo = _IAccInfoService.GetAllAccInfo();
                    foreach (var item in _ListLedgerTxnHist)
                    {
                        foreach (var item1 in _allAccInfo)
                        {
                            if (item.SystemAccountNo == item1.SystemAccountNo)
                            {
                                item.WalletAccountNo = item1.WalletAccountNo;
                                break;
                            }
                        }
                    }
                    return _ListLedgerTxnHist.OrderByDescending(x => x.TransectionDate).ThenByDescending(x => x.BatchNo).ThenByDescending(x => x.Sl).ToList();
                }
                return _ListLedgerTxnHist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertLedgerTxn(IUnitOfWork _IUoW, LedgerTxn _LedgerTxn)
        {
            throw new NotImplementedException();
        }

        public string UpdateClosingBalance(IUnitOfWork _IUoW, LedgerMaster _LedgerMaster)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
