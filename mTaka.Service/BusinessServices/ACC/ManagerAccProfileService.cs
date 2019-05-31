using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.BusinessServices.SP;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.ACC
{
    public interface IManagerProfileService
    {
        //IEnumerable<ManagerAccProfile> GetAllManager();
        List<ManagerAccProfile> GetAllManagerAccProfile();
        ManagerAccProfile GetManagerById(string _ManagerId);
        ManagerAccProfile GetManagerBy(ManagerAccProfile _Manager);
        int AddManager(ManagerAccProfile _Manager);
        int UpdateManager(ManagerAccProfile _Manager);
        int DeleteManager(ManagerAccProfile _Manager);

        IEnumerable<SelectListItem> GetManagerForDD();
    }
    public class ManagerAccProfileService:IManagerProfileService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        private AccMaster _AccInfo = null;
        ErrorLogService _ObjErrorLogService = null;
        public ManagerAccProfileService()
        {
            _IUoW = new UnitOfWork();
        }
        public ManagerAccProfileService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        //public IEnumerable<ManagerAccProfile> GetAllManager()
        //{
        //    try
        //    {
        //        var AllManagerAccProfile = _IUoW.Repository<ManagerAccProfile>().Get(x => x.AuthStatusId == "A" &&
        //                                                       x.LastAction != "DEL").OrderByDescending(x => x.ManId);
        //        return AllManagerAccProfile;
        //    }
        //    catch (Exception ex)
        //    {
        //        _ObjErrorLogService = new ErrorLogService();
        //        _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllManager()", string.Empty);
        //        return null;
        //    }
        //}
        public List<ManagerAccProfile> GetAllManagerAccProfile()
        {
            try
            {
                List<ManagerAccProfile> OBJ_LIST_ManagerAccProfile = new List<ManagerAccProfile>();
                var _ListManagerAccProfile = _IUoW.Repository<ManagerAccProfile>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.ManId);
                foreach (var item in _ListManagerAccProfile)
                {
                    ManagerAccProfile OBJ_ManagerAccProfile = new ManagerAccProfile();
                    ManagerAccProfileService OBJ_ManagerAccProfileService = new ManagerAccProfileService();
                    AccCategoryService OBJ_AccCategoryService = new AccCategoryService();
                    ManagerType OBJ_ManagerType = new ManagerType();
                    CustomerAccProfileService OBJ_CustomerAccProfileService = new CustomerAccProfileService();
                    AccStatusSetupService OBJ_AccStatusSetupService = new AccStatusSetupService();
                    ManagerTypeService OBJ_ManagerTypeService = new ManagerTypeService();
                    ManagerAccProfileService OBJ_ManagerProfileService = new ManagerAccProfileService();

                    OBJ_ManagerAccProfile.ManId = item.ManId;
                    OBJ_ManagerAccProfile.ManType = item.ManType;
                    foreach (var item1 in OBJ_ManagerTypeService.GetManagerTypeForDD())
                    {
                        if (item1.Value == OBJ_ManagerAccProfile.ManType)
                        {
                            OBJ_ManagerAccProfile.ManagerTypeNm = item1.Text;
                        }
                    }                    
                    OBJ_ManagerAccProfile.ManNm = item.ManNm;
                    OBJ_ManagerAccProfile.WalletAccountNo = item.WalletAccountNo;
                    OBJ_ManagerAccProfile.AuthStatusId = item.AuthStatusId;
                    OBJ_ManagerAccProfile.LastAction = item.LastAction;
                    OBJ_ManagerAccProfile.LastUpdateDT = item.LastUpdateDT;
                    OBJ_ManagerAccProfile.MakeBy = item.MakeBy;
                    OBJ_ManagerAccProfile.MakeDT = item.MakeDT;
                    OBJ_LIST_ManagerAccProfile.Add(OBJ_ManagerAccProfile);
                }
                return OBJ_LIST_ManagerAccProfile;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllManagerAccProfile()", string.Empty);
                throw ex;
            }
        }

        public ManagerAccProfile GetManagerById(string _ManagerId)
        {
            try
            {
                return _IUoW.Repository<ManagerAccProfile>().GetById(_ManagerId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetManagerById(string)", string.Empty);
                return null;
            }
        }

        public ManagerAccProfile GetManagerBy(ManagerAccProfile _Manager)
        {
            try
            {
                if (_Manager == null)
                {
                    return _Manager;
                }
                return _IUoW.Repository<ManagerAccProfile>().GetBy(x => x.ManId == _Manager.ManId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddManager(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddManager(ManagerAccProfile _Manager)
        {
            try
            {
                string MonitoringId = "1";
                var _max = _IUoW.Repository<ManagerAccProfile>().GetMaxValue(x => x.ManId);
                if (_max > 0)
                    _Manager.ManId = (_max + 1).ToString();
                else
                    _Manager.ManId = MonitoringId + (_max + 1).ToString().PadLeft(8, '0');


                _Manager.ManagerSystemAccount = Guid.NewGuid().ToString();
                if (_Manager.sameAsPresent == "True")
                {
                    _Manager.AuthStatusId = "A";
                    _Manager.LastAction = "ADD";
                    _Manager.MakeBy = "mTaka";
                    _Manager.MakeDT = System.DateTime.Now;
                    var tempDob = Convert.ToDateTime(_Manager.ManDOB.ToShortDateString());
                    var tempDoj = Convert.ToDateTime(_Manager.ManDOJ.ToShortDateString());
                    _Manager.ManDOB = tempDob.Date;
                    _Manager.ManDOJ = tempDoj.Date;
                    _Manager.ManagerAccType = "005";
                    _Manager.ManPermanentAddress1 = _Manager.ManPresentAddress1;
                    _Manager.ManPermanentAddress2 = _Manager.ManPresentAddress2;
                    _Manager.ManPermanentCity = _Manager.ManPresentCity;
                    _Manager.ManPermanentCountry = _Manager.ManPresentCountry;
                    _Manager.ManPermanentDistrict = _Manager.ManPresentDistrict;
                    _Manager.ManPermanentPhone = _Manager.ManPresentPhone;
                    _Manager.ManPermanentArea = _Manager.ManPresentArea;
                    _Manager.ManPermanentThana = _Manager.ManPresentThana;
                    _Manager.ManagerAccStatus="001";
                }
                else
                {
                    _Manager.AuthStatusId = "A";
                    _Manager.LastAction = "ADD";
                    _Manager.MakeBy = "mTaka";
                    _Manager.MakeDT = System.DateTime.Now;
                    _Manager.ManagerAccType = "005";
                }
                
                var result = _IUoW.Repository<ManagerAccProfile>().Add(_Manager);


                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _Manager, "ADD", "0001", _Manager.FunctionId, 1, "ManagerAccProfile", "MTK_ACC_MANAGER_PROFILE", "ManId", _Manager.ManId, _Manager.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                }
                #endregion

                #region Data Store in Account Info
                if (result == 1)
                {
                    _AccInfo = new AccMaster();
                    var _maxAccInfoId = _IUoW.Repository<AccMaster>().GetMaxValue(x => x.AccountId) + 1;
                    _AccInfo.AccountId = _maxAccInfoId.ToString().PadLeft(3, '0');
                    //_AccInfo.AccProfileId = _Manager.ManId;
                    _AccInfo.WalletAccountNo = _Manager.WalletAccountNo;
                    _AccInfo.SystemAccountNo = _Manager.ManagerSystemAccount;
                    _AccInfo.AccNm = _Manager.ManNm;
                    _AccInfo.AccTypeId = _Manager.ManagerAccType;
                    _AccInfo.TransDT = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    _AccInfo.AccountStatusId = "001";
                    _AccInfo.AuthStatusId = "U";
                    _AccInfo.LastAction = "ADD";
                    _AccInfo.MakeDT = System.DateTime.Now;
                    _AccInfo.MakeBy = "mTaka";

                    _IUoW.Repository<AccMaster>().Add(_AccInfo);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddManager(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateManager(ManagerAccProfile _Manager)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_Manager.ManId))
                {
                    IsRecordExist = _IUoW.Repository<ManagerAccProfile>().IsRecordExist(x => x.ManId == _Manager.ManId);
                    if (IsRecordExist)
                    {
                        var _oldManagerAccProfile = _IUoW.Repository<ManagerAccProfile>().GetBy(x => x.ManId == _Manager.ManId);
                        var _oldManagerAccProfileForLog = ObjectCopier.DeepCopy(_oldManagerAccProfile);

                        _oldManagerAccProfile.AuthStatusId = _Manager.AuthStatusId = "U";
                        _oldManagerAccProfile.LastAction = _Manager.LastAction = "EDT";
                        _oldManagerAccProfile.LastUpdateDT = _Manager.LastUpdateDT = System.DateTime.Now;
                        _Manager.MakeBy = "mtaka";
                        result = _IUoW.Repository<ManagerAccProfile>().Update(_oldManagerAccProfile);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldManagerAccProfileForLog, _Manager, "EDT", "0001", _Manager.FunctionId, 1, "ManagerAccProfile", "MTK_AM_MANAGER_PROFILE", "ManId", _Manager.ManId, _Manager.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateManager(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteManager(ManagerAccProfile _Manager)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_Manager.ManId))
                {
                    IsRecordExist = _IUoW.Repository<ManagerAccProfile>().IsRecordExist(x => x.ManId == _Manager.ManId);
                    if (IsRecordExist)
                    {
                        var _oldManType = _IUoW.Repository<ManagerAccProfile>().GetBy(x => x.ManId == _Manager.ManId);
                        var _oldManTypeForLog = ObjectCopier.DeepCopy(_oldManType);

                        _oldManType.AuthStatusId = _Manager.AuthStatusId = "U";
                        _oldManType.LastAction = _Manager.LastAction = "DEL";
                        _oldManType.LastUpdateDT = _Manager.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<ManagerAccProfile>().Update(_oldManType);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldManTypeForLog, _Manager, "DEL", "0001", _Manager.FunctionId, 1, "ManagerAccProfile", "MTK_ACC_MANAGER_PROFILE", "ManTypeId", _Manager.ManId, _Manager.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteManager(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region DropDown
        public IEnumerable<SelectListItem> GetManagerForDD()
        {
            try
            {
                var List_Manager = _IUoW.Repository<ManagerAccProfile>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.ManId, n.ManNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Manager)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.ManId,
                        Text = element.ManNm
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    return null;
                //throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetManagerForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
