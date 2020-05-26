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
            var address = this.GetAll().Where(x => x.latitude == latitude && x.longitude == longitude).First();
            return address;
        }
        public List<Address> GetAll()
        {
            var address1 = new Address
            {
                latitude = 50.976131,
                longitude = 5.8186005,
                street = "Mijnweg",
                number = 3,
                postal = "6167 AC",
                city = "Geleen",
                country = "Nederland"
            };
            var address2 = new Address
            {
                latitude = 51.2294444,
                longitude = 5.3105231,
                street = "Kerkstraat",
                number = 51,
                postal = "3920",
                city = "Lommel",
                country = "België"
            };
            var address3 = new Address
            {
                latitude = 51.1427211,
                longitude = 5.3583471,
                street = "De Vreedestraat",
                number = 3,
                postal = "3940",
                city = "Eksel",
                country = "België"
            };
            var address4 = new Address
            {
                latitude = 51.0026234,
                longitude = 5.4996789,
                street = "Hoevezavellaan",
                number = 20,
                postal = "3600",
                city = "Genk",
                country = "België"
            };
            var address5 = new Address
            {
                latitude = 50.9371883,
                longitude = 5.3464778,
                street = "Elfde-Liniestraat",
                number = 25,
                postal = "3500",
                city = "Hasselt",
                country = "België"
            };
            var address6 = new Address
            {
                latitude = 51.2104694,
                longitude = 5.4199029,
                street = "Dorpsstraat",
                number = 91,
                postal = "3900",
                city = "Pelt",
                country = "België"
            };
            var address7 = new Address
            {
                latitude = 50.8579426,
                longitude = 5.709894,
                street = "Generaal Marshalllaan",
                number = 3,
                postal = "6224 XG",
                city = "Maastricht",
                country = "Nederland"
            };
            var address8 = new Address
            {
                latitude = 51.1150045,
                longitude = 5.2725964,
                street = "Zegeplaats",
                number = 18,
                postal = "3970",
                city = "Leopoldsburg",
                country = "België"
            };
            var address9 = new Address
            {
                latitude = 50.973324,
                longitude = 5.4931739,
                street = "Nieuwe kuilenweg",
                number = 80,
                postal = "3600",
                city = "Genk",
                country = "België"
            };
            var address10 = new Address
            {
                latitude = 51.1919203,
                longitude = 5.1196979,
                street = "Leenhofstraat",
                number = 15,
                postal = "2400",
                city = "Mol",
                country = "België"
            };
            var address11 = new Address
            {
                latitude = 51.140873,
                longitude = 5.5974333,
                street = "Markt",
                number = 1,
                postal = "3960",
                city = "Bree",
                country = "België"
            };
            var address12 = new Address
            {
                latitude = 51.0418056,
                longitude = 5.1865303,
                street = "PaalseSteenweg",
                number = 201,
                postal = "3583",
                city = "Paal",
                country = "België"
            };


            return new List<Address> { address1, address2, address3, address4, address5, address6, address7, address8, address9, address10, address11, address12 };
        }
    }
}

