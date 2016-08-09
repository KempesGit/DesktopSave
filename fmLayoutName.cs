using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopSave
{
    public partial class FormLayoutName : Form
    {
        public FormLayoutName()
        {
            InitializeComponent();
        }

        private void tbLayoutName_TextChanged(object sender, EventArgs e)
        {
            btAdd.Enabled = tbLayoutName.Text.Trim().Length > 0;
        }
    }
}
