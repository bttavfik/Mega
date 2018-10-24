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
    public partial class frmIssued : Form
    {
        frmIssuedView frmIssue = new frmIssuedView();

        public frmIssued()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        public bool Edit_Flage;

        public int Id;  //get employee from formEmployeeView id

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

        void loadApplicant()
        {
            var applicant = mega.Employees.ToList();
            cboApplicant.DataSource = applicant;
            cboApplicant.DisplayMember = "EmployeeNameEn";
            cboApplicant.ValueMember = "Code";
            cboApplicant.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboItem_SelectedValueChange(object sender, EventArgs e)
        {
            txtStock.Clear();
            var item = mega.Items.Find(cboItem.SelectedValue);
            try
            {
                if (item != null)
                {
                    txtItemCode.Text = item.Code;
                    txtUnitPrice.Text = item.CurrentPrice.ToString();
                }
                var stock = mega.Stocks.Where(x => x.ItemCode.Equals(txtItemCode.Text)).ToList();
                foreach (var qty in stock)
                {
                    txtStock.Text = qty.Quantity.ToString();
                }
                if (txtStock.Text.Trim() == "")
                    txtStock.Text = "Null";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void frmIssued_Load(object sender, EventArgs e)
        {
            lblStop.Hide();
            lblSaved.Hide();
            loadApplicant();
            loadItems();
            loadProject();

            cboItem.SelectedValueChanged += new EventHandler(this.cboItem_SelectedValueChange);

            #region load_from_employee_view

            if (Edit_Flage == true)
            {
                int i=1;

                var issuedLoad = mega.Issueds.Where(x => x.Id == Id).FirstOrDefault();

                dtpIssuedDate.Value = issuedLoad.IssuedDate;
                txtRefer1.Text = issuedLoad.Reference1;
                txtRefer2.Text = issuedLoad.Reference2;
                cboApplicant.SelectedValue = issuedLoad.ApplicantCode;
                cboProject.SelectedValue = issuedLoad.ProjectId;
                txtCar.Text = issuedLoad.Car;
                txtPurpose.Text = issuedLoad.Purpose;

                var issueDetail = mega.IssuedDetails.Where(x => x.MasterCode == Id).ToList();

                foreach (var item in issueDetail)
                {
                    dgvList.Rows.Add(i++, item.ItemCode, item.Item.Description, item.UnitPrice, item.Quantity);
                }
            }

            #endregion

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

                var stock = mega.Stocks.Where(x => x.ItemCode.Equals(txtItemCode.Text)).ToList();

                foreach (var qty in stock)
                {
                    txtStock.Text = qty.Quantity.ToString();
                }

                if (txtStock.Text == "")
                    txtStock.Text = "Null";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
        int i=1;    //Tang for No in datagridview

        decimal money;  //sum price in datagridview into txtGrandTotal

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Edit_Flage) return;

            #region control_textbox_condition

            if (string.IsNullOrEmpty(txtItemCode.Text.Trim()))
            {
                errorMS.SetError(txtItemCode, "Please input item code");
                txtItemCode.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (string.IsNullOrEmpty(cboItem.Text.Trim()))
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

            if (string.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
            {
                errorMS.SetError(txtUnitPrice, "Please input unit price");
                txtUnitPrice.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (txtStock.Text.Trim() == "" || txtStock.Text.Trim() == "Null")
            {
                errorMS.SetError(txtStock, "Your item in stock is empty");
                return;
            }
            else
                errorMS.Clear();
            if (int.Parse(txtQty.Text) > int.Parse(txtStock.Text))
            {
                lblStop.Show();
                txtQty.Focus();
                return;
            }
            else
                lblStop.Hide();

            #endregion

            #region check items datagrid (have or not) 

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
                    newDataRow.Cells[4].Value = int.Parse(dgvList.Rows[j].Cells[4].Value.ToString()) + int.Parse(txtQty.Text);
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

                txtGrandTotal.Text = "$" + money ;
                btnAdd.Text = "Add";
                txtItemCode.Text = txtUnitPrice.Text = txtStock.Text = "";

                #endregion
            }
            else
            {
                #region add 

                money = 0;
                dgvList.Rows.Add(i++, txtItemCode.Text, cboItem.Text, txtUnitPrice.Text, txtQty.Text);
                cboItem.SelectedIndex = -1;
                txtQty.Text = "";

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    money += decimal.Parse(dgvList.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[i].Cells[4].Value.ToString());
                }

                txtGrandTotal.Text = "$" + money;
                txtItemCode.Text = txtUnitPrice.Text = txtStock.Text = "";

                #endregion
            }

        }

        
        int index;  //get rowIndex_from_datagridview

        int no; //get No_from_datagridview

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Edit_Flage) return;

            if (e.RowIndex < 0 || e.RowIndex == dgvList.NewRowIndex)
                return;

            if (e.ColumnIndex==6)//datagrid columns delete click
            {
                money -= decimal.Parse(dgvList.Rows[e.RowIndex].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[e.RowIndex].Cells[4].Value.ToString());
                dgvList.Rows.RemoveAt(e.RowIndex);
                txtGrandTotal.Text = "$" + money;
                i--;
            }

            if (e.ColumnIndex == 5)//datagrid columns edit click
            {
                index = e.RowIndex;
                no = int.Parse(dgvList.Rows[index].Cells[0].Value.ToString());
                cboItem.SelectedValue = dgvList.Rows[e.RowIndex].Cells[1].Value;
                txtQty.Text = dgvList.Rows[e.RowIndex].Cells[4].Value.ToString();
                btnAdd.Text = "Update";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Edit_Flage) return;

            int qty_from_stock; //get quantity from table stock

            int qty_from_dgvlist;   //get quantity from datagridview

            string itm; //get item code from datagridview

            #region condition_if

            if (string.IsNullOrEmpty(txtRefer1.Text.Trim()))
            {
                errorMS.SetError(txtRefer1, "Please input reference 1");
                txtRefer1.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (string.IsNullOrEmpty(txtRefer2.Text.Trim()))
            {
                errorMS.SetError(txtRefer2, "Please input reference 2");
                txtRefer2.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (cboApplicant.SelectedIndex < 0)
            {
                errorMS.SetError(cboApplicant, "Please select applicant");
                cboApplicant.Focus();
                SendKeys.Send("{DOWN}");
                return;
            }
            else
                errorMS.Clear();

            #endregion

            if (dgvList.Rows.Count > 0)
            {
                try
                {
                    #region insert_into_issued

                    var issued = new Issued()
                    {
                        IssuedDate = dtpIssuedDate.Value,
                        Reference1 = txtRefer1.Text,
                        Reference2 = txtRefer2.Text,
                        ApplicantCode = cboApplicant.SelectedValue.ToString(),
                        ProjectId = int.Parse(cboProject.SelectedValue.ToString()),
                        Purpose = txtPurpose.Text,
                        Car = txtCar.Text,
                        ComputerCode = Services.MegaService.GetComputerCode(),
                        ComputeTime = Services.MegaService.GetComputeTime()
                    };
                    mega.Issueds.Add(issued);

                    #endregion

                    for (int i = 0; i < dgvList.Rows.Count; i++)
                    {
                        #region insert_into_issuedDetail_and_update_stock

                        var issuedDetail = new IssuedDetail()
                        {
                            MasterCode = issued.Id,
                            ItemCode = dgvList.Rows[i].Cells[1].Value.ToString(),
                            UnitPrice = decimal.Parse(dgvList.Rows[i].Cells[3].Value.ToString()),
                            Quantity = int.Parse(dgvList.Rows[i].Cells[4].Value.ToString()),
                            Amount = decimal.Parse(dgvList.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvList.Rows[i].Cells[4].Value.ToString())
                        };
                        mega.IssuedDetails.Add(issuedDetail);

                        itm = dgvList.Rows[i].Cells[1].Value.ToString();
                        qty_from_dgvlist = int.Parse(dgvList.Rows[i].Cells[4].Value.ToString());

                        var stock = mega.Stocks.Where(x => x.ItemCode == itm).FirstOrDefault();

                        qty_from_stock = stock.Quantity;
                        stock.Quantity = (qty_from_stock - qty_from_dgvlist);

                        mega.Entry(stock).State = EntityState.Modified;

                        #endregion
                    }

                    mega.SaveChanges();

                    lblSaved.Show();
                    txtRefer1.Text = txtRefer2.Text = txtCar.Text = txtPurpose.Text =txtGrandTotal.Text= "";
                    cboApplicant.SelectedIndex = cboProject.SelectedIndex = -1;
                    dgvList.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)8)
                e.Handled = false;
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }


    }
}
