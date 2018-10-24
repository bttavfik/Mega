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
    public partial class frmEmployeeView : Form
    {
        public frmEmployeeView()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        public void loadEmployee()
        {
            int i=1;
            dgvList.Rows.Clear();
            var emp = mega.Employees.Where(x => x.IsActive != false).ToList();
            foreach (var itm in emp)
            {
                dgvList.Rows.Add(i++,itm.Code, itm.EmployeeNameKh, itm.EmployeeNameEn, itm.Gender.Description, itm.DateOfBirth, itm.Position.Description, itm.Phone, itm.Email, itm.StartWorkDate);
            }
        }

        private void frmEmployeeView_Load(object sender, EventArgs e)
        {
            loadEmployee();
            lblDelete.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmEmployee().ShowDialog();
        }

        int Id;
        string empId;
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvList.NewRowIndex)
                return;
            Id = e.RowIndex;
            empId = dgvList.Rows[Id].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (empId != null)
            {
                try
                {
                    var emp = mega.Employees.Where(x => x.Code == empId).FirstOrDefault();
                    emp.IsActive = false;
                    mega.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    mega.SaveChanges();
                    lblDelete.Show();
                    loadEmployee();
                    empId = null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvList.Rows.Clear();
            var emp = mega.Employees.Where(x => x.EmployeeNameEn.StartsWith(txtSearch.Text)).Select(x => x);
            foreach (var itm in emp)
            {
                dgvList.Rows.Add(itm.Code, itm.EmployeeNameKh, itm.EmployeeNameEn, itm.Gender.Description, itm.DateOfBirth, itm.Position.Description, itm.Phone, itm.Email, itm.StartWorkDate);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (Id >= 0)
            {
                frmEmployee frm = new frmEmployee();
                frm.Edit_Flage = true;
                frm.code = empId;
                frm.ShowDialog();

                dgvList.Rows.Clear();
                Id = -1;
                this.loadEmployee();
            }
            
        }
    }
}
 