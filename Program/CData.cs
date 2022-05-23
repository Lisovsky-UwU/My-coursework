using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Coursework
{
    /// <summary>
    /// Данные из БД (T, A, значения из открытой таблицы) и вспомогательные функции
    /// </summary>
    static class CData
    {
        /// <summary>
        /// Количество знаков после запятой для отображения в таблице
        /// </summary>
        public static int DecNumbToOutput { get; set; }

        /// <summary>
        /// Точность измерений
        /// </summary>
        public static decimal T { get; set; }

        /// <summary>
        /// коэффициент экспоненциального сглаживания
        /// </summary>
        public static decimal A { get; set; }

        /// <summary>
        /// Данные из открытой таблицы
        /// </summary>
        public static List<List<decimal>> Table { get; set; }

        /// <summary>
        /// Количество столбцов в открытой таблице
        /// </summary>
        public static int ColumnCount { get; set; }

        /// <summary>
        /// Количество строк в открытой таблице
        /// </summary>
        public static int RowCount { get; set; }

        /// <summary>
        /// Конструктор (вот уже удивительно, да?)
        /// </summary>
        static CData()
        {
            Table = new List<List<decimal>>();
            DecNumbToOutput = 6;
        }

        /// <summary>
        /// Умное округление - если по результату округления число равно нулю, то оно не округляется
        /// </summary>
        /// <param name="value">Число для округления</param>
        /// <returns>Округленное число</returns>
        public static double Round(decimal value)
        {
            decimal roundVal = Math.Round(value, DecNumbToOutput);
            return (double)(roundVal != 0 ? roundVal : (Math.Round(roundVal, 8) == 0 ? 0 : value));
        }

        /// <summary>
        /// Фунуция для создания серии по значениям только для Y
        /// </summary>
        /// <param name="serName">Название серии</param>
        /// <param name="dataY">Значения по Y</param>
        /// <returns>Вернет серию для Chart</returns>
        public static Series GetSeries(string serName, List<decimal> dataY)
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
        public static Series GetSeries(string serName, List<decimal> dataX, List<decimal> dataY)
        {
            Series newSer = new Series(serName) { ChartType = SeriesChartType.Spline };
            for (int i = 0; i < dataX.Count; i++)
            {
                newSer.Points.AddXY(dataX[i], dataY[i]);
            }
            return newSer;
        }

        /// <summary>
        /// Получить таблицу сформированную по точкам
        /// </summary>
        /// <param name="points">Список точек</param>
        /// <returns>Вернет таблицу, по количеству сфомированных точек</returns>
        public static List<List<decimal>> GetTableForPoints(List<int> points)
        {
            List<List<decimal>> newTable = new List<List<decimal>>();
            for (int i = 0; i < RowCount; i++)
            {
                newTable.Add(new List<decimal>());
                for (int j = 0; j < points.Count; j++)
                {
                    newTable[i].Add(Table[i][points[j] - 1]);
                }
            }
            return newTable;
        }

        public static void FillChartLinks(Chart chart, bool[,] matrix, List<int> pointList, int borderWidth = 1)
        {
            chart.Series.Clear();
            double[,] pointsArr = new double[pointList.Count, 2];

            for (int i = 0; i < pointList.Count; i++)
            {
                double arg = i * (Math.PI * 2) / pointList.Count;
                pointsArr[i, 0] = Math.Cos(arg);
                pointsArr[i, 1] = Math.Sin(arg);

                string serName = $"{i}";
                chart.Series.Add(serName);
                chart.Series[serName].ChartType = SeriesChartType.Line;
                chart.Series[serName].Points.AddXY(pointsArr[i, 0], pointsArr[i, 1]);
                chart.Series[serName].MarkerStyle = MarkerStyle.Circle;
                chart.Series[serName].MarkerColor = Color.Blue;
                chart.Series[serName].MarkerSize = borderWidth * 3 + 2;
                chart.Series[serName].Label = pointList[i].ToString();
                chart.Series[serName].Font = new Font(chart.Series[serName].Font.Name, 10, FontStyle.Regular);
            }

            for (int i = 0; i < pointList.Count; i++)
            {
                for (int j = i + 1; j < pointList.Count; j++)
                {
                    string serName = $"{i}-{j}";
                    chart.Series.Add(serName);
                    chart.Series[serName].ChartType = SeriesChartType.Line;
                    chart.Series[serName].Points.AddXY(pointsArr[i, 0], pointsArr[i, 1]);
                    chart.Series[serName].Points.AddXY(pointsArr[j, 0], pointsArr[j, 1]);
                    chart.Series[serName].Color = matrix[i, j] == true ? Color.Green : Color.Red;
                    chart.Series[serName].BorderWidth = borderWidth;
                }
            }
        }
    }
}
