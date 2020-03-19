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
        internal Task SaveAsync(Appointment tenant)
        {
            using(var context = new AppointmentDbContext())
            {
                context.Appointments.Add(tenant);
                context.SaveChanges();
                return Task.FromResult(tenant);
            }
        }

        internal Task<Appointment> PutAsync(Appointment tenant)
        {
            using (var context = new AppointmentDbContext())
            {
                context.Appointments.Update(tenant);
                context.SaveChanges();
                return Task.FromResult(tenant);
            }
        }

        internal Task<List<Appointment>> GetAsync()
        {
            using (var context = new AppointmentDbContext())
            {
                List<Appointment> tenants = context.Appointments.ToList();
                return Task.FromResult(tenants);
            }
        }

        internal Task<Appointment> GetByIdAsync(int id)
        {
            using (var context = new AppointmentDbContext())
            {
                Appointment tenant = context.Appointments.Where(c => c.Id == id).Single();
                return Task.FromResult(tenant);
            }
        }

        internal Task<Appointment> DeleteByIdAsync(int id)
        {
            using (var context = new AppointmentDbContext())
            {
                Appointment tenant = context.Appointments.Where(c => c.Id == id).Single();
                context.Appointments.Remove(tenant);
                context.SaveChanges();
                return Task.FromResult(tenant);
            }
        }
    }
}
