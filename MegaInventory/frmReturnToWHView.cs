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
    public partial class frmReturnToWHView : Form
    {
        public frmReturnToWHView()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        void loadReturnToWH()
        {
            int i = 1;

            var ReturnToWHView = mega.ReturnToWHs.Include("ReturnToWHDetails").ToList(); 

            foreach (var item in ReturnToWHView)
            {
                dgvList.Rows.Add(i++, item.Id, item.ReturnDate, item.Reference, item.Applicant.EmployeeNameKh, item.Approver.EmployeeNameKh, item.Project.Description, item.ReturnToWHDetails.Count(), item.ReturnToWHDetails.Sum(x => x.UnitPrice), item.Remark);
            }
        }

        private void frmReturnToWHView_Load(object sender, EventArgs e)
        {
            loadReturnToWH();
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0)
            {
                frmReturnToWH frm = new frmReturnToWH();
                frm.Id = this.id;
                frm.Edit_Flage = true;
                frm.ShowDialog();
                dgvList.Rows.Clear();
                this.loadReturnToWH();
                rowIndex = -1;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmReturnToWH frm = new frmReturnToWH();
            frm.Edit_Flage = false;
            frm.ShowDialog();
            dgvList.Rows.Clear();
            this.loadReturnToWH();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dgvList.Rows.Clear();
            int i = 1;
            var search = mega.ReturnToWHs.Where(x => x.ReturnDate >= dtpFrom.Value && x.ReturnDate <= dtpUntil.Value).ToList();
            foreach (var item in search)
            {
                dgvList.Rows.Add(i++, item.Id, item.ReturnDate, item.Reference, item.Applicant.EmployeeNameKh, item.Approver.EmployeeNameKh, item.Project.Description, item.ReturnToWHDetails.Count(), item.ReturnToWHDetails.Sum(x => x.UnitPrice), item.Remark);
            }
        }

    }
}
