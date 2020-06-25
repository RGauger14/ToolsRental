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
	public partial class frmTool : Form
	{
		#region Member Variables

		private long _pkId = 0;
		private DataTable _toolTable = null;
		private bool _isNew = false;

		#endregion Member Variables

		#region Constructors

		// Constructor for createing a new tool

		public frmTool()
		{
			InitializeComponent();
			_isNew = true;
			SetupForm();
		}

		// Constructor for updating existing record
		public frmTool(long pkId)
		{
			InitializeComponent();
			_pkId = pkId;
			SetupForm();
		}

		private void SetupForm()
		{
			InitializeDataTable();
			BindControls();
		}

		#endregion Constructors

		#region Form Events

		private void frmTool_Paint(object sender, PaintEventArgs e)
		{
			// read the new colour selected and apply it to this form's back color
			this.BackColor = Properties.Settings.Default.ColorTheme;
		}

		#endregion Form Events

		#region Helper Methods

		/// <summary>
		/// This method will iniatialize the DataTable that we will use in binding this form.
		/// The data of the table will come from SQL server.
		/// </summary>

		private void InitializeDataTable()
		{
			string sqlQuery = $"SELECT * FROM {ToolsSchema.TableName} WHERE {ToolsSchema.ColumnToolId} = {_pkId}";

			// Get an existing tool record based on the _pkId and the data table will be updatealbe
			_toolTable = Context.GetDataTable(sqlQuery, ToolsSchema.TableName);
			_toolTable.Columns[ToolsSchema.ColumnToolActive].DefaultValue = 1;
			// Check if is new records
			if (_isNew)
			{
				DataRow row = _toolTable.NewRow();
				_toolTable.Rows.Add(row);
			}
		}

		private void BindControls()
		{
			// Binding the Textboc txtToolId with th e_tooltable and mapping it to the database field
			// called 'ToolId' and using the 'Text' property of the Textbox to display the value
			txtToolID.DataBindings.Add("Text", _toolTable, ToolsSchema.ColumnToolId);
			txtToolName.DataBindings.Add("Text", _toolTable, ToolsSchema.ColumnToolName);
			txtToolBrand.DataBindings.Add("Text", _toolTable, ToolsSchema.ColumnToolBrand);
			//chkbxIsActive.DataBindings.Add("Checked", _toolTable, ToolsSchema.ColumnToolActive);
			chkbxIsActive.DataBindings.Add("Checked", _toolTable, ToolsSchema.ColumnToolActive, false, DataSourceUpdateMode.OnPropertyChanged, CheckState.Indeterminate);
		}


		#endregion Helper Methods

		//This is the close button ryan, move it to where is approprate
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// Alwats do the EndEdit, otherwise the data will not persist
			_toolTable.Rows[0].EndEdit();
			// Call the save method of the Context class to save the changes to the database
			Context.SaveDatabaseTable(_toolTable);
		}

        private void frmTool_Load(object sender, EventArgs e)
        {

        }
    }
}