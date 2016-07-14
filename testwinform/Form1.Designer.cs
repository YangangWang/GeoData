namespace testwinform
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl11 = new testwinform.Mudules.UserControl1();
            this.panelControlTest = new DevExpress.XtraEditors.PanelControl();
            this.userControl12 = new testwinform.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTest)).BeginInit();
            this.panelControlTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelContainer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelControlTest);
            this.splitContainer1.Size = new System.Drawing.Size(992, 734);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.elementHost1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(330, 734);
            this.panelContainer.TabIndex = 0;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(2, 2);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(326, 730);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.userControl11;
            // 
            // panelControlTest
            // 
            this.panelControlTest.Controls.Add(this.userControl12);
            this.panelControlTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlTest.Location = new System.Drawing.Point(0, 0);
            this.panelControlTest.Name = "panelControlTest";
            this.panelControlTest.Size = new System.Drawing.Size(658, 734);
            this.panelControlTest.TabIndex = 0;
            this.panelControlTest.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControlTest_Paint);
            // 
            // userControl12
            // 
            this.userControl12.Location = new System.Drawing.Point(5, 12);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(422, 676);
            this.userControl12.TabIndex = 0;
            this.userControl12.WorkDirectory = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 734);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTest)).EndInit();
            this.panelControlTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Mudules.UserControl1 userControl11;
        private DevExpress.XtraEditors.PanelControl panelControlTest;
        private UserControl1 userControl12;

    }
}

