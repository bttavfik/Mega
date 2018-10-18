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
    public partial class frmItem : Form
    {
 
        public frmItem()
        {
            InitializeComponent();
            MegaService.FormatDataGridView(dgvList);
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void AddNewItem()
        {
            var item = new Item()
            {
                Code = txtCode.Text,
                EnglishName = txtEnglishName.Text,
                Description = txtDescription.Text,
                CategoryId = Convert.ToInt32(cboCategory.SelectedValue),
                CurrentPrice = newPrice,
                IsActive = true
            };

            using (var context = new MegaEntities())
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
        }

        private void UpdateItem()
        {
            using (var context = new MegaEntities())
            {
                var item = context.Items.Find(itemCode);
                item.Description = txtDescription.Text;
                item.EnglishName = txtEnglishName.Text;
                item.CategoryId = Convert.ToInt32(cboCategory.SelectedValue);
                item.CurrentPrice = newPrice;
                context.SaveChanges();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editFlag)
            {
                UpdateItem();
            }
            else
            {
                AddNewItem();
            }
        }



        private void ControlOrdering()
        {
            txtCode.TabIndex = 0;
            txtEnglishName.TabIndex = 1;
            txtDescription.TabIndex = 2;
            cboCategory.TabIndex = 3;
            txtNewPrice.TabIndex = 4;
        }

        private void LoadCategories()
        {
            using (var context = new MegaEntities())
            {
                cboCategory.DataSource = context.Categories.Where(c => c.IsActive == true).ToList();
                cboCategory.DisplayMember = "Description";
                cboCategory.ValueMember = "Id";
                cboCategory.Invalidate();
            }
        }

        private void LoadItemPrice(string code)
        {
            int no = 1;
            this.dgvList.Rows.Clear();

            using (var context = new MegaEntities())
            {
                var query = context.ItemPricings.ToList().Where(p => p.ItemCode == code);
                foreach (var pricing in query)
                {
                    dgvList.Rows.Add((no++), pricing.NotedDate, pricing.UnitPrice.ToString("C2"));
                }
            }
        }

        public bool editFlag;
        public string itemCode;
        private void frmItem_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.LoadCategories();
            this.ControlOrdering();

            if (editFlag)
            {
                using (var context = new MegaEntities())
                {
                    var item = context.Items.Find(itemCode);

                    txtCode.Text = item.Code;
                    txtDescription.Text = item.Description;
                    txtEnglishName.Text = item.EnglishName;
                    cboCategory.SelectedValue = item.CategoryId;
                    
                    LoadItemPrice(item.Code);

                    txtCode.Enabled = false;
                    txtNewPrice.Focus();
                }
            }
        }



        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            frmCategory frmCat = new frmCategory();
            frmCat.ShowDialog();

            this.LoadCategories();
        }


        public decimal newPrice;
        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            var itemPrice = new ItemPricing()
            {
                ItemCode = txtCode.Text,
                UnitPrice = Convert.ToDecimal(txtNewPrice.Text),
                NotedDate = MegaService.GetComputeTime(),
                ComputerCode = MegaService.GetComputerCode(),
                ComputeTime = MegaService.GetComputeTime()
            };

            using (var context = new MegaEntities())
            {
                context.ItemPricings.Add(itemPrice);
            }

            txtNewPrice.Clear();
            txtNewPrice.Focus();

            newPrice = itemPrice.UnitPrice;

            dgvList.Rows.Add((dgvList.Rows.Count+1), itemPrice.NotedDate, itemPrice.UnitPrice.ToString("C2"));
        }



        private void txtNewPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAddPrice_Click(sender, e);
            }
        }
    }
}
