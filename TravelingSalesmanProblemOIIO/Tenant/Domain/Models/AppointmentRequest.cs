using System;

namespace AppointmentProj.Domain
{
    public class AppointmentRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int TenantId { get; set; }

        public int? AppointmentId { get; set; }

        public DateTime CreatedDateUtc { get; set; }

    }
}
