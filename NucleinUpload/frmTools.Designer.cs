
namespace NucleinUpload
{
    partial class frmTools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnEnCode = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeCode = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSource.Location = new System.Drawing.Point(0, 0);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSource.Size = new System.Drawing.Size(241, 450);
            this.txtSource.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtCode.Location = new System.Drawing.Point(336, 0);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCode.Size = new System.Drawing.Size(241, 450);
            this.txtCode.TabIndex = 1;
            // 
            // btnEnCode
            // 
            this.btnEnCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEnCode.Location = new System.Drawing.Point(0, 0);
            this.btnEnCode.Name = "btnEnCode";
            this.btnEnCode.Size = new System.Drawing.Size(95, 23);
            this.btnEnCode.TabIndex = 2;
            this.btnEnCode.Text = "加密>>";
            this.btnEnCode.UseVisualStyleBackColor = true;
            this.btnEnCode.Click += new System.EventHandler(this.btnEnCode_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeCode);
            this.panel1.Controls.Add(this.btnEnCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(241, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 450);
            this.panel1.TabIndex = 3;
            // 
            // btnDeCode
            // 
            this.btnDeCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeCode.Location = new System.Drawing.Point(0, 23);
            this.btnDeCode.Name = "btnDeCode";
            this.btnDeCode.Size = new System.Drawing.Size(95, 23);
            this.btnDeCode.TabIndex = 3;
            this.btnDeCode.Text = "<<解密";
            this.btnDeCode.UseVisualStyleBackColor = true;
            this.btnDeCode.Click += new System.EventHandler(this.btnDeCode_Click);
            // 
            // frmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtSource);
            this.Name = "frmTools";
            this.Text = "frmTools";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnEnCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeCode;
    }
}