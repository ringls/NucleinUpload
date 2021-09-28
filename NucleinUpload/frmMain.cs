using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NucleinUpload.Models;
using NucleinUpload.Services;
using _180FrameWork.Common;

namespace NucleinUpload
{
    public partial class frmMain : Form
    {
        NucleinUploadService srv = new NucleinUploadService(); 
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = new List<UploadNucleinRecordJsonRequestItem>();
            list.Add(new UploadNucleinRecordJsonRequestItem()
            {
                name = "阿兰",
                cardType = 1,
                cardNo = "350502198312301548",
                telephone = "13489481234",
                hometownCountryCode = null,
                hometownProvinceCode = null,
                hometownCityCode = null,
                hometownDistrictCode = null,
                samplingTime = "2021-09-15 11:23:21",
                result = 2,
                resultTime = "2021-09-16 14:05:32",
                crowdType = 10,
                subCrowdType = 1,
                outHospitalTime = null,
                remark = "",
                checkOrgName = "中国人民解放军联勤保障部队第九一〇医院",
                extendParameter = "TEST1233"
            });
            var msg = srv.UploadNucleinRecordJson(list);
            if (msg.R)
            {
                MessageBox.Show(msg.D.ObjToJson());
            }
        }
    }
}
