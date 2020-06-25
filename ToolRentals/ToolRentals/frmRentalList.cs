using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolRentals
{
    public partial class frmRentalList : Form
    {
        private object dgvTools;

        public frmRentalList()
        {
            InitializeComponent();
        }

        private void frmRentalList_Paint(object sender, PaintEventArgs e)
        {
            // read the new colour selected and apply it to this form's back color
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRentalList_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            string sqlQuery = "SELECT Rental.RentalId, Rental.DateRented, Customer.CustomerName, Rental.DateReturned " +
                              "FROM Rental INNER JOIN " +
                              "Customer ON Rental.CustomerId = Customer.CustomerId " +
                              "ORDER BY Rental.RentalId DESC";
          
            DataTable table = Context.GetDataTable(sqlQuery, "Rentals");
            dgvRentals.DataSource = table;
        }

        private void linkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRental frm = new frmRental();
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        private void dgvRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRentals_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRentals.CurrentCell == null) return;

            long PKID = long.Parse(dgvRentals[0, dgvRentals.CurrentCell.RowIndex].Value.ToString());

            frmRental frm = new frmRental(PKID);
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }
    }
}
