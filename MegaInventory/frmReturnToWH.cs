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
    public partial class frmReturnToWH : Form
    {
        public frmReturnToWH()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        public bool Edit_Flage;

        public int Id;  //get id returntowh from returntowhview

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

            cboItem.DataSource = item;
            cboItem.DisplayMember = "Description";
            cboItem.ValueMember = "Code";
            cboItem.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void loadApprover()
        {
            var applicant = mega.Employees.ToList();

            cboApprover.DataSource = applicant;

            cboApprover.DisplayMember = "EmployeeNameEn";
            cboApprover.ValueMember = "Code";
            cboApprover.DropDownStyle = ComboBoxStyle.DropDownList;

            cboApplicant.DataSource = applicant;
            cboApplicant.DisplayMember = "EmployeeNameEn";
            cboApplicant.ValueMember = "Code";
            cboApplicant.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboItem_SelectedValueChange(object sender, EventArgs e)
        {
            var item = mega.Items.Find(cboItem.SelectedValue);

            try
            {
                if (item != null)
                {
                    txtItemCode.Text = item.Code;
                    txtUnitPrice.Text = item.CurrentPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Edit_Flage) return;
            int qty_from_stock; //get quantity from table stock

            int qty_from_dgvlist;   //get quantity from datagridview

            string itm; //get item code from datagridview

            #region condition if

            if (string.IsNullOrEmpty(txtRefer1.Text.Trim()))
            {
                errorMS.SetError(txtRefer1, "Please input reference 1");
                txtRefer1.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (cboApplicant.SelectedIndex < 0)
            {
                errorMS.SetError(cboApplicant, "Please select applicant");
                cboApplicant.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (cboApprover.SelectedIndex < 0)
            {
                errorMS.SetError(cboApprover, "Please select approver");
                cboApprover.Focus();
                return;
            }
            else
                errorMS.Clear();

            #endregion

            if (dgvList.Rows.Count > 0)
            {
                #region insert into table ReturnToWH

                var ReturnToWh = new ReturnToWH()
                {
                    ReturnDate = dtpIssuedDate.Value,
                    Reference = txtRefer1.Text,
                    ApplicantCode = cboApplicant.SelectedValue.ToString(),
                    ApproverCode = cboApprover.SelectedValue.ToString(),
                    ProjectId = int.Parse(cboProject.SelectedValue.ToString()),
                    Remark = txtPurpose.Text,
                    ComputerCode = Services.MegaService.GetComputerCode(),
                    ComputeTime = Services.MegaService.GetComputeTime()
                };

                mega.ReturnToWHs.Add(ReturnToWh);

                #endregion

                #region isert into table ReturnToWHDetail and update stock

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    var ReturnToWHView = new ReturnToWHDetail()
                    {
                        MasterCode = ReturnToWh.Id,
                        ItemCode = dgvList.Rows[i].Cells[1].Value.ToString(),
                        Quantity = int.Parse(dgvList.Rows[i].Cells[4].Value.ToString()),
                        UnitPrice = decimal.Parse(dgvList.Rows[i].Cells[3].Value.ToString()),
                        Amount = decimal.Parse(dgvList.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[i].Cells[4].Value.ToString())
                    };

                    mega.ReturnToWHDetails.Add(ReturnToWHView);

                    itm = dgvList.Rows[i].Cells[1].Value.ToString();

                    qty_from_dgvlist = int.Parse(dgvList.Rows[i].Cells[4].Value.ToString());

                    var stock = mega.Stocks.Where(x => x.ItemCode == itm).FirstOrDefault();

                    qty_from_stock = stock.Quantity;
                    stock.Quantity = (qty_from_stock + qty_from_dgvlist);

                    mega.Entry(stock).State = EntityState.Modified;
                }

                #endregion

                mega.SaveChanges();

                dgvList.Rows.Clear();
                txtGrandTotal.Text = txtRefer1.Text = txtPurpose.Text = "";
                cboItem.SelectedIndex = cboApplicant.SelectedIndex = cboApprover.SelectedIndex = cboProject.SelectedIndex = -1;
                lblSaved.Show();
            }
            
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            cboItem.SelectedIndex = -1;

            var item = mega.Items.Where(x => x.Code.Equals(txtItemCode.Text)).Select(x => new { x.Code, x.CurrentPrice });

            try
            {
                foreach (var items in item)
                {
                    cboItem.SelectedValue = items.Code;
                    txtUnitPrice.Text = items.CurrentPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmReturnToWH_Load(object sender, EventArgs e)
        {
            lblSaved.Hide();
            loadApprover();
            loadItems();
            loadProject();
            cboItem.SelectedIndexChanged += new EventHandler(this.cboItem_SelectedValueChange);

            if (Edit_Flage)
            {
                int i = 1;
                var returnToWh = mega.ReturnToWHs.Where(x => x.Id == this.Id).FirstOrDefault();
                dtpIssuedDate.Value = returnToWh.ReturnDate;
                txtRefer1.Text = returnToWh.Reference;
                cboApplicant.SelectedValue = returnToWh.ApplicantCode;
                cboApprover.SelectedValue = returnToWh.ApproverCode;
                cboProject.SelectedValue = returnToWh.ProjectId;
                txtPurpose.Text = returnToWh.Remark;

                var returnToWhView = mega.ReturnToWHDetails.Where(x => x.MasterCode == this.Id).ToList();

                foreach (var item in returnToWhView)
                {
                    dgvList.Rows.Add(i++,item.MasterCode, item.Item.Description, item.UnitPrice, item.Quantity);
                }
                money = 0;
                for (int k = 0; k < dgvList.Rows.Count; k++)
                {
                    money += decimal.Parse(dgvList.Rows[k].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[k].Cells[4].Value.ToString());
                }
                txtGrandTotal.Text = money + " រៀល";
            }
        }

        private void btnNewApplicant_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.ShowDialog();
            cboApplicant.Items.Clear();
            this.loadApprover();
        }

        private void btnNewApprover_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.ShowDialog();
            cboApprover.Items.Clear();
            this.loadApprover();
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            frmProject frm = new frmProject();
            frm.ShowDialog();
            cboProject.Items.Clear();
            this.loadProject();
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            frmItem frm = new frmItem();
            frm.ShowDialog();
            cboItem.Items.Clear();
            this.loadItems();
        }

        
        int i = 1;  //No into datagrid

        decimal money;  //sum price in datagridview into txtGrandTotal

        int index = -1; //get index from datagrid

        int no; //get No from datagrid

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Edit_Flage) return;

            #region condition if
            if (string.IsNullOrEmpty(txtItemCode.Text.Trim()))
            {
                errorMS.SetError(txtItemCode, "Please input item code");
                txtItemCode.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (cboItem.SelectedIndex < 0)
            {
                errorMS.SetError(cboItem, "Please select item");
                cboItem.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (string.IsNullOrEmpty(txtQty.Text.Trim()))
            {
                errorMS.SetError(txtQty, "Please input quantity");
                txtQty.Focus();
                return;
            }
            else
                errorMS.Clear();

            #endregion

            #region check item in datagrid (have or not)

            for (int j = 0; j < dgvList.Rows.Count; j++)
            {
                if (cboItem.SelectedValue.ToString() == dgvList.Rows[j].Cells[1].Value.ToString())
                {
                    money = 0;
                    DataGridViewRow newDataRow = dgvList.Rows[j];
                    newDataRow.Cells[0].Value = dgvList.Rows[j].Cells[0].Value;
                    newDataRow.Cells[1].Value = txtItemCode.Text;
                    newDataRow.Cells[2].Value = cboItem.Text;
                    newDataRow.Cells[3].Value = txtUnitPrice.Text;
                    newDataRow.Cells[4].Value =int.Parse(dgvList.Rows[j].Cells[4].Value.ToString())+int.Parse(txtQty.Text);
                    for (int i = 0; i < dgvList.Rows.Count; i++)
                    {
                        money += decimal.Parse(dgvList.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[i].Cells[4].Value.ToString());
                    }
                    txtGrandTotal.Text = "$" + money;
                    btnAdd.Text = "Add";
                    txtItemCode.Text = txtUnitPrice.Text = txtQty.Text = "";
                    return;
                }
            }

            #endregion

            if (btnAdd.Text == "Update")
            {
                #region update

                money = 0;
                DataGridViewRow newDataRow = dgvList.Rows[index];
                newDataRow.Cells[0].Value = no;
                newDataRow.Cells[1].Value = txtItemCode.Text;
                newDataRow.Cells[2].Value = cboItem.Text;
                newDataRow.Cells[3].Value = txtUnitPrice.Text;
                newDataRow.Cells[4].Value = txtQty.Text;
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    money += decimal.Parse(dgvList.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[i].Cells[4].Value.ToString());
                }
                txtGrandTotal.Text = "$" + money;
                btnAdd.Text = "Add";
                txtItemCode.Text = txtUnitPrice.Text =txtQty.Text= "";

                #endregion
            }
            else
            {
                #region add
                money = 0;
                dgvList.Rows.Add(i++, cboItem.SelectedValue, cboItem.Text, txtUnitPrice.Text, txtQty.Text);
                cboItem.SelectedIndex = -1;
                txtQty.Text = txtUnitPrice.Text = txtItemCode.Text = "";
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    money += decimal.Parse(dgvList.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[i].Cells[4].Value.ToString());
                }
                txtGrandTotal.Text = "$" + money ;

                #endregion
            }

        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Edit_Flage) return;

            if (e.RowIndex < 0 || e.RowIndex == dgvList.NewRowIndex)
                return;

            if (e.ColumnIndex == 6) //datagrid columns delete click
            {
                money -= decimal.Parse(dgvList.Rows[e.RowIndex].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[e.RowIndex].Cells[4].Value.ToString());
                dgvList.Rows.RemoveAt(e.RowIndex);
                txtGrandTotal.Text = "$" + money ;
                i--;
            }

            if (e.ColumnIndex == 5) //datagrid columns edit click
            {
                index = e.RowIndex;
                no = int.Parse(dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());
                cboItem.SelectedValue = dgvList.Rows[e.RowIndex].Cells[1].Value;
                txtQty.Text = dgvList.Rows[e.RowIndex].Cells[4].Value.ToString();
                btnAdd.Text = "Update";
            }

        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)||!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)8)
                e.Handled = false;
        }


    }
}
