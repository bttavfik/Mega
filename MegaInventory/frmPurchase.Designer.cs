namespace MegaInventory
{
    partial class frmPurchase
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewItems = new System.Windows.Forms.Button();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddItemToStock = new System.Windows.Forms.Button();
            this.btnGrandTotal = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.cboPurchaser = new System.Windows.Forms.ComboBox();
            this.cboBuyFrom = new System.Windows.Forms.ComboBox();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAdded = new System.Windows.Forms.Label();
            this.lblSaved = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPRNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewItems);
            this.panel1.Controls.Add(this.btnNewSupplier);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAddItemToStock);
            this.panel1.Controls.Add(this.btnGrandTotal);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.dgvList);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.cboItem);
            this.panel1.Controls.Add(this.cboPurchaser);
            this.panel1.Controls.Add(this.cboBuyFrom);
            this.panel1.Controls.Add(this.cboSupplier);
            this.panel1.Controls.Add(this.dtpPurchaseDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtUnitPrice);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtInvoiceNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblAdded);
            this.panel1.Controls.Add(this.lblSaved);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPRNO);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Khmer OS Siemreap", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 537);
            this.panel1.TabIndex = 1;
            // 
            // btnNewItems
            // 
            this.btnNewItems.Image = global::MegaInventory.Properties.Resources.add_new_document;
            this.btnNewItems.Location = new System.Drawing.Point(741, 37);
            this.btnNewItems.Name = "btnNewItems";
            this.btnNewItems.Size = new System.Drawing.Size(30, 30);
            this.btnNewItems.TabIndex = 9;
            this.btnNewItems.UseVisualStyleBackColor = true;
            this.btnNewItems.Click += new System.EventHandler(this.btnNewItems_Click);
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Image = global::MegaInventory.Properties.Resources.add_new_document;
            this.btnNewSupplier.Location = new System.Drawing.Point(328, 123);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(30, 30);
            this.btnNewSupplier.TabIndex = 9;
            this.btnNewSupplier.UseVisualStyleBackColor = true;
            this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(923, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddItemToStock
            // 
            this.btnAddItemToStock.Image = global::MegaInventory.Properties.Resources.worker_loading_boxes;
            this.btnAddItemToStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItemToStock.Location = new System.Drawing.Point(421, 489);
            this.btnAddItemToStock.Name = "btnAddItemToStock";
            this.btnAddItemToStock.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAddItemToStock.Size = new System.Drawing.Size(165, 35);
            this.btnAddItemToStock.TabIndex = 6;
            this.btnAddItemToStock.Text = "     បញ្ជូលទំនិញទៅក្នុងស្តុក";
            this.btnAddItemToStock.UseVisualStyleBackColor = true;
            this.btnAddItemToStock.Click += new System.EventHandler(this.btnAddItemToStock_Click);
            // 
            // btnGrandTotal
            // 
            this.btnGrandTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrandTotal.ForeColor = System.Drawing.Color.Red;
            this.btnGrandTotal.Location = new System.Drawing.Point(803, 439);
            this.btnGrandTotal.Name = "btnGrandTotal";
            this.btnGrandTotal.Size = new System.Drawing.Size(220, 29);
            this.btnGrandTotal.TabIndex = 6;
            this.btnGrandTotal.Text = "$ 0.0";
            this.btnGrandTotal.UseVisualStyleBackColor = true;
            this.btnGrandTotal.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(803, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(803, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 29);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(923, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 29);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvList.Location = new System.Drawing.Point(421, 141);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.Size = new System.Drawing.Size(602, 292);
            this.dgvList.TabIndex = 5;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            this.dgvList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvList_RowsAdded);
            this.dgvList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvList_RowsRemoved);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Code";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.HeaderText = "UnitPrice";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "Quantity";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 75;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.HeaderText = "Edit";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Text = "Edit";
            this.Column5.UseColumnTextForButtonValue = true;
            this.Column5.Width = 75;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = "Delete";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Text = "Remove";
            this.Column6.UseColumnTextForButtonValue = true;
            this.Column6.Width = 75;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(108, 353);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(250, 80);
            this.txtRemark.TabIndex = 4;
            this.txtRemark.Text = "";
            // 
            // cboItem
            // 
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(421, 37);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(314, 30);
            this.cboItem.TabIndex = 3;
            // 
            // cboPurchaser
            // 
            this.cboPurchaser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPurchaser.FormattingEnabled = true;
            this.cboPurchaser.Location = new System.Drawing.Point(108, 66);
            this.cboPurchaser.Name = "cboPurchaser";
            this.cboPurchaser.Size = new System.Drawing.Size(250, 30);
            this.cboPurchaser.TabIndex = 3;
            // 
            // cboBuyFrom
            // 
            this.cboBuyFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuyFrom.FormattingEnabled = true;
            this.cboBuyFrom.Location = new System.Drawing.Point(108, 296);
            this.cboBuyFrom.Name = "cboBuyFrom";
            this.cboBuyFrom.Size = new System.Drawing.Size(250, 30);
            this.cboBuyFrom.TabIndex = 3;
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(108, 123);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(214, 30);
            this.cboSupplier.TabIndex = 3;
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(108, 9);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(250, 29);
            this.dtpPurchaseDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Purchase date :";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(421, 106);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(350, 29);
            this.txtUnitPrice.TabIndex = 1;
            this.txtUnitPrice.Enter += new System.EventHandler(this.txtUnitPrice_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(424, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Unit Price :";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(803, 37);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(220, 29);
            this.txtQty.TabIndex = 1;
            this.txtQty.Enter += new System.EventHandler(this.txtQty_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(806, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "Quantity :";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(108, 180);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(250, 29);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Supplier :";
            // 
            // lblAdded
            // 
            this.lblAdded.AutoSize = true;
            this.lblAdded.Image = global::MegaInventory.Properties.Resources._checked;
            this.lblAdded.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAdded.Location = new System.Drawing.Point(425, 464);
            this.lblAdded.Name = "lblAdded";
            this.lblAdded.Size = new System.Drawing.Size(64, 22);
            this.lblAdded.TabIndex = 0;
            this.lblAdded.Text = "     Added";
            // 
            // lblSaved
            // 
            this.lblSaved.AutoSize = true;
            this.lblSaved.Image = global::MegaInventory.Properties.Resources._checked;
            this.lblSaved.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSaved.Location = new System.Drawing.Point(710, 498);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(62, 22);
            this.lblSaved.TabIndex = 0;
            this.lblSaved.Text = "     Saved";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(718, 442);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 22);
            this.label13.TabIndex = 0;
            this.label13.Text = "Grand Total :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(424, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Select items :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "PR No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Invoice no :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Image = global::MegaInventory.Properties.Resources.creative;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Location = new System.Drawing.Point(19, 500);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(363, 22);
            this.label15.TabIndex = 0;
            this.label15.Text = "     ព័តមានទាំងអស់នឹងមិនអនុញ្ញាតិអោយ កែ ឬលុប បន្ទាប់ពីចុចប៊ូតុង Save";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Image = global::MegaInventory.Properties.Resources.creative;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(19, 466);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(246, 22);
            this.label14.TabIndex = 0;
            this.label14.Text = "     សួមពិនិត្យឡើងវិញ រាល់ទិន្ន័យដែលបានបញ្ជូល";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Remark :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Buy from :";
            // 
            // txtPRNO
            // 
            this.txtPRNO.Location = new System.Drawing.Point(108, 238);
            this.txtPRNO.Name = "txtPRNO";
            this.txtPRNO.Size = new System.Drawing.Size(250, 29);
            this.txtPRNO.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchaser :";
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 561);
            this.Controls.Add(this.panel1);
            this.Name = "frmPurchase";
            this.Text = "Purchase Items";
            this.Load += new System.EventHandler(this.frmPurchase_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.ComboBox cboPurchaser;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPRNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBuyFrom;
        private System.Windows.Forms.Button btnAddItemToStock;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNewItems;
        private System.Windows.Forms.Button btnGrandTotal;
        private System.Windows.Forms.Label lblSaved;
        private System.Windows.Forms.Label lblAdded;
    }
}