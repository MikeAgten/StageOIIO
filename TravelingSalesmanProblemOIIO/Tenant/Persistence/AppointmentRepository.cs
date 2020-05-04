using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace AppointmentProj.Persistance
{
    public class AppointmentRepository
    {
        private readonly AppointmentDbContext dbContext;

        public AppointmentRepository(AppointmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<int> SaveAsync(Appointment appointment, CancellationToken cancellationToken)
        {
            var result = await dbContext.Appointments.AddAsync(appointment, cancellationToken);
            await dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public virtual async Task PutAsync(Appointment appointment, CancellationToken cancellationToken)
        {

            dbContext.Appointments.Update(appointment);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<List<Appointment>> GetAsync(CancellationToken cancellationToken)
        {
                return await dbContext.Appointments.ToListAsync(cancellationToken);
        }

        public virtual async Task<List<Appointment>> GetByTenantIdAndDateAsync(int tenantId, DateTime date, CancellationToken cancellationToken)
        {
            return await dbContext.Appointments.Where(c => c.TenantId == tenantId && c.Date.Date == date.Date).ToListAsync(cancellationToken);
        }

        public virtual async Task<Appointment> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
                return await dbContext.Appointments.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            Appointment appointment = await dbContext.Appointments.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
            dbContext.Appointments.Remove(appointment);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
