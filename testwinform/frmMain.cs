using DevExpress.Utils;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Frames;
using DevExpress.Utils.About;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars;
using DevExpress.XtraCharts.Native;
using DevExpress.DXperience.Demos;

namespace DevExpress.XtraCharts.Demos {
    public partial class frmMain : RibbonMainForm {
        new internal BarSubItem ExportToImageExButton { get { return base.ExportToImageExButton; } }
        protected override string DemoName { get { return "XtraCharts Features Demo (C# code)"; } }
        
        public frmMain() {
			InitializeComponent();
		}
        protected override RibbonMenuManager CreateRibbonMenuManager() {
            return new ChartRibbonMenuManager(this);
        }        
		protected override void SetFormParam() {
            navBarControl1.Parent.Width = 220;
			Icon = ResourceImageHelper.CreateIconFromResources("DevExpress.XtraCharts.Demos.ChartsMainDemo.ico", typeof(frmMain).Assembly);
		}
        protected override void ShowModule(string name, GroupControl group, DefaultLookAndFeel lookAndFeel, ApplicationCaption caption) {
            DemosInfo.ShowModule(name, group, caption, RibbonMenuManager as ChartRibbonMenuManager);
        }
		protected override void FillNavBar() { 
			base.FillNavBar();
            navBarControl1.SkinExplorerBarViewScrollStyle = SkinExplorerBarViewScrollStyle.ScrollBar;
        }
        protected override void ShowAbout() {
            AboutForm.Show(typeof(Chart), ProductKind.XtraCharts, ProductInfoStage.Registered);
        }
	}
}
