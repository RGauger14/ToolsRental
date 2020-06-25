using Controller;
using Controller.Schemas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolRentals
{
    public partial class frmReport : Form
    {
        private DataView _dvHistory;

        private string _viewAllQuery = @"
SELECT
    Rental.DateRented AS 'Date Rented',
    Customer.CustomerName AS 'Customer',
    CONCAT(Tools.ToolName, ' (', Tools.ToolBrand, ')') AS 'Tool',
    Rental.DateReturned AS 'Date Returned'
FROM
    Customer
    INNER JOIN Rental ON Rental.CustomerId = Customer.CustomerId
    INNER JOIN RentalItems ON Rental.RentalId = RentalItems.RentalId
    INNER JOIN Tools ON RentalItems.ToolId = Tools.ToolId
ORDER BY
    DateRented DESC
";

        public frmReport()
        {
            InitializeComponent();
            reportDropDown.DataSource = new string[] { "All", "Weekly Returns", "Weekly Rented" };
        }

        private void WeeklyReturnsReport()
        {
            var lastWeekDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"); ;
            var weeklyReturnsQuery = $@"
SELECT Rental.DateRented AS 'Date Rented', Customer.CustomerName AS 'Customer', CONCAT(Tools.ToolName, ' (', Tools.ToolBrand, ')') AS 'Tool', Rental.DateReturned AS 'Date Returned'
FROM Customer INNER JOIN
Rental ON Rental.CustomerId = Customer.CustomerId INNER JOIN
RentalItems ON Rental.RentalId = RentalItems.RentalId INNER JOIN
Tools ON RentalItems.ToolId = Tools.ToolId
WHERE Rental.DateReturned >= '{lastWeekDate}'
ORDER BY DateRented DESC
";
            PopulateGrid(weeklyReturnsQuery);
        }

        private void WeeklyRentedReport()
        {
            var lastWeekDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            var weeklyRentedQuery = $@"
SELECT Rental.DateRented AS 'Date Rented', Customer.CustomerName AS 'Customer', CONCAT(Tools.ToolName, ' (', Tools.ToolBrand, ')') AS 'Tool', Rental.DateReturned AS 'Date Returned'
FROM Customer INNER JOIN
Rental ON Rental.CustomerId = Customer.CustomerId INNER JOIN
RentalItems ON Rental.RentalId = RentalItems.RentalId INNER JOIN
Tools ON RentalItems.ToolId = Tools.ToolId
WHERE Rental.DateRented >= '{lastWeekDate}'
ORDER BY DateRented DESC
";
            PopulateGrid(weeklyRentedQuery);
        }

        private void PopulateGrid()
        {
            PopulateGrid(_viewAllQuery);
        }

        private void PopulateGrid(string sqlQuery)
        {
            DataTable table = Context.GetDataTable(sqlQuery, "Rental History", true);
            _dvHistory = new DataView(table);
            dvgReport.DataSource = _dvHistory;
        }

        private void frmReport_Paint(object sender, PaintEventArgs e)
        {
            // read the new colour selected and apply it to this form's back color
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var filter = $"{CustomerSchema.ColumnCustomerName} LIKE '%{txtSearch.Text}%' " +
                                   $"OR {ToolsSchema.ColumnToolName} LIKE '%{txtSearch.Text}%'";
            _dvHistory.RowFilter = filter;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var csv = new StringBuilder();

            foreach (DataRowView drv in _dvHistory)
            {
                csv.AppendLine(string.Join(
                    ", ",
                    drv["Date Rented"],
                    drv["Customer"],
                    drv["Tool"],
                    drv["Date Rented"])
                );
            }

            var selectedReportName = (string)reportDropDown.SelectedValue;
            selectedReportName = selectedReportName.Trim();
            selectedReportName = selectedReportName.Replace(' ', '-');
            var exportPath = Application.StartupPath + $@"\Tools-Report_{selectedReportName}.csv";
            File.WriteAllText(exportPath, csv.ToString());
            MessageBox.Show($"Exported Completed - {exportPath}", Properties.Settings.Default.ProjectName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var report = (string) reportDropDown.SelectedValue;

            if (report == "All")
            {
                PopulateGrid();
            }

            if (report == "Weekly Returns")
            {
                WeeklyReturnsReport();
            }

            if (report == "Weekly Rented")
            {
                WeeklyRentedReport();
            }
        }
    }
}
