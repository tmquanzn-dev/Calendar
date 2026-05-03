using System;
using System.Collections.Generic;

namespace Calendar
{
    public class GroupMeeting : Appointment
    {
        public Appointment SourceAppointment { get; set; }

        public GroupMeeting(Appointment appointment)
        {
            SourceAppointment = appointment;
            AppointmentId = appointment.AppointmentId;
            Name = appointment.Name;
            Location = appointment.Location;
            Start = appointment.Start;
            End = appointment.End;
            Participants = new List<User>(appointment.Participants);
        }
    }
}