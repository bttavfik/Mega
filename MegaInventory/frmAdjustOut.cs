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
    public partial class frmAdjustOut : Form
    {
        public frmAdjustOut()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        public bool Edit_Flage;

        public int Id;  //get id from frmAdjustOutView

        void loadProject()
        {
            var project = mega.Projects.ToList();
            cboProject.DataSource = project;
            cboProject.DisplayMember = "Description";
            cboProject.ValueMember = "Id";
            cboProject.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void loadItems()
        {
            var item = mega.Items.ToList();
            cboDescription.DataSource = item;
            cboDescription.DisplayMember = "Description";
            cboDescription.ValueMember = "Code";
            cboDescription.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Edit_Flage) return;

            if (string.IsNullOrEmpty(txtReference.Text.Trim()))
            {
                errorMS.SetError(txtReference, "Please input reference");
                txtReference.Focus();
                return;
            }
            else
                errorMS.Clear();
            if (string.IsNullOrEmpty(txtItemCode.Text.Trim()))
            {
                errorMS.SetError(txtItemCode, "Please inpute item code");
                txtItemCode.Focus();
                return;
            }
            else
                errorMS.Clear();
            if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                errorMS.SetError(txtQuantity, "Please inpute quantity");
                txtQuantity.Focus();
                return;
            }
            else
                errorMS.Clear();
            try
            {
                decimal amount = decimal.Parse(txtUnitPrice.Text) * int.Parse(txtQuantity.Text);
                var adjout = new AdjustOut()
                {
                    AdjustOutDate = dtpAddustDate.Value,
                    Reference = txtReference.Text,
                    ItemCode = cboDescription.SelectedValue.ToString(),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Amount = amount,
                    ProjectId = int.Parse(cboProject.SelectedValue.ToString()),
                    Remark = txtRemark.Text,
                    ComputerCode = Services.MegaService.GetComputerCode(),
                    ComputeTime = Services.MegaService.GetComputeTime()
                };
                mega.AdjustOuts.Add(adjout);
                mega.SaveChanges();
                lblSaved.Show();
                btnSave.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void frmAdjustOut_Load(object sender, EventArgs e)
        {
            lblSaved.Hide();
            loadItems();
            loadProject();
            cboDescription.SelectedIndex = -1;
            cboProject.SelectedIndex = -1;
            cboDescription.SelectedValueChanged += new EventHandler(this.cboDescription_SelectedValueChange);

            if (Edit_Flage)
            {
                var AdjIn = mega.AdjustOuts.Find(this.Id);
                dtpAddustDate.Value = AdjIn.AdjustOutDate;
                txtReference.Text = AdjIn.Reference;
                txtItemCode.Text = AdjIn.ItemCode;
                cboDescription.SelectedValue = AdjIn.ItemCode;
                txtUnitPrice.Text = AdjIn.UnitPrice.ToString();
                cboProject.SelectedValue = AdjIn.ProjectId;
                txtRemark.Text = AdjIn.Remark;
                txtQuantity.Text = AdjIn.Quantity.ToString();
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            cboDescription.SelectedIndex = -1;
            var item = mega.Items.Where(x => x.Code.Equals(txtItemCode.Text)).Select(x => new { x.Code, x.CurrentPrice });
            foreach (var items in item)
            {
                cboDescription.SelectedValue = items.Code;
                txtUnitPrice.Text = items.CurrentPrice.ToString();
            }
        }

        private void cboDescription_SelectedValueChange(object sender, EventArgs e)
        {
            var item = mega.Items.Find(cboDescription.SelectedValue);
            if (item != null)
            {
                txtItemCode.Text = item.Code;
                txtUnitPrice.Text = item.CurrentPrice.ToString();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)8)
                e.Handled = false;
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            new frmItem().ShowDialog();
            this.loadItems();
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            new frmProject().ShowDialog();
            this.loadProject();
        }


    }
}
