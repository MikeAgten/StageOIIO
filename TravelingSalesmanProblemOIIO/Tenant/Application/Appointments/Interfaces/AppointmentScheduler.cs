using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    class AppointmentScheduler : IAppointmentScheduler
    {
        DateTime startTime;
        public List<Appointment> scheduleAppointments(List<Appointment> appointments)
        {
            startTime = appointments[0].Date;
            TimeSpan ts = new TimeSpan(8, 0, 0);
            startTime = startTime.Date + ts;
            foreach(Appointment appointment in appointments)
            {
                appointment.Start = appointment.Date.Date + ts;
                TimeSpan toAdd = new TimeSpan(0,appointment.Duration,0);
                ts = ts.Add(toAdd);
                appointment.End = appointment.Date.Date + ts;
                Console.WriteLine("from: " + appointment.Start + " until " + appointment.End);
            }
            return appointments;
        }
    }
}
