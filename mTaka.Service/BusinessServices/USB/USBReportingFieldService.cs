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

namespace mTaka.Service.BusinessServices.USB
{
    public interface IUSBReportingFieldService
    {
        IEnumerable<USBReportingField> GetAllUSBReportingField();
        int AddUSBReportingField(USBReportingField _USBReportingField);
        int UpdateUSBReportingField(USBReportingField _USBReportingField);
        IEnumerable<USBReportingField> GetProviderRPTInfo(string DefineServiceId);

        IEnumerable<USBReportingField> GetUSBReportingField(string _USBReportingField);
    }
    public class USBReportingFieldService : IUSBReportingFieldService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        public USBReportingFieldService()
        {
            _IUoW = new UnitOfWork();
        }
        public USBReportingFieldService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<USBReportingField> GetAllUSBReportingField()
        {
            try
            {
                var ProviderNameList = _IUoW.mTakaDbQuery().GetAllProviderName_LQ();
                return ProviderNameList;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllUSBReportingField()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddUSBReportingField(USBReportingField _USBReportingField)
        {
            try
            {
                var _max = _IUoW.Repository<USBReportingField>().GetMaxValue(x => x.ReportingId) + 1;
                _USBReportingField.ReportingId = _max.ToString().PadLeft(3, '0');
                _USBReportingField.AuthStatusId = "U";
                _USBReportingField.LastAction = "ADD";
                _USBReportingField.MakeDT = System.DateTime.Now;
                _USBReportingField.MakeBy = "mtaka";
                var result = _IUoW.Repository<USBReportingField>().Add(_USBReportingField);

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    result = 1;
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddUSBReportingField(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateUSBReportingField(USBReportingField _USBReportingField)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_USBReportingField.ReportingId))
                {
                    IsRecordExist = _IUoW.Repository<USBReportingField>().IsRecordExist(x => x.ReportingId == _USBReportingField.ReportingId);
                    if (IsRecordExist)
                    {
                        var _oldUSBReportingField = _IUoW.Repository<USBReportingField>().GetBy(x => x.ReportingId == _USBReportingField.ReportingId);
                        var _oldUSBReportingFieldForLog = ObjectCopier.DeepCopy(_oldUSBReportingField);

                        _oldUSBReportingField.AuthStatusId = _USBReportingField.AuthStatusId = "U";
                        _oldUSBReportingField.LastAction = _USBReportingField.LastAction = "EDT";
                        _oldUSBReportingField.LastUpdateDT = _USBReportingField.LastUpdateDT = System.DateTime.Now;
                        _USBReportingField.MakeBy = "mtaka";
                        result = _IUoW.Repository<USBReportingField>().Update(_oldUSBReportingField);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldUSBReportingFieldForLog, _USBReportingField, "EDT", "0001", "090102015", 1, "USBReportingField", "MTK_USB_REPORTING_FIELD", "ReportingId", _USBReportingField.ReportingId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateUSBReportingField(obj)", string.Empty);
                return 0;
            }

        }
        #endregion

        #region Get Reporting Info for Dynamic HTML
        public IEnumerable<USBReportingField> GetProviderRPTInfo(string DefineServiceId)
        {
            try
            {
                var RPTInfo = _IUoW.Repository<USBReportingField>().Get(x => x.DefineServiceId == DefineServiceId && x.AuthStatusId=="A" && x.ReportingType == "Output" &&
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

        #region Get Reporting Info According to specific Provider
        public IEnumerable<USBReportingField> GetUSBReportingField(string _USBReportingField)
        {
            try
            {
                var ProviderNameList = _IUoW.mTakaDbQuery().GetAllProviderNameForIndex_LQ(_USBReportingField);
                return ProviderNameList;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetUSBReportingField()", string.Empty);
                return null;
            }
        }
        #endregion

    }
}



