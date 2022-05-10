using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;

namespace Coursework
{
    /// <summary>
    /// Модель для запросов к БД
    /// </summary>
    static class CRequest
    {
        private static SQLiteDataBase dataBase;
        private static DataTable dTable;
        private static string nameOpenTable;

        /// <summary>
        /// Открыта ли база данных
        /// </summary>
        public static bool DBIsOpen { get { return dataBase.IsOpen; } }

        /// <summary>
        /// Установить или получить изображение из базы данных
        /// </summary>
        public static Image IMG { get { return dataBase.GetImage("Дополнительные данные"); } 
                                  set { dataBase.SaveImageToBD(value, "Дополнительные данные"); } }
        /// <summary>
        /// Получить массив с названиями всех таблиц
        /// </summary>
        public static string[] TableNames { get { return dataBase.GetTabelNames(); } }

        /// <summary>
        /// Стандартный конструктор без параметров
        /// </summary>
        static CRequest()
        {
            dataBase = new SQLiteDataBase();
            dTable = null;
        }

        /// <summary>
        /// Открыть базу данных
        /// </summary>
        /// <param name="fileName">Путь к базе данных</param>
        public static void OpenDB(string fileName)
        {
            dataBase.OpenDB(fileName);
            CData.A = dataBase.GetValue("Дополнительные данные", "A");
            CData.T = dataBase.GetValue("Дополнительные данные", "T");
        }
        
        /// <summary>
        /// Записать новое значение для T в БД
        /// </summary>
        /// <param name="newT">Новое значение для T</param>
        public static void WriteT(double newT)
        {
            dataBase.UpdateValue("Дополнительные данные", "T", newT);
            CData.T = newT;
        }

        /// <summary>
        /// Записать новое значение для A в БД
        /// </summary>
        /// <param name="newA">Новое значение для A</param>
        public static void WriteA(double newA)
        {
            dataBase.UpdateValue("Дополнительные данные", "A", newA);
            CData.A = newA;
        }

        /// <summary>
        /// Записать данные из таблицы БД в DataGridView по запросу
        /// </summary>
        /// <param name="dataGrid">Таблица, в которую запишутся значения</param>
        /// <param name="SQLQuery">Запрос, по которому будут выбираться данные</param>
        public static void OpenAndShowTable(DataGridView dataGrid, string tableName)
        {
            OpenTable(tableName);
            ShowTable(dataGrid);
        }

        /// <summary>
        /// Открыть таблицу по имени таблицы
        /// </summary>
        /// <param name="tableName">Имя таблицы для открытия</param>
        public static void OpenTable(string tableName)
        {
            dTable = dataBase.GetTable(tableName);
            nameOpenTable = tableName;
        }

        /// <summary>
        /// Показать таблицу в элементе на форме
        /// </summary>
        /// <param name="dataGrid">Элемент для отображения таблицы</param>
        public static void ShowTable(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            string ColName;
            for (int col = 0; col < dTable.Columns.Count; col++)
            {
                ColName = dTable.Columns[col].ColumnName;
                dataGrid.Columns.Add(ColName, ColName);
                dataGrid.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (int row = 0; row < dTable.Rows.Count; row++)
            {
                dataGrid.Rows.Add(dTable.Rows[row].ItemArray);
            }
        }

        /// <summary>
        /// Добавить строку и отобразить новую таблицу 
        /// </summary>
        /// <param name="dataGrid">Элемент для отображения таблицы</param>
        public static void AddRowAndShow(DataGridView dataGrid)
        {
            AddRow();
            ShowTable(dataGrid);
        }

        /// <summary>
        /// Метод добавления строки в таблицу
        /// </summary>
        public static void AddRow()
        {
            CData.Table.Add(new List<double>());
            dTable.Rows.Add();
            dTable.Rows[dTable.Rows.Count - 1]["Эпоха"] = dTable.Rows.Count - 1;
            
            Random rnd = new Random();
            for (int colIdex = 0; colIdex < CData.Table[CData.Table.Count - 2].Count; colIdex++)
            {
                double max = CData.Table[0][colIdex];
                double min = CData.Table[0][colIdex];
                for (int rowIndex = 1; rowIndex < CData.Table.Count() - 2; rowIndex++)
                {
                    double element = CData.Table[rowIndex][colIdex];
                    max = Math.Max(max, element);
                    min = Math.Min(min, element);
                }
                double newValue = Math.Round(min + rnd.NextDouble() * (max - min), 4);
                dTable.Rows[dTable.Rows.Count - 1][colIdex] = newValue;
                CData.Table[CData.Table.Count - 1].Add(newValue);
            }
        }

        /// <summary>
        /// Удалить выбранные строки в DataGridView и отобразить таблицу
        /// </summary>
        /// <param name="dataGrid">Элемент для отображения</param>
        public static void DeleteRowsAndShow(DataGridView dataGrid)
        {
            List<int> indexSelected = new List<int>();
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                indexSelected.Add(row.Index);
            }
            DeleteRows(indexSelected.ToArray());
            UpdateIndex();
            ShowTable(dataGrid);
        }

        /// <summary>
        /// Удалить строки по индексам
        /// </summary>
        /// <param name="index">Индексы строк для удаления</param>
        public static void DeleteRows(int[] index)
        {
            var sortIndex = from i in index
                            orderby i descending
                            select i;
            foreach (int i in sortIndex)
            {
                try
                {
                    dTable.Rows.RemoveAt(i);
                    CData.Table.RemoveAt(i);
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления строки в таблице", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// Обновить индексы в столбце "Эпоха"
        /// </summary>
        private static void UpdateIndex()
        {
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                dTable.Rows[i]["Эпоха"] = i;
            }
        }

        /// <summary>
        /// Сохранить таблицу в БД
        /// </summary>
        public static void SaveTable()
        {
            dataBase.UpdateTable(nameOpenTable, dTable);
        }

        /// <summary>
        /// Закрыть текущую БД
        /// </summary>
        public static void CloseDB()
        {
            dataBase.Close();
            dTable = null;
        }
        
    }
}
