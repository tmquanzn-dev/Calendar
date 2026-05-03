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
    public partial class AddReminderWindow : Form
    {
        public AddReminderWindow()
        {
            InitializeComponent();
            SetGUI();
        }

        private void SetGUI()
        {
            // BindingList tự cập nhật khi AppointmentList thay đổi
            cbbApp.DataSource = CSDL.Instance.AppointmentList;
            cbbApp.DisplayMember = "Name";
            cbbApp.ValueMember = "AppointmentId";
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            Appointment appointment = cbbApp.SelectedItem as Appointment;

            if (appointment == null)
            {
                MessageBox.Show("Vui lòng chọn một cuộc hẹn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ReminderTxt.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung lời nhắc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ReminderTime1.Value >= appointment.Start)
            {
                MessageBox.Show(
                    $"Thời gian nhắc phải trước thời gian bắt đầu cuộc hẹn ({appointment.Start:dd/MM/yyyy HH:mm}).",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newId = appointment.Reminders.Count > 0
                ? appointment.Reminders.Max(r => r.ReminderId) + 1
                : 1;

            var reminder = new Reminder
            {
                ReminderId = newId,
                ReminderTime = ReminderTime1.Value,
                Note = ReminderTxt.Text.Trim(),
                AppointmentId = appointment.AppointmentId,
                Appointment = appointment
            };

            appointment.Reminders.Add(reminder);
            CSDL.Instance.ReminderList.Add(reminder);
            CSDL.Instance.Reminder_AppointmentList.Add(new Reminder_Appointment
            {
                Name = appointment.Name,
                Location = appointment.Location,
                Start = appointment.Start,
                End = appointment.End,
                ReminderTime = reminder.ReminderTime,
                Note = reminder.Note
            });

            MessageBox.Show("Đã thêm lời nhắc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReminderTxt.Text = "";
        }

        private void ExitBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}