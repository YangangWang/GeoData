using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts.Demos;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;

namespace testwinform.Mudules
{
    public partial class ChartDemoBase : TutorialControl
    {
        protected bool CheckEditShowLabelsVisible
        {
            get { return checkEditShowLabels.Visible; }
            set { checkEditShowLabels.Visible = value; }
        }
        protected bool ShowLabels
        {
            get { return checkEditShowLabels.Checked; }
            set { checkEditShowLabels.Checked = value; }
        }
        public string AppearanceName
        {
            get { return ChartControl == null ? String.Empty : ChartControl.AppearanceName; }
            set { SetAppearanceName(value); }
        }
        public string PaletteName
        {
            get { return ChartControl == null ? String.Empty : ChartControl.PaletteName; }
            set
            {
                if (ChartControl != null)
                    ChartControl.PaletteName = value;
            }
        }
        public ChartDemoBase()
        {
            InitializeComponent();
        }
        protected void SetNumericOptions(Series series, NumericFormat format, int precision)
        {
            series.Label.PointOptions.ValueNumericOptions.Format = format;
            series.Label.PointOptions.ValueNumericOptions.Precision = precision;
        }
        protected virtual void ChartDemoBase_Load(object sender, EventArgs e)
        {
            if (ChartControl != null && !DesignMode)
            {
                InitControls();
                UpdateControls();
            }
        }
        protected virtual void SetAppearanceName(string appearanceName)
        {
            if (ChartControl != null)
                ChartControl.AppearanceName = appearanceName;
        }
        protected virtual void checkEditShowLabels_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Series series in ChartControl.Series)
                if (series.Label != null)
                    series.Label.Visible = checkEditShowLabels.Checked;
            UpdateControls();
        }
        protected virtual void InitControls()
        {
        }
        public virtual void UpdateControls()
        {
        }
    }
}
