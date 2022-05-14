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
        /*                       Данные для 1 уровня декомпозиции                       */
        CDecompLvl1 Lvl1Data;                   //Данные для 1 уровня декомпозиции


        /*                       Данные для 2 уровня декомпозиции                       */
        private int Lvl2BlocksCount;            //Количество блоков
        private List<int>[] Lvl2PointsStorage;  //Массив с распределенными точками в ListBox
        private int SelectedIndexToDrop;        //Индекс элемента взятого для переноса
        private string SourceName;              //Имя источника откуда выполняется перенос
        CDecompLvl2 Lvl2Data;                   //Данные для 2 уровня декомпозиции


        /*                          Функционал для всей формы                           */
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            numericUpDownDecNumb.Value = CData.DecNumbToOutput;
            FormOpenDB frm = new FormOpenDB(this);
            frm.Show();
        }

        // Открыть базу данных с помощью файлового диалога </summary>
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
                try
                {
                    CRequest.OpenDB(fileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Ошибка открытия файла базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Закрыть базу данных
        private void CloseDB()
        {
            dataGridViewData.Rows.Clear();
            dataGridViewData.Columns.Clear();
            comboBoxTable.Items.Clear();
            comboBoxTable.Enabled = false;
            comboBoxTable.Text = "";
            textBoxT.Text = "";
            textBoxT.Enabled = false;
            textBoxA.Text = "";
            textBoxA.Enabled = false;
            buttonAddRow.Enabled = false;
            buttonDeleteRows.Enabled = false;
            buttonLvl1Calculate.Enabled = false;
            buttonLvl2ApplyAllocation.Enabled = false;
            ToolStripSaveDB.Enabled = false;
            ToolStripCloseDB.Enabled = false;
            ToolStripUpdateImage.Enabled = false;
            ToolStripAddRow.Enabled = false;
            numericUpDownDecNumb.Enabled = false;
            numericUpDownLvl2NumbBlocks.Enabled = false;
            CRequest.CloseDB();
        }

        // При открытии базы данных
        public void OpenDB()
        {
            ToolStripSaveDB.Enabled = true;
            ToolStripCloseDB.Enabled = true;
            ToolStripUpdateImage.Enabled = true;

            Image img = CRequest.IMG;
            pictureBoxInData.Image = img;
            pictureBoxLvl1.Image = img;
            pictureBoxLvl2.Image = img;

            textBoxT.Text = CData.T.ToString();
            textBoxT.Enabled = true;
            textBoxA.Text = CData.A.ToString();
            textBoxA.Enabled = true;

            comboBoxTable.Items.AddRange(CRequest.TableNames);
            if (comboBoxTable.Items.Count != 0)
            {
                comboBoxTable.Enabled = true;
                comboBoxTable.SelectedIndex = 0;
                CRequest.OpenAndShowTable(dataGridViewData, comboBoxTable.SelectedItem.ToString());
                buttonAddRow.Enabled = true;
                buttonDeleteRows.Enabled = true;
                buttonLvl1Calculate.Enabled = true;
                buttonLvl2ApplyAllocation.Enabled = true;
                ToolStripAddRow.Enabled = true;
                numericUpDownLvl2NumbBlocks.Enabled = true;
                numericUpDownDecNumb.Enabled = true;
            }
        }

        // Кнопка подключения базы данных
        private void buttonDBConnect_Click(object sender, EventArgs e)
        {
            OpenDataBaseWithFileDialog();            
            if (CRequest.DBIsOpen == true)
            {
                OpenDB();
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
            if (Char.IsDigit(symbol) == false && e.KeyChar != 8 && symbol != ',')
            {
                e.Handled = true;
            }
            else if (symbol == ',' && (sender as TextBox).Text.Contains(',') == true)
            {
                e.Handled = true;
            }
        }

        // Изменение значения в TextBox для T
        private void textBoxT_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            try
            {
                CRequest.WriteT(Convert.ToDecimal(tb.Text));
            }
            catch { }
        }

        // Изменение значения в TextBox для A
        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            try
            {
                CRequest.WriteA(Convert.ToDecimal(tb.Text));
            }
            catch { }
        }

        // Нажание на Chart
        private void chart_Click(object sender, EventArgs e)
        {
            Chart ch = sender as Chart;
            FormChart frm = new FormChart(ch.Series, ch.ChartAreas[0].AxisX.Title, ch.ChartAreas[0].AxisY.Title, ch.Text);
            frm.Visible = true;
        }

        // Нажатие на картинку
        private void pictureBox_Click(object sender, EventArgs e)
        {
            FormImage frm = new FormImage((sender as PictureBox).Image);
            frm.Show();
        }


        /*                       Функционал для вкладки с данными                       */

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

        // Изменение значения в Numeric
        private void numericUpDownDecNumb_ValueChanged(object sender, EventArgs e)
        {
            CData.DecNumbToOutput = Convert.ToInt32((sender as NumericUpDown).Value);
        }


        /*                 Функционал для вкладки 1 уровня декомпозиции                 */

        // Кнопка подсчета 1 уровня декомпозиции
        private void buttonLvl1Calculate_Click(object sender, EventArgs e)
        {
            Lvl1Data = new CDecompLvl1(CData.Table);
            Lvl1Data.FillChartAllM(chartLvl1AllM);
            Lvl1Data.FillChartPhase(chartLvl1Phase);
            Lvl1Data.CalculateAndFillAccident(dataGridView1lvlAccident);
            Lvl1Data.FillMAlpha(dataGridView1lvlMAlpha);
            Lvl1Data.FillForecast(dataGridView1lvlForecast);
            tabControl1lvlTable.Enabled = true;
            chartLvl1AllM.Enabled = true;
            chartLvl1Phase.Enabled = true;
        }


        /*                 Функционал для вкладки 2 уровня декомпозиции                 */

        // Применить введенное количество блоков
        private void buttonLvl2ApplyAllocation_Click(object sender, EventArgs e)
        {
            Lvl2BlocksCount = Convert.ToInt32(numericUpDownLvl2NumbBlocks.Value);
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

        // Событие нажатия для переноса
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

        // Событие Drop для переноса
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

        // Событие входа для переноса
        private void listBoxLvl2Points_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        // Изменение выбранного блока
        private void comboBoxLvl2Block_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLvl2BlockPoints.Items.Clear();
            for (int i = 0; i < Lvl2PointsStorage[comboBoxLvl2Block.SelectedIndex].Count; i++)
            {
                listBoxLvl2BlockPoints.Items.Add(Lvl2PointsStorage[comboBoxLvl2Block.SelectedIndex][i].ToString());
            }
        }

        // Кнопка сворачивания
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

        // Кнопка подсчета 2 уровня
        private void buttonLvl2Calc_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lvl2BlocksCount; i++)
            {
                if (Lvl2PointsStorage[i].Count != Lvl2PointsStorage[0].Count)
                {
                    MessageBox.Show("Распределите равное количество точек!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Lvl2PointsStorage[i].Count == 0)
                {
                    MessageBox.Show("Во всех блоках должна быть хотя бы одна точка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            List<List<int>> newPointsStorage = new List<List<int>>();
            for (int i = 0; i < Lvl2BlocksCount; i++)
            {
                newPointsStorage.Add(Lvl2PointsStorage[i]);
            }

            Lvl2Data = new CDecompLvl2(newPointsStorage.ToArray());

            comboBoxLvl2SelectedBlock.Enabled = true;
            comboBoxLvl2SelectedBlock.SelectedIndex = 0;
            SelectedViewBlockChanged(0);

            chartLvl2AllM.Enabled = true;
            chartLvl2Phase.Enabled = true;
            chartLvl2AllBlocks.Enabled = true;
            tabControlLvl2Tables.Enabled = true;

            Lvl2Data.FillChart(chartLvl2AllBlocks);
        }
        
        // Изменение выбранного блока для отображения
        private void SelectedViewBlockChanged(int index)
        {
            Lvl2Data[index].FillChartPhase(chartLvl2Phase);
            Lvl2Data[index].FillChartAllM(chartLvl2AllM);
            Lvl2Data[index].FillMAlpha(dataGridViewLvl2MAlpha);
            Lvl2Data[index].FillForecast(dataGridViewLvl2Forecast);
            Lvl2Data[index].CalculateAndFillAccident(dataGridViewLvl2Accident);
        }

        // Изменение выбранного блока для отображения в ComboBox
        private void comboBoxLvl2SelectedBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedViewBlockChanged(comboBoxLvl2SelectedBlock.SelectedIndex);
        }


        /*                 Функционал для вкладки 4 уровня декомпозиции                 */

        CDecompLvl2[] Lvl4Data;                 //Данные просчетов 4 уровня (на основе алгоритмов 2 уровня)
        List<List<int>> Lvl4PointsStorage;      //Сортировка точек по блокам для 4 уровня

        // Кнопка просчета 4 уровня
        private void buttonLvl4Calculate_Click(object sender, EventArgs e)
        {
            comboBoxLvl4SelectedBlock.Items.Clear();
            Lvl4PointsStorage = new List<List<int>>();
            for (int i = 0; i < Lvl2PointsStorage.Length; i++)
            {
                if (Lvl2PointsStorage[i].Count != 0)
                {
                    Lvl4PointsStorage.Add(Lvl2PointsStorage[i]);
                }
            }
            Lvl4Data = new CDecompLvl2[Lvl4PointsStorage.Count];
            for (int i = 0; i < Lvl4PointsStorage.Count; i++)
            {
                if (i == Lvl4PointsStorage.Count - 1 && Lvl4PointsStorage[i].Count == 0)
                {
                    break;
                }
                comboBoxLvl4SelectedBlock.Items.Add($"Блок {i + 1}");

                List<int>[] point = new List<int>[Lvl4PointsStorage[i].Count];
                for (int j = 0; j < Lvl4PointsStorage[i].Count; j++)
                {
                    point[j] = new List<int> { Lvl4PointsStorage[i][j] };
                }
                Lvl4Data[i] = new CDecompLvl2(point);
            }
            if (Lvl4PointsStorage.Count == Lvl2PointsStorage.Length)
            {
                comboBoxLvl4SelectedBlock.Items[comboBoxLvl4SelectedBlock.Items.Count - 1] = "Нераспределенные точки";
            }
            comboBoxLvl4SelectedBlock.SelectedIndex = -1;
            comboBoxLvl4SelectedBlock.SelectedIndex = 0;

            chartLvl4AllPoints.Enabled = true;
            chartLvl4OnePoint.Enabled = true;
        }

        // Изменение выбранного блока точек
        private void comboBoxLvl4SelectedBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLvl4SelectedPoint.Items.Clear();
            int index = comboBoxLvl4SelectedBlock.SelectedIndex;
            for (int i = 0; i < Lvl4PointsStorage[index].Count; i++)
            {
                comboBoxLvl4SelectedPoint.Items.Add(Lvl4PointsStorage[index][i]);
            }
            comboBoxLvl4SelectedPoint.SelectedIndex = -1;
            comboBoxLvl4SelectedPoint.SelectedIndex = 0;

            Lvl4Data[index].FillChart(chartLvl4AllPoints, "Точка");
        }

        // Изменение выбранной точки
        private void comboBoxLvl4SelectedPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxLvl4SelectedBlock.SelectedIndex;
            Lvl4Data[index][comboBoxLvl4SelectedPoint.SelectedIndex].CalculateAndFillAccident(dataGridViewLvl4Accident, true);
            Lvl4Data[index][comboBoxLvl4SelectedPoint.SelectedIndex].FillChartMAndForecast(chartLvl4OnePoint);

            foreach (Series s in chartLvl4OnePoint.Series)
            {
                s.BorderWidth = 2;
                s.Label = "#INDEX";
                s.MarkerStyle = MarkerStyle.Circle;
                s.MarkerSize = 9;
            }
        }
    }
}