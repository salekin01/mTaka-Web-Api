using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.Process;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mTaka.Service.BusinessServices.Process
{
    public interface IOrganogramService
    {
        IEnumerable<Organogram> GetOrganogram(Organogram _Organogram);

        Organogram getChannelMemberData(string WNo);

        Organogram getAccountProfileData(string WNo);

        List<Organogram> getChildern(string ACC_Profile_ID, string EmployeeID, string AccTypeId );
    }

    public class OrganogramService : IOrganogramService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        private ErrorLogService _ObjErrorLogService = null;

        public List<Organogram> LIST_Organogram = new List<Organogram>();
        public List<Organogram> ParentList_Organogram = new List<Organogram>();
        public List<Organogram> Child_Organogram = new List<Organogram>();
        public List<Organogram> CusChildernlist = new List<Organogram>();
        public List<Organogram> ChannelChildernlist = new List<Organogram>();
        public List<Organogram> TempList_Organogram = new List<Organogram>();

        

        public OrganogramService()
        {
            _IUoW = new UnitOfWork();
        }

        public OrganogramService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        public IEnumerable<Organogram> GetOrganogram(Organogram _Organogram)
        {
            Organogram CMD = new Organogram();
            Organogram APD = new Organogram();

            if (_Organogram.Title == "D")
            {
                if (_Organogram != null && _Organogram.HomePhone != null)
                {
                    CMD = getChannelMemberData(_Organogram.HomePhone);
                    if (CMD != null)
                    {
                        LIST_Organogram = getChildern(_Organogram.Title, CMD.EmployeeID, CMD.AccTypeId );

                        foreach (var members in LIST_Organogram.ToList())
                        {
                            TempList_Organogram = getChildern(members.Title, members.EmployeeID, members.AccTypeId);

                            if (TempList_Organogram.Count() != 0)
                            {
                                LIST_Organogram.AddRange(TempList_Organogram);
                            }
                        }
                    }
                }
            }
            else if (_Organogram.Title == "M")
            {

            }

            LIST_Organogram.Add(CMD);

            return LIST_Organogram;
        }

        public Organogram getChannelMemberData(string WNo)
        {
            try
            {
                var result = _IUoW.Repository<ChannelAccProfile>().Get(a => a.WalletAccountNo == WNo).Select(s =>
                new Organogram
                {
                    EmployeeID = s.AccountProfileId,
                    FirstName = s.UserName,
                    LastName = s.WalletAccountNo,
                    DateOfBirth = s.DateofBirth,
                    Title = getAccountType(s.AccountTypeId),
                    AccTypeId = s.AccountTypeId,
                    //,
                    ReportsTo = "0"
                }).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Organogram getAccountProfileData(string WNo)
        {
            try
            {
                dynamic result1 = _IUoW.Repository<CustomerAccProfile>().Get(a => a.WalletAccountNo == WNo).Select(s =>
                  new Organogram
                  {
                      EmployeeID = s.AccountProfileId,
                      FirstName = s.UserName,
                      LastName = s.WalletAccountNo,
                      DateOfBirth = s.DOB,
                      Title = getAccountType(s.AccTypeId),
                      ReportsTo = "0"
                  }).FirstOrDefault();

                return result1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string getAccountType(string AccountTypeId)
        {
            try
            {
                var _AccountType = _IUoW.mTakaDbQuery().getAccountType_LQ(AccountTypeId);
                return _AccountType;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "getAccountType()", string.Empty);
                return null;
            }
        }

        public List<Organogram> getChildern(string Type, string EmployeeID, string AccTypeId)
        {
            
            List<Organogram> Childernlist = new List<Organogram>();
            try
            {

                CusChildernlist = _IUoW.Repository<CustomerAccProfile>().Get(a => a.ParentAccountProfileId == EmployeeID).Select(s =>
                        new Organogram
                        {
                            EmployeeID = s.AccountProfileId,
                            FirstName = s.UserName,
                            LastName = s.WalletAccountNo,
                            DateOfBirth = s.DOB,
                            Title = getAccountType(s.AccTypeId),
                            AccTypeId = s.AccTypeId,
                            ReportsTo = EmployeeID
                        }).ToList();

                ChannelChildernlist = _IUoW.Repository<ChannelAccProfile>().Get(a => a.ParentAccountProfileId == EmployeeID).Select(s =>
                    new Organogram
                    {
                        EmployeeID = s.AccountProfileId,
                        FirstName = s.UserName,
                        LastName = s.WalletAccountNo,
                        DateOfBirth = s.DateofBirth,
                        Title = getAccountType(s.AccountTypeId),
                        AccTypeId = s.AccountTypeId,
                        ReportsTo = EmployeeID
                    }).ToList();
                
                #region comment 
                //if (Type == "C" || AccTypeId == "004")
                //{
                //    Childernlist = _IUoW.Repository<CustomerAccProfile>().Get(a => a.ParentAccountProfileId == EmployeeID).Select(s =>
                //        new Organogram
                //        {
                //            EmployeeID = s.AccountProfileId,
                //            FirstName = s.UserName,
                //            LastName = s.WalletAccountNo,
                //            DateOfBirth = s.DOB,
                //            Title = getAccountType(s.AccTypeId),
                //            AccTypeId = s.AccTypeId,
                //            ReportsTo = EmployeeID
                //        }).ToList();
                //}
                //else if (Type == "D" || AccTypeId == "001" || AccTypeId == "002" || AccTypeId == "003")
                //{
                //    Childernlist = _IUoW.Repository<ChannelAccProfile>().Get(a => a.ParentAccountProfileId == EmployeeID).Select(s =>
                //        new Organogram
                //        {
                //            EmployeeID = s.AccountProfileId,
                //            FirstName = s.UserName,
                //            LastName = s.WalletAccountNo,
                //            DateOfBirth = s.DateofBirth,
                //            Title = getAccountType(s.AccountTypeId),
                //            AccTypeId = s.AccountTypeId,
                //            ReportsTo = EmployeeID
                //        }).ToList();
                //}
                #endregion

                if(CusChildernlist.Count() > 0)
                {
                    Childernlist = CusChildernlist;
                }
                else if(ChannelChildernlist.Count() > 0)
                {
                    Childernlist = ChannelChildernlist;
                }
                return Childernlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}