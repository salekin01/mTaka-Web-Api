using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.SP;
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

namespace mTaka.Service.BusinessServices.SP
{
    public interface ISpecialOfferService
    {
        IEnumerable<SpecialOffers> GetAllSpecialOffers();
        SpecialOffers GetSpecialOffersById(string _OfferId);
        int GetSpecialOffersBy(SpecialOffers _SpecialOffers);
        SpecialOffers GetCreateInfoForSpecialOffers();
        int AddSpecialOffers(SpecialOffers _SpecialOffers);
        int UpdateSpecialOffers(SpecialOffers _SpecialOffers);
        int DeleteSpecialOffers(SpecialOffers _SpecialOffers);
        IEnumerable<SelectListItem> GetSpecialOffersForDD();


        SpecialOffers CheckOffers(SpecialOffers _SpecialOffers);
    }

    public class SpecialOfferService : ISpecialOfferService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        SpecialOffers _SpecialOffers = null;
        private ICusCategoryService _ICusCategoryService;

        public SpecialOfferService()
        {
            _IUoW = new UnitOfWork();
        }
        public SpecialOfferService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<SpecialOffers> GetAllSpecialOffers()
        {
            try
            {
                var AllSpecialOffer = _IUoW.mTakaDbQuery().GetAllSpecialOffer_LQ().OrderByDescending(x => x.OfferId);
                return AllSpecialOffer;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllSpecialOffer()", string.Empty);
                return null;
            }
        }

        public SpecialOffers GetCreateInfoForSpecialOffers()
        {
            throw new NotImplementedException();
        }

        public int GetSpecialOffersBy(SpecialOffers _SpecialOffers)
        {
            var SpecialOffer = _IUoW.Repository<SpecialOffers>().GetBy(x => x.DefineServiceId==_SpecialOffers.DefineServiceId
                                                                 && x.AccTypeId==_SpecialOffers.AccTypeId);
            if (SpecialOffer ==null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }

        public SpecialOffers GetSpecialOffersById(string _OfferId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Add
        public int AddSpecialOffers(SpecialOffers _SpecialOffers)
        {
            try
            {
                var startDate = _SpecialOffers.StartDate.Value.Date;
                var endDate = _SpecialOffers.EndDate.Value.Date;
                var _max = _IUoW.Repository<SpecialOffers>().GetMaxValue(x => x.OfferId) + 1;
                _SpecialOffers.OfferId = _max.ToString().PadLeft(3, '0');
                _SpecialOffers.StartDate = startDate;
                _SpecialOffers.EndDate = endDate;
                _SpecialOffers.AuthStatusId = "U";
                _SpecialOffers.LastAction = "ADD";
                _SpecialOffers.MakeDT = System.DateTime.Now;
                _SpecialOffers.MakeBy = "mtaka";
                var result = _IUoW.Repository<SpecialOffers>().Add(_SpecialOffers);

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _SpecialOffers, "ADD", "0001", _SpecialOffers.FunctionId, 1, "SpecialOffers", "MTK_SP_SPECIAL_OFFERS", "OfferId", _SpecialOffers.OfferId, _SpecialOffers.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddSpecialOffers(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateSpecialOffers(SpecialOffers _SpecialOffers)
        {

            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_SpecialOffers.OfferId))
                {
                    IsRecordExist = _IUoW.Repository<SpecialOffers>().IsRecordExist(x => x.OfferId == _SpecialOffers.OfferId);
                    if (IsRecordExist)
                    {
                        var _oldSpecialOffer = _IUoW.Repository<SpecialOffers>().GetBy(x => x.OfferId == _SpecialOffers.OfferId);
                        var _oldSpecialOfferForLog = ObjectCopier.DeepCopy(_oldSpecialOffer);

                        _oldSpecialOffer.AuthStatusId = _SpecialOffers.AuthStatusId = "U";
                        _oldSpecialOffer.LastAction = _SpecialOffers.LastAction = "EDT";
                        _oldSpecialOffer.LastUpdateDT = _SpecialOffers.LastUpdateDT = System.DateTime.Now;
                        _SpecialOffers.MakeBy = "mtaka";
                        result = _IUoW.Repository<SpecialOffers>().Update(_oldSpecialOffer);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldSpecialOfferForLog, _SpecialOffers, "EDT", "0001", _SpecialOffers.FunctionId, 1, "SpecialOffers", "MTK_SP_SPECIAL_OFFERS", "OfferId", _SpecialOffers.OfferId, _SpecialOffers.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateSpecialOffer(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteSpecialOffers(SpecialOffers _SpecialOffers)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_SpecialOffers.OfferId))
                {
                    IsRecordExist = _IUoW.Repository<SpecialOffers>().IsRecordExist(x => x.OfferId == _SpecialOffers.OfferId);
                    if (IsRecordExist)
                    {
                        var _oldSpecialOffers = _IUoW.Repository<SpecialOffers>().GetBy(x => x.OfferId == _SpecialOffers.OfferId);
                        var _oldSpecialOffersForLog = ObjectCopier.DeepCopy(_oldSpecialOffers);

                        _oldSpecialOffers.AuthStatusId = _SpecialOffers.AuthStatusId = "U";
                        _oldSpecialOffers.LastAction = _SpecialOffers.LastAction = "DEL";
                        _oldSpecialOffers.LastUpdateDT = _SpecialOffers.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<SpecialOffers>().Update(_oldSpecialOffers);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldSpecialOffersForLog, _SpecialOffers, "DEL", "0001", _SpecialOffers.FunctionId, 1, "SpecialOffers", "MTK_SP_SPECIAL_OFFERS", "OfferId", _SpecialOffers.OfferId, _SpecialOffers.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteSpecialOffers(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region DropDown
        public IEnumerable<SelectListItem> GetSpecialOffersForDD()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CheckOffer
        public SpecialOffers CheckOffers(SpecialOffers _SpecialOffers)
        {

            var Today = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            var AccInfo = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == _SpecialOffers.WalletAccountNo);

            var SpecialOffer = _IUoW.Repository<SpecialOffers>().GetBy(x => x.DefineServiceId == _SpecialOffers.DefineServiceId
                                                                         && x.AccTypeId == AccInfo.AccTypeId);
            if (SpecialOffer!= null)
            {
                var StartDate = SpecialOffer.StartDate.Value.Date;
                var EndDate = SpecialOffer.EndDate.Value.Date;

                if (Today >= StartDate && Today <= EndDate)
                {
                    return SpecialOffer;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            
        }
        #endregion
    }
}
