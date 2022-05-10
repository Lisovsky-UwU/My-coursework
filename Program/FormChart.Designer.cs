namespace Coursework
{
    partial class FormChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartVis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelChart = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxTags = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownLineWidth = new System.Windows.Forms.NumericUpDown();
            this.radioButtonTagCaptionNone = new System.Windows.Forms.RadioButton();
            this.radioButtonTagCaptionNumber = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonTagCaptionValue = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxCaptoin = new System.Windows.Forms.CheckBox();
            this.checkBoxGridVisible = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartVis)).BeginInit();
            this.panelChart.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartVis
            // 
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Title = "<Имя оси X>";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Title = "<Имя оси Y>";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            this.chartVis.ChartAreas.Add(chartArea1);
            this.chartVis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartVis.Legends.Add(legend1);
            this.chartVis.Location = new System.Drawing.Point(0, 0);
            this.chartVis.Name = "chartVis";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVis.Series.Add(series1);
            this.chartVis.Size = new System.Drawing.Size(560, 446);
            this.chartVis.TabIndex = 0;
            this.chartVis.Text = "chartVis";
            // 
            // panelChart
            // 
            this.panelChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChart.Controls.Add(this.chartVis);
            this.panelChart.Location = new System.Drawing.Point(1, 0);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(560, 446);
            this.panelChart.TabIndex = 1;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.groupBox3);
            this.panelSettings.Controls.Add(this.groupBox2);
            this.panelSettings.Controls.Add(this.groupBox1);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSettings.Location = new System.Drawing.Point(567, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(149, 446);
            this.panelSettings.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(5, 278);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 165);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Графики";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxTags);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDownLineWidth);
            this.groupBox2.Controls.Add(this.radioButtonTagCaptionNone);
            this.groupBox2.Controls.Add(this.radioButtonTagCaptionNumber);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioButtonTagCaptionValue);
            this.groupBox2.Location = new System.Drawing.Point(5, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 181);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вид графиков";
            // 
            // checkBoxTags
            // 
            this.checkBoxTags.AutoSize = true;
            this.checkBoxTags.Location = new System.Drawing.Point(6, 19);
            this.checkBoxTags.Name = "checkBoxTags";
            this.checkBoxTags.Size = new System.Drawing.Size(58, 17);
            this.checkBoxTags.TabIndex = 2;
            this.checkBoxTags.Text = "Метки";
            this.checkBoxTags.UseVisualStyleBackColor = true;
            this.checkBoxTags.CheckedChanged += new System.EventHandler(this.checkBoxTags_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Толщина линий";
            // 
            // numericUpDownLineWidth
            // 
            this.numericUpDownLineWidth.Location = new System.Drawing.Point(6, 59);
            this.numericUpDownLineWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLineWidth.Name = "numericUpDownLineWidth";
            this.numericUpDownLineWidth.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownLineWidth.TabIndex = 8;
            this.numericUpDownLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLineWidth.ValueChanged += new System.EventHandler(this.numericUpDownLineWidth_ValueChanged);
            // 
            // radioButtonTagCaptionNone
            // 
            this.radioButtonTagCaptionNone.AutoSize = true;
            this.radioButtonTagCaptionNone.Checked = true;
            this.radioButtonTagCaptionNone.Location = new System.Drawing.Point(6, 105);
            this.radioButtonTagCaptionNone.Name = "radioButtonTagCaptionNone";
            this.radioButtonTagCaptionNone.Size = new System.Drawing.Size(80, 17);
            this.radioButtonTagCaptionNone.TabIndex = 4;
            this.radioButtonTagCaptionNone.TabStop = true;
            this.radioButtonTagCaptionNone.Text = "Отключить";
            this.radioButtonTagCaptionNone.UseVisualStyleBackColor = true;
            this.radioButtonTagCaptionNone.CheckedChanged += new System.EventHandler(this.radioButtonTagCaptionNone_CheckedChanged);
            // 
            // radioButtonTagCaptionNumber
            // 
            this.radioButtonTagCaptionNumber.AutoSize = true;
            this.radioButtonTagCaptionNumber.Location = new System.Drawing.Point(6, 128);
            this.radioButtonTagCaptionNumber.Name = "radioButtonTagCaptionNumber";
            this.radioButtonTagCaptionNumber.Size = new System.Drawing.Size(59, 17);
            this.radioButtonTagCaptionNumber.TabIndex = 5;
            this.radioButtonTagCaptionNumber.Text = "Номер";
            this.radioButtonTagCaptionNumber.UseVisualStyleBackColor = true;
            this.radioButtonTagCaptionNumber.CheckedChanged += new System.EventHandler(this.radioButtonTagCaptionNumber_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Подписи меток";
            // 
            // radioButtonTagCaptionValue
            // 
            this.radioButtonTagCaptionValue.AutoSize = true;
            this.radioButtonTagCaptionValue.Location = new System.Drawing.Point(6, 151);
            this.radioButtonTagCaptionValue.Name = "radioButtonTagCaptionValue";
            this.radioButtonTagCaptionValue.Size = new System.Drawing.Size(73, 17);
            this.radioButtonTagCaptionValue.TabIndex = 6;
            this.radioButtonTagCaptionValue.Text = "Значение";
            this.radioButtonTagCaptionValue.UseVisualStyleBackColor = true;
            this.radioButtonTagCaptionValue.CheckedChanged += new System.EventHandler(this.radioButtonTagCaptionValue_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCaptoin);
            this.groupBox1.Controls.Add(this.checkBoxGridVisible);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид осей";
            // 
            // checkBoxCaptoin
            // 
            this.checkBoxCaptoin.AutoSize = true;
            this.checkBoxCaptoin.Checked = true;
            this.checkBoxCaptoin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCaptoin.Location = new System.Drawing.Point(6, 42);
            this.checkBoxCaptoin.Name = "checkBoxCaptoin";
            this.checkBoxCaptoin.Size = new System.Drawing.Size(97, 17);
            this.checkBoxCaptoin.TabIndex = 1;
            this.checkBoxCaptoin.Text = "Подписи осей";
            this.checkBoxCaptoin.UseVisualStyleBackColor = true;
            this.checkBoxCaptoin.CheckedChanged += new System.EventHandler(this.checkBoxCaptoin_CheckedChanged);
            // 
            // checkBoxGridVisible
            // 
            this.checkBoxGridVisible.AutoSize = true;
            this.checkBoxGridVisible.Checked = true;
            this.checkBoxGridVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGridVisible.Location = new System.Drawing.Point(6, 19);
            this.checkBoxGridVisible.Name = "checkBoxGridVisible";
            this.checkBoxGridVisible.Size = new System.Drawing.Size(56, 17);
            this.checkBoxGridVisible.TabIndex = 0;
            this.checkBoxGridVisible.Text = "Сетка";
            this.checkBoxGridVisible.UseVisualStyleBackColor = true;
            this.checkBoxGridVisible.CheckedChanged += new System.EventHandler(this.checkBoxGridVisible_CheckedChanged);
            // 
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 446);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelChart);
            this.Name = "FormChart";
            this.Text = "FormChart";
            ((System.ComponentModel.ISupportInitialize)(this.chartVis)).EndInit();
            this.panelChart.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVis;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox checkBoxGridVisible;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxCaptoin;
        private System.Windows.Forms.CheckBox checkBoxTags;
        private System.Windows.Forms.RadioButton radioButtonTagCaptionValue;
        private System.Windows.Forms.RadioButton radioButtonTagCaptionNumber;
        private System.Windows.Forms.RadioButton radioButtonTagCaptionNone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownLineWidth;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}