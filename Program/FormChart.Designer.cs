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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartVis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.groupBoxSeriesVisible = new System.Windows.Forms.GroupBox();
            this.groupBoxSeriesStyle = new System.Windows.Forms.GroupBox();
            this.comboBoxLinesType = new System.Windows.Forms.ComboBox();
            this.checkBoxTags = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownLineWidth = new System.Windows.Forms.NumericUpDown();
            this.radioButtonTagCaptionNone = new System.Windows.Forms.RadioButton();
            this.radioButtonTagCaptionNumber = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonTagCaptionValue = new System.Windows.Forms.RadioButton();
            this.groupBoxAxesSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxCaptoin = new System.Windows.Forms.CheckBox();
            this.checkBoxGridVisible = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartVis)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.groupBoxSeriesStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineWidth)).BeginInit();
            this.groupBoxAxesSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartVis
            // 
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.Title = "<Имя оси X>";
            chartArea2.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.Title = "<Имя оси Y>";
            chartArea2.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.Name = "ChartArea1";
            this.chartVis.ChartAreas.Add(chartArea2);
            this.chartVis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chartVis.Legends.Add(legend2);
            this.chartVis.Location = new System.Drawing.Point(0, 0);
            this.chartVis.Name = "chartVis";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVis.Series.Add(series2);
            this.chartVis.Size = new System.Drawing.Size(524, 476);
            this.chartVis.TabIndex = 0;
            this.chartVis.Text = "chartVis";
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.groupBoxSeriesVisible);
            this.panelSettings.Controls.Add(this.groupBoxSeriesStyle);
            this.panelSettings.Controls.Add(this.groupBoxAxesSettings);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSettings.Location = new System.Drawing.Point(524, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(140, 476);
            this.panelSettings.TabIndex = 2;
            // 
            // groupBoxSeriesVisible
            // 
            this.groupBoxSeriesVisible.Location = new System.Drawing.Point(5, 303);
            this.groupBoxSeriesVisible.Name = "groupBoxSeriesVisible";
            this.groupBoxSeriesVisible.Size = new System.Drawing.Size(128, 170);
            this.groupBoxSeriesVisible.TabIndex = 10;
            this.groupBoxSeriesVisible.TabStop = false;
            this.groupBoxSeriesVisible.Text = "Графики";
            // 
            // groupBoxSeriesStyle
            // 
            this.groupBoxSeriesStyle.Controls.Add(this.comboBoxLinesType);
            this.groupBoxSeriesStyle.Controls.Add(this.checkBoxTags);
            this.groupBoxSeriesStyle.Controls.Add(this.label2);
            this.groupBoxSeriesStyle.Controls.Add(this.numericUpDownLineWidth);
            this.groupBoxSeriesStyle.Controls.Add(this.radioButtonTagCaptionNone);
            this.groupBoxSeriesStyle.Controls.Add(this.radioButtonTagCaptionNumber);
            this.groupBoxSeriesStyle.Controls.Add(this.label1);
            this.groupBoxSeriesStyle.Controls.Add(this.radioButtonTagCaptionValue);
            this.groupBoxSeriesStyle.Location = new System.Drawing.Point(5, 87);
            this.groupBoxSeriesStyle.Name = "groupBoxSeriesStyle";
            this.groupBoxSeriesStyle.Size = new System.Drawing.Size(128, 210);
            this.groupBoxSeriesStyle.TabIndex = 9;
            this.groupBoxSeriesStyle.TabStop = false;
            this.groupBoxSeriesStyle.Text = "Вид графиков";
            // 
            // comboBoxLinesType
            // 
            this.comboBoxLinesType.FormattingEnabled = true;
            this.comboBoxLinesType.Items.AddRange(new object[] {
            "Плавная линия",
            "Кривая линия"});
            this.comboBoxLinesType.Location = new System.Drawing.Point(6, 19);
            this.comboBoxLinesType.Name = "comboBoxLinesType";
            this.comboBoxLinesType.Size = new System.Drawing.Size(116, 21);
            this.comboBoxLinesType.TabIndex = 11;
            this.comboBoxLinesType.Text = "Плавная линия";
            this.comboBoxLinesType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLinesType_SelectedIndexChanged);
            // 
            // checkBoxTags
            // 
            this.checkBoxTags.AutoSize = true;
            this.checkBoxTags.Location = new System.Drawing.Point(6, 48);
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
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Толщина линий";
            // 
            // numericUpDownLineWidth
            // 
            this.numericUpDownLineWidth.Location = new System.Drawing.Point(6, 88);
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
            this.radioButtonTagCaptionNone.Location = new System.Drawing.Point(6, 134);
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
            this.radioButtonTagCaptionNumber.Location = new System.Drawing.Point(6, 157);
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
            this.label1.Location = new System.Drawing.Point(6, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Подписи меток";
            // 
            // radioButtonTagCaptionValue
            // 
            this.radioButtonTagCaptionValue.AutoSize = true;
            this.radioButtonTagCaptionValue.Location = new System.Drawing.Point(6, 180);
            this.radioButtonTagCaptionValue.Name = "radioButtonTagCaptionValue";
            this.radioButtonTagCaptionValue.Size = new System.Drawing.Size(73, 17);
            this.radioButtonTagCaptionValue.TabIndex = 6;
            this.radioButtonTagCaptionValue.Text = "Значение";
            this.radioButtonTagCaptionValue.UseVisualStyleBackColor = true;
            this.radioButtonTagCaptionValue.CheckedChanged += new System.EventHandler(this.radioButtonTagCaptionValue_CheckedChanged);
            // 
            // groupBoxAxesSettings
            // 
            this.groupBoxAxesSettings.Controls.Add(this.checkBoxCaptoin);
            this.groupBoxAxesSettings.Controls.Add(this.checkBoxGridVisible);
            this.groupBoxAxesSettings.Location = new System.Drawing.Point(5, 8);
            this.groupBoxAxesSettings.Name = "groupBoxAxesSettings";
            this.groupBoxAxesSettings.Size = new System.Drawing.Size(128, 73);
            this.groupBoxAxesSettings.TabIndex = 1;
            this.groupBoxAxesSettings.TabStop = false;
            this.groupBoxAxesSettings.Text = "Вид осей";
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
            this.ClientSize = new System.Drawing.Size(664, 476);
            this.Controls.Add(this.chartVis);
            this.Controls.Add(this.panelSettings);
            this.MinimumSize = new System.Drawing.Size(400, 515);
            this.Name = "FormChart";
            this.Text = "FormChart";
            ((System.ComponentModel.ISupportInitialize)(this.chartVis)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.groupBoxSeriesStyle.ResumeLayout(false);
            this.groupBoxSeriesStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineWidth)).EndInit();
            this.groupBoxAxesSettings.ResumeLayout(false);
            this.groupBoxAxesSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVis;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox checkBoxGridVisible;
        private System.Windows.Forms.GroupBox groupBoxAxesSettings;
        private System.Windows.Forms.CheckBox checkBoxCaptoin;
        private System.Windows.Forms.CheckBox checkBoxTags;
        private System.Windows.Forms.RadioButton radioButtonTagCaptionValue;
        private System.Windows.Forms.RadioButton radioButtonTagCaptionNumber;
        private System.Windows.Forms.RadioButton radioButtonTagCaptionNone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSeriesStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownLineWidth;
        private System.Windows.Forms.GroupBox groupBoxSeriesVisible;
        private System.Windows.Forms.ComboBox comboBoxLinesType;
    }
}