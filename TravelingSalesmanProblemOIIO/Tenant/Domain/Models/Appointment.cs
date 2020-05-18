using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Duration { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ClientId { get; set; }
        public int TenantId { get; set; }

        public DateTime CreatedDateUtc { get; set; }



    }
}
