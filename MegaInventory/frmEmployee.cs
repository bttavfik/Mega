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
using System.Drawing.Imaging;
using System.IO;

namespace MegaInventory
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        MegaEntities mega = new MegaEntities();

        public bool Edit_Flage;
        public string code;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (Edit_Flage) return;
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter= "Pictures | *.jpg; *.bmp; *.png";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                pcbPhoto.Image = Image.FromFile(fd.FileName);
                pcbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        void loadGender()
        {
            var gender = mega.Genders.ToList();
            cboGender.DataSource = gender;
            cboGender.DisplayMember = "Description";
            cboGender.ValueMember = "Id";
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        void loadPosition()
        {
            var position = mega.Positions.ToList();
            cboPosition.DataSource = position;
            cboPosition.DisplayMember = "Description";
            cboPosition.ValueMember = "Id";
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            loadGender();
            loadPosition();
            lblSaved.Hide();
            if (Edit_Flage)
            {
                try
                {
                    var emp = mega.Employees.Where(x => x.Code == code).FirstOrDefault();
                    txtEmployeeCode.Text = emp.Code;
                    txtNameKh.Text = emp.EmployeeNameKh;
                    txtNameEnglish.Text = emp.EmployeeNameEn;
                    cboGender.SelectedValue = emp.GenderId;
                    dtpBirthDate.Value = emp.DateOfBirth.Value;
                    txtBirthPlace.Text = emp.PlaceOfBirth;
                    txtNatioalId.Text = emp.NationalId;
                    txtPhone.Text = emp.Phone;
                    txtEmail.Text = emp.Email;
                    cboPosition.SelectedValue = emp.PositionId;
                    dtpStartWork.Value = emp.StartWorkDate.Value;
                    txtCurrentAddress.Text = emp.CurrentAddress;
                    pcbPhoto.Image = byteToImage(emp.Photo);
                    pcbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        byte[] imageToByte(Image imagin) //save image to byte array
        {
            MemoryStream ms = new MemoryStream();
            imagin.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
        Image byteToImage(byte[] byteArray) //save byte array to image 
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Edit_Flage) return;

            if (string.IsNullOrEmpty(txtEmployeeCode.Text.Trim()))
            {
                errorMS.SetError(txtEmployeeCode, "Please input employee code");
                txtEmployeeCode.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (string.IsNullOrEmpty(txtNameKh.Text.Trim()))
            {
                errorMS.SetError(txtNameKh, "Please input khmer name");
                txtNameKh.Focus();
                return;
            }
            else
                errorMS.Clear();

            if (string.IsNullOrEmpty(txtNameEnglish.Text.Trim()))
            {
                errorMS.SetError(txtNameEnglish, "Please input english name");
                txtNameEnglish.Focus();
                return;
            }
            else
                errorMS.Clear();

            try
            {
                var employee = new Employee()
                {
                    Code = txtEmployeeCode.Text,
                    EmployeeNameKh = txtNameKh.Text,
                    EmployeeNameEn = txtNameEnglish.Text,
                    GenderId = int.Parse(cboGender.SelectedValue.ToString()),
                    DateOfBirth = dtpBirthDate.Value,
                    PlaceOfBirth = txtBirthPlace.Text,
                    CurrentAddress = txtCurrentAddress.Text,
                    NationalId = txtNatioalId.Text,
                    PositionId = int.Parse(cboPosition.SelectedValue.ToString()),
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Photo = imageToByte(pcbPhoto.Image),
                    StartWorkDate = dtpStartWork.Value,
                    IsActive = true
                };
                mega.Employees.Add(employee);
                mega.SaveChanges();
                lblSaved.Show();
                btnSave.Enabled = false;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
