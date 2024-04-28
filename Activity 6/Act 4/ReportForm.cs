using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;
using OfficeOpenXml;

namespace Act_4
{
    public partial class ReportForm : Form
    {
        private ReportGenerator myreportGenerator;

        public ReportForm()
        {
            InitializeComponent();
            myreportGenerator = new ReportGenerator("localhost", "event", "root", "Clang");
        }

        private void LoadData()
        {
            string query = "SELECT * FROM itinerary"; // Corrected SQL query
            DataTable dt = myreportGenerator.ExecuteQuery(query);
            if (dt != null)
            {
                myDataGrid.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Unable to load data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string reportContent = GenerateReport();
            MessageBox.Show(reportContent, "Generated Report");
        }

        private string GenerateReport()
        {
            // Implement your report generation logic here
            string report = "Report generated on " + DateTime.Now + "\n";
            report += "-------------------------------------\n";
            report += "Report content goes here.\n";
            report += "-------------------------------------\n";

            return report;
        }

        private void exporttoexcel_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(myDataGrid);
        }

        private void ExportDataGridViewToExcel(DataGridView dgv)
        {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel is not properly installed!");
                return;
            }

            excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Column Header
            for (int i = 1; i < dgv.Columns.Count + 1; i++)
            {
                workSheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }

            // For each row and column, write the data to the Excel sheet
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    var value = dgv.Rows[i].Cells[j].Value;
                    workSheet.Cells[i + 2, j + 1] = (value != null) ? value.ToString() : "";
                }
            }

            // Make Excel visible to the user
            excelApp.Visible = true;

            // Cleanup
            Marshal.ReleaseComObject(workSheet);
            Marshal.ReleaseComObject(excelApp.Workbooks);
            Marshal.ReleaseComObject(excelApp);
        }
    }
}