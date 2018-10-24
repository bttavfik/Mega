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
    public partial class frmCategory : Form
    {

        public frmCategory()
        {
            InitializeComponent();
            MegaService.FormatDataGridView(dgvList);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                Description = txtCategoryName.Text,
                Remark = txtRemark.Text,
                IsActive = true
            };
            using (var context = new MegaEntities())
            {
                category = context.Categories.Add(category);
                context.SaveChanges();
            }

            dgvList.Rows.Add(dgvList.Rows.Count + 1, category.Id, category.Description);

            txtCategoryName.Clear();
            txtRemark.Clear();
            txtCategoryName.Focus();
        }


        private void LoadData()
        {
            int no = 1;
            this.dgvList.Rows.Clear();

            using (var context = new MegaEntities())
            {
                var query = context.Categories.ToList().Where(c => c.IsActive);
                foreach (var category in query)
                {
                    dgvList.Rows.Add((no++), category.Id, category.Description);
                }
            }
        }

        private void ControlOrdering()
        {
            this.txtSearch.TabIndex = 0;
            this.txtCategoryName.TabIndex = 1;
            this.txtRemark.TabIndex = 2;
            this.btnAdd.TabIndex = 3;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.LoadData();
            this.ControlOrdering();
        }



        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int colInd = dgvList.CurrentCell.ColumnIndex;
            if(dgvList.Columns[colInd].HeaderText == "Delete")
            {
                DialogResult action = MessageBox.Show("Delete selected row?","Category",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(action == DialogResult.Yes)
                {
                    int id = int.Parse(dgvList.CurrentRow.Cells[1].Value.ToString());
                    using (var context = new MegaEntities())
                    {
                        var category = context.Categories.Find(id);
                        category.IsActive = false;
                        context.SaveChanges();
                    }

                    this.dgvList.Rows.RemoveAt(dgvList.CurrentRow.Index);
                }
            }
        }



        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAdd_Click(sender, e);
            }
        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int no = 1;
            this.dgvList.Rows.Clear();

            using (var context = new MegaEntities())
            {
                var query = context.Categories.ToList().Where(c => (c.IsActive==true) && c.Description.ToLower().StartsWith(txtSearch.Text.ToLower()));
                foreach (var category in query)
                {
                    dgvList.Rows.Add((no++), category.Id, category.Description);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
