using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Coursework
{
    class SQLiteDataBase
    {
        private SQLiteConnection SQLConn;
        public bool IsOpen { get { return dataBaseIsOpen; } }
        private bool dataBaseIsOpen;

        /// <summary>
        /// Стандартный конструктор без параметров
        /// </summary>
        public SQLiteDataBase()
        {
            dataBaseIsOpen = false;
        }
        /// <summary>
        /// Конструктор открытия БД по пути файла
        /// </summary>
        /// <param name="fileName">Путь к файлу с БД</param>
        public SQLiteDataBase(string fileName) : this()
        {
            OpenDB(fileName);
        }
        /// <summary>
        /// Выполнить запрос
        /// </summary>
        /// <param name="SQLQuery">Запрос для выполнения</param>
        public void RunQuery(string SQLQuery)
        {
            try
            {
                new SQLiteCommand(SQLQuery, SQLConn).ExecuteNonQuery();
            } 
            catch
            {
                throw new Exception("Ошибка выполнения запроса");
            }
        }
        /// <summary>
        /// Метод открытия базы данных по пути к файлу
        /// </summary>
        /// <param name="fileName">Путь к базе данных</param>
        public void OpenDB(string fileName)
        {
            SQLConn = new SQLiteConnection
            {
                ConnectionString = $"DATA SOURCE={fileName};"
            };
            SQLConn.Open();
            this.CorrectDB();
            dataBaseIsOpen = true;
        }
        /// <summary>
        /// Получить имена всех таблиц в базе данных
        /// </summary>
        /// <returns>Вернет список строк с именами</returns>
        public string[] GetTabelNames()
        {
            List<string> resultList = new List<string>();
            string SQLQuery = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
            SQLiteCommand command = new SQLiteCommand(SQLQuery, SQLConn);
            SQLiteDataReader tableReader = command.ExecuteReader();
            while (tableReader.Read())
            {
                if (tableReader[0].ToString() != "Дополнительные данные")
                {
                    resultList.Add(tableReader[0].ToString());
                }
            }
            return resultList.ToArray();
        }
        /// <summary>
        /// Скорректировать данные в БД
        /// </summary>
        private void CorrectDB()
        {
            //Здесь происходит замена запятых во всех ячейках всех таблиц на точки
            //Только в ячейках с типом REAL
            foreach (string tableName in GetTabelNames())
            {
                string SQLQuery = $"PRAGMA table_info(\"{tableName}\");";
                SQLiteCommand tableCommand = new SQLiteCommand(SQLQuery, SQLConn);
                SQLiteDataReader colReader = tableCommand.ExecuteReader();
                while (colReader.Read())
                {
                    if ((string)colReader[2] == "REAL")
                    {
                        RunQuery($"UPDATE [{tableName}] SET [{(string)colReader[1]}] = REPLACE([{(string)colReader[1]}], ',', '.');");
                    }
                }
            }
        }
        /// <summary>
        /// Получить значение из таблицы в БД
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="valueName">Имя значения</param>
        /// <returns>Первое значение в столбце</returns>
        public double GetValue(string tableName, string valueName)
        {
            string SQLQuery = $"SELECT [{valueName}] FROM [{tableName}];";
            SQLiteCommand command = new SQLiteCommand(SQLQuery, SQLConn);
            try
            {
                return Convert.ToDouble(command.ExecuteScalar());
            }
            catch
            {
                MessageBox.Show(
                    $"Ошибка чтения значения {valueName}",
                    "Ошибка чтения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return 0;
            }
            
        }
        /// <summary>
        /// Обновить значение в таблице в БД
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="valueName">Имя значения</param>
        /// <param name="newValue">Новое значение</param>
        /// <param name="addendumQuery">Дополнительные параметры к запросу</param>
        public void UpdateValue(string tableName, string valueName, double newValue, string addendumQuery = "")
        {
            try
            {
                RunQuery($"UPDATE [{tableName}] SET [{valueName}] = {newValue} {addendumQuery};".Replace(',', '.')); //КОСТЫЛЬ
            }
            catch
            {
                MessageBox.Show(
                    $"Ошибка записи значения {valueName}",
                    "Ошибка записи",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
        /// <summary>
        /// Конвертация изображения в биты
        /// </summary>
        /// <param name="image">Изображение для конвертации</param>
        /// <param name="format">Формат конвертируемого изображения</param>
        /// <returns>Вернет массив байтов</returns>
        private byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
        /// <summary>
        /// Конвертация набора битов в изрбражение
        /// </summary>
        /// <param name="imageBytes">Набор битов для конвертации</param>
        /// <returns>Вернет изображение</returns>
        private Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);
            Image image = Image.FromStream(ms);
            return image;
        }
        /// <summary>
        /// Сохранение изображения в таблицу
        /// </summary>
        /// <param name="IMG">Изображение для сохранения</param>
        /// <param name="tableName">Имя таблицы с изображением</param>
        /// <param name="fieldName">Имя поля с изображением</param>
        public void SaveImageToBD(Image IMG, string tableName, string fieldName = "Image")
        {
            byte[] IMGByte = ImageToByte(IMG, System.Drawing.Imaging.ImageFormat.Jpeg);
            string SQLQuery = $@"UPDATE [{tableName}] SET [{fieldName}] = @0;";
            SQLiteCommand command = new SQLiteCommand(SQLQuery, SQLConn);
            SQLiteParameter parameter = new SQLiteParameter("@0", System.Data.DbType.Binary)
            {
                Value = IMGByte
            };
            command.Parameters.Add(parameter);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show(
                   "Ошибка сохранения изображения",
                   "Ошибка чтения",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
            }
        }
        /// <summary>
        /// Чтение изображения из БД
        /// </summary>
        /// <returns>Вернет изображение</returns>
        public Image GetImage(string tableName, string fieldName = "Image")
        {
            string SQLQuery = $"SELECT [{fieldName}] FROM [{tableName}];";
            SQLiteCommand command = new SQLiteCommand(SQLQuery, SQLConn);
            try
            {
                return ByteToImage((byte[])command.ExecuteScalar());
            } 
            catch
            {
                MessageBox.Show(
                   "Ошибка чтения изображения",
                   "Ошибка чтения",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
                return null;
            }
        }
        /// <summary>
        /// Получить таблицу из БД
        /// </summary>
        /// <param name="tableName">Название таблицы</param>
        /// <param name="addendumQuery">Дополнительные параметры к запросу для чтения</param>
        public DataTable GetTable(string tableName, string addendumQuery = "")
        {
            DataTable dTable = new DataTable();
            dTable.Clear();
            string SQLQuery = $"SELECT * FROM [{tableName}] {addendumQuery};";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQLQuery, SQLConn);
            try
            {
                adapter.Fill(dTable);
            }
            catch
            {
                MessageBox.Show(
                   $"Ошибка чтения таблицы {tableName}",
                   "Ошибка чтения",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
            }
            return dTable;
        }
        /// <summary>
        /// Метод закрытия базы даных
        /// </summary>
        public void Close()
        {
            SQLConn.Close();
        }
    }
}
