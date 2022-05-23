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
    public partial class FormChartLinks : Form
    {
        public FormChartLinks(bool[,] matrix, List<int> pointList)
        {
            InitializeComponent();
            CData.FillChartLinks(chartVis, matrix, pointList, 2);
        }
    }
}
