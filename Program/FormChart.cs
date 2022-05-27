using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Coursework
{
    /// <summary>
    /// Форма для отображения графика
    /// </summary>
    public partial class FormChart : Form
    {
        /// <summary>
        /// Конструктор конструкторный
        /// </summary>
        /// <param name="seriesCollection">Серия из графика</param>
        /// <param name="xName">Подпись для оси X</param>
        /// <param name="yName">Подпись для оси Y</param>
        /// <param name="GraphName">Имя отображаемое в заголовке</param>
        public FormChart(SeriesCollection seriesCollection, string xName, string yName, string GraphName)
        {
            InitializeComponent();
            this.Text = GraphName;
            chartVis.Series.Clear();
            chartVis.ChartAreas[0].AxisX.Title = xName;
            chartVis.ChartAreas[0].AxisY.Title = yName;
            foreach (Series s in seriesCollection)
            {
                chartVis.Series.Add(s.Name);
                chartVis.Series[s.Name].ChartType = SeriesChartType.Spline;
                for (int i = 0; i < s.Points.Count; i++)
                {
                    chartVis.Series[s.Name].Points.AddXY(s.Points[i].XValue, s.Points[i].YValues[0]);
                    chartVis.Series[s.Name].Font = new Font(chartVis.Series[s.Name].Font.Name, 10, Font.Style);
                    
                }
                checkedListBoxSeries.Items.Add(s.Name, true);
            }
            comboBoxLinesType.SelectedIndex = 0;
        }

        // Метод загрузки формы
        private void FormChart_Load(object sender, EventArgs e)
        {
            numericUpDownLineWidth.Value = 2;
            checkBoxTags.Checked = true;
            radioButtonTagCaptionNumber.Checked = true;
        }

        // Изменение флага у отображения сетки
        private void checkBoxGridVisible_CheckedChanged(object sender, EventArgs e)
        {
            bool newFlag = (sender as CheckBox).Checked;
            chartVis.ChartAreas[0].AxisX.MajorGrid.Enabled = newFlag;
            chartVis.ChartAreas[0].AxisY.MajorGrid.Enabled = newFlag;
        }

        // Изменение флага у отображения подписей к осям
        private void checkBoxCaptoin_CheckedChanged(object sender, EventArgs e)
        {
            bool newFlag = (sender as CheckBox).Checked;
            chartVis.ChartAreas[0].AxisX.LabelStyle.Enabled = newFlag;
            chartVis.ChartAreas[0].AxisY.LabelStyle.Enabled = newFlag;
        }

        // Изменение отображения маркеров графиков
        private void checkBoxTags_CheckedChanged(object sender, EventArgs e)
        {
            bool newFlag = (sender as CheckBox).Checked;
            for (int i = 0; i < chartVis.Series.Count; i++)
            {
                if (newFlag == true)
                {
                    chartVis.Series[i].MarkerStyle = MarkerStyle.Circle;
                }
                else
                {
                    chartVis.Series[i].MarkerStyle = MarkerStyle.None;
                }
            }
        }

        // Делегат для зменения серий
        delegate void FuncToChangeSeries(int i, int j);

        // Функция для изменнеия всех серий графика
        private void ChangeAllSeries(FuncToChangeSeries func)
        {
            for (int i = 0; i < chartVis.Series.Count; i++)
            {
                for (int j = 0; j < chartVis.Series[i].Points.Count; j++)
                {
                    func(i, j);
                }
            }
        }

        // Убрать подписи к маркерам графика
        private void radioButtonTagCaptionNone_CheckedChanged(object sender, EventArgs e)
        {
            bool newFlag = (sender as RadioButton).Checked;
            if (newFlag == true)
            {
                ChangeAllSeries((i, j) => { chartVis.Series[i].Points[j].Label = ""; });
            }
        }

        // Включить подписи к маркерам по их номерам
        private void radioButtonTagCaptionNumber_CheckedChanged(object sender, EventArgs e)
        {
            bool newFlag = (sender as RadioButton).Checked;
            if (newFlag == true)
            {
                ChangeAllSeries((i, j) => { chartVis.Series[i].Points[j].Label = j.ToString(); });
            }
        }

        // Включить подписи к маркерам по их значениям
        private void radioButtonTagCaptionValue_CheckedChanged(object sender, EventArgs e)
        {
            bool newFlag = (sender as RadioButton).Checked;
            if (newFlag == true)
            {
                ChangeAllSeries((i, j) => 
                {
                    double y = chartVis.Series[i].Points[j].YValues[0];
                    if (Math.Round(y, 4) != 0)
                    {
                        y = Math.Round(y, 4);
                    }
                    else
                    {
                        y = Math.Round(y, 7);
                    }
                    chartVis.Series[i].Points[j].Label = y.ToString();
                });
            }
        }

        // Изменить толщину линий графика
        private void numericUpDownLineWidth_ValueChanged(object sender, EventArgs e)
        {
            int newSize = Convert.ToInt32(numericUpDownLineWidth.Value);
            ChangeAllSeries((i, j) => 
            {
                chartVis.Series[i].BorderWidth = newSize;
                chartVis.Series[i].MarkerSize = newSize * 3 + 2;
            });
        }

        // Измненеие типа линий
        private void comboBoxLinesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesChartType newType;
            if (comboBoxLinesType.SelectedIndex == 0)
            {
                newType = SeriesChartType.Spline;
            }
            else if (comboBoxLinesType.SelectedIndex == 1)
            {
                newType = SeriesChartType.Line;
            }
            else
            {
                newType = SeriesChartType.Point;
            }
            ChangeAllSeries((i, j) =>
            {
                chartVis.Series[i].ChartType = newType;
            });
        }

        // Включение/выключение серии у графика
        private void checkedListBoxSeries_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < checkedListBoxSeries.Items.Count; i++)
            {
                chartVis.Series[i].Enabled = checkedListBoxSeries.GetItemChecked(i);
            }
            chartVis.ChartAreas[0].RecalculateAxesScale();
        }

        // Кнопка открытия окна справки
        private void buttonFormHelp_Click(object sender, EventArgs e)
        {
            FormHelp form = new FormHelp(5);
            form.Show();
        }
    }
}