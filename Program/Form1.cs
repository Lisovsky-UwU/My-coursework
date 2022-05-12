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
                pictureBoxLvl2.Image = CRequest.IMG;
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
            Calculated.FillChartAllM(chartLvl1AllM);
            Calculated.FillChartPhase(chartLvl1Phase);
            Calculated.CalculateAndFillAccident(dataGridView1lvlAccident);
            Calculated.FillMAlpha(dataGridView1lvlMAlpha);
            Calculated.FillForecast(dataGridView1lvlForecast);
            tabControl1lvlTable.Enabled = true;
            chartLvl1AllM.Enabled = true;
            chartLvl1Phase.Enabled = true;
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

        private int Lvl2BlocksCount;
        private CalculateLvl1[] Lvl2Data;
        private List<int>[] Lvl2PointsStorage;
        private void buttonLvl2ApplyAllocation_Click(object sender, EventArgs e)
        {
            Lvl2BlocksCount = Convert.ToInt32(numericUpDownLvl2NumbBlocks.Value);
            Lvl2Data = new CalculateLvl1[Lvl2BlocksCount];
            Lvl2PointsStorage = new List<int>[Lvl2BlocksCount + 1];

            comboBoxLvl2Block.Items.Clear();
            comboBoxLvl2SelectedBlock.Items.Clear();
            for (int i = 0; i < Lvl2BlocksCount; i++)
            {
                comboBoxLvl2SelectedBlock.Items.Add($"Блок {i + 1}");
                comboBoxLvl2Block.Items.Add($"Блок {i + 1}");
                Lvl2PointsStorage[i] = new List<int>();
            }
            comboBoxLvl2Block.SelectedIndex = 0;

            listBoxLvl2AllPoints.Items.Clear();
            listBoxLvl2BlockPoints.Items.Clear();
            Lvl2PointsStorage[Lvl2BlocksCount] = new List<int>();
            for (int i = 0; i < CData.Table.Last().Count; i++)
            {
                Lvl2PointsStorage[Lvl2BlocksCount].Add(i + 1);
                listBoxLvl2AllPoints.Items.Add(i + 1);
            }

            listBoxLvl2AllPoints.Enabled = true;
            listBoxLvl2BlockPoints.Enabled = true;
            comboBoxLvl2Block.Enabled = true;
            buttonLvl2Calc.Enabled = true;
        }

        private int SelectedIndexToDrop;
        private string SourceName;
        private void listBoxLvl2Points_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListBox listBox = sender as ListBox;
                SelectedIndexToDrop = listBox.SelectedIndex;
                if (SelectedIndexToDrop != -1)
                {
                    SourceName = listBox.Name;
                    listBox.DoDragDrop(listBox.SelectedItem.ToString(), DragDropEffects.Move);
                }
            }
        }

        private void listBoxLvl2Points_DragDrop(object sender, DragEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox.Name == SourceName)
            {
                return;
            }
            int value = Convert.ToInt32(e.Data.GetData(DataFormats.Text));
            Point cursorPosition = (sender as ListBox).PointToClient(new Point(e.X, e.Y));
            int itemPosition = (sender as ListBox).IndexFromPoint(cursorPosition);
            if (itemPosition == -1)
            {
                itemPosition = listBox.Items.Count;
            }
            listBox.Items.Insert(itemPosition, value.ToString());
            if (listBox.Name == listBoxLvl2AllPoints.Name)
            {
                Lvl2PointsStorage[Lvl2BlocksCount].Insert(itemPosition, value);
                Lvl2PointsStorage[comboBoxLvl2Block.SelectedIndex].RemoveAt(SelectedIndexToDrop);
            }
            else
            {
                Lvl2PointsStorage[comboBoxLvl2Block.SelectedIndex].Insert(itemPosition, value);
                Lvl2PointsStorage[Lvl2BlocksCount].RemoveAt(SelectedIndexToDrop);
            }

            (panelLvl2AllocationListsBox.Controls[SourceName] as ListBox).Items.RemoveAt(SelectedIndexToDrop);
        }

        private void listBoxLvl2Points_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void comboBoxLvl2Block_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLvl2BlockPoints.Items.Clear();
            for (int i = 0; i < Lvl2PointsStorage[comboBoxLvl2Block.SelectedIndex].Count; i++)
            {
                listBoxLvl2BlockPoints.Items.Add(Lvl2PointsStorage[comboBoxLvl2Block.SelectedIndex][i].ToString());
            }
        }

        private void buttonLvl2Minimaze_Click(object sender, EventArgs e)
        {
            if (buttonLvl2Minimaze.Text == "<")
            {
                panelLvl2Allocation.Visible = false;
                buttonLvl2Minimaze.Text = ">";
            }
            else
            {
                panelLvl2Allocation.Visible = true;
                buttonLvl2Minimaze.Text = "<";
            }
        }

        private void buttonLvl2Calc_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < Lvl2BlocksCount; i++)
            {
                if (Lvl2PointsStorage[i].Count != Lvl2PointsStorage[0].Count)
                {
                    MessageBox.Show("Распределите равное количество точек!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Lvl2Data = new CalculateLvl1[Lvl2BlocksCount];

            for (int i = 0; i < Lvl2BlocksCount; i++)
            {
                List<List<double>> newTable = new List<List<double>>();
                for (int j = 0; j < CData.Table.Count; j++)
                {
                    newTable.Add(new List<double>());
                    for (int k = 0; k < Lvl2PointsStorage[i].Count; k++)
                    {
                        newTable[j].Add(CData.Table[j][Lvl2PointsStorage[i][k]]);
                    }
                }
                Lvl2Data[i] = new CalculateLvl1(newTable);
            }

            comboBoxLvl2SelectedBlock.Enabled = true;
            comboBoxLvl2SelectedBlock.SelectedIndex = 0;

            chartLvl2AllM.Enabled = true;
            chartLvl2Phase.Enabled = true;
            tabControlLvl2Tables.Enabled = true;
        }

        private void comboBoxLvl2SelectedBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxLvl2SelectedBlock.SelectedIndex;
            Lvl2Data[index].FillChartPhase(chartLvl2Phase);
            Lvl2Data[index].FillChartAllM(chartLvl2AllM);
            Lvl2Data[index].FillMAlpha(dataGridViewLvl2MAlpha);
            Lvl2Data[index].FillForecast(dataGridViewLvl2Forecast);
            Lvl2Data[index].CalculateAndFillAccident(dataGridViewLvl2Accident);
        }
    }
}
