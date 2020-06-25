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
    public partial class frmCustomerList : Form
    {
        private int _PKID;
        private DataTable _customersTable;

        public frmCustomerList()
        {
            InitializeComponent();
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            string sqlQuery = $"SELECT {CustomerSchema.ColumnCustomerId}, {CustomerSchema.ColumnCustomerName}, {CustomerSchema.ColumnCustomerPhone} " +
                              $"FROM {CustomerSchema.TableName}";

            _customersTable = Context.GetDataTable(sqlQuery, CustomerSchema.TableName);
            dgvCustomers.DataSource = _customersTable;
        }

        private void btnAdd_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmCustomer();
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCustomerList_Paint(object sender, PaintEventArgs e)
        {
            // read the new colour selected and apply it to this form's back color
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       private void btnDeleteItem_Click(object sender, EventArgs e)
            {
            if (MessageBox.Show("Are you sure you want to delete the item?", Properties.Settings.Default.ProjectName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                 try
                    {
                        long PKID = long.Parse(dgvCustomers[0, dgvCustomers.CurrentCell.RowIndex].Value.ToString());

                        // use the delete record method of the context class and pass the primary key value to delete
                        Context.DeleteRecord(CustomerSchema.TableName, CustomerSchema.ColumnCustomerId, PKID.ToString());
                        PopulateGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No records exists.", Properties.Settings.Default.ProjectName);
                    }
                }
            }
        }
    }

