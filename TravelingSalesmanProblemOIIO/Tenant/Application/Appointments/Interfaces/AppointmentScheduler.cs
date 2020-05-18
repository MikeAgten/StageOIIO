using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    class AppointmentScheduler : IAppointmentScheduler
    {
        DateTime startTime;
        public List<Appointment> scheduleAppointments(List<AppointmentRequest> appointmentRequests, double[] costArray)
        {
            startTime = appointmentRequests[1].Date;
            TimeSpan ts = new TimeSpan(8, 0, 0);
            startTime = startTime.Date + ts;
            TimeSpan toFirstAppointmentTime = new TimeSpan(0, Convert.ToInt32(Math.Round((costArray[0] + 4) / 5) * 5), 0);
            ts = ts.Add(toFirstAppointmentTime);
            var appointments = new List<Appointment>();
            for(int appointmentIndex = 1; appointmentIndex < appointmentRequests.Count; appointmentIndex++)
            {
                var Req = appointmentRequests[appointmentIndex];
                var appointment = new Appointment
                {
                    Id = Req.Id,
                    Title = Req.Title,
                    Description = Req.Description,
                    Latitude = Req.Latitude,
                    Longitude = Req.Longitude,
                    Duration = Req.Duration,
                    Date = Req.Date,
                    ClientId = Req.ClientId,
                    TenantId = Req.TenantId,
                    CreatedDateUtc = DateTime.Now
                };
                appointment.Start = Req.Date + ts;
                TimeSpan toEnd = new TimeSpan(0, Req.Duration, 0);
                ts = ts.Add(toEnd);
                appointment.End = Req.Date + ts;
                appointments.Add(appointment);
                TimeSpan toNextAppointment = new TimeSpan(0, Convert.ToInt32(Math.Round((costArray[appointmentIndex] + 4) / 5) * 5), 0);
                ts = ts.Add(toNextAppointment);
            }
            return appointments;
            /*for (int appointmentIndex = 0; appointmentIndex < appointments.Count; appointmentIndex++)
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
            return appointments;*/
        }
    }
}
