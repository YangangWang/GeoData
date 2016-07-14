using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.Utils.Menu;
using DevExpress.XtraCharts.Demos.Modules;

namespace testwinform.Mudules
{
    public partial class ChartDemoVerticalPanes : ChartDemoBase2D
    {
        public override ChartControl ChartControl { get { return chartControl1; } }

        public ChartDemoVerticalPanes()
        {
            InitializeComponent();
        }
        protected override DXPopupMenu ConstructPopupMenu(object obj, ChartControl chartControl)
        {
            return DXMenuHelper.ConstructPaneMenu(obj, chartControl);
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
