using mTaka.Data.BusinessEntities.Upload_File;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.BusinessServices.Upload_File
{
    public interface IFileUploadService
    {
        int UploadFile(File_Upload _FileUpload);
    }
    public class FileUploadService:IFileUploadService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public FileUploadService()
        {
            _IUoW = new UnitOfWork();
        }

        public FileUploadService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Add
        public int UploadFile(File_Upload _FileUpload)
        {
            try
            {
                var _max = _IUoW.Repository<File_Upload>().GetMaxValue(x => x.FileId) + 1;
                _FileUpload.FileId = _max.ToString().PadLeft(3, '0');
                _FileUpload.AuthStatusId = "A";
                _FileUpload.LastAction = "ADD";
                _FileUpload.MakeBy = "mTaka";
                _FileUpload.MakeDT = System.DateTime.Now;
                var result = _IUoW.Repository<File_Upload>().Add(_FileUpload);
                //#region Auth Log
                //if (result == 1)
                //{
                //    _IAuthLogService = new AuthLogService();
                //    long _outMaxSlAuthLogDtl = 0;
                //    _IAuthLogService.AddAuthLog(_IUoW, null, _FileUpload, "ADD", "0001", "090102004", 1, "FileUpload", "MTK_SP_ACC_TYPE", "FileUploadId", _FileUpload.FileUploadId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                //}
                //#endregion

                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UploadFile(obj)", string.Empty);
                return 0;
            }
        }
        #endregion
    }
}
