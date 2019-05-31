using mTaka.Data.BusinessEntities.USB;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.USB
{
    public interface IUsbParamService
    {
        IEnumerable<UsbParam> GetAllUsbParam();
        int AddUsbParam(UsbParam _UsbParam);
        int UpdateUsbParam(UsbParam _UsbParam);
        int DeleteUsbParam(UsbParam _UsbParam);
        IEnumerable<SelectListItem> GetAllProviderForDD();
        
        IEnumerable<UsbParam> GetAPI(string _usbParam);

    }
    public class UsbParamService : IUsbParamService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        private UsbParamConfig _UsbConfig = null;
        private UsbParamConfig _UsbConfig2 = null;
        ErrorLogService _ObjErrorLogService = null;

        //UsbParam _UsbParam = null;
        //private ICusCategoryService _ICusCategoryService;

        public UsbParamService()
        {
            _IUoW = new UnitOfWork();
        }
        public UsbParamService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region index
        public IEnumerable<UsbParam> GetAllUsbParam()
        {
            try
            {
                var AllUsbParam = _IUoW.Repository<UsbParam>().Get(x => x.AuthStatusId == "A" &&
                                                               x.LastAction != "DEL").OrderByDescending(x => x.PvId);
                return AllUsbParam;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllUsbParam()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddUsbParam(UsbParam _UsbParam)
        {

            var result=0;
            var _maxConfig = _IUoW.Repository<UsbParam>().GetMaxValue(x => x.PvSL) + 1;
            try
            {
               
                    var _max = _IUoW.Repository<UsbParam>().GetMaxValue(x => x.PvSL) + 1;
                    _UsbParam.PvSL = _max.ToString().PadLeft(3, '0');
                    _UsbParam.AuthStatusId = "U";
                    _UsbParam.LastAction = "ADD";
                    _UsbParam.MakeDT = System.DateTime.Now;
                    _UsbParam.MakeBy = "mtaka";
                     result = _IUoW.Repository<UsbParam>().Add(_UsbParam);

                //if (result==1)
                //{
                //    _UsbConfig = new UsbParamConfig();
                //    _UsbConfig.ConfigId = _maxConfig.ToString().PadLeft(3, '0');
                //    _UsbConfig.PvId = _UsbParam.PvId;
                //    _UsbConfig.FieldName = _UsbParam.FieldName;
                //    _UsbConfig.InputType = _UsbParam.InputType;
                //    _UsbConfig.FieldType = _UsbParam.FieldType;
                //    _UsbConfig.FieldLength = _UsbParam.FieldLength;
                //    _UsbConfig.FieldPrefix = _UsbParam.FieldPrefix;
                //    _UsbConfig.FieldSuffix = _UsbParam.FieldSuffix;
                //    _UsbConfig.UserAssist = _UsbParam.UserAssist;
                //    _UsbConfig.UserAssistlength = _UsbParam.UserAssistLength;
                //    _UsbConfig.AuthStatusId = "U";
                //    _UsbConfig.LastAction = "ADD";
                //    _UsbConfig.MakeDT= System.DateTime.Now;
                //    _UsbConfig.MakeBy = "mTaka(K)";

                //    result =_IUoW.Repository<UsbParamConfig>().Add(_UsbConfig);
                //}

                if (result == 1)
                {
                    _IUoW.Commit();
                }

                //if (_UsbParam.BillIDName != null)
                //{
                //     var temp = _maxConfig + 1;
                //    _UsbConfig = new UsbParamConfig();
                //    _UsbConfig.ConfigId = (temp).ToString().PadLeft(3, '0');
                //    _UsbConfig.PvId = _UsbParam.PvId;
                //    _UsbConfig.FieldName = _UsbParam.BillIDName;
                //    _UsbConfig.FieldType = _UsbParam.BillingCodeType;
                //    _UsbConfig.FieldLength = _UsbParam.BillingCodeLength;
                //    _UsbConfig.FieldPrefix = _UsbParam.MonthlyBill;
                //    _UsbConfig.UserAssist = _UsbParam.UserAssistForBill;
                //    _UsbConfig.UserAssistlength = _UsbParam.UserAssistForBillLength;
                //    _UsbConfig.AuthStatusId = "U";
                //    _UsbConfig.LastAction = "ADD";
                //    _UsbConfig.MakeDT = System.DateTime.Now;
                //    _UsbConfig.MakeBy = "mTaka(K)";
                //    _IUoW.Repository<UsbParamConfig>().Add(_UsbConfig);
                //    if (result == 1)
                //    {
                //        _IUoW.Commit();
                //    }

                //}
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddUsbParam(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Update
        public int UpdateUsbParam(UsbParam _UsbParam)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_UsbParam.PvId))
                {
                    IsRecordExist = _IUoW.Repository<UsbParam>().IsRecordExist(x => x.PvId == _UsbParam.PvId);
                    if (IsRecordExist)
                    {
                        var _oldUsbParam = _IUoW.Repository<UsbParam>().GetBy(x => x.PvId == _UsbParam.PvId);
                        var _oldUsbParamForLog = ObjectCopier.DeepCopy(_oldUsbParam);

                        _oldUsbParam.AuthStatusId = _UsbParam.AuthStatusId = "U";
                        _oldUsbParam.LastAction = _UsbParam.LastAction = "EDT";
                        _oldUsbParam.LastUpdateDT = _UsbParam.LastUpdateDT = System.DateTime.Now;
                        _UsbParam.MakeBy = "mtaka";
                        result = _IUoW.Repository<UsbParam>().Update(_oldUsbParam);

                        //#region Auth Log
                        //if (result == 1)
                        //{
                        //    _IAuthLogService = new AuthLogService();
                        //    return 1;
                        //    //long _outMaxSlAuthLogDtl = 0;
                        //    //_IAuthLogService.AddAuthLog(_IUoW, _oldUsbParamForLog, _UsbParam, "EDT", "0001", "090102006", 1, "MTK_SP_MANAGER_TYPE", "PvId", _UsbParam.PvId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        //    //_IAuthLogService.AddAuthLog(_IUoW, ListTest1, ListTest, "EDT", "0001", "010101002", 0, "TEST", "Id", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        //}
                        //#endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateUsbParam(obj)", string.Empty);
                return 0;
            }
        }

        #endregion

        #region Delete
        public int DeleteUsbParam(UsbParam _UsbParam)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region DropDown
        public IEnumerable<SelectListItem> GetAllProviderForDD()
        {
            try
            {
                var List_AccType = _IUoW.Repository<UsbParam>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.PvId, n.PvName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_AccType)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.PvId,
                        Text = element.PvName
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAPI
        public IEnumerable<UsbParam> GetAPI(string _usbParam)
        {
            try
            {
                if (_usbParam != null)
                {
                    var HeaderInfo = _IUoW.Repository<UsbParam>().Get(x => x.PvId == _usbParam && x.AuthStatusId == "A" &&
                                                                x.LastAction != "DEL").OrderByDescending(x => x.PvSL);
                    return HeaderInfo;
                }
                return null;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAPI(obj)", string.Empty);
                return null;
            }
        }
        #endregion

    }
}
