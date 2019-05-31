using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.BusinessServices.SP
{
    public interface IAccTypeWiseTargetService
    {
        IEnumerable<AccTypeWiseTarget> GetAllAccTypeWiseTarget();
        AccTypeWiseTarget GetAccTypeWiseTargetById(string _AccTypeWiseTargetId);
        AccTypeWiseTarget GetAccTypeWiseTargetBy(AccTypeWiseTarget _AccTypeWiseTarget);
        int AddAccTypeWiseTarget(AccTypeWiseTarget _AccTypeWiseTarget);
        int UpdateAccTypeWiseTarget(AccTypeWiseTarget _AccTypeWiseTarget);
        int DeleteAccTypeWiseTarget(AccTypeWiseTarget _AccTypeWiseTarget);

        IEnumerable<AccTypeWiseTargetView> GetTargetInfoForGraph(AccTypeWiseTarget _AccTypeWiseTarget);
    }
    public class AccTypeWiseTargetService : IAccTypeWiseTargetService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        AccTypeWiseTarget _AccTypeWiseTarget = null;
        private ICusCategoryService _ICusCategoryService;

        public AccTypeWiseTargetService()
        {
            _IUoW = new UnitOfWork();
        }
        public AccTypeWiseTargetService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<AccTypeWiseTarget> GetAllAccTypeWiseTarget()
        {
            try
            {
                var _ListAccTypeWiseTarget = _IUoW.mTakaDbQuery().AccTypeWiseTarget_LQ();
                //var _DailyBillList = _IUoW.Repository<AccTypeWiseTarget>().Get(x => x.AuthStatusId == "A" &&
                                                                       // x.LastAction != "DEL").OrderByDescending(x => x.TargetSlNo);
                return _ListAccTypeWiseTarget;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllAccTypeWiseTarget()", string.Empty);
                return null;
                //throw ex;
            }
        }
        public AccTypeWiseTarget GetAccTypeWiseTargetBy(AccTypeWiseTarget _AccTypeWiseTarget)
        {
            throw new NotImplementedException();
        }

        public AccTypeWiseTarget GetAccTypeWiseTargetById(string _AccTypeWiseTargetId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Add
        public int AddAccTypeWiseTarget(AccTypeWiseTarget _AccTypeWiseTarget)
        {
            try
            {
                var _max = _IUoW.Repository<AccTypeWiseTarget>().GetMaxValue(x => x.TargetSlNo) + 1;
                _AccTypeWiseTarget.TargetSlNo = _max.ToString().PadLeft(3, '0');
                _AccTypeWiseTarget.AuthStatusId = "U";
                _AccTypeWiseTarget.LastAction = "ADD";
                _AccTypeWiseTarget.MakeDT = System.DateTime.Now;
                _AccTypeWiseTarget.MakeBy = "mtaka";
                var result = _IUoW.Repository<AccTypeWiseTarget>().Add(_AccTypeWiseTarget);

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _AccTypeWiseTarget, "ADD", "0001", _AccTypeWiseTarget.FunctionId, 1, "AccTypeWiseTarget", "MTK_SP_CUS_TYPE", "AccTypeWiseTargetId", _AccTypeWiseTarget.TargetSlNo, _AccTypeWiseTarget.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAccTypeWiseTarget(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateAccTypeWiseTarget(AccTypeWiseTarget _AccTypeWiseTarget)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public int DeleteAccTypeWiseTarget(AccTypeWiseTarget _AccTypeWiseTarget)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetTargetInfoForGraph
        public IEnumerable<AccTypeWiseTargetView> GetTargetInfoForGraph(AccTypeWiseTarget _AccTypeWiseTarget)
        {
            try
            {
                int i = 0;
                List<AccTypeWiseTargetView> UserNameList = new List<AccTypeWiseTargetView>();

                dynamic Actual = _IUoW.mTakaDbQuery().ActualAmount_LQ(_AccTypeWiseTarget);
                if (Actual == null)
                    return null;

                    var _ListAccTypeWiseTarget = _IUoW.Repository<AccTypeWiseTarget>().Get(x => x.AccCategoryId == _AccTypeWiseTarget.AccCategoryId &&
                                                                                        x.AccTypeId == _AccTypeWiseTarget.AccTypeId &&
                                                                                        x.DefineServiceId == _AccTypeWiseTarget.DefineServiceId &&
                                                                                        x.District == _AccTypeWiseTarget.District &&
                                                                                        x.Area == _AccTypeWiseTarget.Area &&
                                                                                        x.CalenderPrdId == _AccTypeWiseTarget.CalenderPrdId &&
                                                                                        x.AuthStatusId == "A" &&
                                                                                        x.LastAction != "DEL").
                                                                                        Select(s => s.Amount).ToList();

                if (_AccTypeWiseTarget.AccTypeId == "004")
                {
                    UserNameList = _IUoW.Repository<CustomerAccProfile>().Get(x => x.PermanentDistrict == _AccTypeWiseTarget.District &&
                                                                       x.AccTypeId==_AccTypeWiseTarget.AccTypeId &&
                                                                       x.PermanentArea == _AccTypeWiseTarget.Area)
                                                                      .Select(s=> new AccTypeWiseTargetView {
                                                                          name = s.UserName,
                                                                          market1 = 1,
                                                                          market2 = Convert.ToInt32(s.PermanentDistrict),
                                                                          target = Convert.ToInt32(_ListAccTypeWiseTarget[0])
                                                                      }).ToList();
                }
                foreach(var element in UserNameList)
                {
                    UserNameList[i].actual = Actual[i];
                    i++;
                }
                return UserNameList;

            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTargetInfoForGraph()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
