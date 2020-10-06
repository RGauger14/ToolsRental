using Controller;
using Controller.Schemas;
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
    public partial class frmCustomer : Form
    {
        private int _PKID;
        private DataTable _customerItems;
        private bool _isNew;

        public frmCustomer()
        {
            InitializeComponent();
            btnSave.Text = "Add";
            _isNew = true;
            InitializeDataTable();
        }

        public frmCustomer(int customerId)
        {
            InitializeComponent();
            _PKID = customerId;
            InitializeDataTable();
        }

        private void InitializeDataTable()
        {
            string sql = $"SELECT * FROM {CustomerSchema.TableName} WHERE {CustomerSchema.ColumnCustomerId} = {_PKID}";
            _customerItems = Context.GetDataTable(sql, CustomerSchema.TableName);

            if (_isNew)
            {
                DataRow row = _customerItems.NewRow();
                _customerItems.Rows.Add(row);
            }
        }

        private void BindControls()
        {
            txtCustomerID.DataBindings.Add("Text", _customerItems, CustomerSchema.ColumnCustomerId);
            txtCustomerName.DataBindings.Add("Text", _customerItems, CustomerSchema.ColumnCustomerName);
            txtCustomerPhone.DataBindings.Add("Text", _customerItems, CustomerSchema.ColumnCustomerPhone);
            
        }


        private void frmCustomer_Paint(object sender, PaintEventArgs e)
        {
            // read the new colour selected and apply it to this form's back color
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isNew)
            {
                // This block of code is a hack to make sure that the Validate event of the textbox txtRentalId will trigger and
                // subsiquently will store the value of the txtRentalId in the DataTable _dtbRentalItems
                txtCustomerID.Focus();
                txtCustomerID.Text = _PKID.ToString();
                btnSave.Focus();
            }
            _customerItems.Rows[0].EndEdit();
            Context.SaveDatabaseTable(_customerItems);
            this.Close();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            BindControls();
        }
    }
}
