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
    class CalculateLvl1
    {
        private static AlphaAndM M, MPlus, MMinus;
        public static void Calculated(DataTable dTable)
        {
            M = new AlphaAndM(dTable);
            MPlus = new AlphaAndM(dTable, -DataForCalculate.T);
            MMinus = new AlphaAndM(dTable, +DataForCalculate.T);

        }
        public static void FillChartAllM(Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add(GetSeries("M", M.M, M.Alpha));
            chart.Series.Add(GetSeries("M+", MPlus.M, MPlus.Alpha));
            chart.Series.Add(GetSeries("M-", MMinus.M, MMinus.Alpha));
        }
        public static void FillChartForecast(Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add(GetSeries("M", M.M));
            chart.Series.Add(GetSeries("Прогноз", M.Forecast));
        }
        public static void FillChartPhase(Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add(GetSeries("M", M.M));
            chart.Series.Add(GetSeries("M+", MPlus.M));
            chart.Series.Add(GetSeries("M-", MMinus.M));
        }
        private static Series GetSeries(string serName, List<double> dataY)
        {
            Series newSer = new Series(serName) { ChartType = SeriesChartType.Spline };
            for (int i = 0; i < dataY.Count; i++)
            {
                newSer.Points.AddXY(i + 1, dataY[i]);
            }
            return newSer;
        }
        private static Series GetSeries(string serName, List<double> dataX, List<double> dataY)
        {
            Series newSer = new Series(serName) { ChartType = SeriesChartType.Spline };
            for (int i = 0; i < dataX.Count; i++)
            {
                newSer.Points.AddXY(dataX[i], dataY[i]);
            }
            return newSer;
        }
        public static void CalculateAccident(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            string[] columnsName = { "Эпоха", "R", "L", "Аварийность" };
            foreach (string S in columnsName)
            {
                dataGrid.Columns.Add(S, S);
                dataGrid.Columns[S].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            for (int i = 0; i < M.M.Count; i++)
            {
                dataGrid.Rows.Add();
                ChangeDataRow(dataGrid.Rows[i], i.ToString(), MMinus.M[i], M.M[i], MPlus.M[i], M.M[0]);
            }
            dataGrid.Rows.Add();
            ChangeDataRow(dataGrid.Rows[dataGrid.Rows.Count - 1], "Прогноз", MMinus.Forecast.Last(), M.Forecast.Last(), MPlus.Forecast.Last(), M.M[0]);

            /*
            for (int i = 0; i < M.M.Count; i++)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells["Эпоха"].Value = i;
                double R = Math.Abs((MPlus.M[i] - MMinus.M[i]) / 2);
                dataGrid.Rows[i].Cells["R"].Value = R;
                double L = Math.Abs(M.M[i] - M.M[0]);
                dataGrid.Rows[i].Cells["L"].Value = L;
                dataGrid.Rows[i].Cells["Аварийность"].Value = L < R ? "Не аварийное" : (L > R ? "Аварийное" : "Предаварийное");
                switch (dataGrid.Rows[i].Cells["Аварийность"].Value.ToString())
                {
                    case "Не аварийное":
                        dataGrid.Rows[i].Cells["Аварийность"].Style.BackColor = System.Drawing.Color.Green;
                        break;
                    case "Аварийное":
                        dataGrid.Rows[i].Cells["Аварийность"].Style.BackColor = System.Drawing.Color.Red;
                        break;
                    case "Предаварийное":
                        dataGrid.Rows[i].Cells["Аварийность"].Style.BackColor = System.Drawing.Color.Yellow;
                        break;
                }
            }
            */
        }
        private static void ChangeDataRow(DataGridViewRow row, string number, double Mm, double M, double Mp, double Mzero)
        {
            double R = Math.Abs((Mp - Mm) / 2);
            double L = Math.Abs(M - Mzero);
            row.Cells["Эпоха"].Value = number;
            row.Cells["R"].Value = R;
            row.Cells["L"].Value = L;
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
    }
}
