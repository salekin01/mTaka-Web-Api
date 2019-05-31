using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Data.Infrastructure;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using mTaka.Data.BusinessEntities.SP;
using System.ComponentModel;  //For TypeDescriptor
using System.Linq.Expressions;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.BusinessEntities.LEDGER;
using System.Web.WebPages.Html;
using mTaka.Data.BusinessEntities;
using System.Web.Script.Serialization;   //reference is "System.Web.Extensions"
using mTaka.Service.BusinessServices.LEDGER;
using mTaka.Data.BusinessEntities.GL;
using mTaka.Service.Common;
using mTaka.Service.BusinessServices.GL;
using System.ComponentModel.DataAnnotations.Schema;

namespace mTaka.Service.BusinessServices.AUTH
{
    public interface IAuthLogService
    {
        int AddAuthLog(IUnitOfWork _IUoW, Object _oldObject, Object _newObject, string _LastAction, string _BranchId, string _FunctionId, int _PrimaryTableFlag, string _ModelNm, string _TableNm, string _TablePkColNm, string TablePkColVal, string _MakeBy, long _inMaxSl, out long _outMaxSl);

        int VerifyAuthLog(string _LogId, string _Remarks, string _AuthStatusId, string _MakeBy, string[] SelectedAuthLogIdList);
        int VerifyAuthLog_FT(string _LogId, string _Remarks, string _AuthStatusId, string _MakeBy, string[] SelectedAuthLogIdList);

        int SetTableObject<TObject>(IUnitOfWork _IUoW, AuthLog _ObjAuthLog, TObject OBJ); //used in CustomerAccProfileService -> AddCustomer
        int SetTableObject_FT<TObject>(IUnitOfWork _IUoW, FTAuthLog _ObjAuthLog, TObject OBJ);

        IEnumerable<SelectListItem> GetNftAuthLogFunctionsForDD();
        IEnumerable<SelectListItem> GetFtAuthLogFunctionsForDD();

        IEnumerable<AuthLog> GetAllNftAuthLogByFunctionId(string _FunctionId);
        IEnumerable<FTAuthLog> GetAllFtAuthLogByFunctionId(string _FunctionId);

        IEnumerable<AuthLogDtl> GetNftAuthLogDetailsByLogId(string _LogId);
        IEnumerable<FTAuthLogDtl> GetFtAuthLogDetailsByLogId(string _LogId);
    }
    public class AuthLogService : IAuthLogService
    {
        private IUnitOfWork _IUoW = null;       

        ErrorLogService _ObjErrorLogService = null;

        #region Add
        /*
        public int AddAuthLog(IUnitOfWork _IUoW, Object _oldObject, Object _newObject, string _LastAction, string _BranchId, string _FunctionId, int _PrimaryTableFlag, string _TableNm, string _TablePkColNm, string _TablePkColVal, string _MakeBy, long _inMaxSl, out long _outMaxSl)
        {
            try
            {
                long _outMaxSlTemp = 0;
                AuthLog _AuthLog = new AuthLog();
                _AuthLog.BranchId = _BranchId;
                _AuthLog.FunctionId = _FunctionId;
                _AuthLog.PrimaryTableFlag = _PrimaryTableFlag;
                _AuthLog.TableNm = _TableNm;
                _AuthLog.TablePkColNm = _TablePkColNm;
                _AuthLog.TablePkColVal = _TablePkColVal;

                int result = 0;
                var _max_sl = _IUoW.Repository<AuthLog>().GetMaxValue(x => x.Sl) + 1;
                var _max_log_id = _IUoW.Repository<AuthLog>().GetMaxValue(x => x.LogId) + 1;
                _AuthLog.Sl = _max_sl.ToString();
                _AuthLog.LogId = _max_log_id.ToString().PadLeft(9, '0');

                #region Auth Max Level Retriving
                if (string.IsNullOrWhiteSpace(_FunctionId))
                {
                    _outMaxSl = _outMaxSlTemp;
                    return result;
                }

                _AuthLog.AuthLevelMax = 0;
                string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetNftAuthLevelMaxFromFunction/" + _FunctionId + "?format=json";
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    //var _authLevelMax = JsonConvert.DeserializeObject(json);
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    if (dict != null && string.IsNullOrWhiteSpace(dict.First().Value) || dict.First().Value == "")
                    {
                        _outMaxSl = _outMaxSlTemp;
                        return 0;
                    }

                    foreach (var kv in dict)
                    {
                        _AuthLog.AuthLevelMax = (kv.Value == null) ? 0 : Convert.ToInt16(kv.Value);
                    }
                }
                #endregion

                _AuthLog.AuthLevelPending = _AuthLog.AuthLevelMax;
                _AuthLog.AuthStatusId = "U";
                _AuthLog.LastAction = _LastAction;
                _AuthLog.MakeBy = _MakeBy;
                _AuthLog.MakeDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                if (_PrimaryTableFlag == 1)
                {
                    result = _IUoW.Repository<AuthLog>().Add(_AuthLog);
                    if (result == 1)
                    {
                        result = AddAuthLogDtl(_IUoW, _oldObject, _newObject, _AuthLog, _inMaxSl, out _outMaxSl);
                        _outMaxSlTemp = _outMaxSl;
                    }
                }
                else if (_PrimaryTableFlag == 0)
                {
                    result = AddAuthLogDtl(_IUoW, _oldObject, _newObject, _AuthLog, _inMaxSl, out _outMaxSl);
                    _outMaxSlTemp = _outMaxSl;
                }
                _outMaxSl = _outMaxSlTemp;
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAuthLog", string.Empty);
                _outMaxSl = 0;
                return 0;
                //throw ex;
            }
        } */
        public int AddAuthLog(IUnitOfWork _IUoW, Object _oldObject, Object _newObject, string _LastAction, string _BranchId, string _FunctionId, int _PrimaryTableFlag, string _ModelNm, string _TableNm, string _TablePkColNm, string _TablePkColVal, string _MakeBy, long _inMaxSl, out long _outMaxSl)
        {
            int result = 0;
            try
            {
                int _processFlag = 0;
                int _authLevelMax = 0;
                long _outMaxSlTemp = 0;
                long _max_sl = 0;
                long _max_log_id = 0;
                #region Auth Max Level Retriving
                if (string.IsNullOrWhiteSpace(_FunctionId))
                {
                    _outMaxSl = _outMaxSlTemp;
                    return result;
                }

                using (WebClient wc = new WebClient())
                {
                    string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetFunctionDetailsByFunctionId/" + _FunctionId + "?format=json";
                    var json = wc.DownloadString(url);
                    var _objFunctionDtl = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    if (_objFunctionDtl == null)
                    {
                        _outMaxSl = _outMaxSlTemp;
                        return result;
                    }
                    else
                    {
                        foreach (var parent in _objFunctionDtl)
                        {
                            dynamic child = parent.Value;
                            var AuthLevelMax = child.AUTH_LEVEL.Value;
                            var processFlag = child.PROCESS_FLAG.Value;
                            _authLevelMax = AuthLevelMax != null ? Convert.ToInt32(AuthLevelMax.ToString().Trim()) : 0;
                            _processFlag = processFlag != null ? Convert.ToInt32(processFlag.ToString().Trim()) : 0;
                        }
                    }
                }
                #endregion

                if (_processFlag == 0) //NFT
                {
                    _max_sl = _IUoW.Repository<AuthLog>().GetMaxValue(x => x.Sl) + 1;
                    _max_log_id = _IUoW.Repository<AuthLog>().GetMaxValue(x => x.LogId) + 1;

                    AuthLog _AuthLog = new AuthLog();
                    //dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    _AuthLog.Sl = _max_sl.ToString();
                    _AuthLog.LogId = _max_log_id.ToString().PadLeft(9, '0');
                    _AuthLog.BranchId = _BranchId;
                    _AuthLog.FunctionId = _FunctionId;
                    _AuthLog.PrimaryTableFlag = _PrimaryTableFlag;
                    _AuthLog.ModelNm = _ModelNm;
                    _AuthLog.TableNm = _TableNm;
                    _AuthLog.TablePkColNm = _TablePkColNm;
                    _AuthLog.TablePkColVal = _TablePkColVal;

                    _AuthLog.AuthLevelPending = _authLevelMax;
                    _AuthLog.AuthStatusId = "U";
                    _AuthLog.LastAction = _LastAction;
                    _AuthLog.MakeBy = _MakeBy;
                    _AuthLog.MakeDT = System.DateTime.Now;

                    if (_PrimaryTableFlag == 1)
                    {
                        result = _IUoW.Repository<AuthLog>().Add(_AuthLog);
                        if (result == 1)
                        {
                            result = AddAuthLogDtl(_IUoW, _oldObject, _newObject, _AuthLog, _inMaxSl, out _outMaxSl);
                            _outMaxSlTemp = _outMaxSl;
                        }
                    }
                    else if (_PrimaryTableFlag == 0)
                    {
                        result = AddAuthLogDtl(_IUoW, _oldObject, _newObject, _AuthLog, _inMaxSl, out _outMaxSl);
                        _outMaxSlTemp = _outMaxSl;
                    }
                }
                else if (_processFlag == 1) //FT
                {
                    _max_sl = _IUoW.Repository<FTAuthLog>().GetMaxValue(x => x.Sl) + 1;
                    _max_log_id = _IUoW.Repository<FTAuthLog>().GetMaxValue(x => x.LogId) + 1;

                    FTAuthLog _AuthLog = new FTAuthLog();
                    _AuthLog.Sl = _max_sl.ToString();
                    _AuthLog.LogId = _max_log_id.ToString().PadLeft(9, '0');
                    _AuthLog.BranchId = _BranchId;
                    _AuthLog.FunctionId = _FunctionId;
                    _AuthLog.PrimaryTableFlag = _PrimaryTableFlag;
                    _AuthLog.ModelNm = _ModelNm;
                    _AuthLog.TableNm = _TableNm;
                    _AuthLog.TablePkColNm = _TablePkColNm;
                    _AuthLog.TablePkColVal = _TablePkColVal;

                    _AuthLog.AuthLevelPending = _authLevelMax;
                    _AuthLog.AuthStatusId = "U";
                    _AuthLog.LastAction = _LastAction;
                    _AuthLog.MakeBy = _MakeBy;
                    _AuthLog.MakeDT = System.DateTime.Now;

                    if (_PrimaryTableFlag == 1)
                    {
                        result = _IUoW.Repository<FTAuthLog>().Add(_AuthLog);
                        if (result == 1)
                        {
                            result = AddAuthLogDtl(_IUoW, _oldObject, _newObject, _AuthLog, _inMaxSl, out _outMaxSl);
                            _outMaxSlTemp = _outMaxSl;
                        }
                    }
                    else if (_PrimaryTableFlag == 0)
                    {
                        result = AddAuthLogDtl(_IUoW, _oldObject, _newObject, _AuthLog, _inMaxSl, out _outMaxSl);
                        _outMaxSlTemp = _outMaxSl;
                    }
                }
                _outMaxSl = _outMaxSlTemp;
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAuthLog", string.Empty);
                _outMaxSl = 0;
                return result;
                //throw ex;
            }
        }

        //NFT
        public int AddAuthLogDtl(IUnitOfWork _IUoW, Object _oldObject, Object _newObject, AuthLog _AuthLog, long _inMaxSlAuthLogDtl, out long _outMaxSlAuthLogDtl)
        {
            int result = 0;
            try
            {
                Guid _LogChildId = Guid.NewGuid();
                string TablePkColNm = string.Empty;
                string DisplayAttributeNm = string.Empty;
                var _max = _inMaxSlAuthLogDtl > 0 ? _inMaxSlAuthLogDtl : _IUoW.Repository<AuthLogDtl>().GetMaxValue(x => x.Sl);

                if (_AuthLog.LastAction == "ADD")
                {
                    Type newObjectType = _newObject.GetType();
                    IList<PropertyInfo> newObjectProps = new List<PropertyInfo>(newObjectType.GetProperties());
                    List<AuthLogDtl> _ListNewAuthLogDtl = new List<AuthLogDtl>();

                    if (IsEnumerableType(newObjectType) || IsCollectionType(newObjectType))     //when _newObject is a Collection
                    {
                        newObjectType = _newObject.GetType().GetGenericArguments().Single();
                        newObjectProps = new List<PropertyInfo>(newObjectType.GetProperties());
                        TablePkColNm = newObjectProps.FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();

                        int child_id = 0;
                        foreach (var itemOf_newObject in (dynamic)_newObject)
                        {
                            child_id++;
                            foreach (PropertyInfo prop in newObjectProps)
                            {
                                if (prop.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary" || prop.PropertyType.Name == "List`1" || prop.PropertyType.Name == "IList`1" || prop.PropertyType.Name == "ICollection`1" || prop.PropertyType.Name == "IEnumerable`1") //check if property type is a class type || is a List type
                                {
                                    continue;
                                }
                                else
                                {
                                    var attribute = prop.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                                    if (attribute != null)
                                    {
                                        DisplayAttributeNm = attribute.Name;
                                    }

                                    AuthLogDtl _AuthLogDtl = new AuthLogDtl();
                                    _AuthLogDtl.Sl = Convert.ToString(++_max);
                                    _AuthLogDtl.LogId = _AuthLog.LogId;
                                    _AuthLogDtl.LogChildId = _LogChildId + "--" + child_id.ToString().PadLeft(6, '0');
                                    _AuthLogDtl.ModelNm = _AuthLog.ModelNm;
                                    _AuthLogDtl.TableNm = _AuthLog.TableNm;
                                    _AuthLogDtl.TableColNm = prop.Name;
                                    _AuthLogDtl.TablePkColFlag = (prop.Name.ToLower() == TablePkColNm) ? 1 : 0;
                                    _AuthLogDtl.NewValue = Convert.ToString(prop.GetValue(itemOf_newObject, null));
                                    _AuthLogDtl.DisplayTableColNm = DisplayAttributeNm;
                                    _ListNewAuthLogDtl.Add(_AuthLogDtl);
                                }
                            }
                            result = _IUoW.Repository<AuthLogDtl>().AddRange(_ListNewAuthLogDtl);
                        }
                    }
                    else    //when _newObject is a Object
                    {
                        TablePkColNm = newObjectProps.FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();
                        int child_id = 1;
                        foreach (PropertyInfo prop in newObjectProps)
                        {
                            if (prop.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary" || prop.PropertyType.Name == "List`1" || prop.PropertyType.Name == "IList`1" || prop.PropertyType.Name == "ICollection`1" || prop.PropertyType.Name == "IEnumerable`1") //check if property type is a class type || is a List type
                            {
                                continue;
                            }
                            else
                            {
                                var attribute = prop.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                                if (attribute != null)
                                {
                                    DisplayAttributeNm = attribute.Name;
                                }

                                AuthLogDtl _AuthLogDtl = new AuthLogDtl();
                                _AuthLogDtl.Sl = Convert.ToString(++_max);
                                _AuthLogDtl.LogId = _AuthLog.LogId;
                                _AuthLogDtl.LogChildId = (_AuthLog.PrimaryTableFlag == 1) ? string.Empty : _LogChildId + "--" + child_id.ToString().PadLeft(6, '0');
                                _AuthLogDtl.ModelNm = _AuthLog.ModelNm;
                                _AuthLogDtl.TableNm = _AuthLog.TableNm;
                                _AuthLogDtl.TableColNm = prop.Name;
                                _AuthLogDtl.TablePkColFlag = (prop.Name.ToLower() == TablePkColNm) ? 1 : 0;
                                _AuthLogDtl.NewValue = Convert.ToString(prop.GetValue(_newObject, null));
                                _AuthLogDtl.DisplayTableColNm = DisplayAttributeNm;
                                _ListNewAuthLogDtl.Add(_AuthLogDtl);
                            }
                        }
                        result = _IUoW.Repository<AuthLogDtl>().AddRange(_ListNewAuthLogDtl);
                    }
                }

                else if (_AuthLog.LastAction == "EDT" || _AuthLog.LastAction == "DEL")
                {
                    Type oldObjectType = _oldObject.GetType();
                    Type newObjectType = _newObject.GetType();
                    IList<PropertyInfo> oldObjectProps = new List<PropertyInfo>(oldObjectType.GetProperties());
                    IList<PropertyInfo> newObjectProps = new List<PropertyInfo>(newObjectType.GetProperties());
                    List<AuthLogDtl> _ListEditedAuthLogDtl = new List<AuthLogDtl>();

                    if (IsEnumerableType(newObjectType) || IsCollectionType(newObjectType))     //when _newObject is a Collection
                    {
                        newObjectType = _newObject.GetType().GetGenericArguments().Single();
                        oldObjectType = _oldObject.GetType().GetGenericArguments().Single();
                        newObjectProps = new List<PropertyInfo>(newObjectType.GetProperties());
                        oldObjectProps = new List<PropertyInfo>(oldObjectType.GetProperties());
                        int child_id = 0;
                        TablePkColNm = newObjectProps.FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();

                        foreach (var itemOf_newObject in (dynamic)_newObject)
                        {
                            //var newPKKey = itemOf_newObject.GetType().GetProperty(_AuthLog.TablePkColNm).GetValue(itemOf_newObject, null) == itemOf_newObject.GetType().GetProperty(_AuthLog.TablePkColNm).GetValue(itemOf_newObject, null);
                            var newPkkey = newObjectProps.FirstOrDefault(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).GetValue(itemOf_newObject, null);
                            foreach (var itemOf_oldObject in (dynamic)_oldObject)
                            {
                                var oldPkkey = oldObjectProps.FirstOrDefault(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).GetValue(itemOf_oldObject, null);
                                if (newPkkey == oldPkkey) //finding matched old and new row using row's primary key 
                                {
                                    child_id++;
                                    foreach (PropertyInfo oldObjectProp in oldObjectProps)
                                    {
                                        foreach (PropertyInfo newObjectProp in newObjectProps)
                                        {
                                            if (newObjectProp.Name == oldObjectProp.Name)
                                            {
                                                object oldObjectPropValue = oldObjectProp.GetValue(itemOf_oldObject, null);
                                                object newObjectPropValue = newObjectProp.GetValue(itemOf_newObject, null);
                                                string oldPropValue = oldObjectPropValue != null ? oldObjectPropValue.ToString().Trim() : string.Empty;
                                                string newPropValue = newObjectPropValue != null ? newObjectPropValue.ToString().Trim() : string.Empty;

                                                if (newObjectProp.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary" || newObjectProp.PropertyType.Name == "List`1" || newObjectProp.PropertyType.Name == "IList`1" || newObjectProp.PropertyType.Name == "ICollection`1" || newObjectProp.PropertyType.Name == "IEnumerable`1") //check if property type is a class type
                                                {
                                                    continue;
                                                }
                                                else if (oldPropValue == null && newPropValue == null)
                                                {
                                                    continue;
                                                }
                                                else if ((oldPropValue != newPropValue && (newPropValue != null && newPropValue != "")) || newObjectProp.Name.ToLower() == TablePkColNm)
                                                {
                                                    var attribute = newObjectProp.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                                                    if (attribute != null)
                                                    {
                                                        DisplayAttributeNm = attribute.Name;
                                                    }

                                                    AuthLogDtl _AuthLogDtl = new AuthLogDtl();
                                                    _AuthLogDtl.Sl = Convert.ToString(++_max);
                                                    _AuthLogDtl.LogId = _AuthLog.LogId;
                                                    _AuthLogDtl.LogChildId = _LogChildId + "--" + child_id.ToString().PadLeft(6, '0');
                                                    _AuthLogDtl.ModelNm = _AuthLog.ModelNm;
                                                    _AuthLogDtl.TableNm = _AuthLog.TableNm;
                                                    _AuthLogDtl.TableColNm = oldObjectProp.Name;
                                                    _AuthLogDtl.TablePkColFlag = (newObjectProp.Name.ToLower() == TablePkColNm) ? 1 : 0;
                                                    _AuthLogDtl.OldValue = oldPropValue;
                                                    _AuthLogDtl.NewValue = newPropValue;
                                                    _AuthLogDtl.DisplayTableColNm = DisplayAttributeNm;
                                                    _ListEditedAuthLogDtl.Add(_AuthLogDtl);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else  //when _newObject is a Object
                    {
                        int child_id = 1;
                        TablePkColNm = newObjectProps.FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();
                        foreach (PropertyInfo oldObjectProp in oldObjectProps)
                        {
                            foreach (PropertyInfo newObjectProp in newObjectProps)
                            {
                                if (newObjectProp.Name == oldObjectProp.Name)
                                {
                                    object oldObjectPropValue = oldObjectProp.GetValue(_oldObject, null);
                                    object newObjectPropValue = newObjectProp.GetValue(_newObject, null);
                                    string oldPropValue = oldObjectPropValue != null ? oldObjectPropValue.ToString().Trim() : string.Empty;
                                    string newPropValue = newObjectPropValue != null ? newObjectPropValue.ToString().Trim() : string.Empty;

                                    if (newObjectProp.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary" || newObjectProp.PropertyType.Name == "List`1" || newObjectProp.PropertyType.Name == "IList`1" || newObjectProp.PropertyType.Name == "ICollection`1" || newObjectProp.PropertyType.Name == "IEnumerable`1") //check if property type is a class type
                                    {
                                        continue;
                                    }
                                    //if (!IsSimple(newObjectProp.PropertyType)) //check if property type is a class type
                                    //{
                                    //    ////do nothing
                                    //}
                                    else if (oldPropValue == null && newPropValue == null)
                                    {
                                        continue;
                                    }
                                    else if ((oldPropValue != newPropValue && (newPropValue != null && newPropValue != "")) || newObjectProp.Name.ToLower() == TablePkColNm)
                                    {
                                        var attribute = newObjectProp.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                                        if (attribute != null)
                                        {
                                            DisplayAttributeNm = attribute.Name;
                                        }

                                        AuthLogDtl _AuthLogDtl = new AuthLogDtl();
                                        _AuthLogDtl.Sl = Convert.ToString(++_max);
                                        _AuthLogDtl.LogId = _AuthLog.LogId;
                                        _AuthLogDtl.LogChildId = (_AuthLog.PrimaryTableFlag == 1) ? string.Empty : _LogChildId + "--" + child_id.ToString().PadLeft(6, '0');
                                        _AuthLogDtl.ModelNm = _AuthLog.ModelNm;
                                        _AuthLogDtl.TableNm = _AuthLog.TableNm;
                                        _AuthLogDtl.TableColNm = oldObjectProp.Name;
                                        _AuthLogDtl.TablePkColFlag = (newObjectProp.Name.ToLower() == TablePkColNm) ? 1 : 0;
                                        _AuthLogDtl.OldValue = oldPropValue;
                                        _AuthLogDtl.NewValue = newPropValue;
                                        _AuthLogDtl.DisplayTableColNm = DisplayAttributeNm;
                                        _ListEditedAuthLogDtl.Add(_AuthLogDtl);
                                    }
                                }
                            }
                        }
                    }

                    result = _IUoW.Repository<AuthLogDtl>().AddRange(_ListEditedAuthLogDtl);
                }
                _outMaxSlAuthLogDtl = _max;
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAuthLogDtl-NFT", string.Empty);
                _outMaxSlAuthLogDtl = 0;
                return result;
            }
        }

        //FT
        public int AddAuthLogDtl(IUnitOfWork _IUoW, Object _oldObject, Object _newObject, FTAuthLog _AuthLog, long _inMaxSlAuthLogDtl, out long _outMaxSlAuthLogDtl)
        {
            int result = 0;
            try
            {
                Guid _LogChildId = Guid.NewGuid();
                string TablePkColNm = string.Empty;
                string DisplayAttributeNm = string.Empty;
                var _max = _inMaxSlAuthLogDtl > 0 ? _inMaxSlAuthLogDtl : _IUoW.Repository<FTAuthLogDtl>().GetMaxValue(x => x.Sl);

                if (_AuthLog.LastAction == "ADD")
                {
                    Type newObjectType = _newObject.GetType();
                    IList<PropertyInfo> newObjectProps = new List<PropertyInfo>(newObjectType.GetProperties());
                    List<FTAuthLogDtl> _ListNewAuthLogDtl = new List<FTAuthLogDtl>();

                    if (IsEnumerableType(newObjectType) || IsCollectionType(newObjectType))     //when _newObject is a Collection
                    {
                        newObjectType = _newObject.GetType().GetGenericArguments().Single();
                        newObjectProps = new List<PropertyInfo>(newObjectType.GetProperties());
                        TablePkColNm = newObjectProps.FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();

                        int child_id = 0;
                        foreach (var itemOf_newObject in (dynamic)_newObject)
                        {
                            child_id++;
                            foreach (PropertyInfo prop in newObjectProps)
                            {
                                if (prop.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary" || prop.PropertyType.Name == "List`1" || prop.PropertyType.Name == "IList`1" || prop.PropertyType.Name == "ICollection`1" || prop.PropertyType.Name == "IEnumerable`1") //check if property type is a class type || is a List type
                                {
                                    continue;
                                }
                                else
                                {
                                    var attribute = prop.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                                    if (attribute != null)
                                    {
                                        DisplayAttributeNm = attribute.Name;
                                    }

                                    FTAuthLogDtl _AuthLogDtl = new FTAuthLogDtl();
                                    _AuthLogDtl.Sl = Convert.ToString(++_max);
                                    _AuthLogDtl.LogId = _AuthLog.LogId;
                                    _AuthLogDtl.LogChildId = _LogChildId + "--" + child_id.ToString().PadLeft(6, '0');
                                    _AuthLogDtl.ModelNm = _AuthLog.ModelNm;
                                    _AuthLogDtl.TableNm = _AuthLog.TableNm;
                                    _AuthLogDtl.TableColNm = prop.Name;
                                    _AuthLogDtl.TablePkColFlag = (prop.Name.ToLower() == TablePkColNm) ? 1 : 0;
                                    _AuthLogDtl.NewValue = Convert.ToString(prop.GetValue(itemOf_newObject, null));
                                    _AuthLogDtl.DisplayTableColNm = DisplayAttributeNm;
                                    _ListNewAuthLogDtl.Add(_AuthLogDtl);
                                }
                            }
                            result = _IUoW.Repository<FTAuthLogDtl>().AddRange(_ListNewAuthLogDtl);
                        }
                    }
                    else    //when _newObject is a Object
                    {
                        TablePkColNm = newObjectProps.FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();
                        int child_id = 1;
                        foreach (PropertyInfo prop in newObjectProps)
                        {
                            if (prop.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary" || prop.PropertyType.Name == "List`1" || prop.PropertyType.Name == "IList`1" || prop.PropertyType.Name == "ICollection`1" || prop.PropertyType.Name == "IEnumerable`1") //check if property type is a class type || is a List type
                            {
                                continue;
                            }
                            else
                            {
                                var attribute = prop.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                                if (attribute != null)
                                {
                                    DisplayAttributeNm = attribute.Name;
                                }

                                FTAuthLogDtl _AuthLogDtl = new FTAuthLogDtl();
                                _AuthLogDtl.Sl = Convert.ToString(++_max);
                                _AuthLogDtl.LogId = _AuthLog.LogId;
                                _AuthLogDtl.LogChildId = (_AuthLog.PrimaryTableFlag == 1) ? string.Empty : _LogChildId + "--" + child_id.ToString().PadLeft(6, '0');
                                _AuthLogDtl.ModelNm = _AuthLog.ModelNm;
                                _AuthLogDtl.TableNm = _AuthLog.TableNm;
                                _AuthLogDtl.TableColNm = prop.Name;
                                _AuthLogDtl.TablePkColFlag = (prop.Name.ToLower() == TablePkColNm) ? 1 : 0;
                                _AuthLogDtl.NewValue = Convert.ToString(prop.GetValue(_newObject, null));
                                _AuthLogDtl.DisplayTableColNm = DisplayAttributeNm;
                                _ListNewAuthLogDtl.Add(_AuthLogDtl);
                            }
                        }
                        result = _IUoW.Repository<FTAuthLogDtl>().AddRange(_ListNewAuthLogDtl);
                    }
                }

                else if (_AuthLog.LastAction == "EDT" || _AuthLog.LastAction == "DEL")
                {
                    Type oldObjectType = _oldObject.GetType();
                    Type newObjectType = _newObject.GetType();
                    IList<PropertyInfo> oldObjectProps = new List<PropertyInfo>(oldObjectType.GetProperties());
                    IList<PropertyInfo> newObjectProps = new List<PropertyInfo>(newObjectType.GetProperties());
                    List<FTAuthLogDtl> _ListEditedAuthLogDtl = new List<FTAuthLogDtl>();

                    if (IsEnumerableType(newObjectType) || IsCollectionType(newObjectType))     //when _newObject is a Collection
                    {
                        newObjectType = _newObject.GetType().GetGenericArguments().Single();
                        oldObjectType = _oldObject.GetType().GetGenericArguments().Single();
                        newObjectProps = new List<PropertyInfo>(newObjectType.GetProperties());
                        oldObjectProps = new List<PropertyInfo>(oldObjectType.GetProperties());
                        int child_id = 0;
                        TablePkColNm = newObjectProps.FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();

                        foreach (var itemOf_newObject in (dynamic)_newObject)
                        {
                            //var newPKKey = itemOf_newObject.GetType().GetProperty(_AuthLog.TablePkColNm).GetValue(itemOf_newObject, null) == itemOf_newObject.GetType().GetProperty(_AuthLog.TablePkColNm).GetValue(itemOf_newObject, null);
                            var newPkkey = newObjectProps.FirstOrDefault(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).GetValue(itemOf_newObject, null);
                            foreach (var itemOf_oldObject in (dynamic)_oldObject)
                            {
                                var oldPkkey = oldObjectProps.FirstOrDefault(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).GetValue(itemOf_oldObject, null);
                                if (newPkkey == oldPkkey) //finding matched old and new row using row's primary key 
                                {
                                    child_id++;
                                    foreach (PropertyInfo oldObjectProp in oldObjectProps)
                                    {
                                        foreach (PropertyInfo newObjectProp in newObjectProps)
                                        {
                                            if (newObjectProp.Name == oldObjectProp.Name)
                                            {
                                                object oldObjectPropValue = oldObjectProp.GetValue(itemOf_oldObject, null);
                                                object newObjectPropValue = newObjectProp.GetValue(itemOf_newObject, null);
                                                string oldPropValue = oldObjectPropValue != null ? oldObjectPropValue.ToString().Trim() : string.Empty;
                                                string newPropValue = newObjectPropValue != null ? newObjectPropValue.ToString().Trim() : string.Empty;

                                                if (newObjectProp.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary" || newObjectProp.PropertyType.Name == "List`1" || newObjectProp.PropertyType.Name == "IList`1" || newObjectProp.PropertyType.Name == "ICollection`1" || newObjectProp.PropertyType.Name == "IEnumerable`1") //check if property type is a class type
                                                {
                                                    continue;
                                                }
                                                else if (oldPropValue == null && newPropValue == null)
                                                {
                                                    continue;
                                                }
                                                else if ((oldPropValue != newPropValue && (newPropValue != null && newPropValue != "")) || newObjectProp.Name.ToLower() == TablePkColNm)
                                                {
                                                    var attribute = newObjectProp.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                                                    if (attribute != null)
                                                    {
                                                        DisplayAttributeNm = attribute.Name;
                                                    }

                                                    FTAuthLogDtl _AuthLogDtl = new FTAuthLogDtl();
                                                    _AuthLogDtl.Sl = Convert.ToString(++_max);
                                                    _AuthLogDtl.LogId = _AuthLog.LogId;
                                                    _AuthLogDtl.LogChildId = _LogChildId + "--" + child_id.ToString().PadLeft(6, '0');
                                                    _AuthLogDtl.ModelNm = _AuthLog.ModelNm;
                                                    _AuthLogDtl.TableNm = _AuthLog.TableNm;
                                                    _AuthLogDtl.TableColNm = oldObjectProp.Name;
                                                    _AuthLogDtl.TablePkColFlag = (newObjectProp.Name.ToLower() == TablePkColNm) ? 1 : 0;
                                                    _AuthLogDtl.OldValue = oldPropValue;
                                                    _AuthLogDtl.NewValue = newPropValue;
                                                    _AuthLogDtl.DisplayTableColNm = DisplayAttributeNm;
                                                    _ListEditedAuthLogDtl.Add(_AuthLogDtl);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else  //when _newObject is a Object
                    {
                        int child_id = 1;
                        TablePkColNm = newObjectProps.FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();
                        foreach (PropertyInfo oldObjectProp in oldObjectProps)
                        {
                            foreach (PropertyInfo newObjectProp in newObjectProps)
                            {
                                if (newObjectProp.Name == oldObjectProp.Name)
                                {
                                    object oldObjectPropValue = oldObjectProp.GetValue(_oldObject, null);
                                    object newObjectPropValue = newObjectProp.GetValue(_newObject, null);
                                    string oldPropValue = oldObjectPropValue != null ? oldObjectPropValue.ToString().Trim() : string.Empty;
                                    string newPropValue = newObjectPropValue != null ? newObjectPropValue.ToString().Trim() : string.Empty;

                                    if (newObjectProp.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary" || newObjectProp.PropertyType.Name == "List`1" || newObjectProp.PropertyType.Name == "IList`1" || newObjectProp.PropertyType.Name == "ICollection`1" || newObjectProp.PropertyType.Name == "IEnumerable`1") //check if property type is a class type
                                    {
                                        continue;
                                    }
                                    //if (!IsSimple(newObjectProp.PropertyType)) //check if property type is a class type
                                    //{
                                    //    ////do nothing
                                    //}
                                    else if (oldPropValue == null && newPropValue == null)
                                    {
                                        continue;
                                    }
                                    else if ((oldPropValue != newPropValue && (newPropValue != null && newPropValue != "")) || newObjectProp.Name.ToLower() == TablePkColNm)
                                    {
                                        var attribute = newObjectProp.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                                        if (attribute != null)
                                        {
                                            DisplayAttributeNm = attribute.Name;
                                        }

                                        FTAuthLogDtl _AuthLogDtl = new FTAuthLogDtl();
                                        _AuthLogDtl.Sl = Convert.ToString(++_max);
                                        _AuthLogDtl.LogId = _AuthLog.LogId;
                                        _AuthLogDtl.LogChildId = (_AuthLog.PrimaryTableFlag == 1) ? string.Empty : _LogChildId + "--" + child_id.ToString().PadLeft(6, '0');
                                        _AuthLogDtl.ModelNm = _AuthLog.ModelNm;
                                        _AuthLogDtl.TableNm = _AuthLog.TableNm;
                                        _AuthLogDtl.TableColNm = oldObjectProp.Name;
                                        _AuthLogDtl.TablePkColFlag = (newObjectProp.Name.ToLower() == TablePkColNm) ? 1 : 0;
                                        _AuthLogDtl.OldValue = oldPropValue;
                                        _AuthLogDtl.NewValue = newPropValue;
                                        _AuthLogDtl.DisplayTableColNm = DisplayAttributeNm;
                                        _ListEditedAuthLogDtl.Add(_AuthLogDtl);
                                    }
                                }
                            }
                        }
                    }

                    result = _IUoW.Repository<FTAuthLogDtl>().AddRange(_ListEditedAuthLogDtl);
                }
                _outMaxSlAuthLogDtl = _max;
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAuthLogDtl-FT", string.Empty);
                _outMaxSlAuthLogDtl = 0;
                return result;
            }
        }
        #endregion

        #region Verify

        #region NFT
        public int VerifyAuthLog(string _LogId, string _Remarks, string _AuthStatusId, string _MakeBy, string[] SelectedAuthLogIdList)
        {
            int result = 0;
            try
            {
                _IUoW = new UnitOfWork();
                if (SelectedAuthLogIdList != null && SelectedAuthLogIdList.Length > 0)
                {
                    var _max = _IUoW.Repository<AuthLevelLog>().GetMaxValue(x => x.Sl);
                    for (int i = 0; i < SelectedAuthLogIdList.Length; i++)
                    {
                        _LogId = SelectedAuthLogIdList[i];
                        result = VerifyAuthLogData(_IUoW, _LogId, _Remarks, _AuthStatusId, _MakeBy, ++_max);
                        if (result == 0)
                            return result; //break;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(_LogId)) //when checkin from postman giving value in LogId (For ex.: "BusinessData": "{\"LogId\":\"000000001\",\"Remarks\":\"Authorized\",\"AuthStatusId\":\"A\",\"MakeBy\":\"salekin\"}", )
                {
                    var _max = _IUoW.Repository<AuthLevelLog>().GetMaxValue(x => x.Sl);
                    result = VerifyAuthLogData(_IUoW, _LogId, _Remarks, _AuthStatusId, _MakeBy, ++_max);
                }

                if (result == 1)
                {
                    _IUoW.Commit();
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "VerifyAuthLog", string.Empty);
                return result;
            }
        }
        public int VerifyAuthLogData(IUnitOfWork _IUoW, string _LogId, string _Remarks, string _AuthStatusId, string _MakeBy, long _MaxAuthLevelLogSL)
        {
            int result = 0;
            try
            {
                if (_LogId == null)
                {
                    return result;
                }
                var ListAuthLevelLog = _IUoW.Repository<AuthLevelLog>().Get(x => x.LogId == _LogId);
                var userFound = ListAuthLevelLog.Where(x => x.MakeBy == _MakeBy || x.LastAuthBy == _MakeBy).FirstOrDefault();
                if (userFound != null)
                {
                    return result; // Do not've permission to authorize.You've made the request or already authorized once.
                }

                var _ObjAuthLog = _IUoW.Repository<AuthLog>().GetBy(x => x.LogId == _LogId);
                if (_ObjAuthLog.AuthLevelPending > 0)
                {
                    //var _max = _IUoW.Repository<AuthLevelLog>().GetMaxValue(x => x.Sl) + 1;
                    var _max = _MaxAuthLevelLogSL;
                    AuthLevelLog _ObjAuthLevelLog = new AuthLevelLog();
                    _ObjAuthLevelLog.AuthLevelPending = _ObjAuthLog.AuthLevelPending - 1;
                    _ObjAuthLevelLog.Sl = _max.ToString();
                    _ObjAuthLevelLog.LogId = _ObjAuthLog.LogId;
                    _ObjAuthLevelLog.FunctionId = _ObjAuthLog.FunctionId;
                    _ObjAuthLevelLog.LastAction = _ObjAuthLog.LastAction;
                    _ObjAuthLevelLog.MakeBy = _ObjAuthLog.MakeBy;
                    _ObjAuthLevelLog.MakeDT = _ObjAuthLog.MakeDT;
                    _ObjAuthLevelLog.LastAuthBy = _MakeBy;
                    _ObjAuthLevelLog.LastAuthDT = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    _ObjAuthLevelLog.Remarks = _Remarks;
                    _ObjAuthLevelLog.LevelLogStatus = _AuthStatusId;
                    _IUoW.Repository<AuthLevelLog>().Add(_ObjAuthLevelLog);

                    if (_AuthStatusId == "A")
                    {
                        if ((_ObjAuthLog.AuthLevelPending - 1) == 0)
                        {
                            _ObjAuthLog.AuthLevelPending = 0;
                            _ObjAuthLog.AuthStatusId = "A";
                            _ObjAuthLog.LastUpdateDT = System.DateTime.Now;
                            _IUoW.Repository<AuthLog>().Update(_ObjAuthLog);

                            result = UpdateAuthLogObjectTable(_IUoW, _ObjAuthLog);
                        }
                        else
                        {
                            _ObjAuthLog.AuthLevelPending = _ObjAuthLog.AuthLevelPending - 1;
                            _ObjAuthLog.LastUpdateDT = System.DateTime.Now;
                            _IUoW.Repository<AuthLog>().Update(_ObjAuthLog);
                        }
                    }
                    else if (_AuthStatusId == "D")
                    {
                        _ObjAuthLog.AuthLevelPending = 0;
                        _ObjAuthLog.AuthStatusId = "D";
                        _ObjAuthLog.LastUpdateDT = System.DateTime.Now;
                        _IUoW.Repository<AuthLog>().Update(_ObjAuthLog);

                        result = UpdateAuthLogObjectTable(_IUoW, _ObjAuthLog);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAuthLogDtl", string.Empty);
                return result;
            }
        }
        public int UpdateAuthLogObjectTable(IUnitOfWork _IUoW, AuthLog _ObjAuthLog)  //Generic work
        {
            Type type = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == _ObjAuthLog.ModelNm);

            Type classType = typeof(AuthLogService);
            MethodInfo method = classType.GetMethod("GetTableAttributeName");
            MethodInfo generic = method.MakeGenericMethod(type);
            var tableAttributeName = (string) generic.Invoke(this, null);

            if (tableAttributeName != _ObjAuthLog.TableNm)
                return 0;
  
            MethodInfo method1 = classType.GetMethod("CallingForSpacificTable");
            MethodInfo generic1 = method1.MakeGenericMethod(type);
            int result = (int) generic1.Invoke(this, new object[] { _IUoW, _ObjAuthLog });

            #region Segrigated conditions of CP, SP, ACC
            /*
            #region CP
            if (_ObjAuthLog.TableNm == "MTK_CP_ACC_STATUS_SETUP")
            {
                return CallingForSpacificTable<AccStatusSetup>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_CURRENCY_INFO")
            {
                return CallingForSpacificTable<CurrencyInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_COUNTRY_INFO")
            {
                return CallingForSpacificTable<CountryInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_DIVISION_INFO")
            {
                return CallingForSpacificTable<DivisionInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_CITY_INFO")
            {
                return CallingForSpacificTable<CityInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_DISTRICT_INFO")
            {
                return CallingForSpacificTable<DistrictInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_UPAZILA_INFO")
            {
                return CallingForSpacificTable<UpazilaInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_AREA_INFO")
            {
                return CallingForSpacificTable<AreaInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_PS_INFO")
            {
                return CallingForSpacificTable<PSInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_BRANCH_INFO")
            {
                return CallingForSpacificTable<BranchInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_PO_INFO")
            {
                return CallingForSpacificTable<PostOfficeInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_CP_BANK_INFO")
            {
                return CallingForSpacificTable<BankInfo>(_IUoW, _ObjAuthLog);
            }
            #endregion

            #region SP
            if (_ObjAuthLog.TableNm == "MTK_SP_CUS_CATEGORY")
            {
                return CallingForSpacificTable<CusCategory>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_CUS_TYPE")
            {
                return CallingForSpacificTable<CusType>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_DEFINE_SERVICE")
            {
                return CallingForSpacificTable<DefineService>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_STATUS_WISE_SERVICE")
            {
                return CallingForSpacificTable<StatusWiseService>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_MAN_CATEGORY")
            {
                return CallingForSpacificTable<ManCategory>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_ACC_CATEGORY")
            {
                return CallingForSpacificTable<AccCategory>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_ACC_TYPE")
            {
                return CallingForSpacificTable<AccType>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_MANAGER_TYPE")
            {
                return CallingForSpacificTable<ManagerType>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_TRANSACTION_TEMPLATE")
            {
                return CallingForSpacificTable<TransactionTemplate>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_CUS_TYPE_WISE_SERVICE")
            {
                return CallingForSpacificTable<CusTypeWiseServiceList>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_TRANSACTION_RULES")
            {
                return CallingForSpacificTable<TransactionRules>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_PROMO_CODE_CONFIG")
            {
                return CallingForSpacificTable<PromoCodeConfig>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_SP_SPECIAL_OFFERS")
            {
                return CallingForSpacificTable<SpecialOffers>(_IUoW, _ObjAuthLog);
            }
            #endregion

            #region ACC
            if (_ObjAuthLog.TableNm == "MTK_ACC_INFO")
            {
                return CallingForSpacificTable<AccInfo>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_ACC_CHANNEL_PROFILE")
            {
                return CallingForSpacificTable<ChannelAccProfile>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_AM_MANAGER_PROFILE")
            {
                return CallingForSpacificTable<ManagerAccProfile>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_ACC_LIMIT_SETUP")
            {
                return CallingForSpacificTable<AccLimitSetup>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_ACC_CUSTOMER_ACC_PROFILE")
            {
                return CallingForSpacificTable<CustomerAccProfile>(_IUoW, _ObjAuthLog);
            }

            #endregion

            */
            #endregion

            return result;
        }

        public int SetTableObject<TObject>(IUnitOfWork _IUoW, AuthLog _ObjAuthLog, TObject OBJ)
        {
            int result = 0;
            int result_LedgerMaster = 0;
            int result_ChannelAccProfile = 0;
            int result_CustomerAccProfile = 0;
            int result_AccInfo = 0;
            try
            {    
                #region Channel Acc Profile
                if (_ObjAuthLog.TableNm == "MTK_ACC_CHANNEL_PROFILE")
                {
                    AccMaster OBJ_AccInfo = null;
                    ChannelAccProfile OBJ_ChannelAccProfile = null;

                    string SystemAccountNo = OBJ.GetType().GetProperty("SystemAccountNo").GetValue(OBJ, null).ToString();
                    string WalletAccountNo = OBJ.GetType().GetProperty("WalletAccountNo").GetValue(OBJ, null).ToString();
                    string BranchId = OBJ.GetType().GetProperty("BranchId").GetValue(OBJ, null) != null ? OBJ.GetType().GetProperty("BranchId").GetValue(OBJ, null).ToString() : null;
                    string AccountProfileId = OBJ.GetType().GetProperty("AccountProfileId").GetValue(OBJ, null).ToString();
                    string AccountTypeId = OBJ.GetType().GetProperty("AccountTypeId").GetValue(OBJ, null).ToString();

                    OBJ_ChannelAccProfile = _IUoW.Repository<ChannelAccProfile>().GetBy(x => x.SystemAccountNo == SystemAccountNo && x.WalletAccountNo == WalletAccountNo);
                    OBJ_AccInfo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == SystemAccountNo && x.WalletAccountNo == WalletAccountNo);

                    if (OBJ_AccInfo != null)
                    {
                        if (_ObjAuthLog.AuthStatusId == "D")
                        {
                            if (_ObjAuthLog.LastAction == "ADD")
                            {
                                SetTableObjectCommonProperty(OBJ, "D");
                                OBJ_AccInfo.AuthStatusId = "D";
                                //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                            }
                            else if (_ObjAuthLog.LastAction == "EDT")
                            {
                                SetTableObjectCommonProperty(OBJ, "A");
                                OBJ_AccInfo.AuthStatusId = "A";
                                //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                            }
                            else if (_ObjAuthLog.LastAction == "DEL")
                            {
                                SetTableObjectCommonProperty(OBJ, "A");
                                OBJ_AccInfo.AuthStatusId = "A";
                                //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                            }
                        }
                        else
                        {
                            if (_ObjAuthLog.LastAction == "ADD")
                            {
                                LedgerMaster Obj_LedgerMaster = new LedgerMaster();
                                Obj_LedgerMaster.AccProfileId = AccountProfileId;
                                Obj_LedgerMaster.AccountTypeId = AccountTypeId;
                                Obj_LedgerMaster.SystemAccountNo = SystemAccountNo;
                                Obj_LedgerMaster.OpeningBalance = 0;
                                Obj_LedgerMaster.ClosingBalance = 0;
                                Obj_LedgerMaster.AppliedProfit = null;
                                Obj_LedgerMaster.LastAppliedDate = System.DateTime.Now;
                                Obj_LedgerMaster.ProductId = null;
                                Obj_LedgerMaster.BranchId = BranchId;
                                result_LedgerMaster = _IUoW.Repository<LedgerMaster>().Add(Obj_LedgerMaster);

                                OBJ_ChannelAccProfile.AccountStatusId = "002";
                                result_ChannelAccProfile = _IUoW.Repository<ChannelAccProfile>().Update(OBJ_ChannelAccProfile);

                                OBJ_AccInfo.AuthStatusId = "A";
                                OBJ_AccInfo.AccountStatusId = "002";
                                //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                result_AccInfo = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);

                                if (result_LedgerMaster == 1 && result_ChannelAccProfile == 1 && result_AccInfo == 1)
                                {
                                    result = 1;
                                    SetTableObjectCommonProperty(OBJ, "A");
                                }
                            }
                            else if (_ObjAuthLog.LastAction == "EDT")
                            {
                                OBJ_AccInfo.WalletAccountNo = OBJ.GetType().GetProperty("WalletAccountNo").GetValue(OBJ, null).ToString();
                                OBJ_AccInfo.AccNm = OBJ.GetType().GetProperty("UserName").GetValue(OBJ, null).ToString();
                                OBJ_AccInfo.AuthStatusId = "A";
                                //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                                if (result == 1)
                                {
                                    SetTableObjectProperty(_IUoW, _ObjAuthLog, OBJ);
                                    SetTableObjectCommonProperty(OBJ, "A");
                                }
                            }
                            else if (_ObjAuthLog.LastAction == "DEL")
                            {
                                OBJ_AccInfo.AuthStatusId = "A";
                                //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                                if (result == 1)
                                {
                                    SetTableObjectCommonProperty(OBJ, "A");
                                }
                            }
                        }
                    }                    
                    return result;
                }
                #endregion

                #region Customer Acc Profile
                if (_ObjAuthLog.TableNm == "MTK_ACC_CUSTOMER_ACC_PROFILE")
                {
                    AccMaster OBJ_AccInfo = new AccMaster();
                    CustomerAccProfile OBJ_CustomerAccProfile = null;
                    string SystemAccountNo = OBJ.GetType().GetProperty("SystemAccountNo").GetValue(OBJ, null).ToString();
                    string WalletAccountNo = OBJ.GetType().GetProperty("WalletAccountNo").GetValue(OBJ, null).ToString();
                    //string Branch = OBJ.GetType().GetProperty("Branch").GetValue(OBJ, null) != null ? OBJ.GetType().GetProperty("Branch").GetValue(OBJ, null).ToString() : null;
                    string AccountProfileId = OBJ.GetType().GetProperty("AccountProfileId").GetValue(OBJ, null).ToString();
                    string UserName = OBJ.GetType().GetProperty("UserName").GetValue(OBJ, null).ToString();
                    string AccTypeId = OBJ.GetType().GetProperty("AccTypeId").GetValue(OBJ, null).ToString();

                    if(_ObjAuthLog.MainAuthFlag == "1")
                    {
                        OBJ_CustomerAccProfile = _IUoW.Repository<CustomerAccProfile>().GetBy(x => x.SystemAccountNo == SystemAccountNo && x.WalletAccountNo == WalletAccountNo);
                        OBJ_AccInfo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == SystemAccountNo && x.WalletAccountNo == WalletAccountNo);

                        if (OBJ_AccInfo != null)
                        {
                            if (_ObjAuthLog.AuthStatusId == "D")
                            {
                                if (_ObjAuthLog.LastAction == "ADD")
                                {
                                    OBJ_AccInfo.AuthStatusId = "D";
                                    OBJ_AccInfo.LastAction = "ADD";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                                    if(result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "D");
                                    }
                                }
                                else if (_ObjAuthLog.LastAction == "EDT")
                                {                                    
                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.LastAction = "EDT";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                                else if (_ObjAuthLog.LastAction == "DEL")
                                {                                    
                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.LastAction = "DEL";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                            }
                            else
                            {
                                if (_ObjAuthLog.LastAction == "ADD")
                                {
                                    //LedgerMaster Obj_LedgerMaster = new LedgerMaster();
                                    LedgerMaster Obj_LedgerMaster = null;
                                    Obj_LedgerMaster = new LedgerMaster();
                                    Obj_LedgerMaster.AccProfileId = AccountProfileId;
                                    Obj_LedgerMaster.AccountTypeId = AccTypeId;
                                    Obj_LedgerMaster.SystemAccountNo = SystemAccountNo;
                                    Obj_LedgerMaster.OpeningBalance = 0;
                                    Obj_LedgerMaster.ClosingBalance = 0;
                                    Obj_LedgerMaster.AppliedProfit = null;
                                    Obj_LedgerMaster.LastAppliedDate = System.DateTime.Now;
                                    Obj_LedgerMaster.ProductId = null;
                                    Obj_LedgerMaster.BranchId = null;
                                    result_LedgerMaster = _IUoW.Repository<LedgerMaster>().Add(Obj_LedgerMaster);

                                    OBJ_CustomerAccProfile.AccountStatusId = "002";
                                    result_CustomerAccProfile = _IUoW.Repository<CustomerAccProfile>().Update(OBJ_CustomerAccProfile);

                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.AccountStatusId = "002";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result_AccInfo = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);

                                    if (result_LedgerMaster == 1 && result_CustomerAccProfile == 1 && result_AccInfo == 1)
                                    {
                                        result = 1;
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                                else if (_ObjAuthLog.LastAction == "EDT")
                                {
                                    SetTableObjectProperty(_IUoW, _ObjAuthLog, OBJ);                                    
                                    OBJ_AccInfo.WalletAccountNo = WalletAccountNo;
                                    OBJ_AccInfo.AccNm = UserName;
                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.LastAction = "EDT";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                                else if (_ObjAuthLog.LastAction == "DEL")
                                {                                    
                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.LastAction = "DEL";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Update(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                            }
                        }
                    }
                    if (_ObjAuthLog.MainAuthFlag == "0")
                    {
                        //OBJ_AccInfo.AccountId = OBJ.GetType().GetProperty("AccIdofAccInfo").GetValue(OBJ, null).ToString();
                        var _maxAccInfoId = _IUoW.Repository<AccMaster>().GetMaxValue(x => x.AccountId) + 1;
                        OBJ_AccInfo.AccountId = _maxAccInfoId.ToString().PadLeft(3, '0');
                        //OBJ_AccInfo.AccProfileId = AccountProfileId;
                        OBJ_AccInfo.WalletAccountNo = WalletAccountNo;
                        OBJ_AccInfo.SystemAccountNo = SystemAccountNo;
                        OBJ_AccInfo.AccNm = UserName;
                        OBJ_AccInfo.AccTypeId = AccTypeId;
                        OBJ_AccInfo.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                        OBJ_AccInfo.AccountStatusId = "001";                        
                        OBJ_AccInfo.MakeDT = System.DateTime.Now;
                        OBJ_AccInfo.MakeBy = "mTaka";

                        if (OBJ_AccInfo != null)
                        {
                            if (_ObjAuthLog.AuthStatusId == "D")
                            {
                                if (_ObjAuthLog.LastAction == "ADD")
                                {                                    
                                    OBJ_AccInfo.AuthStatusId = "D";
                                    OBJ_AccInfo.LastAction = "ADD";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Add(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "D");
                                    }
                                }
                                else if (_ObjAuthLog.LastAction == "EDT")
                                {                                    
                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.LastAction = "EDT";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Add(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                                else if (_ObjAuthLog.LastAction == "DEL")
                                {                                    
                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.LastAction = "DEL";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Add(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                            }
                            else
                            {
                                if (_ObjAuthLog.LastAction == "ADD")
                                {
                                    //LedgerMaster Obj_LedgerMaster = new LedgerMaster();
                                    LedgerMaster Obj_LedgerMaster = null;
                                    Obj_LedgerMaster = new LedgerMaster();
                                    Obj_LedgerMaster.AccProfileId = AccountProfileId;
                                    Obj_LedgerMaster.AccountTypeId = AccTypeId;
                                    Obj_LedgerMaster.SystemAccountNo = SystemAccountNo;
                                    Obj_LedgerMaster.OpeningBalance = 0;
                                    Obj_LedgerMaster.ClosingBalance = 0;
                                    Obj_LedgerMaster.AppliedProfit = null;
                                    Obj_LedgerMaster.LastAppliedDate = System.DateTime.Now;
                                    Obj_LedgerMaster.ProductId = null;
                                    Obj_LedgerMaster.BranchId = null;
                                    result = _IUoW.Repository<LedgerMaster>().Add(Obj_LedgerMaster);

                                    if (result == 1)
                                    {                                        
                                        OBJ_AccInfo.AuthStatusId = "A";
                                        OBJ_AccInfo.LastAction = "ADD";
                                        //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                        result = _IUoW.Repository<AccMaster>().Add(OBJ_AccInfo);
                                        if (result == 1)
                                        {
                                            SetTableObjectCommonProperty(OBJ, "A");
                                        }
                                    }
                                }
                                else if (_ObjAuthLog.LastAction == "EDT")
                                {
                                    SetTableObjectProperty(_IUoW, _ObjAuthLog, OBJ);                                    
                                    OBJ_AccInfo.WalletAccountNo = WalletAccountNo;
                                    OBJ_AccInfo.AccNm = UserName;
                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.LastAction = "EDT";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Add(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                                else if (_ObjAuthLog.LastAction == "DEL")
                                {                                    
                                    OBJ_AccInfo.AuthStatusId = "A";
                                    OBJ_AccInfo.LastAction = "DEL";
                                    //OBJ_AccInfo.LastUpdateDT = System.DateTime.Now;
                                    result = _IUoW.Repository<AccMaster>().Add(OBJ_AccInfo);
                                    if (result == 1)
                                    {
                                        SetTableObjectCommonProperty(OBJ, "A");
                                    }
                                }
                            }
                        }
                    }          
                    return result;
                }
                #endregion

                #region For Common Tables
                else
                {
                    if (_ObjAuthLog.AuthStatusId == "D")
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "D");
                            result = 1;
                        }
                        else if (_ObjAuthLog.LastAction == "EDT")
                        {
                            SetTableObjectCommonProperty(OBJ, "A");
                            result = 1;
                        }
                        else if (_ObjAuthLog.LastAction == "DEL")
                        {
                            SetTableObjectCommonProperty(OBJ, "A");
                            result = 1;
                        }
                    }
                    else
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "A");
                            result = 1;
                        }
                        else if (_ObjAuthLog.LastAction == "EDT")
                        {
                            SetTableObjectProperty(_IUoW, _ObjAuthLog, OBJ);
                            SetTableObjectCommonProperty(OBJ, "A");
                            result = 1;
                        }
                        else if (_ObjAuthLog.LastAction == "DEL")
                        {
                            SetTableObjectCommonProperty(OBJ, "D");
                            result = 1;
                        }
                    }
                }                
                #endregion
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "SetTableObject(obj)", string.Empty);                
            }
            return result;
        }
        public static TObject SetTableObjectProperty<TObject>(IUnitOfWork _IUoW, AuthLog _ObjAuthLog, TObject OBJ)
        {
            var _ListAuthLogDtl = _IUoW.Repository<AuthLogDtl>().Get(x => x.LogId == _ObjAuthLog.LogId);
            //Type ObjectType = OBJ.GetType();
            //IList<PropertyInfo> ObjectProps = new List<PropertyInfo>(ObjectType.GetProperties());

            foreach (var log_item in _ListAuthLogDtl)
            {
                if (OBJ.GetType().GetProperty(log_item.TableColNm) != null) //true if the property exists.
                {
                    Type ObjectPropertyType = OBJ.GetType().GetProperty(log_item.TableColNm).PropertyType;
                    if (ObjectPropertyType.IsGenericType && ObjectPropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) //when property type is nullable
                    {
                        OBJ.GetType().GetProperty(log_item.TableColNm).SetValue(OBJ, Convert.ChangeType(log_item.NewValue, ObjectPropertyType.GetGenericArguments()[0]), null);
                    }
                    else
                        OBJ.GetType().GetProperty(log_item.TableColNm).SetValue(OBJ, Convert.ChangeType(log_item.NewValue, ObjectPropertyType), null);
                }
            }
            return OBJ;
        }

        public int CallingForSpacificTable<T>(IUnitOfWork _IUoW, AuthLog _ObjAuthLog) where T : class
        {
            int result = 0;
            _ObjAuthLog.MainAuthFlag = "1";
            //var TablePkColNm = typeof(T).GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();
            var _ListAuthLogDtl = _IUoW.Repository<AuthLogDtl>().Get(x => x.LogId == _ObjAuthLog.LogId);
            var _ListAuthLogDtlChild = _ListAuthLogDtl.Where(x => x.LogChildId != null && x.TablePkColFlag == 1).ToList();

            if (_ListAuthLogDtlChild != null && _ListAuthLogDtlChild.Count() > 0) //when List of object will be updated
            {
                string pk_value = string.Empty;
                for (int i = 0; i < _ListAuthLogDtlChild.Count(); i++)
                {
                    pk_value = _ListAuthLogDtlChild[i].NewValue;


                    #region Calling GetExpressionForPk method   
                    //process 1:
                    //To set the dynamic <T> type of GetExpressionForPk method bellow code is added    //Generating this lamda expresson:  x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
                    Type type = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == _ListAuthLogDtlChild[i].ModelNm);
                    Type classType = typeof(AuthLogService);
                    MethodInfo method = classType.GetMethod("GetExpressionForPk");
                    MethodInfo generic = method.MakeGenericMethod(type);
                    var lambda = generic.Invoke(this, new object[] { pk_value });

                    //Process 2:
                    //var lambda = GetExpressionForPk<T>(pk_value);    //Generating this lamda expresson:  x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
                    #endregion


                    #region Calling GetBy method to fetch individual object from table which i need to update after clicking authorization
                    //Process 1:
                    MethodInfo method1 = classType.GetMethod("GetBy");
                    MethodInfo generic1 = method1.MakeGenericMethod(type);
                    var _Obj = generic1.Invoke(this, new object[] { lambda });

                    //Process 2:
                    //var _Obj = _IUoW.Repository<T>().GetBy(lambda); 
                    #endregion


                    ////var _Obj = _IUoW.Repository<T>().GetBy(x => x.GetType().GetProperties().FirstOrDefault(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).GetValue(x, null) == pk_value);

                    if (_Obj == null)
                        return result; //result == 0

                    result = SetTableObject(_IUoW, _ObjAuthLog, _Obj);
                    if (result == 0)
                        return result;
                }
            }
            //if (!string.IsNullOrWhiteSpace(_ObjAuthLog.TablePkColVal) && _ListAuthLogDtlChild == null || !(_ListAuthLogDtlChild.Count() > 0)) //when single object will be updated
            if (!string.IsNullOrWhiteSpace(_ObjAuthLog.TablePkColVal)) //when single object will be updated
            {
                #region Calling GetExpressionForPk method   
                //process 1:
                //To set the dynamic <T> type of GetExpressionForPk method bellow code is added    //Generating this lamda expresson:  x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
                Type type = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == _ObjAuthLog.ModelNm);
                Type classType = typeof(AuthLogService);
                MethodInfo method = classType.GetMethod("GetExpressionForPk");
                MethodInfo generic = method.MakeGenericMethod(type);
                var lambda = generic.Invoke(this, new object[] { _ObjAuthLog.TablePkColVal });

                //Process 2:
                //var lambda = GetExpressionForPk<T>(_ObjAuthLog.TablePkColVal); //Generating this lamda expresson:  x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
                #endregion

                #region Calling GetBy method to fetch individual object from table which i need to update after clicking authorization
                //Process 1:
                MethodInfo method1 = classType.GetMethod("GetBy");
                MethodInfo generic1 = method1.MakeGenericMethod(type);
                var _Obj = generic1.Invoke(this, new object[] { lambda });

                //Process 2:
                //var _Obj = _IUoW.Repository<T>().GetBy(lambda); 
                #endregion

                if (_Obj == null)
                    return result; //result == 0

                result = SetTableObject(_IUoW, _ObjAuthLog, _Obj);
                if (result == 0)
                    return result;
            }
            return result;
        }
        #endregion

        #region FT
        public int VerifyAuthLog_FT(string _LogId, string _Remarks, string _AuthStatusId, string _MakeBy, string[] SelectedAuthLogIdList)
        {
            int result = 0;
            try
            {
                _IUoW = new UnitOfWork();
                if (SelectedAuthLogIdList != null && SelectedAuthLogIdList.Length > 0)
                {
                    var _max = _IUoW.Repository<FTAuthLevelLog>().GetMaxValue(x => x.Sl);
                    for (int i = 0; i < SelectedAuthLogIdList.Length; i++)
                    {
                        _LogId = SelectedAuthLogIdList[i];
                        result = VerifyAuthLogData_FT(_IUoW, _LogId, _Remarks, _AuthStatusId, _MakeBy, ++_max);
                        if (result == 0)
                            return result; //break;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(_LogId)) //when checkin from postman giving value in LogId (For ex.: "BusinessData": "{\"LogId\":\"000000001\",\"Remarks\":\"Authorized\",\"AuthStatusId\":\"A\",\"MakeBy\":\"salekin\"}", )
                {
                    var _max = _IUoW.Repository<FTAuthLevelLog>().GetMaxValue(x => x.Sl);
                    result = VerifyAuthLogData_FT(_IUoW, _LogId, _Remarks, _AuthStatusId, _MakeBy, ++_max);

                }

                if (result == 1)
                {
                    _IUoW.Commit();
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "VerifyAuthLog_FT", string.Empty);
                return result;
            }
        }
        public int VerifyAuthLogData_FT(IUnitOfWork _IUoW, string _LogId, string _Remarks, string _AuthStatusId, string _MakeBy, long _MaxAuthLevelLogSL)
        {
            int result = 0;
            try
            {
                if (_LogId == null)
                {
                    return result;
                }
                var ListAuthLevelLog = _IUoW.Repository<FTAuthLevelLog>().Get(x => x.LogId == _LogId);
                var userFound = ListAuthLevelLog.Where(x => x.MakeBy == _MakeBy || x.LastAuthBy == _MakeBy).FirstOrDefault();
                if (userFound != null)
                {
                    return result; // Do not've permission to authorize.You've made the request or already authorized once.
                }

                var _ObjAuthLog = _IUoW.Repository<FTAuthLog>().GetBy(x => x.LogId == _LogId);
                if (_ObjAuthLog.AuthLevelPending > 0)
                {
                    //var _max = _IUoW.Repository<AuthLevelLog>().GetMaxValue(x => x.Sl) + 1;
                    var _max = _MaxAuthLevelLogSL;
                    FTAuthLevelLog _ObjAuthLevelLog = new FTAuthLevelLog();
                    _ObjAuthLevelLog.AuthLevelPending = _ObjAuthLog.AuthLevelPending - 1;
                    _ObjAuthLevelLog.Sl = _max.ToString();
                    _ObjAuthLevelLog.LogId = _ObjAuthLog.LogId;
                    _ObjAuthLevelLog.FunctionId = _ObjAuthLog.FunctionId;
                    _ObjAuthLevelLog.LastAction = _ObjAuthLog.LastAction;
                    _ObjAuthLevelLog.MakeBy = _ObjAuthLog.MakeBy;
                    _ObjAuthLevelLog.MakeDT = _ObjAuthLog.MakeDT;
                    _ObjAuthLevelLog.LastAuthBy = _MakeBy;
                    _ObjAuthLevelLog.LastAuthDT = System.DateTime.Now;
                    _ObjAuthLevelLog.Remarks = _Remarks;
                    _ObjAuthLevelLog.LevelLogStatus = _AuthStatusId;
                    _IUoW.Repository<FTAuthLevelLog>().Add(_ObjAuthLevelLog);

                    if (_AuthStatusId == "A")
                    {
                        if ((_ObjAuthLog.AuthLevelPending - 1) == 0)
                        {
                            _ObjAuthLog.AuthLevelPending = 0;
                            _ObjAuthLog.AuthStatusId = "A";
                            _ObjAuthLog.LastUpdateDT = System.DateTime.Now;
                            _IUoW.Repository<FTAuthLog>().Update(_ObjAuthLog);

                            result = UpdateAuthLogObjectTable_FT(_IUoW, _ObjAuthLog);
                        }
                        else
                        {
                            _ObjAuthLog.AuthLevelPending = _ObjAuthLog.AuthLevelPending - 1;
                            _ObjAuthLog.LastUpdateDT = System.DateTime.Now;
                            _IUoW.Repository<FTAuthLog>().Update(_ObjAuthLog);
                        }
                    }
                    else if (_AuthStatusId == "D")
                    {
                        _ObjAuthLog.AuthLevelPending = 0;
                        _ObjAuthLog.AuthStatusId = "D";
                        _ObjAuthLog.LastUpdateDT = System.DateTime.Now;
                        _IUoW.Repository<FTAuthLog>().Update(_ObjAuthLog);

                        result = UpdateAuthLogObjectTable_FT(_IUoW, _ObjAuthLog);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "VerifyAuthLogData_FT", string.Empty);
                return result;
            }
        }
        public int UpdateAuthLogObjectTable_FT(IUnitOfWork _IUoW, FTAuthLog _ObjAuthLog)
        {
            Type type = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == _ObjAuthLog.ModelNm);

            Type classType = typeof(AuthLogService);
            MethodInfo method = classType.GetMethod("GetTableAttributeName");
            MethodInfo generic = method.MakeGenericMethod(type);
            var tableAttributeName = generic.Invoke(this, null);

            if (tableAttributeName.ToString() != _ObjAuthLog.TableNm)
                return 0;

            MethodInfo method1 = classType.GetMethod("CallingForSpacificTable");
            MethodInfo generic1 = method1.MakeGenericMethod(type);
            var result = generic1.Invoke(this, new object[] { _IUoW, _ObjAuthLog });

            #region TRN
            /*

            if (_ObjAuthLog.TableNm == "MTK_TRN_FUND_IN")
            {
                return CallingForSpacificTable_FT<FundIn>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_TRN_FUND_OUT")
            {
                return CallingForSpacificTable_FT<FundOut>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_TRN_CASH_IN")
            {
                return CallingForSpacificTable_FT<CashIn>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_TRN_CASH_OUT")
            {
                return CallingForSpacificTable_FT<CashOut>(_IUoW, _ObjAuthLog);
            }
            if (_ObjAuthLog.TableNm == "MTK_TRN_FUND_TRANSFER")
            {
                return CallingForSpacificTable_FT<FundTransfer>(_IUoW, _ObjAuthLog);
            }
            */
            #endregion

            return (int)result;
        }

        public int SetTableObject_FT<TObject>(IUnitOfWork _IUoW, FTAuthLog _ObjAuthLog, TObject OBJ)
        {
            int result = 0;
            int result1 = 0;
            int result2 = 0;
            int result_LedgerTxn = 0;
            int result_GlMaster = 0;
            GLMasterService OBJ_GLMasterService = new GLMasterService();
            GLMaster Obj_GLMaster = new GLMaster();
            try
            {
                #region Fund In
                if (_ObjAuthLog.TableNm == "MTK_TRN_FUND_IN")
                {
                    if (_ObjAuthLog.AuthStatusId == "D")
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "D");
                            result = 1;
                        }
                    }
                    else
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            LedgerService OBJ_ChannelLedgerService = new LedgerService();
                            LedgerTxn Obj_LedgerTxn = new LedgerTxn();
                            AccMaster obj_AccInfo_ForFromAccNo = null;
                            AccMaster obj_AccInfo_ForToAccNo = null;
                            LedgerMaster HasThisFromChannelId = null;
                            LedgerMaster HasThisToChannelId = null;
                            decimal Amount = Convert.ToDecimal(OBJ.GetType().GetProperty("Amount").GetValue(OBJ, null));
                            string functionId = _ObjAuthLog.FunctionId;
                            string amountId = "001";
                            string DefineServiceId = "001";
                            //string TransectionDate = NCORE_COB_EOD_MAP.GetTxnDate(Channel_ID);
                            //if (transectionDate == null)
                            //{
                            //    transectionDate = System.DateTime.Now.ToString("dd-MMM-yyyy");
                            //}
                            DateTime transectionDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));//transectionDate will be _ObjAuthLog.transectionDate

                            #region LedgerMaster, LedgerTxn, GLMaster, TransGL
                            string fromSystemAccountNo = OBJ.GetType().GetProperty("FromSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForFromAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == fromSystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                            string toSystemAccountNo = OBJ.GetType().GetProperty("ToSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForToAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == toSystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                            if (obj_AccInfo_ForFromAccNo != null && obj_AccInfo_ForToAccNo != null)
                            {
                                HasThisFromChannelId = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == fromSystemAccountNo);
                                HasThisToChannelId = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == toSystemAccountNo);
                                int TransectionId = 0;
                                int BatchNo = 0;
                                var MaxObj_LedgerTxn = _IUoW.Repository<LedgerTxn>().GetAll().OrderByDescending(x => x.TransectionDate).ThenByDescending(x => int.Parse(x.BatchNo)).ThenByDescending(x => int.Parse(x.Sl)).FirstOrDefault();
                                //it'll be open after adding trans date in MTK_FT_AUTH_LOG table 
                                //if (MaxObj_LedgerTxn != null && (MaxObj_LedgerTxn.TransectionDate.ToString("dd-MMM-yyyy") != _ObjAuthLog.transectionDate.ToString("dd-MMM-yyyy")))
                                //{
                                //    return result;
                                //}
                                if (MaxObj_LedgerTxn == null)
                                {
                                    TransectionId = 1;
                                    BatchNo = 1;
                                }
                                else
                                {
                                    TransectionId = Convert.ToInt32(MaxObj_LedgerTxn.Sl) + 1;
                                    BatchNo = Convert.ToInt32(MaxObj_LedgerTxn.BatchNo) + 1;
                                }
                                #region From & To Acc Ledger entry in LedgerTxn & LedgerMaster update
                                //if (HasThisFromChannelId != null && HasThisToChannelId != null
                                //    && (obj_AccInfo_ForFromAccNo.AccType == "001" || obj_AccInfo_ForFromAccNo.AccType == "002" || obj_AccInfo_ForFromAccNo.AccType == "003")
                                //    && (obj_AccInfo_ForToAccNo.AccType == "001" || obj_AccInfo_ForToAccNo.AccType == "002" || obj_AccInfo_ForToAccNo.AccType == "003"))
                                //if (HasThisFromChannelId != null && HasThisToChannelId != null)
                                //{
                                //    Obj_LedgerTxn.FromTransectionId = TransectionId.ToString();
                                //    Obj_LedgerTxn.ToTransectionId = (++TransectionId).ToString();
                                //    Obj_LedgerTxn.BatchNo = BatchNo.ToString();
                                //    //Obj_LedgerTxn.FromAccProfileId = obj_AccInfo_ForFromAccNo.AccProfileId;
                                //    //Obj_LedgerTxn.ToAccProfileId = obj_AccInfo_ForToAccNo.AccProfileId;
                                //    Obj_LedgerTxn.FromSystemAccountNo = obj_AccInfo_ForFromAccNo.SystemAccountNo;
                                //    Obj_LedgerTxn.ToSystemAccountNo = obj_AccInfo_ForToAccNo.SystemAccountNo;
                                //    Obj_LedgerTxn.FromAccountTypeId = obj_AccInfo_ForFromAccNo.AccTypeId;
                                //    Obj_LedgerTxn.ToAccountTypeId = obj_AccInfo_ForToAccNo.AccTypeId;
                                //    Obj_LedgerTxn.OpeningBalance = 0;
                                //    Obj_LedgerTxn.ClosingBalance = 0;
                                //    Obj_LedgerTxn.PaymentAmount = Amount;
                                //    Obj_LedgerTxn.ReceiveAmount = Amount;
                                //    Obj_LedgerTxn.MakeBy = OBJ.GetType().GetProperty("MakeBy").GetValue(OBJ, null).ToString();
                                //    Obj_LedgerTxn.FunctionId = _ObjAuthLog.FunctionId;
                                //    Obj_LedgerTxn.AmountId = amountId;
                                //    Obj_LedgerTxn.DefineServiceId = DefineServiceId;
                                //    Obj_LedgerTxn.Narration = "For Fund In";
                                //    Obj_LedgerTxn.TransectionDate = transectionDate;
                                //    //Obj_LedgerTxn.TransectionParentId = _ObjAuthLog.TablePkColVal;
                                //    Obj_LedgerTxn.ProductId = null;
                                //    //Obj_LedgerTxn.AppliedProfit = 0;
                                //    //Obj_LedgerTxn.ProductId = Channel.AG_BANK_ACC_NO.Substring(0, 3);
                                //    //Obj_LedgerTxn.BranchId = obj_AccInfo_ForFromAccNo.BranchId; branch id AccInfo table e felabo then okhan theke nbo
                                //    Obj_LedgerTxn.BranchId = null;
                                //    result_LedgerTxn = OBJ_ChannelLedgerService.InsertLedgerTxn(_IUoW, Obj_LedgerTxn);

                                //    #region GLMaster update & data entry in TransGL 
                                //    Obj_GLMaster.Amount = Amount;
                                //    Obj_GLMaster.DefineServiceId = DefineServiceId;
                                //    result_GlMaster = OBJ_GLMasterService.UpdateGLBalanceLCYandCCY(_IUoW, Obj_GLMaster);
                                //    if (result_LedgerTxn == 1 && result_GlMaster == 1)
                                //    {
                                //        result = 1;
                                //    }
                                //    #endregion
                                //}                               
                                #endregion
                                if (result == 1)
                                {
                                    SetTableObjectCommonProperty(OBJ, "A");
                                }
                            }
                        }
                    }
                }
                #endregion
                #endregion

                #region Fund Out
                if (_ObjAuthLog.TableNm == "MTK_TRN_FUND_OUT")
                {
                    if (_ObjAuthLog.AuthStatusId == "D")
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "D");
                            result = 1;
                        }
                    }
                    else
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            LedgerService OBJ_ChannelLedgerService = new LedgerService();
                            LedgerTxn Obj_LedgerTxn = new LedgerTxn();
                            AccMaster obj_AccInfo_ForFromAccNo = null;
                            AccMaster obj_AccInfo_ForToAccNo = null;
                            LedgerMaster HasThisFromChannelId = null;
                            LedgerMaster HasThisToChannelId = null;
                            decimal Amount = Convert.ToDecimal(OBJ.GetType().GetProperty("Amount").GetValue(OBJ, null));
                            string functionId = _ObjAuthLog.FunctionId;
                            string amountId = "002";
                            string DefineServiceId = "002";
                            //string TransectionDate = NCORE_COB_EOD_MAP.GetTxnDate(CHANNEL_ID);
                            //if (transectionDate == null)
                            //{
                            //    transectionDate = System.DateTime.Now.ToString("dd-MMM-yyyy");
                            //}
                            DateTime transectionDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));//transectionDate will be _ObjAuthLog.transectionDate

                            #region LedgerMaster, LedgerTxn, GLMaster, TransGL
                            string fromSystemAccountNo = OBJ.GetType().GetProperty("FromSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForFromAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == fromSystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                            string toSystemAccountNo = OBJ.GetType().GetProperty("ToSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForToAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == toSystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                            if (obj_AccInfo_ForFromAccNo != null && obj_AccInfo_ForToAccNo != null)
                            {
                                HasThisFromChannelId = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == fromSystemAccountNo);
                                HasThisToChannelId = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == toSystemAccountNo);
                                int TransectionId = 0;
                                int BatchNo = 0;
                                var MaxObj_LedgerTxn = _IUoW.Repository<LedgerTxn>().GetAll().OrderByDescending(x => x.TransectionDate).ThenByDescending(x => int.Parse(x.BatchNo)).ThenByDescending(x => int.Parse(x.Sl)).FirstOrDefault();
                                //it'll be open after adding trans date in MTK_FT_AUTH_LOG table 
                                //if (MaxObj_LedgerTxn != null && (MaxObj_LedgerTxn.TransectionDate.ToString("dd-MMM-yyyy") != _ObjAuthLog.transectionDate.ToString("dd-MMM-yyyy")))
                                //{
                                //    return result;
                                //}
                                if (MaxObj_LedgerTxn == null)
                                {
                                    TransectionId = 1;
                                    BatchNo = 1;
                                }
                                else
                                {
                                    TransectionId = Convert.ToInt32(MaxObj_LedgerTxn.Sl) + 1;
                                    BatchNo = Convert.ToInt32(MaxObj_LedgerTxn.BatchNo) + 1;
                                }
                                #region From & To Acc Ledger entry in LedgerTxn & LedgerMaster update
                                //if (HasThisFromChannelId != null && HasThisToChannelId != null
                                //    && (obj_AccInfo_ForFromAccNo.AccType == "001" || obj_AccInfo_ForFromAccNo.AccType == "002" || obj_AccInfo_ForFromAccNo.AccType == "003")                                    
                                //    && (obj_AccInfo_ForToAccNo.AccType == "001" || obj_AccInfo_ForToAccNo.AccType == "002" || obj_AccInfo_ForToAccNo.AccType == "003"))
                                //if (HasThisFromChannelId != null && HasThisToChannelId != null)
                                //{
                                //    Obj_LedgerTxn.FromTransectionId = TransectionId.ToString();
                                //    Obj_LedgerTxn.ToTransectionId = (++TransectionId).ToString();
                                //    Obj_LedgerTxn.BatchNo = BatchNo.ToString();
                                //    //Obj_LedgerTxn.FromAccProfileId = obj_AccInfo_ForToAccNo.AccProfileId;
                                //    //Obj_LedgerTxn.ToAccProfileId = obj_AccInfo_ForFromAccNo.AccProfileId;
                                //    Obj_LedgerTxn.FromSystemAccountNo = obj_AccInfo_ForToAccNo.SystemAccountNo;
                                //    Obj_LedgerTxn.ToSystemAccountNo = obj_AccInfo_ForFromAccNo.SystemAccountNo;
                                //    Obj_LedgerTxn.FromAccountTypeId = obj_AccInfo_ForToAccNo.AccTypeId;
                                //    Obj_LedgerTxn.ToAccountTypeId = obj_AccInfo_ForFromAccNo.AccTypeId;
                                //    Obj_LedgerTxn.OpeningBalance = 0;
                                //    Obj_LedgerTxn.ClosingBalance = 0;
                                //    Obj_LedgerTxn.PaymentAmount = Amount;
                                //    Obj_LedgerTxn.ReceiveAmount = Amount;
                                //    Obj_LedgerTxn.MakeBy = OBJ.GetType().GetProperty("MakeBy").GetValue(OBJ, null).ToString();
                                //    Obj_LedgerTxn.FunctionId = _ObjAuthLog.FunctionId;
                                //    Obj_LedgerTxn.AmountId = amountId;
                                //    Obj_LedgerTxn.DefineServiceId = DefineServiceId;
                                //    Obj_LedgerTxn.Narration = "For Fund Out";
                                //    Obj_LedgerTxn.TransectionDate = transectionDate;
                                //    //Obj_LedgerTxn.TransectionParentId = _ObjAuthLog.TablePkColVal;
                                //    Obj_LedgerTxn.ProductId = null;
                                //    //Obj_LedgerTxn.AppliedProfit = 0;
                                //    //Obj_LedgerTxn.ProductId = Channel.AG_BANK_ACC_NO.Substring(0, 3);
                                //    //Obj_LedgerTxn.BranchId = obj_AccInfo_ForFromAccNo.BranchId; branch id AccInfo table e felabo then okhan theke nbo
                                //    Obj_LedgerTxn.BranchId = null;
                                //    result_LedgerTxn = OBJ_ChannelLedgerService.InsertLedgerTxn(_IUoW, Obj_LedgerTxn);

                                //    #region GLMaster update & data entry in TransGL 
                                //    Obj_GLMaster.Amount = Amount;
                                //    Obj_GLMaster.DefineServiceId = DefineServiceId;
                                //    result_GlMaster = OBJ_GLMasterService.UpdateGLBalanceLCYandCCY(_IUoW, Obj_GLMaster);
                                //    if (result_LedgerTxn == 1 && result_GlMaster == 1)
                                //    {
                                //        result = 1;
                                //    }
                                //    #endregion                                    
                                //}
                                #endregion
                                if (result == 1)
                                {
                                    SetTableObjectCommonProperty(OBJ, "A");
                                }
                            }
                        }
                    }
                }
                            #endregion
                #endregion

                #region Cash In
                if (_ObjAuthLog.TableNm == "MTK_TRN_CASH_IN")
                {
                    if (_ObjAuthLog.AuthStatusId == "D")
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "D");
                            result = 1;
                        }
                    }
                    else
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            LedgerService OBJ_ChannelLedgerService = new LedgerService();
                            LedgerTxn Obj_LedgerTxn = new LedgerTxn();
                            TransactionTemplate Obj_TransactionTemplate = new TransactionTemplate();
                            AccMaster obj_AccInfo_ForFromAccNo = null;
                            AccMaster obj_AccInfo_ForToAccNo = null;
                            LedgerMaster HasThisFromChannelId = null;
                            LedgerMaster HasThisToChannelId = null;
                            decimal Amount = Convert.ToDecimal(OBJ.GetType().GetProperty("Amount").GetValue(OBJ, null));
                            string Narration = OBJ.GetType().GetProperty("Narration").GetValue(OBJ, null).ToString();
                            string functionId = _ObjAuthLog.FunctionId;
                            string amountId = "003";
                            string DefineServiceId = "003";
                            //string TransectionDate = NCORE_COB_EOD_MAP.GetTxnDate(CHANNEL_ID);
                            //if (transectionDate == null)
                            //{
                            //    transectionDate = System.DateTime.Now.ToString("dd-MMM-yyyy");
                            //}
                            DateTime transectionDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));//transectionDate will be _ObjAuthLog.transectionDate

                            #region LedgerMaster, LedgerTxn, GLMaster, TransGL
                            string fromSystemAccountNo = OBJ.GetType().GetProperty("FromSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForFromAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == fromSystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                            string toSystemAccountNo = OBJ.GetType().GetProperty("ToSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForToAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == toSystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                            if (obj_AccInfo_ForFromAccNo != null && obj_AccInfo_ForToAccNo != null)
                            {
                                HasThisFromChannelId = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == fromSystemAccountNo);
                                HasThisToChannelId = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == toSystemAccountNo);
                                int TransectionId = 0;
                                int BatchNo = 0;
                                var MaxObj_LedgerTxn = _IUoW.Repository<LedgerTxn>().GetAll().OrderByDescending(x => x.TransectionDate).ThenByDescending(i => int.Parse(i.BatchNo)).ThenByDescending(x => int.Parse(x.Sl)).FirstOrDefault();
                               
                                //it'll be open after adding trans date in MTK_FT_AUTH_LOG table 
                                //if (MaxObj_LedgerTxn != null && (MaxObj_LedgerTxn.TransectionDate.ToString("dd-MMM-yyyy") != _ObjAuthLog.transectionDate.ToString("dd-MMM-yyyy")))
                                //{
                                //    return result;
                                //}
                                if (MaxObj_LedgerTxn == null)
                                {
                                    TransectionId = 1;
                                    BatchNo = 1;
                                }
                                else
                                {
                                    TransectionId = Convert.ToInt32(MaxObj_LedgerTxn.Sl) + 1;
                                    BatchNo = Convert.ToInt32(MaxObj_LedgerTxn.BatchNo) + 1;
                                }
                                #region From & To Acc Ledger entry in LedgerTxn & LedgerMaster update
                                //if (HasThisFromChannelId != null && HasThisToChannelId != null && obj_AccInfo_ForFromAccNo.AccType == "003" && obj_AccInfo_ForToAccNo.AccType == "004")
                                if (HasThisFromChannelId != null && HasThisToChannelId != null)
                                //{
                                //    Obj_LedgerTxn.FromTransectionId = TransectionId.ToString();
                                //    Obj_LedgerTxn.ToTransectionId = (++TransectionId).ToString();
                                //    Obj_LedgerTxn.BatchNo = BatchNo.ToString();
                                //    //Obj_LedgerTxn.FromAccProfileId = obj_AccInfo_ForFromAccNo.AccProfileId;
                                //    //Obj_LedgerTxn.ToAccProfileId = obj_AccInfo_ForToAccNo.AccProfileId;
                                //    Obj_LedgerTxn.FromSystemAccountNo = obj_AccInfo_ForFromAccNo.SystemAccountNo;
                                //    Obj_LedgerTxn.ToSystemAccountNo = obj_AccInfo_ForToAccNo.SystemAccountNo;
                                //    Obj_LedgerTxn.FromAccountTypeId = obj_AccInfo_ForFromAccNo.AccTypeId;
                                //    Obj_LedgerTxn.ToAccountTypeId = obj_AccInfo_ForToAccNo.AccTypeId;
                                //    Obj_LedgerTxn.OpeningBalance = 0;
                                //    Obj_LedgerTxn.ClosingBalance = 0;
                                //    Obj_LedgerTxn.PaymentAmount = Amount;
                                //    Obj_LedgerTxn.ReceiveAmount = Amount;
                                //    Obj_LedgerTxn.MakeBy = OBJ.GetType().GetProperty("MakeBy").GetValue(OBJ, null).ToString();
                                //    Obj_LedgerTxn.FunctionId = _ObjAuthLog.FunctionId;
                                //    Obj_LedgerTxn.AmountId = amountId;
                                //    Obj_LedgerTxn.DefineServiceId = DefineServiceId;
                                //    Obj_LedgerTxn.Narration = "For Cash In";
                                //    Obj_LedgerTxn.TransectionDate = transectionDate;
                                //    //Obj_LedgerTxn.TransectionParentId = _ObjAuthLog.TablePkColVal;
                                //    Obj_LedgerTxn.ProductId = null;
                                //    //Obj_LedgerTxn.AppliedProfit = 0;
                                //    //Obj_LedgerTxn.ProductId = Channel.AG_BANK_ACC_NO.Substring(0, 3);
                                //    //Obj_LedgerTxn.BranchId = obj_AccInfo_ForFromAccNo.BranchId; branch id AccInfo table e felabo then okhan theke nbo
                                //    Obj_LedgerTxn.BranchId = null;
                                //    result_LedgerTxn = OBJ_ChannelLedgerService.InsertLedgerTxn(_IUoW, Obj_LedgerTxn);

                                //    #region GLMaster update & data entry in TransGL 
                                //    Obj_GLMaster.Amount = Amount;
                                //    Obj_GLMaster.DefineServiceId = DefineServiceId;
                                //    Obj_GLMaster.Narration = Narration;
                                //    result_GlMaster = OBJ_GLMasterService.UpdateGLBalanceLCYandCCY(_IUoW, Obj_GLMaster);
                                //    if (result_LedgerTxn == 1 && result_GlMaster == 1)
                                //    {
                                //        result = 1;
                                //    }
                                //    #endregion
                                //}
                                #endregion
                                if (result == 1)
                                {
                                    SetTableObjectCommonProperty(OBJ, "A");
                                }
                            }
                        }
                    }
                }
                            #endregion
                #endregion

                #region Cash Out
                if (_ObjAuthLog.TableNm == "MTK_TRN_CASH_OUT")
                {
                    if (_ObjAuthLog.AuthStatusId == "D")
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "D");
                            result = 1;
                        }
                    }
                    else
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            LedgerService OBJ_ChannelLedgerService = new LedgerService();
                            LedgerTxn Obj_LedgerTxn = new LedgerTxn();
                            AccMaster obj_AccInfo_ForFromAccNo = null;
                            AccMaster obj_AccInfo_ForToAccNo = null;
                            LedgerMaster HasThisFromChannelId = null;
                            LedgerMaster HasThisToChannelId = null;
                            decimal Amount = Convert.ToDecimal(OBJ.GetType().GetProperty("Amount").GetValue(OBJ, null));
                            string Narration = OBJ.GetType().GetProperty("Narration").GetValue(OBJ, null).ToString();
                            string functionId = _ObjAuthLog.FunctionId;
                            string amountId = "004";
                            string DefineServiceId = "004";
                            //string TransectionDate = NCORE_COB_EOD_MAP.GetTxnDate(Channel_ID);
                            //if (transectionDate == null)
                            //{
                            //    transectionDate = System.DateTime.Now.ToString("dd-MMM-yyyy");
                            //}
                            DateTime transectionDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));//transectionDate will be _ObjAuthLog.transectionDate

                            #region LedgerMaster, LedgerTxn, GLMaster, TransGL
                            string fromSystemAccountNo = OBJ.GetType().GetProperty("FromSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForFromAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == fromSystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                            string toSystemAccountNo = OBJ.GetType().GetProperty("ToSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForToAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.SystemAccountNo == toSystemAccountNo
                                && x.AuthStatusId == "A"
                                && x.LastAction != "DEL");
                            if (obj_AccInfo_ForFromAccNo != null && obj_AccInfo_ForToAccNo != null)
                            {
                                HasThisFromChannelId = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == fromSystemAccountNo);
                                HasThisToChannelId = _IUoW.Repository<LedgerMaster>().GetBy(x => x.SystemAccountNo == toSystemAccountNo);
                                int TransectionId = 0;
                                int BatchNo = 0;
                                var MaxObj_LedgerTxn = _IUoW.Repository<LedgerTxn>().GetAll().OrderByDescending(x => x.TransectionDate).ThenByDescending(i => int.Parse(i.BatchNo)).ThenByDescending(x => int.Parse(x.Sl)).FirstOrDefault();
                                //it'll be open after adding trans date in MTK_FT_AUTH_LOG table 
                                //if (MaxObj_LedgerTxn != null && (MaxObj_LedgerTxn.TransectionDate.ToString("dd-MMM-yyyy") != _ObjAuthLog.transectionDate.ToString("dd-MMM-yyyy")))
                                //{
                                //    return result;
                                //}
                                if (MaxObj_LedgerTxn == null)
                                {
                                    TransectionId = 1;
                                    BatchNo = 1;
                                }
                                else
                                {
                                    TransectionId = Convert.ToInt32(MaxObj_LedgerTxn.Sl) + 1;
                                    BatchNo = Convert.ToInt32(MaxObj_LedgerTxn.BatchNo) + 1;
                                }
                                #region From & To Acc Ledger entry in LedgerTxn & LedgerMaster update
                                //if (HasThisFromChannelId != null && HasThisToChannelId != null && obj_AccInfo_ForFromAccNo.AccType == "003" && obj_AccInfo_ForToAccNo.AccType == "004")
                                //if (HasThisFromChannelId != null && HasThisToChannelId != null)
                                //{
                                //    Obj_LedgerTxn.FromTransectionId = TransectionId.ToString();
                                //    Obj_LedgerTxn.ToTransectionId = (++TransectionId).ToString();
                                //    Obj_LedgerTxn.BatchNo = BatchNo.ToString();
                                //    //Obj_LedgerTxn.FromAccProfileId = obj_AccInfo_ForToAccNo.AccProfileId;
                                //    //Obj_LedgerTxn.ToAccProfileId = obj_AccInfo_ForFromAccNo.AccProfileId;
                                //    Obj_LedgerTxn.FromSystemAccountNo = obj_AccInfo_ForToAccNo.SystemAccountNo;
                                //    Obj_LedgerTxn.ToSystemAccountNo = obj_AccInfo_ForFromAccNo.SystemAccountNo;
                                //    Obj_LedgerTxn.FromAccountTypeId = obj_AccInfo_ForToAccNo.AccTypeId;
                                //    Obj_LedgerTxn.ToAccountTypeId = obj_AccInfo_ForFromAccNo.AccTypeId; 
                                //    Obj_LedgerTxn.OpeningBalance = 0;
                                //    Obj_LedgerTxn.ClosingBalance = 0;
                                //    Obj_LedgerTxn.PaymentAmount = Convert.ToDecimal(OBJ.GetType().GetProperty("Amount").GetValue(OBJ, null));
                                //    Obj_LedgerTxn.ReceiveAmount = Convert.ToDecimal(OBJ.GetType().GetProperty("Amount").GetValue(OBJ, null));
                                //    Obj_LedgerTxn.MakeBy = OBJ.GetType().GetProperty("MakeBy").GetValue(OBJ, null).ToString();
                                //    Obj_LedgerTxn.FunctionId = _ObjAuthLog.FunctionId;
                                //    Obj_LedgerTxn.AmountId = amountId;
                                //    Obj_LedgerTxn.DefineServiceId = DefineServiceId;
                                //    Obj_LedgerTxn.Narration = "For Cash Out";
                                //    Obj_LedgerTxn.TransectionDate = transectionDate;
                                //    //Obj_LedgerTxn.TransectionParentId = _ObjAuthLog.TablePkColVal;
                                //    Obj_LedgerTxn.ProductId = null;
                                //    //Obj_LedgerTxn.AppliedProfit = 0;
                                //    //Obj_LedgerTxn.ProductId = Channel.AG_BANK_ACC_NO.Substring(0, 3);
                                //    //Obj_LedgerTxn.BranchId = obj_AccInfo_ForFromAccNo.BranchId; branch id AccInfo table e felabo then okhan theke nbo
                                //    Obj_LedgerTxn.BranchId = null;
                                //    result_LedgerTxn = OBJ_ChannelLedgerService.InsertLedgerTxn(_IUoW, Obj_LedgerTxn);

                                //    #region GLMaster update & data entry in TransGL 
                                //    Obj_GLMaster.Amount = Amount;
                                //    Obj_GLMaster.DefineServiceId = DefineServiceId;
                                //    Obj_GLMaster.Narration = Narration;
                                //    result_GlMaster = OBJ_GLMasterService.UpdateGLBalanceLCYandCCY(_IUoW, Obj_GLMaster);
                                //    if (result_LedgerTxn == 1 && result_GlMaster == 1)
                                //    {
                                //        result = 1;
                                //    }
                                //    #endregion
                                //}
                                #endregion
                                if (result == 1)
                                {
                                    SetTableObjectCommonProperty(OBJ, "A");
                                }
                            }
                        }
                    }
                }
                #endregion
                #endregion

                #region Fund Transfer
                if (_ObjAuthLog.TableNm == "MTK_TRN_FUND_TRANSFER")
                {
                    if (_ObjAuthLog.AuthStatusId == "D")
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "D");
                            result = 1;
                        }
                    }
                    else
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "A");
                            result = 1;
                        }
                    }
                }
                #endregion

                #region Utility Bill Collection
                if (_ObjAuthLog.TableNm == "MTK_USB_COLLECTION")
                {
                    if (_ObjAuthLog.AuthStatusId == "D")
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            SetTableObjectCommonProperty(OBJ, "D");
                            result = 1;
                        }
                    }
                    else
                    {
                        if (_ObjAuthLog.LastAction == "ADD")
                        {
                            LedgerService OBJ_ChannelLedgerService = new LedgerService();
                            LedgerTxn Obj_LedgerTxn = new LedgerTxn();
                            AccMaster obj_AccInfo_ForFromAccNo = null;

                            decimal Amount = Convert.ToDecimal(OBJ.GetType().GetProperty("totalBillAmount").GetValue(OBJ, null));
                            string functionId = _ObjAuthLog.FunctionId;
                            string amountId = "003";
                            string DefineServiceId = "003";

                            //DateTime transectionDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));//transectionDate will be _ObjAuthLog.transectionDate
                            DateTime transectionDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            #region LedgerMaster, LedgerTxn, GLMaster, TransGL

                            string fromSystemAccountNo = OBJ.GetType().GetProperty("FromSystemAccountNo").GetValue(OBJ, null).ToString();
                            obj_AccInfo_ForFromAccNo = _IUoW.Repository<AccMaster>().GetBy(x => x.WalletAccountNo == fromSystemAccountNo
                                                                                                && x.AuthStatusId == "A"
                                                                                                && x.LastAction != "DEL");
                            int TransectionId = 0;
                            int BatchNo = 0;
                            var MaxObj_LedgerTxn = _IUoW.Repository<LedgerTxn>().GetAll().OrderByDescending(x => x.TransectionDate).ThenByDescending(i => int.Parse(i.BatchNo)).ThenByDescending(x => int.Parse(x.Sl)).FirstOrDefault();

                            if (MaxObj_LedgerTxn == null)
                            {
                                TransectionId = 1;
                                BatchNo = 1;
                            }
                            else
                            {
                                TransectionId = Convert.ToInt32(MaxObj_LedgerTxn.Sl) + 1;
                                BatchNo = Convert.ToInt32(MaxObj_LedgerTxn.BatchNo) + 1;
                            }

                            #region From & To Acc Ledger entry in LedgerTxn & LedgerMaster update

                            var ClosingBalance = _IUoW.Repository<LedgerMaster>().Get(a => a.SystemAccountNo == obj_AccInfo_ForFromAccNo.SystemAccountNo).Select(s => s.ClosingBalance).ToList();

                            //Obj_LedgerTxn.AccProfileId = obj_AccInfo_ForFromAccNo.AccProfileId;
                            Obj_LedgerTxn.FromTransectionId = TransectionId.ToString();
                            Obj_LedgerTxn.BatchNo = BatchNo.ToString();
                            //Obj_LedgerTxn.FromAccProfileId = obj_AccInfo_ForFromAccNo.AccProfileId;
                            Obj_LedgerTxn.ToAccProfileId = null;
                            Obj_LedgerTxn.SystemAccountNo = obj_AccInfo_ForFromAccNo.SystemAccountNo;
                            Obj_LedgerTxn.SystemAccountNo = null;
                            Obj_LedgerTxn.FromAccountTypeId = obj_AccInfo_ForFromAccNo.AccTypeId;
                            Obj_LedgerTxn.ToAccountTypeId = null;
                            Obj_LedgerTxn.OpeningBalance = 0;
                            Obj_LedgerTxn.ClosingBalance = ClosingBalance[0]-Amount;
                            Obj_LedgerTxn.Amount = Amount;
                            Obj_LedgerTxn.AccBalance = ClosingBalance[0] - Amount;
                            //Obj_LedgerTxn.ReceiveAmount = 0;
                            Obj_LedgerTxn.MakeBy = OBJ.GetType().GetProperty("MakeBy").GetValue(OBJ, null).ToString();
                            Obj_LedgerTxn.FunctionId = _ObjAuthLog.FunctionId;
                            //Obj_LedgerTxn.AmountId = amountId;
                            Obj_LedgerTxn.DefineServiceId = OBJ.GetType().GetProperty("PvId").GetValue(OBJ, null).ToString();
                            Obj_LedgerTxn.Narration = "Utility Bill";
                            Obj_LedgerTxn.TransectionDate = transectionDate;
                            //Obj_LedgerTxn.TransectionParentId = _ObjAuthLog.TablePkColVal;
                            //Obj_LedgerTxn.ProductId = null;
                            //Obj_LedgerTxn.BranchId = null;
                            //result_LedgerTxn = OBJ_ChannelLedgerService.InsertLedgerTxn(_IUoW, Obj_LedgerTxn);

                            #endregion
                            
                            if (result_LedgerTxn == 1)
                            {
                                return result_LedgerTxn;
                            }
                        }
                    }
                }
                #endregion
                #endregion
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "SetTableObject_FT(obj)", string.Empty);                
            }
            return result;
        }
        public static TObject SetTableObjectProperty_FT<TObject>(IUnitOfWork _IUoW, FTAuthLog _ObjAuthLog, TObject OBJ)
        {
            var _ListAuthLogDtl = _IUoW.Repository<FTAuthLogDtl>().Get(x => x.LogId == _ObjAuthLog.LogId);
            //Type ObjectType = OBJ.GetType();
            //IList<PropertyInfo> ObjectProps = new List<PropertyInfo>(ObjectType.GetProperties());

            foreach (var log_item in _ListAuthLogDtl)
            {
                if (OBJ.GetType().GetProperty(log_item.TableColNm) != null) //true if the property exists.
                {
                    Type ObjectPropertyType = OBJ.GetType().GetProperty(log_item.TableColNm).PropertyType;
                    if (ObjectPropertyType.IsGenericType && ObjectPropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) //when property type is nullable
                    {
                        OBJ.GetType().GetProperty(log_item.TableColNm).SetValue(OBJ, Convert.ChangeType(log_item.NewValue, ObjectPropertyType.GetGenericArguments()[0]), null);
                    }
                    else
                        OBJ.GetType().GetProperty(log_item.TableColNm).SetValue(OBJ, Convert.ChangeType(log_item.NewValue, ObjectPropertyType), null);
                }
            }
            return OBJ;
        }

        public int CallingForSpacificTable_FT<T>(IUnitOfWork _IUoW, FTAuthLog _ObjAuthLog) where T : class
        {
            int result = 0;
            //var TablePkColNm = typeof(T).GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name.ToLower();
            var _ListAuthLogDtl = _IUoW.Repository<FTAuthLogDtl>().Get(x => x.LogId == _ObjAuthLog.LogId);
            var _ListAuthLogDtlChild = _ListAuthLogDtl.Where(x => x.LogChildId != null && x.TablePkColFlag == 1).ToList();

            if (_ListAuthLogDtlChild != null && _ListAuthLogDtlChild.Count() > 0) //when List of object will be updated
            {
                string pk_value = string.Empty;
                for (int i = 0; i < _ListAuthLogDtlChild.Count(); i++)
                {
                    pk_value = _ListAuthLogDtlChild[i].NewValue;


                    #region Calling GetExpressionForPk method   
                    //process 1:
                    //To set the dynamic <T> type of GetExpressionForPk method bellow code is added    //Generating this lamda expresson:  x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
                    Type type = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == _ListAuthLogDtlChild[i].ModelNm);
                    Type classType = typeof(AuthLogService);
                    MethodInfo method = classType.GetMethod("GetExpressionForPk");
                    MethodInfo generic = method.MakeGenericMethod(type);
                    var lambda = generic.Invoke(this, new object[] { pk_value });

                    //Process 2:
                    //var lambda = GetExpressionForPk<T>(pk_value);  //Generating this lamda expresson:  x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
                    #endregion


                    #region Calling GetBy method to fetch individual object from table which i need to update after clicking authorization
                    //Process 1:
                    MethodInfo method1 = classType.GetMethod("GetBy");
                    MethodInfo generic1 = method1.MakeGenericMethod(type);
                    var _Obj = generic1.Invoke(this, new object[] { lambda });

                    //Process 2:
                    //var _Obj = _IUoW.Repository<T>().GetBy(lambda); 
                    #endregion


                    //var _Obj = _IUoW.Repository<T>().GetBy(x => x.GetType().GetProperties().FirstOrDefault(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).GetValue(x, null) == pk_value);

                    if (_Obj == null)
                        return result; //result == 0

                    result = SetTableObject_FT(_IUoW, _ObjAuthLog, _Obj);
                    if (result == 0)
                        return result;
                }
            }
            //if (!string.IsNullOrWhiteSpace(_ObjAuthLog.TablePkColVal) && _ListAuthLogDtlChild == null || !(_ListAuthLogDtlChild.Count() > 0)) //when single object will be updated
            if (!string.IsNullOrWhiteSpace(_ObjAuthLog.TablePkColVal)) //when single object will be updated
            {
                #region Calling GetExpressionForPk method   
                //process 1:
                //To set the dynamic <T> type of GetExpressionForPk method bellow code is added    //Generating this lamda expresson:  x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
                Type type = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == _ObjAuthLog.ModelNm);
                Type classType = typeof(AuthLogService);
                MethodInfo method = classType.GetMethod("GetExpressionForPk");
                MethodInfo generic = method.MakeGenericMethod(type);
                var lambda = generic.Invoke(this, new object[] { _ObjAuthLog.TablePkColVal });

                //Process 2:
                //var lambda = GetExpressionForPk<T>(_ObjAuthLog.TablePkColVal); //Generating this lamda expresson:  x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
                #endregion

                #region Calling GetBy method to fetch individual object from table which i need to update after clicking authorization
                //Process 1:
                MethodInfo method1 = classType.GetMethod("GetBy");
                MethodInfo generic1 = method1.MakeGenericMethod(type);
                var _Obj = generic1.Invoke(this, new object[] { lambda });

                //Process 2:
                //var _Obj = _IUoW.Repository<T>().GetBy(lambda); 
                #endregion

                if (_Obj == null)
                    return result; //result == 0

                result = SetTableObject_FT(_IUoW, _ObjAuthLog, _Obj);
                if (result == 0)
                    return result; 
            }
            return result;
        }
        #endregion

        public static TObject SetTableObjectCommonProperty<TObject>(TObject OBJ, string _pASSIGNED_AUTH_STATUS_ID)
        {
            if (OBJ.GetType().GetProperty("AuthStatusId") != null)
                OBJ.GetType().GetProperty("AuthStatusId").SetValue(OBJ, _pASSIGNED_AUTH_STATUS_ID, null);
            OBJ.GetType().GetProperty("LastUpdateDT").SetValue(OBJ, DateTime.Now, null);
            return OBJ;
        }
        public static Expression<Func<T, bool>> GetExpressionForPk<T>(string TablePkColVal)
        {
            string TablePkColNm = typeof(T).GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0).Name;
            //var _KeyList = typeof(T).GetProperties().Where(prop => prop.IsDefined(typeof(KeyAttribute))).ToList();   //Get List of KeyAttribute
            var param = Expression.Parameter(typeof(T), "x");           //x =>
            var len = Expression.PropertyOrField(param, TablePkColNm);  //x => x.TablePkColNm
            var body = Expression.Equal(len, Expression.Constant(TablePkColVal));  //x => x.TablePkColNm = _ObjAuthLog.TablePkColVal
            var lambda = (Expression<Func<T, bool>>)Expression.Lambda(body, param);
            return lambda;
        }
        #endregion

        #region DropDown
        public IEnumerable<SelectListItem> GetNftAuthLogFunctionsForDD()
        {
            try
            {
                _IUoW = new UnitOfWork();
                List<GetMFSMenuResult> LIST_GetMFSMenuResult = new List<GetMFSMenuResult>();
                var List_AuthLogFunctions = _IUoW.Repository<AuthLog>().GetBy(x => x.AuthStatusId == "U" &&
                                                                                   x.LastAction != "DEL", n => new { n.FunctionId }).GroupBy(x => x.FunctionId).Select(x => x.Key).ToList();

                if (!(List_AuthLogFunctions.Count > 0))
                {
                    return null;
                }

                string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetMFSMenu/09?format=json";
                using (WebClient wc = new WebClient())
                {
                    MenuService OBJ_GetMFSMenuResult = new MenuService();    //commented for temporary time by salekin
                    var json = wc.DownloadString(url);
                    OBJ_GetMFSMenuResult = JsonConvert.DeserializeObject<MenuService>(json);
                    LIST_GetMFSMenuResult = OBJ_GetMFSMenuResult.GetMFSMenuResult;
                }
                if (LIST_GetMFSMenuResult == null)
                {
                    return null;
                }

                var selectList = new List<SelectListItem>();
                for (int i = 0; i < List_AuthLogFunctions.Count(); i++)
                {
                    for (int j = 0; j < LIST_GetMFSMenuResult.Count(); j++)
                    {
                        if (LIST_GetMFSMenuResult[j].FUNCTION_ID != null && (List_AuthLogFunctions[i] == LIST_GetMFSMenuResult[j].FUNCTION_ID.ToString()))
                        {
                            selectList.Add(new SelectListItem
                            {
                                Value = LIST_GetMFSMenuResult[j].FUNCTION_ID.ToString(),
                                Text = LIST_GetMFSMenuResult[j].NAME
                            });
                        }
                    }
                }
                if (selectList != null)
                    return selectList;
                else
                    return null;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetNftAuthLogFunctionsForDD()", string.Empty);
                return null;
            }
        }
        public IEnumerable<SelectListItem> GetFtAuthLogFunctionsForDD()
        {
            try
            {
                _IUoW = new UnitOfWork();
                List<GetMFSMenuResult> LIST_GetMFSMenuResult = new List<GetMFSMenuResult>();
                var List_AuthLogFunctions = _IUoW.Repository<FTAuthLog>().GetBy(x => x.AuthStatusId == "U" &&
                                                                                   x.LastAction != "DEL", n => new { n.FunctionId }).GroupBy(x => x.FunctionId).Select(x => x.Key).ToList();

                if (!(List_AuthLogFunctions.Count > 0))
                {
                    return null;
                }

                string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetMFSMenu/09?format=json";
                using (WebClient wc = new WebClient())
                {
                    MenuService OBJ_GetMFSMenuResult = new MenuService();     //commented for temporary time by salekin
                    var json = wc.DownloadString(url);
                    OBJ_GetMFSMenuResult = JsonConvert.DeserializeObject<MenuService>(json);
                    LIST_GetMFSMenuResult = OBJ_GetMFSMenuResult.GetMFSMenuResult;
                }
                if (LIST_GetMFSMenuResult == null)
                {
                    return null;
                }

                var selectList = new List<SelectListItem>();
                for (int i = 0; i < List_AuthLogFunctions.Count(); i++)
                {
                    for (int j = 0; j < LIST_GetMFSMenuResult.Count(); j++)
                    {
                        if (LIST_GetMFSMenuResult[j].FUNCTION_ID != null && (List_AuthLogFunctions[i] == LIST_GetMFSMenuResult[j].FUNCTION_ID.ToString()))
                        {
                            selectList.Add(new SelectListItem
                            {
                                Value = LIST_GetMFSMenuResult[j].FUNCTION_ID.ToString(),
                                Text = LIST_GetMFSMenuResult[j].NAME
                            });
                        }
                    }
                }
                if (selectList != null)
                    return selectList;
                else
                    return null;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetFtAuthLogFunctionsForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        #region Grid Show & Details
        public IEnumerable<AuthLog> GetAllNftAuthLogByFunctionId(string _FunctionId)
        {
            try
            {
                if (_FunctionId == null)
                {
                    return null;
                }
                _IUoW = new UnitOfWork();
                return _IUoW.Repository<AuthLog>().Get(x => x.FunctionId == _FunctionId &&
                                                              x.AuthStatusId == "U" &&
                                                              x.LastAction != "DEL").OrderByDescending(x => x.LogId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllNftAuthLogByFunctionId(string)", string.Empty);
                return null;
            }
        }
        public IEnumerable<FTAuthLog> GetAllFtAuthLogByFunctionId(string _FunctionId)
        {
            try
            {
                if (_FunctionId == null)
                {
                    return null;
                }
                _IUoW = new UnitOfWork();
                return _IUoW.Repository<FTAuthLog>().Get(x => x.FunctionId == _FunctionId &&
                                                              x.AuthStatusId == "U" &&
                                                              x.LastAction != "DEL").OrderByDescending(x => x.LogId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllFtAuthLogByFunctionId(string)", string.Empty);
                return null;
            }
        }

        public IEnumerable<AuthLogDtl> GetNftAuthLogDetailsByLogId(string _LogId)
        {
            try
            {
                if (_LogId == null)
                {
                    return null;
                }
                _IUoW = new UnitOfWork();
                return _IUoW.Repository<AuthLogDtl>().Get(x => x.LogId == _LogId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetNftAuthLogDetailsByLogId(string)", string.Empty);
                return null;
            }
        }
        public IEnumerable<FTAuthLogDtl> GetFtAuthLogDetailsByLogId(string _LogId)
        {
            try
            {
                if (_LogId == null)
                {
                    return null;
                }
                _IUoW = new UnitOfWork();
                return _IUoW.Repository<FTAuthLogDtl>().Get(x => x.LogId == _LogId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetFtAuthLogDetailsByLogId(string)", string.Empty);
                return null;
            }
        }
        #endregion

        public bool IsSimple(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                //return IsSimple(type.GetGenericArguments()[0]);
                return IsSimple(type.GetGenericArguments()[0]);
            }
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal))
              || type.Equals(typeof(DateTime)); //salekin added
        }
        public bool IsEnumerableType(Type type)
        {
            return (type.GetInterface("IEnumerable") != null);
        }
        public bool IsCollectionType(Type type)
        {
            return (type.GetInterface("ICollection") != null);
        }
        public string GetTableAttributeName<T>() where T : class
        {
            var tAttribute = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true)[0];
            var tableName = tAttribute.Name;
            return tableName;
        }
        public virtual T GetBy<T>(Expression<Func<T, bool>> lambda) where T : class
        {
            return _IUoW.Repository<T>().GetBy(lambda);
        }
    }
}
