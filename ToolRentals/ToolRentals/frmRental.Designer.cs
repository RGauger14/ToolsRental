namespace ToolRentals
{
    partial class frmRental
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
            this.txtRentalID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.dtpDateRented = new System.Windows.Forms.DateTimePicker();
            this.dtpDateReturned = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.gbxItems = new System.Windows.Forms.GroupBox();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnInsertItem = new System.Windows.Forms.Button();
            this.dgvRentalItems = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.gbxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRentalID
            // 
            this.txtRentalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRentalID.Location = new System.Drawing.Point(145, 40);
            this.txtRentalID.Margin = new System.Windows.Forms.Padding(2);
            this.txtRentalID.Name = "txtRentalID";
            this.txtRentalID.ReadOnly = true;
            this.txtRentalID.Size = new System.Drawing.Size(107, 22);
            this.txtRentalID.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Rental ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Rental";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Customer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Date Rented:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(145, 75);
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(239, 24);
            this.cboCustomer.TabIndex = 14;
            // 
            // dtpDateRented
            // 
            this.dtpDateRented.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateRented.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateRented.Location = new System.Drawing.Point(145, 111);
            this.dtpDateRented.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateRented.Name = "dtpDateRented";
            this.dtpDateRented.Size = new System.Drawing.Size(132, 22);
            this.dtpDateRented.TabIndex = 15;
            // 
            // dtpDateReturned
            // 
            this.dtpDateReturned.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateReturned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateReturned.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateReturned.Location = new System.Drawing.Point(145, 147);
            this.dtpDateReturned.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateReturned.Name = "dtpDateReturned";
            this.dtpDateReturned.Size = new System.Drawing.Size(132, 22);
            this.dtpDateReturned.TabIndex = 17;
            this.dtpDateReturned.ValueChanged += new System.EventHandler(this.dtpDateReturned_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Date Returned:";
            // 
            // gbxItems
            // 
            this.gbxItems.Controls.Add(this.btnDeleteItem);
            this.gbxItems.Controls.Add(this.btnInsertItem);
            this.gbxItems.Controls.Add(this.dgvRentalItems);
            this.gbxItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxItems.Location = new System.Drawing.Point(12, 181);
            this.gbxItems.Margin = new System.Windows.Forms.Padding(2);
            this.gbxItems.Name = "gbxItems";
            this.gbxItems.Padding = new System.Windows.Forms.Padding(2);
            this.gbxItems.Size = new System.Drawing.Size(372, 247);
            this.gbxItems.TabIndex = 18;
            this.gbxItems.TabStop = false;
            this.gbxItems.Text = "Rental Items";
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.Location = new System.Drawing.Point(106, 215);
            this.btnDeleteItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(98, 25);
            this.btnDeleteItem.TabIndex = 22;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnInsertItem
            // 
            this.btnInsertItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertItem.Location = new System.Drawing.Point(4, 215);
            this.btnInsertItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsertItem.Name = "btnInsertItem";
            this.btnInsertItem.Size = new System.Drawing.Size(98, 25);
            this.btnInsertItem.TabIndex = 21;
            this.btnInsertItem.Text = "Insert Item";
            this.btnInsertItem.UseVisualStyleBackColor = true;
            this.btnInsertItem.Click += new System.EventHandler(this.btnInsertItem_Click);
            // 
            // dgvRentalItems
            // 
            this.dgvRentalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRentalItems.Location = new System.Drawing.Point(2, 17);
            this.dgvRentalItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRentalItems.Name = "dgvRentalItems";
            this.dgvRentalItems.RowTemplate.Height = 28;
            this.dgvRentalItems.Size = new System.Drawing.Size(368, 194);
            this.dgvRentalItems.TabIndex = 0;
            this.dgvRentalItems.DoubleClick += new System.EventHandler(this.dgvRentalItems_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(180, 452);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 25);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(281, 452);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 25);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(286, 111);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(98, 58);
            this.btnCreate.TabIndex = 22;
            this.btnCreate.Text = "Create Rental";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 488);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbxItems);
            this.Controls.Add(this.dtpDateReturned);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDateRented);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRentalID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmRental";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rental";
            this.Load += new System.EventHandler(this.frmRental_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRental_Paint);
            this.gbxItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRentalID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.DateTimePicker dtpDateRented;
        private System.Windows.Forms.DateTimePicker dtpDateReturned;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbxItems;
        private System.Windows.Forms.DataGridView dgvRentalItems;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnInsertItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreate;
    }
}