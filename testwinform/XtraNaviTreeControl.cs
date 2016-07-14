using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OGT.Common.WinForm.XtraAgileTreeControl;
using OGT.Common.Controls.WinForm.AgileTreeView;
using OGT.Production.Infrastructure.BusinessObject;


namespace testwinform
{
    public partial class XtraNaviTreeControl : UserControl
    {
        private XtraAgileTreeControl _agileTree;
        private DataTable _dtTotalWells;
        private WellBaseTreeColumn _column = WellBaseTreeColumn.Instance;
        private List<WellSummary> _registerWells;

        public DataTable DtTotalWells
        {
            get { return _dtTotalWells; }
            set
            {
                _dtTotalWells = value;
                if (_dtTotalWells == null || _dtTotalWells.Rows.Count == 0)
                    return;

                BindAgileTreeControl(_dtTotalWells);
            }
        }
        private void BindAgileTreeControl(DataTable dtAllWells)
        {
            _agileTree.Nodes.Clear();
            _agileTree.DataSource = dtAllWells.AsDataView();
            _agileTree.ColumnsShownOnTree = GetColumnsShowOnTree(dtAllWells);
            try
            {
                _agileTree.ShowData();
            }
            catch (Exception ex)
            {

            }

            _agileTree.BestFitAllColumns();
        }

        private List<OGT.Common.Controls.WinForm.AgileTreeView.Column> GetColumnsShowOnTree(DataTable dt)
        {
            List<OGT.Common.Controls.WinForm.AgileTreeView.Column> columns = new List<OGT.Common.Controls.WinForm.AgileTreeView.Column>();
            DataColumn dataCol = null;
            Column col = null;
            if (dt.Columns.Contains(_column.ColBZJH))
            {
                dataCol = dt.Columns[_column.ColBZJH];
                col = new Column(dataCol.ColumnName);
                col.Caption = dataCol.Caption;
                columns.Add(col);
            }
            return columns;
        }


        public XtraNaviTreeControl()
        {
            _registerWells = new List<WellSummary>();
            InitializeComponent();

            InitAgileTreeControl();
        }
        private void InitAgileTreeControl()
        {
            _agileTree = new XtraAgileTreeControl();
            _agileTree.AdvancedUI = false;
            _agileTree.MultiSelect = false;
            _agileTree.ShowRootNode = false;
            _agileTree.ShowDescription = true;
            _agileTree.NullText = "no value,haha";
            _agileTree.TreeList.OptionsBehavior.Editable = false;
            _agileTree.CreateTreeNodeTag = CreateTag;
            _agileTree.GroupColumnHeader = "标准井号";
            _agileTree.ShowImage = true;
            _agileTree.Images = imageList1;
            _agileTree.SpecificNodeImages = GetSpecificNodeImages();
            _agileTree.ShowIndicator = false;
            _agileTree.AutoSaveLayout = true;
            _agileTree.UseDefaultTemplate = true;
            //_agileTree.UseDefaultImage = true;
            _agileTree.AllowDrop = false;
            _agileTree.Dock = DockStyle.Fill;
            _agileTree.Padding = new Padding(0);
            _agileTree.ShowRoot = false;
            

            _agileTree.BestFitAllColumns();

            this.panelTreeContainer.Controls.Add(_agileTree);
        }

        private List<NodeImage> GetSpecificNodeImages()
        {
            try
            {
                List<NodeImage> nodeImages=new List<NodeImage> ();

                Dictionary<object,string> columnDisplay0=new Dictionary<object,string> ();
                columnDisplay0.Add(_column.ColMQJLB,"采油井");
                nodeImages.Add(new NodeImage(0,columnDisplay0,0,0));


                Dictionary<object,string> columnDisplay1=new Dictionary<object,string> ();
                columnDisplay1.Add(_column.ColMQJLB,"注气井");
                nodeImages.Add(new NodeImage(0,columnDisplay1,1,1));

                Dictionary<object,string> columnDisplay2=new Dictionary<object,string> ();
                columnDisplay2.Add(_column.ColMQJLB,"报废井");
                nodeImages.Add(new NodeImage(0,columnDisplay2,2,2));

                nodeImages.Add(new NodeImage(0,3,3));

                return nodeImages;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private object CreateTag(DataRowView row, OGT.Common.Controls.WinForm.AgileTreeView.Column column)
        {
            int wid = Convert.ToInt32(row[_column.ColWID]);
            WellSummary ws = _registerWells.Find(r => r.WID ==wid);

            if (ws != null)
                return ws;

            ws = new WellSummary(wid, row[_column.ColBZJH].ToString(), row[_column.ColHZJH].ToString(), TranslateWellCategory(row[_column.ColWID].ToString()));
            _registerWells.Add(ws);

            return ws;
        }

        private OGT.Production.Infrastructure.BusinessObject.WellCategory TranslateWellCategory(string category)
        {
            switch (category)
            {
                case "采油井":
                    return WellCategory.Oil;
                case "注水井":
                    return WellCategory.Water;
                default:
                    return WellCategory.Unknown;
            }
        }
    }
}
