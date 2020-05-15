using ContactProj.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Application.Contacts.Queries.GetContactById
{
    public class GetContactByIdQueryDto
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
