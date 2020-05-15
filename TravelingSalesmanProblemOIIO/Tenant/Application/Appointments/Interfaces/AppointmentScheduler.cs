using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    class AppointmentScheduler : IAppointmentScheduler
    {
        DateTime startTime;
        public List<Appointment> scheduleAppointments(List<Appointment> appointments, double[] costArray)
        {
            startTime = appointments[0].Date;
            TimeSpan ts = new TimeSpan(8, 0, 0);
            startTime = startTime.Date + ts;
            for(int appointmentIndex = 0; appointmentIndex < appointments.Count; appointmentIndex++)
            {
                var appointment = appointments[appointmentIndex];
                appointment.Start = appointment.Date.Date + ts;
                TimeSpan toEnd = new TimeSpan(0, appointment.Duration,0);
                ts = ts.Add(toEnd);
                appointment.End = appointment.Date.Date + ts;
                Console.WriteLine("from: " + appointment.Start + " until " + appointment.End);
                TimeSpan toNextAppointment = new TimeSpan(0, Convert.ToInt32(Math.Round((costArray[appointmentIndex] + 4) / 5) * 5), 0);
                ts = ts.Add(toNextAppointment);
            }
            return appointments;
        }
    }
}
