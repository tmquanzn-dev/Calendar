using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Calendar
{
    public class CSDL
    {
        private static CSDL _Instance;
        private BindingList<Appointment> Appointmentlist;
        private BindingList<Reminder> Reminderlist;
        private BindingList<Reminder_Appointment> Reminder_Appointmentlist;
        private List<GroupMeeting> GroupMeetinglist;
        private BindingList<User> Userlist;

        public User CurrentUser { get; private set; } = new User(1, "Me");

        private CSDL()
        {
            Appointmentlist = new BindingList<Appointment>();
            Reminderlist = new BindingList<Reminder>();
            Reminder_Appointmentlist = new BindingList<Reminder_Appointment>();
            GroupMeetinglist = new List<GroupMeeting>();
            Userlist = new BindingList<User>();
            Userlist.Add(CurrentUser);
        }

        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CSDL();
                return _Instance;
            }
        }

        public BindingList<Appointment> AppointmentList => Appointmentlist;
        public BindingList<Reminder> ReminderList => Reminderlist;
        public BindingList<Reminder_Appointment> Reminder_AppointmentList => Reminder_Appointmentlist;
        public List<GroupMeeting> GroupMeetingList => GroupMeetinglist;
        public BindingList<User> UserList => Userlist;
    }
}