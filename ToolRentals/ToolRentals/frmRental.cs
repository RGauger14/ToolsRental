using Controller;
using Controller.Schemas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolRentals
{
    public partial class frmRental : Form
    {
        #region Member Variables

        long _PKID = 0;
        DataTable _rentalTable = null, _rentalItemsTable = null;
        bool _isNew = false;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for creating a new rental
        /// </summary>
        public frmRental()
        {
            InitializeComponent();
            InitializeNewRental();
        }

        /// <summary>
        /// constructor for exsisting rental
        /// </summary>
        /// <param name="pkId"></param>
        public frmRental(long pkId)
        {
            InitializeComponent();
            initializeExistingRental(pkId);
        }


        #endregion

        #region Form Events
        private void frmRental_Paint(object sender, PaintEventArgs e)
        {
            // read the new colour selected and apply it to this form's back color
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }
        private void frmRental_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
            BindControls();
        }


        #endregion

        #region Button Events
        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            // prompt user to add rental item
            frmRentalItem frm = new frmRentalItem(txtRentalID.Text);
            // update grid if ok
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete the item?", Properties.Settings.Default.ProjectName,MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    long PKID = long.Parse(dgvRentalItems[0, dgvRentalItems.CurrentCell.RowIndex].Value.ToString());

                    // use the delete record method of the context class and pass the primary key value to delete
                    Context.DeleteRecord(RentalItemSchema.TableName, RentalItemSchema.ColumnRentalItemId, PKID.ToString());
                    PopulateGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No records exists.", Properties.Settings.Default.ProjectName);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpDateReturned.Text.Equals(" ") == false)
                _rentalTable.Rows[0][RentalSchema.ColumnDateReturned] = dtpDateReturned.Value.ToString("yyyy-MM-dd");

            // always do EndEdit before saving, otherwise the data willl persist in the database.
            _rentalTable.Rows[0].EndEdit();
            Context.SaveDatabaseTable(_rentalTable);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue == null)
            {
                MessageBox.Show("You need to select a customer.", Properties.Settings.Default.ProjectName);
                return;
            }

            // Before we create a child record, we will force our program to create the parent record based on the 
            // selections the user made in the Customer combobox and Date rented DTP
            if (_isNew && _PKID <= 0)
            {
                string columnNames = $"{RentalSchema.ColumnCustomerId}, {RentalSchema.ColumnDateRented}, {RentalSchema.ColumnDateReturned}";

                // When seeding dates in SQL, we will use a string using the format of 'yyyy-MM-dd'
                string dateRented = dtpDateRented.Value.ToString("yyyy-MM-dd");
                long customerId = long.Parse(cboCustomer.SelectedValue.ToString());

                string columnValues = $"{customerId}, '{dateRented}', null";
                // Push the Parent data to the database using InsertParentTable of the Context class. It
                // will return the primary key ID of the newly created parent record and we will simply store it in the _PKID variable
                _PKID = Context.InsertParentTable("Rental", columnNames, columnValues);
                // Display the _PKID value in the txtRentalId textbox
                txtRentalID.Text = _PKID.ToString();
                // Call the initializeDataTable method again to refresh it using newly created parent record from database
                InitializeDataTable();
                gbxItems.Enabled = true;

            }
        }

            #endregion

            #region Helper Methods
        private void InitializeNewRental()
        {
            _isNew = true;
            InitializeDataTable();
            gbxItems.Enabled = false;
        }

        private void initializeExistingRental(long pkId)
        {
            btnCreate.Visible = false;
            cboCustomer.Enabled = false;
            _PKID = pkId;
            InitializeDataTable();
            gbxItems.Enabled = true;
        }

        private void InitializeDataTable()
        {
            _rentalTable = Context.GetDataTable($"SELECT * FROM Rental WHERE RentalId = {_PKID}", "Rental");
            PopulateGrid();
        }


        private void PopulateGrid()
        {
            string sqlQuery = "SELECT RentalItems.RentalItemId, Tools.ToolName, Tools.ToolBrand, RentalItems.RentalId " +
                              "FROM RentalItems INNER JOIN " +
                              "Tools ON RentalItems.ToolId = Tools.ToolId " +
                              $"WHERE RentalId = {_PKID} " +
                              "ORDER BY RentalItems.RentalItemId DESC";
           
            _rentalItemsTable = Context.GetDataTable(sqlQuery, "RentalItem");
            dgvRentalItems.DataSource = _rentalItemsTable;
        }

        /// <summary>
        /// This method will populate the ComboBoc by calling the GetDataTable of the Context class and pass the 
        /// table name of the source database table.
        /// </summary>

        private void PopulateComboBox()
        {
            // Get all records from our source database table - customer
            DataTable dtb = Context.GetDataTable("Customer");

            // Set the ValueMember. The ValueMember is the name of the primary key field of your source database
            // table. This is the value that will be sorted in the database when a user selects a row from comboboc
            cboCustomer.ValueMember = "CustomerId";

            // Set the Displaymember. The displayMember is the name of the field of your source database tbale
            // that we want to display in the ComboBox.
            cboCustomer.DisplayMember = "CustomerName";

            // Set the data source of the ComboBox by using the DataTable we have created aboue - dtb
            cboCustomer.DataSource = dtb;
        }

        private void dgvRentalItems_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRentalItems.CurrentCell == null) return;

            long pkId = long.Parse(dgvRentalItems[0, dgvRentalItems.CurrentCell.RowIndex].Value.ToString());

            frmRentalItem frm = new frmRentalItem(pkId);
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        private void dtpDateReturned_ValueChanged(object sender, EventArgs e)
        {
            // change the DateReturned format so it doesn't return empty when user change or selected a date
            dtpDateReturned.CustomFormat = "dd/MMM/yyyy";
        }
        /// <summary>
        /// 
        /// </summary>
        private void BindControls()
        {
            txtRentalID.DataBindings.Add("Text", _rentalTable, "RentalId");
            cboCustomer.DataBindings.Add("SelectedValue", _rentalTable, "CustomerId");
            dtpDateRented.DataBindings.Add("Text", _rentalTable, "DateRented");
            dtpDateReturned.DataBindings.Add("Text", _rentalTable, "DateReturned");

            // When creating a NEW Rental, we want to make sure that our Customer ComboBox is empty or nothing is
            // selected and our DateReturned DataTimePicker is also empty.
            if (_isNew)
                cboCustomer.SelectedIndex = -1;

            if (_isNew || string.IsNullOrEmpty(_rentalTable.Rows[0]["DateReturned"].ToString())) ;
            {
                dtpDateReturned.Format = DateTimePickerFormat.Custom;
                dtpDateReturned.CustomFormat = " ";
            }
        }

        #endregion



    }
}
