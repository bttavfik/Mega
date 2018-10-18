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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
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
                var query = context.Suppliers.ToList().Where(s => s.IsActive);
                foreach (var supplier in query)
                {
                    dgvList.Rows.Add((no++), supplier.Id, supplier.Description, supplier.Phone);
                }
            }
        }

        private void ControlOrdering()
        {
            txtSupplierName.TabIndex = 0;
            txtPhone.TabIndex = 1;
            txtRemark.TabIndex = 2;
            btnAdd.TabIndex = 3;
            txtSearch.TabIndex = 4;
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.LoadData();
            this.ControlOrdering();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Clear()
        {
            txtSupplierName.Clear();
            txtPhone.Clear();
            txtRemark.Clear();
            txtSearch.Clear();
            txtSupplierName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var supplier = new Supplier()
            {
                Description = txtSupplierName.Text,
                Phone = txtPhone.Text,
                Remark = txtRemark.Text,
                IsActive = true
            };

            using (var context = new MegaEntities())
            {
                supplier = context.Suppliers.Add(supplier);
                context.SaveChanges();
            }

            this.Clear();
            this.dgvList.Rows.Add((dgvList.Rows.Count+1), supplier.Id, supplier.Description, supplier.Phone);
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DialogResult action = MessageBox.Show("Delete selected row?", "Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (action != DialogResult.Yes) return;

                int id = Convert.ToInt32(dgvList.CurrentRow.Cells[1].Value);
                using (var context = new MegaEntities())
                {
                    var supplier = context.Suppliers.Find(id);
                    supplier.IsActive = false;
                    context.SaveChanges();
                }

                this.dgvList.Rows.RemoveAt(dgvList.CurrentRow.Index);
            }
        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int no = 1;
            string content = txtSearch.Text.ToLower();
            this.dgvList.Rows.Clear();

            using (var context = new MegaEntities())
            {
                var query = context.Suppliers.ToList().Where(s => s.IsActive && (s.Description.ToLower().StartsWith(content)));
                foreach (var supplier in query)
                {
                    dgvList.Rows.Add((no++), supplier.Id, supplier.Description, supplier.Phone);
                }
            }
        }
    }
}
