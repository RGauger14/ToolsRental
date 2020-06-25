namespace ToolRentals
{
    partial class frmToolList
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
            this.linkAdd = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTools = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTools)).BeginInit();
            this.SuspendLayout();
            // 
            // linkAdd
            // 
            this.linkAdd.AutoSize = true;
            this.linkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAdd.Location = new System.Drawing.Point(16, 31);
            this.linkAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkAdd.Name = "linkAdd";
            this.linkAdd.Size = new System.Drawing.Size(144, 24);
            this.linkAdd.TabIndex = 0;
            this.linkAdd.TabStop = true;
            this.linkAdd.Text = "Add New Tool";
            this.linkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAdd_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tool List";
            // 
            // dgvTools
            // 
            this.dgvTools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTools.Location = new System.Drawing.Point(11, 57);
            this.dgvTools.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTools.Name = "dgvTools";
            this.dgvTools.RowTemplate.Height = 28;
            this.dgvTools.Size = new System.Drawing.Size(442, 326);
            this.dgvTools.TabIndex = 2;
            this.dgvTools.DoubleClick += new System.EventHandler(this.dgvTools_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(394, 387);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmToolList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(466, 418);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvTools);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmToolList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool List";
            this.Load += new System.EventHandler(this.frmToolList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmToolList_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTools)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTools;
        private System.Windows.Forms.Button btnClose;
    }
}