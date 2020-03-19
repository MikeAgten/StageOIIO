using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Double> Location { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public Customer Customer { get; set; }
        public Tenant Tenant { get; set; }



    }
}
