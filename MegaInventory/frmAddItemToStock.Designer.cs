namespace MegaInventory
{
    partial class frmAddItemToStock
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
            this.lblSaved = new System.Windows.Forms.Label();
            this.lsbAddedItems = new System.Windows.Forms.ListBox();
            this.lsbPurchasedItems = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnMultiBackward = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSingleBackward = new System.Windows.Forms.Button();
            this.btnMultiForward = new System.Windows.Forms.Button();
            this.btnSingleForward = new System.Windows.Forms.Button();
            this.lblQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSaved);
            this.panel1.Controls.Add(this.lsbAddedItems);
            this.panel1.Controls.Add(this.lsbPurchasedItems);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.btnMultiBackward);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSingleBackward);
            this.panel1.Controls.Add(this.btnMultiForward);
            this.panel1.Controls.Add(this.btnSingleForward);
            this.panel1.Controls.Add(this.lblQty);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Khmer OS Siemreap", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 381);
            this.panel1.TabIndex = 0;
            // 
            // lblSaved
            // 
            this.lblSaved.AutoSize = true;
            this.lblSaved.Image = global::MegaInventory.Properties.Resources._checked;
            this.lblSaved.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSaved.Location = new System.Drawing.Point(284, 347);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(62, 22);
            this.lblSaved.TabIndex = 7;
            this.lblSaved.Text = "     Saved";
            // 
            // lsbAddedItems
            // 
            this.lsbAddedItems.FormattingEnabled = true;
            this.lsbAddedItems.ItemHeight = 22;
            this.lsbAddedItems.Location = new System.Drawing.Point(392, 44);
            this.lsbAddedItems.Name = "lsbAddedItems";
            this.lsbAddedItems.Size = new System.Drawing.Size(230, 290);
            this.lsbAddedItems.TabIndex = 6;
            // 
            // lsbPurchasedItems
            // 
            this.lsbPurchasedItems.FormattingEnabled = true;
            this.lsbPurchasedItems.ItemHeight = 22;
            this.lsbPurchasedItems.Location = new System.Drawing.Point(12, 44);
            this.lsbPurchasedItems.Name = "lsbPurchasedItems";
            this.lsbPurchasedItems.Size = new System.Drawing.Size(230, 290);
            this.lsbPurchasedItems.TabIndex = 6;
            this.lsbPurchasedItems.SelectedIndexChanged += new System.EventHandler(this.lsbPurchasedItems_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Image = global::MegaInventory.Properties.Resources.creative;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Location = new System.Drawing.Point(12, 347);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(214, 22);
            this.label15.TabIndex = 4;
            this.label15.Text = "     សួមពិនិត្យឲ្យបានច្បាស់ មុននឹង រក្សាទុក";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(262, 101);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(111, 29);
            this.txtQty.TabIndex = 3;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMultiBackward
            // 
            this.btnMultiBackward.Location = new System.Drawing.Point(261, 243);
            this.btnMultiBackward.Name = "btnMultiBackward";
            this.btnMultiBackward.Size = new System.Drawing.Size(51, 30);
            this.btnMultiBackward.TabIndex = 2;
            this.btnMultiBackward.Text = "<<";
            this.btnMultiBackward.UseVisualStyleBackColor = true;
            this.btnMultiBackward.Click += new System.EventHandler(this.btnMultipleBackward_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(392, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(522, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSingleBackward
            // 
            this.btnSingleBackward.Location = new System.Drawing.Point(261, 153);
            this.btnSingleBackward.Name = "btnSingleBackward";
            this.btnSingleBackward.Size = new System.Drawing.Size(51, 30);
            this.btnSingleBackward.TabIndex = 2;
            this.btnSingleBackward.Text = "<";
            this.btnSingleBackward.UseVisualStyleBackColor = true;
            this.btnSingleBackward.Click += new System.EventHandler(this.btnSingleBackward_Click);
            // 
            // btnMultiForward
            // 
            this.btnMultiForward.Location = new System.Drawing.Point(325, 243);
            this.btnMultiForward.Name = "btnMultiForward";
            this.btnMultiForward.Size = new System.Drawing.Size(48, 30);
            this.btnMultiForward.TabIndex = 2;
            this.btnMultiForward.Text = ">>";
            this.btnMultiForward.UseVisualStyleBackColor = true;
            this.btnMultiForward.Click += new System.EventHandler(this.btnMultipleForward_Click);
            // 
            // btnSingleForward
            // 
            this.btnSingleForward.Location = new System.Drawing.Point(325, 153);
            this.btnSingleForward.Name = "btnSingleForward";
            this.btnSingleForward.Size = new System.Drawing.Size(48, 30);
            this.btnSingleForward.TabIndex = 2;
            this.btnSingleForward.Text = ">";
            this.btnSingleForward.UseVisualStyleBackColor = true;
            this.btnSingleForward.Click += new System.EventHandler(this.btnSingleForward_Click);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(292, 76);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(53, 22);
            this.lblQty.TabIndex = 1;
            this.lblQty.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Khmer OS Siemreap", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(395, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Added to stock";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS Siemreap", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Purchased items";
            // 
            // frmAddItemToStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 381);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddItemToStock";
            this.Text = "Add item to stock";
            this.Load += new System.EventHandler(this.frmAddItemToStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnMultiBackward;
        private System.Windows.Forms.Button btnSingleBackward;
        private System.Windows.Forms.Button btnMultiForward;
        private System.Windows.Forms.Button btnSingleForward;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox lsbAddedItems;
        private System.Windows.Forms.ListBox lsbPurchasedItems;
        private System.Windows.Forms.Label lblSaved;
    }
}