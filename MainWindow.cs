using System;
using System.Linq;
using System.Windows.Forms;

namespace Calendar
{
    public partial class MainWindow : Form
    {
        private System.Windows.Forms.Timer _reminderTimer;
        public MainWindow()
        {
            InitializeComponent();
            cbbApp.DataSource = CSDL.Instance.AppointmentList;
            cbbApp.DisplayMember = "Name";
            cbbApp.SelectedIndexChanged += CbbApp_SelectedIndexChanged;

            // Khởi tạo timer để kiểm tra nhắc nhở mỗi 10 giây
            _reminderTimer = new System.Windows.Forms.Timer();
            _reminderTimer.Interval = 10000; 
            _reminderTimer.Tick += ReminderTimer_Tick;
            _reminderTimer.Start();
        }

        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            var due = CSDL.Instance.ReminderList
                          .Where(r => !r.IsNotified && r.ReminderTime <= now)
                          .ToList();

            foreach (var r in due)
            {
                r.IsNotified = true; // không nhắc lạiđánh dấu đã nhắc, 

                MessageBox.Show(
                    $"⏰ Lời nhắc: {r.Note}\n\n" +
                    $"Cuộc hẹn : {r.Appointment.Name}\n" +
                    $"Địa điểm : {r.Appointment.Location}\n" +
                    $"Bắt đầu  : {r.Appointment.Start:dd/MM/yyyy HH:mm}\n" +
                    $"Kết thúc : {r.Appointment.End:HH:mm}",
                    "🔔 Nhắc nhở lịch hẹn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void CbbApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbApp.SelectedItem is Appointment selected)
            {
                lblParticipants.Text = "Participants: " +
                    (selected.Participants.Count > 0
                        ? string.Join(", ", selected.Participants)
                        : "(chưa có ai)");
            }
            else
            {
                lblParticipants.Text = "Participants: —";
            }
        }

        private void JoinBut_Click(object sender, EventArgs e)
        {
            if (!(cbbApp.SelectedItem is Appointment selected))
            {
                MessageBox.Show("Vui lòng chọn một cuộc hẹn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở JoinWindow để chọn user tham gia
            JoinWindow jw = new JoinWindow(selected);
            jw.ShowDialog();

            // Cập nhật label sau khi đóng JoinWindow
            lblParticipants.Text = "Participants: " +
                (selected.Participants.Count > 0
                    ? string.Join(", ", selected.Participants)
                    : "(chưa có ai)");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddAppointmentWindow().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AppointmentsList().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new RemindersList().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AddReminderWindow().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new GroupMeetingsList().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new ManageUsersWindow().ShowDialog();
        }
    }
}