using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _180FrameWork.Common;

namespace NucleinUpload.Helpers
{
    internal class SysConfig
    {
        private static MyConfigHelper config = new MyConfigHelper();
        /// <summary>
        /// 网络环境
        /// </summary>
        public static string NetType
        {
            get { return config.GetValue("NetType").ToStr(); }
        }
        /// <summary>
        /// 单次上传上限
        /// </summary>
        public static int UploadNumber
        {
            get { return config.GetValue("UploadNumber").ToInt(); }
        }
        /// <summary>
        /// 医院code
        /// </summary>
        public static string HopitalCode
        {
            get { return config.GetValue("HopitalCode").ToStr(); }
        }
        /// <summary>
        /// 医院key
        /// </summary>
        public static string Key
        {
            get { return config.GetValue("Key").ToString(); }
        }
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public static string ServerAddress
        {
            get
            { return config.GetValue("ServerAddress").ToString(); }
        }
    }
}
