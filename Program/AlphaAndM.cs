using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Coursework
{
    class AlphaAndM
    {
        public List<double> Alpha;
        public List<double> M;
        public List<double> Forecast;
        public double ForecastValue { get { return Forecast[Forecast.Count - 1]; } }
        public AlphaAndM(DataTable dTable, double modify = 0)
        {
            M = CalculateM(dTable, modify);
            Alpha = CalculateAlpha(dTable, modify);
            Forecast = CalculateForecast();
        }
        private List<double> CalculateM(DataTable dTable, double modify)
        {
            List<double> result = new List<double>();
            foreach (DataRow row in dTable.Rows)
            {
                double summSQ = 0;
                for (int col = 1; col < row.ItemArray.Count(); col++)
                //foreach (object elem in row.ItemArray)
                {
                    try
                    {
                        summSQ += Math.Pow(Convert.ToDouble(row.ItemArray[col]) + modify, 2);
                    }
                    catch
                    {
                        MessageBox.Show(
                            "Ошибка расчета M",
                            "Ошибка расчета",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                    }
                }
                result.Add(Math.Sqrt(summSQ));
            }
            return result;
        }
        private List<double> CalculateAlpha(DataTable dTable, double modify)
        {
            List<double> result = new List<double> { 0 };
            for (int row = 1; row < dTable.Rows.Count; row++)
            {
                double summProd = 0;
                for (int col = 1; col < dTable.Columns.Count; col++)
                {
                    try
                    {
                        summProd += (Convert.ToDouble(dTable.Rows[row][col]) + modify) * (Convert.ToDouble(dTable.Rows[0][col]) + modify);
                    }
                    catch
                    {
                        MessageBox.Show(
                            "Ошибка расчета Alpha",
                            "Ошибка расчета",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                        return null;
                    }
                }
                result.Add(Math.Acos(summProd / (M[0] * M[row])));
            }
            return result;
        }
        private List<double> CalculateForecast()
        {
            List<double> result = new List<double> { DataForCalculate.A * M[0] + (1 - DataForCalculate.A) * M.Average() };
            for (int i = 1; i < M.Count; i++)
            {
                result.Add(DataForCalculate.A * M[i] + (1 - DataForCalculate.A) * result[i - 1]);
            }
            result.Add(DataForCalculate.A * result.Average() + (1 - DataForCalculate.A) * result[result.Count - 1]);
            return result;
        }
        public void PrintM(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            dataGrid.Columns.Add("M", "M");
            for (int i = 0; i < M.Count; i++)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells[0].Value = Alpha[i];
            }
        }
    }
}
