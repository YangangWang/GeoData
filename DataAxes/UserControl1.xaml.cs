using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataAxes
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private DataTable _dtSource;

        public DataTable DtSource
        {
            get { return _dtSource; }
            set
            {
                _dtSource = value;
                if (_dtSource != null && _dtSource.Rows.Count != 0)
                {
                    ProcessTable();
                    Paint();
                }
            }
        }

        #region ***Constructor***
        public UserControl1()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 这个方法用来辅助绘图。返回的整数值表示在这次作业数据之后要不要绘制间隔线，来表示两次作业相隔了相当长的时间。
        /// </summary>
        /// <returns></returns>
        private List<int> GroupRow()
        {
            if (_dtSource == null || _dtSource.Rows.Count == 0)
                return null;

            DateTime dtKGRQ;
            DateTime dtWGRQ;
            TimeSpan span = new TimeSpan(1, 0, 0, 0);
            List<int> result = new List<int>();

            for (int i = 0; i < _dtSource.Rows.Count - 1; i++)
            {
                dtKGRQ = Convert.ToDateTime(_dtSource.Rows[i]["KGRQ"]);
                dtWGRQ = Convert.ToDateTime(_dtSource.Rows[i + 1]["QGRQ"]);
                if (dtWGRQ - dtKGRQ > span)
                    result.Add(i);
            }
            return result;
        }

        /// <summary>
        /// 如果两个作业的相隔时间太长，就把两次作业之间的间隔缩短，利于绘图
        /// </summary>
        private void ProcessTable()
        {
            if (_dtSource == null || _dtSource.Rows.Count == 0)
                return;

            DateTime dtKGRQ;
            DateTime dtWGRQ;
            TimeSpan span = new TimeSpan(2, 0, 0, 0);

            for (int i = 0; i < _dtSource.Rows.Count - 1; i++)
            {
                dtWGRQ = Convert.ToDateTime(_dtSource.Rows[i]["WGRQ"]);
                dtKGRQ = Convert.ToDateTime(_dtSource.Rows[i + 1]["KGRQ"]);
                TimeSpan span1 = dtKGRQ - dtWGRQ;
                if (span1 > span)
                {
                    for (int j = i + 1; j < _dtSource.Rows.Count; j++)
                    {
                        _dtSource.Rows[j]["KGRQ"] = Convert.ToDateTime(_dtSource.Rows[j]["KGRQ"]) - span1 + new TimeSpan(1, 0, 0, 0);
                        _dtSource.Rows[j]["WGRQ"] = Convert.ToDateTime(_dtSource.Rows[j]["WGRQ"]) - span1 + new TimeSpan(1, 0, 0, 0);
                    }
                }
            }
        }
        private List<double[]> GetPoints()
        {
            if (_dtSource == null || _dtSource.Rows.Count == 0)
                return null;

            //double startX = 10d;
            double startY = 40d;
            //double width = 40d;
            double height = 20d;
            double startSpace = 10d;

            //p[0]代表矩形定点的x坐标，p[1]代表y坐标，p[2]代表矩形的长度
            double[] point;
            List<double[]> result = new List<double[]>();

            DateTime dtStart = Convert.ToDateTime(_dtSource.Rows[0]["KGRQ"]);
            TimeSpan span1 = new TimeSpan();
            TimeSpan span2 = new TimeSpan();

            for (int i = 0; i < _dtSource.Rows.Count; i++)
            {
                point = new double[3];
                span1 = Convert.ToDateTime(_dtSource.Rows[i]["KGRQ"]) - dtStart;
                span2 = Convert.ToDateTime(_dtSource.Rows[i]["WGRQ"]) - Convert.ToDateTime(_dtSource.Rows[i]["KGRQ"]);
                if (i % 2 == 0)
                    point[1] = startY - height;
                else if (i % 2 != 0)
                    point[1] = startY;
                point[0] = startSpace + ConvertToDouble(span1);
                point[2] = startSpace + ConvertToDouble(span2);

                result.Add(point);
            }

            return result;
        }

        private double ConvertToDouble(TimeSpan span)
        {
            //一天在图上代表40单位长度
            return span.Days * 40;
        }
        private void Paint()
        {
            List<double[]> points = GetPoints();
            GeometryGroup gg = path1.Data as GeometryGroup;

            LineGeometry lg = new LineGeometry(new Point(0, 40), new Point(points[points.Count - 1][0], 40));
            gg.Children.Add(lg);

            RectangleGeometry rg;
            for (int i = 0; i < points.Count; i++)
            {
                rg = new RectangleGeometry();
                rg.Rect = new Rect(points[i][0], points[i][1], points[i][2], 20);
                gg.Children.Add(rg);
            }
        }
    }
}
