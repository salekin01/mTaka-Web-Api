using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using mTaka.Data.Infrastructure;
using mTaka.Utility.Crypto;

namespace mTaka.API.Areas.QR.Controllers
{
    public class QrOperationController : ApiController
    {
        private UnitOfWork unitOfWork;

        public QrOperationController()
        {
            unitOfWork = new UnitOfWork();
        }
        [Authorize]
        public string Encrypt([FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            var QRKey = unitOfWork.Repository<CryptoKeyModel>().Get(a => a.Name == "QRKey").FirstOrDefault();
            var QRIV = unitOfWork.Repository<CryptoKeyModel>().Get(a => a.Name == "QRIV").FirstOrDefault();
            if (QRKey != null && QRKey !=null)
            {
                SHA256 mySha256 = SHA256.Create();
                byte[] key = mySha256.ComputeHash(Encoding.ASCII.GetBytes(QRKey.Key));
                byte[] iv = Encoding.ASCII.GetBytes(QRIV.Key);
                var qr = new Utility.Crypto.QR();
                return qr.EncryptString(value, key, iv);
            }
            else
            {
                return null;
            }
        }


        [Authorize]
        public string Decrypt([FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            var QRKey = unitOfWork.Repository<CryptoKeyModel>().Get(a => a.Name == "QRKey").FirstOrDefault();
            var QRIV = unitOfWork.Repository<CryptoKeyModel>().Get(a => a.Name == "QRIV").FirstOrDefault();
            if (QRKey != null && QRKey != null)
            {
                SHA256 mySha256 = SHA256.Create();
                byte[] key = mySha256.ComputeHash(Encoding.ASCII.GetBytes(QRKey.Key));
                byte[] iv = Encoding.ASCII.GetBytes(QRIV.Key);
                var qr = new Utility.Crypto.QR();
                return qr.DecryptString(value, key, iv);
            }
            else
            {
                return null;
            }

        }
    }
}