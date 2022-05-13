using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Coursework
{
    /// <summary>
    /// Алгоритм просчета 1 уровня
    /// </summary>
    class CDecompLvl1
    {
        public AlphaAndM M { get; private set; }
        private AlphaAndM MPlus, MMinus;

        /// <summary>
        /// Классический конструктор, требующий таблицу значений
        /// </summary>
        /// <param name="ValuesTable">Таблица значений для просчета</param>
        public CDecompLvl1(List<List<decimal>> ValuesTable)
        {
            M = new AlphaAndM(ValuesTable);
            MPlus = new AlphaAndM(ValuesTable, +CData.T);
            MMinus = new AlphaAndM(ValuesTable, -CData.T);
        }

        /// <summary>
        /// Заполнить график отклика функции с прогнозами
        /// </summary>
        /// <param name="chart"></param>
        public void FillChartAllM(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].RecalculateAxesScale();
            chart.Series.Add(CData.GetSeries("M", M.M, M.Alpha));
            chart.Series.Add(CData.GetSeries("M+", MPlus.M, MPlus.Alpha));
            chart.Series.Add(CData.GetSeries("M-", MMinus.M, MMinus.Alpha));
            chart.Series.Add(CData.GetSeries("M прогноз", M.MForecast, M.AlphaForecast));
            chart.Series.Add(CData.GetSeries("M+ прогноз", MPlus.MForecast, MPlus.AlphaForecast));
            chart.Series.Add(CData.GetSeries("M- прогноз", MMinus.MForecast, MMinus.AlphaForecast));
        }

        /// <summary>
        /// Заполнить фазовый график
        /// </summary>
        /// <param name="chart"></param>
        public void FillChartPhase(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].RecalculateAxesScale();
            chart.Series.Add(CData.GetSeries("M", M.M));
            chart.Series.Add(CData.GetSeries("M+", MPlus.M));
            chart.Series.Add(CData.GetSeries("M-", MMinus.M));
            chart.Series.Add(CData.GetSeries("M прогноз", M.MForecast));
        }

        /// <summary>
        /// Посчитать и заполнить итоговую таблицу аварийности
        /// </summary>
        /// <param name="dataGrid">Таблица для заполнения</param>
        public void CalculateAndFillAccident(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            FillColumns(dataGrid, "Эпоха", "R", "L", "Аварийность");

            for (int i = 0; i < M.M.Count; i++)
            {
                dataGrid.Rows.Add();
                ChangeDataRow(dataGrid.Rows[i], i.ToString(), MMinus.M[i], M.M[i], MPlus.M[i], M.M[0]);
            }
            dataGrid.Rows.Add();
            ChangeDataRow(dataGrid.Rows[dataGrid.Rows.Count - 1], "Прогноз", MMinus.MForecastValue, M.MForecastValue, MPlus.MForecastValue, M.M[0]);
        }
       
        /// <summary>
        /// Заполнить таблицу для отображения значений векторов
        /// </summary>
        /// <param name="dataGrid">Таблица для заполнения</param>
        public void FillMAlpha(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            FillColumns(dataGrid, "Эпоха", "M-", "Alpha-", "M", "Alpha", "M+", "Alpha+");

            for (int i = 0; i < M.M.Count; i++)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells["Эпоха"].Value = i;
            }
            FillMAlphaRow(dataGrid, M.M, M.Alpha);
            FillMAlphaRow(dataGrid, MMinus.M, MMinus.Alpha, "-");
            FillMAlphaRow(dataGrid, MPlus.M, MPlus.Alpha, "+");
        }
        
        /// <summary>
        /// Заполнить таблицу прогнозных значений
        /// </summary>
        /// <param name="dataGrid"></param>
        public void FillForecast(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            FillColumns(dataGrid, "Эпоха", "M", "M прогноз", "Alpha", "Alpha прогноз");
            
            for (int i = 0; i < M.M.Count; i++)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells["Эпоха"].Value = i;
                dataGrid.Rows[i].Cells["M"].Value = CData.Round(M.M[i]);
                dataGrid.Rows[i].Cells["M прогноз"].Value = CData.Round(M.MForecast[i]);
                dataGrid.Rows[i].Cells["Alpha"].Value = CData.Round(M.Alpha[i]);
                dataGrid.Rows[i].Cells["Alpha прогноз"].Value = CData.Round(M.AlphaForecast[i]);
            }

            int index = M.M.Count;
            dataGrid.Rows.Add();
            dataGrid.Rows[index].Cells["Эпоха"].Value = "Прогноз";
            dataGrid.Rows[index].Cells["M"].Value = "###";
            dataGrid.Rows[index].Cells["M прогноз"].Value = CData.Round(M.MForecastValue);
            dataGrid.Rows[index].Cells["Alpha"].Value = "###";
            dataGrid.Rows[index].Cells["Alpha прогноз"].Value = CData.Round(M.AlphaForecastValue);
        } 
        
        // Функция для создания столбцов в таблице по их названиям
        private void FillColumns(DataGridView dataGrid, params string[] columnsName)
        {
            dataGrid.Columns.Clear();
            foreach (string S in columnsName)
            {
                dataGrid.Columns.Add(S, S);
                dataGrid.Columns[S].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        // Функция для заполнения строки для таблицы аварийности
        private void ChangeDataRow(DataGridViewRow row, string number, decimal Mm, decimal M, decimal Mp, decimal Mzero)
        {
            decimal R = Math.Round(DecimalMath.Abs((Mp - Mm) / 2), 8);
            decimal L = Math.Round(DecimalMath.Abs(M - Mzero), 8);
            row.Cells["Эпоха"].Value = number;
            row.Cells["R"].Value = CData.Round(R);
            row.Cells["L"].Value = CData.Round(L);
            row.Cells["Аварийность"].Value = L < R ? "Не аварийное" : (L > R ? "Аварийное" : "Предаварийное");
            switch (row.Cells["Аварийность"].Value.ToString())
            {
                case "Не аварийное":
                    row.Cells["Аварийность"].Style.BackColor = System.Drawing.Color.Green;
                    break;
                case "Аварийное":
                    row.Cells["Аварийность"].Style.BackColor = System.Drawing.Color.Red;
                    break;
                case "Предаварийное":
                    row.Cells["Аварийность"].Style.BackColor = System.Drawing.Color.Yellow;
                    break;
            }
        }

        // Функция для заполнения строк для значения вектора
        private void FillMAlphaRow(DataGridView dataGrid, List<decimal> M, List<decimal> alpha, string mody = "")
        {
            for (int i = 0; i < M.Count; i++)
            {
                dataGrid.Rows[i].Cells["M" + mody].Value = CData.Round(M[i]);
                dataGrid.Rows[i].Cells["Alpha" + mody].Value = CData.Round(alpha[i]);
            }
        }
    }
}
