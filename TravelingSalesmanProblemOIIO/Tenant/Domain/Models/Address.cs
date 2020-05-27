using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Domain.Models
{
    public class Address
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Postal { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
