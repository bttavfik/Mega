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

namespace MegaInventory
{
    public partial class frmAddItemToStock : Form
    {
        private List<PurchaseDetail> addedList;
        private List<PurchaseDetail> itemList;
        public int purchaseId;

        public frmAddItemToStock()
        {
            InitializeComponent();
        }
        

        private void LoadItemList()
        {
            using (var context = new MegaEntities())
            {
                itemList = new List<PurchaseDetail>();
                var query = context.PurchaseDetails.Include("Item").Where(p => p.MasterCode==purchaseId).ToList();
                foreach (var item in query)
                {
                    itemList.Add(item);
                }
            }
        }

        private void RefreshAllItems()
        {
            lsbPurchasedItems.Items.Clear();
            foreach (var p in itemList)
            {
                lsbPurchasedItems.Items.Add(p.Item.Description + " [ "+p.RemainQuantity+" ] ");
            }

            if(addedList == null)
            {
                addedList = new List<PurchaseDetail>();
            }
            lsbAddedItems.Items.Clear();
            foreach (var p in addedList)
            {
                lsbAddedItems.Items.Add(p.Item.Description + " [ " + p.AddedQuantity + " ] ");
            }
        }
       
        private void frmAddItemToStock_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.LoadItemList();
            this.RefreshAllItems();
            this.lblSaved.Visible = false;
            using (var context = new MegaEntities())
            {
                var purchasing = context.Purchases.Find(purchaseId);
                if(purchasing.IsLock)
                {
                    lblSaved.Visible = true;
                    btnSave.Enabled = false;
                    lblQty.Visible = txtQty.Visible = false;
                    btnSingleBackward.Visible = btnSingleForward.Visible = false;
                    btnMultiBackward.Visible = btnMultiForward.Visible = false;
                }
            }
        }



        private void lsbPurchasedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lsbPurchasedItems.SelectedIndex;
            if (index >= 0 && index < itemList.Count)
            {
                txtQty.Text = itemList[index].RemainQuantity.ToString();
                txtQty.Focus();
            }
        }
        
        

        private void btnMultipleForward_Click(object sender, EventArgs e)
        {
            int count = itemList.Count;
            for (int j = 0; j < count; j++)
            {
                ForwardItem(0, true);
            }
            this.RefreshAllItems();
        }

       
        private void btnMultipleBackward_Click(object sender, EventArgs e)
        {
            int count = addedList.Count;
            for (int i = 0; i < count; i++)
            {
                BackwardItem(0);
            }
            this.RefreshAllItems();
        }

        

        private bool IsAdded(PurchaseDetail pd)
        {
            foreach (var p in addedList)
            {
                if((p.MasterCode==pd.MasterCode) && (p.ItemCode==pd.ItemCode))
                {
                    return true;
                }
            }
            return false;
        }

       

        private void ForwardItem(int index, bool all)
        {   
            var purchaseDetail = new PurchaseDetail()
            {
                MasterCode = itemList[index].MasterCode,
                ItemCode = itemList[index].ItemCode,
                UnitPrice = itemList[index].UnitPrice,
                Quantity = itemList[index].Quantity,
                AddedQuantity = itemList[index].AddedQuantity,
                RemainQuantity = itemList[index].RemainQuantity,
                Amount = itemList[index].Amount
            };
            using (var context = new MegaEntities())
            {
                purchaseDetail.Item = context.Items.Find(purchaseDetail.ItemCode);
            }

            int qty = 0;
            int.TryParse(txtQty.Text, out qty);

            if (qty > purchaseDetail.RemainQuantity || all)
            {
                qty = purchaseDetail.RemainQuantity;
            }
            else if (qty <= 0)
            {
                txtQty.Clear();
                return;
            }
            txtQty.Clear();

            if (IsAdded(purchaseDetail))
            {
                foreach (var p in addedList)
                {
                    if ((p.MasterCode == purchaseDetail.MasterCode) && (p.ItemCode == purchaseDetail.ItemCode))
                    {
                        p.AddedQuantity += qty;
                        p.RemainQuantity = p.Quantity - p.AddedQuantity;
                        if (p.RemainQuantity > 0)
                        {
                            itemList[index].AddedQuantity = p.AddedQuantity;
                            itemList[index].RemainQuantity = p.RemainQuantity;
                        }
                        else
                        {
                            itemList.RemoveAt(index);
                        }
                        break;
                    }
                }
            }
            else
            {
                purchaseDetail.AddedQuantity = qty;
                purchaseDetail.RemainQuantity = purchaseDetail.Quantity - purchaseDetail.AddedQuantity;
                addedList.Add(purchaseDetail);

                itemList.RemoveAt(index);
                if (purchaseDetail.RemainQuantity > 0)
                {
                    itemList.Add(purchaseDetail);
                }
            }
        }

        
        
        private void BackwardItem(int index)
        {
            var purchaseDetail = new PurchaseDetail()
            {
                MasterCode = addedList[index].MasterCode,
                ItemCode = addedList[index].ItemCode,
                UnitPrice = addedList[index].UnitPrice,
                Quantity = addedList[index].Quantity,
                AddedQuantity = addedList[index].AddedQuantity,
                RemainQuantity = addedList[index].RemainQuantity,
                Amount = addedList[index].Amount
            };
            using (var context = new MegaEntities())
            {
                purchaseDetail.Item = context.Items.Find(purchaseDetail.ItemCode);
            }

            purchaseDetail.AddedQuantity = 0;
            purchaseDetail.RemainQuantity = purchaseDetail.Quantity;
            addedList.RemoveAt(index);
            int state = 0;
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].MasterCode == purchaseDetail.MasterCode && itemList[i].ItemCode == purchaseDetail.ItemCode)
                {
                    itemList.RemoveAt(i);
                    itemList.Insert(i, purchaseDetail);
                    state = 1;
                    break;
                }
            }
            if (state == 0)
            {
                itemList.Add(purchaseDetail);
            }
        }

        

        private void btnSingleForward_Click(object sender, EventArgs e)
        {
            if (lsbPurchasedItems.SelectedItems.Count <= 0) return;
            int index = lsbPurchasedItems.SelectedIndex;
            this.ForwardItem(index, false);
            this.RefreshAllItems();
        }

        private void btnSingleBackward_Click(object sender, EventArgs e)
        {
            if (lsbAddedItems.SelectedItems.Count <= 0) return;
            int index = lsbAddedItems.SelectedIndex;
            this.BackwardItem(index);
            this.RefreshAllItems();
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var context = new MegaEntities())
            {
                foreach (var pd in addedList)
                {
                    var p = context.PurchaseDetails.Find(pd.MasterCode, pd.ItemCode);
                    p.AddedQuantity = pd.AddedQuantity;
                    p.RemainQuantity = pd.RemainQuantity;
                }
                context.SaveChanges();
            }
            
            AddItemsToStock();
            lblSaved.Visible = true;
            btnSave.Enabled = false;
            lblQty.Visible = txtQty.Visible = false;
            btnSingleBackward.Visible = btnSingleForward.Visible = false;
            btnMultiBackward.Visible = btnMultiForward.Visible = false;
        }



        private void AddItemsToStock()
        {
            using (var context = new MegaEntities())
            {
                foreach (var p in addedList)
                {
                    var itemInStock = context.Stocks.Find(p.ItemCode);
                    if(itemInStock == null)
                    {
                        itemInStock = new Stock()
                        {
                            ItemCode = p.ItemCode,
                            Quantity = p.AddedQuantity
                        };
                        context.Stocks.Add(itemInStock);
                    }
                    else
                    {
                        itemInStock.Quantity += p.AddedQuantity;
                    }
                    context.SaveChanges();
                }

                var purchasing = context.Purchases.Find(purchaseId);
                purchasing.IsLock = true;
                context.SaveChanges();
            }
        }
     
    }
}
