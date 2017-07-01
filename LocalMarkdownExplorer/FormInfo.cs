using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LocalMarkdownExplorer
{
    public partial class FormInfo : Form
    {
        Form1 form1;

        public FormInfo()
        {
            InitializeComponent();
        }

        public FormInfo(Form1 parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            lbAppTitle.Text = form1.appTitle;
            lbAppVersion.Text = "version 1.0";
            lbCredit.Text = "Takuto Negishi";
        }
    }
}
