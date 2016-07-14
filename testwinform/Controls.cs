using DevExpress.DXperience.Demos;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Demos;
using DevExpress.XtraCharts.Printing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace DevExpress.XtraCharts.Demos
{
    
    public  class BarExportToImageItem : BarButtonItem
    {
        readonly ImageFormat imageFormat;
        readonly ImageCodecInfo imageCodecInfo;

        public ImageFormat ImageFormat { get { return imageFormat; } }
        public ImageCodecInfo ImageCodecInfo { get { return imageCodecInfo; } }

        public BarExportToImageItem(BarManager barManager, ImageFormat imageFormat, ImageCodecInfo imageCodecInfo)
            : base(barManager, String.Empty)
        {
            this.imageFormat = imageFormat;
            this.imageCodecInfo = imageCodecInfo;
            Caption = String.Format("{0}", imageCodecInfo.FormatDescription);
        }
    }
    
    public class ChartRibbonMenuManager:RibbonMenuManager
    {
        BarSubItem bsiAppearances;
        BarSubItem bsiPalettes;
        string appearanceName;
        string paletteName;

        public ChartRibbonMenuManager(RibbonMainForm form)
            : base(form)
        {
            CreateChartAppearanceMenu(form.ReservGroup1);
            CreateChartWizardMenu(form.ReservGroup2);
        }
        void CreateChartAppearanceMenu(RibbonPageGroup ribbonPageGroup)
        {
            ribbonPageGroup.Text = "Chart Appearance";
            ChartControl chart = new ChartControl();
            bsiAppearances = new BarSubItem();
            bsiAppearances.Caption = "Appearance";
            bsiAppearances.Glyph = DevExpress.XtraCharts.Demos.Modules.Utils.GetImage("Appearance_16x16.png");
            bsiAppearances.LargeGlyph = DevExpress.XtraCharts.Demos.Modules.Utils.GetImage("Appearance_32x32.png");
            string[] appearanceNames = chart.GetAppearanceNames();
            int defaultIndex = 0;
            for (int i = 0; i < appearanceNames.Length; i++)
            {
                CheckBarItem cbiAppearanceName = new CheckBarItem(Manager, appearanceNames[i], new ItemClickEventHandler(cbiAppearanceName_Click));
                if (appearanceNames[i] == chart.AppearanceName)
                    defaultIndex = i;
                bsiAppearances.AddItem(cbiAppearanceName);
            }
            ribbonPageGroup.ItemLinks.Add(bsiAppearances);
            if (appearanceNames.Length > 0)
            {
                CheckBarItem item = bsiAppearances.ItemLinks[defaultIndex].Item as CheckBarItem;
                if (bsiAppearances != null)
                {
                    cbiAppearanceName_Click(Manager, new ItemClickEventArgs(item, null));
                    item.Checked = true;
                }
            }
            bsiPalettes = new BarSubItem();
            bsiPalettes.Caption = "Palette";
            bsiPalettes.Glyph = DevExpress.XtraCharts.Demos.Modules.Utils.GetImage("Palette_16x16.png");
            bsiPalettes.LargeGlyph = DevExpress.XtraCharts.Demos.Modules.Utils.GetImage("Palette_32x32.png");
            string[] paletteNames = chart.GetPaletteNames();
            defaultIndex = 0;
            for (int i = 0; i < paletteNames.Length; i++)
            {
                CheckBarItem cbiPaletteName = new CheckBarItem(Manager, paletteNames[i], new ItemClickEventHandler(cbiPaletteName_Click));
                if (paletteNames[i] == chart.PaletteName)
                    defaultIndex = i;
                bsiPalettes.ItemLinks.Add(cbiPaletteName);
            }
            ribbonPageGroup.ItemLinks.Add(bsiPalettes);
            if (paletteNames.Length > 0)
            {
                CheckBarItem item = bsiPalettes.ItemLinks[defaultIndex].Item as CheckBarItem;
                if (bsiPalettes != null)
                {
                    cbiPaletteName_Click(Manager, new ItemClickEventArgs(item, null));
                    item.Checked = true;
                }
            }
            chart.Dispose();
        }
        void CreateChartWizardMenu(RibbonPageGroup ribbonPageGroup)
        {
            ribbonPageGroup.Text = "Wizard";
            ButtonBarItem bbiWizard = new ButtonBarItem(Manager, "Run Chart Wizard...", new ItemClickEventHandler(bbiWizard_Click));
            bbiWizard.Glyph = DevExpress.XtraCharts.Demos.Modules.Utils.GetImage("Wizard_16x16.png");
            bbiWizard.LargeGlyph = DevExpress.XtraCharts.Demos.Modules.Utils.GetImage("Wizard_32x32.png");
            ribbonPageGroup.ItemLinks.Add(bbiWizard);
        }
        void UpdateMenu()
        {
            int count = bsiAppearances.ItemLinks.Count;
            for (int i = 0; i < count; i++)
            {
                BarCheckItem item = bsiAppearances.ItemLinks[i].Item as BarCheckItem;
                if (item != null)
                    item.Checked = item.Caption == appearanceName;
            }
            if (bsiPalettes != null)
            {
                count = bsiPalettes.ItemLinks.Count;
                for (int i = 0; i < count; i++)
                {
                    BarCheckItem item = bsiPalettes.ItemLinks[i].Item as BarCheckItem;
                    if (item != null)
                        item.Checked = item.Caption == paletteName;
                }
            }
        }
        void SetAppearanceName(string name)
        {
            if (bsiAppearances != null)
            {
                appearanceName = name;
                string paletteName = DemosInfo.SetAppearanceName(appearanceName);
                if (paletteName.Length > 0)
                    this.paletteName = paletteName;
                UpdateMenu();
            }
        }
        void SetPaletteName(string name)
        {
            if (bsiPalettes != null)
            {
                paletteName = name;
                string appearanceName = DemosInfo.SetPaletteName(paletteName);
                if (appearanceName.Length > 0)
                    this.appearanceName = appearanceName;
                UpdateMenu();
            }
        }
        void cbiAppearanceName_Click(object sender, ItemClickEventArgs e)
        {
            CheckBarItem item = e.Item as CheckBarItem;
            if (item != null)
                SetAppearanceName(item.Caption);
        }
        void cbiPaletteName_Click(object sender, ItemClickEventArgs e)
        {
            CheckBarItem item = e.Item as CheckBarItem;
            if (item != null)
                SetPaletteName(item.Caption);
        }
        void bbiWizard_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.RunChartWizard();
        }
        internal void UpdateAppearanceAndPalette()
        {
            SetAppearanceName(appearanceName);
            SetPaletteName(paletteName);
        }
    }
    
    public class TutorialControl:TutorialControlBase
    {
        IDXMenuManager menuManager;
        ImageFormat currentImageFormat;

        public IDXMenuManager MenuManager
        {
            get { return menuManager; }
            set { menuManager = value; }
        }
        public ChartRibbonMenuManager ChartRibbonMenuManager { get { return RibbonMenuManager as ChartRibbonMenuManager; } }
        public virtual ChartControl ChartControl { get { return null; } }
        public override bool AllowPrintOptions { get { return ChartControl != null; } }
        protected override void AllowExport()
        {
            EnabledPrintExportActions(true,
                ExportFormats.ImageEx | ExportFormats.PDF | ExportFormats.HTML | ExportFormats.MHT | ExportFormats.XLS | ExportFormats.RTF | ExportFormats.XLSX, false);
        }
        protected override void ExportToCore(string filename, string ext)
        {
            ChartControl chart = ChartControl;
            if (chart != null)
            {
                System.Windows.Forms.Cursor currentCursor = System.Windows.Forms.Cursor.Current;
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                if (ext == "rtf")
                    chart.ExportToRtf(filename);
                else if (ext == "pdf")
                    chart.ExportToPdf(filename);
                else if (ext == "mht")
                    chart.ExportToMht(filename);
                else if (ext == "html")
                    chart.ExportToHtml(filename);
                else if (ext == "xls")
                    chart.ExportToXls(filename);
                else if (ext == "xlsx")
                    chart.ExportToXlsx(filename);
                else
                    chart.ExportToImage(filename, currentImageFormat);
                System.Windows.Forms.Cursor.Current = currentCursor;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ParentFormMain != null)
            {
                BarSubItem exportItem = ((frmMain)ParentFormMain).ExportToImageExButton;
                exportItem.ClearLinks();
                AddImageFormat(exportItem, ImageFormat.Bmp);
                AddImageFormat(exportItem, ImageFormat.Emf);
                AddImageFormat(exportItem, ImageFormat.Exif);
                AddImageFormat(exportItem, ImageFormat.Gif);
                AddImageFormat(exportItem, ImageFormat.Icon);
                AddImageFormat(exportItem, ImageFormat.Jpeg);
                AddImageFormat(exportItem, ImageFormat.Png);
                AddImageFormat(exportItem, ImageFormat.Tiff);
                AddImageFormat(exportItem, ImageFormat.Wmf);
            }
        }
        protected override void ExportToPDF()
        {
            ChartControl chart = ChartControl;
            if (chart != null)
            {
                PrintSizeMode sizeMode = chart.OptionsPrint.SizeMode;
                chart.OptionsPrint.SizeMode = PrintSizeMode.Zoom;
                try
                {
                    ExportTo("pdf", "PDF document (*.pdf)|*.pdf");
                }
                finally
                {
                    chart.OptionsPrint.SizeMode = sizeMode;
                }
            }
        }
        protected override void ExportToHTML()
        {
            ExportTo("html", "HTML document (*.html)|*.html");
        }
        protected override void ExportToMHT()
        {
            ExportTo("mht", "MHT document (*.mht)|*.mht");
        }
        protected override void ExportToXLS()
        {
            ExportTo("xls", "XLS document (*.xls)|*.xls");
        }
        protected override void ExportToXLSX()
        {
            ExportTo("xlsx", "XLSX document (*.xlsx)|*.xlsx");
        }
        protected override void ExportToRTF()
        {
            ExportTo("rtf", "RTF document (*.rtf)|*.rtf");
        }
        protected override void ExportToText()
        {
            ExportTo("txt", "Text document (*.txt)|*.txt");
        }
        protected override void PrintPreview()
        {
            ChartControl chart = ChartControl;
            if (chart != null)
            {
                chart.OptionsPrint.SizeMode = PrintSizeMode.Zoom;
                if (RibbonMenuManager.PrintOptions.ShowRibbonPreviewForm)
                    chart.ShowRibbonPrintPreview();
                else
                    chart.ShowPrintPreview();
            }
        }
        void AddImageFormat(BarSubItem biImagesMenuItem, ImageFormat format)
        {
            ImageCodecInfo codecInfo = FindImageCodec(format);
            if (codecInfo != null)
            {
                BarExportToImageItem item = new BarExportToImageItem(Manager, format, codecInfo);
                item.ItemClick += new ItemClickEventHandler(OnExportImageClick);
                biImagesMenuItem.AddItem(item);
            }
        }
        ImageCodecInfo FindImageCodec(ImageFormat format)
        {
            ImageCodecInfo[] infos = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo item in infos)
                if (item.FormatID.Equals(format.Guid))
                    return item;
            return null;
        }
        void OnExportImageClick(object sender, ItemClickEventArgs e)
        {
            BarExportToImageItem item = e.Item as BarExportToImageItem;
            if (item != null)
            {
                currentImageFormat = item.ImageFormat;
                ExportTo(item.ImageCodecInfo.FilenameExtension,
                    String.Format("{0} ({1})|{1}", String.Format("{0} image", item.ImageCodecInfo.FormatDescription), item.ImageCodecInfo.FilenameExtension));
            }
        }
    }
}
