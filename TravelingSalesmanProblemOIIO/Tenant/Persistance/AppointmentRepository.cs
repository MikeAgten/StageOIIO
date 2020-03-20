using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentProj.Persistance
{
    public class AppointmentRepository
    {
        public AppointmentRepository()
        {

        }
        public virtual void SaveAsync(Appointment appointment)
        {
            using(var context = new AppointmentDbContext())
            {
                context.Appointments.Add(appointment);
                context.SaveChanges();
            }
        }

        public virtual void PutAsync(Appointment appointment)
        {
            using (var context = new AppointmentDbContext())
            {
                context.Appointments.Update(appointment);
                context.SaveChanges();
            }
        }

        public virtual Task<List<Appointment>> GetAsync()
        {
            using (var context = new AppointmentDbContext())
            {
                List<Appointment> appointments = context.Appointments.ToList();
                return Task.FromResult(appointments);
            }
        }

        public virtual Task<Appointment> GetByIdAsync(int id)
        {
            using (var context = new AppointmentDbContext())
            {
                Appointment appointment = context.Appointments.Where(c => c.Id == id).Single();
                return Task.FromResult(appointment);
            }
        }

        public virtual Task<Appointment> DeleteByIdAsync(int id)
        {
            using (var context = new AppointmentDbContext())
            {
                Appointment appointment = context.Appointments.Where(c => c.Id == id).Single();
                context.Appointments.Remove(appointment);
                context.SaveChanges();
                return Task.FromResult(appointment);
            }
        }
    }
}
