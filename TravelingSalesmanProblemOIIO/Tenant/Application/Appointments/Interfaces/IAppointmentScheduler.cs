using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    public interface IAppointmentScheduler
    {
        List<Appointment> ScheduleAppointments(List<AppointmentRequest> appointments, double[] costArray);
    }
}
