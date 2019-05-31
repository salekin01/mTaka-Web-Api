using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.USB;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.USB
{
    public interface IUsbReceiveService
    {

        IEnumerable<USBReportingField> GetUsbParam(string _UsbParam);
        IEnumerable<USBReportingField> GetOperatorInfo(USBReportingField _USBReportingField);
        IEnumerable<UsbInqHeader> GetUsbInqHeaderById(string _PvId);
        int SaveUsb(UsbCollection _usbCollection);
        string GetTotalUSBAmount();
        IEnumerable<UsbCollection> DailyBillList(UsbCollection _usbCollection);

        IEnumerable<UsbCollection> DailyDescoCollection();

    }
    public class UsbReceiveService : IUsbReceiveService
    {

        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public UsbReceiveService()
        {
            _IUoW = new UnitOfWork();
        }

        public UsbReceiveService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region GetUsbParam
        public IEnumerable<USBReportingField> GetUsbParam(string _UsbParam)
        {
            try
            {
                var RPTInfo = _IUoW.Repository<USBReportingField>().Get(x => x.DefineServiceId == _UsbParam && x.AuthStatusId == "A" && x.ReportingType == "Input" &&
                                                               x.LastAction != "DEL").OrderByDescending(x => x.ReportingId);
                return RPTInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetProviderRPTInfo()", string.Empty);
                return null;
            }
        }
        #endregion

        #region GetOperatorInfo
        public IEnumerable<USBReportingField> GetOperatorInfo(USBReportingField _USBReportingField)
        {
            try
            {
                var RPTInfo = _IUoW.Repository<USBReportingField>().Get(x => x.DefineServiceId == _USBReportingField.PvId &&
                                                                x.OperatorId == _USBReportingField.OperatorId &&
                                                                x.AuthStatusId == "A" && x.ReportingType == "Input" &&
                                                                x.LastAction != "DEL").OrderByDescending(x => x.ReportingId);
                return RPTInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetProviderRPTInfo()", string.Empty);
                return null;
            }
        }
        #endregion

        #region GetUsbInqHeaderById
        public IEnumerable<UsbInqHeader> GetUsbInqHeaderById(string _PvId)
        {
            try
            {
                if (_PvId != null)
                {
                    var HeaderInfo = _IUoW.Repository<UsbInqHeader>().Get(x => x.ProviderId == _PvId && x.AuthStatusId == "A" &&
                                                                x.LastAction != "DEL").OrderByDescending(x => x.HeaderId);
                    return HeaderInfo;
                }
                return null;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetUsbInqHeaderById(obj)", string.Empty);
                return null;
            }
        }

        #endregion

        #region Save USB
        public int SaveUsb(UsbCollection _usbCollection)
        {
            try
            {
                var AccInfo = _IUoW.Repository<CustomerAccProfile>().GetBy(x => x.WalletAccountNo == _usbCollection.FromSystemAccountNo);

                var SpecialOffer = _IUoW.Repository<SpecialOffers>().GetBy(x => x.AccTypeId == AccInfo.AccTypeId
                                                                 && x.DefineServiceId == _usbCollection.PvId);


                string MainAuthFlag = string.Empty;

                var Accresult = _IUoW.Repository<AccMaster>().Get(a => a.WalletAccountNo == _usbCollection.FromSystemAccountNo).Select(s => s.SystemAccountNo).ToList();
                var sysAccNo = Accresult[0];

                var max = _IUoW.Repository<UsbCollection>().GetMaxValue(x => x.BillSlNo) + 1;
                 
                _usbCollection.BillSlNo = max.ToString().PadLeft(3, '0');
                _usbCollection.MakeDate = System.DateTime.Now;
                _usbCollection.TransDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
                _usbCollection.Paid = "1";
                _usbCollection.MakeBy = "Kabir";
                var Today = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var StartDate = SpecialOffer.StartDate.Value.Date;
                var EndDate = SpecialOffer.EndDate.Value.Date;

                if (Today >= StartDate && Today <= EndDate)
                {
                    _usbCollection.totalPaidAmount = _usbCollection.totalBillAmount - Convert.ToInt32(SpecialOffer.RateAmount);
                }
                else
                {
                    _usbCollection.totalPaidAmount = _usbCollection.totalBillAmount;
                }
                
                var result = _IUoW.Repository<UsbCollection>().Add(_usbCollection);

                #region Auth Log
                if (result == 1)
                {
                    string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetAuthPermissionByFunctionId/" + _usbCollection.FunctionId + "/" + _usbCollection.FunctionName + "?format=json";
                    using (WebClient wc = new WebClient())
                    {
                        TransactionRules OBJ_TransactionRules = new TransactionRules();
                        var json = wc.DownloadString(url);
                        OBJ_TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(json);
                        MainAuthFlag = OBJ_TransactionRules.GetAuthPermissionByFunctionIdResult;
                    }
                    if (MainAuthFlag == "1")
                    {
                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, _usbCollection, "ADD", "0001", _usbCollection.FunctionId, 1, "UsbCollection", "MTK_USB_COLLECTION", "CashInId", _usbCollection.FunctionId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    }
                    if (MainAuthFlag == "1")
                    {
                        _IAuthLogService = new AuthLogService();
                        FTAuthLog _ObjAuthLog = new FTAuthLog();
                        _ObjAuthLog.TableNm = "MTK_USB_COLLECTION";
                        _ObjAuthLog.AuthStatusId = "A";
                        _ObjAuthLog.LastAction = "ADD";
                        _ObjAuthLog.FunctionId = _usbCollection.FunctionId;
                        _ObjAuthLog.TablePkColVal = _usbCollection.BillSlNo;
                        result = _IAuthLogService.SetTableObject_FT<UsbCollection>(_IUoW, _ObjAuthLog, _usbCollection);
                    }
                }
                #endregion

                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch(Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "SaveUSb(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region TotalUSBAmount
        public string GetTotalUSBAmount()
        {
            try
            {

                var _TotalCashOut = _IUoW.mTakaDbQuery().GetTotalUSBAmount_LQ();
                return _TotalCashOut;

            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetSumValue()", string.Empty);
                return null;
            }

        }
        #endregion


        #region DailyCollection
        #region DESCO
        public IEnumerable<UsbCollection> DailyDescoCollection()
        {
            try
            {
                var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var _ListCustomerProfile = _IUoW.Repository<UsbCollection>().Get(x => x.PvId == "006" && x.TransDate == date
                                                                        ).OrderByDescending(x => x.BillSlNo);
                return _ListCustomerProfile;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DailyDescoCollection()", string.Empty);
                return null;
                //throw ex;
            }
        }
        #endregion
        #endregion

        #region DailyBillList
        public IEnumerable<UsbCollection> DailyBillList(UsbCollection _usbCollection)
        {
            try
            {
                //GetSysNo(walletAccNo);
                var walletAccNo = _usbCollection.WalletAccountNo;

                //var Todate = Convert.ToDateTime(_usbCollection.ToDate.ToShortDateString());
                var result = _IUoW.Repository<AccMaster>().Get(a => a.WalletAccountNo == walletAccNo).Select(s => s.SystemAccountNo).ToList();
                var sys = result[0];
                var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                // var _DailyusbCollection = _IUoW.mTakaDbQuery().DailyusbCollection_LQ();
                if (_usbCollection.FormDate != null && _usbCollection.ToDate != null)
                {
                    var FormDate = _usbCollection.FormDate.Value.Date;
                    var Todate = _usbCollection.ToDate.Value.Date;

                    var _DailyusbCollection = _IUoW.Repository<UsbCollection>().Get(x => x.TransDate >= FormDate && x.TransDate <= Todate && x.SysAccNo == sys).Select(s => new UsbCollection { totalPaidAmount = s.totalPaidAmount, TransDate = s.TransDate }).ToList();

                    return _DailyusbCollection;
                }
                else
                {
                    var _DailyusbCollection = _IUoW.Repository<UsbCollection>().Get(x => x.TransDate == date && x.SysAccNo == sys).Select(s => new UsbCollection { totalPaidAmount = s.totalPaidAmount, TransDate = s.TransDate }).ToList();

                    return _DailyusbCollection;
                }

            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DailyusbCollection()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
