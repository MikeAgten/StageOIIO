using AppointmentProj.Domain;
using AppointmentProj.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentProj.Persistence
{
    public class AppointmentRequestRepository
    {
        private readonly AppointmentDbContext dbContext;

        public AppointmentRequestRepository(AppointmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<int> SaveAsync(AppointmentRequest appointmentRequest, CancellationToken cancellationToken)
        {
            var result = await dbContext.AppointmentRequests.AddAsync(appointmentRequest, cancellationToken);
            await dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public virtual async Task<List<AppointmentRequest>> GetAsync(CancellationToken cancellationToken)
        {
            return await dbContext.AppointmentRequests.ToListAsync(cancellationToken);
        }

        public virtual async Task<List<AppointmentRequest>> GetByTenantIdAndDateAsync(int tenantId, DateTime date, CancellationToken cancellationToken)
        {
            return await dbContext.AppointmentRequests.Where(c => c.TenantId == tenantId && c.Date.Date == date.Date).ToListAsync(cancellationToken);
        }

        public virtual async Task PutAsync(AppointmentRequest appointmentRequest, CancellationToken cancellationToken)
        {

            dbContext.AppointmentRequests.Update(appointmentRequest);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<AppointmentRequest> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await dbContext.AppointmentRequests.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }


    }
}
