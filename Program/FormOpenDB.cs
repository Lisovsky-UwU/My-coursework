using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class FormOpenDB : Form
    {
        MainForm mainForm;
        public FormOpenDB(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        // Кнопка диалогового выбора файла
        private void buttonBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Базы данных (*.db;*.sqlite)|*.db;*.sqlite|Все файлы|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = fileDialog.FileName;
            }
        }

        // Кнопка открытия БД
        private void buttonOpenDB_Click(object sender, EventArgs e)
        {
            try
            {
                CRequest.OpenDB(textBoxFilePath.Text);
                mainForm.OpenDB();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка открытия файла базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка закрытия формы открытия БД
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
