using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    public interface IAppointmentScheduler
    {
        List<Appointment> scheduleAppointments(List<AppointmentRequest> appointments, double[] costArray);

    }
}
