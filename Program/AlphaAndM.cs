using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Coursework
{
    /// <summary>
    /// Класс для просчета значений вектора
    /// </summary>
    class AlphaAndM
    {
        /// <summary>
        /// Значения угла вектора
        /// </summary>
        public List<double> Alpha;

        /// <summary>
        /// Значение вектора
        /// </summary>
        public List<double> M;

        /// <summary>
        /// Прогноз значений вектора
        /// </summary>
        public List<double> MForecast;

        /// <summary>
        /// Прогноз значений угла вектора
        /// </summary>
        public List<double> AlphaForecast;

        /// <summary>
        /// Прогнозное значение вектора
        /// </summary>
        public double MForecastValue { get { return MForecast.Last(); } }

        /// <summary>
        /// Прогнозное значение угла вектора
        /// </summary>
        public double AlphaForecastValue { get { return AlphaForecast.Last(); } }

        /// <summary>
        /// Конструктор для подсчета значений вектора по таблице значений
        /// </summary>
        /// <param name="ValuesTable">Таблица значений для подсчета</param>
        /// <param name="modify">Модификатор для значений таблицы (точность)</param>
        public AlphaAndM(List<List<double>> ValuesTable, double modify = 0)
        {
            M = CalculateM(ValuesTable, modify);
            Alpha = CalculateAlpha(ValuesTable, modify);
            MForecast = CalculateForecast(M);
            AlphaForecast = CalculateForecast(Alpha);
        }

        /// <summary>
        /// Подсчет длины вектора
        /// </summary>
        /// <param name="ValuesTable">Таблица значений</param>
        /// <param name="modify">Модификатор для значений таблицы</param>
        /// <returns>Вернет готовый список со значениями</returns>
        private List<double> CalculateM(List<List<double>> ValuesTable, double modify)
        {
            List<double> result = new List<double>();
            for (int row = 0; row < ValuesTable.Count; row++)
            {
                double summSQ = 0;
                for (int col = 0; col < ValuesTable[row].Count(); col++)
                {
                    try
                    {
                        summSQ += Math.Pow(ValuesTable[row][col] + modify, 2);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка расчета M", "Ошибка расчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                result.Add(Math.Sqrt(summSQ));
            }
            return result;
        }

        /// <summary>
        /// Подсчет угла вектора
        /// </summary>
        /// <param name="ValuesTable">Таблица значений</param>
        /// <param name="modify">Модификатор значений</param>
        /// <returns>Вернет список со значениями</returns>
        private List<double> CalculateAlpha(List<List<double>> ValuesTable, double modify)
        {
            List<double> result = new List<double> { 0 };
            for (int row = 1; row < ValuesTable.Count; row++)
            {
                double summProd = 0;
                for (int col = 0; col < ValuesTable[row].Count; col++)
                {
                    try
                    {
                        summProd += (ValuesTable[row][col] + modify) * (ValuesTable[0][col] + modify);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка расчета Alpha", "Ошибка расчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                result.Add(Math.Acos(summProd / (M[0] * M[row])));
            }
            return result;
        }

        /// <summary>
        /// Подсчет прогнозируемых значений
        /// </summary>
        /// <param name="ValuesList">Список значений для прогноза</param>
        /// <returns>Готовый список с прогнозными значениями</returns>
        private List<double> CalculateForecast(List<double> ValuesList)
        {
            List<double> result = new List<double> { CData.A * ValuesList[0] + (1 - CData.A) * ValuesList.Average() };
            for (int i = 1; i < ValuesList.Count; i++)
            {
                result.Add(CData.A * ValuesList[i] + (1 - CData.A) * result[i - 1]);
            }
            result.Add(CData.A * result.Average() + (1 - CData.A) * result[result.Count - 1]);
            return result;
        }
    }
}
