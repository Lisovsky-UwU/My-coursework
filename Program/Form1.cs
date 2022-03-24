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
    public partial class Form1 : Form
    {
        SQLiteRequest Request;
        public Form1()
        {
            InitializeComponent();
            Request = new SQLiteRequest();
        }

        private void OpenDataBaseWithFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Базы данных (*.db;*.sqlite)|*.db;*.sqlite|Все файлы|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Request.DBIsOpen == true)
                {
                    CloseDB();
                }
                Request.OpenDB(fileDialog.FileName);
            }
        }

        private void CloseDB()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            comboBoxTable.Items.Clear();
            comboBoxTable.Enabled = false;
            textBoxT.Text = "";
            textBoxT.Enabled = false;
            textBoxA.Text = "";
            textBoxA.Enabled = false;
            pictureBox1.Image = null;
            Request.CloseDB();
        }

        private void buttonDBConnect_Click(object sender, EventArgs e)
        {
            OpenDataBaseWithFileDialog();            
            if (Request.DBIsOpen == true)
            {
                textBoxT.Text = Request.ReadT().ToString();
                textBoxT.Enabled = true;
                textBoxA.Text = Request.ReadA().ToString();
                textBoxA.Enabled = true;
                pictureBox1.Image = Request.IMG;
                //comboBoxTable.Items.AddRange(Request.TableNames);
                foreach (string tableName in Request.TableNames)
                {
                    comboBoxTable.Items.Add(tableName);
                }
                if (comboBoxTable.Items.Count != 0)
                {
                    comboBoxTable.Enabled = true;
                    comboBoxTable.SelectedIndex = 0;
                    Request.OpenAndShowTable(dataGridView1, comboBoxTable.SelectedItem.ToString());
                }
            }
        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Изображения (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|Все файлы|*.*"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(fileDialog.FileName);
                pictureBox1.Image = image;
                Request.IMG = image;
            }
        }

        private void buttonDBClose_Click(object sender, EventArgs e)
        {
            CloseDB();
        }

        private void textBoxDigitFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            //8 - backspace
            if (Char.IsDigit(symbol) == false && symbol != ',' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxT_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Text != "" && tb.Text[tb.Text.Length - 1] != ',' && tb.Text[tb.Text.Length - 1] != '0')
            {
                Request.WriteT(Convert.ToDouble((sender as TextBox).Text));
            }
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Text != "" && tb.Text[tb.Text.Length - 1] != ',' && tb.Text[tb.Text.Length - 1] != '0')
            {
                Request.WriteA(Convert.ToDouble((sender as TextBox).Text));
            }
        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Request.OpenAndShowTable(dataGridView1, comboBoxTable.SelectedItem.ToString());
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            Request.AddRowAndShow(dataGridView1);
        }

        private void buttonDeleteRows_Click(object sender, EventArgs e)
        {
            Request.DeleteRowsAndShow(dataGridView1);
        }
    }
}
