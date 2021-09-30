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
using NucleinUpload.Helpers;

namespace NucleinUpload
{
    public partial class frmMain : Form
    {
 
        NucleinUploadService srv = new NucleinUploadService();
        IList<NUCLEIN_RECORD> list = null;
        public frmMain()
        {
            InitializeComponent();
            new ConsoleHelper(this.txtLog);
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            list = srv.GetHSResultList(this.dtStart.Value, this.dtEnd.Value);
            this.dgv.DataSource = list;
            this.lbInfo.Text = string.Format("合计：{0}", list.Count);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            this.btnExport.Enabled = false;
            this.btnGetList.Enabled = false;
            this.btnImport.Enabled = false;
            this.btnUpload.Enabled = false;
            bgw.RunWorkerAsync();
        }

        private void doUpload(IList<UploadNucleinRecordJsonRequestItem> uploadList,ref int successNumber,ref int failNumber)
        {
            var msgUploadNucleinRecordJson = srv.UploadNucleinRecordJson(uploadList);
            if (msgUploadNucleinRecordJson.R)
            {
                //循环回写数据
                foreach (var result in msgUploadNucleinRecordJson.D)
                {

                    var model = new SPT_LIS_UPLOG()
                    {
                        HIS_ID = result.extendParameter,
                        STATUS = result.status.ToStr(),
                        REMARK = result.message,
                        DETAIL_PARA = result.ObjToJson(),
                        UP_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
  
                    //resultList.Add(model);
                    var msgInsertUpStatusNew = srv.InsertUpStatusNew(model);

                    if (msgInsertUpStatusNew.R)
                    {
                        successNumber = successNumber + 1;
                    }
                    else
                    {
                        failNumber = failNumber + 1;
                        //写入日志
                        MyLogerHelper.WriteLog(string.Format("{0}更新上传结果出错", result.cardNo), new Exception(msgInsertUpStatusNew.I));
                    }
                }
                MessageBox.Show("上传并回写完毕");
            }
            else
            {
                //MessageBox.Show("上传出错:" + msgUploadNucleinRecordJson.I);
                //写入日志
                MyLogerHelper.WriteLog("上传出错", new Exception(msgUploadNucleinRecordJson.I));
            }        
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MyFileHelper.WriteWithDialog("核酸检测数据.txt", this.list.ObjToJson(), "", Encoding.Default, false);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var json = MyFileHelper.ReadWithDialog("核酸检测数据.txt", "");
            if (json != null)
            {
                this.list = json.JsonToObj<IList<NUCLEIN_RECORD>>();
                this.dgv.DataSource = list;
                this.lbInfo.Text = string.Format("合计：{0}", list.Count);
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("开始转换数据");
            IList<UploadNucleinRecordJsonRequestItem> uploadList = new List<UploadNucleinRecordJsonRequestItem>();
            //数据转换
            foreach (var item in list)
            {
                //如已经上传
                var uploadItem = new UploadNucleinRecordJsonRequestItem()
                {
                    name = item.NAME,
                    cardType = item.CARDTYPE,
                    cardNo = item.CARDNO,
                    telephone = item.TELEPHONE,
                    hometownCountryCode = item.HOMETOWNCOUNTRYCODE,
                    hometownProvinceCode = item.HOMETOWNPROVINCECODE,
                    hometownCityCode = item.HOMETOWNCITYCODE,
                    hometownDistrictCode = null,
                    samplingTime = item.SAMPLINGTIME.ToString("yyyy-MM-dd HH:mm:ss"),
                    result = item.RESULT,
                    resultTime = item.RESULTTIME.ToString("yyyy-MM-dd HH:mm:ss"),
                    crowdType = item.CROWDTYPE,
                    subCrowdType = item.SUBCROWDTYPE,
                    outHospitalTime = item.OUTHOSPITALTIME.HasValue ? item.OUTHOSPITALTIME.Value.ToString("yyyy-MM-dd HH:mm:ss") : "",
                    remark = item.REMARK,
                    checkOrgName = item.CHECKORGNAME,
                    extendParameter = item.TEST_NO
                };
                uploadList.Add(uploadItem);
            }
            Console.WriteLine("转换数据完成");
            if (uploadList.Count > 0)
            {
                var currentCount = 0;
                var currentUploadList = new List<UploadNucleinRecordJsonRequestItem>();
                int successNumber = 0;
                int failNumber = 0;
                //分批上传，防止接口失败
                do
                {
                    currentUploadList.Add(uploadList[currentCount].Clone());
                    currentCount++;
                    if (currentUploadList.Count >= SysConfig.UploadNumber || currentCount == uploadList.Count)
                    {
                        Console.WriteLine(string.Format("开始分组上传{0}/{1}", currentCount.ToStr(), uploadList.Count.ToStr()));
                        //上传一次
                        doUpload(currentUploadList, ref successNumber, ref failNumber);
                        //清空
                        currentUploadList.Clear();
                    }
                }
                while (currentCount < uploadList.Count);
                //
                Console.WriteLine(string.Format("分组上传完成,成功：{0}，失败：{1}。具体查看日志", successNumber.ToStr(), failNumber.ToStr()));
            }
            else
            {
                MessageBox.Show("没有需要上传的数据");
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnExport.Enabled = true;
            this.btnGetList.Enabled = true;
            this.btnImport.Enabled = true;
            this.btnUpload.Enabled = true;
        }
    }
}
