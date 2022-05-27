using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class FormHelp : Form
    {
        public FormHelp(int tab)
        {
            InitializeComponent();
            tabControl1.SelectedIndex = tab;
        }
    }
}
