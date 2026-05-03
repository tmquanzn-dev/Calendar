using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Calendar
{
    public partial class AddAppointmentWindow : Form
    {
        public AddAppointmentWindow()
        {
            InitializeComponent();
        }

        public AddAppointmentWindow(DateTime defaultStart, DateTime defaultEnd)
        {
            InitializeComponent();
            StartTime.Value = defaultStart;
            EndTime.Value = defaultEnd;
        }

        private void AddAppbut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AppNameText.Text))
            {
                MessageBox.Show("Tên cuộc hẹn không được để trống.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime start = StartTime.Value;
            DateTime end = EndTime.Value;

            if (end <= start)
            {
                MessageBox.Show("Thời gian kết thúc phải sau thời gian bắt đầu.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (start < DateTime.Now)
            {
                MessageBox.Show("Thời gian bắt đầu không được ở quá khứ.", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = AppNameText.Text.Trim();
            TimeSpan duration = end - start;
            User me = CSDL.Instance.CurrentUser;

            var overlap = CSDL.Instance.AppointmentList
                              .FirstOrDefault(a => start < a.End && end > a.Start);
            if (overlap != null)
            {
                var r = MessageBox.Show(
                    $"Trùng lịch với '{overlap.Name}' ({overlap.Start:HH:mm} – {overlap.End:HH:mm}).\nBạn có muốn THAY THẾ không?",
                    "Cảnh báo trùng lịch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                    CSDL.Instance.AppointmentList.Remove(overlap);
                else
                    return;
            }

            var groupMeeting = CSDL.Instance.AppointmentList
                                   .FirstOrDefault(a =>
                                       a.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                       && a.Duration == duration);
            if (groupMeeting != null)
            {
                var r = MessageBox.Show(
                    $"Đã có cuộc họp nhóm '{groupMeeting.Name}' cùng tên và thời lượng.\nBạn có muốn THAM GIA không?",
                    "Tham gia cuộc họp nhóm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    if (!groupMeeting.Participants.Any(u => u.UserId == me.UserId))
                        groupMeeting.Participants.Add(me);

                    string list = string.Join("\n  • ", groupMeeting.Participants);
                    MessageBox.Show($"Đã tham gia '{groupMeeting.Name}'!\n\n  • {list}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    return;
                }
            }

            int newId = CSDL.Instance.AppointmentList.Count > 0
                ? CSDL.Instance.AppointmentList.Max(a => a.AppointmentId) + 1
                : 1;

            CSDL.Instance.AppointmentList.Add(new Appointment
            {
                AppointmentId = newId,
                Name = name,
                Location = AppLocationText.Text.Trim(),
                Start = start,
                End = end,
                Participants = new List<User> { me }
            });

            MessageBox.Show("Đã thêm cuộc hẹn thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }

        private void ClearForm()
        {
            AppNameText.Text = "";
            AppLocationText.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}