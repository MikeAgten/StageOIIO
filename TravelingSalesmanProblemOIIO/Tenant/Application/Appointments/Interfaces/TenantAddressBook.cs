using AppointmentProj.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    public class TenantAddressBook
    {
        public TenantAddress GetAddress(int tenantId)
        {
            return this.GetAll().Where(x => x.TenantId == tenantId).First();
        }

        public List<TenantAddress> GetAll()
        {
            var tenantAddress1 = new TenantAddress
            {
                TenantId = 1,
                Latitude = 51.1493726,
                Longitude = 5.386052
            };
            var tenantAddress2 = new TenantAddress
            {
                TenantId = 2,
                Latitude = 50.9789124,
                Longitude = 5.8429997
            };
            var tenantAddress3 = new TenantAddress
            {
                TenantId = 18,
                Latitude = 50.9382666,
                Longitude = 5.3487666
            };
            var tenantAddress4 = new TenantAddress
            {
                TenantId = 19,
                Latitude = 51.2100941,
                Longitude = 5.4228102
            };
            return new List<TenantAddress> { tenantAddress1, tenantAddress2, tenantAddress3, tenantAddress4 };
        }
    }
}
