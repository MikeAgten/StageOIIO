using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Domain.Models
{
    public class Address
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string postal { get; set; }
        public string city { get; set; }
        public string country { get; set; }

    }
}
