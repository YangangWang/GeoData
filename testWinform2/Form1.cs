using OGT.Common.DbLogin;
using OGT.Dynalyze.Common;
using OGT.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testWinform2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbConnectionInfo info = GetSourceDbConnInfoByStartupArgs();
            if (info == null)
                info=OGT.Common.DbConnModule.DbConnectionManager.Instance.SelectConnection();
            if (info == null)
                return;

            string connStr = info.ConnStringBuilder.ConnectionString;
            EntityHelper.Initialize(OGT.DDLHelper.DatabaseTypeEnum.Oracle, connStr);
            userControl11.DtSource = EntityHelper.FindDataTable("select * from ZY_ZYZJJBSJ where WID=3713");
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
    }
}
