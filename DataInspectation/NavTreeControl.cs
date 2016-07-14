using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OGT.Common.WinForm.XtraAgileTreeControl;

namespace DataInspectation.Controls
{
    public partial class NavTreeControl : UserControl
    {
        #region ***Fields***
        private XtraAgileTreeControl _agileTree;
        private DataTable _totalWells;

        public DataTable TotalWells
        {
            get { return _totalWells; }
            set
            {
                _totalWells = value;
                if (_totalWells == null || _totalWells.Rows.Count == 0)
                    return;

                BindAgileTreeControl(_totalWells);
            }
        }
        #endregion

        #region ***Constructor***
        public NavTreeControl()
        {
            InitializeComponent();
        }
        #endregion

        #region ***Private Methods***
        private void BindAgileTreeControl(DataTable dt)
        {
            _agileTree.Nodes.Clear();
            _agileTree.DataSource = ProcessTable(_totalWells).AsDataView();
            _agileTree.ColumnsShownOnTree = GetColumnsShowOnTree(dt);
            _agileTree.ShowData();
            _agileTree.BestFitAllColumns();
        }
        private DataTable ProcessTable(DataTable dt)
        {
            DataTable resultTable = dt.Clone();

            if (dt != null || dt.Columns.Count != 0)
            {
                List<int> WIDs = dt.AsEnumerable().Select<DataRow, int>(r => Convert.ToInt32(r["WID"])).Distinct().ToList<int>();
                List<DataRow> rows = new List<DataRow>();
                DateTime dtStart;
                DateTime dtEnd;
                DateTime dtStart2;
                DateTime dtEnd2;

                foreach (int wid in WIDs)
                {
                    rows = dt.AsEnumerable().Where(r => Convert.ToInt32(r["WID"]) == wid).ToList<DataRow>();

                    for (int i = 0; i < rows.Count - 1; i++)
                    {
                        dtStart = Convert.ToDateTime(rows[i]["KGRQ"]);
                        dtEnd = Convert.ToDateTime(rows[i]["WGRQ"]);
                        for (int j = i + 1; j < rows.Count; j++)
                        {
                            dtStart2 = Convert.ToDateTime(rows[j]["KGRQ"]);
                            dtEnd2 = Convert.ToDateTime(rows[j]["WGRQ"]);
                            if ((dtStart > dtStart2 && dtStart < dtEnd2) || (dtStart > dtStart2 && dtEnd < dtEnd2) || (dtEnd > dtStart2 && dtEnd < dtEnd2) || (dtStart2 > dtStart && dtEnd2 < dtEnd))
                            {
                                resultTable.Rows.Add(rows[i].ItemArray);
                                resultTable.Rows.Add(rows[j].ItemArray);
                                break;
                            }
                        }
                    }
                }
            }
            return resultTable;
        }
        private List<OGT.Common.Controls.WinForm.AgileTreeView.Column> GetColumnsShowOnTree(DataTable dt)
        {
            List<OGT.Common.Controls.WinForm.AgileTreeView.Column> columns = new List<OGT.Common.Controls.WinForm.AgileTreeView.Column>();
            DataColumn datacol = null;
            OGT.Common.Controls.WinForm.AgileTreeView.Column col = null;
            if (dt.Columns.Contains("BZJH"))
            {
                datacol = dt.Columns["BZJH"];
                col = new OGT.Common.Controls.WinForm.AgileTreeView.Column(datacol.ColumnName);
                col.Caption = datacol.Caption;
                columns.Add(col);
            }
            return columns;
        }
        private void InitAgileTreeControl()
        {
            _agileTree = new XtraAgileTreeControl();
            _agileTree.MultiSelect = false;
            _agileTree.AdvancedUI = false;
            _agileTree.ShowDescription = false;
            _agileTree.ShowRootNode = false;
            _agileTree.NullText = "空值";
            _agileTree.GroupColumnHeader = "标准井号";
            _agileTree.TreeList.OptionsBehavior.Editable = false;
            _agileTree.CreateTreeNodeTag = CreateTreeNodeTag;
            _agileTree.ShowImage = false;
            //_agileTree.Images=
            _agileTree.ShowIndicator = false;
            _agileTree.AutoSaveLayout = true;
            _agileTree.UseDefaultTemplate = true;
            _agileTree.AllowDrop = false;
            _agileTree.Dock = DockStyle.Fill;
            _agileTree.Padding = new Padding(0);
            _agileTree.ShowRoot = false;
            _agileTree.BestFitAllColumns();
            _agileTree.FocusedNodeChanged += _agileTree_FocusedNodeChanged;
            Controls.Add(_agileTree);
        }

        private void _agileTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            string bzjh = _agileTree.SelectedNode.Tag as string;
            if (SelectedWellChanged != null)
                SelectedWellChanged(this, new SelectedWellChangedEventArgs(bzjh));
        }

        /// <summary>
        /// 为树节点构造Tag
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private object CreateTreeNodeTag(DataRowView row, OGT.Common.Controls.WinForm.AgileTreeView.Column column)
        {
            return row["BZJH"].ToString();
        }
        #endregion
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitAgileTreeControl();
        }
        public event SelectedWellChangedEventHandler SelectedWellChanged;
    }
    public delegate void SelectedWellChangedEventHandler(object sender, SelectedWellChangedEventArgs e);

    public class SelectedWellChangedEventArgs
    {
        public string BZJH { get; set; }
        public SelectedWellChangedEventArgs( string bzjh)
        {
            BZJH = bzjh;
        }
    }
}
