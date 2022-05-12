using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    /// <summary>
    /// Данные из БД (T, A, значения из открытой таблицы)
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
    }
}
