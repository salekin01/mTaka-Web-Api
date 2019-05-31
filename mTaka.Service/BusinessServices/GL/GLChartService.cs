using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.GL;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.GL
{
   
    public interface IGLChartService
    {
        IEnumerable<GLChart> GetAllGLChart();
        GLChart GetGLChartByAccSl(string _GLAccSl);
        GLChart GetGLChartByAccNo(string _GLAccNo);
        GLChart GetGLChartBy(GLChart _GLChart);
        int AddGLChart(GLChart _GLChart);
        int UpdateGLChart(GLChart _GLChart);
        int DeleteGLChart(GLChart _GLChart);
        IEnumerable<SelectListItem> GetTotalingAccForDD(int level, string prefix);
        IEnumerable<SelectListItem> GetGLAccForDD();
        IEnumerable<SelectListItem> GetApplPrefixForDD();
        IEnumerable<SelectListItem> GetGLLevelForDD();
  
    }
    public class GLChartService : IGLChartService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;


        public GLChartService()
        {
            _IUoW = new UnitOfWork();
           
        }
        public GLChartService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Fetch


        public IEnumerable<GLChart> GetAllGLChart()
        {
            try
            {
                return _IUoW.Repository<GLChart>().Get(x => x.AuthStatusId == "A" &&
                                                               x.LastAction != "DEL").OrderByDescending(x => x.GLAccSl);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllGLChart()", string.Empty);
                return null;
            }
        }

        public GLChart GetGLChartBy(GLChart _GLChart)
        {
            try
            {
                if (_GLChart == null)
                {
                    return _GLChart;
                }
                return _IUoW.Repository<GLChart>().GetBy(x => x.GLAccSl == _GLChart.GLAccSl &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetGLChartBy(obj)", string.Empty);
                return null;
            }
        }

        public GLChart GetGLChartByAccSl(string _GLAccSl)
        {
            try
            {
                return _IUoW.Repository<GLChart>().GetById(_GLAccSl);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetGLChartByAccSl(string)", string.Empty);
                return null;
            }
        }
        public GLChart GetGLChartByAccNo(string _GLAccNo)
        {
            try
            {
                return _IUoW.Repository<GLChart>().GetBy(x => x.GLAccNo == _GLAccNo);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetGLChartByAccSl(string)", string.Empty);
                return null;
            }
        }

        #endregion
        #region Add
        public int AddGLChart(GLChart _GLChart)
        {
            try
            {
                int result = 0;               
                _GLChart.GLAccSl = _IUoW.mTakaDbQuery().MaxGLAccSL(_GLChart.GLPrefix).ToString();
                _GLChart.GLAccNo = _GLChart.GLPrefix + _GLChart.GLAccNo;
                _GLChart.OpeningDate = Convert.ToDateTime(_GLChart.OpeningDate.ToShortDateString()).Date.AddDays(1);
                _GLChart.GLType = _GLChart.GLType.Substring(0, 1);
                _GLChart.AuthStatusId = "U";
                _GLChart.LastAction = "ADD";
                _GLChart.MakeDT = System.DateTime.Now;
                _GLChart.MakeBy = "mtaka";
                result = _IUoW.Repository<GLChart>().Add(_GLChart);

                if (result != 1)
                    return result;

                var _GLMaster = AutoMapperCFG.SetObjectMapping<GLChart, GLMaster>(_GLChart);
                List<GLMaster> _ListGLMaster = new List<GLMaster>();
                List<BranchInfo> _ListBranch = _IUoW.Repository<BranchInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderBy(x => x.BranchId).ToList();
                var _maxSl = _IUoW.Repository<GLMaster>().GetMaxValue(x => x.Sl) + 1;

                for (int i = 0; i < _ListBranch.Count(); i++)
                {
                    _GLMaster.Sl = (_maxSl++).ToString();
                    _GLMaster.BranchId = _ListBranch[i].BranchId;
                    GLMaster _GLMasterTemp = ObjectCopier.DeepCopy(_GLMaster);
                    
                    _ListGLMaster.Add(_GLMasterTemp);
                }
                result = _IUoW.Repository<GLMaster>().AddRange(_ListGLMaster);



                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _GLChart, "ADD", "0001", "090102017", 1, "GLChart", "MTK_GL_CHART", "GLAccSl", _GLChart.GLAccSl, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    if (result == 1)
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, _ListGLMaster, "ADD", "0001", "090102017", 0, "GLMaster", "MTK_GL_MASTER", "Sl", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddGLChart(obj)", string.Empty);
                return 0;
            }
        }
        #endregion
        #region Edit
        public int UpdateGLChart(GLChart _GLChart)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_GLChart.GLAccSl))
                {
                    IsRecordExist = _IUoW.Repository<GLChart>().IsRecordExist(x => x.GLAccSl == _GLChart.GLAccSl);
                    if (IsRecordExist)
                    {
                        var _oldAccStatusSetup = _IUoW.Repository<GLChart>().GetBy(x => x.GLAccSl == _GLChart.GLAccSl);
                        var _oldAccStatusSetupForLog = ObjectCopier.DeepCopy(_oldAccStatusSetup);

                        _oldAccStatusSetup.AuthStatusId = _GLChart.AuthStatusId = "U";
                        _oldAccStatusSetup.LastAction = _GLChart.LastAction = "EDT";
                        _oldAccStatusSetup.LastUpdateDT = _GLChart.LastUpdateDT = System.DateTime.Now;
                        _GLChart.MakeBy = "mtaka";
                        result = _IUoW.Repository<GLChart>().Update(_oldAccStatusSetup);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldAccStatusSetupForLog, _GLChart, "EDT", "0001", "090102007", 1, "GLChart", "MTK_GL_CHART", "GLAccSl", _GLChart.GLAccSl, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateAccStatusSetup(obj)", string.Empty);
                return 0;
            }
        }
        #endregion
        #region Delete
        public int DeleteGLChart(GLChart _GLChart)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_GLChart.GLAccSl))
                {
                    IsRecordExist = _IUoW.Repository<GLChart>().IsRecordExist(x => x.GLAccSl == _GLChart.GLAccSl);
                    if (IsRecordExist)
                    {
                        var _oldAccStatusSetup = _IUoW.Repository<GLChart>().GetBy(x => x.GLAccSl == _GLChart.GLAccSl);
                        var _oldAccStatusSetupForLog = ObjectCopier.DeepCopy(_oldAccStatusSetup);

                        _oldAccStatusSetup.AuthStatusId = _GLChart.AuthStatusId = "U";
                        _oldAccStatusSetup.LastAction = _GLChart.LastAction = "DEL";
                        _oldAccStatusSetup.LastUpdateDT = _GLChart.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<GLChart>().Update(_oldAccStatusSetup);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldAccStatusSetupForLog, _GLChart, "DEL", "0001", "090102007", 1, "GLChart", "MTK_GL_CHART", "GLAccSl", _GLChart.GLAccSl, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteAccStatusSetup(obj)", string.Empty);
                return 0;
            }
        }
        #endregion
        #region For Dropdown
        public IEnumerable<SelectListItem> GetTotalingAccForDD(int level,string prefix)
        {
            try
            {
                var selectList = new List<SelectListItem>();

               if (level>1)
                {
                    level -= 1;
                    var List_GLChart = _IUoW.Repository<GLChart>().GetBy(x => x.AuthStatusId == "A" &&
                                                                           x.LastAction != "DEL" && x.GLLevel == level && x.Postable == 0 && x.GLPrefix == prefix, n => new { n.GLAccSl, n.GLAccNo, n.GLAccName });

                    foreach (var element in List_GLChart)
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = element.GLAccSl,
                            Text = element.GLAccNo + " - " + element.GLAccName
                        });
                    }

                   
                }
               else if ( prefix == "902" || prefix == "904")
                {
                  
                    string glType = prefix == "902" ? "A" : "L";

                    var List_GLChart = _IUoW.Repository<GLChart>().GetBy(x => x.AuthStatusId == "A" &&
                                                                            x.LastAction != "DEL" && x.GLLevel == level && x.Postable == 0 && x.GLType== glType, n => new { n.GLAccSl, n.GLAccNo, n.GLAccName });
                    foreach (var element in List_GLChart)
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = element.GLAccSl,
                            Text = element.GLAccNo + " - " + element.GLAccName
                        });
                    }

                }
               
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTotalingAccForDD()", string.Empty);
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetGLAccForDD()
        {
            try
            {
                var List_GLChart = _IUoW.Repository<GLChart>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL" , n => new { n.GLAccSl, n.GLAccNo, n.GLAccName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_GLChart)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.GLAccSl,
                        Text = element.GLAccNo + " - " + element.GLAccName
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetGLAccForDD()", string.Empty);
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetApplPrefixForDD()
        {
            try
            {
                var List_ApplPrefix = _IUoW.Repository<ApplPrefix>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL" && x.ApplType=="GL", n => new { n.APPLStartProfix, n.APPLName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_ApplPrefix)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.APPLStartProfix,
                        Text = element.APPLName 
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetApplPrefixForDD()", string.Empty);
                return null;
            }
        }
        public IEnumerable<SelectListItem> GetGLLevelForDD()
        {
            try
            {
                var List_GLLevel = _IUoW.Repository<GLLevel>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL" , n => new { n.GLLevelSL, n.GLLevelLth }).OrderBy(x=>x.GLLevelSL);
                var selectList = new List<SelectListItem>();
                foreach (var element in List_GLLevel)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.GLLevelSL,
                        Text = element.GLLevelSL + " - " + element.GLLevelLth
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetApplPrefixForDD()", string.Empty);
                return null;
            }
        }

     
        #endregion

    }
}
