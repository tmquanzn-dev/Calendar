using System;
using System.Linq;
using System.Windows.Forms;

namespace Calendar
{
    public partial class JoinWindow : Form
    {
        private Appointment _appointment;

        public JoinWindow(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;
        }

        private void JoinWindow_Load(object sender, EventArgs e)
        {
            lblAppName.Text = $"Cuộc hẹn: {_appointment.Name}  ({_appointment.Start:dd/MM/yyyy HH:mm} – {_appointment.End:HH:mm})";

            // Hiện danh sách user chưa tham gia
            var notJoined = CSDL.Instance.UserList
                                .Where(u => !_appointment.Participants.Any(p => p.UserId == u.UserId))
                                .ToList();
            clbUsers.DataSource = notJoined;
            clbUsers.DisplayMember = "UserName";
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (clbUsers.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một người dùng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm các user được chọn vào participants
            foreach (User u in clbUsers.CheckedItems)
            {
                if (!_appointment.Participants.Any(p => p.UserId == u.UserId))
                    _appointment.Participants.Add(u);
            }

            // Tạo hoặc cập nhật GroupMeeting
            var existing = CSDL.Instance.GroupMeetingList
                               .FirstOrDefault(g => g.AppointmentId == _appointment.AppointmentId);
            if (existing == null)
            {
                CSDL.Instance.GroupMeetingList.Add(new GroupMeeting(_appointment));
            }
            else
            {
                foreach (User u in clbUsers.CheckedItems)
                {
                    if (!existing.Participants.Any(p => p.UserId == u.UserId))
                        existing.Participants.Add(u);
                }
            }

            string list = string.Join("\n  • ", _appointment.Participants);
            MessageBox.Show(
                $"Đã tham gia '{_appointment.Name}'!\n\nDanh sách tham gia:\n  • {list}",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}