using System;
using System.Linq;
using System.Windows.Forms;

namespace Calendar
{
    public partial class ManageUsersWindow : Form
    {
        public ManageUsersWindow()
        {
            InitializeComponent();
        }

        private void ManageUsersWindow_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = CSDL.Instance.UserList;
            dgvUsers.Columns["UserId"].HeaderText = "ID";
            dgvUsers.Columns["UserName"].HeaderText = "Tên người dùng";
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CSDL.Instance.UserList.Any(u => u.UserName.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên người dùng đã tồn tại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newId = CSDL.Instance.UserList.Count > 0
                ? CSDL.Instance.UserList.Max(u => u.UserId) + 1
                : 1;

            CSDL.Instance.UserList.Add(new User(newId, name));
            txtUserName.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            // Không cho xóa CurrentUser (Me)
            var selected = CSDL.Instance.UserList[dgvUsers.CurrentRow.Index];
            if (selected.UserId == CSDL.Instance.CurrentUser.UserId)
            {
                MessageBox.Show("Không thể xóa người dùng hiện tại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CSDL.Instance.UserList.Remove(selected);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}