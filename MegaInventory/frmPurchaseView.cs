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
    public partial class frmPurchaseView : Form
    {
        public frmPurchaseView()
        {
            InitializeComponent();
            MegaService.FormatDataGridView(dgvList);
        }



        private void LoadData()
        {
            int no = 1;
            this.dgvList.Rows.Clear();

            using (var context = new MegaEntities())
            {
                var query = context.Purchases.ToList().Where(p => p.ComputerCode==MegaService.GetComputerCode());
                foreach (var p in query)
                {
                    var items = p.PurchaseDetails.ToList();
                    decimal total = 0;

                    foreach (var i in items)
                    {
                        total += i.Amount;
                    }

                    dgvList.Rows.Add((no++), p.Id, p.PurchaseDate,p.Purchaser.EmployeeNameKh,p.Supplier.Description,p.InvoiceNo,p.PRNO,p.BuyFrom, total);
                }
            }
        }

        private void frmPurchaseView_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadData();
        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPurchase frmPur = new frmPurchase();
            frmPur.ShowDialog();
            this.LoadData();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int purchaseId = Convert.ToInt32(dgvList.CurrentRow.Cells[1].Value);
            frmPurchase frmPur = new frmPurchase();
            frmPur.purchaseId = purchaseId;
            frmPur.viewFlag = true;
            frmPur.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvList.CurrentRow.Index;
            if(rowIndex >= 0)
            {
                int purchaseId = Convert.ToInt32(dgvList.CurrentRow.Cells[1].Value);
                frmPurchase frmPur = new frmPurchase();
                frmPur.purchaseId = purchaseId;
                frmPur.viewFlag = true;
                frmPur.ShowDialog();
            }
        }
    }
}
