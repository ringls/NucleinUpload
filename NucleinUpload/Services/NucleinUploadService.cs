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
            var jsonResponse = wh.PostJson(SysConfig.ServerAddress + "uploadNucleinRecordJson", request);
            var response = jsonResponse.JsonToObj<UploadNucleinRecordJsonResponse>();
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
        /// <summary>
        /// 获取需要上传的核酸数据
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public IList<NUCLEIN_RECORD> GetHSResultList(DateTime StartDate, DateTime EndDate)
        {
            if (SysConfig.NetType == "内")
            {
                return wh.Get("http://10.180.180.100:1983/sql/HSUp/GetHSResultList", new { start_date = StartDate.ToString("yyyy-MM-dd"), end_date = EndDate.ToString("yyyy-MM-dd") }).JsonToObj<IList<NUCLEIN_RECORD>>();
            }
            else
            {
                return new List<NUCLEIN_RECORD>();
            }
        }
        /// <summary>
        /// 上传成功后回写数据（逐一项回传）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MSG InsertUpStatusNew(SPT_LIS_UPLOG model)
        {
            if (SysConfig.NetType == "内")
            {
                return wh.PostJson("http://10.180.180.100:1983/sql/HSUp/InsertUpStatus", model).JsonToObj<MSG>();
            }
            else
            {
                var info = model.DETAIL_PARA;
                MyLogerHelper.WriteLog(info);
                return new MSG() { R = true, I = info };
            }
        }
        /// <summary>
        /// 批量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MSG InsertUpStatus(IList<SPT_LIS_UPLOG> model)
        {
            if (SysConfig.NetType == "内")
            {
                return wh.PostJson("http://10.180.180.100:1983/sql/HSUp/InsertUpStatus", model).JsonToObj<MSG>();
            }
            else
            {
                var info = model.ObjToJson();
                MyLogerHelper.WriteLog(info);
                return new MSG() { R = true, I = info };
            }
        }
    }
}
