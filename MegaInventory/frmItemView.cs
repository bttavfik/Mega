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
    public partial class frmItemView : Form
    {

        public frmItemView()
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
                var query = context.Items.ToList().Where(item => item.IsActive);
                foreach (var item in query)
                {
                    dgvList.Rows.Add((no++), item.Code, item.EnglishName, item.Description, item.Category.Description, item.CurrentPrice.ToString("C2"));
                }
            }
        }



        private void ViewData(string itemCode)
        {
            frmItem frmItm = new frmItem();
            frmItm.itemCode = itemCode;
            frmItm.editFlag = true;
            frmItm.ShowDialog();
        }



        private void frmItemView_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadData();
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Focus();
        }



        private void btnView_Click(object sender, EventArgs e)
        {
            if(dgvList.SelectedRows.Count > 0)
            {
                var itemCode = dgvList.CurrentRow.Cells[1].Value.ToString();
                ViewData(itemCode);

                this.LoadData();
            }
        }



        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgvList.CurrentRow.Index >= 0)
            {
                var itemCode = dgvList.CurrentRow.Cells[1].Value.ToString();
                ViewData(itemCode);

                this.LoadData();
            }
        }


        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                var itemCode = dgvList.CurrentRow.Cells[1].Value.ToString();
                ViewData(itemCode);

                this.LoadData();
            }
        }


        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                var itemCode = dgvList.CurrentRow.Cells[1].Value.ToString();
                DialogResult action = MessageBox.Show("Delete item \""+itemCode+"\" ?", "Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (action == DialogResult.Yes)
                {
                    using (var context = new MegaEntities())
                    {
                        var item = context.Items.Find(itemCode);
                        item.IsActive = false;
                        context.SaveChanges();
                    }

                    this.LoadData();
                }
            }
        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmItem frmItm = new frmItem();
            frmItm.editFlag = false;
            frmItm.itemCode = "";
            frmItm.ShowDialog();

            this.LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int no = 1;
            this.dgvList.Rows.Clear();

            using (var context = new MegaEntities())
            {
                var content = txtSearch.Text.ToLower();
                var query = context.Items.ToList().Where(i => (i.Code.ToLower().StartsWith(content) || i.EnglishName.ToLower().StartsWith(content) || i.Description.StartsWith(txtSearch.Text) || i.Category.Description.StartsWith(content)) && (i.IsActive));
                foreach (var item in query)
                {
                    dgvList.Rows.Add((no++), item.Code, item.EnglishName, item.Description, item.Category.Description, item.CurrentPrice.ToString("C2"));
                }
            }
        }
    }
}
