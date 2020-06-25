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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeColour_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // sace the colour selected by the user into the colorTheme
                Properties.Settings.Default.ColorTheme = colorDialog.Color;
                Properties.Settings.Default.Save();
                // read the new colour selected and apply it to this form's back color
                this.BackColor = Properties.Settings.Default.ColorTheme;
            }
        }


        private void frmSettings_Paint(object sender, PaintEventArgs e)
        {
            // read the new colour selected and apply it to this form's back color
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }
    }
}
