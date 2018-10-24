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
    public partial class frmReturnToSupplierView : Form
    {
        public frmReturnToSupplierView()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        void loadReturnToSupplier()
        {
            int i = 1;

            var ReturnToSupplierView = mega.ReturnToSuppliers.Include("ReturnToSupplierDetails").ToList();

            foreach (var item in ReturnToSupplierView)
            {
                dgvList.Rows.Add(i++, item.Id, item.ReturnDate, item.Reference, item.Applicant.EmployeeNameKh, item.Approver.EmployeeNameKh, item.Project.Description, item.ReturnToSupplierDetails.Count(), item.ReturnToSupplierDetails.Sum(x => x.UnitPrice), item.Remark);
            }
        }

        private void frmReturnToSupplierView_Load(object sender, EventArgs e)
        {
            loadReturnToSupplier();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0)
            {
                frmReturnToSupplier frm = new frmReturnToSupplier();
                frm.Id = this.id;
                frm.Edit_Flage = true;
                frm.ShowDialog();
                dgvList.Rows.Clear();
                this.loadReturnToSupplier();
                rowIndex = -1;
            }
        }

        int id; //get id from datagrid cell click

        private int rowIndex = -1;    //get row index form dgvlist

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvList.NewRowIndex)
                return;
            rowIndex = e.RowIndex; 

            id = int.Parse(dgvList.Rows[rowIndex].Cells[1].Value.ToString());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmReturnToSupplier frm = new frmReturnToSupplier();
            frm.Edit_Flage = false;
            frm.ShowDialog();
            dgvList.Rows.Clear();
            this.loadReturnToSupplier();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dgvList.Rows.Clear();
            int i = 1;
            var search = mega.ReturnToSuppliers.Where(x => x.ReturnDate >= dtpFrom.Value && x.ReturnDate <= dtpUntil.Value).ToList();
            foreach (var item in search)
            {
                dgvList.Rows.Add(i++, item.Id, item.ReturnDate, item.Reference, item.Applicant.EmployeeNameKh, item.Approver.EmployeeNameKh, item.Project.Description, item.ReturnToSupplierDetails.Count(), item.ReturnToSupplierDetails.Sum(x => x.UnitPrice), item.Remark);
            }
        }


    }
}
