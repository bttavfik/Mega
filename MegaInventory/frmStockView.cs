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
    public partial class frmStockView : Form
    {
        public frmStockView()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        void loadStock()
        {
            int i=1;
            var stock = mega.Stocks.Include("Item").ToList().OrderByDescending(x=>x.Quantity);
            foreach (var item in stock)
            {
                dgvList.Rows.Add(i++,item.ItemCode, item.Item.EnglishName, item.Item.Description, item.Item.Category.Description, item.Quantity, "$" + item.Item.CurrentPrice);
            }
        }

        private void frmStockView_Load(object sender, EventArgs e)
        {
            loadStock();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPurchase frm = new frmPurchase();
            frm.ShowDialog();
            this.loadStock();
        }

        private void btnAjustIn_Click(object sender, EventArgs e)
        {
            frmAdjustIn frm = new frmAdjustIn();
            frm.Edit_Flage = false;
            frm.ShowDialog();

            dgvList.Rows.Clear();
            this.loadStock();
        }

        private void btnAdjustOut_Click(object sender, EventArgs e)
        {
            frmAdjustOut frm = new frmAdjustOut();
            frm.Edit_Flage = false;
            frm.ShowDialog();

            dgvList.Rows.Clear();
            this.loadStock();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            dgvList.Rows.Clear();
            int i = 1;
            var search = mega.Stocks.Where(x => x.ItemCode.StartsWith(txtSearch.Text)).ToList().OrderByDescending(x => x.Quantity);
            foreach (var item in search)
            {
                dgvList.Rows.Add(i++, item.ItemCode, item.Item.EnglishName, item.Item.Description, item.Item.Category.Description, item.Quantity, item.Item.CurrentPrice);
            }
            
        }
    }
}
