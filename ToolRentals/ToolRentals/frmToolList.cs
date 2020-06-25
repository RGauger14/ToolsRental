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
    public partial class frmToolList : Form
    {
        public frmToolList()
        {
            InitializeComponent();
        }

        private void frmToolList_Paint(object sender, PaintEventArgs e)
        {
            // read the new colour selected and apply it to this form's back color
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmToolList_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            DataTable dtb = new DataTable();
            dtb = Context.GetDataTable("Tools"); 

            dgvTools.DataSource = dtb;
        }

        private void dgvTools_DoubleClick(object sender, EventArgs e)
        {
            // if no current row or cell selected, do nothing
            if (dgvTools.CurrentCell == null) return;

            // Get the primary key id of the selected row which is in column 0
            long pkId = long.Parse(dgvTools[0, dgvTools.CurrentCell.RowIndex].Value.ToString());

            frmTool frm = new frmTool(pkId);

            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        private void linkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTool frm = new frmTool();
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }
    }
}
