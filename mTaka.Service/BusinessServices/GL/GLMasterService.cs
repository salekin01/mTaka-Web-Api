using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.GL;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.GL
{
    public interface IGLMasterService
    {        
        int UpdateGLBalanceLCYandCCY(IUnitOfWork _IUoW, GLMaster _GLMaster);
    }
    public class GLMasterService : IGLMasterService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public GLMasterService()
        {
            _IUoW = new UnitOfWork();
        }
        public GLMasterService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }
        
        #region UpdateGLBalanceLCYandCCY
        public int UpdateGLBalanceLCYandCCY(IUnitOfWork _IUoW, GLMaster _GLMaster)
        {
            int result = 0;
            int TracerNo = 0;
            int BatchNo = 0;
            List<TransGL> List_Obj_TransGL = new List<TransGL>();
            try
            {
                var MaxObj_TransGL = _IUoW.Repository<TransGL>().GetAll().OrderByDescending(x => int.Parse(x.BatchNo)).ThenByDescending(x => int.Parse(x.TracerNo)).FirstOrDefault();
                if (MaxObj_TransGL == null)
                {
                    BatchNo = BatchNo + 1;
                }
                else
                {
                    BatchNo = Convert.ToInt32(MaxObj_TransGL.BatchNo) + 1;
                    TracerNo = Convert.ToInt32(MaxObj_TransGL.TracerNo);
                }

                var List_TransactionTemplate = _IUoW.Repository<TransactionTemplate>().Get(x => (x.DefineServiceId == _GLMaster.DefineServiceId) &&
                                                                                           x.AuthStatusId == "A" && x.LastAction != "DEL");
                if(List_TransactionTemplate != null)
                {
                    foreach (var item in List_TransactionTemplate)
                    {
                        TransGL Obj_TransGL = new TransGL();
                        var _oldGLMaster = _IUoW.Repository<GLMaster>().GetBy(x => x.GLAccSl == item.GLAccSl);
                        if (_oldGLMaster != null)
                        {
                            //var _oldGLMasterForLog = ObjectCopier.DeepCopy(_oldGLMaster);

                            decimal? CurrentBalanceLCY = _oldGLMaster.CurrentBalanceLCY;
                            decimal? CurrentBalanceCCY = _oldGLMaster.CurrentBalanceCCY;
                            decimal? Amount = _GLMaster.Amount;
                            if(item.DebitOrCredit == "D")//debit
                            {
                                _oldGLMaster.CurrentBalanceLCY = (CurrentBalanceLCY - Amount);
                                _oldGLMaster.CurrentBalanceCCY = (CurrentBalanceCCY - Amount);
                            }
                            if (item.DebitOrCredit == "C")//credit
                            {
                                _oldGLMaster.CurrentBalanceLCY = (CurrentBalanceLCY + Amount);
                                _oldGLMaster.CurrentBalanceCCY = (CurrentBalanceCCY + Amount);
                            }
                            _oldGLMaster.AuthStatusId = "A";
                            _oldGLMaster.LastAction = "EDT";
                            _oldGLMaster.LastUpdateDT = System.DateTime.Now;
                            _oldGLMaster.MakeBy = "prova";
                            result = _IUoW.Repository<GLMaster>().Update(_oldGLMaster);
                            if(result == 1)
                            {   
                                if (MaxObj_TransGL == null)
                                {
                                    TracerNo = TracerNo + 1;
                                }
                                else
                                {
                                    TracerNo = TracerNo + 1;
                                }
                                Obj_TransGL.BranchId = _oldGLMaster.BranchId;
                                Obj_TransGL.TracerNo = TracerNo.ToString();
                                Obj_TransGL.BatchNo = BatchNo.ToString();
                                Obj_TransGL.DebitOrCredit = item.DebitOrCredit;
                                Obj_TransGL.GLAccSl = _oldGLMaster.GLAccSl;
                                Obj_TransGL.GLAccNo = _oldGLMaster.GLAccNo;
                                Obj_TransGL.AmountLCY = _GLMaster.Amount;
                                Obj_TransGL.AmountCCY = _GLMaster.Amount;
                                Obj_TransGL.BalanceLCY = Convert.ToInt32(_oldGLMaster.CurrentBalanceLCY);
                                Obj_TransGL.BalanceCCY = Convert.ToInt32(_oldGLMaster.CurrentBalanceCCY);
                                Obj_TransGL.Narration = _GLMaster.Narration;
                                Obj_TransGL.AuthStatusId = "A";
                                Obj_TransGL.LastAction = "ADD";
                                Obj_TransGL.MakeBy = "prova";
                                Obj_TransGL.MakeDT = System.DateTime.Now;
                                List_Obj_TransGL.Add(Obj_TransGL);
                            }
                        }
                        if (result == 0)
                        {
                            return result;
                        }
                    }
                    result = _IUoW.Repository<TransGL>().AddRange(List_Obj_TransGL);
                }                
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateGLBalanceLCYandCCY(string)", string.Empty);
                return result;
            }
        }
        #endregion
    }
}
