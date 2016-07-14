using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OGT.Common.WinForm.XtraGridControl;
using OGT.Entity;
using OGT.GeoDataFactory.Common.ReservoirSplitterClass;

namespace OGT.GeoDataFactory.DataProcessControl.ReservoirSplitterControl
{
    public partial class ReservoirSplitterControl : UserControl
    {
        #region ***构造函数***
        public ReservoirSplitterControl()
        {
            InitializeComponent();
        }
        #endregion

        #region ***字段***
        private string _filePath = string.Empty;
        private string _dataType;
        private DataTable _oilData;
        private DataTable _loggingData;
       
        private const string _gridView1LayoutFileName = "GDF_YQCFZSJ.xml";
        private const string _gridView2LayoutFileName = "GDF_LogInterpretation.xml";
        private const string _gridView3LayoutFileName = "SplitterData.xml";

        List<Well<SimpleLayer>> _subLayerData = new List<Well<SimpleLayer>>();
        List<Well<Reservoir>> _reservoirData = new List<Well<Reservoir>>();
        List<Well<MatchedReservoir>> _matchedReservoirData = new List<Well<MatchedReservoir>>();

        GridCheckMarksSelection dataSourceGridCheckedSelection;
        GridCheckMarksSelection dataSourceGridCheckedSelection1;
        #endregion

        #region ***属性***
        /// <summary>
        /// 工作目录属性，保存布局文件
        /// </summary>
        public string FilePath
        {
            get { return _filePath;}
            set { _filePath = value; }
        }
        /// <summary>
        /// 测井解释数据
        /// </summary>
        public DataTable LoggingData
        {
            get { return _loggingData; }
            set { _loggingData = value; }
        }
        /// <summary>
        /// 油气层分层数据
        /// </summary>
        public DataTable OilData
        {
            get { return _oilData; }
            set { _oilData = value; }
        }
        #endregion

        #region ***私有方法***
        private void ReadOilData()
        {
            if(_oilData!=null)
            {
                _dataType = _gridView1LayoutFileName;

                gridView1.Layout -= new EventHandler(gridView1_Layout);
                gridView1.Columns.Clear();
                gridControl1.DataSource = _oilData;

                OGT.Common.WinForm.Utility.AddExportToExcelFunctionToGridControl(gridControl1);
                OGT.Common.WinForm.Utility.AddDesignLayoutFunctionToGridView(gridView1);

                dataSourceGridCheckedSelection = new GridCheckMarksSelection(gridView1);
                dataSourceGridCheckedSelection.CheckMarkColumn.VisibleIndex = 0;

                Loadlayout1(_gridView1LayoutFileName);
                gridView1.Layout += new EventHandler(gridView1_Layout);
            }
        }
        private void ReadLoggingData()
        {
            if (_loggingData != null)
            {
                _dataType = _gridView2LayoutFileName;


                gridView2.Layout -= new EventHandler(gridView2_Layout);
                gridView2.Columns.Clear();
                gridControl2.DataSource = _loggingData;

                OGT.Common.WinForm.Utility.AddExportToExcelFunctionToGridControl(gridControl2);
                OGT.Common.WinForm.Utility.AddDesignLayoutFunctionToGridView(gridView2);


                dataSourceGridCheckedSelection1 = new GridCheckMarksSelection(gridView2);
                dataSourceGridCheckedSelection1.CheckMarkColumn.VisibleIndex = 0;

                Loadlayout2(_gridView2LayoutFileName);
                gridView2.Layout += new EventHandler(gridView2_Layout);

            }
        }
        /// <summary>
        /// //获得劈分计算数据
        /// </summary>
        /// <returns></returns>
        private List<DataTable> GetDataTable()
        {
            List<int> indexes;
            List<int> indexes1;

            List<DataTable> _dataTables = new List<DataTable>();

            indexes = dataSourceGridCheckedSelection.GetCheckedDataSourceRowIndices();
            indexes1 = dataSourceGridCheckedSelection1.GetCheckedDataSourceRowIndices();

            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            if (indexes.Count > 0)
            {
                DataTable gridTable1 = (DataTable)gridControl1.DataSource;
                table1 = gridTable1.Clone();
                foreach (int n in indexes)
                {
                    table1.Rows.Add(gridTable1.Rows[n].ItemArray);
                }

            }
            else
            {
                DataTable gridTable1 = (DataTable)gridControl1.DataSource;
                table1 = gridTable1.Clone();
                //table1.Merge(gridTable1);
            }

            if (indexes1.Count > 0)
            {
                DataTable gridTable2 = (DataTable)gridControl2.DataSource;
                table2 = gridTable2.Clone();
                foreach (int n in indexes1)
                {
                    table2.Rows.Add(gridTable2.Rows[n].ItemArray);
                }
            }
            else
            {
                DataTable gridTable2 = (DataTable)gridControl2.DataSource;
                table2 = gridTable2.Clone();
            }
            _dataTables.Add(table1);
            _dataTables.Add(table2);

            return _dataTables;

        }
        /// <summary>
        /// 劈分计算方法
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns></returns>
        private DataTable SplitterCalculate(List<DataTable> datatable)
        {
            float _delta;
            _delta = 0.001F;
            //_subLayerData.Clear();
            SubLayerDataReader subLayerDataReader = new SubLayerDataReader();
            _subLayerData = subLayerDataReader.Read(datatable[0]);

            //_reservoirData.Clear();
            ReservoirDataReader reservoirDataReader = new ReservoirDataReader();
            _reservoirData = reservoirDataReader.Read(datatable[1]);
            _matchedReservoirData.Clear();
            foreach (var wells1 in _subLayerData)
            {
                foreach (var wells2 in _reservoirData)
                {
                    if (wells1.Name == wells2.Name)
                    {
                        ReservoirSplitter1 reservoirSplitter = new ReservoirSplitter1();
                        reservoirSplitter.FirstIntervals = wells1.Layers;
                        reservoirSplitter.SecondInvervals = wells2.Layers;
                        reservoirSplitter.MatchOption.Delta = _delta;
                        reservoirSplitter.Split();
                        Well<MatchedReservoir> well3 = new Well<MatchedReservoir>();
                        well3.Name = wells1.Name;
                        well3.Layers = reservoirSplitter.ResultIntervals;
                        _matchedReservoirData.Add(well3);
                    }
                }
            }
            DataTable dt = new DataTable();

            dt.Columns.Add("井号");
            dt.Columns.Add("井ID");
            dt.Columns.Add("小层名称");
            dt.Columns.Add("解释序号");
            dt.Columns.Add("顶界深度");
            dt.Columns.Add("底界深度");
            dt.Columns.Add("有效厚度");
            dt.Columns.Add("孔隙度");
            dt.Columns.Add("渗透率");
            dt.Columns.Add("饱和度");
            dt.Columns.Add("泥沙含量");
            dt.Columns.Add("解释结论");
            dt.Columns.Add("分层方案名称");

            dt.Clear();
            if (textEdit1.Text == "")
            {
                foreach (var wells in _matchedReservoirData)
                {
                    foreach (var reservoir in wells.Layers)
                    {
                        dt.Rows.Add(wells.Name, reservoir.WellID, reservoir.SubLayerName, reservoir.Name, reservoir.Top, reservoir.Bottom,

                           string.Format("{0:F}", reservoir.Thickness), reservoir.Porosity, reservoir.Permeability, reservoir.Saturation,
                            reservoir.Shale, reservoir.Conclusion, reservoir.HierarchicalSchemeName);
                    }
                }

            }
            else
            {
                foreach (var wells in _matchedReservoirData)
                {
                    foreach (var reservoir in wells.Layers)
                    {
                        dt.Rows.Add(wells.Name, reservoir.WellID, reservoir.SubLayerName, reservoir.Name, reservoir.Top, reservoir.Bottom,

                           string.Format("{0:F}", reservoir.Thickness), reservoir.Porosity, reservoir.Permeability, reservoir.Saturation,
                            reservoir.Shale, reservoir.Conclusion, textEdit1.Text);
                    }
                }
            }

            return dt;
        }
        
        /// <summary>
        /// 加载布局文件
        /// </summary>
        /// <param name="file"></param>
        private void Loadlayout1(string file)
        {
            string path = "";

            if (!string.IsNullOrEmpty(_filePath))
            {
                path = Path.Combine(_filePath, file);
            }

            if (File.Exists(path))
            {
                this.gridView1.RestoreLayoutFromXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                this.gridControl1.RefreshDataSource();
            }
        }
        private void Loadlayout2(string file)
        {
            string path = "";

            if (!string.IsNullOrEmpty(_filePath))
            {
                path = Path.Combine(_filePath, file);
            }
            if (File.Exists(path))
            {
                this.gridView2.RestoreLayoutFromXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                this.gridControl2.RefreshDataSource();
            }

        }
        private void Loadlayout3(string file)
        {
            string path = "";

            if (!string.IsNullOrEmpty(_filePath))
            {
                path = Path.Combine(_filePath, file);
            }
            if (File.Exists(path))
            {
                this.gridView3.RestoreLayoutFromXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                //this.gridControl3.RefreshDataSource();
            }

        }
        /// <summary>
        /// 保存gridView1的布局文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_Layout(object sender, EventArgs e)
        {
            if (_dataType != _gridView1LayoutFileName)
                _dataType = _gridView1LayoutFileName;

            if (!string.IsNullOrEmpty(_filePath))
            {
                if (!Directory.Exists(_filePath))
                    Directory.CreateDirectory(_filePath);

                string path = Path.Combine(_filePath, _dataType);
                this.gridView1.SaveLayoutToXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }   
        }
        /// <summary>
        /// 保存gridView2的布局文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_Layout(object sender, EventArgs e)
        {
            if (_dataType != _gridView2LayoutFileName)
                _dataType = _gridView2LayoutFileName;

            if (!string.IsNullOrEmpty(_filePath))
            {
                if (!Directory.Exists(_filePath))
                    Directory.CreateDirectory(_filePath);
                string path = Path.Combine(_filePath, _dataType);
                this.gridView2.SaveLayoutToXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }

        }
        /// <summary>
        /// 保存gridView3的布局文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView3_Layout(object sender, EventArgs e)
        {
            if (_dataType != _gridView3LayoutFileName)
                _dataType = _gridView3LayoutFileName;

            if (!string.IsNullOrEmpty(_filePath))
            {
                if (!Directory.Exists(_filePath))
                    Directory.CreateDirectory(_filePath);
                string path = Path.Combine(_filePath, _dataType);
                this.gridView3.SaveLayoutToXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }
        }
        private DateTime GetDataBaseTime()
        {
            string timeStr = "select to_char(sysdate, 'yyyy-mm-dd hh24:mi:ss') from dual";
            DataTable timeTable = EntityHelper.FindDataTable(timeStr);
            string time1 = timeTable.Rows[0][0].ToString();
            DateTime time = Convert.ToDateTime(timeTable.Rows[0][0].ToString());
            return time;
        }
        #endregion

        #region ***事件***
        private void ReservoirSplitterControl_Load(object sender, EventArgs e)
        {
            ReadOilData();
            ReadLoggingData();

            OGT.Common.WinForm.Utility.AddExportToExcelFunctionToGridControl(gridControl3);
            OGT.Common.WinForm.Utility.AddDesignLayoutFunctionToGridView(gridView3);
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            OGT.Common.WinForm.Utility.ShowLoadingWaitForm("正在加载...");
            try
            {
                //SplashScreenManager.ShowForm(typeof(LoadForm));

                List<DataTable> datatable = new List<DataTable>();
                datatable = GetDataTable();
                DataTable dt = SplitterCalculate(datatable);

                _dataType = _gridView3LayoutFileName;

                gridView3.Layout -= new EventHandler(gridView3_Layout);
                gridView3.Columns.Clear();
                gridControl3.DataSource = dt;

                Loadlayout3(_gridView3LayoutFileName);
                gridView3.Layout += new EventHandler(gridView3_Layout);


                //SplashScreenManager.CloseForm();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                OGT.Common.WinForm.Utility.CloseLoadingWaitForm();

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OGT.Common.WinForm.Utility.ShowLoadingWaitForm(("正在保存..."));
                this.gridControl3.Focus();
                DataTable _dt = (DataTable)gridControl3.DataSource;
                DateTime databaseTime = GetDataBaseTime();

                //SaveData saveData = new SaveData();
                //DateTime dataBaeTime = saveData.GetDataBaseTime();
                //saveData.SaveReseroirData(_dt, dataBaeTime);
                if (SaveDataCalled != null)
                    SaveDataCalled(this, new SaveDataEventArgs(_dt, databaseTime));
                OGT.Common.WinForm.Utility.CloseLoadingWaitForm();
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                OGT.Common.WinForm.Utility.CloseLoadingWaitForm();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public delegate void SaveDataEventHandler(object sender, SaveDataEventArgs e);
        public event SaveDataEventHandler SaveDataCalled;
    }
}
