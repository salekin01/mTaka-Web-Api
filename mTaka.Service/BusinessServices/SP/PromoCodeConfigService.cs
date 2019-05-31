using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.SP
{
    public interface IPromoCodeConfigService
    {
        IEnumerable<PromoCodeConfig> GetAllPromoCodeConfig();
        PromoCodeConfig GetPromoCodeConfigById(string _ConfigurationId);
        PromoCodeConfig GetPromoCodeConfigBy(PromoCodeConfig _PromoCodeConfigBy);
        int AddOrUpdatePromoCodeConfig(PromoCodeConfig _PromoCodeConfig);
        int DeletePromoCodeConfig(PromoCodeConfig _PromoCodeConfig);
    }

    public class PromoCodeConfigService : IPromoCodeConfigService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public PromoCodeConfigService()
        {
            _IUoW = new UnitOfWork();
        }

        public PromoCodeConfigService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<PromoCodeConfig> GetAllPromoCodeConfig()
        {
            try
            {
                var AllPromoCodeConfig = _IUoW.mTakaDbQuery().GetAllPromoCodeConfig_LQ().OrderByDescending(x => x.ConfigurationId);
                return AllPromoCodeConfig;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllPromoCodeConfig()", string.Empty);
                return null;
            }
        }

        public PromoCodeConfig GetPromoCodeConfigById(string _ConfigurationId)
        {
            try
            {
                return _IUoW.Repository<PromoCodeConfig>().GetById(_ConfigurationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PromoCodeConfig GetPromoCodeConfigBy(PromoCodeConfig _PromoCodeConfigBy)
        {
            try
            {
                if (_PromoCodeConfigBy == null)
                {
                    return _PromoCodeConfigBy;
                }
                return _IUoW.Repository<PromoCodeConfig>().GetBy(x => x.ConfigurationId == _PromoCodeConfigBy.ConfigurationId &&
                                                                   x.AuthStatusId != "D" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
        #region Edit
        public int AddOrUpdatePromoCodeConfig(PromoCodeConfig _PromoCodeConfig)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                var _IfExistPromoCodeConfig = _IUoW.Repository<PromoCodeConfig>().GetAll();
                if (_IfExistPromoCodeConfig.Count == 0)
                {
                    var _max = _IUoW.Repository<PromoCodeConfig>().GetMaxValue(x => x.ConfigurationId) + 1;
                    _PromoCodeConfig.ConfigurationId = _max.ToString().PadLeft(3, '0');
                    _PromoCodeConfig.AuthStatusId = "A";
                    _PromoCodeConfig.LastAction = "ADD";
                    _PromoCodeConfig.MakeBy = "mTaka";
                    _PromoCodeConfig.MakeDT = System.DateTime.Now;
                    #region Checked True/False
                    if (_PromoCodeConfig.IntroducerControlFlag == "True")
                    {
                        _PromoCodeConfig.IntroducerControlFlag = "1";
                    }
                    else
                    {
                        _PromoCodeConfig.IntroducerControlFlag = "0";
                    }
                    if (_PromoCodeConfig.EmailFlag == "True")
                    {
                        _PromoCodeConfig.EmailFlag = "1";
                    }
                    else
                    {
                        _PromoCodeConfig.EmailFlag = "0";
                    }
                    if (_PromoCodeConfig.SMSFlag == "True")
                    {
                        _PromoCodeConfig.SMSFlag = "1";
                    }
                    else
                    {
                        _PromoCodeConfig.SMSFlag = "0";
                    }
                    #endregion
                    result = _IUoW.Repository<PromoCodeConfig>().Add(_PromoCodeConfig);
                    #region Auth Log
                    if (result == 1)
                    {
                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        _IAuthLogService.AddAuthLog(_IUoW, null, _PromoCodeConfig, "ADD", "0001", _PromoCodeConfig.FunctionId, 1, "PromoCodeConfig", "MTK_SP_PROMO_CODE_CONFIG", "ConfigurationId", _PromoCodeConfig.ConfigurationId, _PromoCodeConfig.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    }
                    #endregion

                    if (result == 1)
                    {
                        _IUoW.Commit();
                    }
                    return result;
                }
                    if(_IfExistPromoCodeConfig.Count != 0)
                    {
                        if (!string.IsNullOrWhiteSpace(_PromoCodeConfig.ConfigurationId))
                        {
                            var _oldPromoCodeConfig = _IUoW.Repository<PromoCodeConfig>().GetBy(x => x.ConfigurationId == _PromoCodeConfig.ConfigurationId);
                            if (_oldPromoCodeConfig != null)
                            {
                                var _oldPromoCodeConfigForLog = ObjectCopier.DeepCopy(_oldPromoCodeConfig);

                                _oldPromoCodeConfig.AuthStatusId = _PromoCodeConfig.AuthStatusId = "U";
                                _oldPromoCodeConfig.LastAction = _PromoCodeConfig.LastAction = "EDT";
                                _oldPromoCodeConfig.LastUpdateDT = _PromoCodeConfig.LastUpdateDT = System.DateTime.Now;
                                _PromoCodeConfig.MakeBy = "mtaka";
                                result = _IUoW.Repository<PromoCodeConfig>().Update(_oldPromoCodeConfig);

                                #region Auth Log
                                if (result == 1)
                                {
                                    _IAuthLogService = new AuthLogService();
                                    long _outMaxSlAuthLogDtl = 0;
                                    _IAuthLogService.AddAuthLog(_IUoW, _oldPromoCodeConfigForLog, _PromoCodeConfig, "EDT", "0001", _PromoCodeConfig.FunctionId, 1, "PromoCodeConfig", "MTK_SP_PROMO_CODE_CONFIG", "ConfigurationId", _PromoCodeConfig.ConfigurationId, _PromoCodeConfig.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                                }
                                #endregion

                                if (result == 1)
                                {
                                    _IUoW.Commit();
                                }
                                return result;
                            }
                        }
                    }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdatePromoCodeConfig(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeletePromoCodeConfig(PromoCodeConfig _PromoCodeConfig)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_PromoCodeConfig.ConfigurationId))
                {
                    IsRecordExist = _IUoW.Repository<PromoCodeConfig>().IsRecordExist(x => x.ConfigurationId == _PromoCodeConfig.ConfigurationId);
                    if (IsRecordExist)
                    {
                        var _oldPromoCodeConfig = _IUoW.Repository<PromoCodeConfig>().GetBy(x => x.ConfigurationId == _PromoCodeConfig.ConfigurationId);
                        var _oldPromoCodeConfigForLog = ObjectCopier.DeepCopy(_oldPromoCodeConfig);

                        _oldPromoCodeConfig.AuthStatusId = _PromoCodeConfig.AuthStatusId = "U";
                        _oldPromoCodeConfig.LastAction = _PromoCodeConfig.LastAction = "DEL";
                        _oldPromoCodeConfig.LastUpdateDT = _PromoCodeConfig.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<PromoCodeConfig>().Update(_oldPromoCodeConfig);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldPromoCodeConfigForLog, _PromoCodeConfig, "DEL", "0001", _PromoCodeConfig.FunctionId, 1, "PromoCodeConfig", "MTK_SP_PROMO_CODE_CONFIG", "ConfigurationId", _PromoCodeConfig.ConfigurationId, _PromoCodeConfig.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<PromoCodeConfig>().Delete(_PromoCodeConfig);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeletePromoCodeConfig(obj)", string.Empty);
                return 0;
            }
        }
        #endregion
    }
}