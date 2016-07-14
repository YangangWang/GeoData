using OGT.GeoDataFactory.DataProcessControl;
using OGT.GeoDataFactory.DataProcessControl.ReservoirSplitterControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeoDataFactory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ReservoirProcessControl c = new ReservoirProcessControl();
            //c.Dock = DockStyle.Fill;
            //c.SublayerData = GetTable();
            //c.ReservoirData = GetTable();
            //c.LithologicalData = GetTable();
            //c.SedimentaryFaciesData = GetTable();
            //this.Controls.Add(c);
            ReservoirSplitterControl c = new ReservoirSplitterControl();
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);

            
        }
        private DataTable GetTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID",typeof(int));
            dt.Columns.Add("Name",typeof(string));
            dt.Rows.Add(1, "wang");
            dt.Rows.Add(2, "yang");
            return dt;
        }
    }
}
