using DataInspectation.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppStart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        private DataTable GetTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BZJH");
            dt.Rows.Add("wang");
            dt.Rows.Add("yan");

            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavTreeControl navtree = new NavTreeControl();
            navtree.Dock = DockStyle.Fill;
            navtree.TotalWells = GetTable();
            Controls.Add(navtree);
        }
    }
}
