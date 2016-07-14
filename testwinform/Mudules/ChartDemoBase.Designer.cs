namespace testwinform.Mudules
{
    partial class ChartDemoBase
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelRoot = new System.Windows.Forms.Panel();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.checkEditShowLabels = new DevExpress.XtraEditors.CheckEdit();
            this.panelRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowLabels.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRoot
            // 
            this.panelRoot.Controls.Add(this.panel);
            this.panelRoot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRoot.Location = new System.Drawing.Point(0, 0);
            this.panelRoot.Name = "panelRoot";
            this.panelRoot.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panelRoot.Size = new System.Drawing.Size(751, 91);
            this.panelRoot.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.checkEditShowLabels);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(751, 83);
            this.panel.TabIndex = 0;
            // 
            // checkEditShowLabels
            // 
            this.checkEditShowLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkEditShowLabels.EditValue = true;
            this.checkEditShowLabels.Location = new System.Drawing.Point(658, 56);
            this.checkEditShowLabels.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.checkEditShowLabels.Name = "checkEditShowLabels";
            this.checkEditShowLabels.Properties.Caption = "Show Labels";
            this.checkEditShowLabels.Size = new System.Drawing.Size(82, 19);
            this.checkEditShowLabels.TabIndex = 0;
            // 
            // ChartDemoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRoot);
            this.Name = "ChartDemoBase";
            this.Size = new System.Drawing.Size(751, 555);
            this.panelRoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowLabels.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelRoot;
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.CheckEdit checkEditShowLabels;
    }
}
