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
    public partial class frmProject : Form
    {
        public frmProject()
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
                var query = context.Projects.ToList().Where(p => p.IsActive);
                foreach (var project in query)
                {
                    dgvList.Rows.Add((no++), project.Id, project.Description, project.Location);
                }
            }
        }

        private void ControlOrdering()
        {
            txtProjectName.TabIndex = 0;
            txtLocation.TabIndex = 1;
            txtRemark.TabIndex = 2;
            btnAdd.TabIndex = 3;
            txtSearch.TabIndex = 4;
        }

        private void frmProject_Load(object sender, EventArgs e)
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
            txtProjectName.Clear();
            txtLocation.Clear();
            txtRemark.Clear();
            txtSearch.Clear();
            txtProjectName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var project = new Project()
            {
                Description = txtProjectName.Text,
                Location = txtLocation.Text,
                Remark = txtRemark.Text,
                IsActive = true
            };

            using (var context = new MegaEntities())
            {
                project = context.Projects.Add(project);
                context.SaveChanges();
            }

            this.Clear();
            this.dgvList.Rows.Add((dgvList.Rows.Count+1), project.Id, project.Description, project.Location);
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvList.SelectedRows.Count > 0)
            {
                DialogResult action = MessageBox.Show("Delete selected row?", "Proejcts",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (action != DialogResult.Yes) return;

                int id = Convert.ToInt32(dgvList.CurrentRow.Cells[1].Value);
                using (var context = new MegaEntities())
                {
                    var project = context.Projects.Find(id);
                    project.IsActive = false;
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
                var query = context.Projects.ToList().Where(p => p.IsActive && (p.Description.ToLower().StartsWith(content) || p.Location.ToLower().StartsWith(content)));
                foreach (var project in query)
                {
                    dgvList.Rows.Add((no++), project.Id, project.Description,project.Location);
                }
            }
        }
    }
}
