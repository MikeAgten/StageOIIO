using ContactProj.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactProj.Persistance
{
    public class ContactRepository
    {
        private readonly ContactDbContext dbContext;

        public ContactRepository(ContactDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public virtual async Task<int> SaveAsync(Contact customer, CancellationToken cancellationToken)
        {
            var result = await dbContext.Contacts.AddAsync(customer, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return result.Entity.Id;
        }

        public virtual async Task PutAsync(Contact customer, CancellationToken cancellationToken)
        {
            dbContext.Contacts.Update(customer);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<List<Contact>> GetAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Contacts.ToListAsync(cancellationToken);
        }

        public virtual async Task<Contact> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await dbContext.Contacts.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var customer = await dbContext.Contacts.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
            dbContext.Contacts.Remove(customer);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
