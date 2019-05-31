using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.SP
{
    public interface ICusTypeService
    {
        IEnumerable<CusType> GetAllCusType();
        CusType GetCusTypeById(string _CusTypeId);
        CusType GetCusTypeBy(CusType _CusType);
        CusType GetCreateInfoForCusType();
        int AddCusType(CusType _CusType);
        int UpdateCusType(CusType _CusType);
        int DeleteCusType(CusType _CusType);
        IEnumerable<SelectListItem> GetCusTypeForDD();
    }
    public class CusTypeService : ICusTypeService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        CusType _CusType = null;
        private ICusCategoryService _ICusCategoryService;

        public CusTypeService()
        {
            _IUoW = new UnitOfWork();
        }
        public CusTypeService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Fetch
        public IEnumerable<CusType> GetAllCusType()
        {
            try
            {
                //var _ListCusType = _IUoW.Repository<CusType>().Get(x => x.AuthStatusId == "A" &&
                //                                                        x.LastAction != "DEL").OrderByDescending(x => x.CusTypeId);

                var _ListCusType = _IUoW.mTakaDbQuery().GetAllCusType_LQ();
                return _ListCusType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCusType()", string.Empty);
                return null;
                //throw ex;
            }
        }
        public CusType GetCusTypeById(string _CusTypeId)
        {
            try
            {
                return _IUoW.Repository<CusType>().GetById(_CusTypeId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCusTypeById(string)", string.Empty);
                return null;
            }
        }
        public CusType GetCusTypeBy(CusType _CusType)
        {
            try
            {
                if (_CusType == null)
                {
                    return _CusType;
                }
                return _IUoW.Repository<CusType>().GetBy(x => x.CusTypeId == _CusType.CusTypeId &&
                                                              x.AuthStatusId == "A" &&
                                                              x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCusTypeBy(obj)", string.Empty);
                return null;
            }
        }
        public CusType GetCreateInfoForCusType()
        {
            try
            {
                _CusType = new CusType();
                _ICusCategoryService = new CusCategoryService();

                _CusType.CusCategoryDD = _ICusCategoryService.GetCusCategoryForDD();
                return _CusType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCreateInfoForCusType()", string.Empty);
                return null;
                //throw ex;
            }
        }
        #endregion

        #region Add
        public int AddCusType(CusType _CusType)
        {
            try
            {
                var _max = _IUoW.Repository<CusType>().GetMaxValue(x => x.CusTypeId) + 1;
                _CusType.CusTypeId = _max.ToString().PadLeft(3, '0');
                _CusType.AuthStatusId = "U";
                _CusType.LastAction = "ADD";
                _CusType.MakeDT = System.DateTime.Now;
                _CusType.MakeBy = "mtaka";
                var result = _IUoW.Repository<CusType>().Add(_CusType);

                #region Tesing Purpose

                //List<CusType> ListCusType = new List<CusType>();
                //for (int i = 0; i < 3; i++)
                //{
                //    CusType Obj_CusType = new CusType();
                //    Obj_CusType.CusTypeId = (_max++).ToString().PadLeft(3, '0');
                //    Obj_CusType.CusTypeNm = "Test" + i.ToString();
                //    Obj_CusType.CusGroupId = "01";
                //    Obj_CusType.AuthStatusId = "U";
                //    Obj_CusType.LastAction = "ADD";
                //    Obj_CusType.MakeDT = System.DateTime.Now;
                //    Obj_CusType.MakeBy = "mtaka";
                //    ListCusType.Add(Obj_CusType);
                //}
                //var result = _IUoW.Repository<CusType>().AddRange(ListCusType);

                //List<Test> ListTest = new List<Test>();
                //for (int i = 0; i < 5; i++)
                //{
                //    Test Obj_Test = new Test();
                //    Obj_Test.Id = i.ToString();
                //    Obj_Test.Name = "T" + i.ToString();
                //    ListTest.Add(Obj_Test);
                //}
                //_CusType.ListTest = ListTest;
                #endregion

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _CusType, "ADD", "0001", _CusType.FunctionId, 1, "CusType", "MTK_SP_CUS_TYPE", "CusTypeId", _CusType.CusTypeId, _CusType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    //_IAuthLogService.AddAuthLog(_IUoW, null, ListTest, "ADD", "0001", "010101002", 0, "TEST", "ID", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCusType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateCusType(CusType _CusType)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CusType.CusTypeId))
                {
                    IsRecordExist = _IUoW.Repository<CusType>().IsRecordExist(x => x.CusTypeId == _CusType.CusTypeId);
                    if (IsRecordExist)
                    {
                        var _oldCusType = _IUoW.Repository<CusType>().GetBy(x => x.CusTypeId == _CusType.CusTypeId);
                        var _oldCusTypeForLog = ObjectCopier.DeepCopy(_oldCusType);

                        _oldCusType.AuthStatusId = _CusType.AuthStatusId = "U";
                        _oldCusType.LastAction = _CusType.LastAction = "EDT";
                        _oldCusType.LastUpdateDT = _CusType.LastUpdateDT = System.DateTime.Now;
                        _CusType.MakeBy = "mtaka";
                        result = _IUoW.Repository<CusType>().Update(_oldCusType);

                        #region Testing Purpose

                        //List<Test> ListTest = new List<Test>();
                        //for (int i = 0; i < 5; i++)
                        //{
                        //    Test Obj_Test = new Test();
                        //    Obj_Test.Id = i.ToString();
                        //    Obj_Test.Name = "T" + i.ToString();
                        //    ListTest.Add(Obj_Test);
                        //}
                        //_CusType.ListTest = ListTest;

                        //List<Test> ListTest1 = new List<Test>();
                        //for (int i = 0; i < 5; i++)
                        //{
                        //    Test Obj_Test = new Test();
                        //    Obj_Test.Id = i.ToString();
                        //    Obj_Test.Name = "T" + (i + 10).ToString();
                        //    ListTest1.Add(Obj_Test);
                        //}
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCusTypeForLog, _CusType, "EDT", "0001", _CusType.FunctionId, 1, "CusType", "MTK_SP_CUS_TYPE", "CusTypeId", _CusType.CusTypeId, _CusType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                            //_IAuthLogService.AddAuthLog(_IUoW, ListTest1, ListTest, "EDT", "0001", "010101002", 0, "TEST", "Id", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateCusType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteCusType(CusType _CusType)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CusType.CusTypeId))
                {
                    IsRecordExist = _IUoW.Repository<CusType>().IsRecordExist(x => x.CusTypeId == _CusType.CusTypeId);
                    if (IsRecordExist)
                    {
                        var _oldCusType = _IUoW.Repository<CusType>().GetBy(x => x.CusTypeId == _CusType.CusTypeId);
                        var _oldCusTypeForLog = ObjectCopier.DeepCopy(_oldCusType);

                        _oldCusType.AuthStatusId = _CusType.AuthStatusId = "U";
                        _oldCusType.LastAction = _CusType.LastAction = "DEL";
                        _oldCusType.LastUpdateDT = _CusType.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<CusType>().Update(_oldCusType);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCusTypeForLog, _CusType, "DEL", "0001", _CusType.FunctionId, 1, "CusType", "MTK_SP_CUS_TYPE", "CusTypeId", _CusType.CusTypeId, _CusType.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<CusType>().Delete(_CusType);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteCusType(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Dropdown
        public IEnumerable<SelectListItem> GetCusTypeForDD()
        {
            try
            {
                var List_AccType = _IUoW.Repository<CusType>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.CusTypeId, n.CusTypeNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_AccType)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CusTypeId,
                        Text = element.CusTypeNm
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
    }
}
