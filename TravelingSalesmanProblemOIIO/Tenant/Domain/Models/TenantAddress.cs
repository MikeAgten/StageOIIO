using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Domain.Models
{
    public class TenantAddress
    {
        public int TenantId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
