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
    public partial class frmRentalItem : Form
    {
        #region Member Variables

        long _PKID = 0, _RentalID = 0;
        DataTable _dtbRentalItems = null;
        bool _isNew = false;

        #endregion

        #region Constructors

        /// <summary>
        /// This constructor is to create a NEW Rental item and it requires the RentalID (foreign key) so that this NEW
        /// Rental Item will know its parent record in the Rental Table. Since we already have a Constructor that accepts a parameter of type long, 
        /// in this constructor we will accept a parameter of type string.
        /// </summary>
        public frmRentalItem(string RentalId)
        {
            _isNew = true;
            _RentalID = long.Parse(RentalId);
            InitializeComponent();
            InitializeDataTable();

        }
        /// <summary>
        /// This Constructor will open an existing Rental Item based on the PkID parameter.
        /// </summary>
        public frmRentalItem(long PKID)
        {
            InitializeComponent();
            _PKID = PKID;
            InitializeDataTable();
        }

        #endregion

        #region Button Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isNew)
            {
                // This block of code is a hack to make sure that the Validate event of the textbox txtRentalId will trigger and
                // subsiquently will store the value of the txtRentalId in the DataTable _dtbRentalItems
                txtRentalID.Focus();
                txtRentalID.Text = _RentalID.ToString();
                btnSave.Focus();
            }
            _dtbRentalItems.Rows[0].EndEdit();
            Context.SaveDatabaseTable(_dtbRentalItems);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Form Events

        private void frmRentalItem_Paint(object sender, PaintEventArgs e)
        {
            // read the new colour selected and apply it to this form's back color
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmRentalItem_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
            BindControls();
            if (_isNew)
                txtRentalID.Text = _RentalID.ToString();
        }

        #endregion

        #region Helper Methods

        private void InitializeDataTable()
        {
            string sql = $"SELECT * FROM {RentalItemSchema.TableName} WHERE {RentalItemSchema.ColumnRentalId} = {_PKID}";
            _dtbRentalItems = Context.GetDataTable(sql, RentalItemSchema.TableName);

            if (_isNew)
            {
                DataRow row = _dtbRentalItems.NewRow();
                _dtbRentalItems.Rows.Add(row);
            }
        }

        private void BindControls()
        {
            txtRentalID.DataBindings.Add("Text", _dtbRentalItems, RentalItemSchema.ColumnRentalId);
            cboTools.DataBindings.Add("SelectedValue", _dtbRentalItems, RentalItemSchema.ColumnToolId);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PopulateComboBox()
        {
            DataTable toolsDataTable = new DataTable();
            toolsDataTable = Context.GetDataTable(ToolsSchema.TableName);
            // Create a temporary column that combines the ToolName and ToolBrand for the combobox DisplayMember
            var displayNameColumn = "DisplayName";
            toolsDataTable.Columns.Add(displayNameColumn, typeof(string), $"{ToolsSchema.ColumnToolName} + ' (' + {ToolsSchema.ColumnToolBrand} + ')'");
            cboTools.ValueMember = ToolsSchema.ColumnToolId;
            cboTools.DisplayMember = displayNameColumn;
            cboTools.DataSource = toolsDataTable;
        }

        #endregion




    }
}
