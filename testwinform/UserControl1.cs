using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OGT.DockingManager.Helper;
using System.IO;

namespace testwinform
{
    public partial class UserControl1 : UserControl
    {
        private XtraDockManagerHelper _xtraDockManagerHelper = null;
        private string _workDirectory;
        private string _xtraDockManagerLayoutFileName = string.Empty;
        public string WorkDirectory
        {
            get { return _workDirectory; }
            set
            {
                _workDirectory = value;
                if (!Directory.Exists(_workDirectory))
                    Directory.CreateDirectory(_workDirectory);
                this._xtraDockManagerLayoutFileName = Path.Combine(_workDirectory, "MainXtraDockManagerLayout.xml");

            }
        }
        public UserControl1()
        {
            InitializeComponent();
            this._xtraDockManagerHelper = new XtraDockManagerHelper(this);
            this._xtraDockManagerHelper.XtraDockManagerLayoutChanged += _xtraDockManagerHelper_XtraDockManagerLayoutChanged;
        }

        void _xtraDockManagerHelper_XtraDockManagerLayoutChanged()
        {
            if (!string.IsNullOrEmpty(_workDirectory))
                this._xtraDockManagerHelper.SaveXtraDockManagerLayout(this._xtraDockManagerLayoutFileName);
        }
    }
}
