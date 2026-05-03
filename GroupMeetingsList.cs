using System;
using System.Linq;
using System.Windows.Forms;

namespace Calendar
{
    public partial class GroupMeetingsList : Form
    {
        public GroupMeetingsList()
        {
            InitializeComponent();
        }

        private void GroupMeetingsList_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            //Double click de xem chi tiet nguoi tham gia
            dgvGroupMeetings.CellDoubleClick += DgvGroupMeetings_CellDoubleClick;
        }

        private void RefreshGrid()
        {
            var data = CSDL.Instance.GroupMeetingList
                           .Select(g => new
                           {
                               Name = g.Name,
                               StartTime = g.Start.ToString("dd/MM/yyyy HH:mm"),
                               EndTime = g.End.ToString("dd/MM/yyyy HH:mm"),
                               Participants = g.Participants.Count
                           })
                           .ToList();

            dgvGroupMeetings.DataSource = data;

            if (dgvGroupMeetings.Columns.Count > 0)
            {
                dgvGroupMeetings.Columns["Name"].HeaderText = "Tên cuộc họp";
                dgvGroupMeetings.Columns["StartTime"].HeaderText = "Bắt đầu";
                dgvGroupMeetings.Columns["EndTime"].HeaderText = "Kết thúc";
                dgvGroupMeetings.Columns["Participants"].HeaderText = "Số người tham gia";
            }

            dgvGroupMeetings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGroupMeetings.ReadOnly = true;
            dgvGroupMeetings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DgvGroupMeetings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var gm = CSDL.Instance.GroupMeetingList[e.RowIndex];
            string participantList = gm.Participants.Count > 0
                ? string.Join("\n  • ", gm.Participants.Select(u => u.UserName))
                : "(chưa có ai)";

            MessageBox.Show(
                $"Cuộc họp: {gm.Name}\n" +
                $"Bắt đầu:  {gm.Start:dd/MM/yyyy HH:mm}\n" +
                $"Kết thúc: {gm.End:dd/MM/yyyy HH:mm}\n\n" +
                $"Danh sách tham gia ({gm.Participants.Count} người):\n  • {participantList}",
                "Chi tiết cuộc họp",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dgvGroupMeetings.CurrentRow == null || dgvGroupMeetings.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một cuộc họp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var gm = CSDL.Instance.GroupMeetingList[dgvGroupMeetings.CurrentRow.Index];
            string participantList = gm.Participants.Count > 0
                ? string.Join("\n  • ", gm.Participants.Select(u => u.UserName))
                : "(chưa có ai)";

            MessageBox.Show(
                $"Cuộc họp: {gm.Name}\n" +
                $"Bắt đầu:  {gm.Start:dd/MM/yyyy HH:mm}\n" +
                $"Kết thúc: {gm.End:dd/MM/yyyy HH:mm}\n\n" +
                $"Danh sách tham gia ({gm.Participants.Count} người):\n  • {participantList}",
                "Chi tiết cuộc họp",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}