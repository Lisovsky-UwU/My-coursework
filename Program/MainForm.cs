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
        CDecompLvl2 Lvl2Data;                   //Данные для 2 уровня декомпозиции
        int Lvl2BlocksCount;                    //Количество блоков
        List<int>[] Lvl2PointsStorage;          //Массив с распределенными точками в ListBox
        int SelectedIndexToDrop;                //Индекс элемента взятого для переноса


        /*                       Данные для 3 уровня декомпозиции                       */
        CDecompLvl2 Lvl3Data;                   //Данные подситанного блока
        List<int> Lvl3PointsList;               //Изначальный список всех точек в блоке
        List<int>[] Lvl3PointsStorage;          //Распределение точек по подблокам
        List<List<decimal>> Lvl3SubBlockTable;  //Таблица распределенных точек
        int Lvl3CountSubblocks;                 //Количество подблоков в блоке
        int Lvl3SelectedIndexToDrop;            //Выбранный блок для перемещения в него точек
        bool[,] Lvl3Links;                      //Матрица инцидентности (между какими точками есть связь)


        /*                       Данные для 4 уровня декомпозиции                       */
        CDecompLvl2[] Lvl4Data;                 //Данные просчетов 4 уровня (на основе алгоритмов 2 уровня)
        List<List<int>> Lvl4PointsStorage;      //Сортировка точек по блокам для 4 уровня


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
            buttonLvl3Calculate.Enabled = false;
            buttonLvl4Calculate.Enabled = false;
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
                pictureBoxLvl1.Image = image;
                pictureBoxLvl2.Image = image;
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
            try
            {
                decimal val = Convert.ToDecimal(textBoxT.Text);
                if (val >= 0 && val <= 1)
                {
                    CRequest.WriteT(Convert.ToDecimal(textBoxT.Text));
                }
            }
            catch { }
        }

        // Изменение значения в TextBox для A
        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal val = Convert.ToDecimal(textBoxA.Text);
                if (val >= 0 && val <= 1)
                {
                    CRequest.WriteA(Convert.ToDecimal(textBoxA.Text));
                }
            }
            catch { }
        }

        // Когда поле ввода для T перестает быть активным
        private void textBoxT_Leave(object sender, EventArgs e)
        {
            textBoxT.Text = CData.T.ToString();
        }

        // Когда поле ввода для A перестает быть активным
        private void textBoxA_Leave(object sender, EventArgs e)
        {
            textBoxA.Text = CData.A.ToString();
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

        // Кнопка открытия справки
        private void buttonFormHelp_Click(object sender, EventArgs e)
        {
            FormHelp form = new FormHelp(tabControlNavigation.SelectedIndex);
            form.Show();
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
                comboBoxLvl2SelectedBlock.Items.Add($"Блок {Convert.ToChar('А' + i)}");
                comboBoxLvl2Block.Items.Add($"Блок {Convert.ToChar('А' + i)}");
                Lvl2PointsStorage[i] = new List<int>();
            }
            comboBoxLvl2Block.SelectedIndex = 0;

            listBoxLvl2AllPoints.Items.Clear();
            listBoxLvl2BlockPoints.Items.Clear();
            Lvl2PointsStorage[Lvl2BlocksCount] = new List<int>();
            for (int i = 0; i < CData.ColumnCount; i++)
            {
                Lvl2PointsStorage[Lvl2BlocksCount].Add(i + 1);
                listBoxLvl2AllPoints.Items.Add(i + 1);
            }

            listBoxLvl2AllPoints.Enabled = true;
            listBoxLvl2BlockPoints.Enabled = true;
            comboBoxLvl2Block.Enabled = true;
            buttonLvl2Calc.Enabled = true;
        }

        // Изменение выбранного блока
        private void comboBoxLvl2Block_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexToDrop = comboBoxLvl2Block.SelectedIndex;
            listBoxLvl2BlockPoints.Items.Clear();
            for (int i = 0; i < Lvl2PointsStorage[comboBoxLvl2Block.SelectedIndex].Count; i++)
            {
                listBoxLvl2BlockPoints.Items.Add(Lvl2PointsStorage[comboBoxLvl2Block.SelectedIndex][i].ToString());
            }
        }

        // Из основного ListBox в распределение точек
        private void buttonLvl2Lb1ToLb2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxLvl2AllPoints.SelectedIndices.Count; i++)
            {
                listBoxLvl2BlockPoints.Items.Add(listBoxLvl2AllPoints.Items[listBoxLvl2AllPoints.SelectedIndices[i]]);
                Lvl2PointsStorage[SelectedIndexToDrop].Add(Convert.ToInt32(listBoxLvl2AllPoints.Items[listBoxLvl2AllPoints.SelectedIndices[i]]));
            }
            int k = listBoxLvl2AllPoints.SelectedIndices.Count;
            for (int i = k - 1; i >= 0; i--)
            {
                Lvl2PointsStorage[Lvl2BlocksCount].RemoveAt(listBoxLvl2AllPoints.SelectedIndices[i]);
                listBoxLvl2AllPoints.Items.RemoveAt(listBoxLvl2AllPoints.SelectedIndices[i]);
            }
        }

        // Из распределения точек в основного ListBox
        private void buttonLvl2Lb2ToLb1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxLvl2BlockPoints.SelectedIndices.Count; i++)
            {
                listBoxLvl2AllPoints.Items.Add(listBoxLvl2BlockPoints.Items[listBoxLvl2BlockPoints.SelectedIndices[i]]);
                Lvl2PointsStorage[Lvl2BlocksCount].Add(Convert.ToInt32(listBoxLvl2BlockPoints.Items[listBoxLvl2BlockPoints.SelectedIndices[i]]));
            }
            int k = listBoxLvl2BlockPoints.SelectedIndices.Count;
            for (int i = k - 1; i >= 0; i--)
            {
                Lvl2PointsStorage[SelectedIndexToDrop].RemoveAt(listBoxLvl2BlockPoints.SelectedIndices[i]);
                listBoxLvl2BlockPoints.Items.RemoveAt(listBoxLvl2BlockPoints.SelectedIndices[i]);
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
                Lvl2PointsStorage[i].Sort();
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

            comboBoxLvl3SelectBlock.Enabled = true;
            comboBoxLvl3SelectBlock.Items.Clear();
            for (int i = 0; i < Lvl2BlocksCount; i++)
            {
                comboBoxLvl3SelectBlock.Items.Add($"Блок {Convert.ToChar('А' + i)}");
            }

            buttonLvl4Calculate.Enabled = true;
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


        /*                 Функционал для вкладки 3 уровня декомпозиции                 */

        // Изменение выбранного блока для расчетов
        private void comboBoxLvl3SelectBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownLvl3CountSubBlocks.Enabled = true;
            buttonLvl3ApplySubBlocks.Enabled = true;

            listBoxLvl3AllSubBlocksPoints.Items.Clear();
            listBoxLvl3AllSubBlocksPoints.Enabled = false;
            listBoxLvl3SubBlockPoints.Items.Clear();
            listBoxLvl3SubBlockPoints.Enabled = false;
            comboBoxLvl3SelectSubBlock.Items.Clear();
            comboBoxLvl3SelectSubBlock.Enabled = false;
            comboBoxLvl3SelectSubBlockOutput.Items.Clear();
            comboBoxLvl3SelectSubBlockOutput.Enabled = false;
            buttonLvl3FromAllToBlock.Enabled = false;
            buttonLvl3FromBlockToAll.Enabled = false;

            CalculateHForBlock(Lvl2PointsStorage[comboBoxLvl3SelectBlock.SelectedIndex]);
        }

        // Функция расчета таблиц и связей между точками в блоке
        private void CalculateHForBlock(List<int> pointsList)
        {
            Lvl3PointsList = pointsList;
            dataGridViewLvl3LinksL.Rows.Clear();
            dataGridViewLvl3LinksL.Columns.Clear();
            dataGridViewlvl3LinksTF.Rows.Clear();
            dataGridViewlvl3LinksTF.Columns.Clear();

            dataGridViewLvl3LinksL.Columns.Add("Эпоха", "Эпоха");
            dataGridViewLvl3LinksL.Columns["Эпоха"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewlvl3LinksTF.Columns.Add("Эпоха", "Эпоха");
            dataGridViewlvl3LinksTF.Columns["Эпоха"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Lvl3SubBlockTable = CData.GetTableForPoints(pointsList);
            int countLinks = 0;
            for (int i = 0; i < pointsList.Count; i++)
            {
                for (int j = i + 1; j < pointsList.Count; j++)
                {
                    string colName = $"{pointsList[i]}-{pointsList[j]}";
                    dataGridViewLvl3LinksL.Columns.Add(colName, colName);
                    dataGridViewlvl3LinksTF.Columns.Add(colName, colName);
                    dataGridViewLvl3LinksL.Columns[colName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridViewlvl3LinksTF.Columns[colName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    countLinks++;
                }
            }
            Lvl3Links = new bool[countLinks, countLinks];

            for (int i = 0; i < CData.RowCount; i++)
            {
                dataGridViewLvl3LinksL.Rows.Add(i.ToString());
                dataGridViewlvl3LinksTF.Rows.Add(i.ToString());
            }
            dataGridViewlvl3LinksTF.Rows.Add("Сцепка");

            int dataCol = 1;
            for (int i = 0; i < pointsList.Count; i++)
            {
                for (int j = i + 1; j < pointsList.Count; j++)
                {
                    decimal max = 0;
                    decimal firstQua = Math.Abs(Lvl3SubBlockTable[0][i] - Lvl3SubBlockTable[0][j]);
                    for (int row = 0; row < CData.RowCount; row++)
                    {
                        decimal qua = Math.Abs(Lvl3SubBlockTable[row][i] - Lvl3SubBlockTable[row][j]);
                        max = Math.Max(max, Math.Abs(qua - firstQua));
                        dataGridViewLvl3LinksL.Rows[row].Cells[dataCol].Value = qua;
                        dataGridViewlvl3LinksTF.Rows[row].Cells[dataCol].Value = Math.Abs(qua - firstQua);
                    }
                    Lvl3Links[i, j] = max <= CData.T;
                    Lvl3Links[j, i] = max <= CData.T;
                    if (max <= CData.T)
                    {
                        dataGridViewlvl3LinksTF.Rows[CData.RowCount].Cells[dataCol].Value = "Есть";
                        for (int k = 0; k < dataGridViewlvl3LinksTF.Rows.Count; k++)
                        {
                            dataGridViewlvl3LinksTF.Rows[k].Cells[dataCol].Style.BackColor = Color.Green;
                        }
                    }
                    else
                    {
                        dataGridViewlvl3LinksTF.Rows[CData.RowCount].Cells[dataCol].Value = "Нет";
                        for (int k = 0; k < dataGridViewlvl3LinksTF.Rows.Count; k++)
                        {
                            dataGridViewlvl3LinksTF.Rows[k].Cells[dataCol].Style.BackColor = Color.Red;
                        }
                    }

                    dataCol++;
                }
            }

            CData.FillChartLinks(chartLvl3BlocksLinks, Lvl3Links, pointsList, 2);
            chartLvl3BlocksLinks.Enabled = true;
        }

        // Нажатие на график со всеми связями в блоке
        private void chartLvl3BlocksLinks_Click(object sender, EventArgs e)
        {
            FormChartLinks form = new FormChartLinks(Lvl3Links, Lvl3PointsList);
            form.Show();
        }

        // Применить количество подблоков
        private void buttonLvl3ApplySubBlocks_Click(object sender, EventArgs e)
        {
            Lvl3CountSubblocks = Convert.ToInt32(numericUpDownLvl3CountSubBlocks.Value);
            if (Lvl3CountSubblocks > Lvl3PointsList.Count)
            {
                MessageBox.Show("Количество подблоков не может превышать число точек в блоке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Lvl3PointsStorage = new List<int>[Lvl3CountSubblocks];
            for (int i = 0; i < Lvl3CountSubblocks; i++)
            {
                comboBoxLvl3SelectSubBlock.Items.Add($"Подблок {i + 1}");
                comboBoxLvl3SelectSubBlockOutput.Items.Add($"Подблок {i + 1}");
                Lvl3PointsStorage[i] = new List<int>();
            }

            for (int i = 0; i < Lvl3PointsList.Count; i++)
            {
                listBoxLvl3AllSubBlocksPoints.Items.Add(Lvl3PointsList[i]);
            }

            listBoxLvl3AllSubBlocksPoints.Items.Clear();
            listBoxLvl3AllSubBlocksPoints.Enabled = true;
            listBoxLvl3SubBlockPoints.Enabled = true;
            buttonLvl3FromAllToBlock.Enabled = true;
            buttonLvl3FromBlockToAll.Enabled = true;
            buttonLvl3Calculate.Enabled = true;
            comboBoxLvl3SelectSubBlock.Enabled = true;
            comboBoxLvl3SelectSubBlock.SelectedIndex = 0;
        }

        // Перемещение из списка со всеми точкаии в выбранный подблок
        private void buttonLvl3FromAllToBlock_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxLvl3AllSubBlocksPoints.SelectedIndices.Count; i++)
            {
                listBoxLvl3SubBlockPoints.Items.Add(listBoxLvl3AllSubBlocksPoints.Items[listBoxLvl3AllSubBlocksPoints.SelectedIndices[i]]);
                Lvl3PointsStorage[Lvl3SelectedIndexToDrop].Add(Convert.ToInt32(listBoxLvl3AllSubBlocksPoints.Items[listBoxLvl3AllSubBlocksPoints.SelectedIndices[i]]));
            }
            int k = listBoxLvl3AllSubBlocksPoints.SelectedIndices.Count;
            for (int i = k - 1; i >= 0; i--)
            {
                listBoxLvl3AllSubBlocksPoints.Items.RemoveAt(listBoxLvl3AllSubBlocksPoints.SelectedIndices[i]);
            }
        }

        // Перемещение из выбранного подблока в список со всеми точками
        private void buttonLvl3FromBlockToAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxLvl3SubBlockPoints.SelectedIndices.Count; i++)
            {
                listBoxLvl3AllSubBlocksPoints.Items.Add(listBoxLvl3SubBlockPoints.Items[listBoxLvl3SubBlockPoints.SelectedIndices[i]]);
            }
            int k = listBoxLvl3SubBlockPoints.SelectedIndices.Count;
            for (int i = k - 1; i >= 0; i--)
            {
                Lvl3PointsStorage[Lvl3SelectedIndexToDrop].RemoveAt(listBoxLvl3SubBlockPoints.SelectedIndices[i]);
                listBoxLvl3SubBlockPoints.Items.RemoveAt(listBoxLvl3SubBlockPoints.SelectedIndices[i]);
            }
        }

        // Изменение выбранного подблока для внесения значений
        private void comboBoxLvl3SelectSubBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lvl3SelectedIndexToDrop = comboBoxLvl3SelectSubBlock.SelectedIndex;
            listBoxLvl3SubBlockPoints.Items.Clear();
            for (int i = 0; i < Lvl3PointsStorage[Lvl3SelectedIndexToDrop].Count; i++)
            {
                listBoxLvl3SubBlockPoints.Items.Add(Lvl3PointsStorage[Lvl3SelectedIndexToDrop][i]);
            }
        }

        // Кнопка расчета подблоков
        private void buttonLvl3Calculate_Click(object sender, EventArgs e)
        {
            if (listBoxLvl3AllSubBlocksPoints.Items.Count != 0)
            {
                MessageBox.Show("Распределите все точки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Lvl3Data = new CDecompLvl2(Lvl3PointsStorage);
            Lvl3Data.FillChart(chartLvl3AllSubBlocks, "Подблок");

            comboBoxLvl3SelectSubBlockOutput.Enabled = true;
            comboBoxLvl3SelectSubBlockOutput.SelectedIndex = 0;

            chartLvl3AllSubBlocks.Enabled = true;
            chartLvl3AllM.Enabled = true;
            chartLvl3Phase.Enabled = true;
            tabControlLvl3Tables.Enabled = true;
        }

        // Изменение выбранного подблока для вывода
        private void comboBoxLvl3SelectSubBlockOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxLvl3SelectSubBlockOutput.SelectedIndex;
            Lvl3Data[index].FillChartAllM(chartLvl3AllM);
            Lvl3Data[index].FillChartPhase(chartLvl3Phase);
            Lvl3Data[index].FillMAlpha(dataGridViewLvl3MAlpha);
            Lvl3Data[index].FillForecast(dataGridViewLvl3Forecast);
            Lvl3Data[index].CalculateAndFillAccident(dataGridViewLvl3Accident);
        }


        /*                 Функционал для вкладки 4 уровня декомпозиции                 */

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
                comboBoxLvl4SelectedBlock.Items.Add($"Блок {Convert.ToChar('А' + i)}");

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
            comboBoxLvl4SelectedBlock.Enabled = true;
            comboBoxLvl4SelectedPoint.Enabled = true;
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

            Lvl4Data[index].FillChart(chartLvl4AllPoints, "Точка", Lvl4PointsStorage[index]);
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