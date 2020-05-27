using AppointmentProj.Application.Appointments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentProj.Domain.Models
{
    public class AddressBook
    {
        public Address GetAddress(double latitude, double longitude)
        {
            return this.GetAll().Where(x => x.Latitude == latitude && x.Longitude == longitude).First();
        }
        public List<Address> GetAll()
        {
            var address1 = new Address
            {
                Latitude = 50.976131,
                Longitude = 5.8186005,
                Street = "Mijnweg",
                Number = 3,
                Postal = "6167 AC",
                City = "Geleen",
                Country = "Nederland"
            };
            var address2 = new Address
            {
                Latitude = 51.2294444,
                Longitude = 5.3105231,
                Street = "Kerkstraat",
                Number = 51,
                Postal = "3920",
                City = "Lommel",
                Country = "België"
            };
            var address3 = new Address
            {
                Latitude = 51.1427211,
                Longitude = 5.3583471,
                Street = "De Vreedestraat",
                Number = 3,
                Postal = "3940",
                City = "Eksel",
                Country = "België"
            };
            var address4 = new Address
            {
                Latitude = 51.0026234,
                Longitude = 5.4996789,
                Street = "Hoevezavellaan",
                Number = 20,
                Postal = "3600",
                City = "Genk",
                Country = "België"
            };
            var address5 = new Address
            {
                Latitude = 50.9371883,
                Longitude = 5.3464778,
                Street = "Elfde-Liniestraat",
                Number = 25,
                Postal = "3500",
                City = "Hasselt",
                Country = "België"
            };
            var address6 = new Address
            {
                Latitude = 51.2104694,
                Longitude = 5.4199029,
                Street = "Dorpsstraat",
                Number = 91,
                Postal = "3900",
                City = "Pelt",
                Country = "België"
            };
            var address7 = new Address
            {
                Latitude = 50.8579426,
                Longitude = 5.709894,
                Street = "Generaal Marshalllaan",
                Number = 3,
                Postal = "6224 XG",
                City = "Maastricht",
                Country = "Nederland"
            };
            var address8 = new Address
            {
                Latitude = 51.1150045,
                Longitude = 5.2725964,
                Street = "Zegeplaats",
                Number = 18,
                Postal = "3970",
                City = "Leopoldsburg",
                Country = "België"
            };
            var address9 = new Address
            {
                Latitude = 50.973324,
                Longitude = 5.4931739,
                Street = "Nieuwe kuilenweg",
                Number = 80,
                Postal = "3600",
                City = "Genk",
                Country = "België"
            };
            var address10 = new Address
            {
                Latitude = 51.1919203,
                Longitude = 5.1196979,
                Street = "Leenhofstraat",
                Number = 15,
                Postal = "2400",
                City = "Mol",
                Country = "België"
            };
            var address11 = new Address
            {
                Latitude = 51.140873,
                Longitude = 5.5974333,
                Street = "Markt",
                Number = 1,
                Postal = "3960",
                City = "Bree",
                Country = "België"
            };
            var address12 = new Address
            {
                Latitude = 51.0418056,
                Longitude = 5.1865303,
                Street = "PaalseSteenweg",
                Number = 201,
                Postal = "3583",
                City = "Paal",
                Country = "België"
            };

            return new List<Address> { address1, address2, address3, address4, address5, address6, address7, address8, address9, address10, address11, address12 };
        }
    }
}

