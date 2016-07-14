using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using OGT.Common.WPF.Controls.DbLoginControl.Model;
using OGT.Dynalyze.Common;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using OGT.Entity;
using DataInspectation.Controls;
using System.Diagnostics;
using testwinform.Mudules;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace testwinform
{
    public partial class Form1 : XtraForm
    {
        XtraNaviTreeControl _navigatorTree;
        NavTreeControl _navTreeControl;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitConnecctions();
            //InitNavTreeControl();
            //if (_connString != null)
            //    _navTreeControl.TotalWells = GetDataTable(_connString);
            
            
        }
        string _connString = null;
        private void InitConnecctions()
        {
            DbConnectionInfo connInfo = GetSourceDbConnInfoByStartupArgs();
            if (connInfo == null)
            {
                connInfo = OGT.Common.DbConnModule.DbConnectionManager.Instance.SelectConnection();
                _connString = connInfo.ConnStringBuilder.ConnectionString;
            }
            if (connInfo == null)
                Application.Exit();


        }
        private static DbConnectionInfo GetSourceDbConnInfoByStartupArgs()
        {
            StartupArgs args = StartupArgs.Instance;
            if (args == null)
                return null;

            string connName = args.EJDWDM;

            if (string.IsNullOrWhiteSpace(connName))
                return null;

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConnectionStrings");
            if (Directory.Exists(dir) == false)
                return null;

            string file = Path.Combine(dir, connName + ".cef");
            if (File.Exists(file) == false)
                return null;

            try
            {
                return DbConnectionInfo.Open(file);
            }
            catch { }

            return null;
        }
        private void InitControls()
        {
            _navigatorTree = new XtraNaviTreeControl();
            _navigatorTree.Dock = DockStyle.Fill;
            _navigatorTree.Padding = new Padding(3);

            this.panelContainer.Controls.Add(_navigatorTree);
        }
        private void InitNavTreeControl()
        {
            _navTreeControl = new NavTreeControl();
            _navTreeControl.Dock = DockStyle.Fill;
            _navTreeControl.Padding = new Padding(3);
            this.panelContainer.Controls.Add(_navTreeControl);
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private DataTable GetDataTable(string connString)
        {
            DataTable dt;
            DataTable resultTable;

            try
            {
                EntityHelper.Initialize(OGT.DDLHelper.DatabaseTypeEnum.Oracle, _connString);
                dt = EntityHelper.FindDataTable("select a.WID,a.KGRQ,a.WGRQ,b.BZJH from ZY_ZYZJJBSJ a,DZ_JJCSJ b where a.WID=b.ID order by a.WID");
                resultTable = dt.Clone();
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

                        for (int i = 0; i < rows.Count-1; i++)
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
            catch (Exception ex)
            {
                return null;
            }
        }

        private void panelControlTest_Paint(object sender, PaintEventArgs e)
        {

        }

        #region MyRegion

        //DataTable dt = new DataTable("testTable");
        //dt.Columns.Add("BZJH", typeof(string));
        //dt.Columns.Add("ID", typeof(Int32));
        //dt.Columns.Add("WID", typeof(Int32));
        //dt.Columns.Add("HZJH", typeof(string));
        //dt.Columns.Add("MQJLB", typeof(string));

        //dt.Rows.Add(null, 1, 001, "井1", "采油井");
        //dt.Rows.Add("jing2", 2, 002, "井2", "注气井");
        //dt.Rows.Add("jing3", 3, 003, "井3", "报废井");
        //dt.Rows.Add("jing4", 3, 003, "井3", "报废");


        //return dt; 
        #endregion

    }
}
