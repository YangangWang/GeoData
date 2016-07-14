namespace testwinform.Mudules
{
    partial class ChartDemoVerticalPanes
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.ScaleBreak scaleBreak1 = new DevExpress.XtraCharts.ScaleBreak();
            DevExpress.XtraCharts.Strip strip1 = new DevExpress.XtraCharts.Strip();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("1", new object[] {
            ((object)(1D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("2", new object[] {
            ((object)(2D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("3", new object[] {
            ((object)(3D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("4", new object[] {
            ((object)(4D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("5", new object[] {
            ((object)(-1D))});
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(strip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.Alignment = DevExpress.XtraCharts.AxisAlignment.Zero;
            xyDiagram1.AxisX.Color = System.Drawing.Color.Black;
            xyDiagram1.AxisX.MinorCount = 10;
            xyDiagram1.AxisX.Range.Auto = false;
            xyDiagram1.AxisX.Range.MaxValueInternal = 10D;
            xyDiagram1.AxisX.Range.MinValueInternal = 0D;
            xyDiagram1.AxisX.Range.ScrollingRange.Auto = false;
            xyDiagram1.AxisX.Range.ScrollingRange.MaxValueSerializable = "10";
            xyDiagram1.AxisX.Range.ScrollingRange.MinValueSerializable = "1";
            xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.ScaleBreakOptions.Color = System.Drawing.Color.Lime;
            xyDiagram1.AxisX.ScaleBreakOptions.SizeInPixels = 10;
            xyDiagram1.AxisX.ScaleBreakOptions.Style = DevExpress.XtraCharts.ScaleBreakStyle.Waved;
            scaleBreak1.Edge1Serializable = "1";
            scaleBreak1.Edge2Serializable = "1";
            scaleBreak1.Name = "Scale Break 1";
            xyDiagram1.AxisX.ScaleBreaks.AddRange(new DevExpress.XtraCharts.ScaleBreak[] {
            scaleBreak1});
            strip1.MaxLimit.AxisValueSerializable = "2";
            strip1.MinLimit.AxisValueSerializable = "1";
            strip1.Name = "Strip 1";
            xyDiagram1.AxisX.Strips.AddRange(new DevExpress.XtraCharts.Strip[] {
            strip1});
            xyDiagram1.AxisX.Thickness = 5;
            xyDiagram1.AxisX.Tickmarks.CrossAxis = true;
            xyDiagram1.AxisX.Tickmarks.Length = 1;
            xyDiagram1.AxisX.Tickmarks.Thickness = 10;
            xyDiagram1.AxisX.Title.Alignment = System.Drawing.StringAlignment.Far;
            xyDiagram1.AxisX.Title.Visible = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.GridSpacingAuto = false;
            xyDiagram1.AxisY.Interlaced = true;
            xyDiagram1.AxisY.InterlacedColor = System.Drawing.Color.White;
            xyDiagram1.AxisY.Range.Auto = false;
            xyDiagram1.AxisY.Range.MaxValueSerializable = "5";
            xyDiagram1.AxisY.Range.MinValueSerializable = "-5";
            xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.Margins.Bottom = 50;
            xyDiagram1.Margins.Left = 50;
            xyDiagram1.Margins.Right = 50;
            xyDiagram1.Margins.Top = 50;
            xyDiagram1.PaneDistance = 1000;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            sideBySideBarSeriesLabel1.LineVisible = true;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.Name = "test";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4,
            seriesPoint5});
            sideBySideBarSeriesView1.BarWidth = 0.5D;
            series1.View = sideBySideBarSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            sideBySideBarSeriesLabel2.LineVisible = true;
            this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            this.chartControl1.Size = new System.Drawing.Size(800, 603);
            this.chartControl1.TabIndex = 1;
            this.chartControl1.Click += new System.EventHandler(this.chartControl1_Click);
            // 
            // ChartDemoVerticalPanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Name = "ChartDemoVerticalPanes";
            this.Controls.SetChildIndex(this.chartControl1, 0);
            this.Controls.SetChildIndex(this.panelRoot, 0);
            ((System.ComponentModel.ISupportInitialize)(strip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;

    }
}
