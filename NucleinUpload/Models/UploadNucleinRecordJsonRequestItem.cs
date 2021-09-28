using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NucleinUpload.Models
{
    public class UploadNucleinRecordJsonRequestItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cardType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cardNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hometownCountryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hometownProvinceCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hometownCityCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hometownDistrictCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string samplingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string resultTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int crowdType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int subCrowdType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string outHospitalTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string checkOrgName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extendParameter { get; set; }
    }
}
