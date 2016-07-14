using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OGT.Common.WinForm.XtraGridControl;
using System.IO;
using OGT.DataTableMatcher;
using OGT.DataTableMatcher.Model;
using OGT.DataTableMatcher.DTMatch;
using OGT.Entity;

namespace OGT.GeoDataFactory.DataProcessControl
{
    /// <summary>
    /// 小层匹配
    /// </summary>
    public partial class ReservoirProcessControl : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ReservoirProcessControl()
        {
            InitializeComponent();
        }

        #region****字段***
        string _dataType;
        string _filePath = string.Empty;

        private const string _gridView1LayoutFileName = "GDF_XCFCSJ.xml";
        private const string _gridView2LayoutFileName = "GDF_CCJSJLSJ.xml";
        private const string _gridView3LayoutFileName = "GDF_YXJSSJ.xml";
        private const string _gridView4LayoutFileName = "GDF_CJXJSSJ.xml";
        private const string _gridView5LayoutFileName = "MatchTable.xml";

        GridCheckMarksSelection dataSourceGridCheckedSelection;
        GridCheckMarksSelection dataSourceGridCheckedSelection1;
        GridCheckMarksSelection dataSourceGridCheckedSelection2;
        GridCheckMarksSelection dataSourceGridCheckedSelection3;

        private DataTable _sublayerData;
        private DataTable _reservoirData;
        private DataTable _lithologicalData;
        private DataTable _sedimentaryFaciesData;

        #endregion

        #region****属性***
        /// <summary>
        /// 布局文件路径
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        //
        public DataTable SublayerData
        {
            get { return _sublayerData; }
            set
            {
                _sublayerData = value;

            }
        }

        public DataTable ReservoirData
        {
            get { return _reservoirData; }
            set
            {
                _reservoirData = value;

            }
        }

        public DataTable LithologicalData
        {
            get { return _lithologicalData; }
            set
            {
                _lithologicalData = value;

            }
        }

        public DataTable SedimentaryFaciesData
        {
            get { return _sedimentaryFaciesData; }
            set
            {
                _sedimentaryFaciesData = value;

            }
        }
        #endregion

        #region****方法***
        private void ReadSublayerData()
        {
            if (_sublayerData != null)
            {
                _dataType = _gridView1LayoutFileName;


                gridView1.Layout -= new EventHandler(gridView1_Layout);
                gridView1.Columns.Clear();
                gridControl1.DataSource = _sublayerData;

                OGT.Common.WinForm.Utility.AddExportToExcelFunctionToGridControl(gridControl1);
                OGT.Common.WinForm.Utility.AddDesignLayoutFunctionToGridView(gridView1);


                dataSourceGridCheckedSelection = new GridCheckMarksSelection(gridView1);
                dataSourceGridCheckedSelection.CheckMarkColumn.VisibleIndex = 0;

                Loadlayout1(_gridView1LayoutFileName);
                gridView1.Layout += new EventHandler(gridView1_Layout);

            }
        }

        private void ReadReservoirData()
        {
            if (_reservoirData != null)
            {
                _dataType = _gridView2LayoutFileName;


                gridView2.Layout -= new EventHandler(gridView2_Layout);
                gridView2.Columns.Clear();
                gridControl2.DataSource = _reservoirData;

                OGT.Common.WinForm.Utility.AddExportToExcelFunctionToGridControl(gridControl2);
                OGT.Common.WinForm.Utility.AddDesignLayoutFunctionToGridView(gridView2);


                dataSourceGridCheckedSelection1 = new GridCheckMarksSelection(gridView2);
                dataSourceGridCheckedSelection1.CheckMarkColumn.VisibleIndex = 0;

                Loadlayout2(_gridView2LayoutFileName);
                gridView2.Layout += new EventHandler(gridView2_Layout);

            }
        }

        private void ReadLithogicaData()
        {
            if (_lithologicalData != null)
            {
                _dataType = _gridView3LayoutFileName;


                gridView3.Layout -= new EventHandler(gridView3_Layout);
                gridView3.Columns.Clear();
                gridControl3.DataSource = _lithologicalData;

                OGT.Common.WinForm.Utility.AddExportToExcelFunctionToGridControl(gridControl3);
                OGT.Common.WinForm.Utility.AddDesignLayoutFunctionToGridView(gridView3);


                dataSourceGridCheckedSelection2 = new GridCheckMarksSelection(gridView3);
                dataSourceGridCheckedSelection2.CheckMarkColumn.VisibleIndex = 0;

                Loadlayout3(_gridView3LayoutFileName);
                gridView3.Layout += new EventHandler(gridView3_Layout);
            }
        }

        private void ReadSedimentaryFaciesData()
        {
            if (_sedimentaryFaciesData != null)
            {
                _dataType = _gridView4LayoutFileName;


                gridView4.Layout -= new EventHandler(gridView4_Layout);
                gridView4.Columns.Clear();
                gridControl4.DataSource = _sedimentaryFaciesData;

                OGT.Common.WinForm.Utility.AddExportToExcelFunctionToGridControl(gridControl4);
                OGT.Common.WinForm.Utility.AddDesignLayoutFunctionToGridView(gridView4);


                dataSourceGridCheckedSelection3 = new GridCheckMarksSelection(gridView4);
                dataSourceGridCheckedSelection3.CheckMarkColumn.VisibleIndex = 0;

                Loadlayout4(_gridView4LayoutFileName);
                gridView4.Layout += new EventHandler(gridView4_Layout);

            }
        }

        /// <summary>
        /// //获得匹配计算数据
        /// </summary>
        /// <returns></returns>
        private List<DataTable> GetDataTable()
        {
            List<int> indexes;
            List<int> indexes1;
            List<int> indexes2;
            List<int> indexes3;

            List<DataTable> _dataTables = new List<DataTable>();

            indexes = dataSourceGridCheckedSelection.GetCheckedDataSourceRowIndices();
            indexes1 = dataSourceGridCheckedSelection1.GetCheckedDataSourceRowIndices();
            indexes2 = dataSourceGridCheckedSelection2.GetCheckedDataSourceRowIndices();
            indexes3 = dataSourceGridCheckedSelection3.GetCheckedDataSourceRowIndices();

            DataTable GDF_XCFCSJ = new DataTable();
            DataTable GDF_CCJSJLSJ = new DataTable();
            DataTable GDF_YXJSSJ = new DataTable();
            DataTable GDF_CJXJSSJ = new DataTable();

            if (indexes.Count > 0)
            {
                DataTable gridTable1 = (DataTable)gridControl1.DataSource;
                GDF_XCFCSJ = gridTable1.Clone();
                foreach (int n in indexes)
                {
                    GDF_XCFCSJ.Rows.Add(gridTable1.Rows[n].ItemArray);
                }

            }
            else
            {
                DataTable gridTable1 = (DataTable)gridControl1.DataSource;
                GDF_XCFCSJ = gridTable1.Clone();
                //GDF_XCFCSJ.Merge(gridTable1);
            }

            if (indexes1.Count > 0)
            {
                DataTable gridTable2 = (DataTable)gridControl2.DataSource;
                GDF_CCJSJLSJ = gridTable2.Clone();
                foreach (int n in indexes1)
                {
                    GDF_CCJSJLSJ.Rows.Add(gridTable2.Rows[n].ItemArray);
                }
            }
            else
            {
                DataTable gridTable2 = (DataTable)gridControl2.DataSource;
                GDF_CCJSJLSJ = gridTable2.Clone();

            }

            if (indexes2.Count > 0)
            {
                DataTable gridTable3 = (DataTable)gridControl3.DataSource;
                GDF_YXJSSJ = gridTable3.Clone();
                foreach (int n in indexes2)
                {
                    GDF_YXJSSJ.Rows.Add(gridTable3.Rows[n].ItemArray);
                }

            }
            else
            {
                DataTable gridTable3 = (DataTable)gridControl3.DataSource;
                GDF_YXJSSJ = gridTable3.Clone();
                //GDF_YXJSSJ.Merge(gridTable3);

            }
            if (indexes3.Count > 0)
            {
                DataTable gridTable4 = (DataTable)gridControl4.DataSource;
                GDF_CJXJSSJ = gridTable4.Clone();
                foreach (int n in indexes3)
                {
                    GDF_CJXJSSJ.Rows.Add(gridTable4.Rows[n].ItemArray);
                }

            }
            else
            {
                DataTable gridTable4 = (DataTable)gridControl4.DataSource;
                GDF_CJXJSSJ = gridTable4.Clone();
                //GDF_CJXJSSJ.Merge(gridTable4);

            }

            _dataTables.Add(GDF_XCFCSJ);
            _dataTables.Add(GDF_CCJSJLSJ);
            _dataTables.Add(GDF_YXJSSJ);
            _dataTables.Add(GDF_CJXJSSJ);

            return _dataTables;

        }

        private List<List<DataTable>> GetMatchData()
        {
            List<List<DataTable>> wellDataSet = new List<List<DataTable>>();

            List<DataTable> dataTables = GetDataTable();

            List<string> wellName = new List<string>();
            foreach (DataRow dr in dataTables[0].Rows)
            {
                string value = dr["BZJH"].ToString();
                if (!wellName.Contains(value))
                {
                    wellName.Add(value);
                }
            }

            foreach (string str in wellName)
            {
                DataTable GDF_XCFCSJ = dataTables[0].Clone();
                DataTable GDF_CCJSJLSJ = dataTables[1].Clone();
                DataTable GDF_YXJSSJ = dataTables[2].Clone();
                DataTable GDF_CJXJSSJ = dataTables[3].Clone();

                GDF_XCFCSJ.TableName = "GDF_XCFCSJ";
                GDF_CCJSJLSJ.TableName = "GDF_CCJSJLSJ";
                GDF_YXJSSJ.TableName = "GDF_YXJSSJ";
                GDF_CJXJSSJ.TableName = "GDF_CJXJSSJ"; ;
                List<DataTable> tables = new List<DataTable>();

                foreach (DataRow dr in dataTables[0].Rows)
                {


                    if (dr["BZJH"].ToString() == str)
                    {
                        GDF_XCFCSJ.ImportRow(dr);
                    }
                }
                foreach (DataRow dr in dataTables[1].Rows)
                {

                    if (dr["BZJH"].ToString() == str)
                    {
                        GDF_CCJSJLSJ.ImportRow(dr);
                    }
                }
                foreach (DataRow dr in dataTables[2].Rows)
                {

                    if (dr["BZJH"].ToString() == str)
                    {
                        GDF_YXJSSJ.ImportRow(dr);
                    }
                }
                foreach (DataRow dr in dataTables[3].Rows)
                {

                    if (dr["BZJH"].ToString() == str)
                    {
                        GDF_CJXJSSJ.ImportRow(dr);
                    }
                }

                tables.Add(GDF_XCFCSJ);
                tables.Add(GDF_CCJSJLSJ);
                tables.Add(GDF_YXJSSJ);
                tables.Add(GDF_CJXJSSJ);
                wellDataSet.Add(tables);

            }



            return wellDataSet;

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

        #region ***布局文件***
        //保存布局文件
        void gridView1_Layout(object sender, EventArgs e)
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
        void gridView2_Layout(object sender, EventArgs e)
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
        void gridView3_Layout(object sender, EventArgs e)
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

        void gridView4_Layout(object sender, EventArgs e)
        {
            if (_dataType != _gridView4LayoutFileName)
                _dataType = _gridView4LayoutFileName;

            if (!string.IsNullOrEmpty(_filePath))
            {
                if (!Directory.Exists(_filePath))
                    Directory.CreateDirectory(_filePath);
                string path = Path.Combine(_filePath, _dataType);
                this.gridView4.SaveLayoutToXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }
        }
        void gridView5_Layout(object sender, EventArgs e)
        {
            if (_dataType != _gridView5LayoutFileName)
                _dataType = _gridView5LayoutFileName;

            if (!string.IsNullOrEmpty(_filePath))
            {
                if (!Directory.Exists(_filePath))
                    Directory.CreateDirectory(_filePath);
                string path = Path.Combine(_filePath, _dataType);
                this.gridView5.SaveLayoutToXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }
        }
        //加载布局文件
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
                this.gridControl3.RefreshDataSource();
            }

        }
        private void Loadlayout4(string file)
        {
            string path = "";

            if (!string.IsNullOrEmpty(_filePath))
            {
                path = Path.Combine(_filePath, file);
            }

            if (File.Exists(path))
            {
                this.gridView4.RestoreLayoutFromXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                this.gridControl4.RefreshDataSource();
            }

        }
        private void Loadlayout5(string file)
        {
            string path = "";

            if (!string.IsNullOrEmpty(_filePath))
            {
                path = Path.Combine(_filePath, file);
            }

            if (File.Exists(path))
            {
                this.gridView5.RestoreLayoutFromXml(path, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                this.gridControl5.RefreshDataSource();
            }

        }

        #endregion

        public delegate void SaveDataEventHandler(object sender, SaveDataEventArgs e);
        public event SaveDataEventHandler SaveDataCalled;

        #region***事件***
        
        private void ReservoirProcessControl_Load(object sender, EventArgs e)
        {
            this.ReadSublayerData();
            this.ReadReservoirData();
            this.ReadLithogicaData();
            this.ReadSedimentaryFaciesData();

            OGT.Common.WinForm.Utility.AddExportToExcelFunctionToGridControl(gridControl5);
            OGT.Common.WinForm.Utility.AddDesignLayoutFunctionToGridView(gridView5);
        }

        private void btnDataMatch_Click(object sender, EventArgs e)
        {
            OGT.Common.WinForm.Utility.ShowLoadingWaitForm("正在加载...");
            try
            {
                //SplashScreenManager.ShowForm(typeof(LoadForm));

                List<List<DataTable>> _wellDataSet = GetMatchData();

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string file = Path.Combine(_filePath, "小层分层.tpl");
                if (!File.Exists(file))
                {
                    MessageBox.Show(string.Format("未找到模板文件 【{0}】", file));
                    return;
                }

                Template template = Template.GetFromFile(file);
                if (template == null)
                    return;

                DataTable dt = new DataTable();
                for (int i = 0; i < _wellDataSet.Count; i++)
                {
                    DTMatchInfo info = new DTMatchInfo();
                    info.Sources = _wellDataSet[i];
                    info.Template = template;
                    DataTable temp = template.GetResultDataTable();


                    DTMatcher matcher = new DTMatcher();
                    matcher.MatchInfo = info;
                    DataTable matchtable = matcher.DoMatch();

                    Dictionary<DataRow, DataRow> mapping = matcher.GetRowsMapping(_wellDataSet[i][0].TableName);
                    foreach (DataRow key in matchtable.Rows)
                    {
                        DataRow value = mapping[key];
                        decimal minValue;
                        decimal maxValue;

                        if (value != null)
                        {
                            decimal yxhd;
                            minValue = Math.Max(Convert.ToDecimal(key["XCDS1"]), Convert.ToDecimal(value["DJSD1"]));
                            maxValue = Math.Min(Convert.ToDecimal(key["XCDS2"]), Convert.ToDecimal(value["DJSD2"]));
                            yxhd = maxValue - minValue;
                            key["YXHD"] = yxhd;

                        }


                    }
                    dt.Merge(matchtable);

                }
                if (textEdit1.Text != "")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["FCFAMC"] = textEdit1.Text;
                    }
                }


                _dataType = "MatchTable";

                gridView5.Layout -= new EventHandler(gridView5_Layout);
                gridView5.Columns.Clear();

                gridControl5.DataSource = dt;
                gridControl5.RefreshDataSource();
                Loadlayout5("MatchTable");
                gridView5.Layout += new EventHandler(gridView5_Layout);

                //SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                OGT.Common.WinForm.Utility.CloseLoadingWaitForm();
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                OGT.Common.WinForm.Utility.ShowLoadingWaitForm(("正在保存..."));
                this.gridControl5.Focus();
                DataTable _dt = (DataTable)gridControl5.DataSource;
                DateTime databaseTime = GetDataBaseTime();

                //SaveData saveData = new SaveData();
                //DateTime dataBaeTime = saveData.GetDataBaseTime();
                //saveData.SaveReseroirData(_dt, dataBaeTime);
                if (SaveDataCalled != null)
                    SaveDataCalled(this, new SaveDataEventArgs(_dt, databaseTime));
                OGT.Common.WinForm.Utility.CloseLoadingWaitForm();
                MessageBox.Show("保存成功");
            }
            catch(Exception ex)
            {
                OGT.Common.WinForm.Utility.CloseLoadingWaitForm();
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 获取数据库的当前时间
        /// </summary>
        /// <returns></returns>
        
        #endregion
    }
}
