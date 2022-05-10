﻿using System;
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
    class CalculateLvl1
    {
        private AlphaAndM M, MPlus, MMinus;

        /// <summary>
        /// Классический конструктор, требующий таблицу значений
        /// </summary>
        /// <param name="ValuesTable">Таблица значений для просчета</param>
        public CalculateLvl1(List<List<double>> ValuesTable)
        {
            M = new AlphaAndM(ValuesTable);
            MPlus = new AlphaAndM(ValuesTable, -CData.T);
            MMinus = new AlphaAndM(ValuesTable, +CData.T);
        }

        /// <summary>
        /// Заполнить график отклика функции с прогнозами
        /// </summary>
        /// <param name="chart"></param>
        public void FillChartAllM(Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add(GetSeries("M", M.M, M.Alpha));
            chart.Series.Add(GetSeries("M+", MPlus.M, MPlus.Alpha));
            chart.Series.Add(GetSeries("M-", MMinus.M, MMinus.Alpha));
            chart.Series.Add(GetSeries("M прогноз", M.MForecast, M.AlphaForecast));
            chart.Series.Add(GetSeries("M+ прогноз", MPlus.MForecast, MPlus.AlphaForecast));
            chart.Series.Add(GetSeries("M- прогноз", MMinus.MForecast, MMinus.AlphaForecast));
        }

        /// <summary>
        /// Заполнить фазовый график
        /// </summary>
        /// <param name="chart"></param>
        public void FillChartPhase(Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add(GetSeries("M", M.M));
            chart.Series.Add(GetSeries("M+", MPlus.M));
            chart.Series.Add(GetSeries("M-", MMinus.M));
            chart.Series.Add(GetSeries("M прогноз", M.MForecast));
        }

        /// <summary>
        /// Фунуция для создания серии по значениям только для Y
        /// </summary>
        /// <param name="serName">Название серии</param>
        /// <param name="dataY">Значения по Y</param>
        /// <returns>Вернет серию для Chart</returns>
        private Series GetSeries(string serName, List<double> dataY)
        {
            Series newSer = new Series(serName) { ChartType = SeriesChartType.Spline };
            for (int i = 0; i < dataY.Count; i++)
            {
                newSer.Points.AddXY(i + 1, dataY[i]);
            }
            return newSer;
        }

        /// <summary>
        /// Функция для создания серии по значениям для X и Y
        /// </summary>
        /// <param name="serName">Название серии</param>
        /// <param name="dataX">Значения для X</param>
        /// <param name="dataY">Значения для Y</param>
        /// <returns>Вернет серию для Chart</returns>
        private Series GetSeries(string serName, List<double> dataX, List<double> dataY)
        {
            Series newSer = new Series(serName) { ChartType = SeriesChartType.Spline };
            for (int i = 0; i < dataX.Count; i++)
            {
                newSer.Points.AddXY(dataX[i], dataY[i]);
            }
            return newSer;
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
        private void ChangeDataRow(DataGridViewRow row, string number, double Mm, double M, double Mp, double Mzero)
        {
            double R = Math.Abs((Mp - Mm) / 2);
            double L = Math.Abs(M - Mzero);
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
        private void FillMAlphaRow(DataGridView dataGrid, List<double> M, List<double> alpha, string mody = "")
        {
            for (int i = 0; i < M.Count; i++)
            {
                dataGrid.Rows[i].Cells["M" + mody].Value = CData.Round(M[i]);
                dataGrid.Rows[i].Cells["Alpha" + mody].Value = CData.Round(alpha[i]);
            }
        }
    }
}
