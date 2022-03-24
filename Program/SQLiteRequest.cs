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
    class SQLiteRequest
    {
        private SQLiteDataBase dataBase;
        private DataTable dTable;
        private string nameOpenTable;
        /// <summary>
        /// Открыта ли база данных
        /// </summary>
        public bool DBIsOpen { get { return dataBase.IsOpen; } }
        /// <summary>
        /// Установить или получить изображение из базы данных
        /// </summary>
        public Image IMG { get { return dataBase.GetImage("Дополнительные данные"); } 
                           set { dataBase.SaveImageToBD(value, "Дополнительные данные"); } }
        /// <summary>
        /// Получить массив с названиями всех таблиц
        /// </summary>
        public string[] TableNames { get { return dataBase.GetTabelNames(); } }
        /// <summary>
        /// Стандартный конструктор без параметров
        /// </summary>
        public SQLiteRequest()
        {
            dataBase = new SQLiteDataBase();
            dTable = null;
        }
        /// <summary>
        /// Открыть базу данных
        /// </summary>
        /// <param name="fileName">Путь к базе данных</param>
        public void OpenDB(string fileName)
        {
            dataBase.OpenDB(fileName);
        }
        /// <summary>
        /// Конструктор открытия БД по пути файла
        /// </summary>
        /// <param name="fileName">Путь к файлу с БД</param>
        public SQLiteRequest(string fileName):this()
        {
            dataBase.OpenDB(fileName);
        }
        /// <summary>
        /// Считать значение T из БД
        /// </summary>
        /// <returns>Вернет значение T из БД</returns>
        public double ReadT()
        {
            return dataBase.GetValue("Дополнительные данные", "T");
        }
        /// <summary>
        /// Считать значение A из БД
        /// </summary>
        /// <returns>Вернет значение A из БД</returns>
        public double ReadA()
        {
            return dataBase.GetValue("Дополнительные данные", "A");
        }
        /// <summary>
        /// Записать новое значение для T в БД
        /// </summary>
        /// <param name="newT">Новое значение для T</param>
        public void WriteT(double newT)
        {
            dataBase.UpdateValue("Дополнительные данные", "T", newT);
        }
        /// <summary>
        /// Записать новое значение для A в БД
        /// </summary>
        /// <param name="newA">Новое значение для A</param>
        public void WriteA(double newA)
        {
            dataBase.UpdateValue("Дополнительные данные", "A", newA);
        }
        /// <summary>
        /// Записать данные из таблицы БД в DataGridView по запросу
        /// </summary>
        /// <param name="dataGrid">Таблица, в которую запишутся значения</param>
        /// <param name="SQLQuery">Запрос, по которому будут выбираться данные</param>
        public void OpenAndShowTable(DataGridView dataGrid, string tableName)
        {
            OpenTable(tableName);
            ShowTable(dataGrid);
        }
        /// <summary>
        /// Открыть таблицу по имени таблицы
        /// </summary>
        /// <param name="tableName">Имя таблицы для открытия</param>
        public void OpenTable(string tableName)
        {
            dTable = dataBase.GetTable(tableName);
            nameOpenTable = tableName;
        }
        /// <summary>
        /// Показать таблицу в элементе на форме
        /// </summary>
        /// <param name="dataGrid">Элемент для отображения таблицы</param>
        public void ShowTable(DataGridView dataGrid)
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
        public void AddRowAndShow(DataGridView dataGrid)
        {
            AddRow();
            ShowTable(dataGrid);
        }
        /// <summary>
        /// Метод добавления строки в таблицу
        /// </summary>
        public void AddRow()
        {
            dTable.Rows.Add();
            dTable.Rows[dTable.Rows.Count - 1]["Эпоха"] = dTable.Rows.Count - 1;
            
            Random rnd = new Random();
            for (int rowIndex = 1; rowIndex < dTable.Columns.Count; rowIndex++)
            {
                double max = Convert.ToDouble(dTable.Rows[0][rowIndex]);
                double min = Convert.ToDouble(dTable.Rows[0][rowIndex]);
                for (int colIndex = 1; colIndex < dTable.Rows.Count - 2; colIndex++)
                {
                    double element = Convert.ToDouble(dTable.Rows[colIndex][rowIndex]);
                    max = Math.Max(max, element);
                    min = Math.Min(min, element);
                }
                dTable.Rows[dTable.Rows.Count - 1][rowIndex] = Math.Round(min + rnd.NextDouble() * (max - min), 4);
            }
        }
        /// <summary>
        /// Удалить выбранные строки в DataGridView и отобразить таблицу
        /// </summary>
        /// <param name="dataGrid">Элемент для отображения</param>
        public void DeleteRowsAndShow(DataGridView dataGrid)
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
        public void DeleteRows(int[] index)
        {
            var sortIndex = from i in index
                            orderby i descending
                            select i;
            foreach (int i in sortIndex)
            {
                try
                {
                    dTable.Rows.RemoveAt(i);
                }
                catch
                {
                    MessageBox.Show(
                        "Ошибка удаления строки в таблице",
                        "Ошибка удаления",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }
        /// <summary>
        /// Обновить индексы в столбце "Эпоха"
        /// </summary>
        private void UpdateIndex()
        {
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                dTable.Rows[i]["Эпоха"] = i;
            }
        }

        /// <summary>
        /// Закрыть текущую БД
        /// </summary>
        public void CloseDB()
        {
            dataBase.Close();
            dTable = null;
        }
        
    }
}
