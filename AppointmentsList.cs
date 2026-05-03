using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class AppointmentsList : Form
    {
        public AppointmentsList()
        {
            InitializeComponent();
        }

        private void AppointmentsList_Load(object sender, EventArgs e)
        {
            // BindingList tự động cập nhật DataGridView khi có thêm/xóa
            dgvAppList.DataSource = CSDL.Instance.AppointmentList;

            // Ẩn cột Reminders và Participants (kiểu List không hiển thị tốt trong grid)
            if (dgvAppList.Columns["Reminders"] != null)
                dgvAppList.Columns["Reminders"].Visible = false;
            if (dgvAppList.Columns["Participants"] != null)
                dgvAppList.Columns["Participants"].Visible = false;
            if (dgvAppList.Columns["Duration"] != null)
                dgvAppList.Columns["Duration"].Visible = false;

            dgvAppList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppList.ReadOnly = true;
            dgvAppList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}