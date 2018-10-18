using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MegaInventory.InventoryModel;
using MegaInventory.Services;

namespace MegaInventory
{
    public partial class frmPurchase : Form
    {
        public bool viewFlag = false;
        public int purchaseId = 0;

        public frmPurchase()
        {
            InitializeComponent();
            MegaService.FormatDataGridView(dgvList);
        }

        private void LoadPurchasers()
        {
            using (var context = new MegaEntities())
            {
                cboPurchaser.DataSource = context.Employees.Where(i => i.IsActive).ToList();
                cboPurchaser.DisplayMember = "EmployeeNameKh";
                cboPurchaser.ValueMember = "Code";
            }
        }

        private void LoadBuyFrom()
        {
            cboBuyFrom.Items.Add("Int");
            cboBuyFrom.Items.Add("Ext");
        }

        private void LoadItems()
        {
            using (var context = new MegaEntities())
            {
                cboItem.DataSource = context.Items.Where(i => i.IsActive).ToList();
                cboItem.DisplayMember = "Description";
                cboItem.ValueMember = "Code";
            }
        }

        private void LoadSuppliers()
        {
            using (var context = new MegaEntities())
            {
                cboSupplier.DataSource = context.Suppliers.Where(s => s.IsActive).ToList();
                cboSupplier.DisplayMember = "Description";
                cboSupplier.ValueMember = "Id";
            }
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier frmSup = new frmSupplier();
            frmSup.ShowDialog();
            LoadSuppliers();
        }


        private void GenerateRowNo()
        {
            int no = 1;

            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                dgvList.Rows[i].Cells[0].Value = no++;
            }
        }

        private void ClearItem()
        {
            txtQty.Clear();
            txtUnitPrice.Clear();
            cboItem.SelectedIndex = -1;
            cboItem.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(isEdit)
            {
                if (editInd > 0) return;
                dgvList.Rows[editInd].Cells[1].Value = cboItem.SelectedValue;
                dgvList.Rows[editInd].Cells[2].Value = cboItem.Text;
                dgvList.Rows[editInd].Cells[3].Value = txtUnitPrice.Text;
                dgvList.Rows[editInd].Cells[4].Value = txtQty.Text;
                isEdit = false;
                editInd = -1;
                ClearItem();
                return;
            }

            using (var context = new MegaEntities())
            {
                var item = context.Items.Find(cboItem.SelectedValue.ToString());
                dgvList.Rows.Add("", item.Code, item.Description, txtUnitPrice.Text, txtQty.Text);
                GenerateRowNo();
                ClearItem();
            }
        }
        
        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new MegaEntities())
            {
                var item = context.Items.Find(cboItem.SelectedValue);
                if(item != null)
                {
                    decimal currentPrice = 0;
                    decimal.TryParse(item.CurrentPrice + "", out currentPrice);
                    txtUnitPrice.Text = currentPrice.ToString();
                }
            }
        }

        bool isEdit = false;
        int editInd = -1;
        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (viewFlag) return;

            int colInd = dgvList.CurrentCell.ColumnIndex;

            if (dgvList.Columns[colInd].HeaderText == "Delete")
            {
                dgvList.Rows.RemoveAt(dgvList.CurrentRow.Index);
                GenerateRowNo();
            }
            else if(dgvList.Columns[colInd].HeaderText == "Edit")
            {
                isEdit = true;
                editInd = dgvList.CurrentRow.Index;

                cboItem.SelectedValue = dgvList.CurrentRow.Cells[1].Value.ToString();
                txtUnitPrice.Text = dgvList.CurrentRow.Cells[3].Value.ToString();
                txtQty.Text = dgvList.CurrentRow.Cells[4].Value.ToString();
                txtQty.Focus();
            }
        }

        private void GenerateGrandTotal()
        {
            decimal grandTotal = 0;

            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                decimal amount = Convert.ToDecimal(dgvList.Rows[i].Cells[3].Value) * Convert.ToDecimal(dgvList.Rows[i].Cells[4].Value);
                grandTotal += amount;
            }

            btnGrandTotal.Text = grandTotal.ToString("C2");
        }

        private void dgvList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GenerateGrandTotal();
        }

        private void dgvList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GenerateGrandTotal();
        }



        private void ControlOrdering()
        {
            dtpPurchaseDate.TabIndex = 0;
            cboPurchaser.TabIndex = 1;
            cboSupplier.TabIndex = 2;
            btnNewSupplier.TabIndex = 3;
            txtInvoiceNo.TabIndex = 4;
            txtPRNO.TabIndex = 5;
            cboBuyFrom.TabIndex = 6;
            txtRemark.TabIndex = 7;
            cboItem.TabIndex = 8;
            txtQty.TabIndex = 9;
            txtUnitPrice.TabIndex = 10;
            btnAdd.TabIndex = 11;
            btnClear.TabIndex = 12;
            btnAddItemToStock.TabIndex = 13;
            btnSave.TabIndex = 14;
            btnCancel.TabIndex = 15;
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.lblAdded.Visible = false;
            this.lblSaved.Visible = false;
            this.btnAddItemToStock.Enabled = false;
            this.LoadPurchasers();
            this.LoadItems();
            this.LoadBuyFrom();
            this.LoadSuppliers();
            this.ControlOrdering();
            this.cboItem.SelectedIndex = -1;
            this.cboItem.SelectedIndexChanged += new EventHandler(cboItem_SelectedIndexChanged);

            if(viewFlag)
            {
                lblAdded.Visible = lblSaved.Visible = true;
                btnAdd.Enabled = btnClear.Enabled = btnSave.Enabled = false;

                using (var context = new MegaEntities())
                {
                    var purchase = context.Purchases.Find(purchaseId);
                    dtpPurchaseDate.Value = purchase.PurchaseDate;
                    cboPurchaser.SelectedValue = purchase.PurchaserCode;
                    cboSupplier.SelectedValue = purchase.SupplierId;
                    txtInvoiceNo.Text = purchase.InvoiceNo;
                    txtPRNO.Text = purchase.PRNO;
                    cboBuyFrom.SelectedItem = purchase.BuyFrom;
                    if(purchase.IsLock)
                    {
                        btnAddItemToStock.Enabled = false;
                        lblAdded.Visible = true;
                    }
                    else
                    {
                        btnAddItemToStock.Enabled = true;
                        lblAdded.Visible = false;
                    }
                    
                    var detail = purchase.PurchaseDetails.ToList();
                    foreach (var item in detail)
                    {
                        dgvList.Rows.Add("", item.ItemCode, item.Item.Description, item.UnitPrice, item.Quantity);
                    }

                    this.GenerateRowNo();
                }
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            cboItem.SelectedIndex = -1;
            txtUnitPrice.Clear();
            txtQty.Clear();
            isEdit = false;
            editInd = -1;
        }



        private void btnNewItems_Click(object sender, EventArgs e)
        {
            frmItem frmItm = new frmItem();
            frmItm.editFlag = false;
            frmItm.itemCode = "";
            frmItm.ShowDialog();
            cboItem.SelectedIndexChanged -= new EventHandler(cboItem_SelectedIndexChanged);
            this.LoadItems();
            cboItem.SelectedIndexChanged += new EventHandler(cboItem_SelectedIndexChanged);
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
        private void btnSave_Click(object sender, EventArgs e)
        {
            var purchase = new Purchase()
            {
                PurchaseDate = dtpPurchaseDate.Value,
                PurchaserCode = cboPurchaser.SelectedValue.ToString(),
                SupplierId = Convert.ToInt32(cboSupplier.SelectedValue),
                InvoiceNo = txtInvoiceNo.Text,
                PRNO = txtPRNO.Text,
                BuyFrom = cboBuyFrom.SelectedItem.ToString(),
                IsLock = false,
                ComputerCode = MegaService.GetComputerCode(),
                ComputeTime = MegaService.GetComputeTime()
            };

            using (var context = new MegaEntities())
            {
                purchase = context.Purchases.Add(purchase);
                context.SaveChanges();
                purchaseId = purchase.Id;
            }

            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                decimal up = Convert.ToDecimal(dgvList.Rows[i].Cells[3].Value);
                int qty = Convert.ToInt32(dgvList.Rows[i].Cells[4].Value);
                string itemCode = dgvList.Rows[i].Cells[1].Value.ToString();

                var purchaseDetail = new PurchaseDetail()
                {
                    MasterCode = purchase.Id,
                    ItemCode = itemCode,
                    UnitPrice = up,
                    Quantity = qty,
                    AddedQuantity = 0,
                    RemainQuantity = qty,
                    Amount = up * qty
                };

                using (var context = new MegaEntities())
                {
                    context.PurchaseDetails.Add(purchaseDetail);
                    context.SaveChanges();
                }
            }

            this.btnSave.Enabled = false;
            this.btnAddItemToStock.Enabled = true;
        }



        private void txtUnitPrice_Enter(object sender, EventArgs e)
        {
            MegaService.SwitchKeyboardLayout("en");
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            MegaService.SwitchKeyboardLayout("en");
        }

        private void btnAddItemToStock_Click(object sender, EventArgs e)
        {
            frmAddItemToStock frmAdd = new frmAddItemToStock();
            frmAdd.purchaseId = purchaseId;
            frmAdd.ShowDialog();
            using (var context = new MegaEntities())
            {
                var purchase = context.Purchases.Find(purchaseId);
                if (purchase.IsLock)
                {
                    btnAddItemToStock.Enabled = false;
                    lblAdded.Visible = true;
                }
                else
                {
                    btnAddItemToStock.Enabled = true;
                    lblAdded.Visible = false;
                }
            }
        }
    }
}
