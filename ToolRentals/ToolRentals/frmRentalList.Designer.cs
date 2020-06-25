namespace ToolRentals
{
    partial class frmRentalList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.linkAdd = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(383, 375);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvRentals
            // 
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentals.Location = new System.Drawing.Point(11, 66);
            this.dgvRentals.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.RowTemplate.Height = 28;
            this.dgvRentals.Size = new System.Drawing.Size(445, 305);
            this.dgvRentals.TabIndex = 10;
            this.dgvRentals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRentals_CellContentClick);
            this.dgvRentals.DoubleClick += new System.EventHandler(this.dgvRentals_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Rental List";
            // 
            // linkAdd
            // 
            this.linkAdd.AutoSize = true;
            this.linkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAdd.Location = new System.Drawing.Point(11, 44);
            this.linkAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkAdd.Name = "linkAdd";
            this.linkAdd.Size = new System.Drawing.Size(138, 20);
            this.linkAdd.TabIndex = 8;
            this.linkAdd.TabStop = true;
            this.linkAdd.Text = "Add New Rental";
            this.linkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAdd_LinkClicked);
            // 
            // frmRentalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 415);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvRentals);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmRentalList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rental List";
            this.Load += new System.EventHandler(this.frmRentalList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRentalList_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkAdd;
    }
}