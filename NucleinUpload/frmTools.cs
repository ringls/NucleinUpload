using NucleinUpload.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _180FrameWork.Common;

namespace NucleinUpload
{
    public partial class frmTools : Form
    {
        SM4Utils sm4 = new SM4Utils() { secretKey = SysConfig.Key };
        public frmTools()
        {
            InitializeComponent();
        }

        private void btnEnCode_Click(object sender, EventArgs e)
        {
            this.txtCode.Text = sm4.Encrypt_ECB(this.txtSource.Text);
        }

        private void btnDeCode_Click(object sender, EventArgs e)
        {
            this.txtSource.Text = sm4.Decrypt_ECB(this.txtCode.Text);
        }
    }
}
