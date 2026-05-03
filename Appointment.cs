using System;
using System.Collections.Generic;

namespace Calendar
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Reminder> Reminders { get; set; } = new List<Reminder>();
        public List<User> Participants { get; set; } = new List<User>();
        public TimeSpan Duration { get { return End - Start; } }
    }
}