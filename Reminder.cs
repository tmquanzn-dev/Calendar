using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Reminder
    {
        public int ReminderId { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Note { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public bool IsNotified { get; set; } = false;
    }
}
