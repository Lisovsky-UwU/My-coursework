
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.buttonDeleteRows = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.pictureBoxInData = new System.Windows.Forms.PictureBox();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.tabPageLvl1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.chartForecast = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAllM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBoxLvl1 = new System.Windows.Forms.PictureBox();
            this.chartPhase = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewAccident = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.tabPageLvl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAllM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLvl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccident)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(859, 25);
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
            this.ToolStripOpenDB.Size = new System.Drawing.Size(151, 22);
            this.ToolStripOpenDB.Text = "Открыть БД";
            this.ToolStripOpenDB.Click += new System.EventHandler(this.buttonDBConnect_Click);
            // 
            // ToolStripSaveDB
            // 
            this.ToolStripSaveDB.Name = "ToolStripSaveDB";
            this.ToolStripSaveDB.Size = new System.Drawing.Size(151, 22);
            this.ToolStripSaveDB.Text = "Сохранить БД";
            this.ToolStripSaveDB.Click += new System.EventHandler(this.ToolStripSaveDB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // ToolStripCloseDB
            // 
            this.ToolStripCloseDB.Name = "ToolStripCloseDB";
            this.ToolStripCloseDB.Size = new System.Drawing.Size(151, 22);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxT);
            this.panel1.Controls.Add(this.textBoxA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 36);
            this.panel1.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageLvl1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 406);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.label3);
            this.tabPageData.Controls.Add(this.comboBoxTable);
            this.tabPageData.Controls.Add(this.buttonDeleteRows);
            this.tabPageData.Controls.Add(this.buttonAddRow);
            this.tabPageData.Controls.Add(this.pictureBoxInData);
            this.tabPageData.Controls.Add(this.dataGridViewData);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(851, 380);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "Данные";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Таблица";
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.Enabled = false;
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(73, 10);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTable.TabIndex = 4;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxTable_SelectedIndexChanged);
            // 
            // buttonDeleteRows
            // 
            this.buttonDeleteRows.Enabled = false;
            this.buttonDeleteRows.Location = new System.Drawing.Point(135, 331);
            this.buttonDeleteRows.Name = "buttonDeleteRows";
            this.buttonDeleteRows.Size = new System.Drawing.Size(121, 23);
            this.buttonDeleteRows.TabIndex = 3;
            this.buttonDeleteRows.Text = "Удалить строки";
            this.buttonDeleteRows.UseVisualStyleBackColor = true;
            this.buttonDeleteRows.Click += new System.EventHandler(this.buttonDeleteRows_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Enabled = false;
            this.buttonAddRow.Location = new System.Drawing.Point(11, 331);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(115, 23);
            this.buttonAddRow.TabIndex = 2;
            this.buttonAddRow.Text = "Добавить строку";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // pictureBoxInData
            // 
            this.pictureBoxInData.Location = new System.Drawing.Point(500, 37);
            this.pictureBoxInData.Name = "pictureBoxInData";
            this.pictureBoxInData.Size = new System.Drawing.Size(343, 235);
            this.pictureBoxInData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxInData.TabIndex = 1;
            this.pictureBoxInData.TabStop = false;
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(11, 37);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.Size = new System.Drawing.Size(483, 287);
            this.dataGridViewData.TabIndex = 0;
            // 
            // tabPageLvl1
            // 
            this.tabPageLvl1.Controls.Add(this.dataGridViewAccident);
            this.tabPageLvl1.Controls.Add(this.chartPhase);
            this.tabPageLvl1.Controls.Add(this.button1);
            this.tabPageLvl1.Controls.Add(this.chartForecast);
            this.tabPageLvl1.Controls.Add(this.chartAllM);
            this.tabPageLvl1.Controls.Add(this.pictureBoxLvl1);
            this.tabPageLvl1.Location = new System.Drawing.Point(4, 22);
            this.tabPageLvl1.Name = "tabPageLvl1";
            this.tabPageLvl1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLvl1.Size = new System.Drawing.Size(851, 380);
            this.tabPageLvl1.TabIndex = 1;
            this.tabPageLvl1.Text = "1 уровень";
            this.tabPageLvl1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(548, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartForecast
            // 
            chartArea10.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea10.AxisX.IsStartedFromZero = false;
            chartArea10.AxisX.LabelStyle.Enabled = false;
            chartArea10.AxisX.MajorGrid.Enabled = false;
            chartArea10.AxisX.MajorTickMark.Enabled = false;
            chartArea10.AxisX.Title = "t";
            chartArea10.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea10.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea10.AxisY.IsStartedFromZero = false;
            chartArea10.AxisY.LabelStyle.Enabled = false;
            chartArea10.AxisY.MajorGrid.Enabled = false;
            chartArea10.AxisY.MajorTickMark.Enabled = false;
            chartArea10.AxisY.Title = "M";
            chartArea10.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea10.Name = "ChartArea1";
            this.chartForecast.ChartAreas.Add(chartArea10);
            legend10.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend10.Name = "Legend1";
            this.chartForecast.Legends.Add(legend10);
            this.chartForecast.Location = new System.Drawing.Point(11, 193);
            this.chartForecast.Name = "chartForecast";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chartForecast.Series.Add(series10);
            this.chartForecast.Size = new System.Drawing.Size(258, 184);
            this.chartForecast.TabIndex = 4;
            this.chartForecast.Text = "chart1";
            // 
            // chartAllM
            // 
            chartArea11.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea11.AxisX.IsStartedFromZero = false;
            chartArea11.AxisX.LabelStyle.Enabled = false;
            chartArea11.AxisX.MajorGrid.Enabled = false;
            chartArea11.AxisX.MajorTickMark.Enabled = false;
            chartArea11.AxisX.Title = "M";
            chartArea11.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea11.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea11.AxisY.IsStartedFromZero = false;
            chartArea11.AxisY.LabelStyle.Enabled = false;
            chartArea11.AxisY.MajorGrid.Enabled = false;
            chartArea11.AxisY.MajorTickMark.Enabled = false;
            chartArea11.AxisY.Title = "alpha";
            chartArea11.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea11.Name = "ChartArea1";
            this.chartAllM.ChartAreas.Add(chartArea11);
            legend11.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend11.Name = "Legend1";
            this.chartAllM.Legends.Add(legend11);
            this.chartAllM.Location = new System.Drawing.Point(3, 3);
            this.chartAllM.Name = "chartAllM";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chartAllM.Series.Add(series11);
            this.chartAllM.Size = new System.Drawing.Size(266, 187);
            this.chartAllM.TabIndex = 3;
            this.chartAllM.Text = "chart1";
            // 
            // pictureBoxLvl1
            // 
            this.pictureBoxLvl1.Location = new System.Drawing.Point(296, 6);
            this.pictureBoxLvl1.Name = "pictureBoxLvl1";
            this.pictureBoxLvl1.Size = new System.Drawing.Size(246, 144);
            this.pictureBoxLvl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLvl1.TabIndex = 2;
            this.pictureBoxLvl1.TabStop = false;
            // 
            // chartPhase
            // 
            chartArea12.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea12.AxisX.IsStartedFromZero = false;
            chartArea12.AxisX.LabelStyle.Enabled = false;
            chartArea12.AxisX.MajorGrid.Enabled = false;
            chartArea12.AxisX.MajorTickMark.Enabled = false;
            chartArea12.AxisX.Title = "t";
            chartArea12.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea12.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea12.AxisY.IsStartedFromZero = false;
            chartArea12.AxisY.LabelStyle.Enabled = false;
            chartArea12.AxisY.MajorGrid.Enabled = false;
            chartArea12.AxisY.MajorTickMark.Enabled = false;
            chartArea12.AxisY.Title = "M";
            chartArea12.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea12.Name = "ChartArea1";
            this.chartPhase.ChartAreas.Add(chartArea12);
            legend12.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend12.Name = "Legend1";
            this.chartPhase.Legends.Add(legend12);
            this.chartPhase.Location = new System.Drawing.Point(275, 186);
            this.chartPhase.Name = "chartPhase";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chartPhase.Series.Add(series12);
            this.chartPhase.Size = new System.Drawing.Size(267, 188);
            this.chartPhase.TabIndex = 6;
            this.chartPhase.Text = "chart1";
            // 
            // dataGridViewAccident
            // 
            this.dataGridViewAccident.AllowUserToAddRows = false;
            this.dataGridViewAccident.AllowUserToDeleteRows = false;
            this.dataGridViewAccident.AllowUserToResizeRows = false;
            this.dataGridViewAccident.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccident.Location = new System.Drawing.Point(548, 35);
            this.dataGridViewAccident.Name = "dataGridViewAccident";
            this.dataGridViewAccident.ReadOnly = true;
            this.dataGridViewAccident.RowHeadersVisible = false;
            this.dataGridViewAccident.Size = new System.Drawing.Size(295, 337);
            this.dataGridViewAccident.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 467);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.tabPageLvl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAllM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLvl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccident)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.Button buttonDeleteRows;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.PictureBox pictureBoxInData;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.TabPage tabPageLvl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTable;
        private System.Windows.Forms.PictureBox pictureBoxLvl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAllM;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartForecast;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhase;
        private System.Windows.Forms.DataGridView dataGridViewAccident;
    }
}

