using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace testwinform
{
    public partial class TutorialControl : Component
    {
        public TutorialControl()
        {
            InitializeComponent();
        }

        public TutorialControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
