using System;
using System.Linq;
using System.Windows.Forms;

namespace Calendar
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            cbbApp.DataSource = CSDL.Instance.AppointmentList;
            cbbApp.DisplayMember = "Name";
            cbbApp.SelectedIndexChanged += CbbApp_SelectedIndexChanged;
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