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
using System.Resources;

namespace Coursework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            numericUpDownDecNumb.Value = CData.DecNumbToOutput;
        }

        /// <summary>
        /// Открыть базу данных с помощью файлового диалога
        /// </summary>
        private void OpenDataBaseWithFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Базы данных (*.db;*.sqlite)|*.db;*.sqlite|Все файлы|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (CRequest.DBIsOpen == true)
                {
                    CloseDB();
                }
                CRequest.OpenDB(fileDialog.FileName);
            }
        }

        /// <summary>
        /// Закрыть базу данных
        /// </summary>
        private void CloseDB()
        {
            dataGridViewData.Rows.Clear();
            dataGridViewData.Columns.Clear();
            comboBoxTable.Items.Clear();
            comboBoxTable.Enabled = false;
            textBoxT.Text = "";
            textBoxT.Enabled = false;
            textBoxA.Text = "";
            textBoxA.Enabled = false;
            pictureBoxInData = null;
            pictureBoxLvl1 = null;
            buttonAddRow.Enabled = false;
            buttonDeleteRows.Enabled = false;
            buttonCalculateDecomp.Enabled = false;
            CRequest.CloseDB();
        }

        // Кнопка подключения базы данных
        private void buttonDBConnect_Click(object sender, EventArgs e)
        {
            OpenDataBaseWithFileDialog();            
            if (CRequest.DBIsOpen == true)
            {
                textBoxT.Text = CData.T.ToString();
                textBoxT.Enabled = true;
                textBoxA.Text = CData.A.ToString();
                textBoxA.Enabled = true;
                pictureBoxInData.Image = CRequest.IMG;
                pictureBoxLvl1.Image = CRequest.IMG;
                comboBoxTable.Items.AddRange(CRequest.TableNames);
                if (comboBoxTable.Items.Count != 0)
                {
                    comboBoxTable.Enabled = true;
                    comboBoxTable.SelectedIndex = 0;
                    CRequest.OpenAndShowTable(dataGridViewData, comboBoxTable.SelectedItem.ToString());
                    buttonAddRow.Enabled = true;
                    buttonDeleteRows.Enabled = true;
                    buttonCalculateDecomp.Enabled = true;
                }
            }
        }

        // Кнопка загрузки изображения в БД
        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Изображения (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|Все файлы|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(fileDialog.FileName);
                pictureBoxInData.Image = image;
                CRequest.IMG = image;
            }
        }

        // Кнопка закрытия БД
        private void buttonDBClose_Click(object sender, EventArgs e)
        {
            CloseDB();
        }

        // Проверка вводимых значений в TextBox
        private void textBoxDigitFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            // 8 - backspace
            if (Char.IsDigit(symbol) == false && symbol != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        // Изменение значения в TextBox для T
        private void textBoxT_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Text != "" && tb.Text[tb.Text.Length - 1] != ',' && tb.Text[tb.Text.Length - 1] != '0')
            {
                CRequest.WriteT(Convert.ToDouble(tb.Text));
            }
        }

        // Изменение значения в TextBox для A
        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Text != "" && tb.Text[tb.Text.Length - 1] != ',' && tb.Text[tb.Text.Length - 1] != '0')
            {
                CRequest.WriteA(Convert.ToDouble(tb.Text));
            }
        }

        // Изменение выбранной таблицы
        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRequest.OpenAndShowTable(dataGridViewData, comboBoxTable.SelectedItem.ToString());
        }

        // Кнопка добавления строки
        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            CRequest.AddRowAndShow(dataGridViewData);
        }

        // Кнопка удаления строк
        private void buttonDeleteRows_Click(object sender, EventArgs e)
        {
            CRequest.DeleteRowsAndShow(dataGridViewData);
        }

        // Кнопка сохранения изменений в БД
        private void ToolStripSaveDB_Click(object sender, EventArgs e)
        {
            CRequest.SaveTable();
        }

        // Кнопка подсчета декомпозиций
        private void buttonCalculateDecomp_Click(object sender, EventArgs e)
        {
            CalculateLvl1 Calculated = new CalculateLvl1(CData.Table);
            Calculated.FillChartAllM(chartAllM);
            Calculated.FillChartPhase(chartPhase);
            Calculated.CalculateAndFillAccident(dataGridView1lvlAccident);
            Calculated.FillMAlpha(dataGridView1lvlMAlpha);
            Calculated.FillForecast(dataGridView1lvlForecast);
            MessageBox.Show("Декомпозиция просчитана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Нажание на Chart
        private void chart_Click(object sender, EventArgs e)
        {
            Chart ch = sender as Chart;
            FormChart frm = new FormChart(ch.Series, ch.ChartAreas[0].AxisX.Title, ch.ChartAreas[0].AxisY.Title, ch.Text);
            frm.Visible = true;
        }

        // Изменение значения в Numeric
        private void numericUpDownDecNumb_ValueChanged(object sender, EventArgs e)
        {
            CData.DecNumbToOutput = Convert.ToInt32((sender as NumericUpDown).Value);
        }

        private void buttonLvl2ApplyAllocation_Click(object sender, EventArgs e)
        {
            FormTemplateLvlCalc frm = new FormTemplateLvlCalc();
            
        }
    }
}
