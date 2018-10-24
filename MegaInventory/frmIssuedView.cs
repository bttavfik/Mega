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
    public partial class frmIssuedView : Form
    {
        public frmIssuedView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        MegaEntities mega = new MegaEntities();
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmIssued frm = new frmIssued();
            frm.Edit_Flage = false;
            frm.ShowDialog();

            dgvList.Rows.Clear();
            this.LoadIssued();
        }

        public void LoadIssued()
        {
            int no = 1;
            var query = mega.Issueds.Include("IssuedDetails").ToList();

            foreach (var issued in query)
            {
                dgvList.Rows.Add(no++,issued.Id, issued.IssuedDate, issued.Reference1, issued.Reference2, issued.Applicant.EmployeeNameKh,issued.Project.Description, issued.IssuedDetails.Count() + " មុខ" , issued.IssuedDetails.Sum(i => i.Amount), issued.Purpose);
            }
        }

        private void frmIssuedView_Load(object sender, EventArgs e)
        {
            this.LoadIssued();
        }
        
        private int rowIndex=-1;    //get row index form dgvlist

        int id;

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvList.NewRowIndex)
                return;
            rowIndex = e.RowIndex;
            id= int.Parse(dgvList.Rows[rowIndex].Cells["Column"].Value.ToString());
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0)
            {
                frmIssued frm = new frmIssued();
                frm.Edit_Flage = true;
                frm.Id = this.id;
                frm.ShowDialog();

                dgvList.Rows.Clear();
                LoadIssued();
                rowIndex = -1;
            }
        }
        

    }
}
