using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OGT.GeoDataFactory.DataProcessControl
{
    /// <summary>
    /// 用来储存要保存的信息，包括要保存的表，还有数据库的当前时间
    /// </summary>
   public class SaveDataEventArgs:EventArgs
    {
        private DataTable _dtSource;
        /// <summary>
        /// 要保存的数据表
        /// </summary>
        public DataTable DtSource
        {
            get { return _dtSource; }
            set { _dtSource = value; }
        }
        private DateTime _databaseTime;
        /// <summary>
        /// 数据库的时间
        /// </summary>
        public DateTime DatabaseTime
        {
            get { return _databaseTime; }
            set { _databaseTime = value; }
        }
        /// <summary>
        /// 构造要保存到数据库的信息
        /// </summary>
        /// <param name="dtSource">要保存的表</param>
        /// <param name="databaseTime">数据库时间</param>
        public SaveDataEventArgs(DataTable dtSource,DateTime databaseTime)
        {
            this._dtSource = dtSource;
            this._databaseTime = databaseTime;
        }
    }
}
