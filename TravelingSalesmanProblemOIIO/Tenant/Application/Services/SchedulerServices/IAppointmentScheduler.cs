using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Services.SchedulerServices
{
    public interface IAppointmentScheduler
    {
        Dictionary<int, Appointment> ScheduleAppointments(List<AppointmentRequest> appointments, double[] costArray);
    }
}
