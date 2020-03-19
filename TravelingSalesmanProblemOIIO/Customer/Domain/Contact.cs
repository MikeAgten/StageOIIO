using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Domain
{
    public class Contact
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public enum ContactType
        {
            Tenant = 0,
            Customer = 1
        }
    }
}
