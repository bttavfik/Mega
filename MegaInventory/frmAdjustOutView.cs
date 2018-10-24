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
using System.Data.Entity;

namespace MegaInventory
{
    public partial class frmAdjustOutView : Form
    {
        public frmAdjustOutView()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        void loadAdjustOut()
        {
            int i = 1;
            var loadadjOut = mega.AdjustOuts.ToList();
            foreach (var item in loadadjOut)
            {
                dgvList.Rows.Add(i++, item.Id, item.AdjustOutDate, item.Reference, item.Item.Description, "$" + item.UnitPrice, item.Quantity, "$" + item.Amount, item.Remark);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAdjustOut frm = new frmAdjustOut();
            frm.Edit_Flage = false;
            frm.ShowDialog();

            dgvList.Rows.Clear();
            this.loadAdjustOut();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (rowIdex >= 0)
            {
                frmAdjustIn frm = new frmAdjustIn();
                frm.Edit_Flage = true;
                frm.Id = this.Id;
                frm.ShowDialog();

                dgvList.Rows.Clear();
                this.loadAdjustOut();
                this.rowIdex = -1;
            }
        }

        int Id; //get id from datagridview cell click

        int rowIdex = -1;    //get row index from datagrid

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvList.NewRowIndex)
                return;
            if (e.RowIndex >= 0)
            {
                rowIdex = e.RowIndex;
                Id = int.Parse(dgvList.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dgvList.Rows.Clear();
            int i = 1;
            var search = mega.AdjustOuts.Where(x => x.AdjustOutDate >= dtpFrom.Value && x.AdjustOutDate <= dtpUntil.Value).ToList();
            foreach (var item in search)
            {
                dgvList.Rows.Add(i++, item.Id, item.AdjustOutDate, item.Reference, item.Item.Description, "$" + item.UnitPrice, item.Quantity, "$" + item.Amount, item.Remark);
            }
        }


    }
}
