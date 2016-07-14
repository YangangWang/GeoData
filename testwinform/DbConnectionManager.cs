using OGT.Common.WPF.Controls.DbLoginControl.Model;
using OGT.Dynalyze.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace testwinform
{
    class DbConnectionManager
    {
        #region 字段属性。

        /// <summary>
        /// 获取或设置当前数据库连接对象。
        /// </summary>
        //public DbConnectionInfo CurrentConnection
        //{
        //    get { return OGT.Common.DbConnModule.DbConnectionManager.Instance.CurrentConnection; }
        //    set { OGT.Common.DbConnModule.DbConnectionManager.Instance.CurrentConnection = value; }
        //}

        public DbConnectionInfo CurrentConnection
        {
            get { return OGT.Common.DbConnModule.DbConnectionManager.Instance.CurrentConnection; }
            set { OGT.Common.DbConnModule.DbConnectionManager.Instance.CurrentConnection = value; }
        }
        #endregion

        #region 初始化，单例模式。

        private DbConnectionManager()
        {
        }

        //private static readonly object _syncRoot = new object();

        private static DbConnectionManager _instance;
        public static DbConnectionManager Instance
        {
            get
            {
                //if( _instance == null )
                //    lock( _syncRoot )
                if (_instance == null)
                    _instance = new DbConnectionManager();

                return _instance;
            }
        }

        #endregion

        #region 私有方法。

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

        #endregion

        #region 公共方法。

        public DbConnectionInfo SelectConnection()
        {
            return OGT.Common.DbConnModule.DbConnectionManager.Instance.SelectConnection();
        }

        public DbConnectionInfo GetDefaultConnection()
        {
            return GetSourceDbConnInfoByStartupArgs();
        }

        #endregion
    }
}
