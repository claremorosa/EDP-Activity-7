using OfficeOpenXml;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;



namespace Act_4
{
    public partial class Report : Form
    {
        
        private string server = "localhost";
        private string database = "event";
        private string uid = "root";
        private string password = "Clang";

        private string myConnectionString = "Server=127.0.0.1;Port=3386;Database=event;User=root;Password=Clang;";



        public Report()
        {
            InitializeComponent();
            // Set the LicenseContext property before using EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
             myConnectionString = "Server=127.0.0.1;Port=3386;Database=event;User=root;Password=Clang;";

    }

        private void btnexporttoexcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
                openFileDialog.Title = "Select Template Excel File";
                openFileDialog.InitialDirectory = @"C:\Documents";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string templateFilePath = openFileDialog.FileName;

                    // Load the selected Excel template
                    FileInfo templateFile = new FileInfo(templateFilePath);
                    using (ExcelPackage excelPackage = new ExcelPackage(templateFile))
                    {
                        // Access the worksheet in the Excel template
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault(sheet => sheet.Name == "Activities");

                        // Check if worksheet exists
                        if (worksheet != null)
                        {
                            // Set the starting cell where you want to write the data
                            int startRow = 11; // Start from row 11
                            int startColumn = 1; // Start from column A

                            // Fill in the data from the DataGridView into specific cells in the Excel worksheet
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                DataGridViewRow dataGridViewRow = dataGridView1.Rows[i];
                                for (int j = 0; j < dataGridViewRow.Cells.Count; j++)
                                {
                                    DataGridViewCell dataGridViewCell = dataGridViewRow.Cells[j];
                                    if (dataGridViewCell.Value != null)
                                    {
                                        worksheet.Cells[startRow + i, startColumn + j].Value = dataGridViewCell.Value.ToString();
                                    }
                                }
                            }

                            // Create a new worksheet for the graph
                            ExcelWorksheet graphWorksheet = excelPackage.Workbook.Worksheets.Add("Graph");

                            // Define the range of data for the chart
                            // Define the range of data for the chart
                            ExcelRange dataRangeY = worksheet.Cells[startRow, startColumn + 1, startRow + dataGridView1.Rows.Count - 1, startColumn + 1]; // Column B
                            ExcelRange dataRangeX = worksheet.Cells[startRow, startColumn + 3, startRow + dataGridView1.Rows.Count - 1, startColumn + 3]; // Column D

                            // Create a new chart
                            var chart = graphWorksheet.Drawings.AddChart("Chart1", OfficeOpenXml.Drawing.Chart.eChartType.BarClustered);

                            // Set the title for the chart
                            chart.Title.Text = "Activities";

                            // Add data to the chart
                            var seriesY = chart.Series.Add(dataRangeY.Offset(1, 0), dataRangeY.Offset(1, 0));
                            var seriesX = chart.Series.Add(dataRangeX.Offset(1, 0), dataRangeX.Offset(1, 0));

                            // Set axis titles
                            chart.YAxis.Title.Text = "Cost";
                            chart.XAxis.Title.Text = "Name";

                            // Set the position of the chart
                            chart.SetPosition(1, 0, 4, 0);
                            chart.SetSize(800, 400);


                            // Show SaveFileDialog to allow the user to specify the output file path
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
                            saveFileDialog.Title = "Save Output Excel File";
                            saveFileDialog.InitialDirectory = @"C:\Documents"; // Default to the same directory
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string outputFile = saveFileDialog.FileName;

                                // Save the modified Excel file with the specified output file path
                                excelPackage.SaveAs(new FileInfo(outputFile));
                                MessageBox.Show("Data exported to Excel successfully.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sheet 'Activities' not found in the selected Excel file.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error exporting data to Excel: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDisplayData_Click(object sender, EventArgs e)
        {
            DisplayDataFromDatabase();
        }

        private void DisplayDataFromDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnectionString))
                {
                    
                    connection.Open();
                    string query = "SELECT * FROM activities";
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                        {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data from the database: " + ex.Message);
            }
        }
    }



}

