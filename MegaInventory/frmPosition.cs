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
    public partial class frmPosition : Form
    {
        public frmPosition()
        {
            InitializeComponent();
            MegaService.FormatDataGridView(dgvList);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            var position = new Position()
            {
                Description = txtPositionName.Text,
                Remark = txtRemark.Text,
                IsActive = true
            };

            using (var context = new MegaEntities())
            {
                position = context.Positions.Add(position);
                context.SaveChanges();
            }

            dgvList.Rows.Add((dgvList.Rows.Count + 1), position.Id, position.Description);
        }



        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            int no = 1;
            this.dgvList.Rows.Clear();
            string content = txtSearch.Text.ToLower();

            using (var context = new MegaEntities())
            {
                var query = context.Positions.ToList().Where(p => p.Description.ToLower().StartsWith(content) && (p.IsActive == true));
                foreach (var position in query)
                {
                    dgvList.Rows.Add((no++), position.Id, position.Description);
                }
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int colInd = dgvList.CurrentCell.ColumnIndex;
            if(dgvList.Columns[colInd].HeaderText == "Delete")
            {
                DialogResult action = MessageBox.Show("Delete selected row?", "Position", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(action == DialogResult.Yes)
                {
                    var positionCode = Convert.ToInt32(dgvList.CurrentRow.Cells[1].Value);
                    using (var context = new MegaEntities())
                    {
                        var position = context.Positions.Find(positionCode);
                        position.IsActive = false;
                        context.SaveChanges();
                    }

                    dgvList.Rows.RemoveAt(dgvList.CurrentRow.Index);
                }
            }
        }



        private void LoadData()
        {
            int no = 1;
            this.dgvList.Rows.Clear();

            using (var context = new MegaEntities())
            {
                var query = context.Positions.ToList().Where(p => p.IsActive);
                foreach (var position in query)
                {
                    dgvList.Rows.Add((no++), position.Id, position.Description);
                }
            }
        }

        private void ControlOrdering()
        {
            txtSearch.TabIndex = 0;
            txtPositionName.TabIndex = 1;
            txtRemark.TabIndex = 2;
            btnAdd.TabIndex = 3;
        }

        private void frmPosition_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.LoadData();
            this.ControlOrdering();
        }
    }
}
