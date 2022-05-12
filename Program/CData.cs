using System;
using System.Collections.Generic;
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
        public static int DecNumbToOutput;

        /// <summary>
        /// Точность измерений
        /// </summary>
        public static decimal T;

        /// <summary>
        /// коэффициент экспоненциального сглаживания
        /// </summary>
        public static decimal A;

        /// <summary>
        /// Данные из ткрытой таблицы
        /// </summary>
        public static List<List<decimal>> Table;

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
        /// Получить область для построения графика с настройками поумолчанию
        /// </summary>
        /// <param name="nameX">Подпись для оси X</param>
        /// <param name="nameY">Подпись для оси Y</param>
        /// <returns>Вернет готовую ChartArea</returns>
        public static ChartArea GetDefaultChartArea(string nameX, string nameY)
        {
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX = GetAxis(nameX);
            chartArea.AxisY = GetAxis(nameY);
            return chartArea;
        }

        /// <summary>
        /// Получить готовую ось с настройками поумолчанию
        /// </summary>
        /// <param name="name">Подпись оси</param>
        /// <returns>Вернет готовую ось</returns>
        private static Axis GetAxis(string name)
        {
            Axis axis = new Axis();
            axis.IsStartedFromZero = false;
            axis.LabelStyle.Enabled = false;
            axis.ArrowStyle = AxisArrowStyle.Triangle;
            axis.MajorGrid.Enabled = false;
            axis.MajorTickMark.Enabled = false;
            axis.Title = name;
            axis.TitleAlignment = System.Drawing.StringAlignment.Far;
            return axis;
        }
    }
}
