using System;
using System.Windows.Forms;
using DevExpress.Utils.Frames;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts.Wizard;
using DevExpress.XtraCharts.Demos.Modules;
using DevExpress.DXperience.Demos;
using testwinform.Mudules;

namespace DevExpress.XtraCharts.Demos
{
    public class DemosInfo : ModulesInfo
    {
        public static void ShowModule(string name, GroupControl group, ApplicationCaption caption, ChartRibbonMenuManager manager)
        {
            ModuleInfo item = DemosInfo.GetItem(name);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Control oldTutorial = null;
                if (Instance.CurrentModuleBase != null)
                {
                    if (Instance.CurrentModuleBase.Name == name)
                        return;
                    oldTutorial = Instance.CurrentModuleBase.TModule;
                }
                TutorialControlBase tutorial = item.TModule as TutorialControlBase;
                tutorial.Bounds = group.DisplayRectangle;
                Instance.CurrentModuleBase = item;
                tutorial.Visible = false;
                group.Controls.Add(tutorial);
                tutorial.Dock = DockStyle.Fill;
                TutorialControl tc = item.TModule as TutorialControl;
                if (tc != null)
                {
                    manager.AllowExport(tc.ChartControl);
                    manager.ShowReservGroup1(true);
                    manager.ShowReservGroup2(true);
                }
                else
                {
                    manager.AllowExport(null);
                    manager.ShowReservGroup1(false);
                    manager.ShowReservGroup2(false);
                }
                manager.UpdateAppearanceAndPalette();
                tutorial.RibbonMenuManager = manager;
                tutorial.TutorialName = name;
                tutorial.Caption = caption;
                tutorial.Visible = true;
                item.WasShown = true;
                if (oldTutorial != null)
                    oldTutorial.Visible = false;
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
            RaiseModuleChanged();
        }
        public static string SetAppearanceName(string appearanceName)
        {
            //if (Instance.CurrentModuleBase != null)
            //{
            //    ChartDemoBase chartModule = Instance.CurrentModuleBase.TModule as ChartDemoBase;
            //    if (chartModule != null)
            //    {
            //        chartModule.AppearanceName = appearanceName;
            //        return chartModule.PaletteName;
            //    }
            //}
            return String.Empty;
        }
        public static string SetPaletteName(string paletteName)
        {
            //if (Instance.CurrentModuleBase != null)
            //{
            //    ChartDemoBase chartModule = Instance.CurrentModuleBase.TModule as ChartDemoBase;
            //    if (chartModule != null)
            //    {
            //        chartModule.PaletteName = paletteName;
            //        return chartModule.AppearanceName;
            //    }
            //}
            return String.Empty;
        }
        public static void RunChartWizard()
        {
            //if (Instance.CurrentModuleBase != null)
            //{
            //    ChartDemoBase chartModule = Instance.CurrentModuleBase.TModule as ChartDemoBase;
            //    if (chartModule != null)
            //    {
            //        ChartWizard chartWizard = new ChartWizard(chartModule.ChartControl);
            //        chartWizard.ShowDialog();
            //        chartModule.UpdateControls();
            //    }
            //}
        }
    }
}
