using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Coursework
{
    /// <summary>
    /// Подсчет 2 уровня декомпозиции
    /// </summary>
    internal class CDecompLvl2
    {
        private CDecompLvl1[] Data;
        private List<int>[] PointsStorage;

        /// <summary>
        /// Количество блоков
        /// </summary>
        public int BlocksCount { get; private set; }

        /// <summary>
        /// Конструктор конструкторный
        /// </summary>
        /// <param name="PointsStorage">Точки, распределенные по блокам</param>
        public CDecompLvl2(List<int>[] PointsStorage)
        {
            this.PointsStorage = PointsStorage;
            BlocksCount = PointsStorage.Length - 1;
            Data = new CDecompLvl1[PointsStorage.Length];
            CalculateAllBlocks();
        }

        /// <summary>
        /// Выполнить рассчет 2 уровня
        /// </summary>
        private void CalculateAllBlocks()
        {
            for (int i = 0; i < PointsStorage.Length; i++)
            {
                List<List<decimal>> newTable = new List<List<decimal>>();
                for (int j = 0; j < CData.Table.Count; j++)
                {
                    newTable.Add(new List<decimal>());
                    for (int k = 0; k < PointsStorage[i].Count; k++)
                    {
                        newTable[j].Add(CData.Table[j][PointsStorage[i][k] - 1]);
                    }
                }
                Data[i] = new CDecompLvl1(newTable);
            }
        }

        /// <summary>
        /// Заполнить общий график всех блоков
        /// </summary>
        /// <param name="chart">График для заполнения</param>
        public void FillChart(Chart chart, string caption = "Блок")
        {
            chart.Series.Clear();
            chart.ChartAreas[0].RecalculateAxesScale();
            for (int i = 0; i < PointsStorage.Length; i++)
            {
                chart.Series.Add(CData.GetSeries($"{caption} {i + 1}", Data[i].M.M));
            }
        }

        /// <summary>
        /// Обращение к определенному блоку
        /// </summary>
        /// <param name="index">Номер блока</param>
        /// <returns>Вернет блок, посчитанный на основе просчетов 1 уровня</returns>
        public CDecompLvl1 this[int index] { get => Data[index]; }
    }
}
