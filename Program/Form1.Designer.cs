
namespace Coursework
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripOpenDB = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSaveDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripCloseDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownData = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripUpdateImage = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonDeleteRows = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(478, 280);
            this.dataGridView1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(493, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "T =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "A =";
            // 
            // textBoxT
            // 
            this.textBoxT.Enabled = false;
            this.textBoxT.Location = new System.Drawing.Point(37, 8);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(104, 20);
            this.textBoxT.TabIndex = 6;
            this.textBoxT.TextChanged += new System.EventHandler(this.textBoxT_TextChanged);
            this.textBoxT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDigitFilter_KeyPress);
            // 
            // textBoxA
            // 
            this.textBoxA.Enabled = false;
            this.textBoxA.Location = new System.Drawing.Point(180, 8);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(104, 20);
            this.textBoxA.TabIndex = 7;
            this.textBoxA.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            this.textBoxA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDigitFilter_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownFile,
            this.toolStripDropDownData});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(876, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownFile
            // 
            this.toolStripDropDownFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripOpenDB,
            this.ToolStripSaveDB,
            this.toolStripSeparator1,
            this.ToolStripCloseDB});
            this.toolStripDropDownFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownFile.Image")));
            this.toolStripDropDownFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownFile.Name = "toolStripDropDownFile";
            this.toolStripDropDownFile.Size = new System.Drawing.Size(49, 22);
            this.toolStripDropDownFile.Text = "Файл";
            // 
            // ToolStripOpenDB
            // 
            this.ToolStripOpenDB.Name = "ToolStripOpenDB";
            this.ToolStripOpenDB.Size = new System.Drawing.Size(180, 22);
            this.ToolStripOpenDB.Text = "Открыть БД";
            this.ToolStripOpenDB.Click += new System.EventHandler(this.buttonDBConnect_Click);
            // 
            // ToolStripSaveDB
            // 
            this.ToolStripSaveDB.Name = "ToolStripSaveDB";
            this.ToolStripSaveDB.Size = new System.Drawing.Size(180, 22);
            this.ToolStripSaveDB.Text = "Сохранить БД";
            this.ToolStripSaveDB.Click += new System.EventHandler(this.ToolStripSaveDB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripCloseDB
            // 
            this.ToolStripCloseDB.Name = "ToolStripCloseDB";
            this.ToolStripCloseDB.Size = new System.Drawing.Size(180, 22);
            this.ToolStripCloseDB.Text = "Закрыть БД";
            this.ToolStripCloseDB.Click += new System.EventHandler(this.buttonDBClose_Click);
            // 
            // toolStripDropDownData
            // 
            this.toolStripDropDownData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripUpdateImage,
            this.ToolStripAddRow});
            this.toolStripDropDownData.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownData.Image")));
            this.toolStripDropDownData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownData.Name = "toolStripDropDownData";
            this.toolStripDropDownData.Size = new System.Drawing.Size(63, 22);
            this.toolStripDropDownData.Text = "Данные";
            // 
            // ToolStripUpdateImage
            // 
            this.ToolStripUpdateImage.Name = "ToolStripUpdateImage";
            this.ToolStripUpdateImage.Size = new System.Drawing.Size(205, 22);
            this.ToolStripUpdateImage.Text = "Обновить изображение";
            this.ToolStripUpdateImage.Click += new System.EventHandler(this.buttonUploadImage_Click);
            // 
            // ToolStripAddRow
            // 
            this.ToolStripAddRow.Name = "ToolStripAddRow";
            this.ToolStripAddRow.Size = new System.Drawing.Size(205, 22);
            this.ToolStripAddRow.Text = "Добавить строку";
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.Enabled = false;
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(74, 8);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTable.TabIndex = 10;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxTable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Таблица:";
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(9, 327);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(118, 23);
            this.buttonAddRow.TabIndex = 12;
            this.buttonAddRow.Text = "Добавить строку";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonDeleteRows
            // 
            this.buttonDeleteRows.Location = new System.Drawing.Point(133, 327);
            this.buttonDeleteRows.Name = "buttonDeleteRows";
            this.buttonDeleteRows.Size = new System.Drawing.Size(119, 23);
            this.buttonDeleteRows.TabIndex = 13;
            this.buttonDeleteRows.Text = "Удалить строку(и)";
            this.buttonDeleteRows.UseVisualStyleBackColor = true;
            this.buttonDeleteRows.Click += new System.EventHandler(this.buttonDeleteRows_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxT);
            this.panel1.Controls.Add(this.textBoxA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 36);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.buttonDeleteRows);
            this.panel2.Controls.Add(this.comboBoxTable);
            this.panel2.Controls.Add(this.buttonAddRow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 373);
            this.panel2.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 434);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxT;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripOpenDB;
        private System.Windows.Forms.ToolStripMenuItem ToolStripSaveDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripCloseDB;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownData;
        private System.Windows.Forms.ToolStripMenuItem ToolStripUpdateImage;
        private System.Windows.Forms.ToolStripMenuItem ToolStripAddRow;
        private System.Windows.Forms.ComboBox comboBoxTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonDeleteRows;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

