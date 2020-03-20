using ContactProj.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactProj.Persistance
{
    public class ContactRepository
    {
        public ContactRepository()
        {

        }
        public virtual Task SaveAsync(Contact customer)
        {
            using(var context = new ContactDbContext())
            {
                context.Contacts.Add(customer);
                context.SaveChanges();
                return Task.FromResult(customer);
            }
        }

        public virtual Task<Contact> PutAsync(Contact customer)
        {
            using (var context = new ContactDbContext())
            {
                context.Contacts.Update(customer);
                context.SaveChanges();
                return Task.FromResult(customer);
            }
        }

        public virtual Task<List<Contact>> GetAsync()
        {
            using (var context = new ContactDbContext())
            {
                List<Contact> customers = context.Contacts.ToList();
                return Task.FromResult(customers);
            }
        }

        public virtual Task<Contact> GetByIdAsync(int id)
        {
            using (var context = new ContactDbContext())
            {
                Contact customer = context.Contacts.Where(c => c.Id == id).Single();
                return Task.FromResult(customer);
            }
        }

        public virtual Task<Contact> DeleteByIdAsync(int id)
        {
            using (var context = new ContactDbContext())
            {
                Contact customer = context.Contacts.Where(c => c.Id == id).Single();
                context.Contacts.Remove(customer);
                context.SaveChanges();
                return Task.FromResult(customer);
            }
        }
    }
}
