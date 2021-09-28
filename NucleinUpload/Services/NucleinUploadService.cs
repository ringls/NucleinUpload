using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NucleinUpload.Helpers;
using NucleinUpload.Models;
using _180FrameWork.Common;
using _180FrameWork.Common.Models;

namespace NucleinUpload.Services
{
    public class NucleinUploadService
    {
        WebApiHelper wh = new WebApiHelper();
        SM4Utils sm4 = new SM4Utils() { secretKey = SysConfig.Key };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public MSG<IList<UploadNucleinRecordJsonResponseItem>> UploadNucleinRecordJson(IList<UploadNucleinRecordJsonRequestItem> list)
        {
            var msg = new MSG<IList<UploadNucleinRecordJsonResponseItem>>();
            var request = new UploadNucleinRecordJsonRequest()
            {
                hopitalCode = SysConfig.HopitalCode,
                body = sm4.Encrypt_ECB(list.ObjToJson())
            };
            var response = wh.PostJson(SysConfig.ServerAddress + "uploadNucleinRecordJson", request).JsonToObj<UploadNucleinRecordJsonResponse>();
            if (response.code == 0)
            {
                msg.D = sm4.Decrypt_ECB(response.data).JsonToObj<IList<UploadNucleinRecordJsonResponseItem>>();
                msg.R = true;
            }
            else
            {
                msg.I = response.message;
            }
            return msg;
        }   
    }
}
